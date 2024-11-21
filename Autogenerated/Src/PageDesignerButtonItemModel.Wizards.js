define("PageDesignerButtonItemModel", ["PageDesignerButtonItemModelResources", "MaskHelper", "DesignTimeItemModel"
], function(resources) {

	Ext.define("BPMSoft.PageDesignerButtonItemModel", {
		extend: "BPMSoft.DesignTimeItemModel",

		// region Properties: Public

		/**
		 * @inheritdoc BPMSoft.BaseModel#columns
		 * @override
		 */
		columns: {
			"Id": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Name": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Caption": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"CaptionLcz": {
				dataValueType: BPMSoft.DataValueType.LOCALIZABLE_STRING
			},
			"PerformClosePage": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				autoBind: true
			},
			"PerformSaveData": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				autoBind: true
			},
			"GenerateSignal": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Tag": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Style": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				autoBind: true
			},
			"Enabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				autoBind: true
			},
			"ReorderableModel": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			"Selected": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false,
				autoBind: true
			}
		},

		/**
		 * Init button config.
		 * @type {Object}
		 */
		itemConfig: null,

		// endregion

		// region Methods: Private

		/**
		 * @private
		 */
		_generateName: function() {
			return this.itemConfig.name + "-" + BPMSoft.generateGUID("N");
		},

		/**
		 * @private
		 */
		_generateTag: function(items) {
			var values = items.mapArray(function(button) {
				return button.get("Tag");
			}, this);
			return BPMSoft.getUniqueValue(values, this.itemConfig.name);
		},

		/**
		 * @private
		 */
		_generateCaption: function(items) {
			var captions = items.mapArray(function(button) {
				return button.get("Caption");
			}, this);
			return BPMSoft.getUniqueValue(captions, this.itemConfig.caption + " ");
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
			this.initCaption();
		},

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#createDesignItem
		 * @override
		 */
		createDesignItem: function(designSchema) {
			var buttons = designSchema.get("ProcessActionButtons");
			var values = {
				"Id": BPMSoft.generateGUID(),
				"Name": this._generateName(),
				"Caption": this._generateCaption(buttons),
				"Tag": this._generateTag(buttons),
				"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
				"PerformClosePage": true,
				"PerformSaveData": true,
				"GenerateSignal": "",
				"Enabled": true
			};
			var designItem = new this.self({
				values: values,
				designSchema: designSchema
			});
			return designItem;
		},

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#getImageConfig
		 * @override
		 */
		getImageConfig: function() {
			return resources.localizableImages.ButtonImage;
		},

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#getDragActionCode
		 * @override
		 */
		getDragActionCode: function() {
			return BPMSoft.DragAction.MOVE;
		},

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#getCaption
		 * @override
		 */
		getCaption: function() {
			return this.$Caption || this.itemConfig && this.itemConfig.caption;
		},

		/**
		 * @inheritdoc BPMSoft.Reorderable#getReorderableIndex
		 * @override
		 */
		getReorderableIndex: function() {
			return this.designSchema.$ButtonReorderableIndex;
		},

		/**
		 * @inheritdoc BPMSoft.Reorderable#setReorderableIndex
		 * @override
		 */
		setReorderableIndex: function(value) {
			this.designSchema.$ButtonReorderableIndex = value;
		},

		/**
		 * Update reorder index after DragEnter event fire.
		 * @protected
		 * @param {String} crossedItemId Crossed element Id.
		 */
		onDragEnter: function(crossedItemId) {
			var indexOf = this.parentCollection.getKeys().indexOf(crossedItemId);
			this.setReorderableIndex(indexOf);
		},

		/**
		 * Clear reorder index after DragOut event fire.
		 * @protected
		 */
		onDragOut: function() {
			this.setReorderableIndex(null);
		},

		/**
		 * Reordering tab collection.
		 * @protected
		 * @return {Boolean}
		 */
		onDragDrop: function() {
			var reorderableIndex = this.getReorderableIndex();
			this.setReorderableIndex(null);
			var items = this.parentCollection;
			var itemIndex = items.getKeys().indexOf(this.$Name);
			if (Ext.isEmpty(reorderableIndex)) {
				return false;
			}
			if (reorderableIndex < itemIndex) {
				reorderableIndex += 1;
			}
			items.move(itemIndex, reorderableIndex);
			return true;
		}

		// endregion

	});

	return BPMSoft.PageDesignerButtonItemModel;

});
