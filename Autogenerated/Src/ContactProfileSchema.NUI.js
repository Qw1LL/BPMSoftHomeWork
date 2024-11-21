/**
 * Contact profile class.
 * @class BPMSoft.ContactProfileSchema
 */
define("ContactProfileSchema", ["ProfileSchemaMixin", "CommunicationOptionsMixin"],
		function() {
			return {
				entitySchemaName: "Contact",
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
					 * @class ProfileSchemaMixin Mixin.
					 */
					ProfileSchemaMixin: "BPMSoft.ProfileSchemaMixin",
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
						return this.callContact(number, this.$Id);
					}

					//endregion

				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "ProfileModuleContainer",
						"values": {
							"wrapClass": ["profile-module-container", "contact-profile"]
						}
					},
					{
						"operation": "insert",
						"name": "Job",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "JobTitle",
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
						"name": "MobilePhone",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.PhoneEdit",
							"bindTo": "MobilePhone",
							"showValueAsLink": {"bindTo": "isTelephonyEnabled"},
							"href":  {
								"bindTo": "MobilePhone",
								"bindConfig": {converter: "getLinkValue"}
							},
							"linkclick": {
								"bindTo": "onCallClick"
							},
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
								"row": 4,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "Email",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Email",
							"showValueAsLink": true,
							"href":  {
								"bindTo": "Email",
								"bindConfig": {converter: "getLinkValue"}
							},
							"linkclick": {
								"bindTo": "sendEmail"
							},
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 5,
								"colSpan": 24
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
