define("ProcessSchemaLocalizableStringViewModel", ["ProcessSchemaLocalizableStringViewModelResources",
	"ProcessMiniEditPageMixin"
], function() {

	/**
	 * Model 'Using' for the settings page of process.
	 */
	Ext.define("BPMSoft.model.ProcessSchemaLocalizableStringViewModel", {
		extend: "BPMSoft.model.BaseModel",
		alternateClassName: "BPMSoft.ProcessSchemaLocalizableStringViewModel",

		Ext: null,
		BPMSoft: null,

		mixins: {
			processMiniEditPageMixin: "BPMSoft.ProcessMiniEditPageMixin"
		},

		columns: {
			"Id": {
				"dataValueType": this.BPMSoft.DataValueType.GUID
			},
			"Name": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},
			"Caption": {
				"dataValueType": this.BPMSoft.DataValueType.LOCALIZABLE_STRING
			},
			"Value": {
				"dataValueType": this.BPMSoft.DataValueType.LOCALIZABLE_STRING
			},
			"ParameterEditToolsButtonMenu": {
				"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
				"value": Ext.create("BPMSoft.BaseViewModelCollection")
			},
			"Visible": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": true
			},
			"MarkerValue": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
			},
			/**
			 * Parent module instance.
			 */
			"ParentModule": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Indicates whether current item is editable or not.
			 */
			"IsEditable": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"value": true
			}
		},

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getProcessMiniEditPageName
		 * @override
		 */
		getProcessMiniEditPageName: function() {
			return "ProcessSchemaLocalizableStringMiniEditPage";
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getActiveItemEditName
		 * @override
		 */
		getActiveItemEditName: function() {
			return "ProcessLocalizableStringEditName";
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getProcessMiniEditPageId
		 * @override
		 */
		getProcessMiniEditPageId: function() {
			return this.sandbox.id + "localizablestringedit";
		},

		/**
		 * @inheritdoc ProcessMiniEditPageMixin#getActiveItemId
		 * @overridden
		 * @returns {string}
		 */
		getActiveItemId: function () {
			return "ActiveLocalizableStringItemId";
		},

		/**
		 * @inheritdoc ProcessMiniEditPageMixin#getAddButtonEnabledProperyName
		 * @overridden
		 * @returns {string} Enabled property name.
		 */
		getAddButtonEnabledProperyName: function() {
			return "IsAddLocalizableStringButtonEnabled";
		}

		// endregion

	});

	return BPMSoft.ProcessSchemaLocalizableStringViewModel;
});
