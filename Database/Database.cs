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
        
        public MongoDB()
        {
        }
  
    }

    public class UsersCol: MongoDB
    {
        protected static IMongoCollection<Model.Users> UserColl = db.GetCollection<Model.Users>("Users");


        public UsersCol()
        {

        }

        public List<Model.Users> GetAll()
        {
            var filter = Builders<Model.Users>.Filter.Empty;
            var users = UserColl.Find(filter).ToList();

            return users;
        }

        public List<Model.Users> GetOneByID(string userID)
        {
            var filter = Builders<Model.Users>.Filter.Eq("userID", userID);
            var users = UserColl.Find(filter).ToList();

            return users;
        }

        public bool InsertOne(Model.Users newuser)
        {
            var filter = Builders<Model.Users>.Filter.Eq("userID", newuser.userID);
            var user = UserColl.Find(filter).ToList();

            if (user != null)
                return false;
            else
                UserColl.InsertOne(newuser);

            return true;
        }

        public Task<ReplaceOneResult> UpdateOne(Model.Users user)
        {
            var filter = Builders<Model.Users>.Filter.Eq("userID", user.userID);
                
            return UserColl.ReplaceOneAsync(filter, user);

        }

        public Task<DeleteResult> DeleteOne(string userID)
        {
            var filter = Builders<Model.Users>.Filter.Eq("userID", userID);

            return UserColl.DeleteOneAsync(filter);
        }
    }

    public class ProblemCol : MongoDB
    {
        protected static IMongoCollection<Model.Problems> ProblemColl = db.GetCollection<Model.Problems>("Problems");

        public ProblemCol()
        {

        }

        public List<Model.Problems> GetAll()
        {
            var filter = Builders<Model.Problems>.Filter.Empty;
            var problmes = ProblemColl.Find(filter).ToList();

            return problmes;
        }

        public List<Model.Problems> GetOneByID(string ID)
        {
            var filter = Builders<Model.Problems>.Filter.Eq("ID", ID);
            var problems = ProblemColl.Find(filter).ToList();

            return problems;
        }

        public bool InsertOne(Model.Problems newproblem)
        {
            var filter = Builders<Model.Problems>.Filter.Eq("ID", newproblem.ID);
            var problem = ProblemColl.Find(filter).ToList();

            if (problem != null)
                return false;
            else
                ProblemColl.InsertOne(newproblem);

            return true;
        }

        public Task<ReplaceOneResult> UpdateOne(Model.Problems problem)
        {
            var filter = Builders<Model.Problems>.Filter.Eq("ID", problem.ID);

            return ProblemColl.ReplaceOneAsync(filter, problem);

        }

        public Task<DeleteResult> DeleteOne(string ID)
        {
            var filter = Builders<Model.Problems>.Filter.Eq("ID", ID);

            return ProblemColl.DeleteOneAsync(filter);
        }
    }

    public class SubmissionCol : MongoDB
    {
        protected static IMongoCollection<Model.Submissions> SubmissionColl = db.GetCollection<Model.Submissions>("Submission");

        public SubmissionCol()
        {

        }

        public List<Model.Submissions> GetAll()
        {
            var filter = Builders<Model.Submissions>.Filter.Empty;
            var submissions = SubmissionColl.Find(filter).ToList();

            return submissions;
        }

        public List<Model.Submissions> GetOneByID(string ID)
        {
            var filter = Builders<Model.Submissions>.Filter.Eq("ID", ID);
            var submissions = SubmissionColl.Find(filter).ToList();

            return submissions;
        }

        public bool InsertOne(Model.Submissions newsubmission)
        {
            var filter = Builders<Model.Submissions>.Filter.Eq("submissionID", newsubmission.submissionID);
            var submission = SubmissionColl.Find(filter).ToList();

            if (submission != null)
                return false;
            else
                SubmissionColl.InsertOne(newsubmission);

            return true;
        }

        public Task<ReplaceOneResult> UpdateOne(Model.Submissions submission)
        {
            var filter = Builders<Model.Submissions>.Filter.Eq("submissionID", submission.submissionID);

            return SubmissionColl.ReplaceOneAsync(filter, submission);

        }

        public Task<DeleteResult> DeleteOne(string submissionID)
        {
            var filter = Builders<Model.Submissions>.Filter.Eq("submissionID", submissionID);

            return SubmissionColl.DeleteOneAsync(filter);
        }
    }
}
