define("EmailMessagePublisherPage", ["EmailsSearchMixin", "RecipientsSearchLookupEdit"],
		function() {
			return {
				entitySchemaName: "Activity",
				mixins: {
					/**
					 * Mixin using to Elasticsearch for seacrh emails.
					 */
					EmailsSearchMixin: "BPMSoft.EmailsSearchMixin"
				},
				attributes: {
					/**
					 * Copy recipient lookup.
					 */
					"CopyRecipient": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"referenceSchemaName": "VwRecepientEmail"
					},

					/**
					 * Blind copy recipient lookup.
					 */
					"BlindCopyRecipient": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"referenceSchemaName": "VwRecepientEmail"
					},

					/**
					 * Recipient lookup.
					 */
					"Recipient": {
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"referenceSchemaName": "VwRecepientEmail"
					}
				},
				methods: {

					// region Method: Protected

					/**
					 * Set recipient from string.
					 * @protected
					 * @param {String} emails
					 * @param lookupName
					 */
					setRecipient: function(emails, lookupName) {
						if(Ext.isEmpty(emails)){
							return;
						}
						emails.split(this.emailSeparate).forEach(function(email){
							if (!Ext.isEmpty(email)) {
								var lookupValue = this.createLookupValue(email, email);
								this.saveLookupValues(lookupValue, lookupName);
								this.setLookupValues(lookupValue, lookupName);
							}
						}, this);
					},

					/**
					 * @inheritdoc BPMSoft.EmailMessagePublisherPage#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.set("To", "To");
						this.set("Cc", "Cc");
						this.set("Bcc", "Bcc");
					},

					/**
					 * @inheritdoc BPMSoft.BaseMessagePublisherPage#onPublished
					 * @overridden
					 */
					onPublished: function() {
						this.callParent(arguments);
						if (this.isFeatureEmailsSearchDisabled()) {
							return;
						}
						BPMSoft.each(["Recipient", "CopyRecipient", "BlindCopyRecipient"], this.clearLookup, this);
					},

					/**
					 * @inheritdoc BPMSoft.EmailMessagePublisherPage#setDefaultRecepient
					 * @overridden
					 */
					setDefaultRecepient: function() {
						if (this.isFeatureEmailsSearchDisabled()) {
							this.callParent(arguments);
							return;
						}
						var config = this.getListenerRecordData();
						if (!config) {
							return;
						}
						var lookupName = "Recipient";
						var info = config.additionalInfo;
						var lookupValue = null;
						if (info && info.recepient) {
							var recipient = info.recepient;
							var email = this.getEmailFromText(recipient);
							var emailWitName = this.getPreparedEmailWithName(recipient);
							if (email) {
								lookupValue = this.createLookupValue(emailWitName, emailWitName);
								this.saveLookupValues(lookupValue, lookupName);
							}
						}
						this.setLookupValues(lookupValue, lookupName);
					},

					/**
					 * @inheritdoc BPMSoft.EmailMessagePublisherPage#setRecipientValue
					 * @overridden
					 */
					setRecipientValue: function(data) {
						this.callParent(arguments);
						if (this.isFeatureEmailsSearchDisabled()) {
							return;
						}
						var email =  data && (data.email || data.searchValue);
						this.setRecipient(email, "Recipient");
					},

					/**
					 * @inheritdoc BPMSoft.EmailMessagePublisherPage#onGetMacrosData
					 * @overridden
					 */
					onGetMacrosData: function(args) {
						this.callParent(arguments);
						if (this.isFeatureEmailsSearchDisabled()) {
							return;
						}
						this.setRecipient(args.recepient, "Recipient");
						this.setRecipient(args.copyRecepient, "CopyRecipient");
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#onLookupResult
					 * @override
					 */
					onLookupResult: function(args) {
						if (this.isFeatureEmailsSearchDisabled()) {
							this.callParent(arguments);
							return;
						}
						if (args && args.selectedRows && args.columnName) {
							var columnName = args.columnName;
							var currentLookup = this.getCurrentLookupConfig(columnName);
							var oldValues = currentLookup.oldValues;
							var displayValues = args.selectedRows.getItems().map(function(item) {
								var email = item.Email;
								if (!oldValues.contains(email)) {
									oldValues.add(email, email);
								}
								return email;
							});
							var lookupItem = {
								value: displayValues.pop(),
								displayValue: this.getActualDisplayValue(columnName)
							};
							currentLookup.lookupValue = lookupItem;
							this.setLookupValues(lookupItem, columnName);
						}
					},

					/**
					 * @inheritdoc BPMSoft.LookupQuickAddMixin#getLookupPageConfig
					 * @override
					 */
					getLookupPageConfig: function() {
						var config = this.callParent(arguments);
						if (this.isFeatureEmailsSearchEnabled()) {
							config.multiSelect = true;
						}
						return config;
					},

					/**
					 * @inheritdoc BPMSoft.EmailMessagePublisherPage#onDashboardRealoaded
					 * @override
					 */
					onDashboardRealoaded: function() {
						BPMSoft.each(["Recipient", "CopyRecipient", "BlindCopyRecipient"], this.clearLookup, this);
						this.callParent(arguments);
					}

					// endregion

				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "MainGridLayout",
						"name": "ToContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							}
						}
					},
					{
						"operation": "remove",
						"name": "Recepient"
					},
					{
						"operation": "insert",
						"parentName": "ToContainer",
						"propertyName": "items",
						"name": "Recepient",
						"values": {
							"bindTo": "Recepient",
							"controlConfig": {
								"className": "BPMSoft.TextEdit",
								"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
								"rightIconClick": {
									"bindTo": "openRecepientLookupEmail"
								}
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchDisabled"
							},
							"markerValue": "To"
						}
					},
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "ToContainer",
						"name": "Recipient",
						"values": {
							"controlConfig": {
								"className": "BPMSoft.RecipientsSearchLookupEdit",
								"prepareList": {
									"bindTo": "callSearchService"
								},
								"href": "",
								"change": {
									"bindTo": "saveLookupValues"
								},
								"value": {
									"bindConfig": {
										"converter": "convertLookupValue"
									}
								},
								"blur": {
									"bindTo": "onLookupBlur"
								},
								"cleariconclick": {
									"bindTo": "clearLookup"
								}
							},
							"labelConfig": {
								"caption": {"bindTo": "Resources.Strings.RecipientCaption"},
							},
							"markerValue": {
								"bindTo": "To"
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchEnabled"
							}
						}
					},
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "LayoutContainer",
						"name": "CopyRecipientContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"visible": {
								"bindTo": "isCopyRecipientVisible"
							}
						},
						"index": 1
					},
					{
						"operation": "move",
						"parentName": "CopyRecipientContainer",
						"propertyName": "items",
						"name": "CopyRecepient"
					},
					{
						"operation": "merge",
						"parentName": "CopyRecipientContainer",
						"name": "CopyRecepient",
						"values": {
							"visible": {
								"bindTo": "isFeatureEmailsSearchDisabled"
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "CopyRecipientContainer",
						"name": "CopyRecipient",
						"propertyName": "items",
						"values": {
							"controlConfig": {
								"className": "BPMSoft.RecipientsSearchLookupEdit",
								"prepareList": {
									"bindTo": "callSearchService"
								},
								"href": "",
								"change": {
									"bindTo": "saveLookupValues"
								},
								"value": {
									"bindConfig": {
										"converter": "convertLookupValue"
									}
								},
								"blur": {
									"bindTo": "onLookupBlur"
								},
								"cleariconclick": {
									"bindTo": "clearLookup"
								}
							},
							"labelConfig": {
								"caption": {"bindTo": "Resources.Strings.CopyRecepientCaption"},
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchEnabled"
							},
							"markerValue": {
								"bindTo": "Cc"
							}
						}
					},
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "LayoutContainer",
						"name": "BlindCopyRecipientContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"visible": {
								"bindTo": "isBlindCopyRecipientVisible"
							}
						},
						"index": 2
					},
					{
						"operation": "move",
						"parentName": "BlindCopyRecipientContainer",
						"propertyName": "items",
						"name": "BlindCopyRecepient"
					},
					{
						"operation": "merge",
						"name": "BlindCopyRecepient",
						"values": {
							"visible": {
								"bindTo": "isFeatureEmailsSearchDisabled"
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "BlindCopyRecipientContainer",
						"name": "BlindCopyRecipient",
						"propertyName": "items",
						"values": {
							"controlConfig": {
								"className": "BPMSoft.RecipientsSearchLookupEdit",
								"prepareList": {
									"bindTo": "callSearchService"
								},
								"href": "",
								"change": {
									"bindTo": "saveLookupValues"
								},
								"value": {
									"bindConfig": {
										"converter": "convertLookupValue"
									}
								},
								"blur": {
									"bindTo": "onLookupBlur"
								},
								"cleariconclick": {
									"bindTo": "clearLookup"
								}
							},
							"labelConfig": {
								"caption": {"bindTo": "Resources.Strings.BlindCopyRecepientCaption"},
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchEnabled"
							},
							"markerValue":  {
								"bindTo": "Bcc"
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});