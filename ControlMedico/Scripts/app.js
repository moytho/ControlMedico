'use strict';

var controlMedico = angular.module('controlMedico', ['ngRoute', 'controlMedicoControllers', 'controlMedicoServices']);

controlMedico.config(['$routeProvider',
function ($routeProvider) {
    $routeProvider.
    when('/paciente', { templateUrl: 'partials/paciente-lista.html', controller: 'ListaPacienteCtrl' }).
    when('/paciente/nuevo', {templateUrl: 'partials/paciente-detalle.html',controller: 'CrearPacienteCtrl'}).
    when('/paciente/editar/:editarId', { templateUrl: 'partials/paciente-detalle.html', controller: 'EditarPacienteCtrl' }).
    when('/tiposangre', { templateUrl: 'partials/tiposangre-lista.html', controller: 'ListaTipoSangreCtrl' }).
    when('/tiposangre/nuevo', { templateUrl: 'partials/tiposangre-detalle.html', controller: 'CrearTipoSangreCtrl' }).
    when('/tiposangre/editar/:editarId', { templateUrl: 'partials/tiposangre-detalle.html', controller: 'EditarTipoSangreCtrl' }).
    when('/unidadtiempo', { templateUrl: 'partials/dosis-lista.html', controller: 'ListaUnidadTiempoCtrl' }).
    when('/unidadtiempo/nuevo', { templateUrl: 'partials/dosis-detalle.html', controller: 'CrearUnidadTiempoCtrl' }).
    when('/unidadtiempo/editar/:editarId', { templateUrl: 'partials/dosis-detalle.html', controller: 'EditarUnidadTiempoCtrl' }).
    when('/unidadmedida', { templateUrl: 'partials/dosificacion-lista.html', controller: 'ListaUnidadMedidaCtrl' }).
    when('/unidadmedida/nuevo', { templateUrl: 'partials/dosificacion-detalle.html', controller: 'CrearUnidadMedidaCtrl' }).
    when('/unidadmedida/editar/:editarId', { templateUrl: 'partials/dosificacion-detalle.html', controller: 'EditarUnidadMedidaCtrl' }).
    when('/sintoma', { templateUrl: 'partials/sintoma-lista.html', controller: 'ListaSintomaCtrl' }).
    when('/sintoma/nuevo', { templateUrl: 'partials/sintoma-detalle.html', controller: 'CrearSintomaCtrl' }).
    when('/sintoma/editar/:editarId', { templateUrl: 'partials/sintoma-detalle.html', controller: 'EditarSintomaCtrl' }).
    when('/medicamentopresentacion', { templateUrl: 'partials/medicamentopresentacion-lista.html', controller: 'ListaMedicamentoPresentacionCtrl' }).
    when('/medicamentopresentacion/nuevo', { templateUrl: 'partials/medicamentopresentacion-detalle.html', controller: 'CrearMedicamentoPresentacionCtrl' }).
    when('/medicamentopresentacion/editar/:editarId', { templateUrl: 'partials/medicamentopresentacion-detalle.html', controller: 'EditarMedicamentoPresentacionCtrl' }).
    when('/medicamento', { templateUrl: 'partials/medicamento-lista.html', controller: 'ListaMedicamentoCtrl' }).
    when('/medicamento/nuevo', { templateUrl: 'partials/medicamento-detalle.html', controller: 'CrearMedicamentoCtrl' }).
    when('/medicamento/editar/:editarId', { templateUrl: 'partials/medicamento-detalle.html', controller: 'EditarMedicamentoCtrl' }).
    when('/medico', { templateUrl: 'partials/medico-lista.html', controller: 'ListaMedicoCtrl' }).
    when('/medico/nuevo', { templateUrl: 'partials/medico-detalle.html', controller: 'CrearMedicoCtrl' }).
    when('/medico/editar/:editarId', { templateUrl: 'partials/medico-detalle.html', controller: 'EditarMedicoCtrl' }).
    when('/consulta', { templateUrl: 'partials/consulta-lista.html', controller: 'ConsultaListaCtrl' }).
    when('/consulta/nuevo', { templateUrl: 'partials/consulta-detalle.html', controller: 'ConsultaCrearCtrl' }).
    when('/consulta/editar/:editarId', { templateUrl: 'partials/consulta-detalle.html', controller: 'ConsultaEditarCtrl' }).
    when('/medico/agenda/:CodigoMedico', { templateUrl: 'partials/medicoagenda.html', controller: 'MedicoAgendaCtrl' }).
    when('/proveedor', { templateUrl: 'partials/proveedor-lista.html', controller: 'ListaProveedorCtrl' }).
    when('/proveedor/nuevo', { templateUrl: 'partials/proveedor-detalle.html', controller: 'CrearProveedorCtrl' }).
    when('/proveedor/editar/:editarId', { templateUrl: 'partials/proveedor-detalle.html', controller: 'EditarProveedorCtrl' }).
    when('/tipousuario', { templateUrl: 'partials/tipousuario-lista.html', controller: 'ListaTipoUsuarioCtrl' }).
    when('/tipousuario/nuevo', { templateUrl: 'partials/tipousuario-detalle.html', controller: 'CrearTipoUsuarioCtrl' }).
    when('/tipousuario/editar/:editarId', { templateUrl: 'partials/tipousuario-detalle.html', controller: 'EditarTipoUsuarioCtrl' }).
        when('/prescripcion/:CodigoConsulta', { templateUrl: 'partials/prescripcion.html', controller: 'PrescripcionCtrl' }).
    otherwise({
        redirectTo: '/paciente'
    });
}]);