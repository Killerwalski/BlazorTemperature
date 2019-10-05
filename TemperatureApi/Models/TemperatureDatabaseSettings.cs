using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureApi.Models
{
    public class TemperatureDatabaseSettings : ITemperatureDatabaseSettings
    {
        public string TemperatureCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface ITemperatureDatabaseSettings
    {
        string TemperatureCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
