(function () {
    'use strict';
    angular.module('twa').config(function ($routeProvider) {
        $routeProvider.
            when('/', {
                controller: 'HomeCtrl',
                controllerAs: 'vm',
                templateUrl: 'pages/home/index.html'
            });
    });
})();