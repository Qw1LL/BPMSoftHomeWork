/**
 * Parent: BaseMultilingualEntityLookupPage
 */
define("EmailTemplatePageMultilingual", [], function() {
	return {
		entitySchemaName: "EmailTemplate",
		mixins: {
			OutdatedSchemaNotificationMixin: "BPMSoft.OutdatedSchemaNotificationMixin"
		},
		properties: {
			/**
			 * Outdated event name.
			 * @protected
			 * @type {String}
			 */
			outdatedEventName: "EmailTemplatePageSaved",

			/**
			 * Use websocket notifications.
			 * @protected
			 * @type {Boolean}
			 */
			useNotification: true
		},
		attributes: {
			/**
			 * Subject email template column.
			 */
			"Subject": {
				"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN
			},

			/**
			 * Template name.
			 */
			"TemplateName": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true,
				"dependencies": [
					{
						"columns": ["TemplateName"],
						"methodName": "updateName"
					}
				],
				"caption": { "bindTo": "Resources.Strings.TplNameLabelCaption" }
			},

			/**
			 * Template name.
			 */
			"Name": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
				"dependencies": [
					{
						"columns": ["IsEntityInitialized"],
						"methodName": "initVirtualColumns"
					}
				]
			},

			/**
			 * Object email template column, represent template entity schema.
			 * @type {BPMSoft.DataValueType.ENTITY_COLUMN}
			 */
			"Object": {
				"lookupListConfig": {
					filter: function() {
						return this.getObjectEntitySchemaFilters();
					}
				}
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * Converts a collection languages to a string short code names join by commas.
			 * @private
			 * @param {BPMSoft.Collection} languages List of languages.
			 * @returns {string} Returns short code names string.
			 */
			_toShortCodeString: function(languages) {
				return languages.getItems()
					.map(function(lang) {
						var codeArray = lang.get("Code").split("-");
						return codeArray[codeArray.length - 1];
					})
					.join(", ");
			},

			/**
			 * Converts a name column value to template name column value.
			 * @private
			 * @param {string} name Name column value
			 * @returns {string} Returns TemplateName column value.
			 */
			_nameToTemplateName: function(name) {
				var index = name.lastIndexOf("(");
				return index > 0 ? (name.substr(0, index)).trim() : name;
			},

			/**
			 * @private
			 */
			_fillObjectFromHistoryState: function(callback, scope) {
				const historyState = this.sandbox.publish("GetHistoryState");
				const objectSchemaUId = historyState.hash.recordId;
				if (!objectSchemaUId) {
					return Ext.callback(callback, scope);
				}
				BPMSoft.EntitySchemaManager.findItemByUId(objectSchemaUId, function(schema) {
					if (schema) {
						this.set("Object", {
							value: objectSchemaUId,
							displayValue: schema.caption
						});
					}
					Ext.callback(callback, scope);
				}, this);
			},

			// endregion

			// region Methids: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.subscribeOnServerChannelMessage();
					if (this.isAddMode()) {
						this._fillObjectFromHistoryState(callback, scope);
					} else {
						Ext.callback(callback, scope);
					}
				}, this]);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.updateName();
				this.subscribeAttributeEvents();
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onSaved
			 * @override
			 */
			onSaved: function() {
				this.notify(this.outdatedEventName, {
					id: this.get("Id"),
					name: this.get("TemplateName")
				});
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseMultilingualEntityLookupPage#getModuleSchemaName
			 * @override
			 */
			getModuleSchemaName: function() {
				return "EmailMLangContentEditSchema";
			},

			/**
			 * Update column name by getting and combining data from TemplateName and Languages columns.
			 * @protected
			 */
			updateName: function() {
				if (this.get("IsEntityInitialized")) {
					var tplName = this.get("TemplateName");
					var langString = this._toShortCodeString(this.get("Languages"));
					var name = (tplName || "") + " (" + langString + ")";
					this.set("Name", name);
					this.updateCardButtonsVisibility(true);
				}
			},

			/**
			 * Subscribe on view model attribute events.
			 * @protected
			 */
			subscribeAttributeEvents: function() {
				var languages = this.get("Languages");
				languages.on("changed", this.updateName, this);
			},

			/**
			 * Initialize view model virtual columns.
			 * @protected
			 */
			initVirtualColumns: function() {
				var name = this.get("Name");
				if (name) {
					this.set("TemplateName", this._nameToTemplateName(name));
				}
			},

			/**
			 * Returns filters for the entity objects.
			 * @protected
			 * @return {BPMSoft.FilterGroup} Filters for the entity objects.
			 */
			getObjectEntitySchemaFilters: function() {
				var filters = Ext.create("BPMSoft.FilterGroup");
				filters.addItem(BPMSoft.createColumnFilterWithParameter("ManagerName", "EntitySchemaManager"));
				filters.addItem(BPMSoft.createColumnIsNotNullFilter("Caption"));
				return filters;
			},

			/**
			 * @inheritdoc BPMSoft.BaseMultilingualEntityLookupPage#getMultilingualColumnList
			 * @override
			 */
			getMultilingualColumnList: function() {
				var config = this.callParent(arguments);
				config.push({
					name: "Subject",
					className: "BPMSoft.TextEdit"
				});
				config.push({name: "Body"});
				config.push({name: "TemplateConfig"});
				return config;
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "TemplateName",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					},
					"caption": {
						"bindTo": "Resources.Strings.TplNameLabelCaption"
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Object",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24,
						"rowSpan": 1
					},
					"tip": {
						"content": {"bindTo": "Resources.Strings.ObjectTip"}
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "TemplateType",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "Header"
					},
					"bindTo": "TemplateType",
					"enabled": false,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			}
		]/**SCHEMA_DIFF*/
	};
});
