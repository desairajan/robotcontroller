using RobotController.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.Models;
using RobotController.UDFException;

namespace RobotController.BusinessImplementation.ObstacleBehaviours
{
    public class GoBackToInitialLocationObstacleBehaviour : IObstacleBehaviourProvider
    {
        public Location GetNewLocation(ObstacleBehaviourRequest request)
        {
            if (request.RobotInitialLocation == null)
            {
                throw new ObstacleBehaviourException("Robot Initial Location is not found");
            }
            return request.RobotInitialLocation;
        }
    }
}