(function () {
    'use strict';
    angular.module('twa').controller('ProductListCtrl', ProductListCtrl);
    ProductListCtrl.$inject = ['ProductFactory'];
    function ProductListCtrl(ProductFactory) {
        var vm = this;
        vm.products = [];
        vm.product;
        vm.removeProduct = removeProduct;

        activate();

        function activate() {
            getProducts();
        }

        function getProducts() {
            ProductFactory.get()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.products = response;
            }

            function fail(error) {
                if (error.status == 401) {
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                }
                else {
                    toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
                }
            }
        }

        function removeProduct(product) {
            vm.product = product;
            ProductFactory.remove(vm.product)
                .success(success)
                .catch(fail);

            function success(response) {
                var index = vm.products.indexOf(product);
                vm.products.splice(index, 1);
                toastr.success('Produto excluído', 'Sucesso');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
            }

            vm.product = {
                id: 0
            };
        }
    }
})();