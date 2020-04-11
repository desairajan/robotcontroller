using RobotController.Models;
using RobotController.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotController.BusinessInterfaces
{
    public interface IRobotMovementProvider
    {
        Location MoveRecord(RobotMovementUi req);
    }
}
