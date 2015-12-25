(function () {
    'use strict';
    angular.module('twa').factory('ProductFactory', ProductFactory);
    ProductFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];
    function ProductFactory($http, $rootScope, SETTINGS) {
        return {
            list: list
        };

        function list() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/products/instock', $rootScope.header);
        }
    }
})();