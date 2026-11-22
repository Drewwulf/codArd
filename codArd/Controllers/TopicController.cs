using codArd.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace codArd.Controllers
{
    public class TopicController :Controller
    {
        private ApplicationDbContext _context;
        public TopicController(ApplicationDbContext contex)
        {
            _context = contex;
        }
        public IActionResult Index()
        {
            var Topics = _context.Topics.Where(OneTopic => OneTopic.IsDeleted == false).ToList();
              
            return View(Topics);
        }
        public IActionResult AddTopic(string TopicName, string TopicDescription)
        {
            var Topic = new Topic()
            {
                Name = TopicName,
                Description = TopicDescription
            }; 
            _context.Topics.Add(Topic);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ChangeTopic(string TopicName,  string TopicDescription, int Id)
        {

            var FindId = _context.Topics.Find(Id);
            FindId.Name = TopicName;
            FindId.Description = TopicDescription;
            _context.SaveChanges();
            return View("Change",FindId);
        }
        public IActionResult DeleteTopic(int id)
        {
            var FindId = _context.Topics.Find(id);
            FindId.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Change(int id) 
        {
            var FindId = _context.Topics.Find(id);
            return View(FindId);
        }
    }
}
