define("DcmUserTaskSchemaManager", ["ext-base", "BPMSoft", "DcmUserTaskSchema",
	"DcmUserTaskSchemaManagerItem"], function(Ext, BPMSoft) {

	/**
	 * @class BPMSoft.manager.DcmUserTaskSchemaManager
	 */
	Ext.define("BPMSoft.manager.DcmUserTaskSchemaManager", {

		extend: "BPMSoft.BaseUserTaskSchemaManager",

		alternateClassName: "BPMSoft.DcmUserTaskSchemaManager",

		singleton: true,

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseUserTaskSchemaManager#schemaClassName
		 * @overridden
		 */
		schemaClassName: "BPMSoft.DcmUserTaskSchema",

		/**
		 * @inheritdoc BPMSoft.BaseUserTaskSchemaManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.DcmUserTaskSchemaManagerItem",

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaManager#getSelectQuery
		 * @overridden
		 */
		getSelectQuery: function() {
			var itemsQuery = this.callParent(arguments);
			var itemsQueryFilter = BPMSoft.createExistsFilter("[SysDcmUserTask:SchemaUId:UId].Id");
			itemsQuery.filters.addItem(itemsQueryFilter);
			return itemsQuery;
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchemaManager#queryItems
		 * @override
		 */
		queryItems: function(callback, scope) {
			if (BPMSoft.Features.getIsEnabled('UseDcmServerEndPoint')) {
				const request = new BPMSoft.BaseRequest({
					contractName: 'DcmUserTaskManagerRequest'
				});
				return request.execute(callback, scope);
			} else {
				this.callParent(arguments);
			}
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchemaManager#initItems
		 * @override
		 */
		initItems: function(items) {
			if (BPMSoft.Features.getIsEnabled('UseDcmServerEndPoint')) {
				this.initServiceItems(items);
			} else {
				this.callParent(arguments);
			}
		}

		//endregion

	});

	return BPMSoft.DcmUserTaskSchemaManager;

});
