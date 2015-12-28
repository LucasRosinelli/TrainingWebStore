(function () {
    'use strict';
    angular.module('twa').controller('CartCtrl', CartCtrl);
    CartCtrl.$inject = ['$scope', '$rootScope'];
    function CartCtrl($scope, $rootScope) {
        $scope.products = [];

        activate();

        function activate() {
            getItems();
        }

        function getItems() {
            angular.forEach($rootScope.cart, function (value, key) {
                $scope.products.push({
                    title: value.title,
                    image: '',
                    quantity: value.quantity,
                    price: value.price,
                    total: value.price * value.quantity
                });
            });
        }
    }
})();