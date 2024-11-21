define("ServiceParameterViewModel",
	["ServiceEnums","ServiceMetaItemViewModelMixin","ServiceDesignerUtilities"], function() {
	Ext.define("BPMSoft.services.ServiceParameterViewModel", {
		extend: "BPMSoft.BaseViewModel",
		alternateClassName: "BPMSoft.ServiceParameterViewModel",
		mixins: {
			ObservableItem: "BPMSoft.ObservableItem",
			MetaItem: "BPMSoft.ServiceMetaItemViewModelMixin"
		},
		attributes: {

			/**
			 * Service parameter.
			 * @type {BPMSoft.ServiceParameter}
			 */
			ServiceParameter: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Name of value type.
			 * @type {String}
			 */
			DataValueTypeName: {
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Default value complex object of parameter.
			 * @type {BPMSoft.ServiceParameterValue}
			 */
			DefaultValue: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.core.enums.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Parameter type.
			 * @type {BPMSoft.ServiceParameterValue}
			 */
			Type: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT
			}
		},

		/**
		 * Primary column name in grid.
		 */
		primaryColumnName: "Id",
		columns: {

			/**
			 * Parameter UId.
			 * @type {Guid}
			 */
			Id: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "Id",
				dataValueType: BPMSoft.core.enums.DataValueType.GUID
			},

			/**
			 * Name of parameter.
			 * @type {String}
			 */
			Name: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "Name",
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT
			},

			/**
			 * Parent parameter UId.
			 * @type {Guid}
			 */
			ParentId: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "ParentId",
				dataValueType: BPMSoft.core.enums.DataValueType.GUID
			},

			/**
			 * Url to image of parameter data type.
			 * @type {String}
			 */
			TypeIcon: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "TypeIcon",
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT
			},

			/**
			 * Indicates is parameter array.
			 * @type {Boolean}
			 */
			IsArray: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "IsArray",
				dataValueType: BPMSoft.core.enums.DataValueType.BOOLEAN
			},

			/**
			 * Caption of parameter.
			 * @type {String}
			 */
			Caption: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "Caption",
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT
			},

			/**
			 * Default value of parameter.
			 * @type {String}
			 */
			DisplayDefValue: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "ValueInDefaultValue",
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT
			},

			/**
			 * Caption of parameter type.
			 * @type {String}
			 */
			TypeCaption: {
				type: BPMSoft.core.enums.ViewModelColumnType.CALCULATED_COLUMN,
				caption: "TypeCaption",
				dataValueType: BPMSoft.core.enums.DataValueType.TEXT
			}
		},

		//region Methods: Private

		/**
		 * Update values in columns from attributes with complex types.
		 * @private
		 */
		_updateValues: function() {
			var dataValueTypeName = this.$ServiceParameter.getPropertyValue("dataValueTypeName");
			this.$DisplayDefValue = BPMSoft.ServiceDesignerUtilities.getFormattedValue(this.$DefaultValue, dataValueTypeName);
			this.$TypeCaption = BPMSoft.services.enums.ServiceParameterTypeCaption[this.$Type];
			this.$TypeIcon = BPMSoft.ServiceDesignerUtilities.getImageUrlByDataValueTypeName(this.$DataValueTypeName);
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ObservableItem#getAttributeMap
		 * @protected
		 * @overridden
		 */
		getAttributeMap: function() {
			return {
				uId: "Id",
				name: "Name",
				isArray: "IsArray",
				dataValueTypeName: "DataValueTypeName",
				caption: "Caption",
				defValue: "DefaultValue",
				type: "Type"
			};
		},

		/**
		 * @inheritdoc BaseObject#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			this.unsubscribeAllItems();
			this.callParent(arguments);
		},

		//endregion

		//region Methods: Public

		/**
		 * Initialize type icon and set event handlers on change view model state.
		 * @public
		 */
		init: function() {
			this.useItemInitialValues = true;
			this.useViewModelToItemBinding = true;
			this.subscribeOnItemChanged(this.$ServiceParameter);
			this._updateValues();
			this.on("change", this._updateValues, this);
		}

		//endregion

	});
	return BPMSoft.ServiceParameterViewModel;
});
