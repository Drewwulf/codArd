using codArd.Models;
using codArd.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace codArd.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext _context;
        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var tasks = _context.Tasks.Where(t => t.IsDeleted == false).ToList();
            var topics = _context.Topics.Where(t => t.IsDeleted == false).ToList();
            var model = new TaskViewModel()
            {
                tasksViewModel = tasks,
                topicViewModel = topics

            };
            
            return View(model);
        }
        public IActionResult AddTask(string TaskName, string TaskDescription, int TopicId)
        {
            var task1 = new codArd.Models.Task() { TaskName = TaskName, Description = TaskDescription,topicId = TopicId};
            _context.Tasks.Add(task1);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int Id)
        {
            var task = _context.Tasks.Find(Id);
            task.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int Id)
        {
            var topics = _context.Topics.Where(t => t.IsDeleted == false).ToList();
            var task = _context.Tasks.Find(Id);
            var model = new TaskViewModel()
            {
                
                topicViewModel = topics,
                TName= task.TaskName,
                TDescription = task.Description
               ,TId = task.Id,
                topicID = task.topicId

            };

            
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(TaskViewModel tasks)
        {
            var task = _context.Tasks.Find(tasks.TId);
            task.TaskName = tasks.TName;
            task.Description = tasks.TDescription;
            task.topicId = tasks.topicID;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    }
