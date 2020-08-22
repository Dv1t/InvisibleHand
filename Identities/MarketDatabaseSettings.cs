using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvisibleHand.Identities
{
    public class MarketDatabaseSettings:IMarketDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string LotsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IMarketDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string LotsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
