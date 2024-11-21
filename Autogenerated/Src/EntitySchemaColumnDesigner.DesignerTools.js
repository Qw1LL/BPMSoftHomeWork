/**
 * Parent: BaseDesigner
 */
define("EntitySchemaColumnDesigner", ["BPMSoft", "BusinessRuleModule", "DesignTimeEnums",
	"ApplicationStructureWizardUtils"
], function(BPMSoft, BusinessRuleModule) {
	return {
		messages: {

			"ChangeHeaderCaption": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetColumnConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetSchemaColumnsNames": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetDesignerDisplayConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetNewLookupPackageUId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		rules: {
			"ReferenceSchemaUId": {
				"RequiredReferenceSchemaUId": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.REQUIRED,
					logical: BPMSoft.LogicalOperatorType.AND,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "DataValueType"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: BPMSoft.DataValueType.LOOKUP
						}
					}, {
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "UseNewLookup"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: false
						}
					}]
				}
			},
			"NewSchemaCaption": {
				"RequiredNewSchemaCaption": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.REQUIRED,
					logical: BPMSoft.LogicalOperatorType.AND,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "DataValueType"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: BPMSoft.DataValueType.LOOKUP
						}
					}, {
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "UseNewLookup"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"NewSchemaName": {
				"RequiredNewSchemaName": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.REQUIRED,
					logical: BPMSoft.LogicalOperatorType.AND,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "DataValueType"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: BPMSoft.DataValueType.LOOKUP
						}
					}, {
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "UseNewLookup"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"IsRequired": {
				"RequiredNewSchemaName": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.VISIBLE,
					logical: BPMSoft.LogicalOperatorType.AND,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "DataValueType"
						},
						comparisonType: BPMSoft.ComparisonType.NOT_EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: BPMSoft.DataValueType.INTEGER
						}
					}, {
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "DataValueType"
						},
						comparisonType: BPMSoft.ComparisonType.NOT_EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: BPMSoft.DataValueType.FLOAT
						}
					}, {
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "DataValueType"
						},
						comparisonType: BPMSoft.ComparisonType.NOT_EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: BPMSoft.DataValueType.BOOLEAN
						}
					}]
				}
			}
		},
		attributes: {

			UId: {
				dataValueType: BPMSoft.DataValueType.GUID,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			Caption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true
			},

			Name: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true
			},

			Description: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			DataValueType: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true
			},

			ReferenceSchemaUId: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true
			},

			IsRequired: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			IsVirtual: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			IsValueCloneable: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			IsSimpleLookup: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			IsCascade: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			DataValueTypeConfig: {
				dataValueType: BPMSoft.DataValueType.ENUM,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			Column: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			UseNewLookup: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			NewSchemaCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			NewSchemaName: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: ""
			}

		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_onReferenceSchemaChanged: function() {
				const referenceSchemaUId = this.$ReferenceSchemaUId && this.$ReferenceSchemaUId.value;
				if (referenceSchemaUId) {
					BPMSoft.chain(
						function(next) {
							this.getCurrentPackageUId(next, this);
						},
						function(next, packageUId) {
							BPMSoft.EntitySchemaManager.findBundleSchemaInstance({
								schemaUId: referenceSchemaUId,
								packageUId: packageUId
							}, next, this);
						},
						function(next, schema) {
							if (!(schema && schema.primaryDisplayColumn)) {
								this.$ReferenceSchemaUId = null;
								BPMSoft.showMessage(this.get("Resources.Strings.LookupSchemaDoesNotHavePrimaryDisplayColumnMsg"));
							}
						},
						this
					);
				}
			},

			/**
			 * @private
			 */
			_subscribeOnAttributeChanges: function() {
				this.subscribeOnColumnChange("ReferenceSchemaUId", this._onReferenceSchemaChanged, this);
			},

			/**
			 * @private
			 */
			_unsubscribeOnAttributeChanges: function() {
				this.unsubscribeOnColumnChange("ReferenceSchemaUId", this._onReferenceSchemaChanged, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BaseDesigner#initSectionCaption
			 * @override
			 */
			initSectionCaption: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseDesigner#changeDesignerCaption
			 * @override
			 */
			changeDesignerCaption: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Caption", this.columnLengthValidator);
				this.addColumnValidator("Name", this.columnLengthValidator);
				this.addColumnValidator("Name", this.columnNameRegExpValidator);
				this.addColumnValidator("Name", this.columnPrefixValidator);
				this.addColumnValidator("Name", this.columnDuplicateNameValidator);
				this.addColumnValidator("NewSchemaName", this.schemaNameLengthValidator);
				this.addColumnValidator("NewSchemaName", this.schemaNameRegExpValidator);
				this.addColumnValidator("NewSchemaName", this.schemaNamePrefixValidator);
				this.addColumnValidator("NewSchemaName", this.schemaDuplicateNameValidator);
			},

			/**
			 * @inheritdoc BasePageV2#onRender
			 * @override
			 */
			onRender: function() {
				this.updateSize(550, 590);
				this.hideBodyMask();
			},

			/**
			 * Returned column config.
			 * @protected
			 * @return {Object} Column config.
			 */
			getColumnConfig: function() {
				return this.sandbox.publish("GetColumnConfig", null, [this.sandbox.id]);
			},

			/**
			 * Method create new lookup schema.
			 * @protected
			 * @param {Object} config New lookup config.
			 * @param {String} config.name New lookup name.
			 * @param {String} config.caption New lookup caption.
			 * @param {String} config.packageUId New lookup package UId.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			createReferenceEntitySchema: function(config, callback, scope) {
				const name = config.name;
				const caption = config.caption;
				const packageUId = config.packageUId;
				BPMSoft.EntitySchemaManager.initialize(function() {
					const newEntityUId = BPMSoft.generateGUID();
					const newSchema = BPMSoft.EntitySchemaManager.createSchema({
						uId: newEntityUId,
						name: name,
						packageUId: packageUId,
						caption: {}
					});
					newSchema.setLocalizableStringPropertyValue("caption", caption);
					const baseLookupUId = BPMSoft.DesignTimeEnums.BaseSchemaUId.BASE_LOOKUP;
					newSchema.setParent(baseLookupUId, function() {
						const entitySchema = BPMSoft.EntitySchemaManager.addSchema(newSchema);
						BPMSoft.DataManager.initEntitySchemaDataCollection(name);
						newSchema.define();
						BPMSoft.ApplicationStructureWizardUtils.createLookupManagerItem(entitySchema, function() {
							callback.call(scope, entitySchema);
						}, this);
					}, this);
				}, this);
			},

			/**
			 * Initialize schema name prefix
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initSchemaNamePrefix: function(callback, scope) {
				const schemaNamePrefix = BPMSoft.ClientUnitSchemaManager.schemaNamePrefix;
				this.set("SchemaNamePrefix", schemaNamePrefix);
				callback.call(scope);
			},

			/**
			 * Initialize schema column name list.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initSchemaColumnsNames: function(callback, scope) {
				const sandbox = this.sandbox;
				const schemaColumnsNames = sandbox.publish("GetSchemaColumnsNames", null, [sandbox.id]);
				const designerDisplayConfig = this.get("DesignerDisplayConfig");
				if (!designerDisplayConfig.isNewColumn) {
					const column = this.get("Column");
					const currentColumnName = column.getPropertyValue("name");
					const indexOfCurrentColumn = schemaColumnsNames.indexOf(currentColumnName);
					if (indexOfCurrentColumn !== -1) {
						schemaColumnsNames.splice(indexOfCurrentColumn, 1);
					}
				}
				this.set("SchemaColumnsNames", schemaColumnsNames);
				callback.call(scope);
			},

			/**
			 * Initialize designer display config.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initDesignerDisplayConfig: function(callback, scope) {
				const sandbox = this.sandbox;
				const designerDisplayConfig = sandbox.publish("GetDesignerDisplayConfig", null, [sandbox.id]);
				this.set("DesignerDisplayConfig", designerDisplayConfig);
				callback.call(scope);
			},

			/**
			 * Returned caption for designer column.
			 * @protected
			 * @return {String} Designer column caption.
			 */
			getDesignerCaption: function() {
				const config = this.get("DesignerDisplayConfig");
				const parentViewModel = this.get("ModelItem").parentViewModel;
				let caption = config && config.isNewColumn
					? this.get("Resources.Strings.NewColumnCaption")
					: this.get("Resources.Strings.DesignerCaption");
				if (!parentViewModel.get("IsPrimary")) {
					caption += " (" + parentViewModel.get("Caption") + ")";
				}
				return caption;
			},

			/**
			 * Initialize model default values.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.initColumnAttributes();
					const columnConfig = this.getColumnConfig();
					const column = columnConfig.column;
					this.set("Column", column);
					this.set("UseNewLookup", false);
					BPMSoft.chain(
						this.initSchemaNamePrefix,
						this.initDesignerDisplayConfig,
						this.initSchemaColumnsNames,
						function(next) {
							BPMSoft.SchemaDesignerUtilities.getDataValueTypeInfo(next, this);
						},
						function(next, dataValueTypeInfo) {
							this.set("DataValueTypeConfig", dataValueTypeInfo);
							this.setAttributes(column);
							this._subscribeOnAttributeChanges();
							callback.call(scope);
						}, this);
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this._unsubscribeOnAttributeChanges();
				this.callParent(arguments);
			},

			/**
			 * Initializes entity schema column attributes.
			 * @protected
			 */
			initColumnAttributes: function() {
				this.columns.Name.size = BPMSoft.EntitySchemaManager.getMaxEntitySchemaNameLength() -
					BPMSoft.DesignTimeEnums.EntitySchemaColumnSizes.ENTITY_SCHEMA_COLUMN_ID_SUFFIX_SIZE -
					BPMSoft.EntitySchemaManager.getSchemaNamePrefix().length;
				this.columns.Caption.size = BPMSoft.DesignTimeEnums.EntitySchemaColumnSizes.MAX_CAPTION_SIZE;
			},

			/**
			 * Method set model property by column.
			 * @protected
			 * @param {BPMSoft.manager.EntitySchemaColumn} entitySchemaColumn Column.
			 */
			setAttributes: function(entitySchemaColumn) {
				const attributeColumnPropertyNames = this.getPropertyTranslator();
				BPMSoft.each(attributeColumnPropertyNames, function(columnPropertyName, attributeName) {
					let value = entitySchemaColumn.getPropertyValue(columnPropertyName);
					if (value && value instanceof BPMSoft.LocalizableString) {
						value = value.getValue() || "";
					}
					if (columnPropertyName === "dataValueType" && value) {
						const dataValueTypeCaption = this.getDataValueTypeCaption(value);
						value = this.getLookupValue(value, dataValueTypeCaption);
					}
					if (columnPropertyName === "referenceSchemaUId" && !BPMSoft.isEmpty(value)) {
						BPMSoft.EntitySchemaManager.getItemByUId(value, function(item) {
							const schemaCaption = item.getCaption();
							value = this.getLookupValue(value, schemaCaption);
							this.setColumnValue(attributeName, value, {preventValidation: true});
						}, this);
						return;
					}
					this.setColumnValue(attributeName, value, {preventValidation: true});
				}, this);
			},

			/**
			 * Returns object for lookup column.
			 * @protected
			 * @param {String} value Value.
			 * @param {String} displayValue Display value.
			 * @return {Object} Object for lookup column.
			 */
			getLookupValue: function(value, displayValue) {
				return {
					value: value,
					displayValue: displayValue
				};
			},

			/**
			 * Returns data value type caption.
			 * @protected
			 * @param {String} value Value.
			 * @return {String} Data value type caption.
			 */
			getDataValueTypeCaption: function(value) {
				let dataValueTypeCaption = null;
				const dataValueTypesConfig = this.get("DataValueTypeConfig");
				BPMSoft.each(dataValueTypesConfig, function(dataValueType) {
					if (dataValueType.DataValueType === value) {
						dataValueTypeCaption = dataValueType.Caption;
						return false;
					}
				}, this);
				return dataValueTypeCaption;
			},

			/**
			 * Returns dictionary of conformity property between view model and column.
			 * @protected
			 * @return {Object} Dictionary of conformity property between view model and column.
			 */
			getPropertyTranslator: function() {
				return {
					"UId": "uId",
					"Caption": "caption",
					"Name": "name",
					"Description": "description",
					"DataValueType": "dataValueType",
					"ReferenceSchemaUId": "referenceSchemaUId",
					"IsRequired": "isRequired",
					"IsValueCloneable": "isValueCloneable",
					"IsSimpleLookup": "isSimpleLookup",
					"IsCascade": "isCascade",
					"IsInherited": "isInherited"
				};
			},

			/**
			 * Returns isSimpleLookup field visible flag.
			 * @protected
			 * @return {Boolean} isSimpleLookup field visible flag.
			 */
			isLookupDataValueType: function() {
				let dataValueType = this.get("DataValueType");
				dataValueType = dataValueType && dataValueType.value;
				return BPMSoft.isLookupDataValueType(dataValueType);
			},

			/**
			 * Returns property list for current column data type.
			 * @protected
			 * @param {BPMSoft.DataValueType} dataValueType Data type.
			 * @return {Array} Property list.
			 */
			getActualFieldsConfig: function(dataValueType) {
				const commonConfig = ["UId", "DataValueType", "Caption", "Name", "Description", "IsRequired",
					"IsValueCloneable"];
				const typedConfig = {
					LOOKUP: ["ReferenceSchemaUId", "IsSimpleLookup", "IsCascade"]
				};
				const dataValueTypeName = this.getDataValueTypeName(dataValueType);
				const resultConfig = commonConfig.concat(typedConfig[dataValueTypeName] || []);
				return resultConfig;
			},

			/**
			 * Returns data type name.
			 * @protected
			 * @param {BPMSoft.DataValueType} dataValueType Data type.
			 * @return {String} Data type name.
			 */
			getDataValueTypeName: function(dataValueType) {
				let dataValueTypeName = null;
				BPMSoft.each(BPMSoft.DataValueType, function(value, name) {
					if (value === dataValueType) {
						dataValueTypeName = name;
						return false;
					}
				}, this);
				return dataValueTypeName;
			},

			/**
			 * Method prepared data value type list.
			 * @protected
			 * @param {String} filter Filter.
			 * @param {BPMSoft.core.collections.Collection} list List.
			 */
			prepareDataValueTypeList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getDataValueTypeList());
			},

			/**
			 * Returns data value type list.
			 * @protected
			 * @return {Object} Data value type list.
			 */
			getDataValueTypeList: function() {
				const resultConfig = {};
				const dataValueTypeConfig = this.get("DataValueTypeConfig");
				BPMSoft.each(dataValueTypeConfig, function(dataValueType) {
					const dataValueTypeName = dataValueType.DataValueType;
					const dataValueTypeCaption = dataValueType.Caption;
					resultConfig[dataValueTypeName] = {
						value: dataValueTypeName,
						displayValue: dataValueTypeCaption
					};
				}, this);
				return resultConfig;
			},

			/**
			 * Method prepared reference schema list.
			 * @protected
			 * @param {String} filter Filter.
			 * @param {BPMSoft.core.collections.Collection} list List.
			 */
			prepareReferenceSchemaList: function(filter, list) {
				if (list === null) {
					return;
				}
				this.getReferenceSchemaList(function(referenceSchemaList) {
					list.reloadAll(referenceSchemaList);
				}, this);
			},

			/**
			 * Returns reference schema list.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getReferenceSchemaList: function(callback, scope) {
				BPMSoft.chain(
					function(next) {
						this.getCurrentPackageUId(next, this);
					},
					function(next, packageUId) {
						BPMSoft.EntitySchemaManager.findPackageItems(packageUId, next, this);
					},
					function(next, items) {
						const resultConfig = {};
						items.each(function(item) {
							resultConfig[item.getUId()] = {
								value: item.getUId(),
								displayValue: item.getCaption()
							};
						}, this);
						callback.call(scope, BPMSoft.sortObj(resultConfig, "displayValue"));
					},
					this
				);
			},

			/**
			 * Returns current package UId.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 * @return {String} Package UId.
			 */
			getCurrentPackageUId: function(callback, scope) {
				const sysPackageUId = this.sandbox.publish("GetNewLookupPackageUId", null, [this.sandbox.id]);
				callback.call(scope, sysPackageUId);
			},

			/**
			 * Method update column reference link before save.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			initReferenceSchemaBeforeSave: function(callback, scope) {
				const useNewLookup = this.get("UseNewLookup");
				const isInherited = this.get("IsInherited");
				const chain = [];
				if (this.isLookupDataValueType() && useNewLookup && !isInherited) {
					chain.push(
						this.getCurrentPackageUId,
						function(next, packageUId) {
							const createSchemaConfig = {
								name: this.get("NewSchemaName"),
								caption: this.get("NewSchemaCaption"),
								packageUId: packageUId
							};
							this.createReferenceEntitySchema(createSchemaConfig, next, this);
						},
						function(next, instance) {
							this.set("ReferenceSchemaUId", {
								value: instance.getUId(),
								displayValue: instance.getCaption()
							});
							next();
						}
					);
				}
				chain.push(function() {
					callback.call(scope);
				}, this);
				BPMSoft.chain.apply(this, chain);
			},

			/**
			 * Validate column name by column list in entity.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			columnDuplicateNameValidator: function(value) {
				let message = "";
				const schemaColumnsNames = this.get("SchemaColumnsNames");
				if (!Ext.isEmpty(schemaColumnsNames)) {
					const lowerCaseNames = schemaColumnsNames.map(function(name) {
						return name.toLowerCase();
					}, this);
					const lowerCaseValue = value.toLowerCase();
					if (Ext.Array.contains(lowerCaseNames, lowerCaseValue)) {
						message = this.get("Resources.Strings.DuplicateColumnNameMessage");
					}
				}
				return {invalidMessage: message};
			},

			/**
			 * Validate column name by contain required prefix.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			columnPrefixValidator: function(value) {
				let message = "";
				const schemaNamePrefix = this.get("SchemaNamePrefix");
				if (!Ext.isEmpty(schemaNamePrefix) && !this.get("IsInherited")) {
					const validColumnPrefixRegExp = new RegExp("^" + schemaNamePrefix + ".*$");
					if (!validColumnPrefixRegExp.test(value)) {
						message = Ext.String.format(this.get("Resources.Strings.WrongPrefixMessage"),
							schemaNamePrefix);
					}
				}
				return {invalidMessage: message};
			},

			/**
			 * Validate column name by contain invalid char.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			columnNameRegExpValidator: function(value) {
				let message = "";
				const validColumnNameRegExp = /^[a-zA-Z_]{1}[a-zA-Z0-9_]*$/;
				if (!validColumnNameRegExp.test(value)) {
					message = this.get("Resources.Strings.WrongColumnNameMessage");
				}
				return {invalidMessage: message};
			},

			/**
			 * Validate new lookup name by manager list.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			schemaDuplicateNameValidator: function(value) {
				let message = "";
				if (this.get("UseNewLookup")) {
					const entitySchemaManagerItems = BPMSoft.EntitySchemaManager.getItems();
					const filteredEntitySchemaManagerItems = entitySchemaManagerItems.filterByFn(function(item) {
						return item.name.toLowerCase() === value.toLowerCase();
					}, this);
					if (!filteredEntitySchemaManagerItems.isEmpty()) {
						message = this.get("Resources.Strings.DuplicateSchemaNameMessage");
					}
				}
				return {invalidMessage: message};
			},

			/**
			 * Validate new lookup name by contain required prefix.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			schemaNamePrefixValidator: function(value) {
				let message = "";
				const schemaNamePrefix = this.get("SchemaNamePrefix");
				if (!Ext.isEmpty(schemaNamePrefix) && this.get("UseNewLookup")) {
					const validSchemaNamePrefixRegExp = new RegExp("^" + schemaNamePrefix + ".*$");
					if (!validSchemaNamePrefixRegExp.test(value)) {
						message = Ext.String.format(this.get("Resources.Strings.WrongPrefixMessage"),
							schemaNamePrefix);
					}
				}
				return {invalidMessage: message};
			},

			/**
			 * Validate new lookup name by contain invalid char.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			schemaNameRegExpValidator: function(value) {
				let message = "";
				if (this.get("UseNewLookup")) {
					const validSchemaNameRegExp = /^[a-zA-Z]{1}[a-zA-Z0-9]*$/;
					if (!validSchemaNameRegExp.test(value)) {
						message = this.get("Resources.Strings.WrongSchemaNameMessage");
					}
				}
				return {invalidMessage: message};
			},

			/**
			 * Validate new lookup name by length.
			 * @protected
			 * @param {String} value Value for validate.
			 * @return {Object} Validate response.
			 */
			schemaNameLengthValidator: function(value) {
				let message = "";
				if (this.get("UseNewLookup")) {
					const maxLength = BPMSoft.EntitySchemaManager.getMaxEntitySchemaNameLength();
					if (value.length >= maxLength) {
						message = Ext.String.format(this.get("Resources.Strings.WrongSchemaNameLengthMessage"),
							maxLength);
					}
				}
				return {invalidMessage: message};
			},

			/**
			 * Method update column by view model.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			updateColumn: function(callback, scope) {
				const dataValueTypeLookupValue = this.get("DataValueType");
				const dataValueType = dataValueTypeLookupValue.value;
				const actualFieldsConfig = this.getActualFieldsConfig(dataValueType);
				const column = this.get("Column");
				const attributeColumnPropertyNames = this.getPropertyTranslator();
				BPMSoft.each(actualFieldsConfig, function(fieldName) {
					const columnPropertyName = attributeColumnPropertyNames[fieldName];
					let attributeValue = this.get(fieldName);
					const columnValue = column.getPropertyValue(columnPropertyName);
					if (BPMSoft.instanceOfClass(columnValue, "BPMSoft.LocalizableString")) {
						column.setLocalizableStringPropertyValue(columnPropertyName, attributeValue);
						return;
					}
					attributeValue = (attributeValue && attributeValue.value) || attributeValue;
					column.setPropertyValue(columnPropertyName, attributeValue);
				}, this);
				column.fireEvent("changed", {}, this);
				callback.call(scope);
			},

			/**
			 * Validate view model on async mode.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			asyncValidate: function(callback, scope) {
				const validationResult = this.validate();
				callback.call(scope, validationResult);
			},

			/**
			 * Save column property.
			 * @protected
			 */
			save: function() {
				BPMSoft.chain(
					this.asyncValidate,
					function(next, validationResult) {
						if (validationResult) {
							next();
						}
					},
					this.initReferenceSchemaBeforeSave,
					this.updateColumn,
					function() {
						this.onSaved();
					}, this);
			},

			/**
			 * OnSaved column property handler.
			 * @protected
			 */
			onSaved: BPMSoft.emptyFn,

			/**
			 * Cancel save column property handler.
			 * @protected
			 */
			cancel: BPMSoft.emptyFn

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "ColumnPropertiesControlGroup",
				"parentName": "BaseDesignerContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"items": []
				}
			},
			{
				"operation": "move",
				"name": "BaseDesignerFooterContainer",
				"parentName": "ColumnPropertiesControlGroup",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "BaseDesignerFooterContainer",
				"values": {
					"layout": {"row": 0}
				}
			},
			{
				"operation": "insert",
				"name": "MainPropertiesContainer",
				"parentName": "BaseDesignerFooterContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "CaptionContainer",
				"parentName": "MainPropertiesContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["field-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Caption",
				"parentName": "CaptionContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.ColumnCaption"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "NameContainer",
				"parentName": "MainPropertiesContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["field-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Name",
				"parentName": "NameContainer",
				"propertyName": "items",
				"values": {
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.NameLabel"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsRequiredContainer",
				"parentName": "AdditionalPropertiesControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["field-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "IsRequired",
				"parentName": "IsRequiredContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.isRequiredLabel"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DataValueType",
				"parentName": "MainPropertiesContainer",
				"propertyName": "items",
				"values": {
					"visible": false,
					"contentType": BPMSoft.ContentType.ENUM,
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.DataValueTypeLabel"}
					},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "prepareDataValueTypeList"},
						"list": {"bindTo": "dataValueTypeList"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "LookupPropertiesControlGroup",
				"parentName": "BaseDesignerFooterContainer",
				"propertyName": "items",
				"values": {
					"visible": {"bindTo": "isLookupDataValueType"},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					caption: {bindTo: "Resources.Strings.LookupCaption"},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "OrNewLookupContainer",
				"parentName": "LookupPropertiesControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["field-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "UseNewLookup",
				"parentName": "OrNewLookupContainer",
				"propertyName": "items",
				"values": {
					"value": {"bindTo": "UseNewLookup"},
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"classes": {
						"wrapClassName": ["use-new-lookup"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "UseNewLookup",
				"propertyName": "items",
				"name": "UseNewLookupFalse",
				"values": {
					"caption": {"bindTo": "Resources.Strings.UseExistingLookupCaption"},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"markerValue": "UseNewLookupFalse",
					"value": false
				}
			},
			{
				"operation": "insert",
				"parentName": "UseNewLookup",
				"propertyName": "items",
				"name": "UseNewLookupTrue",
				"values": {
					"caption": {"bindTo": "Resources.Strings.CreateNewLookupCaption"},
					"visible": {"bindTo": "isLookupDataValueType"},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"markerValue": "UseNewLookupTrue",
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "ReferenceSchemaUIdContainer",
				"parentName": "LookupPropertiesControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["field-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ReferenceSchemaUId",
				"parentName": "ReferenceSchemaUIdContainer",
				"propertyName": "items",
				"values": {
					"contentType": BPMSoft.ContentType.ENUM,
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.referenceSchemaUIdLabel"}
					},
					"visible": {
						"bindTo": "UseNewLookup",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"controlConfig": {
						"prepareList": {"bindTo": "prepareReferenceSchemaList"},
						"list": {"bindTo": "ReferenceSchemaUIdList"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "NewSchemaCaption",
				"parentName": "ReferenceSchemaUIdContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.NewSchemaCaptionFieldCaption"}
					},
					"visible": {"bindTo": "UseNewLookup"},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "NewSchemaName",
				"parentName": "ReferenceSchemaUIdContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.NewSchemaNameFieldCaption"}
					},
					"visible": {"bindTo": "UseNewLookup"},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "LookupPropertiesGridLayout",
				"parentName": "LookupPropertiesControlGroup",
				"propertyName": "items",
				"values": {
					"visible": {"bindTo": "isLookupDataValueType"},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "IsSimpleLookupCaption",
				"parentName": "LookupPropertiesGridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"caption": {"bindTo": "Resources.Strings.LookupTypeCaption"},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["lookup-view-label"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsSimpleLookup",
				"parentName": "LookupPropertiesGridLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"value": {"bindTo": "IsSimpleLookup"},
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "IsSimpleLookup",
				"propertyName": "items",
				"name": "IsSimpleLookupFalse",
				"values": {
					"caption": {"bindTo": "Resources.Strings.LookupTypeLabel"},
					"visible": {"bindTo": "isLookupDataValueType"},
					"markerValue": "IsSimpleLookupFalse",
					"value": false
				}
			},
			{
				"operation": "insert",
				"parentName": "IsSimpleLookup",
				"propertyName": "items",
				"name": "IsSimpleLookupTrue",
				"values": {
					"caption": {"bindTo": "Resources.Strings.DropDownTypeLabel"},
					"visible": {"bindTo": "isLookupDataValueType"},
					"markerValue": "IsSimpleLookupTrue",
					"value": true
				}
			},
			{
				"operation": "insert",
				"name": "AdditionalPropertiesControlGroup",
				"parentName": "BaseDesignerFooterContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {bindTo: "Resources.Strings.AdditionalPropertiesCaption"},
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "IsCascade",
				"parentName": "AdditionalPropertiesControlGroup",
				"propertyName": "items",
				"values": {
					"visible": {"bindTo": "isLookupDataValueType"},
					"enabled": {
						"bindTo": "IsInherited",
						"bindConfig": {"converter": "invertBooleanValue"}
					},
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.isCascadeLabel"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsValueCloneable",
				"parentName": "AdditionalPropertiesControlGroup",
				"propertyName": "items",
				"values": {
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.isValueCloneableLabel"}
					},
					"classes": {
						"wrapClassName": ["is-value-cloneable"]
					},
					"tip": {
						"content": {"bindTo": "Resources.Strings.IsValueCloneableHint"}
					}
				}
			}
		]
	};
});
