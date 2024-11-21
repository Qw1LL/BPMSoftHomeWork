define("RuleRelationLookupSectionV2", ["RuleRelationLookupSectionV2Resources", "ConfigurationEnums"],
	function(resources, ConfigurationEnums) {
		return {
			entitySchemaName: "RuleRelation",
			attributes: {},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			messages: {},
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
						moduleId: this.getChainCardModuleSandboxId(typeColumnValue),
						instanceConfig: {
							useSeparatedPageHeader: this.get("UseSeparatedPageHeader")
						}
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
				}
			}
		};
	});
