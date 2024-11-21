/**
 * Source code designer schema.
 * Parent: BaseSchemaViewModel
 */
define("SourceCodeDesigner", ["SourceCodeEditEnums", "BaseWizardStepSchemaMixin", "SourceCodeEdit",
	"css!SourceCodeDesignerCSS"
], function(sourceCodeEditEnums) {
	return {
		mixins: {
			BaseWizardStepSchemaMixin: "BPMSoft.BaseWizardStepSchemaMixin"
		},
		attributes: {
			/**
			 * Client unit schema instance.
			 */
			"ClientUnitSchema": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Source code.
			 */
			"SourceCode": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			/**
			 * Source code edit marker value.
			 */
			"SourceCodeEditMarkerValue": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "SourceCodeEdit"
			},
			/**
			 * Source code edit language. See SourceCodeEditEnums module.
			 */
			"Language": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: sourceCodeEditEnums.Language.JAVASCRIPT
			},
			/**
			 * Source code edit theme. See SourceCodeEditEnums module.
			 */
			"Theme": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: sourceCodeEditEnums.Theme.CRIMSON_EDITOR
			},
			/**
			 * Flag that indicates whether source code edit is readonly.
			 */
			"IsSourceCodeReadonly": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Flag that indicates whether source code edit is enabled.
			 */
			"IsSourceCodeEnabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Flag that indicates whether search button is visible.
			 */
			"IsSearchButtonVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Flag that indicates whether search box is visible.
			 */
			"IsSearchBoxVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Flag that indicates whether whitespaces in source code editor is visible.
			 */
			"ShowWhitespaces": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			/**
			 * Flag that indicates whether show whitespace button is visible.
			 */
			"IsWhitespaceButtonVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		methods: {

			// region Methods: Protected

			_subscribeMessages: function() {
				this.sandbox.registerMessages(this.getWizardStepMessages());
				this.sandbox.subscribe("Validate", this.onValidate, this, [this.sandbox.id]);
				this.sandbox.subscribe("Save", this.onSave, this, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this._subscribeMessages();
				var parentMethod = this.getParentMethod();
				BPMSoft.chain(
					function(next) {
						parentMethod.call(this, next, this);
					},
					function(next) {
						this.sandbox.subscribe("GetModuleConfigResult", function(config) {
							this.$PageSchema = config.clientUnitSchema;
							next();
						}, this, [this.sandbox.id]);
						this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
					},
					function() {
						this.loadSourceCode();
						this.hideBodyMask();
						callback.call(scope);
					}, this
				);
			},

			/**
			 * Loads source code from client unit schema.
			 * @protected
			 */
			loadSourceCode: function() {
				this.$SourceCode = this.$PageSchema.body;
			},

			/**
			 * Saves source code to client unit schema.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			saveSourceCode: function(callback, scope) {
				const schema = this.$PageSchema;
				schema.setPropertyValue("body", this.$SourceCode);
				schema.define(function(errorMessage) {
					if (errorMessage) {
						BPMSoft.showErrorMessage(errorMessage, function() {
							callback.call(scope, false);
						}, this);
					} else {
						callback.call(scope, true);
					}
				}, this);
			},

			/**
			 * Validate handler.
			 * @protected
			 */
			onValidate: function() {
				this.showBodyMask();
				this.saveSourceCode(function(isValid) {
					this.hideBodyMask();
					this.publishValidationResult(isValid);
				}, this);
			},

			/**
			 * Button click handler. Invert boolean attribute value.
			 * @protected
			 *
			 */
			invertAttriuteValue: function() {
				var attributeName = arguments[3];
				this.set(attributeName, !this.get(attributeName));
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "SourceCodeEditContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["source-code-edit-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SourceCodeEditContainer",
				"propertyName": "items",
				"name": "SourceCodeEditToolsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["source-code-edit-tools-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SourceCodeEditToolsContainer",
				"propertyName": "items",
				"name": "ShowFindWindowButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"hint": {bindTo: "Resources.Strings.ShowFindWindowButtonHint"},
					"imageConfig": {bindTo: "Resources.Images.SearchImage"},
					"classes": {wrapperClass: ["source-code-edit-tool-button", "find-button"]},
					"click": {bindTo: "invertAttriuteValue"},
					"visible": {bindTo: "IsSearchButtonVisible"},
					"tag": "IsSearchBoxVisible"
				}
			},
			{
				"operation": "insert",
				"parentName": "SourceCodeEditToolsContainer",
				"propertyName": "items",
				"name": "ShowWhitespacesButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {bindTo: "Resources.Images.ShowWhitespacesImage"},
					"hint": {bindTo: "Resources.Strings.ShowWhitespacesButtonHint"},
					"classes": {wrapperClass: ["source-code-edit-tool-button", "show-whitespaces-button"]},
					"click": {bindTo: "invertAttriuteValue"},
					"pressed": {
						bindTo: "ShowWhitespaces",
						converter: "invertBooleanValue"
					},
					"visible": {bindTo: "IsWhitespaceButtonVisible"},
					"tag": "ShowWhitespaces"
				}
			},
			{
				"operation": "insert",
				"parentName": "SourceCodeEditContainer",
				"propertyName": "items",
				"name": "SourceCodeEditControlWrapContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["source-code-edit-control-wrap-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SourceCodeEditControlWrapContainer",
				"propertyName": "items",
				"name": "SourceCode",
				"values": {
					"generator": "SourceCodeEditGenerator.generate",
					"markerValue": {bindTo: "SourceCodeEditMarkerValue"},
					"readonly": {bindTo: "IsSourceCodeReadonly"},
					"enabled": {bindTo: "IsSourceCodeEnabled"},
					"language": {bindTo: "Language"},
					"theme": {bindTo: "Theme"},
					"searchVisible": {bindTo: "IsSearchBoxVisible"},
					"showWhitespaces": {bindTo: "ShowWhitespaces"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
