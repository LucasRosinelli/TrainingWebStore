(function () {
    'use strict';
    angular.module('twa').constant('SETTINGS', {
        'VERSION': '0.0.1',
        'CURR_ENV': 'dev',
        'AUTH_TOKEN': 'twa-token',
        'AUTH_USER': 'twa-user',
        'SERVICE_URL': '/'
        //'SERVICE_URL': 'http://myapi.lucasrosinelli.com/twa/'
    });
    angular.module('twa').run(function ($rootScope, $location, SETTINGS) {
        var token = sessionStorage.getItem(SETTINGS.AUTH_TOKEN);
        var user = sessionStorage.getItem(SETTINGS.AUTH_USER);

        $rootScope.token = null;
        $rootScope.user = null;
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

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!$rootScope.user) {
                $location.path('/login');
            }
        });
    });
})();