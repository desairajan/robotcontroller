(function () {
    'use strict';

    angular
        .module('robotModule')
        .controller('gridSetupAddObstacleCtrl', gridSetupAddObstacleCtrl);

    function gridSetupAddObstacleCtrl($scope){
        $scope.obstacle = new Object();
        $scope.obstacle.Obstacle = {};
        $scope.obstacle.Coordinate = {};

        $scope.save = function (obstacle) {

            if (angular.isDefined(obstacle)) {

                if (!angular.isDefined(obstacle.Obstacle))
                    alert("Select Obstacle");
                else if (angular.isDefined(obstacle.Coordinate) && (angular.isDefined(obstacle.Obstacle.XCoordinate) || obstacle.Obstacle.XCoordinate == ''))
                    alert("Provide X Position");
                else if (angular.isDefined(obstacle.Coordinate) && (angular.isDefined(obstacle.Obstacle.YCoordinate) || obstacle.Obstacle.YCoordinate == ''))
                    alert("Provide Y Position");
                else {
                    $scope.grid.ObstacleList.push(obstacle);
                    $scope.cancelModal();
                }
            }
        };

        $scope.cancelModal = function () {
            $scope.modalInstance.close();
        };

    }


})();