(function () {
    'use strict';
    angular.module('twa').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'twa-token',
        'AUTH_USER': 'twa-user',
        'CART_ITEMS': 'twa-cart',
        'SERVICE_URL': '/'
        //'SERVICE_URL': 'http://myapi.lucasrosinelli.com/twa/'
    });
    angular.module('twa').run(function ($rootScope, $location, SETTINGS) {
        var token = sessionStorage.getItem(SETTINGS.AUTH_TOKEN);
        var user = sessionStorage.getItem(SETTINGS.AUTH_USER);
        var cart = localStorage.getItem(SETTINGS.CART_ITEMS);

        $rootScope.token = null;
        $rootScope.user = null;
        $rootScope.cart = [];
        $rootScope.header = null;

        if (token && user) {
            $rootScope.token = token;
            $rootScope.user = user;
            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer ' + $rootScope.token
                }
            };
        }

        if (cart) {
            var items = angular.fromJson(cart);
            angular.forEach(items, function (value, key) {
                $rootScope.cart.push(value);
            });
        }

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!$rootScope.user) {
                $location.path('/login');
            }
        });
    });
})();