(function () {
    'use strict';
    angular.module('twa').factory('ProductFactory', ProductFactory);
    ProductFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];
    function ProductFactory($http, $rootScope, SETTINGS) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove
        };

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products', $rootScope.header);
        }

        function post(product) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/products', product, $rootScope.header);
        }

        function put(product) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/products/' + product.id, category, $rootScope.header);
        }

        function remove(product) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/products/' + product.id, $rootScope.header);
        }
    }
})();