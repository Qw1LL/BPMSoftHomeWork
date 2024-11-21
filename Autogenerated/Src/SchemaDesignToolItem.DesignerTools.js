define("SchemaDesignToolItem", ["SchemaDesignToolItemResources"], function() {

	/**
	 * BPMSoft.SchemaDesignToolItem
	 */
	Ext.define("BPMSoft.SchemaDesignToolItem", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.configuration.SchemaDesignToolItem",

		/**
		 * Sandbox.
		 * @type {Object}
		 */
		sandbox: null,

		/**
		 * Data source view model.
		 * @type {BPMSoft.model.BaseViewModel}
		 */
		parentViewModel: null,

		/**
		 * Design item class name.
		 * @type {String}
		 */
		designItemClassName: null,

		/**
		 * Design item config.
		 * @type {Object}
		 */
		designItemConfig: null,

		/**
		 * Design item.
		 * @private
		 * @type {BPMSoft.GridLayoutEditItemModel}
		 */
		internalItem: null,

		/**
		 * Invalid drop handler.
		 * @protected
		 * @virtual
		 */
		onInvalidDrop: function() {
			this.fireEvent("change", this, {operation: "InvalidDrop"});
		},

		/**
		 * Drag over handler.
		 * @protected
		 * @virtual
		 */
		onDragOver: function(intersection) {
			Ext.apply(intersection, {
				colSpan: this.internalItem.get("colSpan"),
				rowSpan: this.internalItem.get("rowSpan"),
				operation: "DragOver"
			});
			this.fireEvent("change", this, intersection);
		},

		/**
		 * Success drag and drop handler.
		 * @protected
		 * @virtual
		 */
		onDragDrop: function(info) {
			Ext.apply(info, {operation: "DragDrop"});
			this.fireEvent("change", this, info);
		},

		/**
		 * Drag out handler.
		 * @protected
		 */
		onDragOut: function() {
			const info = Ext.apply({}, {operation: "DragOut"});
			this.fireEvent("change", this, info);
		},

		/**
		 * Adds draggable group.
		 * @param {String} groupName Group name.
		 */
		addDraggableGroupName: function(groupName) {
			var draggableGroupNames = BPMSoft.deepClone(this.get("draggableGroupNames") || []);
			draggableGroupNames.push(groupName);
			this.set("draggableGroupNames", draggableGroupNames);
		},

		/**
		 * Creates design item from internal item.
		 * @param {BPMSoft.ViewModelSchemaDesignerSchema} designSchema Design schema.
		 * @param {Object} config Configuration object.
		 * @return {Array} Design item.
		 */
		createDesignItem: function(designSchema, config) {
			return this.internalItem.createDesignItem(designSchema, config);
		},

		/**
		 * Returns image config.
		 * @return {Array} Image config.
		 */
		getImageConfig: function() {
			return this.internalItem.getImageConfig();
		},

		/**
		 * Returns content.
		 * @return {Array} Content.
		 */
		getContent: function() {
			return this.internalItem.get("content");
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.internalItem = Ext.create(this.designItemClassName, this.getDesignItemConfg());
			this.set("itemId", this.internalItem.itemConfig && this.internalItem.itemConfig.name);
			this.set("content", this.getContent());
			this.set("imageConfig", this.getImageConfig());
		},

		/**
		 * Handler for remove menu item click.
		 */
		onRemoveMenuItemClick: function() {
			this.fireEvent("change", this, {operation: "Remove"});
		},

		/**
		 * Update image config.
		 */
		updateImageConfig: function() {
			this.set("imageConfig", this.getImageConfig());
		},

		/**
		 * @protected
		 */
		getDesignItemConfg: function() {
			return this.designItemConfig;
		}

	});

	return BPMSoft.SchemaDesignToolItem;
});
