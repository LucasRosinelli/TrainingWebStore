(function () {
    'use strict';
    angular.module('twa').controller('CategoryCtrl', CategoryCtrl);
    CategoryCtrl.$inject = ['CategoryFactory'];
    function CategoryCtrl(CategoryFactory) {
        var vm = this;
        vm.categories = [];
        vm.category = {
            id: 0,
            title: ''
        };
        vm.saveCategory = saveCategory;
        vm.loadCategory = loadCategory;
        vm.cancel = cancel;
        vm.removeCategory = removeCategory;

        activate();

        function activate() {
            getCategories();
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

        function saveCategory() {
            if (vm.category.id == 0) {
                addCategory();
            }
            else {
                updateCategory();
            }
        }

        function addCategory() {
            CategoryFactory.post(vm.category)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.categories.push(response);
                toastr.success('Categoria cadastrada', 'Sucesso');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
            }
            clearCategory();
        }

        function updateCategory() {
            CategoryFactory.put(vm.category)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Categoria atualizada', 'Sucesso');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
            }
            clearCategory();
        }

        function clearCategory() {
            vm.category = {
                id: 0,
                title: ''
            };
        }

        function loadCategory(category) {
            vm.category = category;
        }

        function cancel() {
            clearCategory();
        }

        function removeCategory(category) {
            loadCategory(category);
            CategoryFactory.remove(vm.category)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Categoria excluída', 'Sucesso');
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na requisição');
            }

            var index = vm.categories.indexOf(category);
            vm.categories.splice(index, 1);
            clearCategory();
        }
    }
})();