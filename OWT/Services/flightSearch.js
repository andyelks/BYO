(function () {

    var index = angular.module('OneWayTravel');

    index.factory('flightSearch', ['$window', '$q', '$http', function ($window, $q, $http) {

        var search = function (from, to, date) {
            var deferred = $q.defer();

            console.log("Performing search");
            $http.post('http://localhost:51915/api/FlightSearch',
                { 'From': from, 'To': to, 'Date': date })
                .then(
                    function (response) {
                        console.log('Search Complete')
                        deferred.resolve(response);
                    },
                    function (response) {
                        console.log('Search Failed')
                        deferred.resolve(response);
                    }
                );

            return deferred.promise;
        }

        return {
            search: search
        }

    }]);

}());