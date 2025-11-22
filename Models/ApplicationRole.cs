using Microsoft.AspNetCore.Identity;

namespace GreenQuest.AI.Models
{
    public class ApplicationRole : IdentityRole
    {
        // Adaugă aici proprietățile suplimentare pe care vrei să le ai
        // De exemplu:
        public string? Description { get; set; }
        public int Points { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        // sau orice altă proprietate de care ai nevoie
    }
}