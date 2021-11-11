using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IERG3080_PRO3
{
  
  public class MongoDB
  {
        protected MongoClient client = new MongoClient("localhost:27017");
        protected MongoClient.GetDatabase db = client.GetDatabase("IERG3080_DB");

  }

}
