define("SectionPageSettingsItemModel", ["BaseSchemaViewModel", "LookupQuickAddMixin"], function() {

	/**
	 * Class for SectionPageSettings item model.
	 */
	Ext.define("BPMSoft.configuration.SectionPageSettingsItemModel", {
		extend: "BPMSoft.configuration.BaseSchemaViewModel",
		alternateClassName: "BPMSoft.SectionPageSettingsItemModel",

		mixins: {
			LookupQuickAddMixin: "BPMSoft.configuration.mixins.LookupQuickAddMixin"
		},

		attributes: {
			Id: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			/**
			 * @type {BPMSoft.manager.SysModuleEditManagerItem}
			 */
			ModuleEdit: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			SchemaUId: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			SchemaName: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			Caption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				size: 250
			},
			/**
			 * @type {BPMSoft.SectionPageSettings}
			 * @alias $SettingsModel
			 */
			SettingsModel: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * @type {{value: String, displayValue: String}}
			 */
			Type: {
				dataValueType: BPMSoft.DataValueType.LOOKUP
			},
			TypeList: {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			CanRenameSchema: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.set("TypeList", new BPMSoft.Collection());
			this.mixins.LookupQuickAddMixin.init.call(this);
		},

		/**
		 * @inheritdoc BPMSoft.LookupQuickAddMixin#isSilentCreation
		 * @override
		 */
		isSilentCreation: function() {
			return true;
		},

		/**
		 * @inheritdoc BPMSoft.LookupQuickAddMixin#onLookupDataLoaded
		 * @override
		 */
		onLookupDataLoaded: function(config) {
			this.callParent(arguments);
			if (config.columnName === "Type") {
				config.isLookupEdit = true;
				this.mixins.LookupQuickAddMixin.onLookupDataLoaded.call(this, config);
			}
		},

		/**
		 * @inheritdoc BPMSoft.LookupQuickAddMixin#tryCreateEntityOrOpenCard
		 * @override
		 */
		tryCreateEntityOrOpenCard: function(searchValue, columnName) {
			if (columnName === "Type") {
				const canAdd = this.$SettingsModel.checkCanAddNewType(searchValue);
				if (!canAdd) {
					this.set(columnName, null);
					this.$SettingsModel.changeModelItemType(this, null);
					return;
				}
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.LookupQuickAddMixin#onLookupChange
		 * @override
		 */
		onLookupChange: function(newValue, columnName) {
			if (columnName !== "Type") {
				return this.callParent(arguments);
			}
			if (newValue && newValue.isNewValue && this.$SettingsModel.getIsNewTypeEntitySchema()) {
				const displayValue = newValue.displayValue;
				const canAdd = this.$SettingsModel.checkCanAddNewType(displayValue);
				if (canAdd) {
					const config = {
						displayValue: displayValue
					};
					this.$SettingsModel.addTypeRecordToDataManager(config, function(value) {
						this.set(columnName, value);
					}, this);
				} else {
					this.set(columnName, null);
					this.$SettingsModel.changeModelItemType(this, null);
				}
			} else {
				this.callParent([BPMSoft.deepClone(newValue), columnName]);
				const value = this.get(columnName);
				const isNewValue = (value && value.isNewValue) ||
					(newValue && (newValue.isNewValue || newValue.inputedValue));
				if (!isNewValue) {
					this.$SettingsModel.changeModelItemType(this, newValue);
				}
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#loadLookupData
		 * @override
		 */
		loadLookupData: function(filterValue, list, columnName, isLookupEdit, callback, scope) {
			if (columnName !== "Type") {
				return this.callParent(arguments);
			}
			if (this.$SettingsModel.getIsNewTypeEntitySchema()) {
				const config = {
					filterValue: filterValue,
					uniqueTypeValues: true,
					currentType: this.get(columnName)
				};
				this.$SettingsModel.getTypeRecordsFromDataManager(config, function(collection) {
					list.clear();
					const objects = {};
					this.onLookupDataLoaded({
						collection: collection,
						filterValue: filterValue,
						objects: objects,
						columnName: columnName,
						isLookupEdit: isLookupEdit
					});
					list.loadAll(objects);
				}, this);
			} else {
				if (!Ext.isFunction(callback)) {
					callback = null;
				}
				this.callParent([filterValue, list, columnName, isLookupEdit, callback, scope]);
			}
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#getLookupQuery
		 * @override
		 */
		getLookupQuery: function(filterValue, columnName) {
			const esq = this.callParent(arguments);
			if (columnName === "Type") {
				this.$SettingsModel.addUsedTypesFilter(esq, this.get("Type"));
			}
			return esq;
		},

		//endregion

		//region Methods: Public

		/**
		 * Handler for multi page data grid container list item click.
		 */
		onMultiPageItemClick: function() {
			this.$SettingsModel.editModelItem(this);
		},

		/**
		 * Flag that indicate whether Type column is enabled or not.
		 * @return {Boolean}
		 */
		isTypeEnabled: function() {
			const typeColumn = this.$SettingsModel.get("TypeColumn");
			return Boolean(typeColumn);
		},

		/**
		 * Returns page caption button marker value.
		 * @return {String}
		 */
		getPageCaptionButtonMarker: function() {
			return "PageCaptionButton" + this.get("SchemaName");
		},

		/**
		 * Returns page type lookup marker value.
		 * @return {String}
		 */
		getPageTypeLookupMarker: function() {
			return "PageTypeLookup" + this.get("SchemaName");
		},

		/**
		 * Handler for edit page action item.
		 */
		onEditPageActionItem: function() {
			this.$SettingsModel.editModelItem(this);
		},

		/**
		 * Handler for rename page action item.
		 */
		onRenamePageActionItem: function() {
			this.$SettingsModel.renameModelItem(this);
		},

		/**
		 * Handler for copy page action item.
		 */
		onCopyPageActionItem: function() {
			this.$SettingsModel.copyModelItem(this);
		},

		/**
		 * Handler for remove page action item.
		 */
		onRemovePageActionItem: function() {
			this.$SettingsModel.removeModelItem(this);
		}

		//endregion

	});
});
