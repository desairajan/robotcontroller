using RobotController.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.Models;
using RobotController.DAL.Interfaces;

namespace RobotController.BusinessImplementation
{
    public class GridObstacleBehaviourLinkManager : IGridObstacleBehaviourLinkManager
    {
        private IGridObstacleBehaviourLinkDao _behaviourLinkDao;
        public GridObstacleBehaviourLinkManager(IGridObstacleBehaviourLinkDao behaviourLinkDao)
        {
            _behaviourLinkDao = behaviourLinkDao;
        }

        public RobotGridObstacleBehaviourLinkViewModel GetObstacleBehaviourList(string robotCode, string obstacleCode)
        {
            return _behaviourLinkDao.GetObstacleBehaviourList(robotCode, obstacleCode);
        }
    }
}