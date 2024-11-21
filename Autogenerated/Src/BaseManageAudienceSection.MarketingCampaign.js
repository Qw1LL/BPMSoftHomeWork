define("BaseManageAudienceSection", ["BaseManageAudienceSectionResources"],
	function(resources) {
		return {
			properties: {
				/**
				 * Audience delete mode.
				 * @type {Object}
				 */
				deleteMode: {
					SELECTED: 0,
					FOLDER: 1,
					FILTERED: 2,
					AUDIENCE: 3
				},

				/**
				 * Bulk email audience extended entity schema name.
				 * @type {String}
				 */
				audienceSchemaName: null,

				/**
				 * Audience extended entity schema.
				 * @type {Object}
				 */
				audienceSchema: null,

				/**
				 * Master record entity schema name to filter audience.
				 * @type {String}
				 */
				masterRecordEntitySchemaName: null
			},
			methods: {

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
				* @override
				*/
				getModuleCaption: function() {
					return Ext.String.format(resources.localizableStrings.SectionCaption, this.$RecordName);
				},

				/**
				* @inheritdoc BPMSoft.BaseDataView#getQuickFilterModuleId
				* @override
				*/
				getQuickFilterModuleId: function() {
					var baseFilterModuleId = this.callParent(arguments);
					return this.audienceSchemaName + baseFilterModuleId;
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getFiltersKey
				 * @override
				 */
				getFiltersKey: function() {
					var baseFilterKey = this.callParent(arguments);
					return this.audienceSchemaName + baseFilterKey;
				},

				/**
				 * @inheritdoc BPMSoft.BaseAudienceSection#getSessionFiltersKey
				 * @override
				 */
				getSessionFiltersKey: function() {
					var baseSessionFilterKey = this.callParent(arguments);
					return this.audienceSchemaName + baseSessionFilterKey;
				},

				/**
				 * @inheritdoc BPMSoft.BaseAudienceSection#initSection
				 * @override
				 */
				initSection: function() {
					this.callParent(arguments);
					this.$IsSummarySettingsVisible = false;
					this.$ProcessAudienceButtonCaption = resources.localizableStrings.RemoveAudienceButtonCaption;
				},

				/**
				* @inheritdoc BPMSoft.BaseSectionV2#init
				* @override
				*/
				init: function() {
					BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE,
						this.onChannelMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BaseObject#destroy
				 * @override
				 */
				destroy: function() {
					this.BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE,
						this.onChannelMessageReceived, this);
					this.callParent(arguments);
				},

				/**
				 * Handler on WebSocket channel message received event.
				 * @abstract
				 * @param {BPMSoft.ServerChannel} channel WebSocket channel instance.
				 * @param {Object} message WebSocket message instance.
				 */
				onChannelMessageReceived: BPMSoft.abstractFn,

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getGridDataESQ
				 * @override
				 */
				getGridDataESQ: function() {
					var esq = this.callParent(arguments);
					var recordIdFilter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, this.masterRecordEntitySchemaName, this.$RecordId);
					esq.filters.addItem(recordIdFilter);
					return esq;
				},

				/**
				 * Returns specific config for bulk email audience service to provide remove audience action.
				 * @protected
				 * @abstract
				 * @param {Number} sourceType Source type for remove action.
				 * @param {Array} sourceCollection Source data collection to remove.
				 * @param {Number} estimatedCount Estimated records count to remove.
				 * @param {String} esqSerialized Serialized esq to filter records for remove.
				 * @returns {Object}
				 */
				getRemoveAudienceConfig: BPMSoft.abstractFn,

				/**
				 * Calls audience service to remove selected records by ids.
				 * @protected
				 */
				processSelectedRecords: function() {
					var estimatedCount = this.$SelectedRows.length;
					var config = this.getRemoveAudienceConfig(this.deleteMode.SELECTED, this.$SelectedRows, estimatedCount);
					this.callService(config, this.onProcessAudienceCompleted, this);
				},

				/**
				 * Calls audience service to remove records by serialized esq with filters.
				 * @protected
				 */
				processRecordsByFilter: function() {
					var esq = this.getEsqWithFilters();
					var estimatedCount = this.$EstimatedRecordsCount;
					var esqJson = esq.serialize();
					var config = this.getRemoveAudienceConfig(this.deleteMode.FILTERED, [], estimatedCount, esqJson);
					this.callService(config, this.onProcessAudienceCompleted, this);
				},

				/**
				 * Handler on remove audience completed event.
				 * @protected
				 * @param {Object} result Service response result.
				 */
				onProcessAudienceCompleted: function(result) {
					if (result.Success) {
						this.updateSection();
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * Returns collection of remove audience button menu items.
				 * @protected
				 * @returns {BPMSoft.BaseViewModelCollection}
				 */
				getRemoveAudienceMenuItems: function() {
					var items = new BPMSoft.BaseViewModelCollection();
					items.add(new BPMSoft.BaseViewModel({
						values: {
							"Caption": "$Resources.Strings.RemoveSelectedMenuItemCaption",
							"Click": "$onProcessSelectedRecordsClick",
							"Enabled": "$isAnyRowSelected",
							"Tag": "removeSelected"
						}
					}));
					items.add(new BPMSoft.BaseViewModel({
						values: {
							"Caption": "$Resources.Strings.RemoveByFilterMenuItemCaption",
							"Click": "$onProcessByFilterClick",
							"Enabled": "$CanProcessByFilter",
							"Tag": "removeByFilter"
						}
					}));
					return items;
				},

				/**
				 * @inheritdoc BPMSoft.BaseAudienceSection#getProcessSelectedConfirmationMessage
				 * @override
				 */
				getProcessSelectedConfirmationMessage: function() {
					return this.get("Resources.Strings.OnRemoveSelectedRecordsMessage");
				},

				/**
				 * @inheritdoc BPMSoft.BaseAudienceSection#getProcessByFilterConfirmationMessage
				 * @override
				 */
				getProcessByFilterConfirmationMessage: function() {
					return this.get("Resources.Strings.OnRemoveByFilterMessage");
				},

				/**
				 * @inheritdoc BPMSoft.BaseAudienceSection#getProcessAudienceButtonCaption
				 * @override
				 */
				getProcessAudienceButtonCaption: function() {
					return this.get("Resources.Strings.RemoveAudienceButtonCaption");
				},

				/**
				 * @inheritdoc BPMSoft.BaseAudienceSection#getSelectedRecordsLimitReachedMessage
				 * @override
				 */
				getSelectedRecordsLimitReachedMessage: function() {
					return this.get("Resources.Strings.SelectedRecordsLimitReachedMessage");
				}
			},
			diff: [
				{
					"operation": "insert",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"name": "RemoveAudienceButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": "$ProcessAudienceButtonCaption",
						"classes": {
							"wrapperClass": ["actions-button-margin-right"]
						},
						"menu": {
							"items": "$getRemoveAudienceMenuItems"
						}
					}
				},
				{
					"operation": "merge",
					"name": "CloseAudienceSectionButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				},
			]
		};
	}
);
