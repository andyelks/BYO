(function () {
    "use strict";
    angular.module('OneWayTravel', ['ui.router'])

    .config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.when('', '/search');

        $stateProvider

            .state('search', {
                url: '/search',
                templateUrl: 'searchView.html',
                controller: 'searchController as vm'
            })

            .state('booking', {
                url: '/booking',
                templateUrl: 'bookingView.html',
                controller: 'bookingController as vm'
            })




    })

}());