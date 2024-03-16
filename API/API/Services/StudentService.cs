using System.Data.SqlClient;

namespace API.Services
{
    public class StudentService
    {
        public readonly IConfiguration _configuration;
        public SqlConnection con;
        public StudentService(IConfiguration configuration)
        {
            _configuration = configuration;
            con = new SqlConnection(_configuration.GetConnectionString("StudentDb").ToString());

        }
    }
}
