﻿define("LocalizationUtilities", ["BPMSoft", "ext-base"],
	function(BPMSoft, Ext) {

		var lczTablesNames = [
			"SysModuleLcz",
			"SysModuleActionLcz",
			"SysModuleAnalyticsReportLcz",
			"SysModuleDetailLcz",
			"SysModuleEditLcz",
			"SysModuleEditDetailLcz",
			"SysModuleFolderLcz",
			"SysModuleGridViewLcz",
			"SysModulePrimaryGridLczOld",
			"SysModuleReportLcz",
			"MainParamLcz"
		];

		function warn(oldmethodName, newMethodname) {
			var obsoleteMessage = Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage,
				oldmethodName, newMethodname);
			window.console.warn(obsoleteMessage);
		}

		/**
		 * @obsolete
		 */
		function getLczEntitySchemaName(rootSchemaName) {
			var lczEntitySchemaName = rootSchemaName + "Lcz";
			if (lczTablesNames.indexOf(lczEntitySchemaName) > -1) {
				lczEntitySchemaName += "Old";
			}
			return lczEntitySchemaName;
		}

		/**
		 * Adds localizable column to entity schema query.
		 * @obsolete
		 * @param {Object} esq Entity schema query.
		 * @param {String} columnName Localizable column name.
		 * @param {Object} culture Current user culture.
		 * @param {String} [alias] Column alias.
		 * @return {Object} Entity schema column.
		 */
		function addLocalizableColumn(esq, columnName, culture, alias) {
			warn("LocalizationUtilities.addLocalizableColumn", "EntitySchemaQuery.addColumn");
			var column;
			var useMultilanguageData = !BPMSoft.Features.getIsEnabled("DoNotUseMultilanguageData");
			if (useMultilanguageData) {
				column = addColumn(esq, columnName, alias);
			} else {
				column = addOldLocalizableColumn(esq, columnName, culture, alias);
			}
			return column;
		}

		/**
		 * Adds localizable column to entity schema query.
		 * @private
		 * @param {Object} esq Entity schema query.
		 * @param {String} columnName Localizable column name.
		 * @param {String} [alias] Column alias.
		 * @return {Object} Entity schema column.
		 */
		function addColumn(esq, columnName, alias) {
			return esq.addColumn(columnName, alias || columnName);
		}

		/**
		 * Adds localizable column to entity schema query.
		 * @private
		 * @param {Object} query Entity schema query.
		 * @param {String} columnName Localizable column name.
		 * @param {Object} [culture] Current user culture.
		 * @param {String} [alias] Column alias.
		 * @return {Object} Entity schema column.
		 */
		function addOldLocalizableColumn(query, columnName, culture, alias) {
			var rootSchema = query.rootSchema;
			var lczEntitySchemaName = getLczEntitySchemaName(rootSchema.name);
			var entityColumn = rootSchema.columns[columnName];
			var subFilters = BPMSoft.createFilterGroup();
			subFilters.add("ColumnUIdFilter",
				BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"ColumnUId", entityColumn.uId));
			subFilters.add("CultureFilter",
				BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"SysCulture", culture ? culture.value || culture :
						BPMSoft.Resources.CultureSettings.currentCultureId));
			var queryColumn = Ext.create("BPMSoft.AggregationQueryColumn", {
				columnPath: "[" + lczEntitySchemaName + ":Record].Value",
				subFilters: subFilters
			});
			return query.addColumn(queryColumn, alias || columnName);
		}

		/**
		 * @obsolete
		 */
		function saveLocalizableValue(entityName, recordId, columnName, localizationValues, callback, scope) {
			warn("LocalizationUtilities.saveLocalizableValue", "BaseViewModel.saveEntity");
			var jsonData = {
				entityName: entityName,
				recordId: recordId,
				columnName: columnName
			};
			var serviceName = "SaveLocalizableValue";
			callService(serviceName, {
				configJSON: Ext.JSON.encode(jsonData),
				valuesJSON: Ext.JSON.encode(localizationValues)
			}, function(responseObject) {
				callback.call(scope, responseObject.SaveLocalizableValueResult);
			}, scope);
		}

		function callService(serviceName, jsonData, callback, scope) {
			var data = jsonData || {};
			scope = scope || this;
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/LocalizationUtilitiesService/" + serviceName;
			var request = BPMSoft.AjaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function(request, success, response) {
					var responseObject = {};
					if (success) {
						responseObject =  BPMSoft.decode(response.responseText);
					}
					callback.call(scope, responseObject);
				},
				scope: scope
			});
			return request;
		}
		return {
			addLocalizableColumn: addLocalizableColumn,
			saveLocalizableValue: saveLocalizableValue
		};
	});
