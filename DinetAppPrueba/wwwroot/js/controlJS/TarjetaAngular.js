var app = angular.module("app", []);

app.controller("myController", function ($scope, $http) {

    $scope.accion = "AGREGAR";

    window.onload = function () {
        loadTarjetas();
        $scope.tarjeta = {};
    };

    loadTarjetas = function () {
        $http.get("/Tarjeta/GetAllTarjetas").
            then(function (response) {
                $scope.tarjetas = response.data;
                $scope.numtarjetas = response.data.length;
            })
            .catch(function (error) {
                alert('No se pudo obtener las tarjetas!!');
                console.error('Error al obtener tarjetas: ', error);
            });
    };

    $scope.onCreate = function () {
        $scope.accion = "AGREGAR";
        $scope.tarjeta = {};
    };

    $scope.onUpdate = function (miTarjeta) {
        $scope.accion = "ACTUALIZAR";
        $scope.tarjeta = miTarjeta;
    };

    $scope.createupate_Tarjeta = function () {
        console.log($scope.tarjeta);
        if ($scope.accion === "AGREGAR") {
            console.log("AGREGAR" );
            ins_Tarjeta();
        } else {
            console.log("ACTUALIZAR");
            upd_Tarjeta();
        }
    };


    ins_Tarjeta = function () {
        $http.post("/Tarjeta/AddTarjeta", $scope.tarjeta)
            .then(function (response) {
                console.log("Tarjeta registrada:" + response.data);
                alert("Tarjeta registrada!!");
                loadTarjetas();
                $scope.accion = "AGREGAR";

            })
            .catch(function (error) {
                console.error('Error al registrar la Tarjeta: ', error);
                alert('No se pudo registrar la Tarjeta!!');
            });
    };

    upd_Tarjeta = function () {
        $http.put("/Tarjeta/EditTarjeta", $scope.tarjeta)
            .then(function (response) {
                console.log("Tarjeta actualizada:" + response.data);
                alert("Tarjeta actualizada!!");
                loadTarjetas();
                $scope.accion = "AGREGAR";
                $scope.tarjeta = {};
            })
            .catch(function (error) {
                console.error('Error al actualizar la Tarjeta: ', error);
                alert('No se pudo actualizar la Tarjeta!! ');
            });
    };


    $scope.del_Tarjeta = function (idTarjeta) {
        console.log("tarjeta para eliminar con idTarjeta:", idTarjeta);
        $http.delete("/Tarjeta/DeleteTarjeta/"+ idTarjeta)
            .then(function (response) {
                console.log("Tarjeta eliminada:" + response.data);
                alert("Tarjeta eliminada!!");
                loadTarjetas();
            })
            .catch(function (error) {
                console.error('Error al eliminar la Tarjeta: ', error);
                alert('No se pudo eliminar la Tarjeta!!');
            });
    };



});