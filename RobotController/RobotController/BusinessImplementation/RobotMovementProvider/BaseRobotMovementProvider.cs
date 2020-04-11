using RobotController.BusinessInterfaces;
using RobotController.Models;
using RobotController.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.BusinessImplementation.RobotMovementProvider
{
    public class BaseRobotMovementProvider
    {
        public void ValidateNewLocationForBoundariesThrowIfExceeded(Location newLocation,int gridLength,int gridWidth)
        {
            int xCoordinate = newLocation.Coordinate.XCoordinate;
            int yCoordinate = newLocation.Coordinate.YCoordinate;

            if (xCoordinate < 0 || xCoordinate >= gridWidth || yCoordinate < 0 || yCoordinate >= gridLength)
                throw new ApplicationException("Cannot move to the location since it is outside of grid");
        }
        public RobotGridObstacleBehaviourLinkViewModel GetObstacleBehaviourForRobot(string robotCode,string obstacleCode)
        {
            return IoC.Resolve<IGridObstacleBehaviourLinkManager>().GetObstacleBehaviourList(robotCode, obstacleCode);
        }
        public Location GetNewLocationIfObstacleFound(RobotMovementUi req, Location newLocation)
        {
            var key = new Tuple<int, int>(newLocation.Coordinate.XCoordinate, newLocation.Coordinate.YCoordinate);
            if (req.Obstacledic!=null && req.Obstacledic.ContainsKey(key))
            {
                var behaviourLink = GetObstacleBehaviourForRobot(req.RobotCode, req.Obstacledic[key].Obstacle.Code);

                if (!IoC.IsRegistered<IObstacleBehaviourProvider>(behaviourLink.ObstacleBehaviourCode))
                    throw new ApplicationException("Obstacle Bheaviour "+ behaviourLink.ObstacleBehaviourDescription+ " not implemented for obstacle "+ behaviourLink.ObstacleName);

                newLocation = IoC.Resolve<IObstacleBehaviourProvider>(behaviourLink.ObstacleBehaviourCode).GetNewLocation(new ObstacleBehaviourRequest() { RobotCurrentLocation = newLocation, RobotInitialLocation = req.InitialLocation });

            }

            return newLocation;
        }
    }
}