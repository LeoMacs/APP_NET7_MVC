var app = angular.module("app", []);


app.controller("myController", function ($scope, $http) {

    var accion = "";



    /****************GET MOVIMIENTOS**********************************/
    var parametros = {
        NRO_DOCUMENTO: null,
        TIPO_MOVIMIENTO: null,
        FECHA_INI: null,
        FECHA_FIN: null
    };

    $http.get("/Movimiento/getMovimientos", { params: parametros }).
        then(function (response) {
            $scope.movimientos = response.data;
            $scope.numMovimientos = response.data.length;
        })
        .catch(function (error) {
            alert('No se pudo obtener los movimientos!!');
            console.error('Error al obtener Movimientos: ', error);
        });


    $scope.loadMovimientos = function (filtros) {
        $http({
            method: "GET",
            url: "/Movimiento/getMovimientos",
            datatype: "json",
            data: JSON.stringify(filtros)
        }).then(function (response) {
            $scope.movimientos = response.data;
            $scope.numMovimientos = response.data.length;
        }).catch(function (error) {
            alert('No se pudo obtener los movimientos!!');
            console.error('Error al obtener Movimientos: ', error);
        });
    };
    //funciona
    //$scope.loadMovimientos = function (filtros) {
    //    $http.get("/Movimiento/getMovimientos", { params: filtros }).
    //        then(function (d) {
    //            $scope.movimientos = d.data;
    //            $scope.numMovimientos = d.data.length;
    //        })
    //        .catch(function (error) {
    //            alert('No se pudo obtener los movimientos!!');
    //            console.error('Error al obtener Movimientos: ', error);
    //        });
    //};  


    $scope.loadMovimientoxUnidad = function (mov) {
        $http({
            method: "GET",
            url: "/Movimiento/getMovimientosxUnidad",
            datatype: "json",
            data: JSON.stringify(mov)
        }).then(function (response) {
            $scope.movimiento = response.data;
        }).catch(function (error) {
            alert('No se pudo obtener el movimiento!!');
            console.error('Error al obtener el Movimiento: ', error);
        });
    };


    /****************INSERTS MOVIMIENTOS**********************************/
    $scope.pushRegMod1 = function () {
        $scope.btntext = "REGISTRAR";
        $scope.movimiento = {
            COD_CIA: "0",
            COMPANIA_VENTA_3: "1",
            ALMACEN_VENTA: "HU",
            TIPO_MOVIMIENTO: "",
            TIPO_DOCUMENTO: "",
            NRO_DOCUMENTO: "",
            COD_ITEM_2: ""
        };
        $("#tipDoc").attr("readonly", false);
        $("#nroDoc").attr("readonly", false);
        accion = "ins";
    };

    $scope.ins_movimiento = function () {

        $http.post("/Movimiento/InsertMovimiento", $scope.movimiento)
            .then(function (response) {
                console.log("N° REGISTROS INSERTAD0S:"+response.data);
                alert("Movimiento registrado!!");
                $scope.cerrarModalRegMod();
                $scope.loadMovimientos(parametros);
                $scope.btntext = "REGISTRAR";

            })
            .catch(function (error) {
                console.log($scope.movimiento);
                alert('No se pudo registrar el movimiento!!');
                console.error('Error al registrar el movimiento: ', error);
            });

        //funciona
        //$.ajax({
        //    type: "POST",
        //    url: "/Movimiento/InsertMovimiento",
        //    data: $scope.movimiento,
        //    success: function (response) {
        //        console.log(response.data + " " + $scope.movimiento);
        //        alert("Movimiento registrado!!");
        //        $scope.cerrarModalRegMod();
        //        $scope.loadMovimientos(parametros);
        //        $scope.btntext = "REGISTRAR";

        //        //$route.reload();
        //    //    $scope.refrescar();   
        //    },
        //    dataType: 'json'
        //}).catch(function (error) {
        //    alert('No se pudo registrar el movimiento!!');
        //    console.log($scope.movimiento);
        //    console.error('Error al registrar el movimiento: ', error);
        //});

    };


    /****************UPDATE MOVIMIENTOS**********************************/
    $scope.pushRegMod2 = function (mov) {
        $scope.btntext = "GUARDAR";
        $scope.movimiento = {
            COD_CIA: mov.COD_CIA,
            COMPANIA_VENTA_3: mov.COMPANIA_VENTA_3,
            ALMACEN_VENTA: mov.ALMACEN_VENTA,
            TIPO_MOVIMIENTO: mov.TIPO_MOVIMIENTO,
            TIPO_DOCUMENTO: mov.TIPO_DOCUMENTO,
            NRO_DOCUMENTO: mov.NRO_DOCUMENTO,
            COD_ITEM_2: mov.COD_ITEM_2
        };
        $("#tipDoc").attr("readonly", true);
        $("#nroDoc").attr("readonly", true);
        accion = "upd";
    };


    $scope.upd_movimiento = function () {

        // Ejemplo de PUT
        $http.put("/Movimiento/EditMovimiento", $scope.movimiento)
            .then(function (response) {
                console.log("N° REGISTROS ACTUALIZADOS:" + response.data);
                alert("Movimiento actualizado!!");
                $scope.cerrarModalRegMod();
                $scope.loadMovimientos(parametros);
                $scope.btntext = "GUARDAR";
            })
            .catch(function (error) {
                console.log($scope.movimiento);
                alert('No se pudo actualizar el movimiento!!');
                console.error('Error al actualizar el movimiento: ', error);
            });

        //        //funciona
        //        $.ajax({
        //            type: "PUT",
        //            url: "/Movimiento/EditMovimiento",
        //            data: $scope.movimiento,
        //            success: function (response) {
        //                alert("Movimiento actualizado!!");
        //                $scope.cerrarModalRegMod();
        //                $scope.loadMovimientos(parametros);
        //                $scope.btntext = "GUARDAR";
        //            },
        //            dataType: 'json'
        //        }).catch(function (error) {
        //            alert('No se pudo actualizar el movimiento!!');
        //            console.log($scope.movimiento);
        //            console.error('Error al actualizar el movimiento: ', error);
        //        });

    };


    /****************INS_UPD MOVIMIENTOS**********************************/
    $scope.cerrarModalRegMod = function () {
        $('#modalInsUpd').modal('hide');
    };


    $scope.insupd_MOVIMIENTO = function () {
        if (accion == "ins") {
            $scope.ins_movimiento();
        } else {
            $scope.upd_movimiento();
        }
    };

    ////////**************************** Mostrar todas las empresas*****************
    //$http.get("/Movimiento/getMovimientos").then(function (d) {
    //    $scope.empresas = d.data;
    //    $scope.numempresas = d.data.length;

    //}, function (error) {
    //    alert('Failed');
    //});



    //$scope.pushMovimientos = function (movimiento) {
    //    var idempresa = empresa.idempresa;
    //    $scope.nombreEmpresa = empresa.nombre;
    //    var url_data = "/Empresa/Get_Personalxempresa?id=" + idempresa;
    //    $scope.loadListTrabajadores(url_data);

    //};








    /////****************Obtener empresa*******************************///
    //$scope.loadempresa = function (empresa) {

    //    $http.get("/Empresa/Get_empresabyid?id=" + empresa.idempresa).then(function (d) {
    //        $scope.empresa = d.data[0];
    //    }, function (error) {
    //        alert('Failed');
    //    });

    //};





});
