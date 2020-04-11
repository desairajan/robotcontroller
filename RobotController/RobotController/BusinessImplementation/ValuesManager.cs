using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RobotController.BusinessInterfaces;

namespace RobotController.BusinessImplementation
{
    public class ValuesManager: IValuesManager
    {
        public IEnumerable<string> GetValues()
        {
            //_testManager.Test();
            return new string[] { "value1", "value2" };
        }
    }
}