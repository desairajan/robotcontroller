using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using RobotController.BusinessImplementation;
using RobotController.BusinessInterfaces;
using RobotController.BusinessImplementation.ObstacleBehaviours;
using RobotController.DAL.Implementation;
using RobotController.DAL.Interfaces;
using RobotController.BusinessImplementation.RobotMovementProvider;

namespace RobotController.DependencyInjection
{
    public class DependencyResolver
    {
        public void Initialize(IUnityContainer container)
        {
            //Business
            container.RegisterType<IValuesManager, ValuesManager>();
            container.RegisterType<IGridManager, GridManager>();

            container.RegisterType<IObstacleBehaviourProvider, GoBackToInitialLocationObstacleBehaviour>("OB1");
            container.RegisterType<IObstacleBehaviourProvider, CannotMoveObstacleBehaviour>("OB2");
            container.RegisterType<IObstacleBehaviourProvider, ClockWiseSpinNinetyDegreeObstacleBehaviour>("OB3");

            container.RegisterType<IGridObstacleBehaviourLinkManager, GridObstacleBehaviourLinkManager>();
            container.RegisterType<IRobotMovementProvider, LeftMovementProvider>("left");
            container.RegisterType<IRobotMovementProvider, RightMovementProvider>("right");
            container.RegisterType<IRobotMovementProvider, ForwardMovementProvider>("forward");

            //DAL
            container.RegisterType<ISqlDatabase, SqlDatabase>();
            container.RegisterType<IGridObstacleBehaviourLinkDao, GridObstacleBehaviourLinkDao>();
            container.RegisterType<IGridDao, GridDao>();

        }
    }
}