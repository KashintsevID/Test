using Cycle.Info.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info
{
    public class DBRepository
    {
        private class DataSet
        {
            public List<Bicycle> Bicycles { get; set; }
            public List<Station> Stations { get; set; }
            public List<Administrator> Administrators { get; set; }
        }

        DataSet _dataset;

        public IEnumerable<Bicycle> Bicycles
        {
            get
            {
                return _dataset.Bicycles;
            }
        }

        public IEnumerable<Station> Stations
        {
            get
            {
                return _dataset.Stations;
            }
        }

        public IEnumerable<Administrator> Administrators
        {
            get
            {
                return _dataset.Administrators;
            }
        }

        public DBRepository()
        {
            _dataset = JsonConvert.DeserializeObject<DataSet>(File.ReadAllText("C:/Users/ПК/source/repos/Test3/Cycle.Info/Info/startingData.json"));  //написать сюда путь к исходному json файлу
        }
    }
}
