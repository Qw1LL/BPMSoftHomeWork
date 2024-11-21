define("ServiceModelPage", ["ViewUtilities", "ConfigurationDiagramGenerator", "ServiceModelDiagramViewModel",
	"ConfigurationItemGenerator", "ViewUtilities", "css!SectionModuleV2",
	"css!AdditionalCssModule", "ServiceModelNetwork"],
	function(ViewUtilities) {
		return {
			"entitySchemaName": null,
			"details": /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			"attributes": {
				"IsInfluenceCategory": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsDependenceCategory": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsConfItemType": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				IsServiceItemType: {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsActiveStatus": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsInactiveStatus": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsStatusChanged": {
					"dependencies": [
						{
							"columns": ["IsActiveStatus", "IsInactiveStatus"],
							"methodName": "clearStatusCollection"
						}
					]
				},
				"IsTypeObjectChanged": {
					"dependencies": [
						{
							"columns": ["IsConfItemType", "IsServiceItemType"],
							"methodName": "onCanEditConfItemSettings"
						}
					]
				},
				"StatusCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},
				"CategoryCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},
				"TypeCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				},
				"ModelCollection": {
					"dataValueType": BPMSoft.DataValueType.COLLECTION
				}
			},
			"mixins": {
				"ServiceModelDiagramViewModel": "BPMSoft.ServiceModelDiagramViewModel"
			},
			"messages": {},
			"diff": /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "TimelineTab"
				},
				{
					"operation": "remove",
					"name": "ESNFeedContainer"
				},
				{
					"operation": "remove",
					"name": "ESNFeed"
				},
				{
					"operation": "remove",
					"name": "CardContentWrapper"
				},
				{
					"operation": "insert",
					"name": "ServiceModelMainContainer",
					"parentName": "ServiceModelPageContainer",
					"propertyName": "items",
					"values": {
						"id": "ServiceModelMainContainer",
						"selectors": {"wrapEl": "#ServiceModelMainContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["schema-wrap", "two-el", "service-model-mail-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ServiceModelPageWrapContainer",
					"parentName": "ServiceModelMainContainer",
					"propertyName": "items",
					"values": {
						"id": "ServiceModelPageWrapContainer",
						"selectors": {"wrapEl": "#ServiceModelPageWrapContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["content-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ActionsButtonContainer",
					"parentName": "ServiceModelPageWrapContainer",
					"propertyName": "items",
					"values": {
						"id": "ActionsButtonContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["action-buttons-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ActionsButtonContainer",
					"propertyName": "items",
					"name": "CloseButton",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT                     ,
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "onCloseClick"}
					}
				},
				{
					"operation": "insert",
					"name": "ServiceModelFilterContainer",
					"parentName": "ServiceModelPageWrapContainer",
					"propertyName": "items",
					"values": {
						"id": "ServiceModelFilterContainer",
						"selectors": {"wrapEl": "#ServiceModelFilterContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["section", "left-el"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ServiceModelDataContainer",
					"parentName": "ServiceModelPageWrapContainer",
					"propertyName": "items",
					"values": {
						"id": "ServiceModelDataContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["card"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ServiceModelNetwork",
					"parentName": "ServiceModelDataContainer",
					"propertyName": "items",
					"values": {
						"className": "BPMSoft.ServiceModelNetwork",
						"generator": "ConfigurationDiagramGenerator.generateDiagram",
						"items": "NetworkNodes",
						"nodeClicked": {"bindTo": "openNodePage"}
					}
				},
				{
					"operation": "insert",
					"name": "FilterActionButtonContainer",
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"values": {
						"id": "FilterActionButtonContainer",
						"selectors": {"wrapEl": "#FilterActionButtonContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["extended-filter-button-container"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ApplyButton",
					"parentName": "FilterActionButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.ApplyButtonCaption"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": {"bindTo": "onApplyButtonClick"}
					}
				},
				{
					"operation": "insert",
					"name": "CleanButton",
					"parentName": "FilterActionButtonContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.CleanButtonCaption"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"click": {"bindTo": "onCleanButtonClick"}
					}
				},
				{
					"operation": "insert",
					"name": "DependencyCategoryContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.DependencyCategoryContainerCaption"
						},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "IsInfluenceCategory",
					"parentName": "DependencyCategoryContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.IsInfluenceCategoryCaption"
						},
						"bindTo": "IsInfluenceCategory",
						"layout": {
							"column": 0,
							"row": 0
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "IsDependenceCategory",
					"parentName": "DependencyCategoryContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.IsDependenceCategoryCaption"
						},
						"bindTo": "IsDependenceCategory",
						"layout": {
							"column": 0,
							"row": 0
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ObjectTypesContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.ObjectTypesContainerCaption"
						},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "IsConfItemType",
					"parentName": "ObjectTypesContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.IsConfItemTypeCaption"
						},
						"bindTo": "IsConfItemType",
						"layout": {
							"column": 0,
							"row": 0
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "IsServiceItemType",
					"parentName": "ObjectTypesContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.IsServiceItemTypeCaption"
						},
						"bindTo": "IsServiceItemType",
						"layout": {
							"column": 0,
							"row": 0
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "StatusContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.StatusContainerCaption"
						},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "IsActiveStatus",
					"parentName": "StatusContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.IsActiveStatusCaption"
						},
						"bindTo": "IsActiveStatus",
						"layout": {
							"column": 0,
							"row": 0
						}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "IsInactiveStatus",
					"parentName": "StatusContainer",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.IsInactiveStatusCaption"
						},
						"bindTo": "IsInactiveStatus",
						"layout": {
							"column": 0,
							"row": 0
						}
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ConfItemStatusContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.ConfItemStatusContainerCaption"
						},
						"collapsed": {"bindTo": "getCollapsedConfItemControlGroups"},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "AddConfItemStatusButton",
					"parentName": "ConfItemStatusContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AddConfItemStatusButtonCaption"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {"bindTo": "onAddConfItemStatusButtonClick"},
						"enabled": {"bindTo": "CanEditConfItemSettings"}
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ConfItemStatusItemsContainer",
					"parentName": "ConfItemStatusContainer",
					"propertyName": "items",
					"values":
					{
						generator: "ConfigurationItemGenerator.generateContainerList",
						idProperty: "Id",
						collection: "StatusCollection",
						onGetItemConfig: "getLookupItemConfig"
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ConfItemCategoryContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.ConfItemCategoryCaption"
						},
						"collapsed": {"bindTo": "getCollapsedConfItemControlGroups"},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "AddConfItemCategoryButton",
					"parentName": "ConfItemCategoryContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AddConfItemCategoryButtonCaption"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {"bindTo": "onAddConfItemCategoryButtonClick"},
						"enabled": {"bindTo": "CanEditConfItemSettings"}
					}
				},
				{
					"operation": "insert",
					"name": "ConfItemCategoryItemsContainer",
					"parentName": "ConfItemCategoryContainer",
					"propertyName": "items",
					"values":
					{
						generator: "ConfigurationItemGenerator.generateContainerList",
						idProperty: "Id",
						collection: "CategoryCollection",
						onGetItemConfig: "getLookupItemConfig"
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ConfItemTypeContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.ConfItemTypeCaption"
						},
						"collapsed": {"bindTo": "getCollapsedConfItemControlGroups"},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 6
				},
				{
					"operation": "insert",
					"name": "AddConfItemTypeButton",
					"parentName": "ConfItemTypeContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AddConfItemTypeButtonCaption"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {"bindTo": "onAddConfItemTypeButtonClick"},
						"enabled": {"bindTo": "CanEditConfItemSettings"}
					}
				},
				{
					"operation": "insert",
					"name": "ConfItemTypeItemsContainer",
					"parentName": "ConfItemTypeContainer",
					"propertyName": "items",
					"values":
					{
						generator: "ConfigurationItemGenerator.generateContainerList",
						idProperty: "Id",
						collection: "TypeCollection",
						onGetItemConfig: "getLookupItemConfig"
					},
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ConfItemModelContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": {
							"bindTo": "Resources.Strings.ConfItemModelCaption"
						},
						"collapsed": {"bindTo": "getCollapsedConfItemControlGroups"},
						"items": []
					},
					"parentName": "ServiceModelFilterContainer",
					"propertyName": "items",
					"index": 7
				},
				{
					"operation": "insert",
					"name": "AddConfItemModelButton",
					"parentName": "ConfItemModelContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AddConfItemModelButtonCaption"
						},
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": {"bindTo": "onAddConfItemModelButtonClick"},
						"enabled": {"bindTo": "CanEditConfItemSettings"}
					}
				},
				{
					"operation": "insert",
					"name": "ConfItemModelItemsContainer",
					"parentName": "ConfItemModelContainer",
					"propertyName": "items",
					"values":
					{
						generator: "ConfigurationItemGenerator.generateContainerList",
						idProperty: "Id",
						collection: "ModelCollection",
						onGetItemConfig: "getLookupItemConfig"
					},
					"index": 1
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * @inheritDoc BPMSoft.BasePageV2#getPageHeaderCaption
				 * @overridden
				 */
				getPageHeaderCaption: function () {
					return this.getHeader();
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#initHeader
				 * @overridden
				 */
				initHeader: function () {
					const caption = this.getHeader();
					this.sandbox.publish("InitDataViews", {
						caption: caption,
						markerValue: caption
					});
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#onRender
				 * @overridden
				 */
				onRender: function () {
					this.callParent(arguments);
					this.updateElementsConfigs(this.onApplyButtonClick);
					this.removeRedundantBorders();
				},

				/**
				* Remove borders, which are recieved from parent div elements.
				* @protected
				*/
				removeRedundantBorders: function() {
					const containers = this._getContainersWithRedundantBorders();
					if (containers) {
						this.BPMSoft.each(containers, function (container) {
							container.addCls("no-border-class");
						});
					}
				},

				/**
				* @inheritdoc BPMSoft.BaseViewModel#onDestroy
				* @override
				*/
				onDestroy: function () {
					const containers = this._getContainersWithRedundantBorders();
					if (containers) {
						this.BPMSoft.each(containers, function(container) {
							container.removeCls("no-border-class");
						});
					}
					this.callParent(arguments);
				},

				/**
				* @private
				* @returns {Array}
				*/
				_getContainersWithRedundantBorders: function() {
					const headerContainer = this.Ext.get("right-header-container");
					const actionsButtonContainer = this.Ext.get("ActionsButtonContainer");
					const containers =
						headerContainer
							? actionsButtonContainer
								? [headerContainer, actionsButtonContainer]
								: null : null;
					return containers;

				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#getHeader
				 * @overridden
				 */
				getHeader: function () {
					return this.getDefaultValues()[0].name;
				},
				/**
				 * @inheritDoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function () {
					this.callParent(arguments);
					this.initAttributes();
					this.mixins.ServiceModelDiagramViewModel.init.call(this);
				},
				/**
				 * ############## ######## ##########.
				 * @protected
				 */
				initAttributes: function () {
					this.set("CanEditConfItemSettings", true);
					this.set("StatusCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.set("CategoryCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.set("TypeCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					this.set("ModelCollection", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				},
				/**
				 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function () {
					this.callParent(arguments);
					this.loadServiceModel();
				},
				/**
				 * @inheritDoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				loadEntity: function (primaryColumnValue, callback, scope) {
					if (callback) {
						callback.call(scope || this, this);
					}
				},
				/**
				 * ####### ######### ######### ########## "######### ############### ######".
				 * @protected
				 */
				clearStatusCollection: function () {
					this.get("StatusCollection").clear();
				},
				/**
				 * ########## ######### ######### ##### "#### ########".
				 * ############# ####### ########## ################ ######.
				 * @protected
				 */
				onCanEditConfItemSettings: function () {
					const isConfItemType = this.get("IsConfItemType");
					const isServiceItemType = this.get("IsServiceItemType");
					const canEditConfItemSettings = isConfItemType || (!isServiceItemType && !isServiceItemType);
					this.set("CanEditConfItemSettings", canEditConfItemSettings);
					this.set("CollapsedConfItemControlGroups", !canEditConfItemSettings);
					if (!canEditConfItemSettings) {
						this.clearFilterCollection();
					}
				},
				/**
				 * ########## ########### ###### ########## ### ################ ######.
				 * @protected
				 * @return {Boolean} ####### ########### ###### ########## ### ################ ######.
				 */
				getCollapsedConfItemControlGroups: function () {
					return this.get("CollapsedConfItemControlGroups");
				},
				/**
				 * ########## ####### ## ###### "########".
				 * ####### ############ #######
				 * @protected
				 */
				onCleanButtonClick: function () {
					this.set("IsInfluenceCategory", false);
					this.set("IsDependenceCategory", false);
					this.set("IsConfItemType", false);
					this.set("IsServiceItemType", false);
					this.set("IsActiveStatus", false);
					this.set("IsInactiveStatus", false);
					this.clearFilterCollection();
					this.rebuildDiagramNodes(this.get("CachedNodes").getItems());
				},
				/**
				 * ####### ######### ######### ### ##########
				 * @protected
				 */
				clearFilterCollection: function () {
					this.clearStatusCollection();
					this.get("CategoryCollection").clear();
					this.get("TypeCollection").clear();
					this.get("ModelCollection").clear();
				},
				/**
				 * On add status button handler.
				 * Creates elements for filtration configuration items by status.
				 * @protected
				 */
				onAddConfItemStatusButtonClick: function () {
					this.openLookupServiceModel("ConfigItemStatus", "StatusCollection");
				},
				/**
				 * On add category button handler.
				 * Creates elements for filtration configuration items by category.
				 * @protected
				 */
				onAddConfItemCategoryButtonClick: function () {
					this.openLookupServiceModel("ConfigItemCategory", "CategoryCollection");
				},
				/**
				 * On add type button handler.
				 * Creates elements for filtration configuration items by type.
				 * @protected
				 */
				onAddConfItemTypeButtonClick: function () {
					this.openLookupServiceModel("ConfigItemType", "TypeCollection");
				},
				/**
				 * On add model button handler.
				 * Creates elements for filtration configuration items by model.
				 * @protected
				 */
				onAddConfItemModelButtonClick: function () {
					this.openLookupServiceModel("ConfigItemModel", "ModelCollection");
				},
				/**
				 * Opens lookup.
				 * @param {String} entitySchemaName Object name.
				 * @param {String} selectedItemsCollectionName Elemenets collection filter name.
				 */
				openLookupServiceModel: function (entitySchemaName, selectedItemsCollectionName) {
					const config = {
						entitySchemaName: entitySchemaName,
						multiSelect: true
					};
					const selectedItemsCollection = this.get(selectedItemsCollectionName);
					const filtersCollection = this.BPMSoft.createFilterGroup();
					if (selectedItemsCollection && selectedItemsCollection.getCount() > 0) {
						const selectedItemsFilter = this.createColumnInServiceModelFilter(selectedItemsCollection,
							"Id", this.BPMSoft.ComparisonType.NOT_EQUAL);
						filtersCollection.add(selectedItemsFilter);
					}
					if (entitySchemaName === "ConfigItemStatus") {
						const isActive = this.get("IsActiveStatus");
						const isInactive = this.get("IsInactiveStatus");
						if ((!isActive || !isInactive) && (isActive || isInactive)) {
							const statusFilter = this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Active", isActive);
							filtersCollection.add(statusFilter);
						}
					}
					if (entitySchemaName === "ConfigItemType") {
						const categoryCollection = this.get("CategoryCollection");
						if (categoryCollection && categoryCollection.getCount() > 0) {
							const categoryFilter = this.createColumnInServiceModelFilter(categoryCollection,
								"ConfItemCategory", this.BPMSoft.ComparisonType.EQUAL);
							filtersCollection.add(categoryFilter);
						}
					}
					if (entitySchemaName === "ConfigItemModel") {
						const typeCollection = this.get("TypeCollection");
						if (typeCollection && typeCollection.getCount() > 0) {
							const typeFilter = this.createColumnInServiceModelFilter(typeCollection,
								"ConfItemType", this.BPMSoft.ComparisonType.EQUAL);
							filtersCollection.add(typeFilter);
						}
					}
					config.filters = filtersCollection;
					this.openLookup(config, function (response) {
						this.createFilterContainerItems(response, selectedItemsCollectionName);
					}, this);
				},
				/**
				 * ####### ###### ### ###### ######### ########## ## ###########.
				 * ########### ####### ## ### ######### ########.
				 * @param {BPMSoft.BaseViewModelCollection} selectedItemsCollection ######### ######### #########.
				 * @param {String} columnName ### ####### ### #########.
				 * @param {BPMSoft.ComparisonType} comparisonType ### #########.
				 * @return {BPMSoft.Filter} ###### ############# ########## ########.
				 */
				createColumnInServiceModelFilter: function (selectedItemsCollection, columnName, comparisonType) {
					const collection = [];
					selectedItemsCollection.getItems().forEach(function (item) {
						collection.push(item.get("Id"));
					}, this);
					const filter = this.BPMSoft.createColumnInFilterWithParameters(columnName, collection);
					filter.comparisonType = comparisonType;
					return filter;
				},
				/**
				 * ######## ##### ###### "###### ######### ########## ## ###########".
				 * ####### ######## ##########.
				 * @param {response} response ######### ##########.
				 * @param {String} selectedItemsCollectionName ######## ######### ######### ##########.
				 */
				createFilterContainerItems: function (response, selectedItemsCollectionName) {
					this.selectedRows = response.selectedRows.getItems();
					const collection = this.get(selectedItemsCollectionName);
					this.selectedRows.forEach(function (item) {
						const containerItem =
							this.getCollectionItem(item.Id, item.Name);
						collection.add(item.Id, containerItem);
					}, this);
				},
				/**
				 * ########## ############ ######## ########## ##########.
				 * @param {BPMSoft.BaseViewModel} itemConfig ############# ####### ## #############.
				 * @param {BPMSoft.BaseViewModel} item ### ####### ## #############.
				 * @return {BPMSoft.BaseViewModel} ###### ############# ########## ########.
				 */
				getLookupItemConfig: function (itemConfig, item) {
					const config = ViewUtilities.getContainerConfig(
						"ts-controlgroup-container", ["control-width-15", "control-left"]);
					itemConfig.config = config;
					const labelContainerConfig = ViewUtilities.getContainerConfig(
						"label-container", ["label-wrap"]);
					const checkBoxLabelConfig = {
						"className": "BPMSoft.Label",
						"caption": {"bindTo": "Name"},
						"classes": {"wrapClass": ["t-label"]}
					};
					labelContainerConfig.items.push(checkBoxLabelConfig);

					const checkBoxContainerConfig = ViewUtilities.getContainerConfig(
						"checkbox-container", ["control-wrap"]);
					const checkBoxEditConfig = {
						"className": "BPMSoft.CheckBoxEdit",
						"id": item.get("Id"),
						"checked": {"bindTo": "Value"},
						"classes": {"wrapClass": ["t-checkboxedit-wrap"]}
					};
					checkBoxContainerConfig.items.push(checkBoxEditConfig);

					config.items.push(labelContainerConfig, checkBoxContainerConfig);
				},
				/**
				 * ########## ####### ######### ##########.
				 * @param {String} id ############# ####### ## #############.
				 * @param {String} name ### ####### ## #############.
				 * @return {BPMSoft.BaseViewModel} ###### ############# ########## ########.
				 */
				getCollectionItem: function (id, name) {
					const collectionItem = Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Name: name,
							Id: id,
							Value: true
						}
					});
					collectionItem.sandbox = this.sandbox;
					return collectionItem;
				},
				/**
				 * ######### ######### ## ########.
				 * @protected
				 * @param {Object} item #######
				 * @param {Array} nodes ###### #########
				 */
				addConnectors: function (item, nodes) {
					const collection = this.get("CachedNodes");
					nodes.push.apply(nodes, collection.filter("targetNode", item.name).collection.items);
					nodes.push.apply(nodes, collection.filter("sourceNode", item.name).collection.items);
				},
				/**
				 * ########## ######## ## ####### ### ######.
				 * @protected
				 * @param {Object} item #######
				 * @param {String} attr ####### ###### ### ##########
				 * @param {String} prop ######## ######## ### ##########
				 * @param {String} value ######## ### ##########
				 * @return {Boolean} ######## ## ####### ### ######
				 */
				isElementMeetCondition: function (item, attr, prop, value) {
					if (this.get(attr)) {
						if (item[prop] === value) {
							return true;
						}
					}
				},
				/**
				 * ########## ######## ## ####### # ###### ## #########.
				 * @protected
				 * @param {Object} item #######
				 * @param {Collection} collection ######### ######### ########
				 * @param {String} prop ######## ######## ### ##########
				 * @return {Boolean} ######## ## ####### # ###### ## #########
				 */
				isElementMeetCollection: function (item, collection, prop) {
					const items = collection.getItems();
					for (let i = 0; i < items.length; i++) {
						if (item[prop] && items[i].get("Value") &&
							item[prop].toLowerCase() === items[i].get("Id").toLowerCase()) {
							return true;
						}
					}
					return false;
				},
				/**
				 * ########## #### ## # ######### ######## ########## ######.
				 * @protected
				 * @param {Collection} name ######## ######### ########.
				 * @return {Boolean} #### ## # ######### ########## ######.
				 */
				isCollectionWithActiveCondition: function (name) {
					const collection = this.get(name);
					if (!collection || collection.isEmpty()) {
						return false;
					}

					const items = collection.getItems();
					for (let i = 0; i < items.length; i++) {
						if (items[i].get("Value")) {
							return true;
						}
					}
					return false;
				},

				/**
				 * Handles click on filter button.
				 * Filters diagram by chosen filters.
				 */
				onApplyButtonClick: function () {
					const collection = this.get("CachedNodes");
					const filterTypeValue = this.BPMSoft.diagram.UserHandlesConstraint.Node.toString();
					const items = collection.filter("nodeType", filterTypeValue).getItems();
					const nodes = [];

					for (let i = 0; i < items.length; i++) {
						if (items[i].side === "center") {
							nodes.push(items[i]);
							continue;
						}
						if ((this.get("IsInfluenceCategory") || this.get("IsDependenceCategory")) &&
							!this.isElementMeetCondition(items[i], "IsInfluenceCategory", "side", "left") &&
							!this.isElementMeetCondition(items[i], "IsDependenceCategory", "side", "right")) {
							continue;
						}
						if ((this.get("IsConfItemType") || this.get("IsServiceItemType")) &&
							!this.isElementMeetCondition(items[i], "IsConfItemType", "schemaName", this.CONF_ITEM) &&
							!this.isElementMeetCondition(items[i], "IsServiceItemType", "schemaName", this.SERVICE_ITEM)) {
							continue;
						}
						if ((this.get("IsActiveStatus") || this.get("IsInactiveStatus")) &&
							!this.isElementMeetCondition(items[i], "IsActiveStatus", "isActive", true) &&
							!this.isElementMeetCondition(items[i], "IsInactiveStatus", "isActive", false)) {
							continue;
						}

						const schemaName = items[i].schemaName;
						if (this.isCollectionWithActiveCondition("StatusCollection") && schemaName === this.CONF_ITEM &&
							!this.isElementMeetCollection(items[i], this.get("StatusCollection"), "confItemStatusId")) {
							continue;
						}
						if (this.isCollectionWithActiveCondition("CategoryCollection") && schemaName === this.CONF_ITEM &&
							!this.isElementMeetCollection(items[i], this.get("CategoryCollection"), "confItemCategoryId")) {
							continue;
						}
						if (this.isCollectionWithActiveCondition("TypeCollection") && schemaName === this.CONF_ITEM &&
							!this.isElementMeetCollection(items[i], this.get("TypeCollection"), "confItemTypeId")) {
							continue;
						}
						if (this.isCollectionWithActiveCondition("ModelCollection") && schemaName === this.CONF_ITEM &&
							!this.isElementMeetCollection(items[i], this.get("ModelCollection"), "confItemModelId")) {
							continue;
						}
						nodes.push(items[i]);
						this.addConnectors(items[i], nodes);
					}
					this.rebuildDiagramNodes(nodes);
				}
			}
		};
	});
