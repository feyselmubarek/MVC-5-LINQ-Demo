using MVC_5_LINQ_Demo.Data;
using MVC_5_LINQ_Demo.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC_5_LINQ_Demo.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserDbContext DbContext = new UserDbContext();
        
        // GET: Users
        public ActionResult Index()
        {
            var users = from AllUsers in DbContext.Users select AllUsers;
            return View(users);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View(DbContext.Users.Where(u => u.Id == id).Single());
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(Users users)
        {
            try
            {
                DbContext.Users.Add(users);
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
             return View(DbContext.Users.Where(u => u.Id == id).Single());
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Users editedUser)
        {
            try
            {                
                Users user = DbContext.Users.Single(u => u.Id == id);
                user.FirstName = editedUser.FirstName;
                user.LastName = editedUser.LastName;
                user.Age = editedUser.Age;
                user.UserName = editedUser.UserName;
                user.RegisteredDate = editedUser.RegisteredDate;

                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View(DbContext.Users.Where(u => u.Id == id).Single());
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Users users)
        {
            try
            {
                DbContext.Users.Remove(DbContext.Users.Where(u => u.Id == id).Single());
                DbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
