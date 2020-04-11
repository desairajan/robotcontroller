using RobotController.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.Models;
using RobotController.Models.UI;

namespace RobotController.BusinessImplementation.RobotMovementProvider
{
    public class ForwardMovementProvider : BaseRobotMovementProvider, IRobotMovementProvider
    {
        public Location MoveRecord(RobotMovementUi req)
        {
            Location newLocation = new Location(new Coordinate(req.CurrentLocation.Coordinate.XCoordinate, req.CurrentLocation.Coordinate.YCoordinate + 1), !req.CurrentLocation.DirectionFace.HasValue ? Enums.Direction.East : req.CurrentLocation.DirectionFace.Value);

            base.ValidateNewLocationForBoundariesThrowIfExceeded(newLocation, req.GridLength, req.GridWidth);

            newLocation = GetNewLocationIfObstacleFound(req, newLocation);

            return newLocation;
        }
    }
}