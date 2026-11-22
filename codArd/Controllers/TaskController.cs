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
            return View(tasks);
        }
        public IActionResult AddTask(string TaskName, string TaskDescription)
        {
            var task1 = new codArd.Models.Task() { TaskName = TaskName, Description = TaskDescription };
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
            var task = _context.Tasks.Find(Id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(string TaskName, string TaskDescription,int Id)
        {
            var task = _context.Tasks.Find(Id);
            task.TaskName = TaskName;
            task.Description = TaskDescription;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    }
