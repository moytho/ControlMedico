'use strict';

var controlMedicoControllers = angular.module('controlMedicoControllers', []);

//Consultas/Citas
controlMedicoControllers.controller('ConsultaEditarCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Consulta";
        var id = $routeParams.CodigoConsulta;
        $scope.consulta = { CodigoConsulta: 1,CodigoPaciente:"Ejemplo1", PrimerNombre: "Ejemplo 1", PrimerApellido: "Ejemplo1", FechaConsulta: "2014-10-20", HoraConsulta: "10:00:00", Estado: "Pendiente",Observaciones:"Prueba" };
        $scope.medicos=Medico.query({});
    }]);


controlMedicoControllers.controller('ConsultaNuevoCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Consulta";
        var id = $routeParams.CodigoConsulta;

    }]);

controlMedicoControllers.controller('ConsultaListaCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Consultas";
        $scope.consultas = [
                { CodigoConsulta: 1, PrimerNombre: "Ejemplo 1", PrimerApellido: "Ejemplo1", FechaConsulta: "20/10/2014", HoraConsulta: "10:00:00",Estado:"Pendiente" },
                { CodigoConsulta: 2, PrimerNombre: "Ejemplo 2", PrimerApellido: "Ejemplo2", FechaConsulta: "20/10/2014", HoraConsulta: "11:00:00",Estado:"Pendiente" },
                { CodigoConsulta: 3, PrimerNombre: "Ejemplo 3", PrimerApellido: "Ejemplo3", FechaConsulta: "20/10/2014", HoraConsulta: "12:00:00",Estado:"Pendiente" }
        ];

    }]);

//Prescripcion
controlMedicoControllers.controller('PrescripcionCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Prescripcion";
        var id = $routeParams.CodigoConsulta;

    }]);

//MedicoAgenda
controlMedicoControllers.controller('MedicoAgendaCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Agenda";
        var id = $routeParams.CodigoMedico;
        
    }]);

//Proveedor
controlMedicoControllers.controller('EditarProveedorCtrl', ['$scope', '$routeParams', '$location', 'Proveedor',
    function ($scope, $routeParams, $location, Proveedor) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.proveedor = Proveedor.get({ Id: id });

        $scope.save = function (proveedor) {
            Proveedor.update({ id: id }, proveedor, function () {
                $location.path('/proveedor');
            });
        };

    }]);


controlMedicoControllers.controller('CrearProveedorCtrl', ['$scope', '$routeParams', '$location', 'Proveedor',
    function ($scope, $routeParams, $location, Proveedor) {
        $scope.action = "Agregar";
        $scope.save = function (proveedor) {
            Proveedor.save(proveedor, function () {
                $location.path('/proveedor');
            });
        };
    }]);

controlMedicoControllers.controller('ListaProveedorCtrl', ['$scope', '$routeParams', 'Proveedor', '$location',
  function ($scope, $routeParams, Proveedor, $location) {

      $scope.titulo = "Proveedores";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.proveedores = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          Proveedor.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.proveedores = $scope.proveedores.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.proveedor.CodigoProveedor;
          Proveedor.delete({ id: id }, function () {
              $("#proveedor_" + id).fadeOut();
          }, function (error) {
              $location.path("/proveedor");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoProveedor";
      $scope.is_desc = false;


      $scope.reset();

  }]);

//Tipo Usuario
controlMedicoControllers.controller('EditarTipoUsuarioCtrl', ['$scope', '$routeParams', '$location', 'TipoUsuario',
    function ($scope, $routeParams, $location, TipoUsuario) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.tipousuario = TipoUsuario.get({ Id: id });

        $scope.save = function (tipousuario) {
            TipoUsuario.update({ id: id }, tipousuario, function () {
                $location.path('/tipousuario');
            });
        };

    }]);


controlMedicoControllers.controller('CrearTipoUsuarioCtrl', ['$scope', '$routeParams', '$location', 'TipoUsuario',
    function ($scope, $routeParams, $location, TipoUsuario) {
        $scope.action = "Agregar";
        $scope.save = function (tipousuario) {
            TipoUsuario.save(tipousuario, function () {
                $location.path('/tipousuario');
            });
        };
    }]);

controlMedicoControllers.controller('ListaTipoUsuarioCtrl', ['$scope', '$routeParams', 'TipoUsuario', '$location',
  function ($scope, $routeParams, TipoUsuario, $location) {

      $scope.titulo = "Tipo Usuarios";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.tipousuarios = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          TipoUsuario.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.tipousuarios = $scope.tipousuarios.concat(data);
          });
      };

      $scope.delete = function () {

          var id = this.tipousuario.CodigoTipoUsuario;
          console.log(id);
          TipoUsuario.delete({ id: id }, function () {
              $("#tipousuario_" + id).fadeOut();
          }, function (error) {
              $location.path("/tipousuario");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoTipoUsuario";
      $scope.is_desc = false;


      $scope.reset();

  }]);

//Medico
controlMedicoControllers.controller('EditarMedicoCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.medico = Medico.get({ Id: id });

        $scope.save = function (medico) {
            Medico.update({ id: id }, medico, function () {
                $location.path('/medico');
            });
        };

    }]);


