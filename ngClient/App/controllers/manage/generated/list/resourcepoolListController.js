//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

(function () {
    'use strict';

    var controllerId = 'ResourcePoolListController';
    angular.module('main')
        .controller(controllerId, ['resourcePoolFactory',
            'logger',
			ResourcePoolListController]);

    function ResourcePoolListController(resourcePoolFactory,
        logger) {
        logger = logger.forSource(controllerId);

        var vm = this;
        vm.deleteResourcePool = deleteResourcePool;
        vm.resourcePoolSet = [];

        initialize();

        function initialize() {
            getResourcePoolSet();
        }

        function deleteResourcePool(resourcePool) {
            resourcePoolFactory.deleteResourcePool(resourcePool);

            resourcePoolFactory.saveChanges()
                .then(function () {
                    vm.resourcePoolSet.splice(vm.resourcePoolSet.indexOf(resourcePool), 1);
                    logger.logSuccess("Hooray we saved", null, true);
                })
                .catch(function (error) {
                    logger.logError("Boooo, we failed: " + error.message, null, true);
                    // Todo: more sophisticated recovery. 
                    // Here we just blew it all away and start over
                    // refresh();
                });
        }

        function getResourcePoolSet() {
            resourcePoolFactory.getResourcePoolSet(false)
			    .then(function (data) {
                    vm.resourcePoolSet = data;
                });
        }
    }
})();