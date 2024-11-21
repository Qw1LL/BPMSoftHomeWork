define("SimpleSourceCodeEditPage",
		["SourceCodeEditEnums", "SourceCodeEditGenerator",
			"css!ProcessElementTraceDataPageCSS"], function(SourceCodeEditEnums) {
			return {
				attributes: {
					/**
					 * Error description
					 */
					"Content": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"value": null
					}
				},
				messages: {},
				methods: {

					/**
					 * @inheritDoc BPMSoft.ModalBoxSchemaModule#init.
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent([
							function() {
								this.$Content = this.$moduleInfo && this.$moduleInfo.content;
								Ext.callback(callback, scope);
							}, this
						]);
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
						"name": "Content",
						"parentName": "ModalWindow",
						"values": {
							"contentType": BPMSoft.ContentType.RICH_TEXT,
							"generator": "SourceCodeEditGenerator.generate",
							"showLineNumbers": true,
							"id": "Content",
							"useWorker": false,
							"markerValue": "Content",
							"printMargin": false,
							"readonly": true,
							"classes": {
								"wrapClass": ["process-element-trace-data-editor"]
							},
							"language": SourceCodeEditEnums.Language.CSHARP
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
