using API.Models.Student;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace API.Services
{
    public class StudentService: IStudentService
    {
        public readonly IConfiguration _configuration;
        public SqlConnection conn;
        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
        

        }

        public String Create(Student student)
        {
            conn = new SqlConnection(_configuration.GetConnectionString("ConnectionString:StudentDb"));
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO students (registratioNumber, firstName, secondName, lastName, dateOfBirth, stream, gender) VALUES('"+student.RegistratioNumber+ "','" +student.FirstName+ "','" +student.SecondName +"','" + student.LastName + "','" + student.DateOfBirth + "','" + student.Stream + "','" + student.Gender + "')",conn);
            int i = cmd.ExecuteNonQuery();

            if(i > 0)
            {
                return $"Student Registered with Register No: {student.RegistratioNumber}";
            }
            else
            {
                return "Error";
            }


        }

    }
}
