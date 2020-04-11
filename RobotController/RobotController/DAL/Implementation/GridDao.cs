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
    public class GridDao : IGridDao
    {
        private ISqlDatabase _sqlDb;
        public GridDao()
        {
            _sqlDb = IoC.Resolve<ISqlDatabase>();
        }
        public List<Robot> GetAllRobot()
        {
            SqlCommand cmd = new SqlCommand("dbo.Robot_GetAll");

            var dt = _sqlDb.ExecuteSelect(cmd);

            List<Robot> res = new List<Robot>();

            foreach (DataRow row in dt.Rows)
            {
                Robot r = new Robot()
                {
                    Id = DataTableUtils.GetValue<int>(row, "RobotId"),
                    Code = DataTableUtils.GetValue<string>(row, "Code"),
                    Name = DataTableUtils.GetValue<string>(row, "Name")
                };

                res.Add(r);
            }

            return res;
        }

        public List<GridObstacle> GetAllGridObstacle()
        {
            SqlCommand cmd = new SqlCommand("dbo.GridObstacle_GetAll");

            var dt = _sqlDb.ExecuteSelect(cmd);

            List<GridObstacle> res = new List<GridObstacle>();

            foreach (DataRow row in dt.Rows)
            {
                GridObstacle r = new GridObstacle()
                {
                    Id = DataTableUtils.GetValue<int>(row, "GridObstacleId"),
                    Code = DataTableUtils.GetValue<string>(row, "Code"),
                    Name = DataTableUtils.GetValue<string>(row, "Name")
                };

                res.Add(r);
            }

            return res;
        }
    }
}