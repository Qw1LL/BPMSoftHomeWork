define("ProcessSchemaUsingViewModel", ["ProcessSchemaUsingViewModelResources", "ProcessMiniEditPageMixin"
], function() {

	/**
	 * Model 'Using' for the settings page of process.
	 */
	Ext.define("BPMSoft.model.ProcessSchemaUsingViewModel", {
		extend: "BPMSoft.model.BaseModel",
		alternateClassName: "BPMSoft.ProcessSchemaUsingViewModel",

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
			"Alias": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT
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
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT
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
			return "ProcessSchemaUsingMiniEditPage";
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getActiveItemEditName
		 * @override
		 */
		getActiveItemEditName: function() {
			return "ProcessUsingEditName";
		},

		/**
		 * @inheritdoc ProcessMiniEditPageMixin#getActiveItemId
		 * @overridden
		 * @returns {string}
		 */
		getActiveItemId: function () {
			return "ActiveUsingItemId";
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getProcessMiniEditPageId
		 * @override
		 */
		getProcessMiniEditPageId: function() {
			return this.sandbox.id + "usingedit";
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getAddButtonEnabledProperyName
		 * @override
		 */
		getAddButtonEnabledProperyName: function() {
			return "IsAddUsingsButtonEnabled";
		}

		// endregion

	});

	return BPMSoft.ProcessSchemaUsingViewModel;
});
