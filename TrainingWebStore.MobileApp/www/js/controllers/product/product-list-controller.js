(function () {
    'use strict';
    angular.module('twa').controller('ProductListCtrl', ProductListCtrl);
    ProductListCtrl.$inject = ['$scope', 'ProductFactory'];
    function ProductListCtrl($scope, ProductFactory) {
        $scope.products = [];

        activate();

        function activate() {
            getProducts();
        }

        function getProducts() {
            ProductFactory.get()
                .success(success)
                .catch(fail);

            function success(data) {
                $scope.products = data;
            }

            function fail(error) {
                console.log(error);
            }
        }
    }
})();