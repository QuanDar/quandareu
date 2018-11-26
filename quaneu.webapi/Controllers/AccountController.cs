

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using quaneu.datalayer;
using quaneu.datalayer.Entities.Models.Users;
using quaneu.webapi.Helpers;
using quaneu.webapi.ViewModels;

namespace quaneu.webapi.Controllers
{
    [Route("api/[controller]")] 
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _caller;

        public AccountController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;
            _caller = httpContextAccessor.HttpContext.User;
        }

        // POST api/accounts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.QuanUsers.AddAsync(new QuanUser { IdentityId = userIdentity.Id });
            await _appDbContext.SaveChangesAsync();

            return Ok("Account created");
        }
        
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            // Get user id from with token. 
            var userId = _caller.Claims.Single(c => c.Type == "id").Value;
            // Find user in database
            var user = await _appDbContext.QuanUsers.Include(c => c.Identity).SingleAsync(c => c.Identity.Id == userId);

            return Ok(new
            {
                Message = "This is secure API and user data!",
                user.Identity.UserName,
                user.Identity.FirstName,
                user.Identity.LastName,
                user.Identity.PictureUrl,
                user.Identity.FacebookId,
            });
        }
    }
}
