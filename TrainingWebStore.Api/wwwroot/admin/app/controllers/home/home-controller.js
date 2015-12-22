(function () {
    'use strict';
    angular.module('twa').controller('HomeCtrl', HomeCtrl);
    HomeCtrl.$inject = [];
    function HomeCtrl() {
        var vm = this;
        vm.title = "Meu Home Controller";
        vm.activate = activate;

        activate();

        function activate() {
        }
    }
})();