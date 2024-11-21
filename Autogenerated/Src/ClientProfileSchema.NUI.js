define("ClientProfileSchema", ["ProfileSchemaMixin"],
		function() {
			return {
				mixins: {
					ProfileSchemaMixin: "BPMSoft.ProfileSchemaMixin"
				},
				attributes: {
					/**
					 * Visibility tag contact profile.
					 * @type {Boolean}
					 */
					"IsVisibleContactProfile": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: true
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BaseProfileSchema#getProfileModuleContainerDataMarker
					 * @overridden
					 */
					getProfileModuleContainerDataMarker: function() {
						return "client-profile-module-container";
					},

					/**
					 * @inheritdoc BPMSoft.BaseProfileSchema#getBlankSlateHeaderCaption
					 * @overridden
					 */
					getBlankSlateHeaderCaption: function() {
						return this.get("Resources.Strings.Client");
					},

					/**
					 * Returns warning icon url.
					 * @return {String} Warning icon url.
					 */
					getWarningIcon: function() {
						return this.getImageUrlByResourceKey("Resources.Images.WarningIcon");
					},

					/**
					 * Returns visibility tag for warning.
					 * @return {Boolean} Visibility tag.
					 */
					getIsVisibleWarning: function() {
						var masterColumnNames = this.get("MasterColumnNames");
						if (!masterColumnNames) {
							return false;
						}
						var masterColumnValues = masterColumnNames.filter(function(columnName) {
							var value = this.get(columnName);
							return !this.Ext.isEmpty(value);
						}, this);
						return masterColumnValues.length > 1;
					},

					/**
					 * @inheritdoc BPMSoft.BaseMultipleProfileSchema#onProfileColumnChanged
					 * @overridden
					 */
					onProfileColumnChanged: function() {
						this.set("IsVisibleContactProfile", !this.getIsVisibleWarning());
						return this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseMultipleProfileSchema#onColumnChanged
					 * @overridden
					 */
					onColumnChanged: function() {
						this.callParent(arguments);
						this.set("IsVisibleContactProfile", !this.getIsVisibleWarning());
					},

					/**
					 * @inheritdoc BPMSoft.BaseProfileSchema#getClearButtonHint
					 * @overridden
					 */
					getClearButtonHint: function() {
						var clearActionCaption = this.get("Resources.Strings.ClearButtonCaption");
						var masterColumnCaption = this.get("Resources.Strings.Client");
						return this.Ext.String.format("{0} {1}", clearActionCaption, masterColumnCaption);
					}

				},
				modules: /**SCHEMA_MODULES*/{
					"AccountClientProfile": {
						"config": {
							"schemaName": "ClientAccountProfileSchema",
							"isSchemaConfigInitialized": true,
							"useHistoryState": false,
							"parameters": {
								"viewModelConfig": {
									masterColumnName: "Account"
								}
							}
						}
					},
					"ContactClientProfile": {
						"config": {
							"schemaName": "ClientContactProfileSchema",
							"isSchemaConfigInitialized": true,
							"useHistoryState": false,
							"parameters": {
								"viewModelConfig": {
									masterColumnName: "Contact"
								}
							}
						}
					}
				}/**SCHEMA_MODULES*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "ProfileIcon"
					},
					{
						"operation": "remove",
						"name": "ProfileHeaderContainer"
					},
					{
						"operation": "merge",
						"name": "ProfileModuleContainer",
						"values": {
							"wrapClass": ["profile-module-container", "client-profile"]
						}
					},
					{
						"operation": "insert",
						"name": "ClientProfilesContainer",
						"parentName": "ProfileContentContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"items": [],
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24,
								"rowSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "WarningIcon",
						"parentName": "ClientProfilesContainer",
						"propertyName": "items",
						index: 0,
						"values": {
							"getSrcMethod": "getWarningIcon",
							"readonly": true,
							"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
							"visible": {"bindTo": "getIsVisibleWarning"},
							"classes": {
								"wrapClass": ["warning-icon"]
							},
							"hint": {"bindTo": "Resources.Strings.WarningMessage"}
						}
					},
					{
						"operation": "insert",
						"parentName": "ClientProfilesContainer",
						"propertyName": "items",
						"name": "AccountClientProfile",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.MODULE
						}
					},
					{
						"operation": "insert",
						"parentName": "ClientProfilesContainer",
						"propertyName": "items",
						"name": "ContactClientProfile",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.MODULE,
							"visible": {"bindTo": "IsVisibleContactProfile"}
						}
					},
					{
						"operation": "insert",
						"name": "AddButton",
						"parentName": "BlankSlateContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"classes": {
								"textClass": "blank-slate-button",
								"wrapperClass": "sale-profile-state-button"
							},
							"selectors": {
								"wrapEl": "#AddButton"
							},
							"click": {"bindTo": "addRecord"},
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
							"caption": {"bindTo": "AddRecordButtonCaption"},
							"controlConfig": {
								"menu": {
									"items": {
										"bindTo": "hasEditPages"
									}
								}
							},
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24
							}
						}
					},
					{
						"operation": "insert",
						"name": "FindButton",
						"parentName": "BlankSlateContainer",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"classes": {
								"textClass": "sale-profile-add-button"
							},
							"selectors": {
								"wrapEl": "#FindButton"
							},
							"click": {"bindTo": "onSearchButtonClick"},
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
							"caption": {"bindTo": "getSearchButtonCaption"},
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 24
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
