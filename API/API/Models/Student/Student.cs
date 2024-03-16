using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Models.Student
{
    public class Student
    {
 
        public required string RegistratioNumber { get; set; }

   
        public required string FirstName { get; set; }  


        public required string SecondName { get; set; }  

        public required string LastName { get; set; }

        public Date? DateOfBirth { get; set; } = default;

        public required string Stream { get; set; }

        public required string Gender { get; set; }

    }
}

