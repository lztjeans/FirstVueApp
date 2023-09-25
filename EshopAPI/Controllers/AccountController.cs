using FirstApp.Models;
using FirstApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Microsoft.IdentityModel.Tokens;
using EshopAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Ardalis.Result;
using Microsoft.AspNetCore.Cors;

namespace EshopAPI.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> _signinManager;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AccountController(UserManager<ApplicationUser> userMgr, SignInManager<ApplicationUser> signinMgr)
        {
            userManager = userMgr;
            _signinManager = signinMgr;
        }

        [HttpPost("login")]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<SignInResult> Login(LoginViewModel login)
        {
            ApplicationUser appUser = await userManager.FindByEmailAsync(login.Email);
            if (appUser != null)
            {
                await _signinManager.SignOutAsync();
                SignInResult result = await _signinManager.PasswordSignInAsync(appUser, login.Password, login.Remember, false);
                
                return result;
            }
            return null;
        }

        //[Authorize]
        [HttpGet("logout")]
        public async Task<Result> Logout()
        {
            await _signinManager.SignOutAsync();
            logger.Info("User signed out.");
            //return NoContent();
            return Result.Success();
        }

        //empl
        //Create
        [HttpPost("empl/add")]
        public async Task<IActionResult> Create(ApplicationUserDTO userDTO)
        {
            ApplicationUser appUser = userDTO.ToEntity();
            IdentityResult result = await userManager.CreateAsync(appUser, appUser.Password);
            if (result.Succeeded)
                return NoContent();
            else
                return BadRequest(result.Errors);
        }

        ////Read
        [HttpGet("empl/get")]
        public List<ApplicationUserDTO> Index()
        {
            List<ApplicationUserDTO> results = new();
            userManager.Users.ToList().ForEach(x => {
                var v = new ApplicationUserDTO(x); 
                results.Add(new ApplicationUserDTO(x));
            });

            return results;
        }

        [HttpGet("empl/get/{id}")]
        public ApplicationUserDTO? Index(string id)
        {
            try
            {
                return new ApplicationUserDTO(userManager.Users.First(x => x.Id == id));
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        ////Update
        [HttpPut("empl/upd")]
        public async Task<IActionResult> Update(ApplicationUserDTO userDTO)
        {
            //string id, string UserName, string email, string Age, string Salary, string Department, char Sex
            if (userDTO != null)
            {
                ApplicationUser user = await userManager.FindByIdAsync(userDTO.Id);
                if (!string.IsNullOrEmpty(userDTO.Username))
                    user.UserName = userDTO.Username;
                else
                    ModelState.AddModelError("", "UserName cannot be empty");

                if (!string.IsNullOrEmpty(userDTO.Email))
                    user.Email = userDTO.Email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(userDTO.Age))
                    //user.PasswordHash = passwordHasher.HashPassword(user, password);
                    user.Age = Convert.ToInt32(userDTO.Age);
                else
                    ModelState.AddModelError("", "Age cannot be empty");

                if (!string.IsNullOrEmpty(userDTO.Salary))
                    user.Salary = Convert.ToDecimal(userDTO.Salary);
                else
                    ModelState.AddModelError("", "Salary cannot be empty");

                if (!string.IsNullOrEmpty(userDTO.Department))
                    user.Department = userDTO.Department;
                else
                    ModelState.AddModelError("", "Department cannot be empty");

                user.Sex = Convert.ToChar( userDTO.Sex);
                if (ModelState.ErrorCount == 0)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return NoContent();
                    else
                        return BadRequest(result.Errors);
                }
            }
            return NotFound();
        }

        //Delete
        [HttpDelete("empl/del/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return NoContent();
            }
            else
                return NotFound("User Not Found");

        }
    }


}
