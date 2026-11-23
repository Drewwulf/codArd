namespace codArd.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }
        
        public bool IsDeleted { get; set; } = false;
        public List<codArd.Models.Task> Tasks { get; set; }
    }
}
