define("AttributeContainerListItemViewModel", ["AttributeContainerListItemViewModelResources"],
	function(resources) {
		/**
		 * @class BPMSoft.Designers.AttributeContainerListItemViewModel
		 */
		Ext.define("BPMSoft.configuration.AttributeContainerListItemViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.AttributeContainerListItemViewModel",

			attributes: {
				/**
				 * Container list item caption.
				 * @type {String}
				 */
				"Caption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Attribute item object stored in ContentBuilder.Attributes collection.
				 * @type {Object}
				 * {
				 * 		Caption: {String},
				 * 		Value: {String},
				 * 		Index: {Int},
				 * 		TypeId: {Guid},
				 * 		Id: {Guid}
				 * 	}
				 */
				"Item": {
					dataValueType: BPMSoft.DataValueType.OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},

			/**
			 * Element id.
			 * @type {BPMSoft.DataValueType.GUID}
			 */
			id: null,

			/**
			 * Custom user object with params.
			 * @type {Object}
			 */
			source: null,

			/**
			 * Parent editable container list.
			 * @type {BPMSoft.ObservableContainerList}
			 */
			containerList: null,

			/**
			 * Constructor which calls base and initialize resources.
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * Initialize resource values from resource object.
			 * @param resourcesObj View model resources object.
			 */
			initResourcesValues: function(resourcesObj) {
				var resourcesSuffix = "Resources";
				BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
					resourceGroupName = resourceGroupName.replace("localizable", "");
					BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
						var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
						this.set(viewModelResourceName, resourceValue);
					}, this);
				}, this);
			},

			/**
			 * Sets parent container list.
			 * @param {BPMSoft.EditableContainerList} containerList Parent container list.
			 */
			setContainerList: function(containerList) {
				this.containerList = containerList;
			},

			/**
			 * Sets container list item attributes.
			 * @param {BPMSoft.DataValueType.GUID} id Item id.
			 * @param {String} caption Item caption.
			 * @param {Boolean} selected Indicated is item selected.
			 * @param {Object} source Custom user object inside container list item. Store any extra needed
			 * info for item here.
			 * @param {String} moduleId Container list module id owner of the item.
			 * @param {BPMSoft.EditableContainerList} containerList Container list owner of the item.
			 */
			initModel: function(id, caption, selected, source) {
				this.id = id;
				this.source = source;
				this.set("Caption", caption);
				this.set("Item", source);
				this.set("Items", Ext.create("BPMSoft.Collection"));
				this.set("Selected", selected);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				this.addEvents(
					/**
					 * @event onObservableItemClick
					 * The click event on the list element
					 */
					"onAttributeItemDelete"
				);
			},

			/**
			 * Handles click event on delete button of item.
			 * Publishes delete message.
			 */
			onAttributeDeleteButtonClick: function() {
				this.sandbox.publish("DCAttributeDelete", this.source);
			},

			/**
			 * Returns view config for item of collection.
			 * @returns {Object} View config.
			 */
			getViewConfig: function() {
				return {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["attribute-item-container-wrap"]
					},
					items: [
						{
							className: "BPMSoft.Container",
							classes: { wrapClassName: ["attribute-item-container"] },
							items: [
								{
									className: "BPMSoft.Label",
									caption: "$Caption"
								},
								{
									className: "BPMSoft.Button",
									imageConfig: "$Resources.Images.DeleteIcon",
									markerValue: "DeleteAttributeButton",
									style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
									click: {"bindTo": "onAttributeDeleteButtonClick"},
									visible: "$Selected"
								}
							]
						}
					]
				};
			}
		});
		return BPMSoft.configuration.AttributeContainerListItemViewModel;
	}
);
