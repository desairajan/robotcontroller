using RobotController.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.Models;
using System.Data.SqlClient;
using System.Data;
using RobotController.Utils;

namespace RobotController.DAL.Implementation
{
    public class GridObstacleBehaviourLinkDao : IGridObstacleBehaviourLinkDao
    {
        private ISqlDatabase _sqlDb;
        public GridObstacleBehaviourLinkDao()
        {
            _sqlDb = IoC.Resolve<ISqlDatabase>();
        }
        public RobotGridObstacleBehaviourLinkViewModel GetObstacleBehaviourList(string robotCode, string obstacleCode)
        {
            SqlCommand cmd = new SqlCommand("dbo.LinkRobotGridObstacleBehaviour_Get");
            cmd.Parameters.AddWithValue("@RobotCode", robotCode);
            cmd.Parameters.AddWithValue("@GridObstacleCode", obstacleCode);
            var dt = _sqlDb.ExecuteSelect(cmd);

            
            DataRow row = dt.Rows[0];

            RobotGridObstacleBehaviourLinkViewModel obj = new RobotGridObstacleBehaviourLinkViewModel();
            obj.RobotCode = DataTableUtils.GetValue<string>(row, "RobotCode");
            obj.ObstacleCode = DataTableUtils.GetValue<string>(row, "ObstacleCode");
            obj.ObstacleName = DataTableUtils.GetValue<string>(row, "ObstacleName");
            obj.ObstacleBehaviourDescription = DataTableUtils.GetValue<string>(row, "ObstacleBehaviourDescription");
            obj.ObstacleBehaviourCode = DataTableUtils.GetValue<string>(row, "ObstacleBehaviourCode");
            

            return obj;

        }
    }
}