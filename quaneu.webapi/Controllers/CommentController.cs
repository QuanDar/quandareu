using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Entities.Models.Users;
using quaneu.datalayer.Models.Blog;
using quaneu.webapi.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace quaneu.webapi.Controllers
{
#warning testing roles and policy. Role not used in future. 
    [Authorize(Policy = "QuanUser")]//, Roles = "Blogger")]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        private ApplicationDbContext _appDbContext;
        private readonly ClaimsPrincipal _caller;

        public CommentController(IRepositoryWrapper repoWrapper, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _repoWrapper = repoWrapper;
            _appDbContext = appDbContext;
            _caller = httpContextAccessor.HttpContext.User;
        }



        // GET: api/Comment
        [HttpGet("post/{postId}")]
        public async Task<IEnumerable<CommentViewModel>> GetComments(int postId)
        {
            return await _repoWrapper.Comments.GetCommentsCommentViewModel(postId);
        }

        // GET: api/Comments/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _repoWrapper.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [HttpPut]
        public async Task<IActionResult> PutComment([FromBody] CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get user id from with token. 
            var userId = _caller.Claims.Single(c => c.Type == "id").Value;
            // Find user in database
            var user = await _appDbContext.QuanUsers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId);

#warning is dit voldoende beveiligd? 
            // Instead of taken UserName from commentViewModel, let the backend look for the username.
            Comment comment = _repoWrapper.Comments.Find(commentViewModel.CommentId);

            if (user.Identity.UserName != comment.UserName)
            {
                return Unauthorized();
            }

            comment.PostId = commentViewModel.PostId;
            comment.UserName = user.Identity.UserName;
            comment.CommentText = commentViewModel.CommentText;
            comment.ParentCommentId = commentViewModel.ParentCommentId;

            _repoWrapper.Comments.Update(comment);
            await _repoWrapper.Comments.Save();
            try
            {
                await _repoWrapper.Comments.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(commentViewModel.CommentId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(comment);
        }

        // POST: api/Comments
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Get user id from with token. 
            var userId = _caller.Claims.Single(c => c.Type == "id").Value;
            // Find user in database
            var user = await _appDbContext.QuanUsers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId);

            if (user == null)
            {
                return BadRequest("User not accepted");
            }

            Comment comment = new Comment
            {
                PostId = commentViewModel.PostId,
                UserName = user.Identity.UserName,
                AddDate = commentViewModel.AddDate,
                CommentText = commentViewModel.CommentText,
                UpVotes = commentViewModel.UpVotes,
                DownVotes = commentViewModel.DownVotes,
                ParentCommentId = commentViewModel.ParentCommentId
            };

            _repoWrapper.Comments.Add(comment);
            await _repoWrapper.Comments.Save();

            return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

#warning er moet extra controle worden gedaan of de user wel echt de user is. 

            var commentFromDb = await _repoWrapper.Comments.FindAsync(id);
            if (commentFromDb == null)
            {
                return NotFound();
            }

            _repoWrapper.Comments.Delete(commentFromDb);
            await _repoWrapper.Comments.Save();

            return Ok(commentFromDb);
        }

        private bool CommentExists(int id)
        {
            return _repoWrapper.Comments.Any(e => e.CommentId == id);
        }
    }
}