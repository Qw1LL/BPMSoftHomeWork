define("ReclassificationEditPage", ["ReclassificationEditPageResources", "BusinessRuleModule",
			"CaseServiceContractUtility", "css!RecommendationModule"],
		function(resources, BusinessRuleModule) {
			return {
				entitySchemaName: "Case",
				messages: {
					/**
					 * @message SetParametersInfo
					 * Set escalation parameters info to CasePage
					 */
					"SetParametersInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				attributes: {
					"ServicePact": {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							filter: function() {
								return this.getServicePactFilter();
							}
						}
					},
					"ServiceItem": {
						lookupListConfig: {
							filter: function() {
								return this.getServiceItemFilters();
							}
						},
						dependencies: [
							{
								columns: ["ServicePact"],
								methodName: "onServicePactChanged"
							}
						]
					},
					"Category": {
						"isRequired": true,
						"dependencies": [
							{
								"columns": ["Category"],
								"methodName": "onCategoryChanged"
							}
						]
					}
				},
				mixins: {
					CaseServiceContractUtility: "BPMSoft.CaseServiceContractUtility"
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				methods: {
					/**
					 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
					 * @overridden
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						this.setInitialValues();
					},

					/**
					 * Category field change handler.
					 * @protected
					 */
					onCategoryChanged: function() {
						this.set("ServiceItem", null);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getPageHeaderCaption
					 * @overridden
					 */
					getPageHeaderCaption: function() {
						return this.get("Resources.Strings.ReclassificationPageCaption");
					},
					/**
					 * Runs case reclassification.
					 * @protected
					 * @virtual
					 */
					reclassificate: function() {
						if (!this.validateParameters()) {
							this.setValidationAttributes();
							this.showInformationDialog(this.getValidationMessage());
							return;
						}
						var properties = this.getParametersInfo();
						this.sandbox.publish("SetParametersInfo", properties, [this.sandbox.id]);
						this.onCloseCardButtonClick();
					},
					/**
					 * Returns set parameters info of case page.
					 * @protected
					 * @virtual
					 */
					getParametersInfo: function() {
						return {
							ServiceItem: this.get("ServiceItem"),
							ServicePact: this.get("ServicePact"),
							Category: this.get("Category")
						};
					},

					/**
					 * Validates attributes of reclassification page.
					 * @protected
					 * @virtual
					 */
					validateParameters: function() {
						var parameters = this.getValidationAttributesName();
						var result = true;
						this.BPMSoft.each(parameters, function(attributeName) {
							var attributeValidationInfo = this.getAttributeValidationInfo(attributeName);
							result = result && attributeValidationInfo.isValid;
							this.validationInfo.set(attributeName, attributeValidationInfo);
						}, this);
						return result;
					},

					/**
					 * Returns validation attributes name.
					 * @protected
					 * @virtual
					 * @return {Array} Validation attributes name.
					 */
					getValidationAttributesName: function() {
						return ["ServicePact", "ServiceItem", "Category"];
					},

					/**
					 * Returns attribute validation info.
					 * @protected
					 * @virtual
					 * @param {String} attributeName Name of attribute.
					 * @return {Object} Attribute validation info.
					 */
					getAttributeValidationInfo: function(attributeName) {
						var attribute = this.get(attributeName);
						var isValid = !this.Ext.isEmpty(attribute && attribute.value);
						var validationInfo = {
							invalidMessage: this.BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage,
							isValid: isValid
						};
						return validationInfo;
					},
					/**
					 * Sets validation atrributes of reclassification page.
					 * @protected
					 * @virtual
					 */
					setValidationAttributes: function() {
						var attributes = {
							ServicePact: this.validationInfo.attributes.ServicePact,
							ServiceItem: this.validationInfo.attributes.ServiceItem,
							Category: this.validationInfo.attributes.Category
						};
						this.validationInfo.attributes = attributes;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "SaveButton",
						"values": {
							"caption": {"bindTo": "Resources.Strings.ReclassificateButtonCaption"},
							"click": {"bindTo": "reclassificate"}
						}
					},
					{
						"operation": "remove",
						"name": "ViewOptionsButton"
					},
					{
						"operation": "insert",
						"name": "RecalculationNotification",
						"parentName": "Header",
						"propertyName": "items",
						"values": {
							"labelClass": ["t-label information recommendation"],
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": {
								"bindTo": "Resources.Strings.RecalculationNotificationCaption"
							},
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 18,
								"rowSpan": 2
							}
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Category",
						"values": {
							"bindTo": "Category",
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 24,
								"rowSpan": 1
							},
							"contentType": this.BPMSoft.ContentType.ENUM,
							"caption": {
								"bindTo": "Resources.Strings.CaseCategoryCaption"
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "ServicePact",
						"values": {
							"bindTo": "ServicePact",
							"layout": {
								"column": 0,
								"row": 4,
								"colSpan": 24,
								"rowSpan": 1
							},
							"contentType": this.BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "ServiceItem",
						"values": {
							"bindTo": "ServiceItem",
							"layout": {
								"column": 0,
								"row": 5,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					}
				]/**SCHEMA_DIFF*/,
				userCode: {},
				rules: {
					"ServiceItem": {
						"BindingServiceItemToServicePact": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"logical": this.BPMSoft.LogicalOperatorType.AND,
							"property": BusinessRuleModule.enums.Property.ENABLED,
							"conditions": [
								{
									"leftExpression": {
										"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
										"attribute": "ServicePact"
									},
									"comparisonType": this.BPMSoft.ComparisonType.IS_NOT_NULL
								}
							]
						},
						"ServiceItemRequired": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [
								{
									"leftExpression": {
										"type": BusinessRuleModule.enums.ValueType.CONSTANT,
										"value": true
									},
									"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
									"rightExpression": {
										"type": BusinessRuleModule.enums.ValueType.CONSTANT,
										"value": true
									}
								}
							]
						}
					}
				}
			};
		});
