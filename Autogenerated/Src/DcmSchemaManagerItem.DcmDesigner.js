define("DcmSchemaManagerItem", ["ext-base", "BPMSoft", "DcmSchema"], function(Ext, BPMSoft) {

	/**
	 * Dcm schema manager class.
	 */
	Ext.define("BPMSoft.manager.DcmSchemaManagerItem", {
		extend: "BPMSoft.manager.BaseSchemaManagerItem",
		alternateClassName: "BPMSoft.DcmSchemaManagerItem",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#instanceClassName
		 * @overridden
		 */
		instanceClassName: "BPMSoft.DcmSchema",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#requestClassName
		 * @overridden
		 */
		requestClassName: "BPMSoft.DcmSchemaRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#removeRequestClassName
		 * @overridden
		 */
		removeRequestClassName: "BPMSoft.DcmSchemaRemoveRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#updateRequestClassName
		 * @overridden
		 */
		updateRequestClassName: "BPMSoft.DcmSchemaUpdateRequest",

		/**
		 * Stage column uId.
		 * @protected
		 * @type {String}
		 */
		stageColumnUId: null,

		/**
		 * Entity schema uId.
		 * @protected
		 * @type {String}
		 */
		entitySchemaUId: null,

		/**
		 * Flag that indicates whether, dcm schema is active.
		 * @protected
		 * @type {Boolean}
		 */
		isActive: false,

		/**
		 * Flag that indicates whether dcm schema is of active version or not.
		 * @type {Boolean}
		 */
		isActiveVersion: false,

		/**
		 * Root version unique identifier.
		 * @type {Guid}
		 */
		versionParentUId: BPMSoft.GUID_EMPTY,

		/**
		 * Filters of dcm schema.
		 * @protected
		 * @type {Object[]}
		 */
		filters: null,

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#onAfterSave
		 * @override
		 */
		onAfterSave: function(response) {
			if (response.schemaName) {
				this.instance.name = response.schemaName;
			}
			this.callParent(arguments);
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManagerItem#getInstance
		 * @overridden
		 */
		getInstance: function(callback, scope) {
			this.getInstanceWithResponse(callback, scope);
		},

		/**
		 * Returns stage column uId.
		 * @return {String}
		 */
		getStageColumnUId: function() {
			return this.stageColumnUId;
		},

		/**
		 * Returns entity schema uId.
		 * @return {String}
		 */
		getEntitySchemaUId: function() {
			return this.entitySchemaUId;
		},

		/**
		 * Returns flag that indicates whether, dcm schema is active.
		 * @return {Boolean}
		 */
		getIsActive: function() {
			return this.isActive;
		},

		/**
		 * Returns dcm schema filters.
		 * @return {Object[]}
		 * @deprecated
		 */
		getFilters: function() {
			var filters = Ext.JSON.decode(this.filters, true);
			return filters || [];
		},

		/**
		 * Returns dcm schema filters.
		 * @return {BPMSoft.FilterGroup}
		 */
		getFilterGroup: function() {
			return Ext.isEmpty(this.filters)
				? Ext.create("BPMSoft.FilterGroup")
				: BPMSoft.deserialize(this.filters);
		}

		// endregion

	});

	return BPMSoft.DcmSchemaManagerItem;
});
