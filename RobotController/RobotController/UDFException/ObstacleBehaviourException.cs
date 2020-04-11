using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobotController.UDFException
{
    public class ObstacleBehaviourException : Exception
    {
        public ObstacleBehaviourException(string message) : base(message)
        {

        }
    }
}