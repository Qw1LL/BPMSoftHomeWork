define("DetailDesignerUtils", ["BPMSoft", "DetailDesignerUtilsResources"], function(BPMSoft, resources) {
	Ext.define("BPMSoft.configuration.DetailDesignerUtils", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.DetailDesignerUtils",
		singleton: true,

		// region Methods: Private

		/**
		 * @private
		 */
		_buildSchemaViewConfig: function({detailManagerItem, packageUId}, callback, scope) {
			if (!detailManagerItem.detailSchemaUId) {
				callback.call(scope);
				return;
			}
			const clientSchemaItem = BPMSoft.ClientUnitSchemaManager.get(detailManagerItem.detailSchemaUId);
			const entitySchemaItem = BPMSoft.EntitySchemaManager.get(detailManagerItem.entitySchemaUId);
			const schemaBuilder = new BPMSoft.SchemaBuilder();
			const config = {
				entitySchemaName: entitySchemaItem.name,
				schemaName: clientSchemaItem.name,
				packageUId: packageUId,
				useCache: false
			};
			schemaBuilder.build(config, (viewModelClass, viewConfig) => {
				callback.call(scope, viewConfig);
			}, this);
		},

		/**
		 * @private
		 */
		_hasConfigurationGrid: function(viewConfig) {
			if (!Ext.isArray(viewConfig)) {
				return false;
			}
			for (const item of viewConfig) {
				if (item.className === "BPMSoft.ConfigurationGrid") {
					return true;
				} else {
					const result = this._hasConfigurationGrid(item.items);
					if (result) {
						return true;
					}
				}
			}
			return false;
		},

		/**
		 * @private
		 */
		_canChangeType: function({hasConfigurationGrid, schemaBody, detailManagerItem}) {
			const detailSchemaUId = detailManagerItem.getDetailSchemaUId();
			const entitySchemaUId = detailManagerItem.getEntitySchemaUId();
			const clientSchemaItem = BPMSoft.ClientUnitSchemaManager.get(detailSchemaUId);
			const entitySchemaItem = BPMSoft.EntitySchemaManager.get(entitySchemaUId);
			const schemaName = clientSchemaItem.name;
			const entitySchemaName = entitySchemaItem.name;
			const detailBody = this._getDefaultDetailBody(schemaName, entitySchemaName);
			const gridDetailBody = this._getDefaultGridDetailBody(schemaName, entitySchemaName);
			return (!hasConfigurationGrid && (BPMSoft.isEmpty(schemaBody) || this._isEqualBody(schemaBody, detailBody))) ||
				(hasConfigurationGrid && this._isEqualBody(schemaBody, gridDetailBody));
		},

		/**
		 * @private
		 */
		_isEqualBody: function(body1, body2) {
			return new Intl.Collator("en", {ignorePunctuation: true})
				.compare(body1, body2) === 0;
		},

		/**
		 * @private
		 */
		_getDefaultDetailBody: function(schemaName, entitySchemaName) {
			const templates = BPMSoft.ClientUnitSchemaBodyTemplate;
			const types = BPMSoft.SchemaType;
			return Ext.String.format(templates[types.GRID_DETAIL_VIEW_MODEL_SCHEMA],
				schemaName, entitySchemaName);
		},

		/**
		 * @private
		 */
		_getDefaultGridDetailBody: function(schemaName, entitySchemaName) {
			const templates = BPMSoft.ClientUnitSchemaBodyTemplate;
			const types = BPMSoft.SchemaType;
			return Ext.String.format(templates[types.GRID_EDIT_DETAIL_VIEW_MODEL_SCHEMA],
				schemaName, entitySchemaName);
		},

		// endregion

		// region Methods: Public

		/**
		 * Returns grid type info.
		 * @public
		 * @param {BPMSoft.DetailManagerItem} detailManagerItem Detail manager item.
		 * @param {String} packageUId UId of the package.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		getGridTypeInfo: function({detailManagerItem, packageUId}, callback, scope) {
			this._buildSchemaViewConfig({detailManagerItem, packageUId}, (viewConfig) => {
				const hasConfigurationGrid = viewConfig && this._hasConfigurationGrid(viewConfig);
				if (detailManagerItem.getIsNew()) {
					callback.call(scope, {
						canChangeType: true,
						hasConfigurationGrid
					});
					return;
				}
				BPMSoft.ClientUnitSchemaManager.forceGetPackageSchema({
					schemaUId: detailManagerItem.getDetailSchemaUId(),
					packageUId
				}, (schema) => {
					const schemaBody = schema.getPropertyValue("body");
					const canChangeType = this._canChangeType({
						hasConfigurationGrid,
						schemaBody,
						detailManagerItem
					});
					callback.call(scope, {
						canChangeType,
						hasConfigurationGrid
					});
				});
			}, this);
		},

		/**
		 * Returns caption of enable grid control.
		 * @public
		 * @return {String}
		 */
		getEnableGridCaption: function() {
			return resources.localizableStrings.EnableGridCaption;
		},

		/**
		 * Update data grid type.
		 * @public
		 * @param {BPMSoft.DetailManagerItem} detailManagerItem Detail manager item.
		 * @param {BPMSoft.ClientUnitSchema} schema Client unit schema.
		 * @param {Boolean} hasConfigurationGrid Indicates if type of grid should be BPMSoft.ConfigurationGrid.
		 */
		updateDataGridType: function(detailManagerItem, schema, hasConfigurationGrid) {
			const detailSchemaUId = detailManagerItem.getDetailSchemaUId();
			const entitySchemaUId = detailManagerItem.getEntitySchemaUId();
			const clientSchemaItem = BPMSoft.ClientUnitSchemaManager.get(detailSchemaUId);
			const entitySchemaItem = BPMSoft.EntitySchemaManager.get(entitySchemaUId);
			const schemaName = clientSchemaItem.name;
			const entitySchemaName = entitySchemaItem.name;
			const defaultDetailBody = this._getDefaultDetailBody(schemaName, entitySchemaName);
			const defaultGridDetailBody = this._getDefaultGridDetailBody(schemaName, entitySchemaName);
			const schemaBody = schema.getPropertyValue("body");
			if (hasConfigurationGrid && this._isEqualBody(schemaBody, defaultDetailBody)) {
				schema.setPropertyValue("body", defaultGridDetailBody);
			}
			if (!hasConfigurationGrid && this._isEqualBody(schemaBody, defaultGridDetailBody)) {
				schema.setPropertyValue("body", defaultDetailBody);
			}
		},

		/**
		 * Returns detail schema type.
		 * @public
		 * @param {Boolean} hasConfigurationGrid Indicates if type of grid should be BPMSoft.ConfigurationGrid.
		 * @returns {BPMSoft.SchemaType|Number}
		 */
		getDetailSchemaType: function(hasConfigurationGrid) {
			return hasConfigurationGrid
				? BPMSoft.SchemaType.GRID_EDIT_DETAIL_VIEW_MODEL_SCHEMA
				: BPMSoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA;
		}

		// endregion
	});

	return BPMSoft.DetailDesignerUtils;
});
