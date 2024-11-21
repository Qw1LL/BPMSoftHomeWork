define("CampaignDiagramPropertyBulkEmailPage", ["BPMSoft", "CampaignDiagramPropertyBulkEmailPageResources",
			"MarketingEnums"],
		function(BPMSoft, resources, MarketingEnums) {
			return {
				entitySchemaName: "BulkEmail",
				methods: {
					/**
					 * Returns a collection of fields used in the entity.
					 * @protected
					 * @overridden
					 * @return {Array} Collection fields.
					 */
					getUsedColumns: function() {
						return [
								"Id",
								"Name",
								"StartDate",
								"TemplateSubject",
								"SenderName",
								"SenderEmail",
								"Category"
							];
					},

					/**
					 * @inheritdoc BPMSoft.BaseViewModel#CampaignDiagramPropertyEntityPage
					 */
					formLookupConfig: function(entity) {
						var config = this.callParent(arguments);
						return this.Ext.apply(config, {
							Category: entity.get("Category")
						});
					},

					/**
					 * Returns a filter collection lookup field Entity.
					 * @protected
					 * @overriden
					 * @return {BPMSoft.FiltersGroup} Collection fields.
					 */
					getCustomLookupFilters: function() {
						var filters = BPMSoft.createFilterGroup();
						filters.logicalOperation = BPMSoft.LogicalOperatorType.AND;
						filters.addItem(BPMSoft.createColumnIsNullFilter("Campaign"));
						filters.addItem(BPMSoft.createColumnIsNullFilter("SplitTest"));
						filters.addItem(BPMSoft.createColumnInFilterWithParameters(
							"Status", [
								MarketingEnums.BulkEmailStatus.ACTIVE,
								MarketingEnums.BulkEmailStatus.PLANNED,
								MarketingEnums.BulkEmailStatus.START_SCHEDULED,
								MarketingEnums.BulkEmailStatus.STOPPED
							]));
						filters.addItem(BPMSoft.createColumnInFilterWithParameters(
							"LaunchOption", [
								MarketingEnums.BulkEmailLaunchOption.MASS_MAILING_SCHEDULED,
								MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_SHEDULED,
								MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_IMMEDIATE,
								MarketingEnums.BulkEmailLaunchOption.TRIGGERED_EMAIL_HOURLY
							]));
						filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"RecipientCount", 0));
						return filters;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "CampaignDiagramPropertyDescriptionContainer"
					},
					{
						"operation": "merge",
						"name": "CampaignDiagramPropertyEntityMainContainer",
						"values": {
							"wrapClass": ["main", "fields-container"]
						}
					},
					{
						"operation": "insert",
						"name": "StartDate",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false
							}
						}
					},
					{
						"operation": "insert",
						"name": "TemplateSubject",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false,
								"setValidationInfo": BPMSoft.emptyFn
							},
							"isRequired": false
						}
					},
					{
						"operation": "insert",
						"name": "SenderName",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false,
								"setValidationInfo": BPMSoft.emptyFn
							},
							"isRequired": false
						}
					},
					{
						"operation": "insert",
						"name": "SenderEmail",
						"parentName": "CampaignDiagramPropertyEntityMainContainer",
						"propertyName": "items",
						"values":  {
							"controlConfig": {
								"enabled": false,
								"setValidationInfo": BPMSoft.emptyFn
							},
							"isRequired": false
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
