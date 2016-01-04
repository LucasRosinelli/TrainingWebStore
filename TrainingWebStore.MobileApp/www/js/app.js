(function () {
    'use strict';
    angular.module('twa', ['ionic']).constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'twa-token',
        'AUTH_USER': 'twa-user',
        'CART_ITEMS': 'twa-cart',
        //'SERVICE_URL': 'http://192.168.1.11:10000/' //Casa
        'SERVICE_URL': 'http://testeadt.intelimidia.com.br/wa/' //Intelimidia
        //'SERVICE_URL': 'http://myapi.lucasrosinelli.com/twa/'
    });
    angular.module('twa').run(function ($rootScope, $ionicPlatform, SETTINGS) {
        $ionicPlatform.ready(function () {
            if (window.cordova && window.cordova.plugins.Keyboard) {
                cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
                cordova.plugins.Keyboard.disableScroll(true);
            }
            if (window.StatusBar) {
                StatusBar.styleDefault();
            }
        });

        $rootScope.cart = [];
    });
    angular.module('twa').config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/');
        $stateProvider.state('home', {
            url: '/',
            templateUrl: 'pages/home/index.html',
            controller: 'HomeCtrl'
        });
        $stateProvider.state('products', {
            url: '/products',
            templateUrl: 'pages/product/index.html',
            controller: 'ProductListCtrl'
        });
        $stateProvider.state('productdetails', {
            url: '/product/details/:id',
            templateUrl: 'pages/product/details.html',
            controller: 'ProductDetailCtrl'
        });
        $stateProvider.state('cart', {
            url: '/cart',
            templateUrl: 'pages/store/cart.html',
            controller: 'CartCtrl'
        });
    });
})();
