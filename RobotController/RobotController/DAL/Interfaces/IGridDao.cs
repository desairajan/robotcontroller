using RobotController.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.DAL.Interfaces
{
    public interface IGridDao
    {
        List<Robot> GetAllRobot();
        List<GridObstacle> GetAllGridObstacle();
    }
}
