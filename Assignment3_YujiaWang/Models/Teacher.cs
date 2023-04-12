using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3_YujiaWang.Models
{
    public class Teacher
    {
        //the following fileds define a teacher
        public string TeacherFname;
        public string TeacherLname;
        public int TeacherId;
        public decimal Salary;
        public string EmployeeNumber;
        public DateTime HireDate;


        //add more details of class to link class with teacher
        public string ClassCode;
        public string ClassName;
        public int ClassId;


        //parameter-less constructor function
        public Teacher()
        {

        }


    }
}