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
            $rootScope.cart.push(product);
            localStorage.setItem(SETTINGS.CART_ITEMS, angular.toJson($rootScope.cart));
            toastr('Produto adicionado ao carrinho com sucesso', 'Produto incluído');
        }
    }
})();