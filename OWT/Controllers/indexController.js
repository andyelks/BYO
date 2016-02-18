(function () {

    var index = angular.module('OneWayTravel');

    index.controller('indexController', ['$rootScope', '$location',
        function indexController($rootScope, $location) {
            var ivm = this;

            var setupDisplay = function () {
                $location.url("/search");
            }

            setupDisplay();
        }]);

}());