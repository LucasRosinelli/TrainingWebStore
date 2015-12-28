(function () {
    'use strict';
    angular.module('twa').controller('HeadbarCtrl', HeadbarCtrl);
    HeadbarCtrl.$inject = ['$scope', '$ionicSideMenuDelegate'];
    function HeadbarCtrl($scope, $ionicSideMenuDelegate) {
        $scope.toggleSidebar = toggleSidebar;

        activate();

        function activate() {
        }

        function toggleSidebar() {
            $ionicSideMenuDelegate.toggleLeft();
        }
    }
})();
