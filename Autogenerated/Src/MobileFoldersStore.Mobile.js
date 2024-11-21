/**
 * @class BPMSoft.configuration.FoldersStore
 */
Ext.define("BPMSoft.configuration.FoldersStore", {
	extend: "BPMSoft.store.AbstractFoldersStore",

	config: {

		/**
		 * @inheritdoc
		 */
		autoSetProxy: false,

		/**
		 * @inheritdoc
		 */
		proxy: {
			type: BPMSoft.Proxies.Query
		},

		/**
		 * @cfg {String} parentId Parent Id.
		 */
		parentId: null

	},

	// region Methods: Private

	/**
	 * @private
	 */
	createParentQueryFilter: function() {
		var leftExpression = Ext.create("BPMSoft.ColumnExpression", {
			columnPath: "Parent"
		});
		var parentId = this.getParentId();
		if (Ext.isEmpty(parentId)) {
			return Ext.create("BPMSoft.QueryIsNullFilter", {
				leftExpression: leftExpression
			});
		} else {
			return Ext.create("BPMSoft.QueryCompareFilter", {
				leftExpression: leftExpression,
				rightExpression: Ext.create("BPMSoft.ParameterExpression", {
					parameter: {
						dataValueType: BPMSoft.DataValueType.Guid,
						value: parentId
					}
				})
			});
		}
	},

	/**
	 * @private
	 */
	createFolderTypeQueryFilter: function(folderTypeId) {
		return Ext.create("BPMSoft.QueryCompareFilter", {
			leftExpression: Ext.create("BPMSoft.ColumnExpression", {
				columnPath: "FolderType"
			}),
			rightExpression: Ext.create("BPMSoft.ParameterExpression", {
				parameter: {
					dataValueType: BPMSoft.DataValueType.Guid,
					value: folderTypeId
				}
			})
		});
	},

	/**
	 * @private
	 */
	createSelectQuery: function() {
		var folderModel = this.getFolderModel();
		var folderModelName = folderModel.getName();
		var nameColumn = Ext.create("BPMSoft.EntityQueryColumn", {
			columnPath: "Name",
			orderDirection: BPMSoft.OrderDirection.Asc,
			orderPosition: 0
		});
		var childrenCountColumn = this.getChildrenCountQueryColumn();
		return Ext.create("BPMSoft.SelectQuery", {
			rootSchemaName: folderModelName,
			columns: ["Id", nameColumn, "Parent.Id", "FolderType.Id", childrenCountColumn],
			filters: this.createQueryFilters()
		});
	},

	/**
	 * @private
	 */
	convertToRecord: function(row) {
		var folderModel = this.getFolderModel();
		return this.createRecord({
			Id: BPMSoft.util.genGuid(),
			FolderType: this.getFolderType(row["FolderType.Id"]),
			Name: row.Name,
			HasChildren: row.ChildrenCount > 0,
			Group: 1,
			Folder: Ext.create(folderModel, {
				Id: row.Id,
				Parent: row["Parent.Id"],
				FolderType: row["FolderType.Id"]
			})
		});
	},

	/**
	 * @private
	 */
	convertFolderFavoriteRecords: function(data) {
		var folderModel = this.getFolderModel();
		var records = [];
		for (var i = 0, ln = data.rows.length; i < ln; i++) {
			var row = data.rows[i];
			records.push(this.createRecord({
				Id: BPMSoft.util.genGuid(),
				FolderType: BPMSoft.FolderType.Favorite,
				Name: row.Name,
				HasChildren: false,
				Group: 0,
				Folder: Ext.create(folderModel, {
					Id: row.FolderId,
					FolderType: row.FolderTypeId
				})
			}));
		}
		return records;
	},

	/**
	 * @private
	 */
	getFolderType: function(folderTypeId) {
		switch (folderTypeId) {
			case BPMSoft.FolderTypeId.Static:
				return BPMSoft.FolderType.Static;
			case BPMSoft.FolderTypeId.Dynamic:
				return BPMSoft.FolderType.Dynamic;
			default:
				return null;
		}
	},

	/**
	 * @private
	 */
	getChildrenCountQueryColumn: function() {
		var folderModel = this.getFolderModel();
		var folderModelName = folderModel.getName();
		return Ext.create("BPMSoft.SubQueryColumn", {
			columnPath: "[" + folderModelName + ":Parent].Parent",
			aggregationType: BPMSoft.QueryAggregationType.Count,
			alias: "ChildrenCount"
		});
	},

	// endregion

	// region Methods: Protected

	/**
	 * @cfg-applier
	 * @protected
	 * @virtual
	 */
	applyProxy: function(config, oldConfig) {
		var selectQuery = this.createSelectQuery();
		config = Ext.mergeIf(config, {
			query: selectQuery,
			createRecordFn: function(row) {
				return this.convertToRecord(row);
			}.bind(this)});
		return this.callParent([config, oldConfig]);
	},

	/**
	 * Gets store filters by type.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.QueryFilterGroup} Instance of filters group.
	 */
	createFolderTypeQueryFilters: function() {
		var dynamicTypeFilter = this.createFolderTypeQueryFilter(BPMSoft.FolderTypeId.Dynamic);
		var staticTypeFilter = this.createFolderTypeQueryFilter(BPMSoft.FolderTypeId.Static);
		return Ext.create("BPMSoft.QueryFilterGroup", {
			logicalOperation: BPMSoft.QueryLogicalOperatorType.Or,
			items: {
				dynamic: dynamicTypeFilter,
				static: staticTypeFilter
			}
		});
	},

	/**
	 * Gets store filters.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.QueryFilterGroup} Instance of filters group.
	 */
	createQueryFilters: function() {
		return Ext.create("BPMSoft.QueryFilterGroup", {
			items: {
				parent: this.createParentQueryFilter(),
				type: this.createFolderTypeQueryFilters()
			}
		});
	},

	/**
	 * Gets store filters.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.QueryFilterGroup} Instance of filters group.
	 */
	createFavoritesFilters: function(schemaUId) {
		var schemaFilter = Ext.create("BPMSoft.QueryCompareFilter", {
			leftExpression: Ext.create("BPMSoft.ColumnExpression", {
				columnPath: "FolderEntitySchemaUId"
			}),
			rightExpression: Ext.create("BPMSoft.ParameterExpression", {
				parameter: {
					dataValueType: BPMSoft.DataValueType.Guid,
					value: schemaUId
				}
			})
		});
		var userFilter = Ext.create("BPMSoft.QueryCompareFilter", {
			leftExpression: Ext.create("BPMSoft.ColumnExpression", {
				columnPath: "SysAdminUnit"
			}),
			rightExpression: Ext.create("BPMSoft.FunctionExpression", {
				functionType: BPMSoft.QueryFunctionType.Macros,
				macrosType: BPMSoft.QueryMacrosType.CurrentUser
			})
		});
		return Ext.create("BPMSoft.QueryFilterGroup", {
			items: {
				schemaUId: schemaFilter,
				user: userFilter
			}
		});
	},

	/**
	 * Gets select query for favorites.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.SelectQuery} Select query.
	 */
	getFavoritesSelectQuery: function(schemaUId) {
		var folderModel = this.getFolderModel();
		var folderModelName = folderModel.getName();
		var folderNameColumn = Ext.create("BPMSoft.EntityQueryColumn", {
			alias: "Name",
			columnPath: "[" + folderModelName + ":Id:FolderId].Name",
			orderDirection: BPMSoft.OrderDirection.Asc,
			orderPosition: 0
		});
		var folderFolderTypeColumn = Ext.create("BPMSoft.EntityQueryColumn", {
			alias: "FolderTypeId",
			columnPath: "[" + folderModelName + ":Id:FolderId].FolderType.Id"
		});
		return Ext.create("BPMSoft.SelectQuery", {
			rootSchemaName: "FolderFavorite",
			columns: ["Id", "FolderId", folderNameColumn, folderFolderTypeColumn],
			filters: this.createFavoritesFilters(schemaUId)
		});
	},

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc
	 */
	loadFavorites: function(config, scope) {
		var folderModel = this.getFolderModel();
		BPMSoft.CFUtils.loadSysSchemaUIdByName({
			modelName: folderModel.getName(),
			cancellationId: config.cancellationId,
			success: function(schemaUId) {
				var selectQuery = this.getFavoritesSelectQuery(schemaUId);
				BPMSoft.QueryExecutor.executeSelect({
					query: selectQuery,
					isCancelable: config.isCancelable,
					cancellationId: config.cancellationId,
					success: function(data) {
						var records = this.convertFolderFavoriteRecords(data);
						Ext.callback(config.callback, scope, [records]);
					},
					failure: function(exception) {
						Ext.callback(config.callback, scope, [[], exception]);
					},
					scope: this
				});
			},
			failure: function(exception) {
				Ext.callback(config.callback, scope, [[], exception]);
			},
			scope: this
		});
	}

	// endregion

});
