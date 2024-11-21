define("ProcessElementTraceDataPage", ["ProcessModuleUtilities", "SourceCodeEditGenerator",
	"ReadDataUserTaskTraceDataTransformer", "css!ProcessElementTraceDataPageCSS"], function() {
	return {
		attributes: {

			/**
			 * Trace Data.
			 */
			"TraceData": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			},

			/**
			 * Process Element Log Identifier.
			 */
			"ProcessElementLog": {
				"dataValueType": BPMSoft.DataValueType.GUID
			},

			/**
			 * Trace data transformer.
			 */
			"TransformerType": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": null
			}
		},
		messages: {},
		methods: {

			/**
			 * @param sysProcessElementLog
			 * @param callback
			 * @param scope
			 * @private
			 */
			_requestTraceData: function(sysProcessElementLog, callback, scope) {
				const filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					"SysProcessElementLog", sysProcessElementLog);
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysPrcElementTraceLog"
				});
				const traceEventColumn = esq.addColumn("TraceEvent");
				traceEventColumn.orderPosition = 0;
				traceEventColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				esq.addColumn("ElementData");
				esq.addColumn("ProcessData");
				esq.filters.addItem(filter);
				esq.execute(function(response) {
					Ext.callback(callback, scope, [response]);
				}, this);
			},

			/**
			 * @param parameterConfig
			 * @return {*}
			 * @private
			 */
			_getParameterCaption: function(parameterConfig) {
				return parameterConfig.Caption || parameterConfig.Name;
			},

			/**
			 * @private
			 */
			_findParameterValueByName: function(parameters, name) {
				let value = null;
				parameters.forEach(function(item) {
					if (item.Parameter.Name === name) {
						value = item.Value;
					}
				});
				return value;
			},

			/**
			 * @private
			 */
			_actualizeParameterNamesForCollectionItem: function(parameter, collectionItem) {
				const resultRow = {};
				BPMSoft.each(collectionItem, function(parameterValue, parameterName) {
					const nestedParameter = parameter.ItemProperties.find(function(itemProperty) {
						return itemProperty.Name === parameterName;
					});
					const parameterCaption = nestedParameter ? this._getParameterCaption(nestedParameter) : parameterName;
					resultRow[parameterCaption] = this._actualizeNestedParameterNames(parameterValue, nestedParameter);
				}, this);
				return resultRow;
			},

			/**
			 * @private
			 */
			_actualizeDataItemNestedParameterNames: function(dataItem) {
				if (!dataItem) {
					return null;
				}
				return this._actualizeNestedParameterNames(dataItem.Value, dataItem.Parameter);
			},

			/**
			 * @private
			 */
			_actualizeNestedParameterNames: function(value, parameter) {
				if (!BPMSoft.isArray(value) || !BPMSoft.isArray(parameter.ItemProperties)) {
					return value;
				}
				return value.map(this._actualizeParameterNamesForCollectionItem.bind(this, parameter));
			},

			/**
			 * @private
			 */
			_createReadableParameterValue: function(parameterCaption, valueBeforeExecution, valueAfterExecution) {
				const parameterCaptionProperty = this.get("Resources.Strings.TraceDataParameterCaption");
				const valueCaption = this.get("Resources.Strings.TraceDataParameterValueCaption");
				const item = {};
				item[parameterCaptionProperty] = parameterCaption;
				item[valueCaption] = {};
				const beforeExecCaption = this.get("Resources.Strings.TraceDataParameterValueBeforeExecCaption");
				const afterExecCaption = this.get("Resources.Strings.TraceDataParameterValueAfterExecCaption");
				item[valueCaption][beforeExecCaption] = valueBeforeExecution;
				item[valueCaption][afterExecCaption] = valueAfterExecution;
				return item;
			},

			/**
			 * @private
			 */
			_getParameterValue: function(dataItemBefore, dataItemAfter) {
				const parameterCaption = this._getParameterCaption(dataItemBefore.Parameter);
				const valueBeforeExecution = this._actualizeDataItemNestedParameterNames(dataItemBefore);
				const valueAfterExecution = this._actualizeDataItemNestedParameterNames(dataItemAfter);
				return this._createReadableParameterValue(parameterCaption, valueBeforeExecution, valueAfterExecution);
			},

			/**
			 * @param dataBefore
			 * @param dataAfter
			 * @return {Array}
			 * @private
			 */
			_getParameterValues: function(dataBefore, dataAfter) {
				const result = [];
				BPMSoft.each(dataBefore, function(dataItemBefore, index) {
					const dataItemAfter = dataAfter && dataAfter[index];
					const item = this._getParameterValue(dataItemBefore, dataItemAfter);
					result.push(item);
				}, this);
				return result;
			},

			/**
			 * @param dataBefore
			 * @param dataAfter
			 * @return {[{},{}]}
			 * @private
			 */
			_parseParameterValues: function(dataBefore, dataAfter) {
				dataBefore = Ext.JSON.decode(dataBefore, true);
				dataAfter = Ext.JSON.decode(dataAfter, true);
				return [dataBefore, dataAfter];
			},

			/**
			 * @private
			 */
			_transformTraceData: function(data) {
				let transformer;
				if (this.$TransformerType) {
					transformer = this.Ext.create(this.$TransformerType);
				}
				return transformer ? transformer.transform(data) : data;
			},

			/**
			 * @param beforeExecutionData
			 * @param afterExecutionData
			 * @return {{}}
			 * @private
			 */
			_parseTraceData: function(beforeExecutionData, afterExecutionData) {
				const result = {};
				this._parseElementTraceData(result, beforeExecutionData, afterExecutionData);
				this._parseProcessTraceData(result, beforeExecutionData, afterExecutionData);
				return result;
			},

			/**
			 * @private
			 */
			_getElementParametersCaption: function() {
				return this.get("Resources.Strings.TraceDataElementCaption");
			},

			/**
			 * @private
			 */
			_parseElementTraceData: function (result, beforeExecutionData, afterExecutionData) {
				const elementParametersCaption = this._getElementParametersCaption();
				const elementParameterValues = this._parseParameterValues(
					this._transformTraceData(beforeExecutionData.get("ElementData")),
					this._transformTraceData(afterExecutionData.get("ElementData")));
				result[elementParametersCaption] = this._getParameterValues.apply(this, elementParameterValues);
			},

			/**
			 * @private
			 */
			_parseProcessTraceData: function(result, beforeExecutionData, afterExecutionData) {
				const processParametersCaption = this.get("Resources.Strings.TraceDataProcessCaption");
				const processParameterValues = this._parseParameterValues(beforeExecutionData.get("ProcessData"),
					afterExecutionData.get("ProcessData"));
				result[processParametersCaption] = this._getParameterValues.apply(this, processParameterValues);
			},

			/**
			 * @private
			 */
			_parseTraceDataResponse: function(response) {
				if (!response.success) {
					throw new BPMSoft.InvalidOperationException();
				}
				let result;
				const collection = response.collection;
				if (!collection.isEmpty()) {
					const beforeExecutionData = collection.getByIndex(0);
					const afterExecutionData = collection.getCount() > 1
						? collection.getByIndex(1)
						: new this.BPMSoft.BaseViewModel();
					result = this._parseTraceData(beforeExecutionData, afterExecutionData);
				}
				return result;
			},

			/**
			 * @private
			 */
			_onException: function() {
				const message = this.get("Resources.Strings.ParseTraceResponseErrorText");
				BPMSoft.showInformation(message);
			},

			/**
			 * @private
			 */
			_validateModuleInfo: function(moduleInfo) {
				BPMSoft.each(["processElementLog"], function(property) {
					if (Ext.isEmpty(moduleInfo[property])) {
						throw new BPMSoft.InvalidObjectState();
					}
				}, this);
			},

			/**
			 * @private
			 */
			_getIsFlowIteratorGateway: function(typeName) {
				return typeName === "BPMSoft.Core.Process.FlowIteratorGateway";
			},

			/**
			 * @private
			 */
			_handleErrorFromResponse: function(result) {
				const errorInfo = result.errorInfo;
				const message = Ext.String.format("{0}: {1}\n{2}", errorInfo.errorCode, errorInfo.message,
					errorInfo.stackTrace);
				this.error(message);
			},

			/**
			 * @private
			 */
			_rename: function(config, oldName, newName) {
				if (config) {
					config[newName] = config[oldName];
					delete config[oldName];
				}
			},

			/**
			 * @private
			 */
			_setTraceData: function(traceData) {
				this.set("TraceData", JSON.stringify(traceData, null, "\t"));
			},

			/**
			 * @private
			 */
			_localizePropertyNames: function(parameters) {
				const parameterCaption = this.get("Resources.Strings.TraceDataParameterCaption");
				const valueCaption = this.get("Resources.Strings.TraceDataParameterValueCaption");
				const beforeExecCaption = this.get("Resources.Strings.TraceDataParameterValueBeforeExecCaption");
				const afterExecCaption = this.get("Resources.Strings.TraceDataParameterValueAfterExecCaption");
				BPMSoft.each(parameters, function(parameter) {
					const parameterValue = parameter.value;
					this._rename(parameterValue, "beforeExecution", beforeExecCaption);
					this._rename(parameterValue, "afterExecution", afterExecCaption);
					this._rename(parameter, "parameter", parameterCaption);
					this._rename(parameter, "value", valueCaption);
				}, this);
			},

			/**
			 * @private
			 */
			_applyMultiInctanceElementParameters: function(traceData, parameters) {
				this._localizePropertyNames(parameters);
				const elementParametersCaption = this._getElementParametersCaption();
				const elementParameters = traceData[elementParametersCaption];
				BPMSoft.each(parameters, function(parameter) {
					elementParameters.push(parameter);
				}, this);
			},

			/**
			 * @private
			 */
			_initTraceData: function(moduleInfo) {
				if (this._getIsFlowIteratorGateway(moduleInfo.elementTypeName)) {
					const request = Ext.create("BPMSoft.ProcessMultiInstanceTraceDataRequest", {
						iteratorElementId: moduleInfo.processElementLog
					});
					request.execute(function(result) {
						if (!result.success) {
							this._handleErrorFromResponse(result);
							return;
						}
						this._requestTraceData(moduleInfo.processElementLog, function(response) {
							const traceData = this._parseTraceDataResponse(response);
							this._applyMultiInctanceElementParameters(traceData, result.parameters);
							this._setTraceData(traceData);
						}, this);
					}, this);
				} else {
					this._requestTraceData(moduleInfo.processElementLog, function(response) {
						const traceData = this._parseTraceDataResponse(response);
						this._setTraceData(traceData);
					}, this);
				}
			},

			/**
			 * @inheritDoc BPMSoft.ModalBoxSchemaModule#init.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					try {
						this.showBodyMask();
						const moduleInfo = this.get("moduleInfo") || {};
						this._validateModuleInfo(moduleInfo);
						this._initTraceData(moduleInfo);
					} catch (e) {
						this._onException(e);
					} finally {
						this.hideBodyMask();
						Ext.callback(callback, scope);
					}
				}, this]);
			},

			/**
			 * Close modal window
			 */
			close: function() {
				this.destroyModule();
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ModalWindow",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["process-element-trace-data-page-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"name": "TraceData",
				"parentName": "ModalWindow",
				"values": {
					"contentType": BPMSoft.ContentType.RICH_TEXT,
					"generator": "SourceCodeEditGenerator.generate",
					"showLineNumbers": true,
					"id": "TraceData",
					"useWorker": false,
					"markerValue": "TraceData",
					"readonly": true,
					"classes": {
						"wrapClass": ["process-element-trace-data-editor"]
					}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"name": "close-icon",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"classes": {"wrapperClass": ["close-btn-trace-data-page"]},
					"click": {"bindTo": "close"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
