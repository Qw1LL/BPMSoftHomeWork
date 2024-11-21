define("ProcessTraceDataViewMixin", ["ProcessModuleUtilities", "ProcessElementTraceDataPage"],
	function(ProcessModuleUtilities) {
		Ext.define("BPMSoft.configuration.mixins.TraceDataViewMixin", {
			alternateClassName: "BPMSoft.ProcessTraceDataViewMixin",

			/**
			 * Opens a trace data page.
			 * @param {Object} config Config.
			 * @param {String} config.elementLogId Element log identifier.
			 * @param {String} config.sysSchemaUId Process SysSchema unique identifier.
			 * @param {String} config.schemaElementUId Process schema element unique identifier.
			 * @param {String} config.elementTypeName Name of the process schema element type.
			 */
			openTracePage: function(config) {
				const id = this._getProcessElementTraceDataPageModuleId();
				const moduleInfo = {
					schemaName: "ProcessElementTraceDataPage",
					processElementLog: config.elementLogId,
					elementTypeName: config.elementTypeName
				};
				this._initElementType(config, function(elementType) {
					const transformerType = this._getTraceDataTransformerType(elementType);
					this.sandbox.loadModule("ModalBoxSchemaModule", {
						id: id,
						instanceConfig: {
							moduleInfo: moduleInfo,
							parameters: {
								viewModelConfig: {
									TransformerType: transformerType
								}
							},
							initialSize: { width: 800, height: 800 }
						}
					});
				}, this);
			},

			/**
			 * @private
			 */
			_initElementType: function(config, callback, scope) {
				if (!config.schemaElementUId || !config.sysSchemaUId) {
					Ext.callback(callback, scope);
					return;
				}
				ProcessModuleUtilities.getProcessInstanceByUId(config.sysSchemaUId, function(instance) {
					const element = instance.flowElements.findByPath("uId", config.schemaElementUId);
					let elementType;
					if (element && element.schema) {
						elementType = element.schema.name;
					}
					Ext.callback(callback, scope, [elementType]);
				}, this);
			},

			/**
			 * @private
			 */
			_getProcessElementTraceDataPageModuleId: function() {
				return this.sandbox.id + "_ProcessElementTraceDataPage";
			},

			/**
			 * @private
			 */
			_getTraceDataTransformerType: function(elementType) {
				return elementType === "ReadDataUserTask"
					? "BPMSoft.ReadDataUserTaskTraceDataTransformer"
					: null;
			}
		});
	});
