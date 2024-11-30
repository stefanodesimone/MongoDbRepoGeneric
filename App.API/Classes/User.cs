using MongoDbRepoGeneric.Classes;

namespace App.API.Classes
{
    [BsonCollection("Users")]
    public class User : Document
    {

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;
    }
}
