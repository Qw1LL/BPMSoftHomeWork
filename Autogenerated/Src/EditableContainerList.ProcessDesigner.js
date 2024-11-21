define("EditableContainerList", ["BPMSoft", "EditableContainerListResources", "EntitySchemaSelectMixin",
		"EditableContainerListItemViewModel", "ConfigurationItemGenerator"],
	function(BPMSoft, resources) {
		return {
			mixins: {
				entitySchemaSelectMixin: "BPMSoft.EntitySchemaSelectMixin"
			},
			messages: {

				/**
				 * @message OnActionClick
				 * On container list item right icon click.
				 * @param {Object} Action config.
				 * @param {String} Control tag.
				 * @param {BPMSoft.EditableContainerListItemViewModel} Item where contol was clicked.
				 */
				"OnActionClick": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message InitEditableContainerListItems
				 * On module init, gets items collection.
				 * @param {String} Publisher module id.
				 */
				"InitEditableContainerListItems": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SetEditableContainerListItems
				 * On module init, gets items collection.
				 * @param {BPMSoft.Collection} Collection of container list items.
				 */
				"SetEditableContainerListItems": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message OnSelectedItemsChange
				 * Sends new container list items collection, when it changes.
				 * @param {BPMSoft.Collection} Collection of container list items.
				 */
				"OnSelectedItemsChange": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SetParametersInfo
				 * Sends new items collection from modal box to container list.
				 */
				"SetParametersInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message SetParametersInfo
				 * Sends items collection from container list to modal box.
				 */
				"GetParametersInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * Concrete container list module id.
				 * @private
				 * @type {String}
				 */
				"ModuleId": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Container list modal box caption.
				 * @private
				 * @type {String}
				 */
				"ModalBoxCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Collection of EditableContainerListItemViewModel items.
				 * @private
				 * @type {BPMSoft.Collection}
				 */
				"Items": {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Container list data item marker.
				 * @type {String}
				 */
				"ContainerDataItemMarker": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Add button list data item marker.
				 * @type {String}
				 */
				"AddButtonDataItemMarker": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * AddButton caption.
				 * @type {String}
				 */
				"AddButtonCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * Custom function for container list item generation.
				 * @private
				 * @virtual
				 */
				setCustomContainerListValuesViewConfig: null,

				//region Methods: Private

				/**
				 * Returns modal box schema name.
				 * @private
				 * @returns {String}
				 */
				getModalBoxSchemaName: function() {
					return "ProcessLookupModule";
				},

				/**
				 * Returns modal box page id.
				 * @private
				 * @returns {String}
				 */
				getModalBoxPageId: function() {
					var schemaName = this.getModalBoxSchemaName();
					return this.sandbox.id + schemaName;
				},

				/**
				 * Init container list items.
				 * @private
				 */
				initModuleInfo: function() {
					var moduleId = this.get("ModuleId");
					var config = this.sandbox.publish("InitEditableContainerListItems", moduleId, [moduleId]);
					var items = config.items;
					this.bindItemsToContainerList(items);
					this.setCustomContainerListValuesViewConfig = config.setCustomViewConfig;
					this.set("Items", items);
					this.initDataItemMarkers(moduleId);
					this.initAddButtonCaption();
				},

				/**
				 * Initializes data markers.
				 * @param {String} moduleId Id of the editable container list instance.
				 * @private
				 */
				initDataItemMarkers: function(moduleId) {
					const containerDataItemMarker = moduleId + "MainContainer";
					this.set("ContainerDataItemMarker", containerDataItemMarker);
					const addButtonDataItemMarker = moduleId + "AddButton";
					this.set("AddButtonDataItemMarker", addButtonDataItemMarker);
				},

				/**
				 * Sets default AddButton caption.
				 * @private
				 */
				_setDefaultAddButtonCaption: function() {
					this.set("AddButtonCaption", resources.localizableStrings.AddButtonCaption);
				},

				/**
				 * Subscribes for SetEditableContainerListItems that sets container list items.
				 * @private
				 */
				subscribeSetEditableContainerListItems: function() {
					const moduleId = this.get("ModuleId");
					this.sandbox.subscribe("SetEditableContainerListItems", function(items) {
						this.bindItemsToContainerList(items);
						this.set("Items", items);
					}, this, [moduleId]);
				},

				/**
				 * Binds all items to container list.
				 * @private
				 * @param {BPMSoft.Collection} items Collection if items.
				 */
				bindItemsToContainerList: function(items) {
					items.each(function(item) {
						item.setContainerList(this);
					}, this);
				},

				/**
				 * Opens modal box with container list items and subscribes for it`s events.
				 * @private
				 */
				onAddButtonClick: function() {
					const modalBoxPageId = this.getModalBoxPageId();
					this.subscribeForSendConfigToModalBox();
					this.subscribeForGetSelectedListFromModalBox();
					this.showProcessLookupPage(modalBoxPageId);
				},

				/**
				 * Subscribes for GetParametersInfo that sends container list items to modal box.
				 * @private
				 */
				subscribeForSendConfigToModalBox: function() {
					var schemaName = this.getModalBoxSchemaName();
					var pageId = this.getModalBoxPageId();
					var modalBoxCaption = this.get("ModalBoxCaption");
					var modalBoxList = this.get("Items");
					var modalBoxConfig = {
						schemaName: schemaName,
						modalBoxCaption: modalBoxCaption,
						parameters: {
							"FilteredCollection": modalBoxList
						}
					};
					this.sandbox.subscribe("GetParametersInfo", function() {
						return modalBoxConfig;
					}, this, [pageId]);
				},

				/**
				 * Subscribes for SetParametersInfo that sends modal box items to container list.
				 * @private
				 */
				subscribeForGetSelectedListFromModalBox: function() {
					var pageId = this.getModalBoxPageId();
					this.sandbox.subscribe("SetParametersInfo", function(parametersInfo) {
						this.updateItemsSelection(parametersInfo.selectedRows);
						this.closeSchemaColumnSelectPage();
					}, this, [pageId]);
				},

				/**
				 * Updates selection and visibility property for items.
				 * @private
				 * @param {Array} uIdArray Array of selected items uIds.
				 */
				updateItemsSelection: function(uIdArray) {
					var items = this.get("Items");
					items.each(function(item) {
						var isItemSelected = Ext.Array.contains(uIdArray, item.id);
						item.setVisibility(isItemSelected);
					}, this);
					this.publishOnSelectedItemsChange();
				},

				/**
				 * Returns container list items view config.
				 * @private
				 * @param {Object} itemConfig Container list item config.
				 */
				setContainerListValuesViewConfig: function(itemConfig) {
					if (this.setCustomContainerListValuesViewConfig) {
						this.setCustomContainerListValuesViewConfig(itemConfig);
					} else {
						this.defaultSetContainerListValuesViewConfig(itemConfig);
					}
				},

				/**
				 * Returns container list items view config.
				 * @private
				 * @param {Object} itemConfig Container list item config.
				 */
				defaultSetContainerListValuesViewConfig: function(itemConfig) {
					var defaultValuesViewConfig = this.get("ContainerListValuesViewConfig");
					if (defaultValuesViewConfig) {
						itemConfig.config = defaultValuesViewConfig;
						return;
					}
					var items = [{
						"id": "Value",
						"readonly": true,
						"className": "BPMSoft.TextEdit",
						"rightIconClasses": ["base-edit-clear-icon"],
						"markerValue": {
							bindTo: "MarkerValue"
						},
						"value": {
							bindTo: "Caption"
						},
						"rightIconClick": {
							bindTo: "rightIconClick"
						},
						"visible": {
							bindTo: "Visible"
						}
					}];
					itemConfig.config = {
						className: "BPMSoft.Container",
						id: "item-view",
						selectors: {
							wrapEl: "#item-view"
						},
						items: items,
						visible: true,
						classes: {
							wrapClassName: ["top-caption-control", "control-width-15"]
						}
					};
					this.set("ContainerListValuesViewConfig", itemConfig.config);
				},

				//endregion

				//region Methods: Protected

				/**
				 * Sets AddButton caption.
				 * @protected
				 */
				initAddButtonCaption: function() {
					const addButtonCaption = this.get("AddButtonCaption");
					if (addButtonCaption) {
						return;
					}
					this._setDefaultAddButtonCaption();
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initModuleInfo();
					this.subscribeSetEditableContainerListItems();
				},

				/**
				 * Publishes OnActionClick message.
				 * @param {String} Control tag.
				 * @param {BPMSoft.EditableContainerListItemViewModel} Item where contol was clicked.
				 */
				publishOnActionClick: function(tag, item) {
					var config = {
						tag: tag,
						item: item
					};
					var moduleId = this.get("ModuleId");
					this.sandbox.publish("OnActionClick", config, [moduleId]);
				},

				/**
				 * Publishes OnSelectedItemsChange message.
				 */
				publishOnSelectedItemsChange: function() {
					var items = this.get("Items");
					var moduleId = this.get("ModuleId");
					var config = {
						items: items,
						moduleId: moduleId
					};
					this.sandbox.publish("OnSelectedItemsChange", config, [moduleId]);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"propertyName": "items",
					"name": "EditableContainerListContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": true,
						"markerValue": {
							bindTo: "ContainerDataItemMarker"
						},
						"wrapClass": ["entity-columns-container"]
					}
				},
				{
					"operation": "insert",
					"parentName": "EditableContainerListContainer",
					"propertyName": "items",
					"name": "ValuesContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "DomElementId",
						"collection": "Items",
						"onGetItemConfig": "setContainerListValuesViewConfig",
						"itemPrefix": "Id",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "EditableContainerListContainer",
					"propertyName": "items",
					"name": "AddButton",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"caption": {
							bindTo: "AddButtonCaption"
						},
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": {
							"bindTo": "onAddButtonClick"
						},
						"markerValue": {
							bindTo: "AddButtonDataItemMarker"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
