using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reservation_Foyer.Models;
namespace Reservation_Foyer.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        // GET: Users
        public IActionResult Index()
        {
            var users = _context.Users.Include(u => u.Universite).ToList();
            return View(users);
        }

     

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.Universites = new SelectList(_context.Universites, "Id", "Name");
            ViewBag.Chambres = new SelectList(_context.Chambres, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        private string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new StringBuilder to collect the bytes and create a string
                StringBuilder stringBuilder = new StringBuilder();

                // Loop through each byte of the hashed data and format it as a hexadecimal string
                for (int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string
                return stringBuilder.ToString();
            }
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {

            // Hash the password before saving it to the database
            string originalPassword = user.Password;
             user.Password = GetMd5Hash(user.Password);

                _context.Add(user);
                _context.SaveChanges();
            SendEmail(user.Email,user.Name, originalPassword);
            return RedirectToAction("Index");
            
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
           
                // Hash the password before saving it to the database
                user.Password = GetMd5Hash(user.Password);

                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
           
        }
        // Method to send an email
        private void SendEmail(string toEmail, string name, string password)
        {
            try
            {
                var fromAddress = new MailAddress("mohamedhlel321@gmail.com", "Gestion des Foyer");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "twuj orqz ufoa ynsd";
                const string subject = "Welcome to Our Application University Hostel Management";
                string body = $"Dear {name},\n\nYour account has been created successfully \n\n  The login : {toEmail} \n\n the password: {password}.\n\nBest regards,\n";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log the error)
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Universites = new SelectList(_context.Universites, "Id", "Name", user.UniversiteId);
            ViewBag.Chambres = new SelectList(_context.Chambres, "Id", "Name", user.ChambreId);
            return View(user);
        }

        // GET: Users/data/5
        public IActionResult data(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewBag.Universites = new SelectList(_context.Universites, "Id", "Name", user.UniversiteId);
            ViewBag.Chambres = new SelectList(_context.Chambres, "Id", "Name", user.ChambreId);
            return View(user);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

      
    }
}
