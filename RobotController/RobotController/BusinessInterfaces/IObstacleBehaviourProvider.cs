using RobotController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.BusinessInterfaces
{
    interface IObstacleBehaviourProvider
    {
        Location GetNewLocation(ObstacleBehaviourRequest request);
    }
}
