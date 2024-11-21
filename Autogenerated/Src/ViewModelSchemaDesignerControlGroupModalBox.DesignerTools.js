define("ViewModelSchemaDesignerControlGroupModalBox", ["css!ViewModelSchemaDesignerControlGroupModalBoxCss"],
	function() {
		return {
			messages: {

				/**
				 * @message SaveControlGroupConfig
				 */
				"SaveControlGroupConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Control group caption.
				 */
				"ControlGroupCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					size: 50,
					value: null
				}
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.ModalBoxSchemaModule#init.
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						var moduleInfo = this.get("moduleInfo");
						this.set("ControlGroupCaption", moduleInfo.controlGroupCaption);
						callback.call(scope);
					}, this]);
				},

				/**
				 * @inheritDoc BPMSoft.ModalBoxSchemaModule#onRender.
				 * @overridden
				 */
				onRender: function() {
					this.callParent(arguments);
					var moduleInfo = this.get("moduleInfo");
					var boxSizes = moduleInfo.modalBoxSize;
					var width = boxSizes.width;
					var height = boxSizes.height;
					this.updateSize(width, height);
				},

				/**
				 * @inheritDoc BPMSoft.BaseModalBoxPage#getHeader.
				 * @overridden
				 */
				getHeader: function() {
					return this.get("Resources.Strings.ControlGroupModalBoxHeader");
				},

				/**
				 * Returns control group configuration.
				 * @protected
				 * @virtual
				 * @return {Object} Control group configuration.
				 */
				getControlGroupConfig: function() {
					return {
						caption: this.get("ControlGroupCaption")
					};
				},

				/**
				 * Save button click handler.
				 * @protected
				 * @virtual
				 */
				onSaveButtonClick: function() {
					if (this.validate()) {
						this.sandbox.publish("SaveControlGroupConfig", this.getControlGroupConfig(), [this.sandbox.id]);
						this.close();
					}
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("ControlGroupCaption", this.getControlGroupCaptionLengthValidator);
				},

				/**
				 * Validate ControlGroupCaption length.
				 * @protected
				 * @virtual
				 * @param {String} value ControlGroupCaption value.
				 * @param {Object} column Model column.
				 * @return {Object} Validation result.
				 */
				getControlGroupCaptionLengthValidator: function(value, column) {
					if (!Ext.isEmpty(value)) {
						var maxLength = column.size;
						if (value.length > maxLength) {
							var message = this.get("Resources.Strings.WrongControlGroupCaptionLengthMessage");
							return {
								invalidMessage: Ext.String.format(message, maxLength)
							};
						}
					}
					return {};
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "CardContentWrapper",
					"values": {
						"wrapClass": ["modal-box-card-content-wrap", "control-group-modal-box"]
					}
				},
				{
					"operation": "insert",
					"parentName": "CardContentWrapper",
					"propertyName": "items",
					"name": "ControlGroupCaption",
					"values": {
						"bindTo": "ControlGroupCaption",
						"labelConfig": {
							"caption": {"bindTo": "Resources.Strings.ControlGroupModalBoxLabelCaption"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "OkButton",
					"parentName": "CardContentWrapper",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"click": {"bindTo": "onSaveButtonClick"},
						"caption": {"bindTo": "Resources.Strings.ControlGroupModalBoxSaveButtonCaption"},
						"classes": {"textClass": ["tap-panel-box"]}
					}
				},
				{
					"operation": "insert",
					"name": "CancelButton",
					"parentName": "CardContentWrapper",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"click": {"bindTo": "close"},
						"caption": {"bindTo": "Resources.Strings.ControlGroupModalBoxCancelButtonCaption"},
						"classes": {"textClass": ["tap-panel-box"]}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
