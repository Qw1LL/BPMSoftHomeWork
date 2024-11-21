define("PackageHelper", ["ext-base", "BPMSoft"],
	function(Ext, BPMSoft) {

		//region Methods: Protected

		function setAvailablePackageFilters(esq) {
			const currentWorkspace = BPMSoft.SysValue.CURRENT_WORKSPACE.value;
			const currentMaintainer = BPMSoft.SysValue.CURRENT_MAINTAINER.value;
			esq.filters.add("SysWorkspace",
				BPMSoft.createColumnFilterWithParameter("SysWorkspace", currentWorkspace));
			esq.filters.add("Maintainer",
				BPMSoft.createColumnFilterWithParameter("Maintainer", currentMaintainer));
			esq.filters.add("InstallType",
				BPMSoft.createColumnFilterWithParameter("InstallType", 0));
		}

		//region  

		//region Methods: Public

		/**
		 * Checks for installed package
		 * @param {String} packageUId Unique identifier for the package.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope context
		 * @return {Boolean} The result of checking for the presence of an installed package
		 */
		function getIsPackageInstalled(packageUId, callback, scope) {
			scope = scope || this;
			const select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysPackage"
			});
			const columnAlias = "RecordsCount";
			select.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, columnAlias);
			select.filters.add("packageUId", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "UId", packageUId));
			select.getEntityCollection(function(response) {
				var isInstalled = false;
				if (response.success) {
					const resultItem = response.collection.getByIndex(0);
					const resultItemValue = parseInt(resultItem.get(columnAlias));
					isInstalled = resultItemValue > 0;
				}
				callback.call(scope, isInstalled);
			});
		}

		/**
		 * Get available packages in current workspace
		 * @param {Function} callback CallBack function
		 * @param {Object} scope current context
		 * @return {Collection} Collection of available packages
		 */
		function getAvailablePackages(callback, scope) {
			scope = scope || this;

			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysPackage"
			});
			esq.addColumn("UId");
			esq.addColumn("Id");
			esq.addColumn("Name");
			setAvailablePackageFilters(esq);
			esq.getEntityCollection(function(response) {
				callback.call(this, response.collection);
			}, scope);
		}

		//endregion

		return {
			getIsPackageInstalled: getIsPackageInstalled,
			getAvailablePackages: getAvailablePackages
		};
	}
);
