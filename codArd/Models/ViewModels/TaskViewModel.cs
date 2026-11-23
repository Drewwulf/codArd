namespace codArd.Models.ViewModels
{
    public class TaskViewModel
    {
        public List<codArd.Models.Task> tasksViewModel { get; set; }
        public List<Topic> topicViewModel { get; set; }

        public string TName { get; set; }
        public string TDescription { get; set; }
        public int TId { get; set; }
        public int topicID { get; set; }
    }
}
