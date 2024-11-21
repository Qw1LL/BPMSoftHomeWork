/**
 * Parent: BaseDataModificationUserTaskPropertiesPage
 */
define("ChangeDataUserTaskPropertiesPage", ["BPMSoft", "ChangeDataUserTaskPropertiesPageResources",
	"EntityColumnMappingMixin"],
	function(BPMSoft) {
		return {
			mixins: {
				entityColumnMappingMixin: "BPMSoft.EntityColumnMappingMixin"
			},
			attributes: {},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						this.initEntityColumnMappingMixin(element, callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveParameters
				 * @overridden
				 */
				saveParameters: function(element) {
					this.callParent(arguments);
					this.saveEntityColumnMappings(element);
				},

				/**
				 * @inheritdoc EntityColumnMappingMixin#getEntityColumnMappingSchemaUId
				 * @overridden
				 */
				getEntityColumnMappingSchemaUId: function() {
					return this.getEntitySchemaUId();
				},

				/**
				 * @inheritdoc BaseDataModificationUserTaskPropertiesPage#onUpdatedEntitySchema
				 * @overridden
				 */
				onUpdatedEntitySchema: function() {
					this.callParent(arguments);
					var element = this.get("ProcessElement");
					this.reInitEntityColumnMapping(element, Ext.emptyFn);
				}

				//endregion

			},
			diff: [

				// region ColumnValues

				{
					"operation": "insert",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"name": "ColumnValuesContainer",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [],
						"visible": {
							"bindTo": "ReferenceSchemaUId",
							"bindConfig": {
								"converter": function(value) {
									return !this.Ext.isEmpty(value);
								}
							}
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnValuesContainer",
					"propertyName": "items",
					"name": "ColumnValuesLabel",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.EntityColumnMapping_ColumnValuesLabelCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnValuesContainer",
					"propertyName": "items",
					"name": "RecordColumnValuesContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "EntityColumnMappingsControls",
						"onGetItemConfig": "getEntityColumnMappingsControlViewConfig",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnValuesContainer",
					"propertyName": "items",
					"name": "AddRecordColumnValuesButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.EntityColumnMapping_AddRecordColumnValuesButtonCaption"
						},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": {"bindTo": "onAddEntityColumnMappings"}
					}
				}

				// endregion

			]
		};
	}
);
