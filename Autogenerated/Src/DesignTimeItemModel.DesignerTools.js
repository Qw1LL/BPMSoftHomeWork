define("DesignTimeItemModel", ["DesignTimeItemModelResources", "DesignTimeItemModel"], function(resources) {

	/**
	 * Class of DesignTimeItemModel.
	 */
	Ext.define("BPMSoft.configuration.DesignTimeItemModel", {
		extend: "BPMSoft.model.BaseViewModel",
		alternateClassName: "BPMSoft.DesignTimeItemModel",

		// region Properties: Public

		/**
		 * Design schema.
		 * @type {BPMSoft.ViewModelSchemaDesignerSchema}
		 */
		designSchema: null,

		// endregion

		// region Methods: Abstract

		/**
		 * Returns the image configuration for current data type.
		 * @abstract
		 * @return {Object} Image configuration.
		 */
		getImageConfig: BPMSoft.abstractFn,

		/**
		 * Returns caption for element.
		 * @abstract
		 * @return {Object} Caption for element.
		 */
		getCaption: BPMSoft.abstractFn,

		/**
		 * Creates design item from self.
		 * @abstract
		 * @param {BPMSoft.ViewModelSchemaDesignerSchema} designSchema Design schema.
		 * @param {Object} config Configuration object.
		 * @return {BPMSoft.DesignTimeItemModel}
		 */
		createDesignItem: BPMSoft.abstractFn,

		/**
		 * Adds design item to design schema.
		 * @abstract
		 * @param {Object} config Configuration object.
		 */
		addToDesignSchema: BPMSoft.abstractFn,

		/**
		 * Edits design item.
		 * @abstract
		 * @param {Object} config Configuration object.
		 */
		edit: BPMSoft.abstractFn,

		/**
		 * Removes design item from design schema.
		 * @abstract
		 * @param {Object} config Configuration object.
		 */
		removeFromDesignSchema: BPMSoft.abstractFn,

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
			this.onContentChange();
			if (this.isDesignState()) {
				this.registerMessages();
			}
		},

		/**
		 * Returns the drag action code for type of data.
		 * @protected
		 * @return {Object} Drag action code.
		 */
		getDragActionCode: function() {
			return BPMSoft.DragAction.ALL;
		},

		/**
		 * Initializes model resources values from resources object.
		 * @protected
		 * @param {Object} resourcesObj Resources object.
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
		 * Returns array of classes for current item.
		 * @protected
		 * @return {String[]} Array of CSS classes.
		 */
		getItemClasses: function() {
			return [];
		},

		/**
		 * Initializes caption for element.
		 * @protected
		 */
		initCaption: function() {
			this.set("content", this.getCaption());
		},

		/**
		 * Initializes item CSS classes.
		 * @protected
		 */
		initStyles: function() {
			this.set("wrapClasses", this.getItemClasses());
		},

		/**
		 * Initializes drag action code for data type.
		 * @protected
		 */
		initDragActionCode: function() {
			this.set("DragActionsCode", this.getDragActionCode());
		},

		/**
		 * Column changes handler.
		 * @protected
		 */
		onContentChange: function() {
			this.initCaption();
			this.initDragActionCode();
			this.initStyles();
		},

		/**
		 * Returns configuration button visibility.
		 * @protected
		 * @return {Boolean} true - if field can be changed, false - in other case.
		 */
		getConfigurationButtonVisible: function() {
			return true;
		},

		/**
		 * Returns true if item created for designing.
		 * @protected
		 * @return {Boolean} True if item created for designing
		 */
		isDesignState: function() {
			return !Ext.isEmpty(this.designSchema);
		},

		/**
		 * Returns remove button visibility.
		 * @protected
		 * @return {Boolean} true - if field can be deleted, false - in other case.
		 */
		getRemoveButtonVisible: function() {
			return true;
		},

		/**
		 * Registers design item messages in design schema.
		 * @protected
		 */
		registerMessages: function() {
			BPMSoft.each(this.getMessages(), function(messageConfig) {
				this.designSchema.registerApplictionComponentItemMessage(messageConfig);
			}, this);
		},

		/**
		 * Returns design item message config.
		 * @protected
		 * @return {Array} Design item message config.
		 */
		getMessages: function() {
			return [];
		}

		// endregion

	});

	return BPMSoft.DesignTimeItemModel;
});
