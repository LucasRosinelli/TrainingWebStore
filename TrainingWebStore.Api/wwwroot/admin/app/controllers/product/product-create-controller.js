(function () {
    'use strict';
    angular.module('twa').controller('ProductCreateCtrl', ProductCreateCtrl);
    ProductCreateCtrl.$inject = ['ProductFactory', 'CategoryFactory'];
    function ProductCreateCtrl(ProductFactory, CategoryFactory) {
        var vm = this;
        vm.categories = [];
        vm.product = {
            title: '',
            category: 0,
            description: '',
            price: 0,
            quantityOnHand: 0
        };

        activate();

        function activate() {
            getCategories();
        }

        function getProducts() {
            //ProductFactory.get()
            //    .success(success)
            //    .catch(fail);

            //function success(response) {
            //    vm.products = response;
            //}

            //function fail(error) {
            //    if (error.status == 401) {
            //        toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
            //    }
            //    else {
            //        toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
            //    }
            //}
        }

        function getCategories() {
            CategoryFactory.get()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.categories = response;
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