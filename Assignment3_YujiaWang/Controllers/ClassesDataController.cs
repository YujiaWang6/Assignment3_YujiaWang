using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment3_YujiaWang.Models;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;

namespace Assignment3_YujiaWang.Controllers
{
    public class ClassesDataController : ApiController
    {
        //The database context class which allows us to access our MySQL Database
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// returns a list of classes in database
        /// </summary>
        /// <example>
        /// GET: api/ClassesData/ListClass
        /// </example>
        /// <returns>A list of classes(calssCode, classId, className)</returns>
        
        [HttpGet]
        public IEnumerable<Classes> ListClass()
        {
            //create the instance connection to school database
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //create a new command
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from classes";

            //gather result set of query into a variable
            MySqlDataReader resultSet = cmd.ExecuteReader();

            //create an empty list of classes
            List<Classes> classes = new List<Classes> { };

            //loop through each row in the result set
            while(resultSet.Read())
            {
                //access column information by their database column name as an index and convert to int/string
                int ClassId = Convert.ToInt32(resultSet["classid"]);
                string ClassCode = resultSet["classcode"].ToString();
                string ClassName = resultSet["classname"].ToString();


                //create a NewClass object which is the new instantiation of the Classes class
                Classes newClass = new Classes();

                newClass.ClassCode = ClassCode;
                newClass.ClassId = ClassId;
                newClass.ClassName = ClassName;


                classes.Add(newClass);
            }

            //close connection between webserver and database
            Conn.Close();


            return classes;

        }


        /// <summary>
        /// Find the class in the database with an id
        /// </summary>
        /// <param name="id">the class primary key(classid)</param>
        /// <example>
        /// GET: api/ClassesData/ClassDetails/{id}     -> A Classes object
        /// </example>
        /// <example>
        /// GET: api/ClassesData/ClassDetails/2     ->
        /// 
        ///<Classes>
        ///<ClassCode>http5102</ClassCode>
        ///<ClassId>2</ClassId>
        ///<ClassName>Project Management</ClassName>
        ///<FinishDate>2018-12-14 12:00:00 AM</FinishDate>
        ///<StartDate>2018-09-04 12:00:00 AM</StartDate>
        ///<TeacherId>2</TeacherId>
        ///</Classes>
        /// 
        /// </example>
        /// <returns>A Classes object</returns>
        [HttpGet]
        public Classes ClassDetails(int id)
        {
            //create the instance connection to school database
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //create a new command
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query
            cmd.CommandText = "Select * from classes where classid = " + id;

            //gather result set of query into a variable
            MySqlDataReader resultSet = cmd.ExecuteReader();

            //create a NewClass object which is the new instantiation of the Classes class
            Classes newClass = new Classes();

            //loop through each row in the result set
            while (resultSet.Read())
            {
                //access column information by their database column name as an index and convert to int/string
                int ClassId = Convert.ToInt32(resultSet["classid"]);
                string ClassCode = resultSet["classcode"].ToString();
                int TeacherId = Convert.ToInt32(resultSet["teacherid"]);
                string StartDate = resultSet["startdate"].ToString();
                string FinishDate = resultSet["finishdate"].ToString();
                string ClassName = resultSet["classname"].ToString();

                newClass.ClassCode = ClassCode;
                newClass.ClassId = ClassId;
                newClass.TeacherId = TeacherId;
                newClass.ClassName = ClassName;
                newClass.StartDate= StartDate;
                newClass.FinishDate = FinishDate;

            }

            //close connection between webserver and database
            Conn.Close();


            return newClass;
        }

    }
}
