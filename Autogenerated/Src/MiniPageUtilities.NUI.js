﻿define("MiniPageUtilities", ["ConfigurationEnumsV2", "ModuleUtils"], function() {
	/**
	 * Contains utility methods used by mini page.
	 */
	Ext.define("BPMSoft.configuration.mixins.MiniPageUtilities", {
		alternateClassName: "BPMSoft.MiniPageUtilities",

		// mixins: {
		// 	"SectionSettingsMixin": "BPMSoft.SectionSettingsMixin"
		// },
		/**
		 * Mouse over event handler.
		 * @param {Object} options
		 * @param {Object} entityInfo Entity column name or entity attribute with entitySchemaName.
		 */
		linkMouseOver: function(options, entityInfo) {
			this.prepareMiniPageOpenParameters(options, entityInfo);
		},


		/**
		 * Prepare mini page config and then open mini page.
		 * @param {Object} options
		 * @param {Object} entityInfo Entity column name or entity attribute with entitySchemaName.
		 */
		prepareMiniPageOpenParameters: function(options, entityInfo) {
			var config = {};
			if (options.rowId) {
				config = {
					rowId: options.rowId,
					columnName: options.columnName,
					targetId: options.targetId,
					isFixed: options.isFixed,
					showDelay: options.showDelay
				};
				this.openMiniPage(config);
			} else if (options.targetId) {
				var entitySchemaName = null;
				var columnName = entityInfo;
				var recordId = null;
				if (Ext.isObject(entityInfo)) {
					columnName = entityInfo.columnName;
					entitySchemaName = entityInfo.referenceSchemaName;
					recordId = entityInfo.recordId;
				}
				config = {
					columnName: columnName,
					targetId: options.targetId,
					entitySchemaName: entitySchemaName,
					recordId: recordId
				};
				this.openMiniPage(config);
			}
		},

		/**
		 * Opens mini page.
		 * @param {Object} config Mini page config.
		 * @param {String} config.rowId Record identifier.
		 * @param {String} config.columnName Target column name.
		 * @param {String} config.targetId DOM element identifier.
		 * @param {String} config.entitySchemaName Entity schema name.
		 * @param {String} config.operation Page operation.
		 * @param {Array} config.valuePairs Entity columns default values.
		 * @param {Number} config.showDelay Show MiniPage delay in ms.
		 * @param {String} config.viewModelClassName View model class name.
		 */
		openMiniPage: function(config) {
			const referenceSchemaName = config.entitySchemaName || this.getReferenceSchemaName(config.columnName);
			const hasMiniPage = this.hasMiniPage(referenceSchemaName);
			if (referenceSchemaName && (hasMiniPage || config.miniPageSchemaName)) {
				const recordId = config.recordId || this.getTargetRecordId(config.rowId, config.columnName);
				const addOperation = BPMSoft.ConfigurationEnums.CardOperation.ADD;
				if (recordId || config.operation === BPMSoft.ConfigurationEnums.CardOperation.ADD) {
					const sandbox = this.sandbox;
					BPMSoft.MiniPageListener.open({
						parameters: {
							entitySchemaName: referenceSchemaName,
							primaryColumnValue: recordId,
							viewGeneratorClassName : config.viewGeneratorClassName || ""
						},
						miniPageSchemaName: config.miniPageSchemaName,
						floatTo: config.targetId,
						operation: config.operation,
						valuePairs: config.valuePairs,
						isFixed: config.isFixed,
						showDelay: config.showDelay,
						moduleId: config.moduleId,
						rowId: config.rowId,
						isSectionGrid: config.operation !== addOperation && Ext.isEmpty(this.get("MasterRecordId")) &&
							!Ext.isEmpty(config.rowId),
						miniPageSourceSandboxId: !Ext.isEmpty(sandbox) && this.$Operation !== addOperation
							? sandbox.id
							: "",
						allowClickPropagation: config.allowClickPropagation
					});
				}
			}
		},

		/**
		 * Opens mini page in add mode.
		 * @param {Object} config Mini page config.
		 * @param {Array} config.valuePairs Entity columns default values.
		 * @param {String} config.entitySchemaName Entity schema name.
		 */
		openAddMiniPage: function(config) {
			var addMiniPageConfig = this.getDefaultOpenAddMiniPageConfig();
			Ext.apply(addMiniPageConfig, config);
			this.openMiniPage(addMiniPageConfig);
		},

		/**
		 * Returns add mini page config with default config values.
		 * @return {Object} Open add mini page configuration information.
		 */
		getDefaultOpenAddMiniPageConfig: function() {
			var config = {
				operation: BPMSoft.ConfigurationEnums.CardOperation.ADD,
				isFixed: true,
				showDelay: 0
			};
			return BPMSoft.deepClone(config);
		},

		/**
		 * Returns reference schema name.
		 * @param {String} columnName Target column name.
		 * @return {String} Reference schema name.
		 */
		getReferenceSchemaName: function(columnName) {
			if (columnName === this.primaryDisplayColumnName) {
				return this.entitySchemaName || (this.entitySchema && this.entitySchema.name);
			} else {
				var column = this.getColumnByName(columnName);
				if (column && column.referenceSchemaName) {
					return column.referenceSchemaName;
				}
			}
			return null;
		},

		/**
		 * Returns target record identifier.
		 * @param {String} rowId Record identifier.
		 * @param {String} columnName Target column name.
		 * @private
		 * @return {String} Target record identifier.
		 */
		getTargetRecordId: function(rowId, columnName) {
			if (Ext.isEmpty(columnName)) {
				return "";
			}
			var columnValue = this.get(columnName);
			return Ext.isFunction(this.getGridData)
				? this.getGridDataRecordId(rowId, columnName)
				: this.getEntityColumnValue(columnValue, columnName);
		},

		/**
		 * Returns grid target record identifier.
		 * @param {String} rowId Record identifier.
		 * @param {String} columnName Target column name.
		 * @private
		 * @return {String} Target record identifier.
		 */
		getGridDataRecordId: function(rowId, columnName) {
			var gridData = this.getGridData();
			if (Ext.isEmpty(rowId)) {
				return "";
			}
			var record = gridData.get(rowId);
			var recordValue = record.get(columnName);
			return recordValue && recordValue.value ? recordValue.value : rowId;
		},

		/**
		 * Returns entity target record identifier.
		 * @param {String} columnValue Record identifier.
		 * @param {String} columnName Target column name.
		 * @private
		 * @return {String} Target record identifier.
		 */
		getEntityColumnValue: function(columnValue, columnName) {
			if (Ext.isEmpty(columnValue)) {
				return "";
			}
			if (columnName === this.primaryDisplayColumnName) {
				var primaryId = this.get("Id");
				return primaryId ? primaryId : columnValue;
			}
			return columnValue.value ? columnValue.value : this.get("SubjectId") || this.get("Id");
		},

		/**
		 * Checks mini page add mode accessibility.
		 * @param {String} typeUId Edit page UId.
		 * @return {Boolean} True - if mini page has add mode.
		 */
		hasAddMiniPage: function(typeUId) {
			var result = false;
			var editPages = this.getEditPages();
			if (editPages && editPages.contains(typeUId)) {
				var editPage = editPages.get(typeUId);
				var miniPage = editPage.get("MiniPage");
				if (miniPage) {
					result = Ext.isDefined(miniPage.hasAddMiniPage)
						? miniPage.hasAddMiniPage
						: _.contains(miniPage.miniPageModes, "add");
				}
			}
			return result;
		},

		/**
		 * Returns true if entity has MiniPage.
		 * @param {String} entityName Entity name.
		 * @return {Boolean} True if entity has MiniPage.
		 */
		hasMiniPage: function(entityName) {
			var miniPages = this.getMiniPages(entityName);
			return !BPMSoft.isEmpty(miniPages);
		},

		/**
		 * Calls callback function with flag, wich indicate that can open MiniPage.
		 * @param {String} entityName Entity name.
		 * @param {String} mode MiniPage operation mode.
		 * @return {Boolean} True if can open MiniPage.
		 */
		hasMiniPageForMode: function(entityName, mode, callback, scope) {
			BPMSoft.chain(
				function(next) {
					var structure = BPMSoft.ModuleUtils.getEntityStructureByName(entityName);
					var editPages = BPMSoft.ModuleUtils.getPages(structure);
					mode = mode || BPMSoft.ConfigurationEnums.CardOperation.VIEW;
					var availableModes = editPages.map(editPage => editPage.miniPageModes).join("");
					const editPage = editPages[0];
					const miniPageSchema = editPage && editPage.miniPageSchema;
					if (!availableModes && editPages.length > 0 && miniPageSchema) {
						this._loadOldAvailableModes(miniPageSchema, next, this);
						return;
					}
					next(availableModes)
				},
				function(next, availableModes) {
					var canOpen = availableModes.includes(mode);
					Ext.callback(callback, scope, [canOpen]);
				},
				this
			);
		},

		/**
		 * @param miniPageSchemaName {String} Name of minipage.
		 * @param callback {Function}
		 * @param scope {Object}
		 * @private
		 */
		_loadOldAvailableModes: function(miniPageSchemaName, callback, scope) {
			let modes = "";
			BPMSoft.chain(
				function(next) {
					BPMSoft.require(["MiniPageDesignerViewGenerator"], next, this);
				},
				function(next) {
					var builder = new BPMSoft.SchemaBuilder({
						viewGeneratorClassName: "BPMSoft.MiniPageDesignerViewGenerator"
					});
					builder.build({schemaName: miniPageSchemaName}, function(viewModelClass) {
						next(viewModelClass);
					}, this);
				},
				function(next, viewModelClass) {
					const miniPageModes = viewModelClass.prototype.getColumnByName("MiniPageModes");
					modes = (miniPageModes && miniPageModes.value) || [];
					const sysSettingName = BPMSoft.getFormattedString("Has{0}MiniPageAddMode", viewModelClass.prototype.entitySchemaName);
					BPMSoft.SysSettings.querySysSettingsItem(sysSettingName, next, this);
				},
				function(next, hasAddMode) {
					const addMode = BPMSoft.ConfigurationEnums.CardOperation.ADD;
					if (!_.contains(modes, addMode) && hasAddMode) {
						modes.push(addMode);
					} else if (_.contains(modes, addMode) && !hasAddMode) {
						modes = _.without(modes, addMode);
					}
					Ext.callback(callback, scope, [modes]);
				}, this
			);
		},

		/**
		 * Returns all mini pages schema name by entity schema.
		 * @return {String[]}
		 */
		getMiniPages: function(entityName) {
			var miniPages = [];
			var structure = BPMSoft.ModuleUtils.getModuleStructureByName(entityName);
			if (Ext.isObject(structure)) {
				if (structure.miniPageSchema) {
					miniPages.push(structure.miniPageSchema);
				} else {
					BPMSoft.each(structure.pages, function(page) {
						miniPages.push(page.miniPageSchema);
					}, this);
				}
			}
			return _.compact(miniPages);
		},

		/**
		 * Returns MiniPage sandbox id.
		 * @param {String} entityName Entity name.
		 * @return {String}
		 */
		getMiniPageSandboxId: function(entityName) {
			return Ext.String.format("ViewModule_MiniPageListener_MiniPage_{0}MiniPage", entityName);
		},

		/**
		 * Returns sandbox id for all mini pages by entity schema.
		 * @param {String} entityName Entity name.
		 * @return {String[]}
		 */
		getMiniPagesSandboxId: function(entityName) {
			var miniPages = this.getMiniPages(entityName);
			var result = miniPages.map(function(pageName) {
				return "ViewModule_MiniPageListener_MiniPage_" + pageName;
			}, this);
			var oldMiniPageSandboxId = this.getMiniPageSandboxId(entityName);
			result.push(oldMiniPageSandboxId);
			return _.uniq(result);
		}
	});

	return BPMSoft.MiniPageUtilities;
});
