using Microsoft.Identity.Client;

namespace codArd.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set;  }

        public bool IsDeleted { get; set; } = false;
    }
    
}
