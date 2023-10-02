using Microsoft.AspNetCore.Mvc;
using NLog;
using EshopAPI.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace EshopAPI.Controllers
{

    [EnableCors("MyPolicy")]
    [Route("/prod")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private UserManager<ApplicationUser> userManager;
        //private SignInManager<ApplicationUser> _signinManager;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public ProductController()
        {
            //userManager = userMgr;
            //_signinManager = signinMgr;
        }


        //empl
        //Create
        [HttpPost("add")]
        public async Task<IActionResult> Create(ApplicationUserDTO userDTO)
        {
            //ApplicationUser appUser = userDTO.ToEntity();
            //IdentityResult result = await userManager.CreateAsync(appUser, appUser.Password);
            //if (result.Succeeded)
            return NoContent();
            //else
            //    return BadRequest(result.Errors);
        }

        ////Read
        [HttpGet("list")]
        public List<Dictionary<string, string>> Index()
        {
            List<Dictionary<string, string>> results = new();
            Dictionary<string, string> parir = new()
            {
                { "name", "abc" },
                { "description", "desc" },
                { "price", "15555" },
                { "pic", "33" },
                { "typename", "123" },
                { "brand", "e1f" },
                { "updateLink", "2" },
                { "deleteLink", "3" }
            };
            results.Add(parir);
            return results;
        }

        [HttpGet("get/{id}")]
        public ApplicationUserDTO? Index(string id)
        {
            //try
            //{
            //    return new ApplicationUserDTO(userManager.Users.First(x => x.Id == id));
            //}
            //catch (InvalidOperationException)
            //{
            return null;
            //}
        }

        ////Update
        [HttpPut("upd")]
        public async Task<IActionResult> Update(ApplicationUserDTO userDTO)
        {
            //string id, string UserName, string email, string Age, string Salary, string Department, char Sex
            //if (userDTO != null)
            //{
            //    ApplicationUser user = await userManager.FindByIdAsync(userDTO.Id);
            //    if (!string.IsNullOrEmpty(userDTO.Username))
            //        user.UserName = userDTO.Username;
            //    else
            //        ModelState.AddModelError("", "UserName cannot be empty");

            //    if (!string.IsNullOrEmpty(userDTO.Email))
            //        user.Email = userDTO.Email;
            //    else
            //        ModelState.AddModelError("", "Email cannot be empty");

            //    if (!string.IsNullOrEmpty(userDTO.Age))
            //        //user.PasswordHash = passwordHasher.HashPassword(user, password);
            //        user.Age = Convert.ToInt32(userDTO.Age);
            //    else
            //        ModelState.AddModelError("", "Age cannot be empty");

            //    if (!string.IsNullOrEmpty(userDTO.Salary))
            //        user.Salary = Convert.ToDecimal(userDTO.Salary);
            //    else
            //        ModelState.AddModelError("", "Salary cannot be empty");

            //    if (!string.IsNullOrEmpty(userDTO.Department))
            //        user.Department = userDTO.Department;
            //    else
            //        ModelState.AddModelError("", "Department cannot be empty");

            //    user.Sex = Convert.ToChar( userDTO.Sex);
            //    if (ModelState.ErrorCount == 0)
            //    {
            //        IdentityResult result = await userManager.UpdateAsync(user);
            //        if (result.Succeeded)
            //            return NoContent();
            //        else
            //            return BadRequest(result.Errors);
            //    }
            //}
            return NotFound();
        }

        //Delete
        [HttpDelete("del/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            //ApplicationUser user = await userManager.FindByIdAsync(id);
            //if (user != null)
            //{
            //    await userManager.DeleteAsync(user);
            //    return NoContent();
            //}
            //else
            return NotFound("User Not Found");

        }
    }


}
