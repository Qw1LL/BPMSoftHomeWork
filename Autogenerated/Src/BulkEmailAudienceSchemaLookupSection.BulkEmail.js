 define("BulkEmailAudienceSchemaLookupSection",
 		["BulkEmailAudienceSchema", "BulkEmailAudienceSchemaLookupSectionResources"],
	 function(RootSchema, resources) {
		return {
			entitySchemaName: "BulkEmailAudienceSchema",
			attributes: {
				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#UseSectionHeaderCaption
				 * @override
				 */
				"UseSectionHeaderCaption": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {

				/**
				 * @private
				 */
				_getExistedBulkEmailRecordsEsq: function(schemaIds) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmail"
					});
					esq.columns.clear();
					var filter = BPMSoft.createColumnInFilterWithParameters(
						"[BulkEmailAudienceSchema:Id:AudienceSchemaId].Id", schemaIds);
					esq.filters.addItem(filter);
					esq.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "Count");
					return esq;
				},

				/**
				 * @private
				 */
				_canEditEntityObject: function(items, count) {
					if (count > 0) {
						var message = (items.length > 1)
							? resources.localizableStrings.CouldNotDeleteAudienceSchemaMulti
							: resources.localizableStrings.CouldNotDeleteAudienceSchemaSingle;
						message = Ext.String.format(message, count);
						this.showInformationDialog(message);
						return false;
					}
					return true;
				},

				/**
				 * @inheritdoc BPMSoft.LinkedEntitySchemaLookupSection#formatColumnPath
				 * @override
				 */
				formatColumnPath: function(path, columnName) {
					return path;
				},

				/**
				 * @inheritdoc BPMSoft.BaseDataView#getActiveViewCaption
				 * @override
				 */
				getActiveViewCaption: function() {
					return RootSchema.caption;
				},

				/**
				 * @inheritdoc BPMSoft.BaseLookupConfigurationSection#checkCanDelete
				 * @override
				 */
				checkCanDelete: function(items, callback, scope) {
					var parentMethod = this.getParentMethod(this, arguments);
					var esq = scope._getExistedBulkEmailRecordsEsq(items);
					esq.getEntityCollection(function(response) {
						var result = response.collection.first();
						var count = result.get("Count");
						if (scope._canEditEntityObject(items, count)) {
							parentMethod();
						}
					});
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
          "operation": "insert",
          "name": "SeparateModeActionsButton",
          "parentName": "SeparateModeActionButtonsLeftContainer",
          "propertyName": "items",
          "values": {
            "itemType": BPMSoft.ViewItemType.BUTTON,
            "style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
            "caption": {"bindTo": "ActionsButtonCaption"},
            "classes": {
              "textClass": ["actions-button-margin-right"],
              "wrapperClass": ["actions-button-margin-right"]
            },
            "prepareMenu": {"bindTo": "prepareActionsButtonMenuItems"},
            "menu": {"items": {"bindTo": "SeparateModeActionsButtonMenuItems"}},
            "visible": {"bindTo": "isSeparateModeActionsButtonVisible"}
          }
        },
				{
					"operation": "merge",
					"name": "SeparateModeBackButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
