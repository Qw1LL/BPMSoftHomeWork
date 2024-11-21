define("CaseStatusLookupSection", ["CaseStatusLookupSectionResources", "ConfigurationEnums", "CasePageUtilitiesV2"],
	function(resources, ConfigurationEnums) {
		return {
			entitySchemaName: "CaseStatus",
			attributes: {},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			messages: {},
			mixins: {
				/**
				 * @class CasePageUtilitiesV2 implements quick save cards in one click.
				 */
				CasePageUtilitiesV2: "BPMSoft.CasePageUtilitiesV2"
			},
			methods: {
				/**
				 * ######### ######## ########## ######
				 * @protected
				 */
				addRecord: function(typeColumnValue) {
					if (!typeColumnValue) {
						var editPages = this.get("EditPages");
						if (editPages.getCount() > 1) {
							return false;
						}
						var tag = this.get("AddRecordButtonTag");
						typeColumnValue = tag || this.BPMSoft.GUID_EMPTY;
					}
					var schemaName = this.getEditPageSchemaName(typeColumnValue);
					if (!schemaName) {
						return;
					}
					this.openCardInChain({
						schemaName: schemaName,
						operation: ConfigurationEnums.CardStateV2.ADD,
						moduleId: this.getChainCardModuleSandboxId(typeColumnValue)
					});
				},
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getModuleCaption
				 * @overridden
				 */
				getModuleCaption: function() {
					var historyState = this.sandbox.publish("GetHistoryState");
					var state = historyState.state;
					if (state && state.caption) {
						return state.caption;
					}
					if (this.entitySchema) {
						var headerTemplate = this.get("Resources.Strings.HeaderCaption");
						return Ext.String.format(headerTemplate, this.entitySchema.caption);
					}
				},
				/**
				 * Update CaseStatusCache on change value
				 * @overridden
				 */
				onActiveRowChange: function() {
					this.getCaseNextStatuses();
					this.callParent(arguments);
				}
			}
		};
	});
