using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.Models
{
    public class RobotGridObstacleBehaviourLinkViewModel
    {
        public string RobotCode { get; set; }
        public string ObstacleName { get; set; }
        public string ObstacleCode { get; set; }
        public string ObstacleBehaviourCode { get; set; }
        public string ObstacleBehaviourDescription { get; set; }
    }
}