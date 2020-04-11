using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.Models.UI
{
    public class RobotMovementUi
    {
        public Location CurrentLocation { get; set; }
        public Location InitialLocation { get; set; }
        public string MoveDirection { get; set; }
        public List<GridObstacleUi> ObstacleList { get; set; }
        public int GridLength { get; set; }
        public int GridWidth { get; set; }
        public string RobotCode { get; set; }
        public Dictionary<Tuple<int,int>,GridObstacleUi> Obstacledic
        {
            get
            {
                if (ObstacleList != null)
                {
                    return ObstacleList.ToDictionary(i => new Tuple<int,int>(i.Coordinate.XCoordinate,i.Coordinate.YCoordinate));
                }
                return null;
            }
        } 
    }
}