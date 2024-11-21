define("EventSegmentDetailV2", [],
		function() {
			return {
				entitySchemaName: "EventSegment",
				methods: {
					/**
					 * ############## ######.
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.set("ParentEntitySchemaName", "Event");
					}
				}
			};
		}
);
