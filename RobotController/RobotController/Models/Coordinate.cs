using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.Models
{
    public class Coordinate
    {
        public Coordinate(int x,int y)
        {
            XCoordinate = x;
            YCoordinate = y;
        }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
    }
}