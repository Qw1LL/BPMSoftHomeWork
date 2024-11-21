/**
 * Schema of deduplicator element page
 */
define("CampaignDeduplicatorPage", ["CampaignElementMixin", "DropdownLookupMixin"],
	function() {
		return {
			properties: {
				defaultAudienceSchemaId: "5b229e55-8ebf-414a-8dee-26e2b059025b"
			},
			attributes: {
				/**
				 * Values collection of lookup for AudienceSchema.
				 * @type {BPMSoft.Collection}
				 */
				"AudienceSchemaCollection": {
					"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": Ext.create("BPMSoft.Collection")
				},
	
				/**
				 * Current audience schema to search duplicates in campaign participants.
				 * @type {Object}
				 */
				"AudienceSchema": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "onAudienceSchemaChanged",
					"isRequired": true
				},
	
				/**
				 * Audience schema column path to search duplicates by.
				 * @type {Object}
				 */
				"ColumnPath": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"SuspendParticipantsWithEmptyValues": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN
				}
			},
			methods: {

				// #region Methods: Private

				_createAudienceSchemaESQ: function() {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CampaignSignalEntity"
					});
					esq.addColumn("Id");
					esq.addColumn("EntityObject");
					esq.addColumn("Caption");
					return esq;
				},

				_initAudienceSchemaCollection: function(callback, scope) {
					var esq = this._createAudienceSchemaESQ();
					esq.getEntityCollection(function(response) {
						this.loadAudienceSchemaCollection(response.collection);
						callback.call(scope);
					}, this);
				},

				_initAudienceSchema: function(audienceSchemaId, callback, scope) {
					var selectedItem = this.$AudienceSchemaCollection.findByFn(function(el) {
						return el.entitySchemaUId === audienceSchemaId;
					});
					if (!selectedItem) {
						selectedItem = this._getDefaultAudienceSchema();
					}
					if (selectedItem.schemaName) {
						this._onAudienceSchemaInited(selectedItem, callback, scope);
						return;
					}
					BPMSoft.EntitySchemaManager.findItemByUId(selectedItem.entitySchemaUId, function(schema) {
						selectedItem.schemaName = schema.name;
						this._onAudienceSchemaInited(selectedItem, callback, scope);
					}, this);
				},

				_onAudienceSchemaInited: function(audienceSchema, callback, scope) {
					this.set("AudienceSchema", audienceSchema);
					callback.call(scope);
				},

				_updateAudienceSchemaData: function(props) {
					var schemaId = this.$AudienceSchema.value;
					var currentSchema = this.$AudienceSchemaCollection.findByFn(function(el) {
						return el.value === schemaId;
					}, this);
					BPMSoft.each(props, function(value, prop) {
						currentSchema[prop] = value;
					}, this);
				},

				_getDefaultAudienceSchema: function() {
					var item = this.$AudienceSchemaCollection.findByFn(function(el) {
						return el.value === this.defaultAudienceSchemaId;
					}, this);
					return item;
				},

				// #endregion

				// #region Methods: Protected

				/**
				 * Loads available audience schemas to AudienceSchemaCollection.
				 * @protected
				 * @param {BPMSoft.Collection} collection Loaded audience schemas.
				 */
				loadAudienceSchemaCollection: function(collection) {
					var list = new BPMSoft.Collection();
					BPMSoft.each(collection, function(el) {
						var schemaObject = {
							value: el.$Id,
							displayValue: el.$Caption,
							caption: el.$Caption,
							entitySchemaUId: el.$EntityObject.value
						};
						list.add(el.$Id, schemaObject);
					}, this);
					list.sort("caption", this.BPMSoft.OrderDirection.ASC);
					this.$AudienceSchemaCollection.reloadAll(list);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#initPageAsync
				 * @override
				 */
				 initPageAsync: function(element, callback, scope) {
					var parentMethod = this.getParentMethod();
					this.$CanSaveElementConfig = true;
					this._initAudienceSchemaCollection(function() {
						parentMethod.call(this, element, callback, scope);
					}, this);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
				 * @override
				 */
				initElementProperties: function(element, callback, scope) {
					var parentMethod = this.getParentMethod();
					this._initAudienceSchema(element.entitySchemaUId, function() {
						this.$ColumnPath = element.columnPath;
						this.$SuspendParticipantsWithEmptyValues = element.suspendParticipantsWithEmptyValues;
						parentMethod.call(this, element, callback, scope);
					}, this);
				},

				/**
				 * Handler on "AudienceSchema" attribute change event.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} model View model.
				 * @param {Object} value New value.
				 */
				onAudienceSchemaChanged: function(model, value) {
					this.$ColumnPath = undefined;
					if (!value) {
						return;
					}
					if (!value.schemaName) {
						BPMSoft.EntitySchemaManager.findItemByUId(value.entitySchemaUId, function(schema) {
							this.$AudienceSchema.schemaName = schema.name;
							this._updateAudienceSchemaData({schemaName: schema.name});
						}, this);
						return;
					}
				},

				/**
				 * Handler for select column button click event.
				 * @protected
				 */
				onColumnSelectClick: function() {
					var schemaName = this.$AudienceSchema.schemaName;
					BPMSoft.StructureExplorerUtilities.open({
						scope: this,
						handlerMethod: this.onEntityColumnSelected,
						moduleConfig: {
							useBackwards: false,
							schemaName: schemaName
						}
					});
				},

				/**
				 * Handler on "ColumnPath" value selected event.
				 * @protected
				 * @param {BPMSoft.BaseViewModel} model View model.
				 * @param {Object} value New value.
				 */
				onEntityColumnSelected:function(result) {
					this.$ColumnPath = result.leftExpressionColumnPath;
				},

				/**
				 * Handler on load audience schema list on combobox click.
				 * @protected
				 * @param {String} filter Text to contain.
				 * @param {BPMSoft.Collection} list Items collection.
				 */
				prepareAudienceSchemaList: function(filter, list) {
					list.reloadAll(this.$AudienceSchemaCollection);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#saveValues
				 * @override
				 */
				saveValues: function() {
					var element = this.$ProcessElement;
					element.entitySchemaUId = this.$AudienceSchema && this.$AudienceSchema.entitySchemaUId;
					element.columnPath = this.$ColumnPath;
					element.suspendParticipantsWithEmptyValues = this.$SuspendParticipantsWithEmptyValues
					this.callParent(arguments);
				}

				// #endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "RuleEditorContainer",
					"propertyName": "items",
					"parentName": "EditorsContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AudienceSchemaLabel",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.AudienceSchemaLabelCaption",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "AudienceSchema",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"rowSpan": 1,
							"colSpan": 24
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": "$prepareAudienceSchemaList",
							"filterComparisonType": this.BPMSoft.StringFilterType.CONTAIN
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["top-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "ColumnSelectLabel",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.ColumnSelectLabelCaption",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ColumnPath",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 22
						},
						"value": "$ColumnPath",
						"wrapClass": ["style-input rule-inline-grid-caption"],
						"isRequired": true,
						"enabled": false,
						"labelConfig": {
							"visible": false
						},
					}
				},
				{
					"operation": "insert",
					"name": "ColumnSelectButton",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"layout": {
							"column": 22,
							"row": 3,
							"colSpan": 2
						},
						"imageConfig": "$Resources.Images.ColumnSelectButtonIcon",
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"click": "$onColumnSelectClick",
						"classes": {
							"wrapperClass": []
						}
					}
				},
				{
					"operation": "insert",
					"name": "ColumnWithEmptyValuesLabel",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.ColumnWithEmptyValuesLabel",
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "SuspendParticipantsWithEmptyValues",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"caption": "$Resources.Strings.ColumnWithEmptyValuesCaption",
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 22
						}
					}
				},
				{
					"name": "ColumnWithEmptyValuesHint",
					"operation": "insert",
					"parentName": "RuleEditorContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 22,
							"row": 5,
							"colSpan": 1
						},
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": "$Resources.Strings.ColumnWithEmptyValuesHint",
						"controlConfig": {
							"classes": {
								"wrapperClass": "t-checkbox-information-button"
							},
							"imageConfig": {
								"bindTo": "Resources.Images.InfoButtonImage"
							}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
