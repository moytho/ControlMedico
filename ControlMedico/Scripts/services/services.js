'use strict';

var controlMedicoServices = angular.module('controlMedicoServices', ['ngResource']);

controlMedicoServices.factory('Paciente', ['$resource',
  function ($resource) {
      return $resource('/api/Paciente/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('TipoSangre', ['$resource',
  function ($resource) {
      return $resource('/api/TipoSangre/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('EstadoCivil', ['$resource',
  function ($resource) {
      return $resource('/api/EstadoCivil/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('Genero', ['$resource',
  function ($resource) {
      return $resource('/api/Genero/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('UnidadMedida', ['$resource',
  function ($resource) {
      return $resource('/api/UnidadMedida/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('UnidadTiempo', ['$resource',
  function ($resource) {
      return $resource('/api/UnidadTiempo/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('Sintoma', ['$resource',
  function ($resource) {
      return $resource('/api/Sintoma/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('MedicamentoPresentacion', ['$resource',
  function ($resource) {
      return $resource('/api/MedicamentoPresentacion/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('Medicamento', ['$resource',
  function ($resource) {
      return $resource('/api/Medicamento/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('Medico', ['$resource',
  function ($resource) {
      return $resource('/api/Medico/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('Proveedor', ['$resource',
  function ($resource) {
      return $resource('/api/Proveedor/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);

controlMedicoServices.factory('TipoUsuario', ['$resource',
  function ($resource) {
      return $resource('/api/TipoUsuario/:id', { id: '@id' }, { update: { method: 'PUT' } });
  }]);



