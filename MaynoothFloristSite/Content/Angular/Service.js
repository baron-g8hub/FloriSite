app.service("myService", function ($http) {

    //get All Eployee
    this.getItems = function () {
      
        return $http.get("Home/IndexVM");
    };

    // get Item By Id
    this.getItem = function (ID) {
        var response = $http({
            method: "post",
            url: "Home/getItemByNo",
            params: {
                id: JSON.stringify(ID)
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