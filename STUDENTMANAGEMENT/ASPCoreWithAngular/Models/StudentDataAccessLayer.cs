using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=myTestDB;Data Source=DESKTOP-SDQAJLR";

        //To View all Students details
        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                List<Student> lstStudent = new List<Student>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Student Student = new Student();

                        Student.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        Student.Name = rdr["Name"].ToString();
                        Student.Gender = rdr["Gender"].ToString();
                        Student.Department = rdr["Department"].ToString();
                        Student.City = rdr["City"].ToString();

                        lstStudent.Add(Student);
                    }
                    con.Close();
                }
                return lstStudent;
            }
            catch
            {
                throw;
            }
        }

        //To Add new Student record 
        public int AddStudent(Student Student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", Student.Name);
                    cmd.Parameters.AddWithValue("@Gender", Student.Gender);
                    cmd.Parameters.AddWithValue("@Department", Student.Department);
                    cmd.Parameters.AddWithValue("@City", Student.City);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar Student
        public int UpdateStudent(Student Student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", Student.ID);
                    cmd.Parameters.AddWithValue("@Name", Student.Name);
                    cmd.Parameters.AddWithValue("@Gender", Student.Gender);
                    cmd.Parameters.AddWithValue("@Department", Student.Department);
                    cmd.Parameters.AddWithValue("@City", Student.City);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Student
        public Student GetStudentData(int id)
        {
            try
            {
                Student Student = new Student();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sqlQuery = "SELECT * FROM tblEmployee WHERE EmployeeID= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Student.ID = Convert.ToInt32(rdr["EmployeeID"]);
                        Student.Name = rdr["Name"].ToString();
                        Student.Gender = rdr["Gender"].ToString();
                        Student.Department = rdr["Department"].ToString();
                        Student.City = rdr["City"].ToString();
                    }
                }
                return Student;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record on a particular Student
        public int DeleteStudent(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
