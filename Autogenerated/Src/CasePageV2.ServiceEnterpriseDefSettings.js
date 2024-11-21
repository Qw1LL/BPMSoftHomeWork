define("CasePageV2", ["ProcessModuleUtilities", "CasePageV2Resources"],
	function(ProcessModuleUtilities, resourses) {
		return {
			entitySchemaName: "Case",
			details: /**SCHEMA_DETAILS*/{
				"ConfItem": {
					"schemaName": "ConfItemCaseDetail",
					"entitySchemaName": "ConfItemInCase",
					"filter": {
						"detailColumn": "Case",
						"masterColumn": "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Change",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Change"
					},
					"parentName": "SolutionMainGroup_gridLayout",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "Problem",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Problem"
					},
					"parentName": "SolutionMainGroup_gridLayout",
					"propertyName": "items",
					"index": 11
				},
				{
					"operation": "insert",
					"name": "ConfItem",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				}
			]/**SCHEMA_DIFF*/,
			mixins: {},
			attributes: {},
			messages: {
				/**
				 * @message SetParametersInfo
				 * Set parameters info from escalation page.
				 */
				"SetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onQueueInfoFinded
				 * @overriden
				 */
				 onQueueInfoFinded: function() {
					this.callParent(arguments);
					this.set("Owner", this.BPMSoft.SysValue.CURRENT_USER_CONTACT);
				},
				/**
				 * Open service model by case service.
				 * @protected
				 * @virtual
				 */
				openServiceModelModule: function() {
					var serviceItem = this.get("ServiceItem");
					if (!serviceItem) {
						this.save();
						return;
					}
					var defaultValues = [{
						"id": serviceItem.value,
						"schemaName": this.getColumnByName("ServiceItem").name,
						"name": serviceItem.displayValue
					}];
					this.openCardInChain({
						"schemaName": "ServiceModelPage",
						"moduleId": this.sandbox.id + "_ServiceModelPage",
						"isSeparateMode": false,
						"defaultValues": defaultValues
					});
				},
				/**
				 * @inheritdoc BPMSoft.BasePageV2#getActions
				 * @overridden
				 */
				getActions: function() {
					var defaultMenuItems = this.callParent(arguments);
					var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Tag": "runEscalation",
						"Caption": resourses.localizableStrings.EscalationTitle,
						"Enabled": !this.isNewMode()
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Tag": "runSearchForSimilarCases",
						"Caption": resourses.localizableStrings.SearchForSimilarCasesButtonCaption,
						"Enabled": !this.isNewMode()
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Tag": "openServiceModelModule",
						"Caption": resourses.localizableStrings.OpenServiceModelByServiceModuleCaption,
						"Enabled": !this.isNewMode()
					}));
					actionMenuItems.addItem(this.getButtonMenuSeparator());
					defaultMenuItems.each(function(item) {
						actionMenuItems.addItem(item);
					});
					return actionMenuItems;
				},
				/**
				 * Run process "Search for similar cases".
				 * @protected
				 * @virtual
				 */
				runSearchForSimilarCases: function() {
					var parameters = {
						"IncidentId": this.get("Id")
					};
					ProcessModuleUtilities.runProcess("SearchForParent", parameters, function() {
						this.hideBodyMask();
					}, this);
				},
				/**
				 * Run Escalation.
				 * @protected
				 * @virtual
				 */
				runEscalation: function() {
					var defaultValues = [];
					var scope = this;
					var propertyNames = ["Id", "Group", "Owner", "Contact", "SupportLevel", "ServiceItem"];
					this.BPMSoft.each(propertyNames, function(name) {
						scope.addDefaultValue(defaultValues, name);
					}, this);
					this.openCardInChain({
						"schemaName": "EscalationEditPage",
						"operation": "add",
						"primaryColumnValue": null,
						"moduleId": this.sandbox.id + "_EscalationEditPage",
						"isSeparateMode": false,
						"isInChain": true,
						"defaultValues": defaultValues
					});
				},
				/**
				 * Run Escalation.
				 * @param {Array} defaultValues Collection default values for page.
				 * @param {String} propertyName Property name of default values.
				 * @protected
				 * @virtual
				 */
				addDefaultValue: function(defaultValues, propertyName) {
					var propertyNameValue = this.get(propertyName);
					if (!propertyNameValue) {
						return;
					}
					defaultValues.push({
						name: propertyName,
						value: propertyNameValue.value
					});

				},
				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initPageMessages();
				},
				/**
				 * Set parameters info from escalation page.
				 * @param {Object} parameters Property name of default values.
				 */
				setParametersInfo: function(parameters) {
					if (!parameters) {
						return;
					}
					BPMSoft.each(parameters, function(value, name) {
						this.set(name, value);
					}, this);
					this.save();
				},
				/**
				 * Initializes the required messages for the page.
				 * @protected
				 */
				initPageMessages:  function() {
					var schemaName = "_EscalationEditPage";
					var pageId = this.sandbox.id + schemaName;
					this.sandbox.subscribe("SetParametersInfo", this.setParametersInfo, this, [pageId]);
				}
			},
			rules: {},
			userCode: {}
		};
	});
