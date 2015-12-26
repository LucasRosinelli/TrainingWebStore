(function () {
    'use strict';
    angular.module('twa').controller('CartCtrl', CartCtrl);
    CartCtrl.$inject = ['$rootScope', 'SETTINGS'];
    function CartCtrl($rootScope, SETTINGS) {
        var vm = this;
        vm.items = [];
        vm.total = 0;
        vm.updateTotal = updateTotal;
        vm.remove = remove;
        vm.updateQuantity = updateQuantity;

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
                    quantity: value.quantity,
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

        function remove(item) {
            var index = vm.items.indexOf(item);
            $rootScope.cart.splice(index, 1);
            localStorage.setItem(SETTINGS.CART_ITEMS, angular.toJson($rootScope.cart));
            vm.items.splice(index, 1);
            updateTotal();
        }

        function updateQuantity(item) {
            var index = vm.items.indexOf(item);
            $rootScope.cart[index].quantity = item.quantity;
            localStorage.setItem(SETTINGS.CART_ITEMS, angular.toJson($rootScope.cart));
            updateTotal();
        }
    }
})();