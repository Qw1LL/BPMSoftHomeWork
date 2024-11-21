define("BaseCampaignPage", ["MarketingEnums", "EntityHelper"], function(MarketingEnums) {
	return {
		entitySchemaName: "Campaign",
		mixins: {
			EntityHelper: "BPMSoft.EntityHelper"
		},
		attributes: {
			"IsStatusEnabled": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				dependencies: [{
					columns: ["CampaignStatus"],
					methodName: "onCampaignStatusChanged"
				}]
			},
			"IsStatusInProgress": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				dependencies: [{
					columns: ["CampaignStatus"],
					methodName: "onCampaignStatusChanged"
				}]
			},
			"IsStatusFinal": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				dependencies: [{
					columns: ["CampaignStatus"],
					methodName: "onCampaignStatusChanged"
				}]
			}
		},
		details: /**SCHEMA_DETAILS*/{
			Files: {
				schemaName: "FileDetailV2",
				entitySchemaName: "CampaignFile",
				filter: {
					masterColumn: "Id",
					detailColumn: "Campaign"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentContainer",
				"values": {
					"wrapClass": ["campaign-card-content-container", "center-main-container"]
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE
				}
			},
			{
				"operation": "merge",
				"name": "TabsContainer",
				"values": {
					"wrapClass": ["tabs-container"]
				}
			},
			{
				"operation": "remove",
				"name": "GeneralInfoTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.GeneralInfoTabCaption"
					},
					"items": []
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},

			//region Tabs: Notes And Files

			{
				"operation": "insert",
				"name": "NotesAndFilesTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 4,
				"values": {
					"caption": {"bindTo": "Resources.Strings.NotesAndFilesTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "NotesAndFilesTab",
				"propertyName": "items",
				"name": "Files",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"name": "NotesControlGroup",
				"parentName": "NotesAndFilesTab",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
					"controlConfig": {
						"collapsed": false
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "NotesControlGroup",
				"propertyName": "items",
				"name": "Notes",
				"values": {
					"contentType": BPMSoft.ContentType.RICH_TEXT,
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"imageLoaded": {
							"bindTo": "insertImagesToNotes"
						},
						"images": {
							"bindTo": "NotesImagesCollection"
						}
					}
				}
			}

			//endregion

		]/**SCHEMA_DIFF*/,
		methods: {

			/**
			 * Entity initialization handler.
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.onCampaignStatusChanged();
				if (this.isNew) {
					var targetDescriptionDefaultValue = this.get("Resources.Strings.TargetDescriptionDefaultValue");
					this.set("TargetDescription", targetDescriptionDefaultValue);
				}
			},

			/**
			 * @inheritDoc BPMSoft.DcmMixin#initCanOpenDcmPageInSectionWizard
			 * @override
			 */
			initCanOpenDcmPageInSectionWizard: function() {
				this.set("CanOpenDcmPageInSectionWizard", false);
			},

			/**
			 * Handles the Tabs change tab event.
			 * @protected
			 * @override
			 * @param {BPMSoft.BaseViewModel} activeTab Selected tab.
			 */
			activeTabChange: function(activeTab) {
				this.set("ActiveTabName", activeTab.get("Name"));
				this.callParent(arguments);
			},

			/**
			 * Gets campaign status.
			 * @returns {Object} Campaign status.
			 */
			onGetCampaignStatus: function() {
				return {
					campaignStatusId: this.get("CampaignStatus") ? this.get("CampaignStatus").value : null
				};
			},

			/**
			 * Campaign status change handler.
			 */
			onCampaignStatusChanged: function() {
				var status = this.get("CampaignStatus").value;
				var isFinal = ((status === MarketingEnums.CampaignStatus.STOPPED) ||
					(status === MarketingEnums.CampaignStatus.CANCELED));
				var isStarted = (status === MarketingEnums.CampaignStatus.STARTED);
				var isEnabled = (isFinal || isStarted);
				this.set("IsStatusEnabled", !isEnabled);
				this.set("IsStatusInProgress", isStarted);
				this.set("IsStatusFinal", isFinal);
			},

			/**
			 * Reloads card fields for page entity.
			 * @protected
			 * @param {Array} fields List of fields to refresh.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 */
			reloadFields: function(fields, callback, scope) {
				if (!this.Ext.isArray(fields) || fields.length === 0) {
					return;
				}
				var fieldsQuantity = fields.length;
				var selectNewValues = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName
				});
				for (var i = 0; i < fieldsQuantity; i++) {
					selectNewValues.addColumn(fields[i]);
				}
				var id = this.get("Id");
				selectNewValues.getEntity(id, function(result) {
					var entity = result.entity;
					if (entity) {
						fields.forEach(function(element) {
							var newValue = entity.get(element);
							this.set(element, newValue);
						}, this);
						this.set("ShowSaveButton", false);
						this.set("ShowDiscardButton", false);
						this.set("ShowCloseButton", true);
						callback.call(scope);
					}
				}, this);
			}
		}
	};
});
