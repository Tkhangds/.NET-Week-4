using BaiTapThucHanhWeek4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucHanhWeek4.Controllers
{
    public class AccessController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        //private readonly SignInManager<TUser> _signInManager;
        //private readonly UserManager<TUser> _userManager;

        //public AccessController(SignInManager<TUser> signInManager, UserManager<TUser> userManager) {
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}

        //[HttpGet]
        //[Authorize]
        //public IActionResult Login()
        //{
        //    return RedirectToAction("Index", "Home");

        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(string username, string password)
        //{
        //    var user = await _userManager.FindByNameAsync(username);
        //    if (user == null) return View();

        //    var passwordCorrect = await _userManager.CheckPasswordAsync(user, password);
        //    if (!passwordCorrect) return View();

        //    await _signInManager.SignInAsync(user, isPersistent: true);
        //    return RedirectToAction("Index", "Home");
        //}

        [HttpGet]
        public IActionResult Login()
        {
            if(HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            } 
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Login(TUser user)
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                var u = db.TUsers.Where(x => x.Username.Equals(user.Username) && x.Password.Equals(user.Password)).FirstOrDefault();

                if (u != null)
                {
                    HttpContext.Session.SetString("UserName", u.Username.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public IActionResult Logout() 
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Access");
        }

    }
}
