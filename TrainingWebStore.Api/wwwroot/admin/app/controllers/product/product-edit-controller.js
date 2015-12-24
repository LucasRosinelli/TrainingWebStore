(function () {
    'use strict';
    angular.module('twa').controller('ProductEditCtrl', ProductEditCtrl);
    ProductEditCtrl.$inject = ['$routeParams', '$scope', '$location', 'ProductFactory', 'CategoryFactory'];
    function ProductEditCtrl($routeParams, $scope, $location, ProductFactory, CategoryFactory) {
        var vm = this;
        var id = $routeParams.id;

        vm.categories = [];
        vm.product = {};
        vm.save = save;

        activate();

        function activate() {
            getCategories();
            getProduct();
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

        function getProduct() {
            ProductFactory.getById(id)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.product = response;
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

        function save() {
            ProductFactory.put(vm.product)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Produto alterado', 'Sucesso');
                $location.path('/products');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
            }
        }

        var handleFileSelect = function (evt) {
            var file = evt.currentTarget.files[0];
            var reader = new FileReader();
            reader.onload = function (evt) {
                $scope.$apply(function ($scope) {
                    vm.product.image = evt.target.result;
                });
            };
            reader.readAsDataURL(file);
        };
        angular.element(document.querySelector('#file')).on('change', handleFileSelect);
    }
})();