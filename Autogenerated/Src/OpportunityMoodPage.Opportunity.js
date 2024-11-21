define("OpportunityMoodPage", ["OpportunityMoodPageResources", "ImageCustomGeneratorV2"],
	function(resources) {
		return {
			entitySchemaName: "OpportunityMood",
			methods: {
				/**
				 * @private
				 * @return {Object} responseHandler
				 */
				_getImageApiResponseHandler: function() {
					return {
						onComplete: this.processImageApiSuccessResponse,
						onError: this.processImageApiErrorResponse,
						scope: this
					};
				},

				/**
				 * Processing image api upload success response.
				 * @return {String} Default image url.
				 */
				processImageApiSuccessResponse: function(imageId) {
					let imageData = {
						value: imageId,
						displayValue: "Image"
					};
					this.set(this.primaryImageColumnName, imageData);
				},

				/**
				 * Processing image api upload error response.
				 * @return {String} Default image url.
				 */
				processImageApiErrorResponse: function(imageId, error, uploadResult) {
					if (uploadResult.response) {
						let response = BPMSoft.decode(uploadResult.response);
						if (response.error) {
							BPMSoft.showMessage(response.error);
						}
					}
				},
				
				/**
				 * Get image url.
				 * @return {*}
				 */
				getSrcMethod: function() {
					let primaryImageColumnValue = this.get(this.primaryImageColumnName);
					if (primaryImageColumnValue) {
						return this.getSchemaImageUrl(primaryImageColumnValue);
					}
					return this.getDefaultImageURL();
				},
				
				/**
				 * Returns default image url.
				 * @return {String} Default image url.
				 */
				getDefaultImageURL: function() {
					return this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultImage);
				},

				/**
				 * Processing image changes.
				 * @param {Object} image Image object.
				 */
				onImageChange: function(image) {
					if (image) {
						let data = this._getImageApiResponseHandler();
						data.file = image;
						this.BPMSoft.ImageApi.upload(data);
					} else {
						this.set(this.primaryImageColumnName, null);
					}
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Name",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 11,
							"column": 2,
							"row": 0
						}
					}
				},
				{
					"operation": "insert",
					"name": "Position",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 11,
							"column": 14,
							"row": 0
						}
					}
				},
				{
					"operation": "merge",
					"name": "Description",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {
							"colSpan": 24,
							"column": 2,
							"row": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ImageContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container"],
						"layout": {"column": 0, "row": 0, "rowSpan": 2, "colSpan": 2},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "ImageContainer",
					"propertyName": "items",
					"name": "Image",
					"values": {
						"getSrcMethod": "getSrcMethod",
						"onPhotoChange": "onImageChange",
						"beforeFileSelected": true,
						"readonly": false,
						"defaultImage": {"bindTo": "getDefaultImageURL"},
						"layout": {"column": 0, "row": 0, "rowSpan": 2, "colSpan": 2},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				},
			]/**SCHEMA_DIFF*/
		};
	});
