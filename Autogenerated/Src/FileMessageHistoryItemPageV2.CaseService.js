define("FileMessageHistoryItemPageV2", [],
	function() {
		return {
			entitySchemaName: "BaseMessageHistory",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * Opens "Created by" page.
				 * @protected
				 */
				openCreatedByPage: function() {
					if (this.isGeneralUser()) {
						var createdBy = this.get("CreatedBy");
						if (this.Ext.isEmpty(createdBy)) {
							return;
						}
						MaskHelper.ShowBodyMask();
						var hash = NetworkUtilities.getEntityUrl("Contact", createdBy.value);
						this.sandbox.publish("PushHistoryState", {hash: hash});
					}
				},
				/**
				 * @inheritdoc BPMSoft.BaseMessageHistoryPage#getChannelIcon
				 * @overridden
				 */
				getChannelIcon: function () {
					return BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.FileChannelIcon"));
				},
				/**
				 * Check if the current connection is general connection.
				 * @protected
				 * @returns {boolean} True, if connection type is general.
				 */
				isGeneralUser: function() {
					return (this.BPMSoft.CurrentUser.userType !== this.BPMSoft.UserType.SSP);
				},
				/**
				 * Check if the current connection is ssp connection.
				 * @protected
				 * @returns {boolean} True, if connection type is ssp.
				 */
				isSSPUser: function() {
					return (this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "HistoryV2CreatedByLink",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.HYPERLINK,
						"classes": {
							"hyperlinkClass": ["createdByLink"]
						},
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"markerValue": "CreatedByLink",
						"target": this.BPMSoft.controls.HyperlinkEnums.target.SELF,
						"visible": {
							"bindTo": "isGeneralUser",
							"bindConfig": {
								converter: function(value) {
									return !value;
								}
							}
						}
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "HistoryV2CreatedByLabel",
					"parentName": "HeaderCenterContainerTopLine",
					"propertyName": "items",
					"values": {
						"id": "HistoryV2CreatedByLabel",
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getCreatedByName"
						},
						"markerValue": "HistoryV2CreatedByLabel",
						"visible": {
							"bindTo": "isSSPUser"
						}
					},
					"index": 4
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
