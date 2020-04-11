using log4net;
using RobotController.BusinessInterfaces;
using RobotController.Models.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace RobotController.Controllers
{
    public class RobotMovementController:ApiController
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(RobotMovementController).Name);
        
        [HttpPost]
        public IHttpActionResult MoveRecord(RobotMovementUi model)
        {
            try
            {
                if (!IoC.IsRegistered<IRobotMovementProvider>(model.MoveDirection))
                    throw new ApplicationException(model.MoveDirection + " implementation not found");

                var newLocation = IoC.Resolve<IRobotMovementProvider>(model.MoveDirection).MoveRecord(model);

                return Ok(new { NewLocation = newLocation });
            }
            catch (Exception ex)
            {
                _log.Error("Error in MoveRecord() ", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}