controlMedicoControllers.controller('CrearMedicoCtrl', ['$scope', '$routeParams', '$location', 'Medico',
    function ($scope, $routeParams, $location, Medico) {
        $scope.action = "Agregar";
        $scope.save = function (medico) {
            Medico.save(medico, function () {
                $location.path('/medico');
            });
        };
    }]);

controlMedicoControllers.controller('ListaMedicoCtrl', ['$scope', '$routeParams', 'Medico', '$location',
  function ($scope, $routeParams,Medico, $location) {

      $scope.titulo = "Medicos";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.medicos = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          Medico.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.medicos = $scope.medicos.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.medico.CodigoMedico;
          Medico.delete({ id: id }, function () {
              $("#medico_" + id).fadeOut();
          }, function (error) {

              $location.path("/medico");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoMedico";
      $scope.is_desc = false;


      $scope.reset();

  }]);

//Paciente
controlMedicoControllers.controller('EditarPacienteCtrl', ['$scope', '$routeParams', '$location', 'Paciente','TipoSangre',
    function ($scope, $routeParams, $location, Paciente, TipoSangre) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;

        $scope.paciente = Paciente.get({ Id: id });

        $scope.generos = [];
        $scope.generos = [
                { CodigoGenero: 1, Descripcion: 'Masculino' },
                { CodigoGenero: 2, Descripcion: 'Femenino' }
        ];

        $scope.estadociviles = [];
        $scope.estadociviles = [
                { CodigoEstadoCivil: 1, Descripcion: 'Soltero' },
                { CodigoEstadoCivil: 2, Descripcion: 'Casado' }
        ];

        $scope.tiposangres = [];
        $scope.tiposangres = TipoSangre.query();

        $scope.save = function (paciente) {
            Paciente.update({ id: id }, paciente, function () {
                $location.path('/paciente');
            });
        };

    }]);


controlMedicoControllers.controller('CrearPacienteCtrl', ['$scope','$routeParams','$location', 'Paciente', 'TipoSangre',
    function ($scope, $routeParams, $location, Paciente, TipoSangre) {
        $scope.action = "Agregar";

        $scope.generos = [];
        $scope.generos = [
                { CodigoGenero: 1, Descripcion: 'Masculino'},
                { CodigoGenero: 2, Descripcion: 'Femenino'}
        ];

        $scope.estadociviles = [];
        $scope.estadociviles = [
                { CodigoEstadoCivil: 1, Descripcion: 'Soltero' },
                { CodigoEstadoCivil: 2, Descripcion: 'Casado' }
        ];

        $scope.tiposangres = [];
        $scope.tiposangres = TipoSangre.query();
        
        $scope.save = function (paciente) {
            Paciente.save(paciente, function () {
                $location.path('/paciente');
            });
        };

    }]);

controlMedicoControllers.controller('ListaPacienteCtrl', ['$scope', 'Paciente', '$location',
  function ($scope, Paciente, $location) {

      $scope.titulo = "Pacientes";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 20;
          $scope.offset = 0;
          $scope.pacientes = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          Paciente.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 20;
              $scope.pacientes = $scope.pacientes.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.paciente.CodigoPaciente;
          Paciente.delete({ id: id }, function () {
              $("#paciente_" + id).fadeOut();
          }, function (error) {

              $location.path("/paciente");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoPaciente";
      $scope.is_desc = false;


      $scope.reset();

  }]);


//Medicamento
controlMedicoControllers.controller('EditarMedicamentoCtrl', ['$scope', '$routeParams', '$location', 'Medicamento', 'MedicamentoPresentacion',
    function ($scope, $routeParams, $location, Medicamento, MedicamentoPresentacion) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;

        $scope.medicamento = Medicamento.get({ Id: id });

        $scope.medicamentopresentaciones = [];
        $scope.medicamentopresentaciones = MedicamentoPresentacion.query();

        //$scope.medicamento.MedicamentoPresentacion = 1;

        $scope.save = function (medicamento) {
            Medicamento.update({ id: id }, medicamento, function () {
                $location.path('/medicamento');
            });
        };

        }]);


controlMedicoControllers.controller('CrearMedicamentoCtrl', ['$scope', '$location', 'Medicamento', 'MedicamentoPresentacion',
    function ($scope, $location, Medicamento, MedicamentoPresentacion) {
        $scope.action = "Agregar";

        $scope.medicamentopresentaciones = [];
        $scope.medicamentopresentaciones = MedicamentoPresentacion.query();

        //$scope.presentacionmedicamentos = medicamentopresentaciones [0];
        $scope.save = function (medicamento) {
            Medicamento.save(medicamento, function () {
                $location.path('/medicamento');
            });
        };

    }]);

controlMedicoControllers.controller('ListaMedicamentoCtrl', ['$scope', 'Medicamento', '$location',
  function ($scope, Medicamento, $location) {

      $scope.titulo = "Medicamentos";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.medicamentos = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          Medicamento.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.medicamentos = $scope.medicamentos.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.medicamento.CodigoMedicamento;
          Medicamento.delete({ id: id }, function () {
              $("#medicamento_" + id).fadeOut();
          }, function (error) {

              $location.path("/medicamento");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoMedicamento";
      $scope.is_desc = false;


      $scope.reset();

  }]);


//MedicamentoPresentacion
controlMedicoControllers.controller('EditarMedicamentoPresentacionCtrl', ['$scope', '$routeParams', '$location', 'MedicamentoPresentacion',
    function ($scope, $routeParams, $location, MedicamentoPresentacion) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.medicamentopresentacion = MedicamentoPresentacion.get({ Id: id });

        $scope.save = function (medicamentopresentacion) {
            MedicamentoPresentacion.update({ id: id }, medicamentopresentacion, function () {
                $location.path('/medicamentopresentacion');
            });
        };

    }]);


controlMedicoControllers.controller('CrearMedicamentoPresentacionCtrl', ['$scope', '$location', 'MedicamentoPresentacion',
    function ($scope, $location, MedicamentoPresentacion) {
        $scope.action = "Agregar";
        $scope.save = function (medicamentopresentacion) {
            MedicamentoPresentacion.save(medicamentopresentacion, function () {
                $location.path('/medicamentopresentacion');
            });
        };
    }]);

controlMedicoControllers.controller('ListaMedicamentoPresentacionCtrl', ['$scope', 'MedicamentoPresentacion', '$location',
  function ($scope, MedicamentoPresentacion, $location) {

      $scope.titulo = "Presentacion del Medicamento";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.medicamentopresentacions = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          MedicamentoPresentacion.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.medicamentopresentacions = $scope.medicamentopresentacions.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.medicamentopresentacion.CodigoMedicoPresentacion;
          MedicamentoPresentacion.delete({ id: id }, function () {
              $("#medicamentopresentacion_" + id).fadeOut();
          }, function (error) {

              $location.path("/medicamentopresentacion");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoMedicoPresentacion";
      $scope.is_desc = false;


      $scope.reset();

  }]);


//Sintomas
controlMedicoControllers.controller('EditarSintomaCtrl', ['$scope', '$routeParams', '$location', 'Sintoma',
    function ($scope, $routeParams, $location, Sintoma) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.sintoma = Sintoma.get({ Id: id });

        $scope.save = function (sintoma) {
            Sintoma.update({ id: id }, sintoma, function () {
                $location.path('/sintoma');
            });
        };

    }]);


controlMedicoControllers.controller('CrearSintomaCtrl', ['$scope', '$location', 'Sintoma',
    function ($scope, $location, Sintoma) {
        $scope.action = "Agregar";
        $scope.save = function (sintoma) {
            Sintoma.save(sintoma, function () {
                $location.path('/sintoma');
            });
        };
    }]);

controlMedicoControllers.controller('ListaSintomaCtrl', ['$scope', 'Sintoma', '$location',
  function ($scope, Sintoma, $location) {

      $scope.titulo = "Sintomas";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 20;
          $scope.offset = 0;
          $scope.sintomas = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          Sintoma.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 20;
              $scope.sintomas = $scope.sintomas.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.sintoma.CodigoSintoma;
          Sintoma.delete({ id: id }, function () {
              $("#sintoma_" + id).fadeOut();
          }, function (error) {

              $location.path("/sintoma");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoSintoma";
      $scope.is_desc = false;


      $scope.reset();

  }]);

//Dosis
controlMedicoControllers.controller('EditarUnidadTiempoCtrl', ['$scope', '$routeParams', '$location', 'UnidadTiempo',
    function ($scope, $routeParams, $location, UnidadTiempo) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.unidadtiempo = UnidadTiempo.get({ Id: id });

        $scope.save = function (unidadtiempo) {
            UnidadTiempo.update({ id: id }, unidadtiempo, function () {
                $location.path('/unidadtiempo');
            });
        };

    }]);


controlMedicoControllers.controller('CrearUnidadTiempoCtrl', ['$scope', '$location', 'UnidadTiempo',
    function ($scope, $location, UnidadTiempo) {
        $scope.action = "Agregar";
        $scope.save = function (unidadtiempo) {
            UnidadTiempo.save(unidadtiempo, function () {
                $location.path('/unidadtiempo');
            });
        };
    }]);

controlMedicoControllers.controller('ListaUnidadTiempoCtrl', ['$scope', 'UnidadTiempo', '$location',
  function ($scope, UnidadTiempo, $location) {

      $scope.titulo = "Unidad Tiempo/Dosis";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.unidadtiempos = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          UnidadTiempo.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.unidadtiempos = $scope.unidadtiempos.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.unidadtiempo.CodigoUnidadTiempo;
          UnidadTiempo.delete({ id: id }, function () {
              $("#unidadtiempo_" + id).fadeOut();
          }, function (error) {

              $location.path("/unidadtiempo");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoUnidadTiempo";
      $scope.is_desc = false;


      $scope.reset();

  }]);


//Dosificacion
controlMedicoControllers.controller('EditarUnidadMedidaCtrl', ['$scope', '$routeParams', '$location', 'UnidadMedida',
    function ($scope, $routeParams, $location, UnidadMedida) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.unidadmedida = UnidadMedida.get({ Id: id });

        $scope.save = function (unidadmedida) {
            UnidadMedida.update({ id: id }, unidadmedida, function () {
                $location.path('/unidadmedida');
            });
        };

    }]);


controlMedicoControllers.controller('CrearUnidadMedidaCtrl', ['$scope', '$location', 'UnidadMedida',
    function ($scope, $location, UnidadMedida) {
        $scope.action = "Agregar";
        $scope.save = function (unidadmedida) {
            UnidadMedida.save(unidadmedida, function () {
                $location.path('/unidadmedida');
            });
        };
    }]);

controlMedicoControllers.controller('ListaUnidadMedidaCtrl', ['$scope', 'UnidadMedida', '$location',
  function ($scope, UnidadMedida, $location) {

      $scope.titulo = "Unidad Medida/Dosificacion";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.unidadmedidas = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          UnidadMedida.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.unidadmedidas = $scope.unidadmedidas.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.unidadmedida.CodigoUnidadMedida;
          UnidadMedida.delete({ id: id }, function () {
              $("#unidadmedida_" + id).fadeOut();
          }, function (error) {

              $location.path("/unidadmedida");
          });

      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoUnidadMedida";
      $scope.is_desc = false;


      $scope.reset();

  }]);


// Tipo de Sangre
controlMedicoControllers.controller('EditarTipoSangreCtrl', ['$scope', '$routeParams', '$location', 'TipoSangre',
    function ($scope, $routeParams, $location, TipoSangre) {
        $scope.action = "Actualizar";
        var id = $routeParams.editarId;
        $scope.tiposangre = TipoSangre.get({ Id: id });

        $scope.save = function (tiposangre) {
            TipoSangre.update({ id: id }, tiposangre, function () {
                $location.path('/tiposangre');
            });
        };

    }]);


controlMedicoControllers.controller('CrearTipoSangreCtrl', ['$scope', '$location', 'TipoSangre',
    function ($scope, $location, TipoSangre) {
        $scope.action = "Agregar";
        $scope.save = function (tiposangre) {
            TipoSangre.save(tiposangre, function () {
                $location.path('/tiposangre');
            });
        };
    }]);

controlMedicoControllers.controller('ListaTipoSangreCtrl', ['$scope', 'TipoSangre', '$location',
  function ($scope, TipoSangre, $location) {

      $scope.titulo = "Tipo Sangre";

      $scope.reset = function () {
          //debugger; 
          $scope.limit = 10;
          $scope.offset = 0;
          $scope.tiposangres = [];
          $scope.more = true;
          $scope.search();
      };

      $scope.search = function () {
          TipoSangre.query({ q: $scope.query, sort: $scope.sort_order, desc: $scope.is_desc, offset: $scope.offset, limit: $scope.limit }, function (data) {
              $scope.more = data.length === 10;
              $scope.tiposangres = $scope.tiposangres.concat(data);
          });
      };

      $scope.delete = function () {
          var id = this.tiposangre.CodigoTipoSangre;
          TipoSangre.delete({ id: id }, function () {
              $("#tiposangre_" + id).fadeOut();
          }, function (error) {
              
              $location.path("/tiposangre");
          });
          
      };

      $scope.has_more = function () {
          return $scope.more;
      }

      $scope.show_more = function () {
          $scope.offset += $scope.limit;
          $scope.search();
      };

      $scope.sort = function (col) {
          if ($scope.sort_order === col) {
              $scope.is_desc = !$scope.is_desc;
          } else {
              $scope.sort_order = col;
              $scope.is_desc = false;
          }
          $scope.reset();
      }

      $scope.sort_order = "CodigoTipoSangre";
      $scope.is_desc = false;


      $scope.reset();

  }]);

