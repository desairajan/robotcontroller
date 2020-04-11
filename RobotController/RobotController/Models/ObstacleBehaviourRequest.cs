using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.Models
{
    public class ObstacleBehaviourRequest
    {
        public Location RobotCurrentLocation { get; set; }
        public Location RobotInitialLocation { get; set; }
    }
}