(function () {
    'use strict';

    angular
        .module('robotModule')
        .controller('gridCtrl', gridCtrl);

    //gridSetupCtrl.$inject = ['$scope'];

    function gridCtrl($scope, $http, gridDataService) {
        $scope.grid = gridDataService.getGridData();
        $scope.pathList = [];
        $scope.path = '';

        $scope.moveRecord = function (direction) {


            var model = new Object();
            model.CurrentLocation = $scope.grid.CurrentLocation;
            model.InitialLocation = $scope.grid.InitialLocation;
            model.MoveDirection = direction;
            model.ObstacleList = $scope.grid.ObstacleList;
            model.GridLength = $scope.grid.length;
            model.GridWidth = $scope.grid.width;
            model.RobotCode = $scope.grid.RobotType.Code;

            var promise = $http({
                method: 'POST',
                url: 'RobotMovement/MoveRecord',
                data: JSON.stringify(model),
                headers: { 'Content-Type': 'application/json' }
            });

            promise.then(function (res) {
                $scope.grid.CurrentLocation = res.data.NewLocation;
                gridDataService.assignOrUpdateGridData($scope.grid);
                addPathToList(direction);
                alert("Successfully updated the location");
            },
            function (err) {
                alert(err.data.Message);
            });

        };

        var addPathToList = function (direction) {
            if (direction == 'left')
                $scope.pathList.push('L');
            else if(direction=='forward')
                $scope.pathList.push('F');
            else if(direction=='right')
                $scope.pathList.push('R');

            $scope.path = $scope.pathList.join(",");
        }
    }
})();
