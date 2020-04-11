using RobotController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.BusinessInterfaces
{
    public interface IGridObstacleBehaviourLinkManager
    {
        RobotGridObstacleBehaviourLinkViewModel GetObstacleBehaviourList(string robotCode,string obstacleCode);
    }
}
