/**
 * Client contact profile class.
 * @class BPMSoft.ClientContactProfileSchema
 */
define("ClientContactProfileSchema", ["ProfileSchemaMixin", "CommunicationOptionsMixin"],
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
					},

					/**
					 * @message GetEntityInfo
					 * Returns information about master entity for minipage.
					 */
					"GetMiniPageMasterEntityInfo": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {
					/**
					 * Related page column name.
					 * @type {String}
					 */
					"RelatedPageRecordColumn": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: "Opportunity"
					}
				},
				mixins: {
					ProfileSchemaMixin: "BPMSoft.ProfileSchemaMixin",
					/**
					 * @class CommunicationOptionsMixin Mixin, implements communication options usage methods.
					 */
					CommunicationOptionsMixin: "BPMSoft.CommunicationOptionsMixin"
				},
				methods: {
					
					//Region Methods: Public

					/**
					 * @inheritdoc BPMSoft.BaseProfileSchema#getProfileHeaderCaption
					 * @overridden
					 */
					getProfileHeaderCaption: function() {
						return this.get("Resources.Strings.ProfileHeaderCaption");
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent([function() {
							this.initSyncMailboxCount(callback, scope);
						}, this]);
					},

					/**
					 * Returns parent module sandbox id for passed module sandbox id.
					 * @protected
					 * @param {String} moduleSandboxId Module sandbox id.
					 * @return {String} Parent module sandbox id.
					 */
					getParentModuleSandboxId:function(moduleSandboxId) {
						var parentModileId = this.mixins.CommunicationOptionsMixin.getParentModuleSandboxId(moduleSandboxId);
						return this.mixins.CommunicationOptionsMixin.getParentModuleSandboxId(parentModileId);
					},

					/**
					 * Starts call in CTI panel.
					 * @param {String} number Phone number to call.
					 * @return {Boolean} False, to stop click event propagation.
					 */
					onCallClick: function(number) {
						return this.callContactWithRelations(number, this.$Id, this.getProfileRelationFields());
					}

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
							"wrapClass": ["profile-module-container", "contact-profile"]
						}
					},
					{
						"operation": "insert",
						"name": "Name",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"bindTo": "Name",
							"showValueAsLink": true,
							"href": {
								"bindTo": "Name",
								"bindConfig": { converter: "getLinkValue" }
							},
							"linkclick": {
								"bindTo": "onProfileHeaderClick"
							},
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24
							}
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
