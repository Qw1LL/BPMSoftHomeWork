define("ConfItemInContactDetail", ["ServiceDeskConstants"],
	function(ServiceDeskConstants) {
		return {
			entitySchemaName: "ConfItemUser",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#initConfig
				 * @overridden
				 */
				initConfig: function() {
					this.callParent(arguments);
					var config = this.getConfig();
					config.lookupEntitySchema = config.lookupConfig.entitySchemaName = "ConfItem";
					config.sectionEntitySchema = "Contact";
				},

				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initConfig();
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "ConfItem";
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseManyToManyGridDetail#getSchemaInsertQuery
				 * @overridden
				 */
				getSchemaInsertQuery: function() {
					var insert = this.callParent(arguments);
					insert.setParameterValue("Type", ServiceDeskConstants.ServiceObjectType.Contact,
						this.BPMSoft.DataValueType.GUID);
					return insert;
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
