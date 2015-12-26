(function () {
    'use strict';
    angular.module('twa').controller('HomeCtrl', HomeCtrl);
    HomeCtrl.$inject = ['$rootScope', 'SETTINGS', 'ProductFactory'];
    function HomeCtrl($rootScope, SETTINGS, ProductFactory) {
        var vm = this;
        vm.products = [];
        vm.addToCart = addToCart;

        activate();

        function activate() {
            getProducts();
        }

        function getProducts() {
            ProductFactory.list()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.products = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao obter lista de produtos');
            }
        }

        function addToCart(product) {
            var index = -1;
            for (var i = 0; i < $rootScope.cart.length; i++) {
                if ($rootScope.cart[i].id == product.id) {
                    index = i;
                    break;
                }
            }
            if (index > -1) {
                $rootScope.cart[index].quantity++;
            }
            else {
                product.quantity = 1;
                $rootScope.cart.push(product);
            }
            localStorage.setItem(SETTINGS.CART_ITEMS, angular.toJson($rootScope.cart));
            toastr.success('Produto adicionado ao carrinho com sucesso', 'Produto incluído');
        }
    }
})();