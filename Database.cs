using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Database
{

    public class MongoDB
    {
        private static string connection = "mongodb+srv://admin:<admin>@cluster0.ag5gb.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";

        protected static MongoClient client = new MongoClient(connection);
        protected static IMongoDatabase db = client.GetDatabase("3080Proj");

        protected static IMongoCollection<BsonDocument> UserColl = db.GetCollection<BsonDocument>("Users");
        protected static IMongoCollection<BsonDocument> ProblemColl = db.GetCollection<BsonDocument>("Problems");
        protected static IMongoCollection<BsonDocument> SubmissionColl = db.GetCollection<BsonDocument>("Submission");
        public MongoDB()
        {
        }

        public virtual void getAll() { }
  
    }

    public class UsersCol: MongoDB
    {
        public UsersCol()
        {
        }

        public override List<Model.Users> getAll() { return}
    }

}
