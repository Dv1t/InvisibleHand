using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvisibleHand.Identities;
using Microsoft.VisualBasic.CompilerServices;
using MongoDB.Driver;

namespace InvisibleHand.Services
{
    public class LotService
    {
        private readonly IMongoCollection<Lot> _lots;

        public LotService(IMarketDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _lots = database.GetCollection<Lot>(settings.LotsCollectionName);
        }

        public List<Lot> Get() =>
            _lots.Find(lot => true).ToList();

        public Lot Get(string id) =>
            _lots.Find<Lot>(lot => lot.Id == id).FirstOrDefault();
        public List<Lot> FindByOwner(string owner)
        {
            return _lots.Find<Lot>(lot => lot.Owner == owner).ToList();
        }
        public Lot FindToBuy(double price,string type)
        {
            return _lots.Find<Lot>(lot => (Math.Abs(price-lot.Price) <= 1.0)&&(lot.Product==type)&&(lot.Sell)).FirstOrDefault();
        }


        public Lot Create(Lot lot)
        {
            _lots.InsertOne(lot);
            return lot;
        }

        public void Update(string id, Lot lotIn) =>
            _lots.ReplaceOne(lot => lot.Id == id, lotIn);

        public void Remove(Lot lotIn) =>
            _lots.DeleteOne(lot => lot.Id == lotIn.Id);

        public void Remove(string id) =>
            _lots.DeleteOne(lot => lot.Id == id);
    }
}

