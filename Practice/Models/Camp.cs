using LiteDB;

namespace Practice.Models
{
    public class Camp
    {
        // properties 
        public int ID { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ImageLink { get; set; }
        public int PricePerDay { get; set; }


        private readonly LiteDatabase _db;

        public Camp()
        {
            _db = new LiteDatabase(@"Filename=data.db; Connection=shared;");
        }


        // methods 

        public List<Camp> GetAllCamps()
        {
            var collection = _db.GetCollection<Camp>("camp");
            return collection.FindAll().ToList();
        }

        public Camp GetCampBYID(int id)
        {
            var collection = _db.GetCollection<Camp>("camp");
            return collection.FindById(id);
        }

        public Camp GetCampBYNAME(string name)
        {
            var collection = _db.GetCollection<Camp>("camp");
            return collection.FindOne(name);
        }

        public bool AddCamp(Camp camp)
        {
            var collection = _db.GetCollection<Camp>("camp");
            collection.Insert(camp);
            return true;
        }

        public bool UpdateCamp(Camp camp,int id)
        {
            var collection = _db.GetCollection<Camp>("camp");
            camp.ID = camp.ID;
            return collection.Update(camp);
        }


    }
}
