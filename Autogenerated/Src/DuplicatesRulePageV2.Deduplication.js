﻿define("DuplicatesRulePageV2", ["DuplicatesRulePageV2Resources", "MainMenuUtilities", "TagUtilitiesV2"], function() {
	return {
		entitySchemaName: "DuplicatesRule",
		mixins: {
			TagUtilities: "BPMSoft.TagUtilities"
		},
		messages: {
			/**
			 * @message ChangeObject
			 */
			ChangeObject: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			"Object": {
				dataValueType: BPMSoft.DataValueType.LOOKUP
			},
			"EnableEsDeduplication": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: BPMSoft.Features.getIsEnabled("ESDeduplication")
			},
			"EnableBulkEsDeduplication": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: BPMSoft.Features.getIsEnabled("BulkESDeduplication")
			},
			"AvailableSections": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true
			},
			"IsActive": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"onChange": "onIsActiveChanged"
			}
		},
		modules: /**SCHEMA_MODULES*/{
			"DuplicateRulesSettings": {
				"config": {
					"schemaName": "DuplicateRulesSettings",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false
				}
			}
		}/**SCHEMA_MODULES*/,
		methods: {

			//region Methods: Private

			/**
			 * Shows log out confirmation dialog.
			 * @private
			 */
			_showLogoutMsgBox: function() {
				const logoutBtnCaption = this.get("Resources.Strings.LogoutBtnCaption");
				const messageBoxButtons = BPMSoft.MessageBoxButtons;
				const logoutButton = {
					className: "BPMSoft.Button",
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					caption: logoutBtnCaption,
					markerValue: logoutBtnCaption,
					returnCode: "logout"
				};
				this.showConfirmationDialog(this.get("Resources.Strings.UseAtSaveChangedMsg"), async function(returnCode) {
					if (returnCode === logoutButton.returnCode) {
						await BPMSoft.MainMenuUtilities.logout();
					}
				}, [logoutButton, messageBoxButtons.CANCEL], {defaultButton: 0});
			},

			//endregion

			//region Methods: Protected

			/**
			 * @override
			 * @inheritdoc
			 */
			init: function(callback, scope) {
				this.initAttributes();
				this.initSubscribers();
				this.fetchAvailableSections();
				this.callParent(arguments);
			},

			/**
			 * Initialize attributes.
			 * @protected
			 */
			initAttributes: function() {
				const collection = Ext.create("BPMSoft.BaseViewModelCollection");
				this.set("AvailableSections", collection);
			},

			/**
			 * Initialize sandbox subscribers.
			 * @protected
			 */
			initSubscribers: function() {
				this.on("change:Object", this.onChangeObject, this);
			},

			/**
			 * Handler of the change Object column value.
			 * @protected
			 */
			onChangeObject: function() {
				if (!this.isAddMode()) {
					return;
				}
				this.set("RuleBody", JSON.stringify({filters: []}));
				const object = this.get("Object") || {};
				const sectionName = object.displayValue;
				this.set("Name", sectionName);
				const eventTags = this.getEntityInitializedSubscribers();
				this.sandbox.publish("ChangeObject", object, eventTags);
			},

			/**
			 * Loads available sections from SysModule.GlobalSearchAvailable.
			 * @protected
			 */
			fetchAvailableSections: function() {
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysModule"
				});
				const captionColumn = Ext.create("BPMSoft.EntityQueryColumn", {
					columnPath: "[SysModuleEntity:Id:SysModuleEntity].[SysSchema:UId:SysEntitySchemaUId].Caption",
					orderDirection: BPMSoft.OrderDirection.DESC,
					orderPosition: -1
				});
				esq.addColumn(captionColumn, "Caption");
				esq.addColumn("[SysModuleEntity:Id:SysModuleEntity].SysEntitySchemaUId", "ObjectId");
				const filter = BPMSoft.createColumnFilterWithParameter("GlobalSearchAvailable", true);
				esq.filters.addItem(filter);
				esq.getEntityCollection(function(result) {
					const collection = result.collection;
					const availableSections = this.get("AvailableSections");
					availableSections.clear();
					availableSections.loadAll(collection);
				}, this);
			},

			/**
			 * Sets available sections.
			 * @protected
			 * @param {Object} filter Filter.
			 * @param {BPMSoft.Collection} list List of the sections.
			 */
			setAvailableSections: function(filter, list) {
				const sectionsCollection = this.get("AvailableSections");
				const sections = sectionsCollection.getItems();
				const sectionsArray = sections.map(function(item) {
					return {
						value: item.get("ObjectId"),
						displayValue: item.get("Caption"),
						name: item.get("Caption")
					};
				});
				const map = Ext.Array.toValueMap(sectionsArray, "value");
				list.clear();
				list.loadAll(map);
			},

			/**
			 * Gets is Object field is enabled.
			 * @protected
			 * @return {Boolean} True if Object filed is enabled.
			 */
			getObjectEnabled: function() {
				return this.isAddMode();
			},

			/**
			 * Returns parameters for the Object column filtration by name.
			 * @protected
			 * @return {Array} Parameters of filter.
			 */
			getObjectFilterByNameParameters: function() {
				return ["Contact", "Account"];
			},

			/**
			 * Returns filter by name for the Object column.
			 * @protected
			 * @return {BPMSoft.BaseFilter} Instance of filter.
			 */
			getObjectColumnFilterByName: function() {
				return BPMSoft.createColumnInFilterWithParameters(
					"Name", this.getObjectFilterByNameParameters()
				);
			},

			/**
			 * Returns collection of filters for the Object column.
			 * @protected
			 * @return {BPMSoft.FilterGroup} Collection of the filters.
			 */
			getObjectColumnFilters: function() {
				var filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(this.getObjectColumnFilterByName());
				return filters;
			},

			/**
			 * @inheritdoc BasePageV2#addSectionDesignerViewOptions
			 * @overridden
			 */
			addSectionDesignerViewOptions: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getActions
			 * @overridden
			 */
			getActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {
						"bindTo": "Resources.Strings.ContactsDuplicatesSearchCaption"
					},
					"Tag": "openContactDuplicatesModule"
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {
						"bindTo": "Resources.Strings.AccountsDuplicatesSearchCaption"
					},
					"Tag": "openAccountDuplicatesModule"
				}));
				actionMenuItems.addItem(this.getButtonMenuSeparator());
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {
						"bindTo": "Resources.Strings.ScheduleCaption"
					},
					"Visible": {
						"bindTo": "EnableBulkEsDeduplication"
					},
					"Click": {
						"bindTo": "openScheduleSettingPage"
					}
				}));
				return actionMenuItems;
			},

			/**
			 * Opens duplicates search schedule setup page.
			 * @protected
			 */
			openScheduleSettingPage: function() {
				this.sandbox.publish("PushHistoryState", {
					hash: "SearchDuplicatesSettingsPage"
				});
			},

			/**
			 * Opens contact dupliactes search page.
			 * @protected
			 */
			openContactDuplicatesModule: function() {
				this.openDuplicatesModule("Contact");
			},

			/**
			 * Opens account duplicates search page.
			 * @protected
			 */
			openAccountDuplicatesModule: function() {
				this.openDuplicatesModule("Account");
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#save
			 * @overridden
			 */
			save: function() {
				this.callParent(arguments);
				if (this.isChanged() && this.$EnableEsDeduplication) {
					this._showLogoutMsgBox();
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.set("IsActiveInitialValue", this.get("IsActive"));
			},

			/**
			 * Handles IsActive attribute value change.
			 * Asks user to confirm rule deactivation.
			 */
			onIsActiveChanged: function() {
				if (!this.get("IsEntityInitialized") || this.isAddMode() || !this.get("IsActiveInitialValue")) {
					return;
				}
				const value = this.get("IsActive");
				if (value === false) {
					this.showConfirmationDialog(this.get("Resources.Strings.ChangingIsActiveAttributeMessage"), 
						function(returnCode) {
							if (returnCode !== this.BPMSoft.MessageBoxButtons.YES.returnCode) {
								this.set("IsActive", true);
							}
					}, [this.BPMSoft.MessageBoxButtons.YES.returnCode, 
						this.BPMSoft.MessageBoxButtons.NO.returnCode]);
				}
			},

			onCardAction: function() {
				var action = arguments[0] || arguments[3];
				if(action==="saveCardAndLoadTagsFromSection"){
					this.save();
					this.mixins.TagUtilities.showTagModule.call(this);
				}
				this[action]();
			},

			getCurrentRecordId: function() {
				return this.values.PrimaryColumnValue;
			}

			//endregion
		},
		diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "insert",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"name": "DuplicateRulesSettings",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"visible": {"bindTo": "EnableEsDeduplication"}
				}
			},
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"visible": {
						"bindTo": "EnableEsDeduplication",
						"bindConfig": {
							"converter": function(value) {
								return !value;
							}
						}
					},
					"enabled": false,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "DuplicateRuleObjectWrapper",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "DuplicateRuleObject",
				"values": {
					"bindTo": "Object",
					"visible": {"bindTo": "EnableEsDeduplication"},
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.ObjectTypeLabelCaption"}
					},
					"enabled": {"bindTo": "getObjectEnabled"},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24,
						"rowSpan": 1
					},
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "setAvailableSections"}
					}
				},
				"parentName": "DuplicateRuleObjectWrapper",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Object",
				"values": {
					"enabled": false,
					"visible": {
						"bindTo": "EnableEsDeduplication",
						"bindConfig": {
							"converter": function(value) {
								return !value;
							}
						}
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24,
						"rowSpan": 1
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"parentName": "DuplicateRuleObjectWrapper",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "IsActive",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 6,
						"rowSpan": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "UseAtSave",
				"values": {
					"layout": {
						"column": 18,
						"row": 1,
						"colSpan": 6,
						"rowSpan": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			}
		] /**SCHEMA_DIFF*/
	};
});
