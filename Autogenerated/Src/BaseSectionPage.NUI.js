define("BaseSectionPage", ["NotesUtilities", "TagUtilitiesV2"], function() {
	return {
		attributes: {
			/**
			 * Notes image collection.
			 * @type {BPMSoft.Collection}
			 */
			"NotesImagesCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},
			/**
			 * Indicating tag accessibility.
			 * @type {Boolean}
			 */
			"UseTagModule": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		mixins: {
			/**
			 * @class TagUtilities implements work with the tag module.
			 */
			TagUtilities: "BPMSoft.TagUtilities",
			/**
			 * @class NotesUtilities implements work with the notes.
			 */
			NotesUtilities: "BPMSoft.NotesUtilities"
		},
		messages: {
			/**
			 * @message TagChanged
			 * Updates number of tags in the button.
			 */
			"TagChanged": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetRecordId
			 * Returns current edited record identifier.
			 */
			"GetRecordId": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Create tag module identifier.
			 * @private
			 * @return {string} Tag module identifier.
			 */
			getTagModuleSandboxId: function() {
				return this.sandbox.id + "_TagModule";
			},

			/**
			 * Updates "Attachments and notes" details.
			 * @private
			 */
			updateFileDetail: function() {
				this.updateDetail({detail: "Files"});
			},

			//endregion

			//region Methods: Protected

			/**
			 * Tag button handler.
			 * @protected
			 */
			onTagButtonClick: function() {
				if (this.isAddMode() || this.isEditMode() || this.isCopyMode()) {
					this.saveCardAndLoadTags();
				} else {
					this.showTagModule();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onPageInitialized
			 * @overridden
			 */
			onPageInitialized: function(callback, scope) {
				this.callParent([function() {
					this.initNotesImagesCollection();
					this.initTags(this.entitySchemaName);
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				if (this.get("IsSeparateMode")) {
					this.initTagButton();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("GetRecordId", this.getCurrentRecordId, this, [this.sandbox.id]);
				this.sandbox.subscribe("TagChanged", this.reloadTagCount, this, [this.getTagModuleSandboxId()]);
			},

			/**
			 * @inheritdoc BPMSoft.NotesUtilities#onNotesImagesUpload
			 * @overridden
			 */
			onNotesImagesUpload: function() {
				this.showBodyMask();
			},

			/**
			 * @inheritdoc BPMSoft.NotesUtilities#onNotesImagesUploadComplete
			 * @overridden
			 */
			onNotesImagesUploadComplete: function() {
				this.hideBodyMask();
				this.updateFileDetail();
			},

			/**
			 * @inheritdoc BPMSoft.NotesUtilities#getFileEntitySchemaName
			 * @overridden
			 */
			getFileEntitySchemaName: function() {
				return this.entitySchema.name + "File";
			},

			/**
			 * @inheritdoc BPMSoft.TagUtilities#getCurrentRecordId
			 * @overridden
			 */
			getCurrentRecordId: function() {
				return this.get("Id");
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#initContainersVisibility
			 * @overridden
			 */
			initContainersVisibility: function() {
				this.callParent(arguments);
				if (this.getIsFeatureDisabled("OldUI")) {
					this.set("IsActionDashboardContainerVisible", true);
				}
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"name": "TagButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "TagButtonCaption"},
					"hint": {"bindTo": "Resources.Strings.TagButtonHint"},
					"imageConfig": {"bindTo": "Resources.Images.TagButtonIcon"},
					"click": {"bindTo": "onTagButtonClick"},
					"classes": {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					"visible": {"bindTo": "TagButtonVisible"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
 