/**
 * Parent: BasePageV2
 */
define("PageTemplatePage", ["PageTemplatePageResources", "css!PageTemplatePageCSS"], function(resources) {
	return {
		entitySchemaName: "PageTemplate",
		attributes: {
			"PageSchema": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				referenceSchemaName: "SysSchema",
				isRequired: true,
				lookupListConfig: {
					columns: ["UId"]
				}
			}
		},
		properties: {
			basePageTemplateUId: "21620f25-166f-42f1-8b4d-224a959040a3"
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_findPageTemplates: function() {
				var manager = BPMSoft.ClientUnitSchemaManager;
				var result = [this.basePageTemplateUId];
				manager.getItems().each(function(item) {
					if (manager.isInheritedFrom(item.uId, this.basePageTemplateUId)) {
						result.push(item.uId);
					}
				}, this);
				return result;
			},

			/**
			 * @private
			 */
			_initPageSchema: function() {
				var item = BPMSoft.ClientUnitSchemaManager.findItem(this.$PageSchemaUId);
				if (item) {
					this.$PageSchema = {
						Id: item.id,
						UId: item.uId,
						displayValue: item.caption,
						value: item.id
					};
				}
			},

			/**
			 * @private
			 */
			_getDefaultPreviewImage: function() {
				return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultTemplate);
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				var parentMethod = this.getParentMethod();
				BPMSoft.chain(
					function(next) {
						BPMSoft.ClientUnitSchemaManager.initialize(next);
					},
					function() {
						parentMethod.call(this, callback, scope);
					},
					this
				);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @override
			 */
			onEntityInitialized: function() {
				this._initPageSchema();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#save
			 * @override
			 */
			save: function() {
				this.$PageSchemaUId = this.$PageSchema && this.$PageSchema.UId;
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getLookupQueryFilters
			 * @override
			 */
			getLookupQueryFilters: function() {
				var filters = this.callParent(arguments);
				var templates = this._findPageTemplates();
				var groupAnd = BPMSoft.createFilterGroup();
				groupAnd.addItem(BPMSoft.createColumnInFilterWithParameters("UId", templates, BPMSoft.DataValueType.GUID));
				groupAnd.addItem(BPMSoft.createNotExistsFilter("[PageTemplate:PageSchemaUId:UId].Id"));
				var groupOr = new BPMSoft.FilterGroup({
					logicalOperation: BPMSoft.LogicalOperatorType.OR
				});
				groupOr.addItem(groupAnd);
				if (this.$PageSchemaUId) {
					groupOr.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "UId",
						this.$PageSchemaUId, BPMSoft.DataValueType.GUID));
				}
				filters.addItem(groupOr);
				return filters;
			},

			/**
			 * @inheritdoc BasePageV2#initActionButtonMenu
			 * @override
			 */
			initActionButtonMenu: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BasePageV2#getPageHeaderCaption
			 * @override
			 */
			getPageHeaderCaption: function() {
				return this.$PageSchema && this.$PageSchema.displayValue;
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns preview image of the template.
			 * @return {String}.
			 */
			getPreviewImage: function() {
				return this.getSchemaImageUrl() || this._getDefaultPreviewImage();
			},

			/**
			 * Preview image change handler.
			 * @param {File} file Image file.
			 */
			onPreviewImageChange: function(file) {
				if (file) {
					BPMSoft.ImageApi.upload({
						file: file,
						onComplete: this.onPreviewImageUploaded,
						scope: this
					});
				} else {
					this.set(this.primaryImageColumnName, null);
				}
			},

			/**
			 * Preview image uploaded handler.
			 * @param {String} imageId Image ID.
			 */
			onPreviewImageUploaded: function(imageId) {
				var imageData = {
					value: imageId,
					displayValue: "PreviewImage"
				};
				this.set(this.primaryImageColumnName, imageData);
			},

			/**
			 * Returns default image url.
			 * @return {String} Default image url.
			 */
			getDefaultImageURL: function() {
				return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultTemplate);
			}

			//endregion
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"name": "EditContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["edit-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EditContainer",
				"name": "PageSchema",
				"propertyName": "items",
				"values": {
					"caption": {"bindTo": "Resources.Strings.PageSchemaCaption"},
					"isRequired": true
				}
			},
			{
				"operation": "insert",
				"parentName": "EditContainer",
				"name": "Position",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"parentName": "EditContainer",
				"propertyName": "items",
				"name": "PageIconContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["control-width-15 page-icon-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "PageIconContainer",
				"propertyName": "items",
				"name": "PageIconLabelContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-wrap"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "PageIconLabelContainer",
				"name": "PageIconLabel",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.PageIconLabel"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "PageIconContainer",
				"propertyName": "items",
				"name": "PreviewImage",
				"values": {
					"getSrcMethod": "getPreviewImage",
					"onPhotoChange": "onPreviewImageChange",
					"readonly": false,
					"defaultImage": {"bindTo": "getDefaultImageURL"},
					"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
