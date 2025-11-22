namespace GreenQuest.AI.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Event_Date { get; set; }
    
        public string Description { get; set; } = string.Empty;
        // În Event.cs - adaugi o proprietate nouă
        public string Creator_id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdatedAt { get; set; } = DateTime.UtcNow;

        public int Bonus { get; set; }

    }
}
