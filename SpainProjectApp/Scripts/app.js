var app = angular.module('app', [ 'ui.grid', 'ui.grid.resizeColumns', 'ui.grid.selection', 'ui.grid.pagination', 'ngRoute'])
    .controller('MainCtrl', MainCtrl);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "listDetails.html",
            controller: "detailsCtrl"          
        })
        .when("/insert", {
            templateUrl: "EditDetails.html",
            controller: "insertDetailsCtrl"          
        })
        .when("/edit/:id", {
            templateUrl: "EditDetails.html",
            controller: "insertDetailsCtrl"
        })
        .when("/delete/:id", {
            templateUrl: "listDetails.html",
        controller: "deleteRecordCtrl"
        });
});

app.controller("deleteRecordCtrl", function ($scope, $location, $http, $routeParams) {
    if (typeof $routeParams.id !== 'undefined') {
        $scope.currentEditId = $routeParams.id;
        $http.delete('/api/details/' + $routeParams.id).then(function (response) {
            var s = response;
            $scope.$parent.canEdit = false;
            $location.path('/');
        });
    }
});

app.controller("insertDetailsCtrl", function ($scope, $location, $http, uiGridConstants, $routeParams) {


    $scope.currentEditId = '0';

    if (typeof $routeParams.id !== 'undefined') {
        $scope.currentEditId = $routeParams.id;
        $http.get('/api/details/' + $routeParams.id).then(function (response) {
            var arrData = angular.fromJson(response.data);            
            arrData[0].DateOfAuto = new Date(arrData[0].DateOfAuto.substr(0, 10));
            $scope.details = arrData[0];
        });            
    }
   
    $scope.details = {};
    $scope.details.DateOfAuto = new Date(1700, 0, 1);
    


    $scope.mDateofAuto = new Date(1700, 0, 1);    
    
    $scope.closeInsert = function () {
        $location.path('/');
        $scope.$parent.canEdit = false;
    };

    $scope.saveInsert = function () {    
        

        var saveDetail = {
            mDateofAuto: $scope.details.DateOfAuto,
            mTribunal: $scope.details.Tribunal,
            mselTypeofAuto: $scope.details.TypeOfAuto,
            mLocationofAuto: $scope.details.LocationOfAuto,
            mtxtName: $scope.details.Name,
            mAliases: $scope.details.Aliases,
            mselGender: $scope.details.Sex,            
            mselPersonalStatus: $scope.details.PersonalStatus,
            mOccupation: $scope.details.Occupation,
            mFamilyTies: $scope.details.FamilyTies,
            mLocationOfBirth: $scope.details.LocationOfBirth,
            mResidence: $scope.details.Residence,
            mTypeOfCrime: $scope.details.TypeOfCrime,
            mSentence: $scope.details.Sentence,
            mAdditionalInformation: $scope.details.AdditionalInformation,
            mAge: $scope.details.Age,
            mGenealogicalOrigin: $scope.details.GenealogicalOrigin,
            mSurname: $scope.details.Surname,
            mBishopricOfBirth: $scope.details.BishopricOfBirth,
            mBishopricOfResidence: $scope.details.BishopricOfResidence,
            mPunishment: $scope.details.Punishment
        };

        if ($scope.currentEditId !== '0') {
            saveDetail.mCurrentEditId = $scope.currentEditId;
            $scope.currentEditId = '0';
            $scope.$parent.canEdit = false;
        }

        //return;
        $http({
            method: "post",
//            url: "http://spainproject.gearhostpreview.com/api/details/",
            url: "/api/details",
            data: saveDetail
        }).then(function success(data, status, headers, config) {
            $scope.PostDataResponse = data;
            $scope.closeInsert();
        }, function myErr(data, status, header, config) {
            $scope.ResponseDetails = "Data: " + data +
                "<hr />status: " + status +
                "<hr />headers: " + header +
                "<hr />config: " + config;
        });
    };
});

