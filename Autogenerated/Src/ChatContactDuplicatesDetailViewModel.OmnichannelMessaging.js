define("ChatContactDuplicatesDetailViewModel", ["NetworkUtilities", "ChatContactDuplicatesDetailViewModelResources",
	"ServiceHelper", "DuplicatesDetailViewModelV2", "css!ChatContactDuplicatesDetailViewModel"],
	function (NetworkUtilities, resources, ServiceHelper) {
	Ext.define("BPMSoft.configuration.ChatContactDuplicatesDetailViewModel", {
		extend: "BPMSoft.DuplicatesDetailViewModel",
		alternateClassName: "BPMSoft.ChatContactDuplicatesDetailViewModel",

		// region Methods: Private

		/**
		 * @private
		 */
		_isCurrent: function(item) {
			return item.id === this.get("currentContactId").toLowerCase();
		},

		/**
		 * @private
		 */
		_getContactUrl: function(contactId) {
			const config = {
				entitySchema: this.entitySchemaName,
				primaryColumnValue: contactId,
				operation: BPMSoft.ConfigurationEnums.CardOperation.EDIT
			};
			return BPMSoft.combinePath(this.BPMSoft.workspaceBaseUrl, "Nui", "ViewModule.aspx#",
				NetworkUtilities.getEntityUrl(config));
		},

		// endregion

		// region Methods: Protected

		/**
		 * @protected
		 */
		getCurrentLabelConfig: function() {
			return {
				"className": "BPMSoft.Label",
				"caption": resources.localizableStrings.CurrentContactLabel,
				"classes": {
					"labelClass": ["current-entity-label"]
				}
			};
		},

		/**
		 * @protected
		 */
		getContactNameConfig: function(item) {
			return {
				"className": "BPMSoft.Hyperlink",
				"href": this._getContactUrl(item.id),
				"caption": {"bindTo": item.columnName.bindTo},
				"classes": {
					"hyperlinkClass": ["contact-name-link"]
				},
				"target": this.BPMSoft.controls.HyperlinkEnums.target.SELF
			};
		},

		// endregion

		// region Methods: Public

		/**
		 * Applies custom control config to the row
		 * @param {Object} control Configuration object.
		 * @param {Object} item Item of grid row element.
		 */
		applyControlConfig: function(control, item) {
			const configItems = [this.getContactNameConfig(item)];
			if (this._isCurrent(item)) {
				configItems.push(this.getCurrentLabelConfig());
			}
			control.config = {
				"className": "BPMSoft.Container",
				"classes": {
					"wrapClassName": ["contact-name-container"]
				},
				"items": configItems
			};
		},

		/**
		 * @inheritdoc DuplicatesDetailViewModelV2#mergeEntityDuplicatesAsync
		 * @override
		 */
		mergeEntityDuplicatesAsync: function () {
			this.callParent(arguments);
			ServiceHelper.callService("OmnichannelChatService", "ClearContactIdentityCache", Ext.emptyFn, {
				contactIds: this.get("SelectedRows")
			}, this);
		}
		
		// endregion

	});
});
