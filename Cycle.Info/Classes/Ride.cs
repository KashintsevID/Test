using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle.Info.Classes
{
    public class Ride
    {
        public int Id { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public Bicycle Bicycle { get; set; }
        public int BicycleId { get; set; }
        public DateTime BeginingOfRide { get; set; }
        public string TotalRideTime { get; set; }
        public decimal MoneyPaid { get; set; }
        public bool IsRideFinished { get; set; }
    }
}
