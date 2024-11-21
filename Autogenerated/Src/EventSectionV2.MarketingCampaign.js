define("EventSectionV2", ["SegmentsStatusUtils"],
function(SegmentsStatusUtils) {
	return {
		entitySchemaName: "Event",
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		messages: {},
		methods: {
			/**
			 * ##### ######## "######## ###### #####".
			 * @protected
			 */
			updateContactList: function() {
				var activeRow = this.getActiveRow();
				var eventId = activeRow.get("Id");
				this.callService({
					serviceName: "MandrillService",
					methodName: "UpdateTargetAudience",
					data: {schemaName: "Event", recordId: eventId}
				}, this.onUpdateContactListLaunched, this);
			},

			/*
			 * ########## ######## # #########.
			 * @protected
			 */
			onUpdateContactListLaunched: function() {
				var scope = this;
				setTimeout(function() {
					var activeRow = scope.getActiveRow();
					var eventId = activeRow.get("Id");
					if (scope.get("IsCardVisible")) {
						scope.editRecord(eventId);
					}
				}, SegmentsStatusUtils.timeoutBeforeUpdate);
			}
		}
	};
});
