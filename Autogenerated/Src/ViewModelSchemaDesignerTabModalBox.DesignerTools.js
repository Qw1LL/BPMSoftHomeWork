define("ViewModelSchemaDesignerTabModalBox", ["css!ViewModelSchemaDesignerTabModalBoxCss"], function() {
	return {
		messages: {

			/**
			 * @message GetDesignerDisplayConfig
			 */
			"SaveTabConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {

			/**
			 * Tab caption.
			 */
			"TabCaption": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				isRequired: true,
				size: 50,
				value: ""
			}
		},
		methods: {

			/**
			 * Returns modal box config.
			 * @return {Object}
			 */
			getModuleInfo: function() {
				return this.get("moduleInfo");
			},

			/**
			 * Returns modal box header.
			 * @return {String}
			 */
			getHeader: function() {
				return this.get("Resources.Strings.TabModalBoxHeader");
			},

			/**
			 * @inheritDoc BPMSoft.ModalBoxSchemaModule#init.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					var moduleInfo = this.getModuleInfo();
					this.set("TabCaption", moduleInfo.tabCaption);
					callback.call(scope);
				}, this]);
			},

			/**
			 * Returns new tab config.
			 * @return {Object}
			 */
			getTabConfig: function() {
				return {
					caption: this.get("TabCaption")
				};
			},

			/**
			 * @inheritDoc BPMSoft.ModalBoxSchemaModule#onRender.
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				var moduleInfo = this.getModuleInfo();
				var boxSizes = moduleInfo.modalBoxSize;
				var width = boxSizes.width;
				var height = boxSizes.height;
				this.updateSize(width, height);
			},

			/**
			 * Handler save button by click.
			 * @protected
			 */
			okButtonClick: function() {
				if (this.validate()) {
					var tabConfig = this.getTabConfig();
					this.sandbox.publish("SaveTabConfig", tabConfig, [this.sandbox.id]);
					this.close();
				}
			},

			/**
			 * @protected
			 * @inheritdoc BaseSchemaViewModel#setValidationConfig
			 * @overridden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("TabCaption", this.tabCaptionLengthValidator);
			},

			/**
			 * Validate TabCaption length.
			 * @protected
			 * @virtual
			 * @param {String} value TabCaption value.
			 * @param {Object} column Model column.
			 * @return {Object} Result of validate.
			 */
			tabCaptionLengthValidator: function(value, column) {
				var message = "";
				if (this.get("TabCaption")) {
					var maxLength = column.size;
					if (value.length >= maxLength) {
						message = Ext.String.format(this.get("Resources.Strings.WrongTabCaptionLengthMessage"),
								maxLength);
					}
				}
				return {invalidMessage: message};
			}

		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["modal-box-card-content-wrap", "tab-modal-box"]
				}
			},
			{
				"operation": "insert",
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"name": "TabCaption",
				"values": {
					"bindTo": "TabCaption",
					"labelConfig": {
						"caption": {"bindTo": "Resources.Strings.TabBoxTitleCaption"}
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
					"click": {"bindTo": "okButtonClick"},
					"caption": {"bindTo": "Resources.Strings.OkButtonCaption"},
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
					"caption": {"bindTo": "Resources.Strings.CancelButtonBoxCaption"},
					"classes": {"textClass": ["tap-panel-box"]}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
