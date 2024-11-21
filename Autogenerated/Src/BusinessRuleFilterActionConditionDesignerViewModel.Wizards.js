define("BusinessRuleFilterActionConditionDesignerViewModel",
	["BusinessRuleFilterActionConditionDesignerViewModelResources", "BusinessRuleConditionDesignerViewModel",
	"ExpressionEnums", "css!BusinessRuleFilterActionConditionDesignerViewModel"], function(resources) {

	/**
	 * @class BPMSoft.Designers.BusinessRuleFilterActionConditionDesignerViewModel
	 */
	Ext.define("BPMSoft.Designers.BusinessRuleFilterActionConditionDesignerViewModel", {
		extend: "BPMSoft.BusinessRuleConditionDesignerViewModel",
		alternateClassName: "BPMSoft.BusinessRuleFilterActionConditionDesignerViewModel",

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getExpressionsConfig
		 * @overridden
		 */
		getExpressionsConfig: function(metaItem) {
			const config = this.callParent(arguments);
			config.autoComplete = metaItem.rightExpression.autocomplete
			config.autoClean = metaItem.leftExpression.autoClean
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#setPreparedPropertiesIntoViewModel
		 * @overridden
		 */
		setPreparedPropertiesIntoViewModel: function(config) {
			this.callParent(arguments);
			this.set("AutoComplete", config.autoComplete);
			this.set("AutoClean", config.autoClean);
		},

		getIsAutoCleanOrAutoCompleteVisible: function() {
			const leftExpression = this.$LeftExpressionValue
			const rightExpression = this.$RightExpressionValue
			const leftExpressionType = this.$LeftExpressionType;
			const rightExpressionType = this.$RightExpressionType;
			if (!leftExpression || !rightExpression) {
				return false;
			}
			const rightExpressionValue = rightExpression.value || "";
			const rightExpressionValueMetapthLength = rightExpressionValue.split(".").length;
			if (rightExpressionValueMetapthLength !== 1) {
				return false;
			}
			return leftExpressionType === BPMSoft.ExpressionEnums.ExpressionType.COLUMN &&
				rightExpressionType === BPMSoft.ExpressionEnums.ExpressionType.COLUMN;
		},

		getLeftExpressionAdditionalCheckboxCaption: function() {
			const rightExpression = this.$RightExpressionValue;
			const dataModelName = this.$RightExpressionDataModelName;
			if (!rightExpression || !dataModelName) {
				return "";
			}
			const entitySchema = BPMSoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(dataModelName,
				this.pageSchemaUId);
			const columnUId = rightExpression.value.split(".")[0];
			const column = entitySchema.findColumnByUId(columnUId);
			if (!column) {
				return "";
			}
			return BPMSoft.getFormattedString(resources.localizableStrings.AutoCleanCaption, column.caption);
		},

		getRightExpressionAdditionalCheckboxCaption: function() {
			const leftExpression = this.$LeftExpressionValue;
			const dataModelName = this.$LeftExpressionDataModelName;
			if (!leftExpression || !dataModelName) {
				return "";
			}
			const entitySchema = BPMSoft.BusinessRuleSchemaManager.getEntitySchemaByDataModel(dataModelName,
				this.pageSchemaUId);
			const columnUId = leftExpression.value.split(".")[0];
			const column = entitySchema.findColumnByUId(columnUId);
			if (!column) {
				return "";
			}
			return BPMSoft.getFormattedString(resources.localizableStrings.AutoCompleteCaption, column.caption);
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#createLeftExpressionMetaItem
		 * @overridden
		 */
		createLeftExpressionMetaItem: function() {
			const leftExpression = this.callParent(arguments);
			leftExpression.setPropertyValue("autoClean", this.get("AutoClean"));
			return leftExpression;
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#createRightExpressionMetaItem
		 * @overridden
		 */
		createRightExpressionMetaItem: function() {
			const rightExpression = this.callParent(arguments);
			if (rightExpression) {
				rightExpression.setPropertyValue("autocomplete", this.get("AutoComplete"));
			}
			return rightExpression;
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getAvailableComparisonTypeNames
		 * @overridden
		 */
		getAvailableComparisonTypeNames: function() {
			return ["EQUAL", "NOT_EQUAL", "GREATER", "GREATER_OR_EQUAL", "LESS", "LESS_OR_EQUAL"];
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			var classes = config.classes = (config.classes || {});
			var wrapClassName = classes.wrapClassName = (classes.wrapClassName || []);
			wrapClassName.push("business-rules-filter-action-condition");
			return config;
		},

		/**
		 * Left expression sync validator
		 * @protected
		 * @param {Mixed} value Left expression value.
		 * @return {Object} Validation info.
		 */
		validateLeftExpressionValue: function(value) {
			return this.validateColumnPathCodeSymbolValue(value && value.name, {
				"minPartCount": 2,
				"invalidMessage": resources.localizableStrings.InvalidLeftExpressionFormatMessage
			});
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#onLeftExpressionTypeChanged
		 * @overridden
		 */
		onLeftExpressionTypeChanged: function(model, expressionType) {
			if (expressionType === BPMSoft.ExpressionEnums.ExpressionType.PARAMETER) {
				this.loadLeftExpressionEntitySchemaColumnVocabulary();
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getAsyncValidateLeftExpressionConfig
		 * @overridden
		 */
		getAsyncValidateLeftExpressionConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply(config, {
				"columnCaption": this.get("DefaultExpressionCaption"),
				"minPartCount": 2,
				"invalidFormatMessage": resources.localizableStrings.InvalidLeftExpressionFormatMessage
			});
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getAsyncValidateRightExpressionConfig
		 * @overridden
		 */
		getAsyncValidateRightExpressionConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply(config, {
				"autocomplete": this.get("AutoComplete"),
				"autoClean": this.get("AutoClean"),
				"columnCaption": this.get("DefaultExpressionCaption"),
				"maxPartCount": 1
			});
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getLeftExpressionControlConfig
		 * @overridden
		 */
		getLeftExpressionControlConfig: function() {
			const config = this.callParent(arguments);
			return Ext.apply(config, {
				"placeholder": resources.localizableStrings.LeftExpressionPlaceholder,
				"typeVisible": !this.isEntitySchemaBased(),
				"showAdditionalCheckbox": {"bindTo": "getIsAutoCleanOrAutoCompleteVisible"},
				"additionalCheckboxValue": {"bindTo": "AutoClean"},
				"additionalCheckboxCaption": {"bindTo": "getLeftExpressionAdditionalCheckboxCaption"},
				"wrapClass": "filter-left-expression",
				"contentType": BPMSoft.ContentType.LOOKUP
			});
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getRightExpressionControlConfig
		 * @overridden
		 */
		getRightExpressionControlConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply(config, {
				"placeholder": resources.localizableStrings.RightExpressionPlaceholder,
				"showAdditionalCheckbox": {"bindTo": "getIsAutoCleanOrAutoCompleteVisible"},
				"additionalCheckboxValue": {"bindTo": "AutoComplete"},
				"additionalCheckboxCaption": {"bindTo": "getRightExpressionAdditionalCheckboxCaption"},
				"wrapClass": "filter-right-expression"
			});
		},

		/**
		 * @inheritdoc BPMSoft.BusinessRuleConditionDesignerViewModel#getLeftExpressionTypeList
		 * @overridden
		 */
		getLeftExpressionTypeList: function() {
			const Type = BPMSoft.ExpressionEnums.ExpressionType;
			const types = [];
			if (this.isEntitySchemaBased()) {
				types.push(Type.COLUMN);
			} else {
				types.push(Type.PARAMETER);
				const dataSource = BPMSoft.BusinessRuleSchemaManager.getDataSourcesConfig(this.pageSchemaUId);
				if (!BPMSoft.isEmptyObject(dataSource)) {
					types.push(Type.DATASOURCE);
				}
			}
			return types;
		},

		// endregion

		// region Methods: Public

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.validationConfig.LeftExpressionValue = [this.validateLeftExpressionValue];
		},

		/**
		 * @inheritdoc BPMSoft.BaseModel#getModelColumns
		 * @override
		 */
		getModelColumns: function() {
			const columns = this.callParent(arguments);
			columns.AutoComplete = {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			};
			columns.AutoClean = {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			};
			return columns;
		},

		// endregion

	});
	return BPMSoft.BusinessRuleFilterActionConditionDesignerViewModel;
});
