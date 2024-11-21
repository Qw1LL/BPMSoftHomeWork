define("StructureExplorerParameterMainViewModel", ["StructureExplorerMainViewModel", "ProcessModuleUtilities"
], function() {

	/**
	 * Structure explorer main view model for work with client unit schema parameters.
	 */
	Ext.define("BPMSoft.StructureExplorerParameterMainViewModel", {
		extend: "BPMSoft.StructureExplorerMainViewModel",

		pageSchema: null,

		// region Methods: Private

		/**
		 * @private
		 */
		_getEntitySchemaName: function(schemaUId) {
			var entitySchema = BPMSoft.EntitySchemaManager.findItem(schemaUId);
			return entitySchema && entitySchema.getName();
		},

		/**
		 * @private
		 */
		_getParameters: function() {
			var list = new BPMSoft.Collection();
			var parameters = this.pageSchema.parameters.filterByFn(function(parameter) {
				var isSystemParameter = BPMSoft.ProcessModuleUtilities.isSystemParameter(parameter.name);
				var isLookup = parameter.dataValueType === BPMSoft.DataValueType.LOOKUP;
				return !isSystemParameter && isLookup;
			}, this);
			parameters.each(function(parameter) {
				list.add(parameter.uId, {
					value: parameter.uId,
					name: parameter.name,
					columnName: parameter.name,
					displayValue: parameter.caption.getValue(),
					dataValueType: parameter.dataValueType,
					referenceSchemaName: this._getEntitySchemaName(parameter.referenceSchemaUId)
				});
			}, this);
			list.sort("displayValue", BPMSoft.OrderDirection.ASC);
			return list;
		},

		/**
		 * @private
		 */
		_isEmptyInitialFilters: function() {
			return Ext.isEmpty(this.params.columnPath);
		},

		// endregion

		// region Methods: Protected

		/**
		 * @override
		 */
		initRootItemIdentifier: function() {
			this.rootItemIdentifier = {};
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#setItemChildren
		 * @override
		 */
		setItemChildren: function(identifier, itemViewModel, callback, scope) {
			if (identifier.referenceSchemaName) {
				this.callParent(arguments);
			} else {
				var parameters = this._getParameters();
				var list = itemViewModel.get("EntitySchemaColumnList");
				list.reloadAll(parameters);
				Ext.callback(callback, scope, [parameters]);
			}
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#getItems
		 * @override
		 */
		getItems: function(filter, list) {
			list.sort("displayValue");
			list.fireEvent("dataloaded", list);
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#initRootSchema
		 * @override
		 */
		initRootSchema: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					const schemaUId = this.params.pageSchemaUId;
					BPMSoft.ClientUnitSchemaManager.getCurrentPackageSchemaByUId(schemaUId, next, this);
				},
				function(next, pageSchema) {
					this.set("caption", pageSchema.caption.toString());
					this.pageSchema = pageSchema;
					var list = this._getParameters();
					this.$EntitySchemaColumnList.reloadAll(list);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#showFilters
		 * @override
		 */
		showFilters: function() {
			this.callParent();
			this.set("RemoveVisible", false);
			if (this._isEmptyInitialFilters()) {
				this.onExpandItem();
			}
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#showFilters
		 * @override
		 */
		onExpandItem: function() {
			this.callParent();
			this.set("RemoveVisible", false);
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#addItem
		 * @override
		 */
		addItem: function(itemViewModel) {
			if (this.viewModelCollection.getCount() === 0) {
				itemViewModel.set("CloseVisible", false);
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.StructureExplorerMainViewModel#focusLastInput
		 * @override
		 */
		focusLastInput: function() {
			if (this._isEmptyInitialFilters()) {
				var schemaLookup = Ext.getCmp("schemaLookup0").getEl();
				schemaLookup.focus();
				var event = document.createEvent("Events");
				event.initEvent("keydown", true, true);
				event.keyCode = Ext.EventObject.DOWN;
				schemaLookup.dom.dispatchEvent(event);
			} else {
				this.callParent(arguments);
			}
		}

		// endregion

	});

	return BPMSoft.StructureExplorerParameterMainViewModel;
});
