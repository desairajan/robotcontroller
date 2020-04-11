using RobotController.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.Models
{
    public class Location
    {
        public Location(Coordinate coordinate,Direction? direction)
        {
            Coordinate = coordinate;
            DirectionFace = direction;
        }
        public Coordinate Coordinate { get; set; }
        public Direction? DirectionFace { get; set; }

        public string Direction {
            get
            {
                if (DirectionFace != null)
                    return DirectionFace.Value.ToString();
                else return string.Empty;
            }
        }
    }
}