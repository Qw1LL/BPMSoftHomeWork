﻿define("EntitySchemaSelectMixin", ["ProcessLookupModule", "ProcessLookupPageMixin"], function() {
	/**
	 * @class BPMSoft.configuration.mixins.EntitySchemaSelectMixin
	 * Implements work with schema columns.
	 */
	Ext.define("BPMSoft.configuration.mixins.EntitySchemaSelectMixin", {
		alternateClassName: "BPMSoft.EntitySchemaSelectMixin",

		mixins: {
			processLookupPageMixin: "BPMSoft.ProcessLookupPageMixin"
		},

		//region Methods: Private

		/**
		 * @private
		 */
		_findLastExtendChild: function(collection, parentItem) {
			const child = collection.findByFn((item) => item.parentUId === parentItem.uId  && item.getExtendParent());
			return child
				? this._findLastExtendChild(collection, child)
				: parentItem;
		},

		/**
		 * @private
		 */
		_findTopExtendedPackageItemCaption: function(packageItems, item) {
			if (BPMSoft.Features.getIsDisabled("DisableSortPackageItemsByHierarchy")) {
				const extendedPackageItems = packageItems.filter((x)=> x.getName() === item.getName());
				return extendedPackageItems.last()?.getCaption() || item.getCaption();
			}
			return item.getCaption();
		},

		//endregion

		//region Methods: Protected

		/**
		 * Initializes EntitySchemaSelectMixin.
		 * @protected
		 */
		initEntitySchemaSelectMixin: function() {
			this.set("EntitySchemaColumnsControlsSelect", this.Ext.create("BPMSoft.Collection"));
			this.set("EntitySchemaColumnsSelect", null);
			this.set("EntitySchemaSelect", null);
		},

		/**
		 * Initializes EntitySchemaSelect.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		initEntitySchemaSelect: function(callback, scope) {
			var entitySchemaUId = this.getEntitySchemaUId();
			if (!this.Ext.isEmpty(entitySchemaUId)) {
				this.getEntitySchemaInfo(entitySchemaUId, function(item) {
					this.set("EntitySchemaSelect", item);
					this.on("change:EntitySchemaSelect", this.onEntitySchemaSelectChanged, this);
					callback.call(scope);
				}, this);
			} else {
				this.on("change:EntitySchemaSelect", this.onEntitySchemaSelectChanged, this);
				callback.call(scope);
			}
		},

		/**
		 * Returns entity schema UId.
		 * @protected
		 */
		getEntitySchemaUId: function() {
			return this.get("EntitySchemaSelect");
		},

		/**
		 * Clears entity schema columns and their controls.
		 * @protected
		 */
		clearEntitySchemaColumns: function() {
			var entityColumns = this.get("EntitySchemaColumnsSelect");
			if (entityColumns) {
				entityColumns.clear();
				this.set("EntitySchemaColumnsSelect", null);
			}
			var controlList = this.get("EntitySchemaColumnsControlsSelect");
			if (controlList) {
				controlList.clear();
			}
		},

		/**
		 * EntitySchemaSelect change handler.
		 * @protected
		 */
		onEntitySchemaSelectChanged: function() {
			this.clearEntitySchemaColumns();
		},

		/**
		 * Initializes EntitySchemaColumnsSelect.
		 * @protected
		 * @param {Array} entityColumns Entity columns array.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		initEntitySchemaColumnsSelect: function(entityColumns, callback, scope) {
			if (this.Ext.isArray(entityColumns) && entityColumns.length > 0) {
				var controlList = this.get("EntitySchemaColumnsControlsSelect");
				controlList.clear();
				this.addEntitySchemaColumnControlSelect(entityColumns, callback, scope);
				return;
			}
			if (this.Ext.isFunction(callback)) {
				callback.call(scope || this);
			}
		},

		/**
		 * Returns entity schema info. If item schema not found, returns null.
		 * @protected
		 * @param {String} entitySchemaUId Entity schema UId.
		 * @param {Function} callback The callback function.
		 * @param {String} callback.value Value.
		 * @param {String} callback.displayValue Display value.
		 * @param {String} callback.name Name.
		 * @param {Object} scope The scope for the callback.
		 */
		getEntitySchemaInfo: function(entitySchemaUId, callback, scope) {
			var packageUId = this.getPackageUId();
			BPMSoft.EntitySchemaManager.findPackageItem(entitySchemaUId, packageUId, function(schemaItem) {
				var entitySchemaInfo;
				if (schemaItem && !schemaItem.getIsVirtual()) {
					entitySchemaInfo = {
						value: schemaItem.uId,
						displayValue: schemaItem.getCaption(),
						name: schemaItem.getName()
					};
				}
				callback.call(scope, entitySchemaInfo);
			}, this);
		},

		/**
		 *  Returns a list of excluded schemas.
		 * @protected
		 * @return {Array}
		 */
		getExcludedReferenceSchemaList() {
			return [
				"27aeadd6-d508-4572-8061-5b55b667c902", // SysSettings 
			];
		},

		/**
		 * Returns a list of schemas.
		 * @protected
		 * @return {Object} The list of schemas.
		 */
		getReferenceSchemaList: function(callback, scope) {
			const packageUId = this.getPackageUId();
			const excludedReferenceSchemaList = this.getExcludedReferenceSchemaList();
			let result = {};
			const config = {
				packageUId,
				filterFn: (item)=> !excludedReferenceSchemaList.includes(item.getUId()?.toLowerCase())
			}
			BPMSoft.EntitySchemaManager.findPackageItems(config, (packageItems) => {
				packageItems
					.filter((item)=> !item.getExtendParent())
					.sort("caption", this.BPMSoft.OrderDirection.ASC)
					.each((item) => {
						let value, name, displayValue;
						if (item.getIsVirtual()) {
							const childItem = this._findLastExtendChild(packageItems, item);
							if (childItem.getIsVirtual()) {
								return true;
							} else {
								value = childItem.getUId();
								name = childItem.getName();
								displayValue = this._findTopExtendedPackageItemCaption(packageItems, childItem);
							}
						} else {
							value = item.getUId();
							name = item.getName();
							displayValue = this._findTopExtendedPackageItemCaption(packageItems, item);
						}
						result[value] = {value, displayValue, name};
					}, this);
				Ext.callback(callback, scope, [result]);
			}, this);
		},

		/**
		 * Returns entity columns for ReferenceSchemaUId.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getEntitySchemaColumnsSelect: function(callback, scope) {
			scope = scope || this;
			var referenceSchemaUId = this.get("EntitySchemaSelect");
			var entitySchemaColumns = this.get("EntitySchemaColumnsSelect");
			if (!entitySchemaColumns) {
				entitySchemaColumns = this.Ext.create("BPMSoft.Collection");
				this.set("EntitySchemaColumnsSelect", entitySchemaColumns);
			}
			referenceSchemaUId = this.Ext.isObject(referenceSchemaUId) ? referenceSchemaUId.value : referenceSchemaUId;
			if (!referenceSchemaUId || !entitySchemaColumns.isEmpty()) {
				if (this.Ext.isFunction(callback)) {
					callback.call(scope, entitySchemaColumns);
				}
				return;
			}
			this.getEntitySchemaColumns(referenceSchemaUId, callback, scope);
		},

		/**
		 * Returns entity schema columns for ReferenceSchemaUId.
		 * @protected
		 * @param {GUID} schemaUId UId of the entity schema.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getEntitySchemaColumns: function(schemaUId, callback, scope) {
			var packageUId = this.getPackageUId();
			var config = {
				schemaUId: schemaUId,
				packageUId: packageUId
			};
			var entitySchemaColumns = this.get("EntitySchemaColumnsSelect");
			this.BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(schema) {
				if (schema) {
					schema.columns.each(function(column) {
						var entitySchemaColumn = this.getEntitySchemaColumnSelect(column);
						entitySchemaColumns.add(entitySchemaColumn.id, entitySchemaColumn);
					}, this);
					entitySchemaColumns.sort("caption");
				}
				if (this.Ext.isFunction(callback)) {
					callback.call(scope, entitySchemaColumns);
				}
			}, this);
		},

		/**
		 *
		 * Generates configuration view of the element.
		 * @protected
		 * @param {Object} itemConfig Link to configuration of element in ContainerList.
		 */
		getEntitySchemaColumnsControlsSelectViewConfig: function(itemConfig) {
			var defaultValuesViewConfig = this.get("EntitySchemaColumnsControlsSelectViewConfig");
			if (defaultValuesViewConfig) {
				itemConfig.config = defaultValuesViewConfig;
				return;
			}
			itemConfig.config = this.getEntitySchemaColumnsControlsSelectItemViewConfig();
			this.set("EntitySchemaColumnsControlsSelectViewConfig", itemConfig.config);
		},

		/**
		 * Returns EntitySchemaColumnsControlsSelect item view config.
		 * @protected
		 */
		getEntitySchemaColumnsControlsSelectItemViewConfig: function() {
			return this.getContainerConfig("item-view", ["top-caption-control", "control-width-15"], [{
				"id": "Value",
				"className": "BPMSoft.TextEdit",
				"value": {
					"bindTo": "Caption"
				},
				"readonly": true,
				"rightIconClasses": ["base-edit-clear-icon"],
				"markerValue": {
					"bindTo": "Caption"
				},
				"rightIconClick": {
					"bindTo": "rightIconClick"
				}
			}]);
		},

		/**
		 * Add new column.
		 * @protected
		 */
		onAddEntitySchemaColumnControlSelect: function() {
			this.getEntitySchemaColumnsSelect(function(entityColumns) {
				this.addSubscriptionsToEntitySchemaSetParametersInfo();
				this.showEntitySchemaColumnSelectPage(entityColumns);
			}, this);
		},

		/**
		 * Adds subscriptions  on SetParametersInfo.
		 * @private
		 */
		addSubscriptionsToEntitySchemaSetParametersInfo: function() {
			var schemaName = "ProcessLookupPage";
			var pageId = this.sandbox.id + schemaName;
			this.sandbox.subscribe("SetParametersInfo", function(parametersInfo) {
				if (parametersInfo) {
					this.addEntitySchemaColumnControlSelect(parametersInfo.selectedRows);
				}
				this.closeSchemaColumnSelectPage();
			}, this, [pageId]);
		},

		/**
		 * Returns entity schema column descriptor.
		 * @protected
		 * @param {Object} config Entity schema column config.
		 * @return {Object} Entity schema column descriptor.
		 */
		getEntitySchemaColumnSelect: function(config) {
			var id = config.uId;
			var caption = config.caption.getValue();
			return {
				id: id,
				value: id,
				name: config.name,
				caption: caption,
				displayValue: caption,
				selected: false
			};
		},

		/**
		 * Adds controls by selected columns if not exists.
		 * @protected
		 * @param {Array} selectedRows Selected columns.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		addEntitySchemaColumnControlSelect: function(selectedRows, callback, scope) {
			var controlList = this.get("EntitySchemaColumnsControlsSelect");
			var actualRows = new BPMSoft.Collection();
			this.getEntitySchemaColumnsSelect(function(entityColumns) {
				entityColumns.each(function(column) {
					var selected = this.Ext.Array.contains(selectedRows, column.id);
					if (selected && !controlList.contains(column.id)) {
						var viewModelConfig = this.Ext.merge({}, column, {
							displayValue: "",
							value: "",
							entitySchemaColumnsControlsSelect: this.get("EntitySchemaColumnsControlsSelect"),
							entitySchemaColumnsSelect: this.get("EntitySchemaColumnsSelect")
						});
						var viewModel = this.getEntitySchemaColumnControlSelectViewModel(viewModelConfig);
						actualRows.add(column.id, viewModel);
					}
					if (!selected && controlList.contains(column.id)) {
						controlList.removeByKey(column.id);
					}
					column.selected = selected;
				}, this);
				controlList.loadAll(actualRows);
				if (this.Ext.isFunction(callback)) {
					callback.call(scope || this);
				}
			}, this);
		},

		/**
		 * Deletes record column values control.
		 * @protected
		 * @param {String} id Record identifier.
		 */
		deleteRecordColumnValuesControl: function(id) {
			id = id || this.get("Id");
			var controlList = this.get("EntitySchemaColumnsControlsSelect");
			if (controlList) {
				controlList.removeByKey(id);
			}
			var entityColumns = this.get("EntitySchemaColumnsSelect");
			if (entityColumns) {
				var column = entityColumns.get(id);
				column.selected = false;
			}
		},

		/**
		 * Returns record column value element ViewModel.
		 * @protected
		 * @param {Object} config Element configuration.
		 * @return {BPMSoft.RecordColumnValueViewModel}
		 */
		getEntitySchemaColumnControlSelectViewModel: function(config) {
			var viewModel = this.Ext.create("BPMSoft.BaseModel",
				this.getEntitySchemaColumnControlSelectViewModelConfig(config));
			return viewModel;
		},

		/**
		 * The event handler for preparing of the data drop-down Entity.
		 * @protected
		 * @param {Object} filter Filters for data preparation.
		 * @param {BPMSoft.Collection} list The data for the drop-down list.
		 */
		prepareEntityList: function(filter, list) {
			if (list === null) {
				return;
			}
			list.clear();
			this.getReferenceSchemaList(function(entitySchemaList) {
				list.loadAll(entitySchemaList);
			}, this);
		},

		/**
		 * Returns package unique identifier.
		 * @protected
		 */
		getPackageUId: function() {
			return this.get("packageUId");
		},

		/**
		 * Returns EntitySchemaColumnControlSelect viewModel config.
		 * @param  {Object} config Initial config.
		 * @return {Object} EntitySchemaColumnControlSelect viewModel config.
		 */
		getEntitySchemaColumnControlSelectViewModelConfig: function(config) {
			return {
				columns: {
					Id: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.GUID
					},
					Name: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.TEXT
					},
					Caption: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.TEXT
					},
					Value: {
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: this.BPMSoft.DataValueType.TEXT
					},
					EntitySchemaColumnsControlsSelect: {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isCollection: true
					},
					EntitySchemaColumnsSelect: {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						isCollection: true
					}
				},
				values: {
					Id: config.id,
					Name: config.name,
					Caption: config.caption,
					Value: config.value,
					EntitySchemaColumnsControlsSelect: config.entitySchemaColumnsControlsSelect,
					EntitySchemaColumnsSelect: config.entitySchemaColumnsSelect
				},
				methods: {
					rightIconClick: this.deleteRecordColumnValuesControl
				}
			};
		}

		//endregion
	});

	return BPMSoft.EntitySchemaSelectMixin;
});
