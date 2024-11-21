define("MacrosPage", ["ModalBox"], function(ModalBox) {
	return {
		attributes: {
			/**
			 * Collection of tabs.
			 */
			"TabsCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Collection of macros.
			 */
			"MacrosCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Collection of not localized macros alias.
			 */
			"MacrosAliasCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Collection of macros groups.
			 */
			"MacrosGroupsCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION
			}
		},
		messages: {
			"MacroSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Initializes collections on the page.
			 * @private
			 */
			initCollections: function() {
				this.set("MacrosGroupsCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
			},

			/**
			 * Initializes tabs on the page.
			 * @private
			 */
			initTabs: function() {
				var activeTabName = "GeneralMacrosTab";
				this.set("ActiveTabName", activeTabName);
				this.set(activeTabName, true);
			},

			/**
			 * Loads macros.
			 * @private
			 */
			loadMacros: function() {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "EmailTemplateMacros"
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				esq.addColumn("ColumnPath");
				esq.addColumn("Code");
				var parentColumn = esq.addColumn("Parent");
				parentColumn.orderPosition = 0;
				parentColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				var positionColumn = esq.addColumn("Position");
				positionColumn.orderPosition = 1;
				positionColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				esq.filters.add("isActiveFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "IsInactive", false));
				esq.getEntityCollection(function(response) {
					if (!response.success) {
						throw new BPMSoft.UnknownException();
					}
					this.processMacros(response.collection);
				}, this);
			},

			/**
			 * Loads macros not localized alias.
			 * @private
			 */
			_loadMacrosAlias: function() {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "EmailTemplateMacros"
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				esq.filters.add("isActiveFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "IsInactive", false));
				esq.useLocalization = false;
				esq.getEntityCollection(function(response) {
					if (response.success) {
						this.set("MacrosAliasCollection", response.collection);
					}
				}, this);
			},

			/**
			 * Processes macros.
			 * @private
			 * @param {BPMSoft.Collection} macrosCollection Macros collection.
			 */
			processMacros: function(macrosCollection) {
				var macrosGroupsCollection = this.get("MacrosGroupsCollection");
				macrosCollection.each(function(macro) {
					var parent = macro.get("Parent");
					if (parent) {
						return;
					}
					var macroId = macro.get("Id");
					var children = macrosCollection.filter(function(item) {
						var parent = item.get("Parent");
						var itemParentId = parent.value;
						if (!itemParentId) {
							return false;
						}
						return (macroId === itemParentId);
					});
					var name = macro.get("Name");
					var macrosGroup = this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							ActiveRow: "",
							Name: name,
							ChildrenCollection: children
						}
					});
					macrosGroup.on("change:ActiveRow", this.rowSelected, this);
					macrosGroup.sandbox = this.sandbox;
					macrosGroupsCollection.addItem(macrosGroup);
				}, this);
				this.set("MacrosCollection", macrosCollection);
			},

			/**
			 * Returns a formatted representation of the macro.
			 * @private
			 * @param {BPMSoft.BaseViewModel} macro Macro for formatting.
			 * @return {String} Formatted representation of the macro.
			 */
			getFormattedMacro: function(macro) {
				var macroTemplate = this.get("Resources.Strings.MacroTemplate");
				var macrosAlias = this.get("MacrosAliasCollection");
				var parent = macro.get("Parent");
				var parentMacroAlias = macrosAlias.get(parent.value);
				var parentMacroName = parentMacroAlias.get("Name");
				var macroId = macro.get("Id");
				var macroAlias = macrosAlias.get(macroId);
				var macroName = macroAlias.get("Name");
				var path = this.Ext.String.format("{0}.{1}", parentMacroName, macroName);
				return this.Ext.String.format(macroTemplate, path);
			},

			// endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initCollections();
					this.initTabs();
					this.loadMacros();
					this._loadMacrosAlias();
					callback.call(scope);
				}, this]);
			},

			// endregion

			//region Methods: Public

			/**
			 * Processes clicking the Select button.
			 */
			onSelectButtonClick: function() {
				var selectedMacro = this.get("SelectedMacro");
				if (selectedMacro) {
					var formattedMacro = this.getFormattedMacro(selectedMacro);
					this.sandbox.publish("MacroSelected", formattedMacro, [this.sandbox.id]);
				}
				this.onCancelButtonClick();
			},

			/**
			 * Processes clicking the Close button.
			 */
			onCancelButtonClick: function() {
				ModalBox.close();
			},

			/**
			 * Handles the modification event of the selected macro.
			 * @param {Backbone.Model} model Model of a macros group.
			 * @param {String} primaryColumnValue Value of the selected record primary column.
			 */
			rowSelected: function(model, primaryColumnValue) {
				if (!primaryColumnValue) {
					return;
				}
				var macrosGroupsCollection = this.get("MacrosGroupsCollection");
				macrosGroupsCollection.each(function(macroGroup) {
					var activeRow = macroGroup.get("ActiveRow");
					if (!activeRow || (primaryColumnValue === activeRow)) {
						return;
					}
					macroGroup.set("ActiveRow", "");
				}, this);
				var macrosCollection = this.get("MacrosCollection");
				var selectedMacro = macrosCollection.get(primaryColumnValue);
				this.set("SelectedMacro", selectedMacro);
			},

			/**
			 * Prepares the configuration of the macro group view.
			 * @param {Object} item Macro group configuration.
			 */
			prepareMacrosGroupViewConfig: function(item) {
				item.config = {
					className: "BPMSoft.Container",
					items: [
						{
							className: "BPMSoft.ControlGroup",
							caption: {
								bindTo: "Name"
							},
							collapsed: false,
							items: [
								{
									className: "BPMSoft.Grid",
									type: "listed",
									collection: {bindTo: "ChildrenCollection"},
									listedZebra: true,
									primaryDisplayColumnName: "Name",
									activeRow: {
										bindTo: "ActiveRow"
									},
									columnsConfig: [
										{
											cols: 24,
											key: {
												name: "Name",
												bindTo: "Name",
												type: "text"
											}
										}
									]
								}
							]
						}
					]
				};
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MacrosPageContainer",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["macros-page-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Header",
				"parentName": "MacrosPageContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderLabelContainer",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderLabel",
				"parentName": "HeaderLabelContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.MacrosPageCaption"},
					"labelClass": ["information"]
				}
			},
			{
				"operation": "insert",
				"name": "CloseButton",
				"parentName": "HeaderLabelContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"classes": {"wrapperClass": ["close-button"]},
					"click": { "bindTo": "onCancelButtonClick" }
				}
			},
			{
				"operation": "insert",
				"name": "TabsContainer",
				"parentName": "MacrosPageContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["tabs-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Tabs",
				"parentName": "TabsContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.TAB_PANEL,
					"activeTabName": {"bindTo": "ActiveTabName"},
					"classes": {
						"wrapClass": []
					},
					"visible": false,
					"collection": {"bindTo": "TabsCollection"},
					"tabs": []
				}
			},
			{
				"operation": "insert",
				"name": "ActionButtonsContainer",
				"parentName": "TabsContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"visible": true,
					"wrapClass": ["actions-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"name": "SelectButton",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": { "bindTo": "Resources.Strings.SelectButtonCaption" },
					"click": { "bindTo": "onSelectButtonClick" }
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": { "bindTo": "Resources.Strings.CancelButtonCaption" },
					"click": { "bindTo": "onCancelButtonClick" }
				}
			},
			{
				"operation": "insert",
				"name": "GeneralMacrosTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"generateId": false,
					"caption": {"bindTo": "Resources.Strings.GeneralMacrosTabCaption"},
					"wrapClass": ["general-tab-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MacrosGroups",
				"parentName": "GeneralMacrosTab",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "Id",
					"collection": "MacrosGroupsCollection",
					"onGetItemConfig": "prepareMacrosGroupViewConfig",
					"classes": {
						wrapClassName: ["macros-groups"]
					},
					"isAsync": false
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
