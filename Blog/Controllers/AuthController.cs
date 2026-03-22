using Blog.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        // Register
        // Login
        // Logout

        public AuthController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                /*
                 ❌ Sync (Blocking)You stand at the door doing nothing until pizza arrives
                 ✅ Async (await)You go watch TV, your phone notifies you when pizza arrives
                 */

                // await = "notify me when it's done, I'll do other things meanwhile"

                var user =await _userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Email or Password is Incorrect");
                    return View(model);
                }

                var signInresult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (!signInresult.Succeeded)
                {
                    ModelState.AddModelError("", "Email or Password is Incorrect");
                    return View(model);
                }
                return RedirectToAction("Index", "Post");
            }
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            // Check for validation 
            if(ModelState.IsValid)
            {
                // Create Identity User object
                var user = new IdentityUser
                {
                    //Username is mandatory
                    UserName = model.Email,
                    Email = model.Email

                };
                // User Create
             var result= await _userManager.CreateAsync(user, model.Password);

            // if user create successfully
            if (result.Succeeded)
                {
                    // If the User Role exist in database
                   if(!await _roleManager.RoleExistsAsync("User"))
                    {
                      await _roleManager.CreateAsync(new IdentityRole("User"));
                    }

                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.SignInAsync(user, true);

                    return RedirectToAction("Index", "Post");
                }

            }
            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Post");
        }
    }
}
