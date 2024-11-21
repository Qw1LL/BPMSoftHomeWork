define("SectionActionsDashboard", ["SectionActionsDashboardResources", "ConfigurationConstants",
			"SocialMessagePublisherModule"],
	function(resources, ConfigurationConstants) {
		return {
			attributes: {},
			messages: {},
			methods: {

				/**
				 * @inheritdoc BPMSoft.ActionsDashboard#getExtendedConfig
				 * @overridden
				 */
				getExtendedConfig: function() {
					var config = this.callParent(arguments);
					var lczImages = resources.localizableImages;
					config.TaskMessageTab = {
						"ImageSrc": this.BPMSoft.ImageUrlBuilder.getUrl(lczImages.TaskMessageTabImage),
						"MarkerValue": "task-message-tab",
						"Align": this.BPMSoft.Align.RIGHT,
						"Tag": "Task"
					};
					return config;
				},

				/**
				 * @inheritdoc BPMSoft.ActionsDashboard#onActiveTabChange
				 * @overridden
				 */
				onActiveTabChange: function(activeTab) {
					var messageType = activeTab.get("Name");
					if (messageType === "TaskMessageTab") {
						var operation = this.getMasterEntityParameterValue("Operation");
						var cardOperations = this.BPMSoft.ConfigurationEnums.CardOperation;
						if (operation === cardOperations.ADD || operation === cardOperations.COPY) {
							var config = {
								callback: this.openTask
							};
							this.saveMasterEntity(config, this);
						} else {
							this.openTask();
						}
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * Opens task card.
				 * @private
				 */
				openTask: function() {
					var task = this.getTaskEntityStructure();
					if (task && task.hasAddMiniPage) {
						this.openTaskMiniPage();
					} else {
						this.openTaskPage();
					}
				},

				/**
				 * Opens task page with default values.
				 * @private
				 */
				openTaskPage: function() {
					var defaultValues = this.getDefaultValues();
					this.openCardInChain({
						"schemaName": "ActivityPageV2",
						"operation": this.BPMSoft.ConfigurationEnums.CardOperation.ADD,
						"moduleId": this.sandbox.id + "ActivityPageV2",
						"renderTo": "centerPanel",
						"defaultValues": defaultValues
					});
				},

				/**
				 * Opens task MiniPage with default values.
				 * @private
				 */
				openTaskMiniPage: function() {
					var defaultValues = this.getDefaultValues();
					this.openMiniPage({
						"entitySchemaName": "Activity",
						"operation": this.BPMSoft.ConfigurationEnums.CardOperation.ADD,
						"valuePairs": defaultValues,
						"isFixed": true,
						"showDelay": 0
					});
				},

				/**
				 * Returns default values for the task page.
				 * @protected
				 * @return {Object} DefaultValues.
				 */
				getDefaultValues: function() {
					var defaultValues = [];
					var activityId = this.BPMSoft.generateGUID();
					defaultValues.push({
						name: "Id",
						value: activityId
					});
					var activityConfig = this.getDashboardItemsConfig("Activity");
					if (activityConfig && activityConfig.referenceColumnName) {
						defaultValues.push({
							name: activityConfig.referenceColumnName,
							value: this.getMasterEntityParameterValue("Id")
						});
					}
					var contact = this.getMasterEntityParameterValue("Contact");
					if (this.Ext.isObject(contact) && contact.value) {
						defaultValues.push({
							name: "Contact",
							value: contact.value
						});
					}
					var account = this.getMasterEntityParameterValue("Account");
					if (this.Ext.isObject(account) && account.value) {
						defaultValues.push({
							name: "Account",
							value: account.value
						});
					}
					var activityType = ConfigurationConstants.Activity.Type.Task;
					defaultValues.push({
						name: "Type",
						value: activityType
					});
					return defaultValues;
				},
				/**
				 * @inheritdoc BPMSoft.MessagePublisher.SectionActionsDashboard#getSectionPublishers
				 * @overridden
				 */
				getSectionPublishers: function() {
					var publishers = this.callParent(arguments);
					publishers.push("Task");
					return publishers;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "TaskMessageTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"items": []
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
