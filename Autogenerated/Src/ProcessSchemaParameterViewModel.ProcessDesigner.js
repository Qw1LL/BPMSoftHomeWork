define("ProcessSchemaParameterViewModel", [
	"ProcessSchemaParameterViewModelResources",
	"MappingEditMixin"
],	function(resources) {
	Ext.define("BPMSoft.configuration.ProcessSchemaParameterViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.ProcessSchemaParameterViewModel",
		mixins: {
			mappingEditMixin: "BPMSoft.MappingEditMixin"
		},
		sandbox: null,
		columns: {
			Id: {dataValueType: BPMSoft.DataValueType.TEXT},
			UId: {dataValueType: BPMSoft.DataValueType.GUID},
			InvokerUId: {dataValueType: BPMSoft.DataValueType.GUID},
			Name: {dataValueType: BPMSoft.DataValueType.TEXT},
			Caption: {dataValueType: BPMSoft.DataValueType.TEXT},
			DataValueType: {dataValueType: BPMSoft.DataValueType.INTEGER},
			DataValueTypeImage: {dataValueType: BPMSoft.DataValueType.TEXT},
			IsRequired: {dataValueType: BPMSoft.DataValueType.BOOLEAN},
			ReferenceSchemaUId: {dataValueType: BPMSoft.DataValueType.LOOKUP},
			InitialReferenceSchemaUId: {dataValueType: BPMSoft.DataValueType.LOOKUP},
			Value: {dataValueType: BPMSoft.DataValueType.MAPPING},
			Enabled: {dataValueType: BPMSoft.DataValueType.BOOLEAN},
			Visible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			packageUId: { dataValueType: BPMSoft.DataValueType.GUID },
			ParameterEditToolsButtonMenu: { dataValueType: BPMSoft.DataValueType.COLLECTION },
			ActiveParameterEditUId: { dataValueType: BPMSoft.DataValueType.GUID },
			Parameters: { dataValueType: BPMSoft.DataValueType.COLLECTION },
			ProcessElement: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			Direction: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Item properties.
			 */
			ItemProperties: {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Has nested parameters.
			 */
			HasNestedParameters: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Is nested control group collapsed.
			 */
			HideNestedItems: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether user can add nested parameters or not.
			 */
			CanAddNestedItems: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether a nested parameter edit page is opened or not.
			 */
			IsNestedParameterEditPageOpened: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Caption of control group for nested parameters.
			 */
			ControlGroupCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: resources.localizableStrings.CollapseControl
			},

			/**
			 * Parent parameter uId.
			 */
			ParentUId: { dataValueType: BPMSoft.DataValueType.GUID },

			/**
			 * Process schema.
			 */
			ProcessSchema: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether a value can be mapped to a parameter.
			 */
			CanAssignSourceValue: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Property for sorting by direction.
			 */
			CaptionWithDirection: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.CALCULATED_COLUMN
			},

			/**
			 * Parameter value contains mapping to the collection.
			 */
			HasCollectionMapping: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Previous parameter value.
			 */
			PreviousValue: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * AddButton menu items collection.
			 */
			AddButtonMenu: {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				value: Ext.create("BPMSoft.BaseViewModelCollection")
			},

			/**
			 * Parameter edit key.
			 */
			ParameterEditKey: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Data item marker value.
			 */
			MarkerValue: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},

		//region Methods: Private

		/**
		 * @private
		 */
		_mappingValidator: function(value) {
			var result = {invalidMessage: ""};
			if (value && value.isValid === false && BPMSoft.ProcessSchemaDesignerUtilities.hasMapping(value)) {
				var resource = this.get("Resources.Strings.InavalidMappingColumn");
				result.invalidMessage = resource || "Invalid formula";
			}
			return result;
		},

		/**
		 * @private
		 */
		_onItemPropertiesChanged: function() {
			this.$HasNestedParameters = this.$ItemProperties && !this.$ItemProperties.isEmpty();
		},

		/**
		 * @private
		 */
		_onValueChanged: function(args) {
			this.$PreviousValue = args.previous("Value");
		},

		/**
		 * Sets IsNestedParameterEditPageOpened attribute value recursively.
		 * @public
		 * @param isAdding
		 */
		setIsNestedParameterEditPageOpened: function(isAdding) {
			this.$IsNestedParameterEditPageOpened = isAdding;
			const itemProperties = this.$ItemProperties;
			itemProperties.each(function(item) {
				item.setIsNestedParameterEditPageOpened(isAdding);
			}, this);
		},

		//endregion

		/**
		 * @private
		 */
		_requiredParameterValidator: function(mapping) {
			if ((this.$ProcessElement instanceof BPMSoft.ProcessWebServiceSchema) &&
					this.$IsRequired && !mapping.value && !Ext.isBoolean(mapping.value)) {
				return {invalidMessage: BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage};
			}
			return {invalidMessage: ""};
		},

		/**
		 * @private
		 */
		_initProcessSchema: function(config) {
			if (config && config.values && config.values.ProcessElement) {
				var element = config.values.ProcessElement;
				this.$ProcessSchema = element.parentSchema || element;
			}
		},

		/**
		 * Determines whether to show parameter direction image or not.
		 * @returns {boolean}
		 */
		getCanShowParameterDirection: function() {
			return !this.$ParentUId;
		},

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constuctor
		 * @protected
		 */
		constructor: function(config) {
			this.callParent(arguments);
			this.addEvents("collectionMappingSet");
			this.addEvents("collectionMappingReset");
			this.addEvents("onAddNestedParameter");
			this._initProcessSchema(config);
			this.addColumnValidator("Value", BPMSoft.ProcessSchemaDesignerUtilities.mappingValidator);
			this.addColumnValidator("Value", this._requiredParameterValidator);
			this.on("change:ItemProperties", this._onItemPropertiesChanged, this);
			this.on("change:Value", this._onValueChanged, this);
			const orderDirectionValue = BPMSoft.ProcessSchemaParameterDirectionOrder[this.$Direction];
			this.$CaptionWithDirection = Ext.String.format("{0}{1}", orderDirectionValue, this.$Caption);
			this.$HasNestedParameters = this.$ItemProperties && !this.$ItemProperties.isEmpty();
			this.$ParameterEditKey = this.getParameterEditKey();
			this.$MarkerValue = this._getMarkerValue();
		},

		/**
		 * @inheritdoc MappingEditMixin#getInvokerUId
		 * @override
		 */
		getInvokerUId: function() {
			return this.get("InvokerUId");
		},

		/**
		 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
		 * @override
		 */
		getParameterReferenceSchemaUId: function() {
			return this.get("InitialReferenceSchemaUId");
		},

		/**
		 * Returns parameter edit tools button image.
		 * @protected
		 */
		getParameterEditToolsButtonImage: function() {
			return resources.localizableImages.ParameterEditToolsButtonImage;
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:ItemProperties", this._onItemPropertiesChanged, this);
			this.callParent(arguments);
		},

		/**
		 * Handles control group collapsedchange event.
		 * @protected
		 */
		onCollapsedChanged: function() {
			var resourceName = !this.$HideNestedItems ? "ExpandControl" : "CollapseControl";
			this.$ControlGroupCaption = resources.localizableStrings[resourceName];
		},

		// endregion

		// region Methods: Public

		/**
		 * Returns true is $ItemProperties not empty.
		 * @return {Boolean} Has nested parameters.
		 * @public
		 */
		hasItemProperties: function() {
			return this.$ItemProperties && !this.$ItemProperties.isEmpty();
		},

		/**
		 * Returns true if parameter available to use.
		 * @return {Boolean}.
		 * @public
		 */
		isAvailable: function() {
			if (!BPMSoft.Features.getIsEnabled("NoCompilationFeature") && !BPMSoft.isDebug) {
				return true;
			}
			return BPMSoft.isInstanceOfClass(this.$ProcessSchema, "BPMSoft.ProcessSchema")
				? !(this.$ProcessSchema.shouldBeCompiled() && BPMSoft.isEnumerableDataValueType(this.$DataValueType))
				: true;
		},

		/**
		 * Returns true if input parameter is available.
		 * @return {Boolean}
		 * @public
		 */
		isInputParameterAvailable: function() {
			return this.isAvailable() && this.$Direction === BPMSoft.ProcessSchemaParameterDirection.IN;
		},

		/**
		 * Determines whether a nested items control should be visible or not.
		 * @return {Boolean}
		 * @public
		 */
		getShouldShowNestedItems: function() {
			return this.$HasNestedParameters || this.$CanAddNestedItems;
		},

		/**
		 * Determines whether a value control should be visible or not.
		 * @return {Boolean}
		 * @public
		 */
		getShouldShowValueControl: function() {
			return !this.getShouldShowNestedItems();
		},

		/**
		 * Handles a click event of the AddNestedItemButton.
		 * @protected
		 * @param {String} dataValueType Data value type.
		 */
		onAddNestedItemButtonClick: function(dataValueType) {
			this.fireEvent("onAddNestedParameter", {
				dataValueType: dataValueType,
				parameterUId: this.$UId,
				parameterId: this.$Id
			});
		},

		/**
		 * @inheritdoc BPMSoft.MappingEditMixin#getParameterEditKey
		 * @override
		 */
		getParameterEditKey: function() {
			return this.get("Id") + "-" + this.get("UId");
		},

		/**
		 * Returns a data item marker value.
		 * @returns {string}
		 */
		_getMarkerValue: function() {
			return "esn-notification-item-" + this.get("Id");
		}

		// endregion

	});

	return BPMSoft.ProcessSchemaParameterViewModel;
});
