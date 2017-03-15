app.controller('APIController', function ($scope, $log, APIService) {
    getAll();

    function getAll() {
        var servCall = APIService.getSubs();
        servCall.then(function (d) {
            $scope.customer = d.data;
        }, function (error) {
            $log.error('Oops! Something went wrong while fetching the data.')
        })
    }
})

app.controller('customerController', function($scope){

})

app.controller('driverController', function($scope){

})

app.controller('rideStatusController', function($scope){

})

app.controller('aboutController', function($scope){

})