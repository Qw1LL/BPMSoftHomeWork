﻿define("CasePriorityLookupEditPageV2", ["ext-base", "BPMSoft", "CasePriorityLookupEditPageV2Resources"],
	function(Ext, BPMSoft, resources) {
		return {
			entitySchemaName: "CasePriority",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {},
			methods: {
				/**
				 * Processing change photos.
				 * @param {Object} image.
				 */
				onImageChange: function(image) {
					var callbackSuccess = function(imageId) {
						var imageData = {
							value: imageId,
							displayValue: "Image"
						};
						this.set(this.primaryImageColumnName, imageData);
					};
					var data = {
						onComplete: callbackSuccess,
						onError: function(e) {
							throw new BPMSoft.UnknownException({
								message: e.error
							});
						},
						scope: this
					};
					if (image) {
						data.file = image;
						this.BPMSoft.ImageApi.upload(data);
					} else {
						this.set(this.primaryImageColumnName, null);
					}
				},

				/**
				 * The method of obtaining the reference image.
				 * @return {*}
				 */
				getSrcMethod: function() {
					var primaryImageColumnValue = this.get(this.primaryImageColumnName);
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
				 * @inheritDoc BasePageV2#asyncValidate
				 * @overridden
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						this.responceValidate(response, callback, scope);
					}, this]);
				},

				/**
				 * Handles responce of asyncValidate for setTypeOfField.
				 * @param {Object} response Responce of asyncValidate.
				 * @param {Function} callback callback function.
				 * @param {BPMSoft.BaseSchemaViewModel} scope callback scope.
				 * @protected
				 */
				responceValidate: function(response, callback, scope) {
					if (!this.validateResponse(response)) {
						return;
					}
					BPMSoft.chain(
						function(next) {
							this.validatePrioritis(function(response) {
								if (this.validateResponse(response)) {
									next();
								}
							}, this);
						},
						function(next) {
							this.validateName(function(response) {
								if (this.validateResponse(response)) {
									next();
								}
							}, this);
						},
						function(next) {
							callback.call(scope, response);
							next();
						}, this);
				},

				/**
				 * Validate name column value.
				 * @private
				 * @param {Function} callback callback function.
				 * @param {BPMSoft.BaseSchemaViewModel} scope callback scope.
				 */
				validateName: function(callback, scope) {
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Name)) {
						callback.call(scope, {success: true});
					} else {
						var result = {success: true};
						var name = this.changedValues.Name;
						this.nameHasDuplicatesValidate(callback, scope, result, name);
					}
				},

				/**
				 * Create an instance of the class that returns the result of the validation CasePriority pairs.
				 * @private
				 * @param {Object} priorityTimeUnit param for validation.
				 * @param {Integer} priorityTimeValue param for validation.
				 * @return {Object} instance of the "CasePriorityTimeValidation" class.
				 */
				createPrioritiesValidator: function(priorityTimeUnit, priorityTimeValue) {
					Ext.define("BPMSoft.Configuration.CasePriorityTimeValidation", {

						timeUnit: "",
						timeValue: "",

						/**
						 * Set pair.
						 * @constructor
						 * @param {Object} pair pair for validation.
						 */
						constructor: function(pair) {
							this.timeUnit = pair.unit;
							this.timeValue = pair.value;
						},

						/**
						 * Check the value in the pairing.
						 * @private
						 * @return {Boolean} validation result.
						 */
						validatePair: function() {
							if (this.timeUnit) {
								if (Ext.isEmpty(this.timeValue) || this.timeValue === 0) {
									return false;
								}
							}
							if (this.timeValue) {
								if (Ext.isEmpty(this.timeUnit)) {
									return false;
								}
							}
							return true;
						}
					});
					return Ext.create("BPMSoft.Configuration.CasePriorityTimeValidation",
						{unit: priorityTimeUnit, value: priorityTimeValue});
				},

				/**
				 * Formation object response.
				 * @private
				 * @param {String} message message name.
				 */
				createResponseMessage: function(message) {
					return {
						success: false,
						message: this.get("Resources.Strings." + message + "")
					};
				},

				/**
				 * Validate CasePriority (if exist priority value must be to).
				 * @private
				 * @param {Function} callback callback function.
				 * @param {BPMSoft.BaseSchemaViewModel} scope callback scope.
				 */
				validatePrioritis: function(callback, scope) {
					var result = {success: true};
					var getSolutionTimeValidate = this.createPrioritiesValidator(
						this.get("SolutionTimeUnit"), this.get("SolutionTimeValue"));
					if (getSolutionTimeValidate.validatePair()) {
						var getReactionTimeValidate = this.createPrioritiesValidator(
							this.get("ReactionTimeUnit"), this.get("ReactionTimeValue"));
						if (!getReactionTimeValidate.validatePair()) {
							result = this.createResponseMessage("EmptyReactionTimeValueMessage");
						}
					} else {
						result = this.createResponseMessage("EmptySolutionTimeValueMessage");
					}
					callback.call(scope, result);
				},

				/**
				 * Validate that name column value has no duplicates.
				 * @private
				 * @param {Function} callback callback function.
				 * @param {BPMSoft.BaseSchemaViewModel} scope callback scope.
				 * @param {Object} result Callback result of nameHasDuplicatesValidate function.
				 * @param {String} name Name column value.
				 */
				nameHasDuplicatesValidate: function(callback, scope, result, name) {
					var id = this.get("Id");
					var query = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "CasePriority"
					});
					query.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
					var duplicatesFilter = query.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Name", name);
					var notSelfFilter = query.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Id", id);
					var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
					filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
					filterGroup.addItem(notSelfFilter);
					filterGroup.addItem(duplicatesFilter);
					query.filters.addItem(filterGroup);
					query.getEntityCollection(function(resultQuery) {
						this.getHasDuplicatesHandler(callback, scope, result, resultQuery);
					}, this);
				},

				/**
				 * Handles entitySchemaQuery.getEntityCollection getHasDuplicates query response.
				 * @private
				 * @param {Function} callback callback function.
				 * @param {BPMSoft.BaseSchemaViewModel} scope callback scope.
				 * @param {Object} result Callback result of getEntityCollection function.
				 * @param {String} resultQuery entitySchemaQuery result.
				 */
				getHasDuplicatesHandler: function(callback, scope, result, resultQuery) {
					if (resultQuery.success && resultQuery.collection.getItems()[0].get("Count")) {
						result = {
							message: this.get("Resources.Strings.NameIsDuplicateMessage"),
							success: false
						};
					}
					callback.call(scope, result);
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
						"getSrcMethod": "getSrcMethod",
						"onPhotoChange": "onImageChange",
						"beforeFileSelected": "beforeFileSelected",
						"readonly": false,
						"defaultImage": {"bindTo": "getDefaultImageURL"},
						"layout": {
							"column": 0,
							"row": 0,
							"rowSpan": 3,
							"colSpan": 2
						},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
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
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Priority",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 7,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Description",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 7,
							"rowSpan": 1
						},
						"contentType": this.BPMSoft.ContentType.LONG_TEXT
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ReactionTimeValue",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 4,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ReactionTimeUnit",
					"values": {
						"layout": {
							"column": 5,
							"row": 3,
							"colSpan": 6,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "SolutionTimeValue",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 4,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "SolutionTimeUnit",
					"values": {
						"layout": {
							"column": 5,
							"row": 4,
							"colSpan": 6,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				}
			]/**SCHEMA_DIFF*/
		};
	});
