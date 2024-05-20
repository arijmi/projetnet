using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_Foyer.Models;
using System.Security.Cryptography;
using System.Text;

namespace Reservation_Foyer.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // GET: Login
        public IActionResult Login()
        {
            return View();
        }
        // POST: Login
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Email, string Password)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                // Find the user by email
                var user = _context.Users.FirstOrDefault(u => u.Email == Email);


                // If user is found
                if (user != null)
                {
                    // Hash the provided password using the same algorithm used for storing passwords
                    string hashedPassword = GetMd5Hash(Password);

                    // Compare the hashed passwords
                    if (user.Password == hashedPassword)
                    {
                        // Check if the user's role is equal to 1
                        if (user.Role == 1)
                        {
                            // Redirect to home page or any desired page for role 1
                            return RedirectToAction("Index", "Chambres");
                        }
                        else
                        {
                            

                            // Pass the user's Id to the data action method
                            return RedirectToAction("data", "Users", new { id = user.Id });
                        }
                    }
                    else
                    {
                        // Passwords do not match
                        ModelState.AddModelError(string.Empty, "Invalid email or password");
                    }
                }
                else
                {
                    // User not found
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                }
            }

            // If user is not found or password does not match, return to login page with error
            return View();
        }

        // Method to hash the password using MD5 (same as before)
        private string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

    }
}
