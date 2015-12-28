(function () {
    'use strict';
    angular.module('twa').controller('ProductDetailCtrl', ProductDetailCtrl);
    ProductDetailCtrl.$inject = ['$stateParams', '$scope', '$rootScope', '$location', 'ProductFactory'];
    function ProductDetailCtrl($stateParams, $scope, $rootScope, $location, ProductFactory) {
        var id = $stateParams.id;

        $scope.product = {};
        $scope.addToCart = addToCart;

        activate();

        function activate() {
            getProduct();
        }

        function getProduct() {
            ProductFactory.getById(id)
                .success(success)
                .catch(fail);

            function success(data) {
                $scope.product = data;
            }

            function fail(error) {
                console.log(error);
            }
        }

        function addToCart() {
            var index = -1;
            for (var i = 0; i < $rootScope.cart.length; i++) {
                if ($rootScope.cart[i].id == $scope.product.id) {
                    index = i;
                    break;
                }
            }
            if (index > -1) {
                $rootScope.cart[index].quantity++;
            }
            else {
                $scope.product.quantity = 1;
                $rootScope.cart.push($scope.product);
            }
            $location.path('/cart');
        }
    }
})();