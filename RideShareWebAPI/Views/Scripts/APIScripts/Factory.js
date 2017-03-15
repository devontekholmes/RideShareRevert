app.factory("APIFactory", function ($http) {
    var domain = "http://localhost:61017/api/Customers/";
    
    var getCustomer = function(id, successCB, errorCB){
        $http.get(domain + id)
        .then(function(data){
            successCB(data);
            console.log(data);
        }, function (error) {
            errorCB(error);
        });
    };
    return {
        getInfo: getInfo
    }
});