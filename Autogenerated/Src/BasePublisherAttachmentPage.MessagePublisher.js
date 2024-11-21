define("BasePublisherAttachmentPage", ["MessageConstants", "MultilineLabel", "css!MultilineLabel"],
	function(MessageConstants) {
		return {
			entitySchemaName: "File",
			attributes: {},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			methods: {
				init: function() {
					this.set("FilesList", new BPMSoft.Collection());
				},

				/**
				 * Returns attachment link.
				 * @protected
				 * @virtual
				 */
				getAttachmentLink: function() {
					var currentSchema = this.entitySchemaName;
					var schemas = this.BPMSoft.EntitySchemaManager.getItems();
					var fileSchema = schemas.filterByFn(function(item) {
						return item.name === currentSchema;
					}).getByIndex(0);

					return this.Ext.String.format(MessageConstants.UrlTemplate.FileUrlTemplate,
						fileSchema.uId, this.get("Id"), this.get("Name"));
				},

				/**
				 * Returns attachment delete image url.
				 * @protected
				 * @virtual
				 * @return {String} Image url.
				 */
				getAttachmentDeleteImageUrl: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.AttachementDeleteIamge"));
				},

				/**
				 * Delete attachment.
				 * @protected
				 * @virtual
				 */
				deleteAttachment: function() {
					var deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
							rootSchemaName: this.entitySchemaName
						});
					var recordId = this.get("Id");
					deleteQuery.filters.add(deleteQuery.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", recordId));
					deleteQuery.execute(function(response) {
						if (response && response.success) {
							var filesListItems = this.values.filesList;
							filesListItems.remove(filesListItems.collection.getByKey(this.get("Id")));
						}
					}, this);
				},

				/**
				 * Returns module ID of publisher.
				 * @private
				 * @return {String} Sandbox identifier for message history.
				 */
				getMessagePublisherSandboxId: this.BPMSoft.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "AttachmentWrapContainer",
					"propertyName": "items",
					"values": {
						"id": "AttachmentWrapContainer",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"markerValue": "AttachmentWrapContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["attachmentWrap"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "AttachmentLink",
					"parentName": "AttachmentWrapContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"markerValue": "AttachmentLink",
								"className": "BPMSoft.MultilineLabel",
								"classes": {
									"multilineLabelClass": ["attachmentLink"]
								},
								"caption": {
									"bindTo": "getAttachmentLink"
								},
								"showLinks": true
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "AttachmentDeleteImage",
					"parentName": "AttachmentWrapContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getAttachmentDeleteImageUrl",
						"onPhotoChange": this.BPMSoft.emptyFn,
						"readonly": true,
						"classes": {
							"wrapClass": ["attachmentDeleteImage"]
						},
						"markerValue": "AttachmentDeleteImage",
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"onImageClick": {
							"bindTo": "deleteAttachment"
						},
						"visible": true
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
