define("EntityStructureHelper", ["ext-base", "BPMSoft", "ConfigurationEnums", "EntityStructureHelperResources"],
	function(Ext, BPMSoft, ConfigurationEnums, resources) {
		var sandbox = {};
		var summaryColumnsOnly = false;
		var useBackwards = true;
		var displayId = false;
		var lookupsColumnsOnly = false;
		var dataValueType = null;
		var aggregationType;
		var UseExists;
		var UseCount = true;
		var localEntitySchema;
		var localEntitySchemaLoaded = false;
		var columnsFiltrationMethod;
		var excludeDataValueTypes = [];
		var allowedReferenceSchemas = [];
		var allowedColumnAccessList;
		var aggregatedDataValueTypes;
		var defaultAggregatedDataValueTypes = [
			BPMSoft.DataValueType.DATE_TIME,
			BPMSoft.DataValueType.DATE,
			BPMSoft.DataValueType.TIME,
			BPMSoft.DataValueType.INTEGER,
			BPMSoft.DataValueType.FLOAT,
			BPMSoft.DataValueType.MONEY
		];

		function init(params) {
			sandbox = params.sa;
			summaryColumnsOnly = params.summaryColumnsOnly;
			useBackwards = params.useBackwards;
			displayId = params.displayId || false;
			lookupsColumnsOnly = params.lookupsColumnsOnly || false;
			dataValueType = params.dataValueType || null;
			aggregationType = params.aggregationType || null;
			UseExists = params.useExists || false;
			UseCount = (params.useCount !== false);
			columnsFiltrationMethod = params.columnsFiltrationMethod;
			aggregatedDataValueTypes = params.aggregatedDataValueTypes || defaultAggregatedDataValueTypes;
			allowedReferenceSchemas = params.allowedReferenceSchemas || [];
			excludeDataValueTypes = params.excludeDataValueTypes || [];
			if (params.enableBlobDataValueType !== true) {
				excludeDataValueTypes.push(BPMSoft.DataValueType.BLOB);
			}
			localEntitySchemaLoaded = false;
			allowedColumnAccessList = params.allowedColumns;
		}

		function getEntitySchemaDescriptor(entityName, callback) {
			if (!localEntitySchemaLoaded) {
				localEntitySchema = sandbox.publish("GetEntitySchema", entityName);
				localEntitySchemaLoaded = true;
			}
			if (localEntitySchema && localEntitySchema.name === entityName) {
				callback.call(this, localEntitySchema);
			} else {
				sandbox.requireModuleDescriptors([entityName], callback, this);
			}
		}

		function getEntitySchema(entityName, callback) {
			if (localEntitySchema && localEntitySchema.name === entityName) {
				callback.call(this, localEntitySchema);
			} else {
				require([entityName], callback);
			}
		}

		function getEntityDescriptorsForLookupColumns(entity, callback) {
			var entityNames = [];
			BPMSoft.each(entity.columns, function(column) {
				if (column.isLookup) {
					var schemaName = column.referenceSchemaName;
					if (schemaName && !arrayHasItem(entityNames, schemaName)) {
						entityNames[entityNames.length] = schemaName;
					}
				}
			}, this);
			sandbox.requireModuleDescriptors(entityNames, callback, this);
		}

		function getLookupColumns(identifier, callback, scope) {
			var schemaName = identifier.referenceSchemaName;
			getEntitySchemaDescriptor(schemaName, function() {
				getEntitySchema(schemaName, function(schema) {
					getEntityDescriptorsForLookupColumns(schema, BPMSoft.emptyFn);
					var columns = {};
					BPMSoft.each(schema.columns, function(column) {
						if (column.isLookup &&
							column.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None) {
							columns[column.uId] = createChild(column);
						}
					}, this);
					if (useBackwards) {
						getBackwardColumns(schemaName, function(result) {
							result.collection.each(function(column) {
								var columnFakeId = BPMSoft.utils.generateGUID();
								column.values.UId = columnFakeId;
								columns[columnFakeId] = createBackwardChild(column.values);
							}, this);
							callback.call(scope, columns);
						});
					} else {
						callback.call(scope, columns);
					}
				});
			});
		}

		/**
		 * Adds schema name filters to query.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 */
		function initSysSchemaNameEsqFilter(esq) {
			var excludedSystemObjects = [
				"SysAdminUnit",
				"SysUserInRole",
				"SysLic",
				"SysLicPackage",
				"SysLicUser",
				"SysLicType",
				"SysUserSession"
			];
			var sysSchemaNameFilter = BPMSoft.createFilterGroup();
			sysSchemaNameFilter.name = "SysSchemaNameFilter";
			sysSchemaNameFilter.logicalOperation = BPMSoft.LogicalOperatorType.OR;
			var systemObjectNameFilter = BPMSoft.createFilterGroup();
			systemObjectNameFilter.add("VwSysFilter",
				esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_START_WITH,
					"SysSchema.Name", "VwSys"));
			systemObjectNameFilter.add("SysFilter",
				esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.NOT_START_WITH,
					"SysSchema.Name", "Sys"));
			sysSchemaNameFilter.add(systemObjectNameFilter);
			BPMSoft.each(excludedSystemObjects, function(systemObject) {
				sysSchemaNameFilter.add(Ext.String.format("{0}Filter", systemObject),
					esq.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL,
						"SysSchema.Name", systemObject));
			});
			esq.filters.add(sysSchemaNameFilter);
		}

		/**
		 * Adds filters to query.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {String} identifier Reference schema identifier.
		 */
		function initBackwardColumnsEsqFilters(esq, identifier) {
			esq.filters.add("SchemaFilter",
				esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "[SysSchema:Id:ReferenceSchema].Name", identifier));
			esq.filters.add("PackageFilter",
				esq.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"SysSchema.SysPackage.SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value));
			initSysSchemaNameEsqFilter(esq);
			esq.filters.add("UsageTypeFilter",
				esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "UsageType", 0));
		}

		/**
		 * Queries backward columns information.
		 * @param {String} identifier Reference schema identifier.
		 * @param {Function} callback Callback.
		 */
		function getBackwardColumns(identifier, callback) {
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysEntitySchemaReference",
				rowCount: -1,
				isDistinct: true
			});
			esq.addColumn("ColumnCaption", "ColumnCaption");
			esq.addColumn("ColumnName", "ColumnName");
			esq.addColumn("SysSchema.Name", "Name");
			esq.addColumn("SysSchema.Caption", "Caption");
			initBackwardColumnsEsqFilters(esq, identifier);
			esq.getEntityCollection(callback, this);
		}

		function isAggregateTypeColumn(column, columnAggregationType) {
			return isAggregateFunctionCanBeUsedToType(column.dataValueType, columnAggregationType);
		}

		function isAggregateFunctionCanBeUsedToType(columnDataValueType, columnAggregationType) {
			if (columnDataValueType === BPMSoft.DataValueType.BLOB) {
				return false;
			}
			switch (columnAggregationType) {
				case BPMSoft.AggregationType.COUNT:
					return true;
				case BPMSoft.AggregationType.MAX:
				case BPMSoft.AggregationType.MIN:
					return isDateTime(columnDataValueType) || isNumeric(columnDataValueType);
				case BPMSoft.AggregationType.AVG:
				case BPMSoft.AggregationType.SUM:
					return isNumeric(columnDataValueType);
				default:
					return false;
			}
		}

		function isDateTime(columnDataValueType) {
			return columnDataValueType === BPMSoft.DataValueType.DATE_TIME ||
				columnDataValueType === BPMSoft.DataValueType.DATE ||
				columnDataValueType === BPMSoft.DataValueType.TIME;
		}

		function isNumeric(columnDataValueType) {
			return columnDataValueType === BPMSoft.DataValueType.INTEGER ||
				columnDataValueType === BPMSoft.DataValueType.FLOAT ||
				columnDataValueType === BPMSoft.DataValueType.MONEY;
		}

		function isAggregateColumn(column) {
			return Ext.Array.contains(aggregatedDataValueTypes, column.dataValueType);
		}

		function  isReferenceSchemasAllowed(referenceSchemas, entitySchemaName) {
			return (Ext.isEmpty(referenceSchemas) || Ext.Array.contains(referenceSchemas, entitySchemaName));
		}

		/**
		 * Filter for entity schema columns.
		 * @private
		 * @param {Object} column Column item.
		 * @param {Object} config Filtration config.
		 * @return {Boolean}
		 */
		function _entitySchemaColumnFiltration(column, config) {
			var primaryColumnName = config.schema.primaryColumnName;
			var schemaName = config.schema.name;
			var columnDataValueType = column.dataValueType;
			if (column.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.None) {
				return false;
			}
			if (BPMSoft.contains(excludeDataValueTypes, columnDataValueType)) {
				return false;
			}
			if (column.name === primaryColumnName && !config.hasBackwardElements) {
				return displayId && isReferenceSchemasAllowed(allowedReferenceSchemas, schemaName);
			}
			if (!Ext.isEmpty(aggregationType)) {
				return isAggregateTypeColumn(column, aggregationType);
			}
			if (lookupsColumnsOnly) {
				return !!column.isLookup &&
					isReferenceSchemasAllowed(allowedReferenceSchemas, column.referenceSchemaName);
			}
			if ((config.hasBackwardElements || summaryColumnsOnly) && !isAggregateColumn(column)) {
				return false;
			}
			if (!Ext.isEmpty(dataValueType) && (dataValueType !== columnDataValueType)) {
				return false;
			}
			if (allowedColumnAccessList) {
				var isContainColumnInAllowedColumn = !Ext.isEmpty(
					BPMSoft.findWhere(allowedColumnAccessList, {uId: column.uId}));
				if (!isContainColumnInAllowedColumn) {
					return false;
				}
			}
			return true;
		}

		function getItemsColumns(identifier, callback, hasBackwardElements, scope) {
			var schemaName = identifier && identifier.referenceSchemaName;
			if (!schemaName) {
				callback.call(scope, {});
				return;
			}
			getEntitySchemaDescriptor(schemaName, function() {
				getEntitySchema(schemaName, function(schema) {
					var columns = {};
					var filterFn = _entitySchemaColumnFiltration;
					if (Ext.isFunction(columnsFiltrationMethod)) {
						filterFn = columnsFiltrationMethod;
					}
					var filtrationConfig = {
						hasBackwardElements: hasBackwardElements,
						schema: schema
					};
					BPMSoft.each(schema.columns, function(column) {
						if (filterFn(column, filtrationConfig) !== false) {
							columns[column.uId] = createItem(column);
						}
					}, this);
					if (hasBackwardElements) {
						if (UseCount) {
							columns.functionCount = createCountColumn();
						}
						if (UseExists) {
							columns.functionExists = createExistsColumn();
						}
					}
					callback.call(scope, columns);
				});
			});
		}

		function getSchemaCaption(identifier, callback, scope) {
			var schemaName = identifier.referenceSchemaName;
			getEntitySchemaDescriptor(schemaName, function() {
				getEntitySchema(schemaName, function(schema) {
					callback.call(scope, schema.caption);
				});
			});
		}

		/**
		 * Returns item config.
		 * @private
		 * @param {Object} column Column item.
		 * @return {Object}
		 */
		function createItem(column) {
			return {
				value: column.uId,
				displayValue: column.caption,
				columnName: column.name,
				markerValue: column.caption + " " + column.name,
				order: 2,
				dataValueType: column.dataValueType,
				isLookup: column.isLookup || false,
				referenceSchemaName: column.isLookup ? column.referenceSchemaName : ""
			};
		}

		function createChild(column) {
			return {
				value: column.uId,
				displayValue: column.caption,
				columnName: column.name,
				referenceSchemaName: column.referenceSchemaName,
				isBackward: false,
				order: 2
			};
		}

		function createCountColumn() {
			return {
				value: "count",
				displayValue: resources.localizableStrings.CountItemCaption,
				columnName: "count",
				dataValueType: BPMSoft.DataValueType.INTEGER,
				order: 1,
				isAggregative: true,
				aggregationFunction: ConfigurationEnums.AggregationFunction.COUNT
			};
		}

		function createExistsColumn() {
			return {
				value: "exists",
				displayValue: resources.localizableStrings.ExistsItemCaption,
				columnName: "exists",
				order: 0,
				isAggregative: true,
				aggregationFunction: ConfigurationEnums.AggregationFunction.EXISTS
			};
		}

		function createBackwardChild(column) {
			return {
				value: column.UId,
				displayValue: resources.localizableStrings.BackwardCaptionTemplate
					.replace("#EntityName#", column.Caption)
					.replace("#ColumnName#", column.ColumnCaption),
				columnName: "[" + column.Name + ":" + column.ColumnName + "]",
				referenceSchemaName: column.Name,
				isBackward: true,
				order: 2
			};
		}

		function arrayHasItem(array, item) {
			return array.indexOf(item) >= 0;
		}

		function getColumnPathCaption(dataSend, callback, scope) {
			var ajaxProvider = BPMSoft.AjaxProvider;
			var data = {configJSON: dataSend};
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/StructureExplorerService/GetColumnPathCaption";
			ajaxProvider.request({
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
						responseObject = BPMSoft.decode(response.responseText);
					}
					callback.call(scope || this, responseObject);
				},
				scope: this
			});
		}

		function hasAggregationColumns(schemaName, columnAggregationType, callback, scope) {
			var ajaxProvider = BPMSoft.AjaxProvider;
			var data = {
					schemaName: schemaName,
					aggregationType: columnAggregationType
				};
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/StructureExplorerService/HasAggregationColumns";
			var hasAggregationColumnsRequest = ajaxProvider.request({
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
						responseObject = BPMSoft.decode(response.responseText).HasAggregationColumnsResult;
					}
					callback.call(scope || this, responseObject);
				},
				scope: scope
			});
			return hasAggregationColumnsRequest;
		}

		return {
			init: init,
			getItems: getItemsColumns,
			getChildren: getLookupColumns,
			getItemCaption: getSchemaCaption,
			getBackwardColumns: getBackwardColumns,
			hasAggregationColumns: hasAggregationColumns,
			getColumnPathCaption: getColumnPathCaption,
			isAggregateFunctionCanBeUsedToType: isAggregateFunctionCanBeUsedToType
		};
	});
