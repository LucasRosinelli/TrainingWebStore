(function () {
    'use strict';
    angular.module('twa').controller('CartCtrl', CartCtrl);
    CartCtrl.$inject = ['$rootScope'];
    function CartCtrl($rootScope) {
        var vm = this;
        vm.items = [];
        vm.total = 0;
        vm.updateTotal = updateTotal;

        activate();

        function activate() {
            getItems();
            updateTotal();
        }

        function getItems() {
            angular.forEach($rootScope.cart, function (value, key) {
                vm.items.push({
                    title: value.title,
                    image: '',
                    quantity: 1,
                    price: value.price,
                    total: value.price
                });
            });
        }

        function updateTotal() {
            getTotal();
        }

        function getTotal() {
            var total = 0;
            angular.forEach(vm.items, function (value, key) {
                total += (value.price * value.quantity);
            });
            vm.total = total;
        }
    }
})();