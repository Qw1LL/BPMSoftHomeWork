define("ActivityPageV2", [], function() {
	return {
		entitySchemaName: "Activity",

		messages: {
			/**
			 * @message GetNewValues
			 * ########### ##### ######## #####.
			 */
			"GetScheduleItemStatus": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message ReloadGridData
			 * ######## ############# ######### # ####### ###### ### ### #########.
			 */
			"ReloadGridData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		methods: {
			/**
			 * ####### ######### ############# ########.
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				var statusId = this.sandbox.publish("GetScheduleItemStatus", null, [this.sandbox.id]);
				if (statusId) {
					this.loadLookupDisplayValue("Status", statusId);
				}
			},

			/**
			 * ######### ############# ########## ######.
			 * @overridden
			 */
			onSaved: function() {
				this.callParent(arguments);
				this.sandbox.publish("ReloadGridData", null, [this.sandbox.id]);
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
