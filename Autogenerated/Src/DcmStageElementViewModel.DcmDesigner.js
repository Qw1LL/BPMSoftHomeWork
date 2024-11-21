define("DcmStageElementViewModel", ["ext-base", "DcmStageElement"],
	function(Ext) {
		/**
		 * @class BPMSoft.Designers.DcmStageElementViewModel
		 */
		Ext.define("BPMSoft.Designers.DcmStageElementViewModel", {

			extend: "BPMSoft.BaseViewModel",

			alternateClassName: "BPMSoft.DcmStageElementViewModel",

			mixins: {
				ReorderableItemVMMixin: "BPMSoft.ReorderableItemVMMixin",
				ObservableItem: "BPMSoft.ObservableItem"
			},

			columns: {
				/**
				 * Dcm schema.
				 * @type {BPMSoft.DcmSchema}
				 */
				Schema: {
					type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.core.enums.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Caption.
				 * @type {BPMSoft.String}
				 */
				Caption: {
					type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.core.enums.DataValueType.TEXT
				},

				/**
				 * Flag that indicators the element is selected.
				 * @type {Boolean}
				 */
				Selected: {
					type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.core.enums.DataValueType.BOOLEAN
				},

				/**
				 * Flag that indicators the element validation state.
				 * @type {Boolean}
				 */
				IsValid: {
					type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.core.enums.DataValueType.BOOLEAN
				},

				/**
				 * Flag that indicates whether element property page executes validation.
				 * @type {Boolean}
				 */
				IsValidateExecuted: {
					type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.core.enums.DataValueType.BOOLEAN
				},

				/**
				 * Flag that indicators the element required state.
				 * @type {Number}
				 */
				RequiredType: {
					type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.core.enums.DataValueType.INTEGER
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.mixins.ReorderableItemVMMixin.preInit.call(this);
				this.initAttributes();
				var element = this.getSchemaElement();
				this.subscribeOnItemChanged(element);
				this.subscribeOnItemChanged(element.processFlowElement);
			},

			/**
			 * Init attributes of view model.
			 * @protected
			 */
			initAttributes: function() {
				var element = this.getSchemaElement();
				this.set("Name", element.name);
				this.set("IsValidateExecuted", element.isValidateExecuted);
				this.set("IsValid", element.isValid);
				this.set("RequiredType", element.requiredType);
				var caption = element.caption;
				var captionValue = caption && caption.getValue();
				this.set("Caption", captionValue);
			},

			/**
			 * Returns DCM schema element.
			 * @return {BPMSoft.DcmSchemaElement|null}
			 */
			getSchemaElement: function() {
				var schema = this.get("Schema");
				var id = this.get("Id");
				var element = schema.findItemByUId(id);
				return element;
			},

			/**
			 * Returns image configuration.
			 * @protected
			 * @return {Object} Image config.
			 */
			getImageConfig: function() {
				var element = this.getSchemaElement();
				var image = element.getDcmSmallImage();
				var imageUrl = BPMSoft.ImageUrlBuilder.getUrl(image);
				return {
					source: BPMSoft.ImageSources.URL,
					url: imageUrl
				};
			},

			/**
			 * Returns module view configuration.
			 * @return {Object} Module view configuration.
			 */
			getViewConfig: function() {
				return {
					className: "BPMSoft.DcmStageElement",
					groupName: "dcm-stage-items",
					tag: this.get("Id"),
					id: this.get("Id"),
					caption: {
						bindTo: "Caption"
					},
					markerValue: {
						bindTo: "Caption"
					},
					isValidateExecuted: {
						bindTo: "IsValidateExecuted"
					},
					isValid: {
						bindTo: "IsValid"
					},
					requiredType: {
						bindTo: "RequiredType"
					},
					selected: {
						bindTo: "Selected"
					},
					imageConfig: {
						bindTo: "getImageConfig"
					},
					onDragEnter: {
						bindTo: "onDragEnter"
					},
					onDragDrop: {
						bindTo: "onDragDrop"
					},
					onDragOut: {
						bindTo: "onDragOut"
					}
				};
			},

			/**
			 * @inheritdoc BPMSoft.ObservableItem#getItemAttributeValue
			 * @overridden
			 */
			getItemAttributeValue: function(item, key) {
				var value = this.mixins.ObservableItem.getItemAttributeValue.call(this, item, key);
				if (value instanceof BPMSoft.LocalizableString) {
					value = value.getValue();
				}
				return value;
			},

			/**
			 * @inheritdoc BPMSoft.ObservableItem#getAttributeMap
			 * @overridden
			 */
			getAttributeMap: function() {
				var attributeMap = this.mixins.ObservableItem.getAttributeMap.call(this);
				var attributes = {
					caption: "Caption",
					isValidateExecuted: "IsValidateExecuted",
					isValid: "IsValid",
					requiredType: "RequiredType"
				};
				return Ext.apply(attributeMap, attributes);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				this.unsubscribeAllItems();
				this.callParent(arguments);
			},

			/**
			 * Set selected item.
			 * @param {Boolean} isSelected A flag that indicates that the item is selected.
			 */
			setSelected: function(isSelected) {
				this.set("Selected", isSelected);
			}
		});
		return BPMSoft.Designers.DcmStageElementViewModel;
	}
);
