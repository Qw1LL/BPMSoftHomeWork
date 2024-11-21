define("MLModelColumnViewModel", ["ColumnSettingsUtilities"], function(ColumnSettingsUtilities) {
	/**
	 * @class BPMSoft.configuration.MLModelColumnViewModel
	 * Ml model column view model.
	 */
	Ext.define("BPMSoft.configuration.MLModelColumnViewModel", {
		alternateClassName: "BPMSoft.MLModelColumnViewModel",
		extend: "BPMSoft.BaseViewModel",
		Ext: null,
		BPMSoft: null,
		sandbox: null,

		/**
		 * @inheritdoc BPMSoft.BaseModel#columns
		 * @override
		 */
		columns: {
			UId: {
				dataValueType: BPMSoft.DataValueType.GUID
			},
			ColumnPath: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			Caption: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			SchemaCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			DataValueType: {
				dataValueType: BPMSoft.DataValueType.INTEGER
			},
			ReferenceSchemaName: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			SubFilters: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			IsBackward: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},
			ColumnType: {
				dataValueType: BPMSoft.DataValueType.LOOKUP
			},
			IsNew: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},

		/**
		 * Column settings window close handler.
		 * @param {Object} config Edited column config.
		 * @private
		 */
		_onColumnSettingsClosed: function(config) {
			if (this.$Caption !== config.title) {
				this.$Caption = config.title || this.$SchemaCaption;
			}
			this.$AggregationType = config.aggregationType;
			this.$SubFilters = config.serializedFilter;
		},

		/**
		 * Opens column settings.
		 * @return {Boolean}
		 */
		onColumnHyperlinkClick: function() {
			ColumnSettingsUtilities.Open(this.sandbox, {
				aggregationType: this.$AggregationType,
				isCaptionHidden: false,
				leftExpressionCaption: this.$Caption,
				metaCaptionPath: this.$SchemaCaption,
				isColumnTypeVisible: false,
				dataValueType: this.$DataValueType,
				isBackward: this.$IsBackward,
				referenceSchemaName: this.$ReferenceSchemaName,
				serializedFilter: this.$SubFilters || null,
				loadModuleConfig: {
					hidePageCaption: true
				}
			}, this._onColumnSettingsClosed, "centerPanel", this);
			return false;
		},

		/**
		 * Removes element from collection.
		 */
		onRemoveColumnClick: function() {
			this.parentCollection.remove(this);
		}
	});
});
