using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3_YujiaWang.Models
{
    public class Classes
    {
        //the following fileds define a class
        public string ClassCode;
        public int TeacherId;
        public string ClassName;
        public string StartDate;
        public string FinishDate;
        public int ClassId;


        //add more details of teacher to link class with teacher
        public string TeacherFname;
        public string TeacherLname;
    }
}