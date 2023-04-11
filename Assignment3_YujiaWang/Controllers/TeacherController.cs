using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3_YujiaWang.Models;
using System.Diagnostics;

namespace Assignment3_YujiaWang.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Teacher/List
        public ActionResult List(string searchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeacher(searchKey);

            return View(Teachers);
        }

        // GET: /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.DetailTeacherInfo(id);

            return View(NewTeacher);
        }

        // GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.DetailTeacherInfo(id);
            return View(NewTeacher);
        }


        // POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST: /Teacher/Create
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname= TeacherLname;
            NewTeacher.Salary = Salary;
            NewTeacher.EmployeeNumber= EmployeeNumber;

            TeacherDataController controller = new TeacherDataController();
            controller.CreateTeacher(NewTeacher);

            return RedirectToAction("List");
        }



        /// <summary>
        /// Routes to a dynamically generated "Teacher Update" page. Gathers information from database
        /// </summary>
        /// <param name="id">ID of the Teacher</param>
        /// <returns>A dynamic "update teacher" webpage which provides the current information of the teacher and ask the user for information as part of a form.</returns>
        /// <example>GET: /Teacher/Update/{id}</example>
        //GET: /Teacher/Update/{id}
        [HttpGet]
        public ActionResult Update(int id)
        {
            //Debug.WriteLine("working123");
            TeacherDataController controller = new TeacherDataController(); ;
            Teacher selectedTeacher = controller.DetailTeacherInfo(id);
            return View(selectedTeacher);
        }



        /// <summary>
        ///  Receives a POST request containing information about an existing teacher in the system with new values.
        /// </summary>
        /// <param name="id">ID of the Teacher to update (primary key)</param>
        /// <param name="TeacherFname">The updated first name of the teacher</param>
        /// <param name="TeacherLname">The updated last name of the teacher</param>
        /// <param name="EmployeeNumber">The updated employeenumber of the teacher</param>
        /// <param name="Salary">The updated salary of the teacher</param>
        /// <returns>A dynamic webpage with provides the current information of the teacher</returns>
        /// <example>POST: /Teacher/Update/{id}</example>
        /// //POST: /Teacher/Update/{id}

        [HttpPost]
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, decimal Salary)
        {
            Debug.WriteLine("working");


            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.Salary = Salary;



            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }


    }
}