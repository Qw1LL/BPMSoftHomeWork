define("EntitySchemaDesignerUtilities", ["BPMSoft", "DesignTimeEnums"], function(BPMSoft) {
	Ext.define("BPMSoft.configuration.EntitySchemaDesignerUtilities", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.EntitySchemaDesignerUtilities",
		singleton: true,

		//region Methods: Private

		/**
		 * @private
		 */
		_createSelectItem: function(schemaItem, entityFileInfo) {
			return {
				value: schemaItem.getUId(),
				displayValue: schemaItem.getCaption(),
				name: schemaItem.getName(),
				entitySchemaUId: entityFileInfo.entitySchemaUId,
				entitySchemaName: entityFileInfo.entitySchemaName
			};
		},

		/**
		 * @private
		 */
		_getEntitySchemaColumnSelect: function(config) {
			const id = config.uId;
			const caption = config.caption.getValue();
			return {
				id: id,
				value: id,
				name: config.name,
				caption: caption,
				displayValue: caption,
				selected: false
			};
		},

		/**
		 * Indicates that lookup columns are compatible by their types.
		 * @private
		 * @param {Object} sourceDataValueTypeInfo Source data value type info.
		 * @param {String} sourceDataValueTypeInfo.dataValueType Target data value type.
		 * @param {String} sourceDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
		 * is needed for a lookup data value type.
		 * @param {Object} targetDataValueTypeInfo Target data value type info.
		 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
		 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
		 * is needed for a lookup data value type.
		 * @return {Boolean} True, if value from source column can be set to the target column. Otherwise, false.
		 */
		_getAreCompatibleLookupColumnTypes: function(sourceDataValueTypeInfo, targetDataValueTypeInfo) {
			const sourceType = sourceDataValueTypeInfo.dataValueType;
			const targetType = targetDataValueTypeInfo.dataValueType;
			if ((sourceType === BPMSoft.DataValueType.GUID) && (targetType === BPMSoft.DataValueType.GUID)) {
				return true;
			}
			if (BPMSoft.isLookupDataValueType(sourceType) && (targetType === BPMSoft.DataValueType.GUID)) {
				return true;
			}
			if (BPMSoft.isLookupDataValueType(targetType) && (sourceType === BPMSoft.DataValueType.GUID)) {
				return true;
			}
			if (BPMSoft.isLookupDataValueType(sourceType) && BPMSoft.isLookupDataValueType(targetType)) {
				return sourceDataValueTypeInfo.referenceSchemaUId === targetDataValueTypeInfo.referenceSchemaUId;
			}
			return false;
		},

		/**
		 * Indicates that schema columns are compatible by their types.
		 * @private
		 * @param {Object} sourceDataValueTypeInfo Source data value type info.
		 * @param {String} sourceDataValueTypeInfo.dataValueType Target data value type.
		 * @param {String} sourceDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
		 * is needed for a lookup data value type.
		 * @param {Object} targetDataValueTypeInfo Target data value type info.
		 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
		 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
		 * is needed for a lookup data value type.
		 * @return {Boolean} True, if value from source column can be set to the target column. Otherwise, false.
		 */
		_getAreCompatibleColumnTypes: function(sourceDataValueTypeInfo, targetDataValueTypeInfo) {
			const sourceType = sourceDataValueTypeInfo.dataValueType;
			const targetType = targetDataValueTypeInfo.dataValueType;
			if (BPMSoft.utils.dataValueType.isTextDataValueType(sourceType) &&
					BPMSoft.utils.dataValueType.isTextDataValueType(targetType)) {
				return true;
			}
			if (BPMSoft.utils.dataValueType.isDateDataValueType(sourceType) &&
					BPMSoft.utils.dataValueType.isDateDataValueType(targetType)) {
				return true;
			}
			if (BPMSoft.utils.dataValueType.isNumberDataValueType(sourceType) &&
					BPMSoft.utils.dataValueType.isNumberDataValueType(targetType)) {
				return true;
			}
			if (sourceType === BPMSoft.DataValueType.INTEGER &&
					BPMSoft.utils.dataValueType.isNumberDataValueType(targetType)) {
				return true;
			}
			if (BPMSoft.isLookupDataValueType(sourceType) || (sourceType === BPMSoft.DataValueType.GUID)) {
				return this._getAreCompatibleLookupColumnTypes(sourceDataValueTypeInfo, targetDataValueTypeInfo);
			}
			if (sourceType === targetType) {
				return true;
			}
		},

		//endregion

		//region Methods: Public

		/**
		 * Returns file entities collection.
		 * @param {Guid} packageUId Package unique identifier.
		 * @param {Array} entitySchemaUIdList Optional array of entity schema unique identifiers to filter entities by.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Scope object.
		 */
		getFileEntities: function(packageUId, entitySchemaUIdList, callback, scope) {
			const fileEntityNames = Ext.create("BPMSoft.Collection");
			BPMSoft.each(BPMSoft.configuration.ModuleStructure, function(item) {
				if (item.entitySchemaUId) {
					const fileEntitySchemaName = item.entitySchemaName === "Lead" ?
						"FileLead"
						: Ext.String.format("{0}File", item.entitySchemaName);
					fileEntityNames.add(fileEntitySchemaName, {
						entitySchemaUId: item.entitySchemaUId.toLowerCase().replace(/[{}]/g, ""),
						entitySchemaName: item.entitySchemaName
					});
				}
			}, this);
			BPMSoft.EntitySchemaManager.findPackageItems(packageUId, (entities) => {
				entities.sort("caption", BPMSoft.OrderDirection.ASC);
				const filteredEntities = entities.filter((item) => !item.getIsVirtual())
					.filter((item) => fileEntityNames.contains(item.getName()))
					.filter((item) => !entitySchemaUIdList || entitySchemaUIdList &&
						BPMSoft.contains(entitySchemaUIdList, item.getUId()));
				const resultEntities = {};
				filteredEntities.each(function(entity) {
					const entitySchemaUId = entity.getUId();
					const schemaSchemaName = entity.getName();
					const entityFileInfo = fileEntityNames.get(schemaSchemaName);
					resultEntities[entitySchemaUId] = this._createSelectItem(entity, entityFileInfo);
				}, this);
				Ext.callback(callback, scope, [resultEntities]);
			}, this);
		},

		/**
		 * Returns a connected column for the provided entity schema.
		 * @param {Object} config Config object.
		 * @param {String} config.entitySchemaUId Unique identifier of the entity schema.
		 * @param {String} config.packageUId Unique identifier of the package.
		 * @param {String} config.connectedSchemaUId Connected entity schema unique identifier.
		 * @param {String} config.connectedSchemaName Connected entity schema name.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Scope object.
		 */
		findConnectedColumn: function(config, callback, scope) {
			const managerConfig = {
				schemaUId: config.entitySchemaUId,
				packageUId: config.packageUId
			};
			BPMSoft.EntitySchemaManager.findBundleSchemaInstance(managerConfig, function(schema) {
				if (schema) {
					const referenceColumn = schema.columns.findByFn(function(column) {
						return column.referenceSchemaUId === config.connectedSchemaUId &&
							column.name === config.connectedSchemaName;
					}, this);
					let result;
					if (referenceColumn) {
						result = {
							referenceSchemaUId: referenceColumn.referenceSchemaUId,
							uId: referenceColumn.uId,
							caption: referenceColumn.caption.toString()
						};
					}
					Ext.callback(callback, scope, [result]);
					return;
				}
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * Returns sorting columns select items.
		 * @param {Guid} packageUId Package unique identifier.
		 * @param {Guid} entitySchemaUId Entity schema unique identifier.
		 * @param {Function} callback Callback.
		 * @param {Object} scope Scope object.
		 */
		getSortingColumnsSelectItems: function(packageUId, entitySchemaUId, callback, scope) {
			const config = {
				schemaUId: entitySchemaUId,
				packageUId: packageUId
			};
			const entitySchemaColumns = Ext.create("BPMSoft.Collection");
			BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(schema) {
				if (schema) {
					schema.columns.each(function(column) {
						const entitySchemaColumn = this._getEntitySchemaColumnSelect(column);
						entitySchemaColumns.add(entitySchemaColumn.id, entitySchemaColumn);
					}, this);
					entitySchemaColumns.sort("caption");
					Ext.callback(callback, scope, [entitySchemaColumns]);
				}
			}, this);
		},

		/**
		 * Returns the collection of columns, that fit the target column by their types.
		 * @param {Object} targetDataValueTypeInfo Target data value type info.
		 * @param {String} targetDataValueTypeInfo.dataValueType Target data value type.
		 * @param {String} targetDataValueTypeInfo.referenceSchemaUId Unique identifier of the entity schema witch
		 * is needed for a lookup data value type.
		 * @param {BPMSoft.Collection} sourceSchemaColumns The collection of source column.
		 * @return {BPMSoft.Collection} Objects with id and caption of columns, that fit target column by their
		 * types.
		 */
		filterSourceSchemaColumns: function(sourceSchemaColumns, targetDataValueTypeInfo) {
			const filteredColumns = Ext.create("BPMSoft.Collection");
			if (sourceSchemaColumns && !sourceSchemaColumns.isEmpty()) {
				sourceSchemaColumns.each(function(sourceSchemaColumn) {
					const datavalueType = sourceSchemaColumn.getPropertyValue("dataValueType");
					const referenceSchemaUId = sourceSchemaColumn.getPropertyValue("referenceSchemaUId");
					const sourceDataValueTypeInfo = {
						dataValueType: datavalueType,
						referenceSchemaUId: referenceSchemaUId
					};
					if (!this._getAreCompatibleColumnTypes(sourceDataValueTypeInfo, targetDataValueTypeInfo)) {
						return;
					}
					const id = sourceSchemaColumn.uId;
					filteredColumns.add(id, {
						id: sourceSchemaColumn.uId,
						caption: sourceSchemaColumn.caption.getValue()
					});
				}, this);
			}
			return filteredColumns;
		},

		/**
		 * Returns an entity schema UId by it's name.
		 * @param {String} schemaName Schema name to get UId of.
		 * @return {Guid} Schema unique identifier.
		 */
		getEntitySchemaUIdByName: function(schemaName) {
			const item = BPMSoft.EntitySchemaManager.findItemByName(schemaName);
			return item?.uId;
		}

		//endregion

	});

	return BPMSoft.EntitySchemaDesignerUtilities;
});
