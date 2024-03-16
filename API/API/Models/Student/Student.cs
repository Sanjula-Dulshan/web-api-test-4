using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Models.Student
{
    public class Student
    {
        {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonElement("firstName")]
        public required string FirstName { get; set; }  

        [BsonElement("secondName")]
        public required string SecondName { get; set; }  

        [BsonElement("lastName")]
        public required string LastName { get; set; } 

        [BsonElement("dateOfBirth")]
        public required Date DateOfBirth { get; set; }

        [BsonElement("stream")]
        public required string Stream { get; set; }

        [BsonElement("gender")]
        public required string Gender { get; set; }

    }
}

