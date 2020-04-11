using log4net;
using RobotController.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace RobotController.Controllers
{
    [RoutePrefix("grid")]
    public class GridController : ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(GridController).Name);
        private IGridManager _gridManager;

        public GridController()
        {
            _gridManager = IoC.Resolve<IGridManager>();
        }
        [HttpGet]
        [Route("GetAllRobotType")]
        public IHttpActionResult GetAllRobotType()
        {
            try
            {
                var lst = _gridManager.GetAllRobot();

                return Ok(new { RobotTypeList = lst});
            }
            catch (Exception ex)
            {
                _log.Error("Error in GetAllRobotType ", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllGridObstacles")]
        public IHttpActionResult GetAllGridObstacles()
        {
            try
            {
                var lst = _gridManager.GetAllGridObstacle();

                return Ok(new { GridObstacleList = lst });
            }
            catch (Exception ex)
            {
                _log.Error("Error in GetAllGridObstacles ", ex);
                return BadRequest(ex.Message);
            }
        }

    }
}