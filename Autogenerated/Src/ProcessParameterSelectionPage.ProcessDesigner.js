/**
 * Parent: ProcessMappingPage
 */
define("ProcessParameterSelectionPage", ["BPMSoft", "ProcessParameterSelectionPageResources", "MappingEnums"],
	function(BPMSoft) {
		return {
			attributes: {

				/**
				 * Indicates if return value needs conversion to display value.
				 * @protected
				 * @type {Boolean}
				 */
				"ConvertToDisplayValue": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			messages: {

				/**
				 * @message SetParametersInfo
				 * Passes parameters data.
				 */
				"SetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetSelectedProcessParameter
				 * Returns selected process parameter.
				 */
				"GetSelectedProcessParameter": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetParameterMappingInfo
				 * Returns the parameter mapping data.
				 */
				"GetParameterMappingInfo": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 *  Inits mapping type parameter if it is null.
				 *  @private
				 */
				subscribeGetParameterMappingInfo: function(viewModel) {
					var tabName = viewModel.get("Name");
					var sandbox = this.sandbox;
					var pageId = sandbox.id + tabName;
					sandbox.subscribe("GetParameterMappingInfo", function() {
						return {
							schemaElementUId: this.get("SchemaElementUId"),
							parameterUId: this.get("ParameterUId"),
							entityColumnUId: this.get("EntityColumnUId")
						};
					}, this, [pageId]);
				},

				/**
				 * Returns default active tab name.
				 * @protected
				 * return {String}
				 */
				getDefActiveTabName: function() {
					var tabName = "TabElementsMapping";
					var mappingType = this.get("MappingType");
					if (mappingType === BPMSoft.MappingEnums.MappingType.LOOKUP) {
						tabName = "TabValueMapping";
					} else if (mappingType === BPMSoft.MappingEnums.MappingType.SYSTEM_SETTINGS) {
						tabName = "TabSysSettingsMapping";
					}
					return tabName;
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getProfile
				 * @overridden
				 */
				getProfile: function() {
					var profile = this.callParent(arguments);
					var parameterUId = this.get("ParameterUId");
					if (!parameterUId || this.BPMSoft.isEmptyGUID(parameterUId)) {
						this.initDefProfileActiveTabName(profile);
						return profile;
					}
					var schemaElementUId = this.get("SchemaElementUId");
					profile.activeTabName = schemaElementUId && !this.BPMSoft.isEmptyGUID(schemaElementUId)
						? this.getDefActiveTabName()
						: "TabParametersMapping";
					return profile;
				},

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#loadModule
				 * @overridden
				 */
				loadModule: function(viewModel) {
					this.subscribeGetParameterMappingInfo(viewModel);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#addQuote
				 * @overridden
				 */
				addQuote: Ext.emptyFn,

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#initFormulaParameters
				 * @overridden
				 */
				initFormulaParameters: Ext.emptyFn,

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#onSaveClick
				 * @overridden
				 */
				onSaveClick: function() {
					var activeRows = this.get("ActiveRowLookupValueResult");
					if (!activeRows || !activeRows.selectedRows) {
						this.close();
						return;
					}
					var selectedRow = activeRows.selectedRows.getByIndex(0);
					this.publishSetParameterInfoMessage(selectedRow);
				},

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#getPreparedFormulaResult
				 * @overridden
				 * @param {String} displayValue display value.
				 * @param {String} value The formula source value.
				 * @return {Object} Selected data.
				 * @return {String} return.value Resulted value.
				 * @return {String} return.displayValue Resulted display value.
				 * @return {Number} return.source Resulted parameter value source.
				 * @return {GUID} return.referenceSchemaUId Resulted reference schema identifier.
				 */
				getPreparedFormulaResult: function(displayValue, value) {
					var result = {
						value: value,
						isValid: true,
						displayValue: displayValue,
						source: Ext.isEmpty(value)
							? BPMSoft.ProcessSchemaParameterValueSource.None
							: BPMSoft.ProcessSchemaParameterValueSource.Script,
						dataValueType: this.get("DataValueType")
					};
					var lookupSchema = this.get("LookupSchema");
					if (lookupSchema) {
						result.referenceSchemaUId = lookupSchema.value;
					}
					return this.applyInvokerResultConfig(result);
				},

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#getFormulaValue
				 * @overridden
				 * @param {String} displayValue display value.
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback function scope.
				 */
				getFormulaValue: function(displayValue, callback, scope) {
					var schema = this.get("ProcessSchema");
					var dataValueType = this.get("DataValueType");
					var parameterName = this.get("ParameterName");
					var elementName = this.get("ElementName");
					var config = {
						displayValue: displayValue,
						schema: schema,
						dataValueType: dataValueType,
						parameterName: parameterName,
						elementName: elementName
					};
					BPMSoft.FormulaParserUtils.parseFormulaValue(config, callback, scope);
				},

				/**
				 * Published setParameterInfo Message.
				 * @private
				 * @param {Object) data selected value parameters.
				 */
				publishSetParameterInfoMessage: function(data) {
					if (!data) {
						this.close();
						return;
					}
					var sandbox = this.sandbox;
					var displayValue = null;
					if (this.get("ConvertToDisplayValue")) {
						var parameterValues = this.getParameterValues(data);
						displayValue = BPMSoft.ProcessSchemaDesignerUtilities.addParameterMask(
							parameterValues.displayValue);
						this.getFormulaValue(displayValue, function(result) {
							var parameterInfo = this.getPreparedFormulaResult(displayValue, result.value);
							sandbox.publish("SetParametersInfo", parameterInfo, [sandbox.id]);
						}, this);
					} else {
						sandbox.publish("SetParametersInfo", data, [sandbox.id]);
					}
				},

				/**
				 * @inheritdoc BPMSoft.ProcessMappingPage#onResultSelectedRows
				 * @overridden
				 */
				onResultSelectedRows: function(lookupValueResult) {
					var selectedRows = lookupValueResult.selectedRows;
					if (selectedRows) {
						var activeRows = this.get("ActiveRowLookupValueResult");
						var selectedRow = activeRows && activeRows.selectedRows
							? activeRows.selectedRows.getByIndex(0)
							: selectedRows.getByIndex(0);
						if (selectedRow) {
							this.publishSetParameterInfoMessage(selectedRow);
						}
					}
				},

				/**
				 * Initializes default profile active tab name.
				 * @param {Object} profile Page profile.
				 */
				initDefProfileActiveTabName: function(profile) {
					var tabs = this.get("TabsCollection");
					if (!tabs.find(profile.activeTabName)) {
						profile.activeTabName = this.getDefActiveTabName();
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"parentName": "center-area-editPage",
					"name": "FormulaEdit"
				}
			]/**SCHEMA_DIFF*/
		};
	});
