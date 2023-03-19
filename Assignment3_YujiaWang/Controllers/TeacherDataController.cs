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
    
    public class TeacherDataController : ApiController
    {
        //The database context class which allows us to access our MySQL Database

        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Return a list of Teacher in the database
        /// </summary>
        /// <example>
        /// GET: api/TeacherData/ListTeacher
        /// </example>
        /// <returns>A list of teachers(firstnames and lastnames)</returns>

        [HttpGet]
        public IEnumerable<Teacher> ListTeacher()
        {
            //create the instance connection to school database
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from teachers";

            //gather result set of query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //create an empty list of teachers
            List<Teacher> Teachers = new List<Teacher>{};

            //loop through each row in the result set
            while (ResultSet.Read())
            {
                //access column information by their database column name as an index and convert to int/string
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string) ResultSet["teacherfname"];
                string TeacherLname = (string) ResultSet["teacherlname"];

                //create a NewTeacher object which is the new instantiation of the Teacher class
                Teacher NewTeacher = new Teacher();
                
                //set the NewTeacher's property (as NewTeacher is an object)
                NewTeacher.TeacherId= TeacherId;
                NewTeacher.TeacherFname= TeacherFname;
                NewTeacher.TeacherLname= TeacherLname;

                //add the teacher name to the list
                Teachers.Add(NewTeacher);

            }

            //close the connection between webserver and database
            Conn.Close();

            //return the list of teachers' names
            return Teachers;

        }



        /// <summary>
        /// Finds a teacher in the system given an ID
        /// </summary>
        /// <param name="id">The teacher primary key</param>
        /// <example>
        /// GET: api/teacherdata/DetailTeacherInfo/{id}   -> A teacher object
        /// </example>
        /// <example>
        /// GET: api/teacherdata/DetailTeacherInfo/3     ->
        /// 
        ///<Teacher>
        ///<EmployeeNumber>T382</EmployeeNumber>
        ///<Salary>60.22</Salary>
        ///<TeacherFname>Linda</TeacherFname>
        ///<TeacherId>3</TeacherId>
        ///<TeacherLname>Chan</TeacherLname>
        ///</Teacher>
        ///
        /// </example>
        /// <returns>A teacher object</returns>
        [HttpGet]
        public Teacher DetailTeacherInfo(int id)
        {
            //create a NewTeacher object which is the new instantiation of the Teacher class
            Teacher NewTeacher = new Teacher();

            //create the instance connection to school database
            MySqlConnection Conn = School.AccessDatabase();

            //open the connection between webserver and database
            Conn.Open();

            //create a new command for database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from teachers where teacherid = " + id;

            //gather result set of query into a variable ResultSet
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //loop the results
            while (ResultSet.Read())
            {
                //access the column information by database column name as an index and convert them to int/string/decimal
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                decimal Salary = (decimal)ResultSet["salary"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];


                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.Salary = Salary;
                NewTeacher.EmployeeNumber= EmployeeNumber;
            }

            //close the connection
            Conn.Close();

            //return the object NewTeacher
            return NewTeacher;

        }

    }
}
