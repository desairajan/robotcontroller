(function () {
    'use strict';

    angular
        .module('robotModule')
        .controller('gridSetupCtrl', gridSetupCtrl);

    //gridSetupCtrl.$inject = ['$scope']; 

    function gridSetupCtrl($scope, $http, $uibModal,$state,gridDataService) {
        $scope.grid = {
            InitialLocation: {},
            CurrentLocation: {},
            ObstacleList: []
        };

        $scope.addRecord = function () {
            $scope.modalInstance = $uibModal.open({
                animation: false,
                templateUrl: 'UI/gridSetup/grid-setup-add-obstacle.html',
                controller: 'gridSetupAddObstacleCtrl',
                scope: $scope,
                size: '',
                resolve: {
                }
            });

        }

        function getRobotType(){
            $http.get("Grid/GetAllRobotType").then(function (res) {
                $scope.robotTypeList = res.data.RobotTypeList;
            },
            function(err){
                alert(err);
            });
            
        }

        function getGridObstacles() {
            $http.get("Grid/GetAllGridObstacles").then(function (res) {
                $scope.gridObstacleList = res.data.GridObstacleList;
            },
            function (err) {
                alert(err);
            });

        }

        $scope.gotoGrid = function () {
            //add direction to initiallocation
            $scope.grid.InitialLocation.Direction = "East";
            //copy initiallocation to currentlocation
            $scope.grid.CurrentLocation = $scope.grid.InitialLocation;
            gridDataService.assignOrUpdateGridData($scope.grid);
            $state.go('grid');
        }

        function initializeGrid() {
            getRobotType();
            getGridObstacles();
        }
        

        initializeGrid();
    }
})();
