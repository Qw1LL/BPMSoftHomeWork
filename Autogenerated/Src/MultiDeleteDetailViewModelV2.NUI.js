define("MultiDeleteDetailViewModelV2", ["MultiDeleteDetailViewModelV2Resources", "GridUtilitiesV2"],
	function(resources) {
		Ext.define("BPMSoft.configuration.MultiDeleteDetailViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.MultiDeleteDetailViewModel",

			mixins: {
				GridUtilities: "BPMSoft.GridUtilities"
			},

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			columns: {
				/**
				 * The text of the header caption.
				 */
				"Caption": {
					columnPath: "Caption",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: ""
				},

				/**
				 * Identifier of the group of search results.
				 */
				"GroupId": {
					columnPath: "GroupId",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					value: 0
				},

				/**
				 * The collection of the grid rows.
				 */
				"GridData": {
					columnPath: "GridData",
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					isCollection: true,
					value: Ext.create("BPMSoft.BaseViewModelCollection"),
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				}
			},

			/**
			 * Initialize model.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			init: function(callback, scope) {
				this.set("GridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				this.initProperties();
				this.mixins.GridUtilities.init.call(this);
				this.loadGridData();
				if (callback) {
					callback.call(scope || this);
				}
			},

			/**
			 * Initialize properties.
			 * @private
			 */
			initProperties: function() {
				var propertiesTranslator = this.getPropertiesTranslator();
				var conditionsTranslator = this.getConditionsTranslator();
				var properties = this.values || {};
				this.BPMSoft.each(propertiesTranslator, function(configName, viewModelPropertyName) {
					if (properties.hasOwnProperty(configName)) {
						var value = properties[configName];
						if (conditionsTranslator.hasOwnProperty(configName)) {
							var condition = conditionsTranslator[configName];
							condition.apply(this, [value]);
							return;
						}
						this.set(viewModelPropertyName, value);
					}
				}, this);
			},

			/**
			 * Returns grid row collection.
			 * @return {BPMSoft.BaseViewModelCollection} Grid row collection.
			 * @private
			 */
			getGridData: function() {
				return this.get("GridData");
			},

			/**
			 * Sets entity schema name.
			 * @param {String} value Entity schema name.
			 * @private
			 */
			setEntitySchemaName: function(value) {
				if (this.Ext.isEmpty(value)) {
					throw new BPMSoft.ArgumentNullOrEmptyException({
						argumentName: "EntitySchemaName"
					});
				}
				this.entitySchemaName = value;
			},

			/**
			 * Returns filters for detail select.
			 * @return {BPMSoft.FilterGroup} Filters for detail select.
			 * @protected
			 */
			getFilters: function() {
				var filter = this.Ext.create("BPMSoft.FilterGroup");
				var referenceColumns = this.get("ReferenceColumns");
				var referenceRecordId = this.get("ReferenceRecordId");
				filter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
				this.BPMSoft.each(referenceColumns, function(column) {
					filter.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							column, referenceRecordId));
				}, this);
				return filter;
			},

			/**
			 * Returns structure of the module.
			 * @param {String} moduleName Name of the module.
			 * @return {Object} Structure of the module.
			 * @protected
			 * @virtual
			 */
			getModuleStructure: function(moduleName) {
				return this.BPMSoft.ModuleUtils.getModuleStructureByName(moduleName || this.entitySchemaName);
			},

			/**
			 * Returns decoupling config for the parameter values for properties of the ViewModel.
			 * @return {Object} Config.
			 * @protected
			 * @virtual
			 */
			getPropertiesTranslator: function() {
				return {
					"Caption": "caption",
					"GroupId": "groupId",
					"CanRead": "canRead",
					"ReferenceColumns": "referenceColumns",
					"RecordsCount": "recordsCount",
					"Profile": "profile",
					"ReferenceRecordId": "referenceRecordId",
					"EntitySchemaName": "entitySchemaName"
				};
			},

			/**
			 * Returns conditions decoupling config for the parameter values for properties of the ViewModel.
			 * @return {Object} Config.
			 * @protected
			 * @virtual
			 */
			getConditionsTranslator: function() {
				return {
					"entitySchemaName": this.setEntitySchemaName
				};
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#loadGridData
			 * @overridden
			 */
			loadGridData: function() {
				if (this.get("CanRead")) {
					this.mixins.GridUtilities.loadGridData.call(this, arguments);
				}
			},
			
			/**
			 * @inheritdoc BPMSoft.GridUtilities#onGridDataLoaded
			 * @overridden
			 */
			onGridDataLoaded: function(response) {
				const collectionCount = response && response.success && response.collection.getCount() || 0;
				const haveNotAllRowsAccess = this.$CanRead && collectionCount < this.$RecordsCount;
				if (haveNotAllRowsAccess) {
					const accessErrorMsgTpl = resources.localizableStrings.RowsAccessErrorMsgTpl;
					this.$Caption = Ext.String.format("{0}. {1}", this.$Caption,
							Ext.String.format(accessErrorMsgTpl, this.$RecordsCount - collectionCount));
				}
				this.mixins.GridUtilities.onGridDataLoaded.apply(this, arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#addProcessEntryPointColumn
			 * @overridden
			 */
			addProcessEntryPointColumn: this.BPMSoft.emptyFn,

			/**
			 * On render handler.
			 */
			onRender: this.Ext.emptyFn

		});
	});
