define("BaseImportAudienceSection", ["BaseImportAudienceSectionResources"],
	function(resources) {
		return {
			properties: {
				/**
				 * Audience import mode.
				 * @type {Object}
				 */
				importMode: {
					SELECTED: 0,
					BY_FOLDER: 1,
					BY_FILTER: 2
				},
				/**
				 * Audience schema unique identifier of current bulk email for audience import.
				 * @type {String}
				 */
				audienceSchemaId: null
			},
			methods: {

				/**
				 * @private
				 */
				_initEntitySchemaName: function() {
					var historyState = this.sandbox.publish("GetHistoryState");
					if (historyState && historyState.state && historyState.hash) {
						this.entitySchemaName = historyState.state.entitySchema || historyState.hash.operationType;
						this.audienceSchemaId = historyState.state.audienceSchemaId || historyState.hash.recordId;
					}
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
				* @override
				*/
				getModuleCaption: function() {
					return Ext.String.format(resources.localizableStrings.SectionCaption, this.$RecordName);
				},

				/**
				 * @inheritdoc BPMSoft.BaseBulkEmailAudienceSection#initSection
				 * @override
				 */
				initSection: function() {
					this.callParent(arguments);
					if (this.entitySchemaName === "Contact") {
						this.set("UseStaticFolders", true);
					}
					this.$ProcessAudienceButtonCaption = resources.localizableStrings.ImportAudienceButtonCaption;
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#init
				* @override
				*/
				init: function() {
					this._initEntitySchemaName();
					this.callParent(arguments);
				},

				/**
				 * Calls audience service to import selected records by ids.
				 * @protected
				 */
				processSelectedRecords: function() {
					var estimatedCount = this.$SelectedRows.length;
					var config = this.getImportConfig(this.importMode.SELECTED, this.$SelectedRows, estimatedCount);
					this.callService(config, this.onProcessAudienceCompleted, this);
				},

				/**
				 * Calls audience service to import filtered records by current folder.
				 * @protected
				 */
				processRecordByFolder: function() {
					var folder = this.get("CurrentFolder");
					var sourceCollection = [folder.value];
					var estimatedCount = this.$EstimatedRecordsCount;
					var config = this.getImportConfig(this.importMode.BY_FOLDER, sourceCollection, estimatedCount);
					this.callService(config, this.onProcessAudienceCompleted, this);
				},

				/**
				 * Calls audience service to import records by serialized esq with filters.
				 * @protected
				 */
				processRecordsByFilter: function() {
					var esq = this.getEsqWithFilters();
					var estimatedCount = this.$EstimatedRecordsCount;
					var esqJson = esq.serialize();
					var config = this.getImportConfig(this.importMode.BY_FILTER, [], estimatedCount, esqJson);
					this.callService(config, this.onProcessAudienceCompleted, this);
				},

				/**
				 * Returns collection of import audience button menu items.
				 * @protected
				 * @returns {BPMSoft.BaseViewModelCollection}
				 */
				getImportAudienceMenuItems: function() {
					var items = new BPMSoft.BaseViewModelCollection();
					items.add(new BPMSoft.BaseViewModel({
						values: {
							"Caption": "$Resources.Strings.ImportSelectedMenuItemCaption",
							"Click": "$onProcessSelectedRecordsClick",
							"Enabled": "$isAnyRowSelected",
							"Tag": "importSelected"
						}
					}));
					items.add(new BPMSoft.BaseViewModel({
						values: {
							"Caption": "$Resources.Strings.ImportByFilterMenuItemCaption",
							"Click": "$onProcessByFilterClick",
							"Enabled": "$CanProcessByFilter",
							"Tag": "importByFilter"
						}
					}));
					return items;
				},

				/**
				 * @inheritdoc BPMSoft.BaseBulkEmailAudienceSection#getProcessSelectedConfirmationMessage
				 * @override
				 */
				getProcessSelectedConfirmationMessage: function() {
					var messageTpl = resources.localizableStrings.OnImportSelectedRecordsMessage;
					return Ext.String.format(messageTpl, this.$SelectedRows.length);
				},

				/**
				 * @inheritdoc BPMSoft.BaseBulkEmailAudienceSection#getProcessByFilterConfirmationMessage
				 * @override
				 */
				getProcessByFilterConfirmationMessage: function() {
					var messageTpl = resources.localizableStrings.OnImportByFilterMessage;
					return Ext.String.format(messageTpl, this.$SelectedRows.length);
				},

				/**
				 * @inheritdoc BPMSoft.BaseBulkEmailAudienceSection#getProcessAudienceButtonCaption
				 * @override
				 */
				getProcessAudienceButtonCaption: function() {
					return resources.localizableStrings.ImportAudienceButtonCaption;
				},

				/**
				 * @inheritdoc BPMSoft.BaseBulkEmailAudienceSection#getSelectedRecordsLimitReachedMessage
				 * @override
				 */
				getSelectedRecordsLimitReachedMessage: function() {
					return resources.localizableStrings.SelectedRecordsLimitReachedMessage;
				}
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"name": "ImportAudienceButton",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": "$ProcessAudienceButtonCaption",
						"classes": {
							"wrapperClass": ["actions-button-margin-right"]
						},
						"menu": {
							"items": "$getImportAudienceMenuItems"
						}
					}
				}
			]
		};
	}
);
