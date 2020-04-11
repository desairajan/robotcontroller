using RobotController.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.Models
{
    public class Grid
    {
        private int _length, _width;
        private List<GridObstacleUi> _obstacleList;
        private Location _initialLocation;
        private List<Coordinate> _coordinateLst;
        private Robot _robot;

        public Grid(int length, int width, List<GridObstacleUi> obstList, Location robotInitialLoc,Robot robot)
        {
            _length = length;
            _width = width;
            _obstacleList = obstList;
            _robot = robot;
            _initialLocation = robotInitialLoc;
            RobotCurrentLocation = robotInitialLoc;//when the grid is initialized current position is same as initial
            _coordinateLst = InitialiseCoordinates();
        }       

        public int Length { get { return _length; } }

        public int Width { get { return _width; } }

        public List<GridObstacleUi> ObstacleList { get { return _obstacleList; } }

        public Robot Robot { get { return _robot; } }

        public Location RobotInitialLocation { get { return _initialLocation; } }

        public Location RobotCurrentLocation { get; set; }

        public List<Coordinate> CoordinateList
        {
            get
            {
                return _coordinateLst;
            }
        }

        private List<Coordinate> InitialiseCoordinates()
        {
            var coordinateList = new List<Coordinate>();

            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; i < Width; j++)
                {
                    coordinateList.Add(new Coordinate(i, j));
                }
            }
            return coordinateList;
        }
    }
}