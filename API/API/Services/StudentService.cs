using API.Models.Student;
using System.Data.SqlClient;

namespace API.Services
{
    public class StudentService : IStudentService
    {
        public readonly IConfiguration _configuration;
        public SqlConnection conn;
        public string connectionString;
        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = "data source=Sanjula\\SQLEXPRESS02;initial catalog=StudentDb; integrated security=true";
            conn = new SqlConnection(connectionString);



        }

        public String Create(Student student)
        {
            // string connectionString = _configuration.GetConnectionString("StudentDb");

            if (string.IsNullOrEmpty(connectionString))
            {
                // Handle null or empty connection string
                return $"Error: Connection string is null or empty.";
            }

            student.RegistrationNumber = GenerateRegistrationNumber(student.Stream);

            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO students (registrationNumber, firstName, secondName, lastName,dateOfBirth, stream, gender) VALUES('" + student.RegistrationNumber + "','" + student.FirstName + "','" + student.SecondName + "','" + student.LastName + "','" + student.DateOfBirth + "','" + student.Stream + "','" + student.Gender + "')", conn);
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();

            if (rowsAffected > 0)
            {
                return student.RegistrationNumber;
            }
            else
            {
                return "Error: Failed to register student.";
            }


        }

        private string GenerateRegistrationNumber(string stream)
        {
            string streamAbbreviation = GetStreamAbbreviation(stream);
            int sequentialNumber = GetSequentialNumber(stream);

            int currentYear = DateTime.Now.Year;
            string sequentialNumberFormatted = sequentialNumber.ToString("D4");
            string registrationNumber = $"{streamAbbreviation}{currentYear}{sequentialNumberFormatted}";

            return registrationNumber;
        }


        private string GetStreamAbbreviation(string stream)
        {
            int startIndex = stream.IndexOf("(") + 1;
            int endIndex = stream.IndexOf(")");
            if (startIndex != -1 && endIndex != -1 && endIndex > startIndex)
            {
                return stream.Substring(startIndex, endIndex - startIndex);
            }
            else
            {
                return stream;
            }
        }

        private int GetSequentialNumber(string streamAbbreviation)
        {
            int count = 0;

            conn.Open();
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM students WHERE stream = '{streamAbbreviation}'", conn);
            count = (int)command.ExecuteScalar();
            conn.Close();

            count++;

            return count;
        }


    }
}
