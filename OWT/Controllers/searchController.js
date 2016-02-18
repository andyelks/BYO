(function () {

    var search = angular.module('OneWayTravel');

    search.controller('searchController', ['$scope', 'flightSearch',
        function searchController($scope, flightSearch) {
            var vm = this;

            vm.showSearch = true;
            vm.showResults = false;
            vm.isLoading = false;
            vm.searchError = '';

            vm.from = '';
            vm.to = '';
            vm.date = new Date();

            vm.flightResults = undefined;

            vm.search = function (isValid) {

                if (isValid == false)
                    return;

                flightSearch.search(vm.from, vm.to, vm.date).then(function (data)
                {
                    if (data.status == 200)
                    {
                        vm.showSearch = false;
                        vm.showResults = true;
                        vm.flightResults = data.data;
                    }
                    else
                    {
                        if (data.data.ModelState != undefined)
                        {
                            if (data.data.ModelState["model.From"] != undefined)
                                vm.searchError = data.data.ModelState["model.From"][0];

                            if (data.data.ModelState["model.To"] != undefined)
                                vm.searchError = data.data.ModelState["model.To"][0];
                        }
                        else
                        {
                            vm.searchError = 'Error performing search';
                        }

                        
                    }

                })
            };

            vm.currentDate = function () {
                var now = new Date();
                var year = now.getFullYear();
                var month = now.getMonth() + 1;
                var day = now.getDate();
                if (month.toString().length == 1) {
                    var month = '0' + month;
                }
                if (day.toString().length == 1) {
                    var day = '0' + day;
                }
                var dateTime = year + '-' + month + '-' + day;
                return dateTime;
            };

            //vm.expand = function (id) {
            //    document.getElementById(id + '-details').className = 'stats-approvals-show';
            //    document.getElementById(id + '-expand').className = 'stats-approvals-hide';
            //    document.getElementById(id + '-minus').className = 'fa fa-minus-square-o stats-approvals-expand';
            //}

            //var setSavingState = function () {
            //    vm.isSaving = true;
            //    vm.isLoading = false;
            //    vm.showApprovals = false;
            //    vm.isNoDailyStats = false;
            //}

        }]);

}());