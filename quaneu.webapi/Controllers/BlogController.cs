using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer;
using quaneu.datalayer.Contracts;
using quaneu.datalayer.Entities.Extensions;
using quaneu.datalayer.Models.Blog;

namespace quaneu.webapi.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private IRepositoryWrapper _repoWrapper;

        public BlogController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }


        // GET: api/Blog
        [HttpGet("post")]
        public async Task<IEnumerable<PostBlogViewModel>> GetPosts()
        {
            return await _repoWrapper.Posts.GetPosts();
        }

        // GET: api/Blog
        [HttpGet]
        public async Task<IEnumerable<Blog>> GetBlog()
        {
            return await _repoWrapper.Blogs.FindAll();
        }

        // GET: api/Blogs/5
        [HttpGet("post/{id}")]
        public async Task<IActionResult> GetPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _repoWrapper.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet("blog/{id}")]
        public async Task<IActionResult> GetBlog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _repoWrapper.Blogs.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Blog/post/5
        [HttpPut("post/{id}")]
        public async Task<IActionResult> PutPost([FromRoute] int id, [FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            _repoWrapper.Posts.Add(post);

            try
            {
                await _repoWrapper.Posts.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Blog/post
        [HttpPost("post")]
        public async Task<IActionResult> PostPost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repoWrapper.Posts.Add(post);
            await _repoWrapper.Posts.Save();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = await _repoWrapper.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _repoWrapper.Posts.Delete(post);
            await _repoWrapper.Posts.Save();

            return Ok(post);
        }

        private bool PostExists(int id)
        {
            return _repoWrapper.Posts.Any(e => e.Id == id);
        }
    }
}