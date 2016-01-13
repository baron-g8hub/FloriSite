app.controller("myCntrl", function ($scope, myService) {
    //$scope.divEmployee = false;
    //GetAllEmployee();
    ////To Get All Records  
    //function GetAllEmployee() {

    //    var getData = myService.getEmployees();

    //    getData.then(function (emp) {
    //        $scope.employees = emp.data;
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

    //$scope.editEmployee = function (employee) {
    //    debugger;
    //    var getData = myService.getEmployee(employee.Id);
    //    getData.then(function (emp) {
    //        $scope.employee = emp.data;
    //        $scope.employeeId = employee.Id;
    //        $scope.employeeName = employee.name;
    //        $scope.employeeEmail = employee.email;
    //        $scope.employeeMobil_no = employee.mobil_no;
    //        $scope.Action = "Update";
    //        $scope.divEmployee = true;
    //    },
    //    function () {
    //        alert('Error in getting records');
    //    });
    //}

    //$scope.AddUpdateEmployee = function () {

    //    console.log($scope.employee);  //this shows the object
    //    var Employee = {
    //        Name: $scope.employeeName,
    //        Email: $scope.employeeEmail,
    //        Mobil_no: $scope.employeeMobil_no
    //    };
    //    var getAction = $scope.Action;

    //    if (getAction == "Update") {
    //        Employee.Id = $scope.employeeId;
    //        var getData = myService.updateEmp(Employee);
    //        getData.then(function (msg) {
    //            GetAllEmployee();
    //            alert(msg.data);
    //            $scope.divEmployee = false;
    //        }, function () {
    //            alert('Error in updating record');
    //        });
    //    }
    //    else {
    //        var getData = myService.AddEmp(Employee);
    //        getData.then(function (msg) {
    //            GetAllEmployee();
    //            alert(msg.data);
    //            $scope.divEmployee = false;
    //        }, function () {
    //            alert('Error in adding record');
    //        });
    //    }
    //    debugger;
    //    GetAllEmployee();
    //    $scope.refresh();
    //}

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


});

app.controller('ModalDemoCtrl', function ($scope, $uibModal, $log, myService) {

    $scope.divEmployee = false;
    GetAllEmployee();
    //To Get All Records  
    function GetItems() {

        var getData = myService.getItems();

        getData.then(function (item) {
            $scope.items = item.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editEmployee = function (item) {
        debugger;
        var getData = myService.getItems(item.Id);
        getData.then(function (item) {
            $scope.product = item.data;
            $scope.productId = item.Id;
            $scope.productName = item.Name;
            $scope.productPrice = item.Price;
            $scope.productDescription = item.Description;
            $scope.productImage = employee.Image;
        
            //$scope.divEmployee = true;
        },
        function () {
            alert('Error in getting records');
        });
    }

    $scope.AddUpdateEmployee = function () {

        //$scope.employee = empNew;

        console.log($scope.employee);  //this shows the object
        var Employee = {
            Name: $scope.employee.name,
            Email: $scope.employee.email,
            Mobil_no: $scope.employee.mobil_no
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            Employee.Id = $scope.employee.Id;
            var getData = myService.updateEmp(Employee);
            getData.then(function (msg) {
                GetAllEmployee();
                alert(msg.data);
                //ClearFields();
                //$scope.divEmployee = false;
            }, function () {
                alert('Error in updating record');
            });
        }
        else {
            var getData = myService.AddEmp(Employee);
            getData.then(function (msg) {
                GetAllEmployee();
                alert(msg.data);
                //ClearFields();
                //$scope.divEmployee = false;
            }, function () {
                alert('Error in adding record');
            });
        }
        debugger;
        GetAllEmployee();
        $scope.refresh();
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

    $scope.clearFields = function () {
        $scope.employee.Id = null;
        $scope.employee.name = null;
        $scope.employee.email = null;
        $scope.employee.mobil_no = null;
    }

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            
            reader.onload = function (e) {
                $('#blah').attr('src', e.target.result);
            }
            
            reader.readAsDataURL(input.files[0]);
        }
    }
    
    $("#imgInp").change(function(){
        readURL(this);
    });



    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    $scope.animationsEnabled = true;

    // for Modal popup
    $scope.open = function (size, employee) {

        $scope.employee = employee

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '/home/index',
            controller: 'ModalInstanceCtrl',
            size: size,
            scope: $scope,
            resolve: {
                items: function () {
                    console.log($scope.employee);  //this shows the object
                    //$scope.editEmployee(employee);
                    return employee;
                }
            }
        });

        modalInstance.result.then(function (addNewEmp) {

            console.log($scope.employee);  //this shows the object

            if (addNewEmp.Id == null) {

                $scope.employee = addNewEmp;
                $scope.Action = "Add";
                $scope.AddUpdateEmployee();
            }
            else if (addNewEmp.Id != null) {


                $scope.Action = "Update";
                // $scope.employee = newEmp;
                $scope.AddUpdateEmployee();
            }
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });
    };

    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };

});

// Please note that $modalInstance represents a modal window (instance) dependency.
// It is not the same as the $uibModal service used above.

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance, items) {
    
    $scope.ok = function (employee) {

        $scope.newEmployee = employee;
        $uibModalInstance.close($scope.newEmployee);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});