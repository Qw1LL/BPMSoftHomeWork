define("SatisfactionLevelLookupEditPage", ["ext-base", "BPMSoft", "SatisfactionLevelLookupEditPageResources",
	"ContentImageUtilitiesV2"],
	function(Ext, BPMSoft, resources) {
		return {
			entitySchemaName: "SatisfactionLevel",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {},
			mixins: {
				/**
				 * @class ContentImageUtilities implements image content control.
				 */
				ContentImageUtilities: "BPMSoft.ContentImageUtilities"
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Point", this.pointValueValidator);
				},

				/**
				 * Point required validator.
				 * @param {Object} value Column attribute value.
				 * @protected
				 * @return {Object} Point validation.
				 */
				pointValueValidator: function(value) {
					return {
						invalidMessage: (value < 1)
							? this.BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage
							: ""
					};
				},

				/**
				 * Returns default image url.
				 * @return {String} Default image url.
				 */
				getDefaultImageURL: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultImage);
				}

			},
			rules: {},
			userCode: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "Name"
				},
				{
					"operation": "remove",
					"name": "Description"
				},
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 7,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Point",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 7,
							"rowSpan": 1
						},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.PointTipMessage"
							}
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "Status",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 7,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "IsActive",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 7,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ImageContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container"],
						"layout": {
							"column": 8,
							"row": 0,
							"rowSpan": 3,
							"colSpan": 2
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ImageContainer",
					"propertyName": "items",
					"name": "Image",
					"values": {
						"getSrcMethod": "getImageUrl",
						"onPhotoChange": "onImageChange",
						"readonly": false,
						"defaultImage": {"bindTo": "getDefaultImageURL"},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
