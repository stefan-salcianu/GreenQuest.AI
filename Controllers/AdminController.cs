using GreenQuest.AI.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenQuest.AI.Controllers
{
    // This controller is only for development - remove in production!
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // Only available in Development environment
        public async Task<IActionResult> ConfirmAllAccounts()
        {
            // Only allow in Development
            if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.Equals("Development", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                return NotFound();
            }

            var users = await _userManager.Users.ToListAsync();
            var confirmedCount = 0;

            foreach (var user in users)
            {
                if (!user.EmailConfirmed)
                {
                    user.EmailConfirmed = true;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        confirmedCount++;
                    }
                }
            }

            return Content($"Confirmed {confirmedCount} account(s). All existing accounts are now confirmed. You can now enable RequireConfirmedAccount = true.");
        }

        // Alternative: Confirm specific account by email
        public async Task<IActionResult> ConfirmAccount(string email)
        {
            // Only allow in Development
            if (!Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.Equals("Development", StringComparison.OrdinalIgnoreCase) ?? false)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(email))
            {
                return Content("Please provide an email parameter: /Admin/ConfirmAccount?email=your@email.com");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Content($"User with email {email} not found.");
            }

            if (user.EmailConfirmed)
            {
                return Content($"Account {email} is already confirmed.");
            }

            user.EmailConfirmed = true;
            var result = await _userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                return Content($"Account {email} has been confirmed successfully!");
            }
            else
            {
                return Content($"Error confirming account: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}


