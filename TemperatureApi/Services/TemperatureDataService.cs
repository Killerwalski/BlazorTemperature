using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemperatureApi.Models;

namespace TemperatureApi.Services
{
    public class TemperatureDataService
    {
        private readonly IMongoCollection<TemperatureEntry> _temperatures;

        public TemperatureDataService(ITemperatureDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _temperatures = database.GetCollection<TemperatureEntry>(settings.TemperatureCollectionName);
        }

        public List<TemperatureEntry> Get() =>
            _temperatures.Find(pass => true).ToList();


    }
}
