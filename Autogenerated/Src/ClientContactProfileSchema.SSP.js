define("ClientContactProfileSchema", ["ProfileSchemaMixin", "CommunicationOptionsMixin"],
	function() {
		return {
			entitySchemaName: "Contact",
			messages: {
				"ContactSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {},
			mixins: {},
			methods: {
				/**
				 * @inheritDoc BaseProfileSchema#getMiniPageConfig
				 * @override
				 */
				getMiniPageConfig: function() {
					const parentConfig = this.callParent(arguments);
					if (BPMSoft.isCurrentUserSsp()) {
						parentConfig.miniPageSchemaName="PortalContactMiniPage";
						parentConfig.operation = BPMSoft.ConfigurationEnums.CardOperation.EDIT;
					}
					return parentConfig;
				},

				/**
				 * @inheritDoc BaseProfileSchema#onProfileHeaderClick
				 * @override
				 */
				onProfileHeaderClick: function(options) {
					if (BPMSoft.isCurrentUserSsp()) {
						var config = this.getMiniPageConfig(options);
						this.openMiniPage(config);
						return false;
					}
					return this.callParent(arguments);
				},

				/**
				 * @inheritDoc BaseProfileSchema#onProfileLinkMouseOver
				 * @override
				 */
				onProfileLinkMouseOver: function() {
					if (BPMSoft.isCurrentUserSsp()) {
						return;
					}
					this.callParent(arguments);
				},

				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.subscribeUpdateProfile();
				},

				subscribeUpdateProfile: function() {
					this.sandbox.subscribe("ContactSaved", this.updateProfile, this, [this.sandbox.id]);
				},

				updateProfile: function() {
					this.initEntity();
				},

				getProfileHeaderLabelValue: function() {
					return this.get("Resources.Strings.ProfileHeaderValueLabel");
				}
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
						"showValueAsLink": { "bindTo": "isTelephonyEnabled" },
						"href": {
							"bindTo": "MobilePhone",
							"bindConfig": { converter: "getLinkValue" }
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
						"showValueAsLink": { "bindTo": "isTelephonyEnabled" },
						"href": {
							"bindTo": "Phone",
							"bindConfig": { converter: "getLinkValue" }
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
						"href": {
							"bindTo": "Email",
							"bindConfig": { converter: "getLinkValue" }
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
