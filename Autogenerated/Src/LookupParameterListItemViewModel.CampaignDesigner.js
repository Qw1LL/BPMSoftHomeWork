 /**
  * View model for lookup parameter item in container list.
  */
define("LookupParameterListItemViewModel", ["LookupParameterListItemViewModelResources", "LookupUtilities",
		"BaseParameterListItemViewModel"],
	function(resources, LookupUtilities) {
		/**
		 * @class BPMSoft.configuration.LookupParameterListItemViewModel
		 */
		Ext.define("BPMSoft.configuration.LookupParameterListItemViewModel", {
			extend: "BPMSoft.BaseParameterListItemViewModel",
			alternateClassName: "BPMSoft.LookupParameterListItemViewModel",
			columns: {
				/**
				 * Selected lookup item.
				 * @protected
				 */
				"SelectedItem": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				}
			},
			attributes: {
				/**
				 * Unique identifier of entity schema for lookup.
				 * @type {String}
				 */
				"EntitySchemaUId": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			/**
			 * Sets selected lookup item value.
			 * @private
			 * @param {BPMSoft.BaseViewModel} entity Entity.
			 */
			_setLookupValue: function(entity) {
				this.$SelectedItem = entity && {
					value: entity.$value,
					displayValue: entity.$displayValue
				};
			},

			/**
			 * Initializes lookup entity.
			 * @private
			 */
			_initSelectedEntity: function() {
				if (this.$Value && !this.$HasMacrosValue) {
					this._loadEntity(this.$Value, function(entity) {
						this._setLookupValue(entity);
					}, this);
				} else {
					this._setLookupValue(null);
				}
			},

			/**
			 * Loads lookup entity by Id.
			 * @private
			 * @param {String} entityId Unique identifier of the entity.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Context.
			 */
			_loadEntity: function(entityId, callback, scope) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.getEntitySchemaName()
				});
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "value");
				esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, "displayValue");
				esq.getEntity(entityId, function(response) {
					var entity = response && response.entity;
					callback.call(scope || this, entity);
				}, this);
			},

			/**
			 * @inheritdoc BaseParameterListItemViewModel#constructor
			 * @override
			 */
			constructor: function(config, parameterConfig) {
				this.callParent(arguments);
				this._initSelectedEntity();
				this.on("change:SelectedItem", this.onSelectedItemChanged, this);
			},

			/**
			 * @inheritdoc BaseParameterListItemViewModel#initParameter
			 * @override
			 */
			initParameter: function(values, config) {
				this.callParent(arguments);
				values.EntitySchemaUId = config.referenceSchemaUId;
			},

			/**
			 * Opens lookup for entity schema.
			 * @protected
			 * @param {Object} args Contains the searchValue property.
			 * @param {String} tag Root schema name.
			 */
			openEntityLookup: function(args, tag) {
				var config = this.getEntityLookupConfig(tag);
				LookupUtilities.Open(this.sandbox, config, this.onEntityLookupSelected, this, null, false, false);
			},

			/**
			 * Gets entity lookup config.
			 * @protected
			 * @param {String} entitySchemaName Root schema name.
			 * @return {Object} Lookup config with filters for select entity record.
			 */
			getEntityLookupConfig: function(entitySchemaName) {
				var config = {
					entitySchemaName: entitySchemaName,
					multiSelect: false,
					hideActions: true
				};
				return config;
			},

			/**
			 * Returns root schema name for entity
			 * @protected
			 * @returns {String} Root schema name.
			 */
			getEntitySchemaName: function() {
				var schema = BPMSoft.EntitySchemaManager.items.find(this.$EntitySchemaUId);
				return schema && schema.name;
			},

			/**
			 * Handles event after selected item in lookup.
			 * @protected
			 * @param {Object} lookupInfo Contains information about selected rows from lookup.
			 */
			onEntityLookupSelected: function(lookupInfo) {
				var selectedRows = lookupInfo && lookupInfo.selectedRows;
				if (!selectedRows.isEmpty()) {
					var selectedItem = selectedRows.first();
					this.$SelectedItem = selectedItem;
				}
			},

			/**
			 * Handles event after selected item changed.
			 * @protected
			 * @param {Object} model Control model.
			 * @param {Object} item New selected item.
			 */
			onSelectedItemChanged: function(model, item) {
				this.$Value = item && item.value;
			},

			/**
			 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#getValueMenuItems
			 * @override
			 */
			getValueMenuItems: function() {
				var items = this.callParent();
				if (this.$Name === "Account" || this.$Name === "QualifiedAccount") {
					items.add("ContactAccount", new BPMSoft.BaseViewModel(
						{
							values: {
								Id: "ContactAccount",
								Caption: resources.localizableStrings.ContactAccount,
								ImageConfig: this.getImage(resources.localizableImages.AccountIcon),
								MarkerValue: "ContactAccount",
								Click: "$onSelectContactAccountMacros"
							}
						}));
				}
				return items;
			},

			/**
			 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#getParameterInputConfig
			 * @override
			 */
			getParameterInputConfig: function() {
				return [
					{
						className: "BPMSoft.MultilineLabel",
						contentVisible: true,
						showReadMoreButton: false,
						caption: "$Caption"
					},
					{
						className: "BPMSoft.LookupEdit",
						loadVocabulary: "$openEntityLookup",
						value: "$SelectedItem",
						markerValue: this.getControlMarkerValue(),
						tag: this.getEntitySchemaName()
					}
				];
			},

			/**
			 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#resetParameterValue
			 * @override
			 */
			resetParameterValue: function(macros) {
				this.callParent(arguments);
				this._setLookupValue(null);
			},

			/**
			 * Handles contact account macros selected.
			 * @protected
			 */
			onSelectContactAccountMacros: function() {
				var macros = this.formatMacrosColumn("Account.Id");
				this.onGetMacros(macros);
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseParameterListItemViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
			    this.addColumnValidator("SelectedItem", this.validateValue)
			}

		});
		return BPMSoft.LookupParameterListItemViewModel;
	}
);