function MainCtrl($scope, $http, uiGridConstants) {    

//    $scope.gridOptions = {        
//        enableColumnResizing: true,
//        enableRowSelection: true, enableRowHeaderSelection: false,
//        columnDefs: [
//            { field: 'ID', width: '3%' },
//            { field: 'CreateDate', width: '10%', cellFilter: 'date:"dd MM yyyy hh:mm:ss"'},
//            { field: 'DateOfAuto', width: '10%', cellFilter: 'date:"dd-MM-yyyy"'},            
//            { field: 'Tribunal', width: '10%'},
//            { field: 'TypeOfAuto', width: '10%'},
//            { field: 'LocationOfAuto', width: '10%' },
//            { field: 'Name', width: '10%' },
//            { field: 'Surname', width: '10%' },
//            { field: 'Aliases', width: '10%'},
//            { field: 'Gender', width: '10%' },
//            { field: 'GenealogicalOrigin', width: '10%' },
//            { field: 'Age', width: '10%' },      
//            { field: 'PersonalStatus', width: '10%'},
//            { field: 'Occupation', width: '10%'},
//            { field: 'FamilyTies', width: '30%'},
//            { field: 'LocationOfBirth', width: '10%' },
//            { field: 'BishopricOfBirth', width: '10%' },
//            { field: 'Residence', width: '10%' },
//            { field: 'BishopricOfResidence', width: '10%' },
//            { field: 'TypeOfCrime', width: '10%'},
//            { field: 'Sentence', width: '10%' },
//            { field: 'Punishment', width: '10%' },
//            { field: 'AdditionalInformation', width: '50%' }
//        ]
     
//    };
//    $scope.gridOptions.multiSelect = false;
//    $scope.gridOptions.modifierKeysToMultiSelect = false;
//    $scope.gridOptions.noUnselect = false;
//    $scope.gridOptions.onRegisterApi = function (gridApi) {
//        $scope.gridApi = gridApi;
//        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            
//            console.log(row);
            
//            $scope.canEdit = row.isSelected;
//        });

//    };

//    $http.get('/api/details/').then(function (response) {
////        $http.get('/api/details/').then(function (response) {
//        var e = angular.fromJson(response.data);
//        $scope.gridOptions.data = e;

//    });
}

app.controller("detailsCtrl", function ($scope, $location, $http, uiGridConstants, $timeout) {
    $scope.gridOptions = {
        enableColumnResizing: true,
        enableRowSelection: true, enableRowHeaderSelection: false,
        enableFiltering: true,
        paginationPageSizes: [25, 50, 75],
        paginationPageSize: 25,
        columnDefs: [
            { field: 'ID', width: '3%', enableFiltering: false },
            { field: 'CreateDate', width: '10%', cellFilter: 'date:"dd MM yyyy hh:mm:ss"', enableFiltering: false },
            { field: 'DateOfAuto', width: '10%', cellFilter: 'date:"dd-MM-yyyy"' },
            { field: 'Tribunal', width: '10%' },
            { field: 'TypeOfAuto', width: '10%' },
//            { field: 'LocationOfAuto', width: '10%' },
            { field: 'Name', width: '10%' },
            { field: 'Surname', width: '10%' },
            { field: 'Aliases', width: '10%' },
            { field: 'LocationOfBirth', width: '10%' },
            { field: 'BishopricOfBirth', width: '10%' },
            { field: 'Residence', width: '10%' },
            { field: 'BishopricOfResidence', width: '10%' },
            { field: 'Sex', width: '10%' },
//            { field: 'GenealogicalOrigin', width: '10%' },
            { field: 'Age', width: '10%' },
            { field: 'PersonalStatus', width: '10%' },
            { field: 'Occupation', width: '10%' },
            { field: 'FamilyTies', width: '30%' },          
            { field: 'TypeOfCrime', width: '10%' },
            { field: 'Sentence', width: '10%' },
            { field: 'Punishment', width: '10%' },
            { field: 'AdditionalInformation', width: '50%' }
        ]

    };
    $scope.gridOptions.multiSelect = false;
    $scope.gridOptions.modifierKeysToMultiSelect = false;
    $scope.gridOptions.noUnselect = false;
    $scope.gridOptions.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
        gridApi.selection.on.rowSelectionChanged($scope, function (row) {
            console.log(row);
            $scope.$parent.canEdit = row.isSelected;
            $scope.$parent.editId = row.entity.ID;
        });
        gridApi.core.on.filterChanged($scope, function () {
            $timeout(function () {
                $scope.numOfRows = gridApi.grid.getVisibleRows().length;
            }, 500);
            
        });
    };


    $http.get('/api/details/').then(function (response) {        
        var e = angular.fromJson(response.data);
        $scope.gridOptions.data = e;
        $scope.numOfRows = $scope.gridOptions.data.length;
    });

});
