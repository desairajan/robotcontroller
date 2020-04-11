using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.BusinessInterfaces;
using RobotController.DAL.Interfaces;
using RobotController.Models;

namespace RobotController.BusinessImplementation
{
    public class GridManager : IGridManager
    {
        private IGridDao _gridDao;
        public GridManager(IGridDao gridDao)
        {
            _gridDao = gridDao;
        }

        public List<GridObstacle> GetAllGridObstacle()
        {
            return _gridDao.GetAllGridObstacle();
        }

        public List<Robot> GetAllRobot()
        {
            return _gridDao.GetAllRobot();
        }
    }
}