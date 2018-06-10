using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info.Classes
{
    public class Station
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public string NearestMetroStation { get; set; }
        public int NumberOfSlots { get; set; }
        public int NumberOfBikes { get; set; }
        [JsonIgnore]
        public List<Bicycle> BicyclesONStation { get; set; }
    }
}
