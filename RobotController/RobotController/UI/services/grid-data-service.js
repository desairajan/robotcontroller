(function () {

    angular.module('robotModule').factory('gridDataService', gridDataService);

    function gridDataService() {
        var gridData = {};

        var assignOrUpdateData = function (grid) {
            gridData = grid;
        };

        var getGridData = function () {
            return gridData;
        };

        return {
            assignOrUpdateGridData: assignOrUpdateData,
            getGridData: getGridData
        };
    };


})();