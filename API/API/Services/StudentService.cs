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
            // string connectionString = _configuration.GetConnectionString("StudentDb");
            string connectionString = "data source=Sanjula\\SQLEXPRESS02;initial catalog=StudentDb; integrated security=true";

            if (string.IsNullOrEmpty(connectionString))
            {
                // Handle null or empty connection string
                return $"Error: Connection string is null or empty.connectionString: {connectionString}";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();



                SqlCommand cmd = new SqlCommand("INSERT INTO students (registrationNumber, firstName, secondName, lastName,dateOfBirth, stream, gender) VALUES('" + student.RegistrationNumber + "','" + student.FirstName + "','" + student.SecondName + "','" + student.LastName + "','" +student.DateOfBirth + "','" +student.Stream + "','" + student.Gender + "')", conn);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return $"Student registered with Registration No: {student.RegistrationNumber}";
                }
                else
                {
                    return "Error: Failed to register student.";
                }
            }


        }

    }
}
