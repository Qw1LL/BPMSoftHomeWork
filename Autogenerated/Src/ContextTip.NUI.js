define("ContextTip", ["ext-base", "ContextTipManager", "BPMSoft"], function(Ext, ContextTipManager, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.ContextTip
	 * Class "Context Tip"
	 */
	Ext.define("BPMSoft.configuration.ContextTip", {
		extend: "BPMSoft.controls.Tip",
		alternateClassName: "BPMSoft.ContextTip",

		//region Properties: Protected

		/**
		 * Context tip manager
		 * @type {BPMSoft.ContextTipManager}
		 */
		manager: null,

		//endregion

		// region Properties: Public

		/**
		 * List of context id's to register tip within.
		 * @type {String[]}
		 */
		contextIdList: null,

		// endregion

		// region Constructors: Public

		/**
		 * @inheritdoc BPMSoft.Component#constructor
		 * @protected
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initManager();
			if (!Ext.isEmpty(this.contextIdList)) {
				this.validateContextIdList();
				this.manager.register(this, this.contextIdList);
			}
		},

		// endregion

		// region Methods: Private

		/**
		 * Returns true if tip not in active displayed tips group, otherwise false.
		 * @private
		 * @return {Boolean}
		 */
		canHide: function() {
			return Ext.isEmpty(this.contextIdList) || !this.manager.isTipInActiveGroup(this);
		},

		// endregion

		// region Methods: Protected

		/**
		 * Performs validation of items in {link #contextIdList} array.
		 * @protected
		 */
		validateContextIdList: function() {
			BPMSoft.each(this.contextIdList, function(contextId) {
				if (!Ext.isString(contextId)) {
					var message = Ext.String.format("Invalid type for {0}. ContextIdList must contain only strings",
							contextId);
					throw new BPMSoft.UnsupportedTypeException({message: message});
				}
			}, this);
		},

		/**
		 * Initializes tip manager.
		 * @protected
		 * @virtual
		 */
		initManager: function() {
			this.manager = ContextTipManager;
		},

		/**
		 * @inheritdoc BPMSoft.controls.Tip#onDocMouseDown
		 * @overridden
		 */
		onDocMouseDown: function() {
			if (this.canHide()) {
				this.callParent(arguments);
			}
		},

		/**
		 * @inheritdoc BPMSoft.controls.Tip#onWindowResize
		 * @overridden
		 */
		onWindowResize: function() {
			if (this.canHide()) {
				this.callParent(arguments);
			} else {
				this.adjustPosition();
			}
		},

		/**
		 * @inheritdoc BPMSoft.controls.Tip#onBodyMouseWheel
		 * @overridden
		 */
		onBodyMouseWheel: function() {
			if (this.canHide()) {
				this.callParent(arguments);
			}
		}

		//endregion

	});
});
