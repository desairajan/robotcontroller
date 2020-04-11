using RobotController.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.Models;
using RobotController.UDFException;

namespace RobotController.BusinessImplementation.ObstacleBehaviours
{
    public class CannotMoveObstacleBehaviour : IObstacleBehaviourProvider
    {
        public Location GetNewLocation(ObstacleBehaviourRequest request)
        {
            throw new ObstacleBehaviourException("Cannot move to this location");
        }
    }
}