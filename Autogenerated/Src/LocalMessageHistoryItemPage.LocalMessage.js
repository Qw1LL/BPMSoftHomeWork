define("LocalMessageHistoryItemPage", ["css!LocalMessageHistoryItemStyle"],
	function() {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * Returns local message image.
				 * @private
				 * @return {String} Local message image.
				 */
				getLocalMessageImage: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.LocalMessageImage"));
				},

				/**
				 * Returns local message text.
				 * @private
				 * @return {String} Local message text.
				 */
				getLocalMessageText: function() {
					var formatedDate = this.getCreatedOn();
					var message = this.get("Message");
					return message + " " + formatedDate;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "HistoryMessageWrapContainer",
					"values": {
						"wrapClass": ["historyMessageWrap", "historyLocalMessageWrap"],
						"markerValue": "LocalHistoryMessageWrapContainer"
					}
				},
				{
					"operation": "merge",
					"name": "CreatedByImage",
					"values": {
						"getSrcMethod": "getLocalMessageImage"
					}
				},
				{
					"operation": "merge",
					"name": "MessageText",
					"parentName": "MessageBodyContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"id": "MessageText",
								"markerValue": "MessageText",
								"className": "BPMSoft.MultilineLabel",
								"classes": {
									"multilineLabelClass": ["messageText"]
								},
								"caption": {
									"bindTo": "getLocalMessageText"
								},
								"showLinks": true
							};
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
