using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_YujiaWang.Models;
using MySql.Data.MySqlClient;

namespace Assignment3_YujiaWang.Controllers
{
    //GET api/TeacherData/ListTeacher
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        public IEnumerable<Teacher> ListTeacher()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from teachers";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> Teachers = new List<Teacher>{};

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string) ResultSet["teacherfname"];
                string TeacherLname = (string) ResultSet["teacherlname"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId= TeacherId;
                NewTeacher.TeacherFname= TeacherFname;
                NewTeacher.TeacherLname= TeacherLname;


                Teachers.Add(NewTeacher);

            }

            Conn.Close();

            return Teachers;

        }


        [HttpGet]
        public Teacher DetailTeacherInfo(int id)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from teachers where teacherid = " + id;

            MySqlDataReader ResultSet = cmd.ExecuteReader();


            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];


                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
            }

            return NewTeacher;

        }

    }
}
