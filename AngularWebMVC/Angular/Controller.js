app.controller("myCntrl", function ($scope, myService) {
    $scope.divEmployee = false;
    GetAllProduct();
    //To Get All Records  
    function GetAllProduct() {

        var getData = myService.getProducts();

        getData.then(function (prod) {
            $scope.products = prod.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editProduct = function (product) {
        debugger;
        var getData = myService.getProduct(product.Id);
        getData.then(function (prod) {
            $scope.product = prod.data;
            $scope.productId = product.Id;
            $scope.productName = product.Name;
            $scope.productPrice = product.Price;
            $scope.productDescription = product.Description;
            $scope.productImage = product.Image;

            $scope.Action = "Update";
            $scope.divEmployee = true;
        },
        function () {
            alert('Error in getting records');
        });
    }

    $scope.AddUpdateEmployee = function () {

        var Employee = {
            Name: $scope.employeeName,
            Email: $scope.employeeEmail,
            Mobil_no: $scope.employeeMobil_no
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Employee.Id = $scope.employeeId;
            var getData = myService.updateEmp(Employee);
            getData.then(function (msg) {
                GetAllEmployee();
                alert(msg.data);
                $scope.divEmployee = false;
            }, function () {
                alert('Error in updating record');
            });
        }
        else {
            var getData = myService.AddEmp(Employee);
            getData.then(function (msg) {
                GetAllEmployee();
                alert(msg.data);
                $scope.divEmployee = false;
            }, function () {
                alert('Error in adding record');
            });
        }
        debugger;
        GetAllEmployee();
        $scope.refresh();
    }

    //$scope.apply(function () {
    //    debugger;
    //    // update goes here
    //    GetAllEmployee();
    //});


    $scope.AddEmployeeDiv = function () {
        ClearFields();
        $scope.Action = "Add";
        $scope.divEmployee = true;
    }
    $scope.CancelBtn = function () {
        ClearFields();
        CancelPanel();
    }

    $scope.deleteEmployee = function (employee) {
        debugger;
        var getData = myService.DeleteEmp(employee);
        getData.then(function (msg) {
            GetAllEmployee();
            alert('Employee Deleted');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

    function ClearFields() {
        $scope.employeeId = "";
        $scope.employeeName = "";
        $scope.employeeEmail = "";
        $scope.employeeMobil_no = "";
    }

    function CancelPanel() {
        $scope.divEmployee = false;
    }
});