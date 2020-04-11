using RobotController.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.Models;
using RobotController.Enums;
using RobotController.UDFException;

namespace RobotController.BusinessImplementation.ObstacleBehaviours
{
    public class ClockWiseSpinNinetyDegreeObstacleBehaviour : IObstacleBehaviourProvider
    {
        public Location GetNewLocation(ObstacleBehaviourRequest request)
        {
            if(request.RobotCurrentLocation==null)
            {
                throw new ObstacleBehaviourException("Robot current location is not known");
            }
            if(request.RobotCurrentLocation.Coordinate==null)
            {
                throw new ObstacleBehaviourException("Robot current coordinates are not known");
            }
            if (request.RobotCurrentLocation.DirectionFace == null)
            {
                throw new ObstacleBehaviourException("Robot current direction is not known");
            }
            Direction newDirection;
            var currentdegree = (int)request.RobotCurrentLocation.DirectionFace.Value;
            currentdegree += 90;

            if (currentdegree == 360)
                newDirection = Direction.East;
            else
                newDirection = (Direction)currentdegree;

            return new Location(request.RobotCurrentLocation.Coordinate, newDirection);
        }
    }
}