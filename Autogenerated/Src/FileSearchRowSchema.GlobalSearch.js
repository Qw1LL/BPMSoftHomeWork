define("FileSearchRowSchema", ["ConfigurationConstants"], function(configurationConstants) {
	return {
		attributes: {
			/**
			 * Entity schema caption.
			 */
			"ParentEntityColumn": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN
			},
			/**
			 * Parent entity column name.
			 */
			"ParentEntityColumnName": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"value": ""
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#initAttributeValues
			 * @overridden
			 */
			initAttributeValues: function() {
				this.callParent(arguments);
				this.set("ParentEntityColumn", this.get(this.getParentEntityColumnName()));
			},

			/**
			 * Returns parent entity column name.
			 * @return {String} Parent entity column name.
			 */
			getParentEntityColumnName: function() {
				var parentEntityColumnName = this.get("ParentEntityColumnName");
				if (!parentEntityColumnName) {
					this.set("ParentEntityColumnName", this.entitySchemaName.replace("File", ""));
				}
				return this.get("ParentEntityColumnName");
			},

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#initSchemaCaption
			 * @overridden
			 */
			initSchemaCaption: function() {
				var moduleStructure = this.getModuleStructure(this.getParentEntityColumnName());
				this.set("EntitySchemaCaption", moduleStructure && moduleStructure.moduleCaption || "");
			},

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#onPrimaryColumnLinkClick
			 * @overridden
			 */
			onPrimaryColumnLinkClick: function() {
				var type = this.get("Type");
				var typeValue = type && type.value && type.value.toLowerCase();
				if (!this.entitySchema) {
					return;
				}
				if (typeValue === configurationConstants.FileType.File) {
					location.href = Ext.String.format("../rest/FileService/GetFile/{0}/{1}",
							this.entitySchema.uId, this.get("Id"));
				} else {
					window.open(this.get("Name"));
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#onLinkClick
			 * @overridden
			 */
			onLinkClick: function(url) {
				return this.callParent([url, this.getParentEntityColumnName()]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#getLinkUrl
			 * @overridden
			 */
			getLinkUrl: function() {
				return this.callParent([this.getParentEntityColumnName()]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#linkMouseOver
			 * @overridden
			 */
			linkMouseOver: function(options) {
				this.callParent([options, this.getParentEntityColumnName()]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSearchRowSchema#getHighlightText
			 * @overridden
			 */
			getHighlightText: function(columnName) {
				var args = columnName === "ParentEntityColumn" ? [this.getParentEntityColumnName()] :
						[columnName];
				return this.callParent(args);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#getBindMap
			 * @overridden
			 */
			getBindMap: function() {
				var parentEntityColumnName = this.getParentEntityColumnName();
				var bindMap = this.callParent(arguments);
				if (bindMap && !bindMap.contains(parentEntityColumnName)) {
					bindMap.add(parentEntityColumnName, {});
				}
				return bindMap;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "ParentEntityColumn",
				"values": {
					"isLinkColumn": true,
					"caption": {"bindTo": "Resources.Strings.ParentEntityLinkCaption"},
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "merge",
				"name": "EntitySchemaCaption",
				"values": {
					"layout": {
						"column": 18,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
