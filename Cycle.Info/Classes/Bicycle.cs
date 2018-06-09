using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info.Classes
{
   public  class Bicycle
    {
        public int Id { get; set; }
        [JsonIgnore]
        public Station Station { get; set; }
        public int StationId { get; set; }
      

    }
}
