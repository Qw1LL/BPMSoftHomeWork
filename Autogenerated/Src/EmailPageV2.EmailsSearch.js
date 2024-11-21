define("EmailPageV2", ["EmailConstants", "EmailsSearchMixin", "RecipientsSearchLookupEdit"],
		function(EmailConstants) {
			return {
				entitySchemaName: "Activity",
				mixins: {
					/**
					 * Mixin using to Elasticsearch for search emails.
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
					},
					/**
					 * Copy recepients input visibility.
					 */
					"isCopyRecipientVisible": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
					/**
					 * Blind copy recepients input visibility.
					 */
					"isBlindCopyRecipientVisible": {
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					},
				},
				methods: {

					// region Method: Private

					/**
					 * Update lookup values from textedit values.
					 * @private
					 * @param {String} texteditName TextEdit name.
					 * @param {String} lookupName Lookup name.
					 */
					_updateLookupValues: function(texteditName, lookupName) {
						var recipients = this.get(texteditName);
						if (!recipients) {
							return;
						}
						var lookupValue;
						recipients.split(this.emailSeparate).forEach(function(item) {
							if (!Ext.isEmpty(item.trim())) {
								lookupValue = this.createLookupValue(item, item);
								this.saveLookupValues(lookupValue, lookupName);
							}
						}, this);
						if (lookupValue) {
							lookupValue = this.convertLookupValue(lookupValue, null, {name: lookupName});
							this.set(lookupName, lookupValue);
						}
					},

					// endregion

					// region Method: Protected

					/**
					 *
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#onLookupResult
					 * @override
					 */
					onLookupResult: function(args) {
						if (this.isFeatureEmailsSearchDisabled() || args && args.columnName && args.selectedRows &&
								args.selectedRows.isEmpty()) {
							this.callParent(arguments);
							return;
						}
						var lookupName = args.columnName;
						var recipientsColumnNames = ["Recipient", "CopyRecipient", "BlindCopyRecipient"];
						if (!recipientsColumnNames.includes(lookupName)) {
							this.callParent(arguments);
							return;
						}
						var currentLookup = this.getCurrentLookupConfig(lookupName);
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
							displayValue: this.getActualDisplayValue(lookupName)
						};
						currentLookup.lookupValue = lookupItem;
						this.setLookupValues(lookupItem, lookupName);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
					 * @override
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						if (this.isFeatureEmailsSearchDisabled()) {
							return;
						}
						this._updateLookupValues("Recepient", "Recipient");
						this._updateLookupValues("CopyRecepient", "CopyRecipient");
						this._updateLookupValues("BlindCopyRecepient", "BlindCopyRecipient");
					},

					/**
					 * Copies original message column values.
					 * @overridden
					 * @param {Object} entity Original message.
					 * @param {Object} actionType Email action type.
					 */
					copyEntityColumnValues: function(entity, actionType) {
						this.callParent(arguments);
						if (this.isFeatureEmailsSearchDisabled()) {
							return;
						}
						var actionName = actionType ? actionType.name : "";
						this._updateLookupValues("Recepient", "Recipient");
						if (actionName === EmailConstants.emailAction.ReplyAll) {
							this._updateLookupValues("CopyRecepient", "CopyRecipient");
							this._updateLookupValues("BlindCopyRecepient", "BlindCopyRecipient");
						}
					},

					/**
					 * Generate markerValue, where value of new recipients column name replaced by old recipients
					 * column name (backward compatibility).
					 * @param {string} columnName Column name.
					 * @return {string} Marker value.
					 */
					getMarkerValue: function(columnName) {
						var oldColumnName = columnName.replace("Recipient", "Recepient");
						var entityColumn = this.findEntityColumn(oldColumnName);
						return oldColumnName + " " + entityColumn.caption;
					}

					// endregion

				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "Header",
						"name": "ToContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24
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
							"wrapClass": ["no-margin-bottom"],
														"controlConfig": {
								"className": "BPMSoft.TextEdit",
								"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
								"rightIconClick": {
									"bindTo": "openRecepientLookupEmail"
								},
								"placeholder": {"bindTo": "Resources.Strings.RecepientPlaceholder"}
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchDisabled"
							}
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
								},
								"loadVocabulary": {
									"bindTo": "openRecepientLookupEmail"
								}
							},
							"labelConfig": {
								"caption": {"bindTo": "Resources.Strings.RecepientCaption"},
							},
							"markerValue": { "bindTo": "getMarkerValue" },
							"visible": {
								"bindTo": "isFeatureEmailsSearchEnabled"
							},
							"enabled": {
								"bindTo": "isEmailSendStatusNotSent"
							}
						}
					},
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "EmailPageHeaderContainer",
						"name": "CopyRecipientContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24
							},
							"visible": {
								"bindTo": "isCopyRecipientVisible"
							}
						},
						"index": 0
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
								},
								"loadVocabulary": {
									"bindTo": "openCopyRecepientLookupEmail"
								}
							},
							"labelConfig": {
								"caption": {"bindTo": "Resources.Strings.CopyRecepientCaption"},
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchEnabled"
							},
							"markerValue": { "bindTo": "getMarkerValue" },
							"enabled": {
								"bindTo": "isEmailSendStatusNotSent"
							}
						}
					},
					{
						"operation": "insert",
						"propertyName": "items",
						"parentName": "EmailPageHeaderContainer",
						"name": "BlindCopyRecipientContainer",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"visible": {
								"bindTo": "isBlindCopyRecipientVisible"
							}
						},
						"index": 1
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
								},
								"loadVocabulary": {
									"bindTo": "openBlindCopyRecepientLookupEmail"
								}
							},
							"labelConfig": {
								"caption": {"bindTo": "Resources.Strings.BlindCopyRecepientCaption"},
							},
							"visible": {
								"bindTo": "isFeatureEmailsSearchEnabled"
							},
							"enabled": {
								"bindTo": "isEmailSendStatusNotSent"
							},
							"markerValue": { "bindTo": "getMarkerValue" }
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});