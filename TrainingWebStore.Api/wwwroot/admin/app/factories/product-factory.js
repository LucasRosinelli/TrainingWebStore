﻿(function () {
    'use strict';
    angular.module('twa').factory('ProductFactory', ProductFactory);
    ProductFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];
    function ProductFactory($http, $rootScope, SETTINGS) {
        return {
            get: get,
            getById: getById,
            post: post,
            put: put,
            remove: remove,
            list: list
        };

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products', $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products/' + id, $rootScope.header);
        }

        function post(product) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/products', product, $rootScope.header);
        }

        function put(product) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/products/' + product.id, product, $rootScope.header);
        }

        function remove(product) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/products/' + product.id, $rootScope.header);
        }

        function list() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products/instock', $rootScope.header);
        }
    }
})();