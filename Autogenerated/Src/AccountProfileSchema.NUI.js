/**
 * Account profile class.
 * @class BPMSoft.AccountProfileSchema
 */
define("AccountProfileSchema", ["CommunicationOptionsMixin"],
		function() {
			return {
				entitySchemaName: "Account",
				messages: {
					/**
					 * @message CallCustomer
					 * Starts phone call in CTI panel.
					 */
					"CallCustomer": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				mixins: {
					/**
					 * @class CommunicationOptionsMixin Mixin, implements communication options usage methods.
					 */
					CommunicationOptionsMixin: "BPMSoft.CommunicationOptionsMixin"
				},
				methods: {

					//Region Methods: Public

					init: function(callback, scope) {
						this.callParent([function() {
							this.initSyncMailboxCount(callback, scope);
						}, this]);
					},

					/**
					 * Starts call in CTI panel.
					 * @param {String} number Phone number to call.
					 * @return {Boolean} False, to stop click event propagation.
					 */
					onCallClick: function(number) {
						return this.callAccount(number, this.$Id);
					},
	
					/**
					 * Generates href config for setLinkValue method of BPMSoft.BaseEdit
					 * @param {String | undefined } name View model Name field value
					 * @returns {{caption: String, url: String}} Config to show value as link in control
					 */
					generateAccountLink: function (name) {
						return {
							url: name ? this.getProfileHeaderURL() : '',
							caption: name ? name : ''
						}
					},

					//endregion

				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "ProfileHeaderValue"
					},
					{
						"operation": "merge",
						"name": "ProfileModuleContainer",
						"values": {
							"wrapClass": ["profile-module-container", "account-profile"]
						}
					},
					{
						"operation": "insert",
						"name": "Name",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Name",
							"enabled": false,
							"showValueAsLink": true,
							"href":  {
								"bindTo": "Name",
								"bindConfig": {converter: "generateAccountLink"}
							},
							"controlConfig": {
								"linkmouseover": {"bindTo": "onProfileLinkMouseOver"}
							},
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Owner",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Owner",
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Type",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Type",
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Web",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Web",
							"showValueAsLink": true,
							"href":  {
								"bindTo": "Web",
								"bindConfig": {converter: "getLinkValue"}
							},
							"linkclick": {
								"bindTo": "openNewTab"
							},
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 4,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Phone",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.PhoneEdit",
							"bindTo": "Phone",
							"showValueAsLink": {"bindTo": "isTelephonyEnabled"},
							"href":  {
								"bindTo": "Phone",
								"bindConfig": {converter: "getLinkValue"}
							},
							"linkclick": {
								"bindTo": "onCallClick"
							},
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 5,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "AccountCategory",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "AccountCategory",
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 6,
								"colSpan": 24
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"name": "Industry",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Industry",
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 7,
								"colSpan": 24
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
