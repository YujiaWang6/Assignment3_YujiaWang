using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_YujiaWang.Models;

namespace Assignment3_YujiaWang.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        //Get: Classes/List
        public ActionResult List(string searchKey = null)
        {

            ClassesDataController controller = new ClassesDataController();
            IEnumerable<Classes> Classes = controller.ListClasses(searchKey);

            return View(Classes);
        }

        //Get: Classes/Show/{id}
        public ActionResult Show(int id) 
        {
            ClassesDataController controller = new ClassesDataController();
            Classes classes = controller.ClassDetails(id);

            return View(classes);
        }
    }
}