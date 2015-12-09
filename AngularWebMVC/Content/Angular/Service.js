app.service("myService", function ($http) {

    //get All Product
    this.getProducts = function () {
      
        return $http.get("Home/GetAll");
    };

    // get Product By Id
    this.getProduct = function (productId) {
        var response = $http({
            method: "post",
            url: "Home/getProductByNo",
            params: {
                id: JSON.stringify(productId)
            }
        });
        return response;
    }

    // Update Employee 
    this.updateEmp = function (employee) {
        var response = $http({
            method: "post",
            url: "Home/UpdateEmployee",
            data: JSON.stringify(employee),
            dataType: "json"
        });
        return response;
    }

    // Add Employee
    this.AddEmp = function (employee) {
       
        var response = $http({
            method: "post",
            url: "Home/AddEmployee",
            data: JSON.stringify(employee),
            dataType: "json"
        });
      
        return response;
    }

    //Delete Employee
    this.DeleteEmp = function (employee) {
        var response = $http({
            method: "post",
            url: "Home/DeleteEmployee",
            data: JSON.stringify(employee),
            dataType: "json"
            //params: {
            //    employeeId: JSON.stringify(employeeId)
           // }
        });
        return response;
    }
});