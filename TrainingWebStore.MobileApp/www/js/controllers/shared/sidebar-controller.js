(function () {
    'use strict';
    angular.module('twa').controller('SidebarCtrl', SidebarCtrl);
    SidebarCtrl.$inject = ['$location', '$scope', '$ionicSideMenuDelegate'];
    function SidebarCtrl($location, $scope, $ionicSideMenuDelegate) {
        $scope.goHome = goHome;
        $scope.goProducts = goProducts;
        $scope.goCart = goCart;

        activate();

        function activate() {
        }

        function go(url) {
            $location.path('/' + url);
            $ionicSideMenuDelegate.toggleLeft();
        }

        function goHome() {
            go('home');
        }

        function goProducts() {
            go('products');
        }

        function goCart() {
            go('cart');
        }
    }
})();