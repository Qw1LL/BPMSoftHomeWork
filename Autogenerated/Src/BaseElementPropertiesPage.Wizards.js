define("BaseElementPropertiesPage", [], function() {
	return {
		messages: {
			"GetDesignSchema": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			"DesignSchema": {
				type: BPMSoft.DataValueType.CUSTOM_OBJECT,
				autoBind: false
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getAutoBindAttributes: function() {
				return BPMSoft.filter(this.columns, {autoBind: true});
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.$DesignSchema = this.sandbox.publish("GetDesignSchema");
					this.loadData();
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * Returns current edited item.
			 * @protected
			 */
			getDesignSchemaItem: function() {
				return this.$DesignSchema && this.$DesignSchema.$ActionLayoutItem;
			},

			/**
			 * Init element properties.
			 * @protected
			 */
			loadData: function() {
				var item = this.getDesignSchemaItem();
				var attributes = this._getAutoBindAttributes();
				BPMSoft.each(attributes, function(attribute) {
					var name = attribute.name;
					this.set(name, item.get(name));
				}, this);
			},

			/**
			 * Saves element properties.
			 * @protected
			 * @param {Function} callback Callback function
			 * @param {Object} scope Callback function context
			 */
			saveData: function(callback, scope) {
				if (this.validate()) {
					var item = this.getDesignSchemaItem();
					var attributes = this._getAutoBindAttributes();
					BPMSoft.each(attributes, function(attribute) {
						var name = attribute.name;
						item.set(name, this.get(name));
					}, this);
					Ext.callback(callback, scope);
				}
			},

			/**
			 * Closes properties page.
			 * @protected
			 */
			closePropertiesPage: function() {
				var modalBox = this.$DesignSchema.getModalBox();
				modalBox.close();
			},

			// endregion

			// region Methods: Public

			/**
			 * Returns properties page title.
			 * @return {String}
			 */
			getTitle: function() {
				return this.get("Resources.Strings.PropertiesPageTitle");
			},

			/**
			 * Handler for CancelButton click.
			 */
			onCancelClick: function() {
				this.closePropertiesPage();
			},

			/**
			 * Handler for SaveButton click.
			 */
			onSaveClick: function() {
				if (this.validate()) {
					this.saveData(function() {
						this.closePropertiesPage();
					}, this);
				}
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["modal-box-schema-module-header"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"name": "Title",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "getTitle"},
					"labelConfig": {"classes": ["modal-box-title"]}
				}
			},
			{
				"operation": "insert",
				"name": "MainContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainContainer",
				"propertyName": "items",
				"name": "MainGridContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {"wrapClassName": ["main-grid-container"]},
					"layout": {"column": 0, "row": 0, "colSpan": 24},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "MainContainer",
				"propertyName": "items",
				"name": "ButtonsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["buttons-container"],
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ButtonsContainer",
				"propertyName": "items",
				"name": "SaveButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"layout": {"column": 0, "row": 1, "colSpan": 2},
					"click": {"bindTo": "onSaveClick"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ButtonsContainer",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"layout": {"column": 4, "row": 1, "colSpan": 2},
					"click": {"bindTo": "onCancelClick"}
				}
			},
			{
				"operation": "insert",
				"name": "CloseMiniPageButton",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.CloseButtonImage"
					},
					"classes": {"wrapperClass": ["wizard-settings-close-button"]},
					"click": {"bindTo": "onCancelClick"},
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
