(function () {
    'use strict';
    angular.module('twa').controller('ProductListCtrl', ProductListCtrl);
    ProductListCtrl.$inject = ['ProductFactory'];
    function ProductListCtrl(ProductFactory) {
        var vm = this;
        vm.products = [];

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
    }
})();