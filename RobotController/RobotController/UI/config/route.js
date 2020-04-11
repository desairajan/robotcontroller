(function () {
    'use strict';
    angular.module('robotModule').config(['$stateProvider','$urlRouterProvider',function ($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('roboHome', {
                url: '/roboHome',
                templateUrl: '/UI/robot-home.html'
            })
            .state('gridSetup', {
                url: '/gridSetup',
                templateUrl: '/UI/gridSetup/grid-setup.html',
                controller: 'gridSetupCtrl'
            })
            .state('grid', {
                url: '/grid',
                templateUrl: '/UI/grid/grid.html',
                controller: 'gridCtrl'
            });

        $urlRouterProvider.otherwise('/roboHome');
    }

    ]);

})();