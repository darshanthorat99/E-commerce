using E_commerce.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace E_commerce.Controllers
{
    public class UserController : Controller
    {

        private readonly IConfiguration configuration;
        UserDAL userdal;
        public UserController(IConfiguration configuration)
        {
            this.configuration = configuration;
            userdal = new UserDAL(configuration);
        }
        // GET: UsersController
        public IActionResult Register()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        public IActionResult Register(Users users)
        {
            try
            {
                int res = userdal.UsersRegister(users);
                if (res == 1)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(Users users)
        {
            Users user = userdal.UsersLogin(users);
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, users.Emailid) },
                CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            HttpContext.Session.SetInt32("user_id", users.Userid);
            HttpContext.Session.SetString("email", users.Emailid);
            HttpContext.Session.SetInt32("role_id", users.Roleid);

            if (user != null)
            {
                if (user.Roleid == 1)
                {
                    return RedirectToAction("Create", "Product");
                }
                else if (user.Roleid == 2)
                {
                    return RedirectToAction("List", "Product");
                }
                return View();
            }
            return View();
        }
        // POST: UsersController/Delete/5
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            var StoredCookies = Request.Cookies.Keys;
            foreach (var Cookie in StoredCookies)
            {
                Response.Cookies.Delete(Cookie);
            }
            return RedirectToAction("Login");
        }
    }
}
