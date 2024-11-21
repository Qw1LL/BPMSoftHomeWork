define("CaseSection", ["BaseFiltersGenerateModule", "CheckBoxFixedFilterStyle", "StorageUtilities",
			"ServiceDeskConstants", "CasePageUtilitiesV2", "css!CheckBoxFixedFilterStyle"],
		function(BaseFiltersGenerateModule, CheckBoxFixedFilterStyle, StorageUtilities, ServiceDeskConstants) {
			return {
				entitySchemaName: "Case",
				contextHelpId: "1001",
				mixins: {
					/**
					 * @class CasePageUtilitiesV2 CasePageUtilitiesV2 implements quick save cards in one click.
					 */
					CasePageUtilitiesV2: "BPMSoft.CasePageUtilitiesV2"
				},
				properties: {

					/**
					 * Property key for 'Show closed cases' button.
					 */
					showClosedCasesPropertyName: "showClosedCases"
				},
				attributes: {
					/**
					 * Resolved button menu visibility.
					 */
					"ResolvedButtonMenuVisible": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						value: false
					},
					/**
					 * Caption for ResolvedMenu button.
					 */
					"ResolvedButtonMenuCaption": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: ""
					},
					/**
					 *  Collection name drop-down menu in the function button.
					 */
					"ResolvedButtonMenuItems": {
						dataValueType: this.BPMSoft.DataValueType.COLLECTION
					},
					"IsActive": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: false
					},
					"NeedReloadData": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: false
					},
					"StatusFilterContainerDisplay": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: true
					},
					/**
					 * Container for custom case section profile.
					 */
					"CaseSectionCustomProfile": {
						dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						value: null
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "ResolvedButton",
						"parentName": "CombinedModeActionButtonsCardLeftContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"caption": {
								"bindTo": "ResolvedButtonMenuCaption"
							},
							"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
							"classes": {
								"textClass": ["actions-button-margin-right", "resolved-button-padding-border-right"],
								"wrapperClass": ["actions-button-margin-right"],
								"markerClass": ["resolved-button-pos-left"]
							},
							"click": {"bindTo": "onResolvedButtonMenuClick"},
							"menu": {
								"items": {"bindTo": "ResolvedButtonMenuItems"}
							},
							"visible": {
								"bindTo": "ResolvedButtonMenuVisible"
							}
						}
					},//FiltersContainer
					{
						"operation": "insert",
						"name": "IsActiveFiltersContainer",
						"parentName": "FiltersContainer",
						"propertyName": "items",
						"index": 0,
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"visible": {"bindTo": "StatusFilterContainerDisplay"},
							"wrapClass": ["isActive-filter-container-wrapClass"],
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "IsActiveFiltersContainer",
						"propertyName": "items",
						"name": "IsActive",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.CheckboxFilterCaption"
							},
							"bindTo": "IsActive",
							"controlConfig": {
								"className": "BPMSoft.CheckBoxEdit",
								"checkedchanged": {
									"bindTo": "onCheckboxChecked"
								},
								"checked": {
									"bindTo": "IsActive"
								}
							}
						}
					}
				]/**SCHEMA_DIFF*/,
				messages: {
					/**
					 * @message UpdateResolvedButtonMenu
					 * It is need to update the collection of menu items quick save button after changing status.
					 * @param {Object} Id current status.
					 */
					"UpdateResolvedButtonMenu": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},

					/**
					 * @message OnResolvedButtonMenuClick
					 * Event menu selection buttons quick save.
					 * @param {Object} config menu
					 */
					"OnResolvedButtonMenuClick": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {

					/**
					 * Adds custom values to the profile.
					 * @param {String} propertyName Property name.
					 * @param {Object} propertyValue Property value.
					 * @private
					 */
					_addPropertyToProfile: function(propertyName, propertyValue) {
						var key = this.getCustomProfileKey();
						var profile = this.$CaseSectionCustomProfile;
						if (!this.Ext.isEmpty(profile)) {
							profile[propertyName] = propertyValue;
							BPMSoft.utils.saveUserProfile(key, profile, false);
							this.$CaseSectionCustomProfile = profile;
						}
					},

					/**
					 * Returns profile key.
					 * @returns {string} Profile key.
					 */
					getCustomProfileKey: function() {
						var schemaName = this.name;
						return schemaName + "CustomSectionData";
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#loadGridDataView
					 * @overridden
					 */
					loadGridDataView: function() {
						this.set("StatusFilterContainerDisplay", true);
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#loadAnalyticsDataView
					 * @overridden
					 */
					loadAnalyticsDataView: function() {
						this.set("StatusFilterContainerDisplay", true);
						this.callParent(arguments);
					},
					/**
					 * Publishes a message to the current state of the registry.
					 * In the state of zavistimosti - Card or sets the style for a Section SectionFiltersContainer.
					 */
					onSectionModeChanged: function() {
						this.callParent(arguments);
						CheckBoxFixedFilterStyle.setFilterContainerStyle(this);
					},

					/**
					 * Event menu selection buttons quick save
					 * @protected
					 */
					onResolvedButtonMenuClick: function() {
						var tagButtonMenu = arguments[0];
						if (!tagButtonMenu) {
							var resolvedButtonMenuItems = this.get("ResolvedButtonMenuItems");
							if (!resolvedButtonMenuItems.isEmpty()) {
								tagButtonMenu = resolvedButtonMenuItems.collection.items[0].values.Tag;
							}
						}
						this.sandbox.publish("OnResolvedButtonMenuClick", tagButtonMenu,
								[this.sandbox.id + "_CardModuleV2"]);
					},

					/**
					 * @inheritdoc BPMSoft.BaseSectionV2#changeDataView
					 * @overridden
					 */
					changeDataView: function() {
						this.callParent(arguments);
						if (this.$NeedReloadData) {
							this.reloadGridData();
							this.$NeedReloadData = false; 
						}
					},

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#initializeProfile
					 * @overridden
					 */
					initializeProfile: function(callback, scope) {
						this.callParent([function() {
							this.requireCustomProfile(callback, scope);
						}, scope || this]);
					},

					/**
					 * Loads case section profile.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback context.
					 */
					requireCustomProfile: function(callback, scope) {
						var key = this.getCustomProfileKey();
						this.requireProfile(function(profile) {
							if (profile) {
								this.$CaseSectionCustomProfile = profile;
								if (!this.Ext.isEmpty(profile[this.showClosedCasesPropertyName])) {
									this.$NeedReloadData = profile[this.showClosedCasesPropertyName];
									this.set("IsActive", profile[this.showClosedCasesPropertyName]);
								}
							}
							Ext.callback(callback, scope);
						}, scope || this, key);
					},

					/**
					 * Initializes the initial values of the model.
					 * @overridden
					 */
					init: function() {
						this.subscribeResolvedButton();
						this.initSatisfactionUpdateProcessJob();
						this.callParent(arguments);
					},

					/**
					 * Subscribes for resolved button events.
					 * @protected
					 */
					subscribeResolvedButton: function() {
						this.initResolvedButtonCollection();
						var resolvedClickSubscriberId = this.sandbox.id + "_CardModuleV2";
						this.sandbox.subscribe("UpdateResolvedButtonMenu", function(recordId) {
							this.initResolvedButtonCollection(recordId);
						}, this, [resolvedClickSubscriberId]);
					},

					/**
					 * Sets initial values for SatisfactionUpdateProcessJob
					 * @protected
					 */
					initSatisfactionUpdateProcessJob: function() {
						this.callSyncJobService(ServiceDeskConstants.SetSatisfactionTaskPeriod,
								"SatisfactionUpdateProcessJob", "SatisfactionUpdateProcess");
						var wasCheckTermSet = StorageUtilities.getItem("wasCheckTermSet");
						if (wasCheckTermSet) {
							return;
						}
						StorageUtilities.setItem(true, "wasCheckTermSet");
						this.BPMSoft.SysSettings.querySysSettingsItem("CaseOverduesCheckTerm",
								this.callOverdueSetter, this);
					},

					/**
					 * Create a scheduler to run the process at intervals.
					 * @param {Integer} value Value of the period in minutes
					 * @param {String} jobname Name of the task scheduler
					 * @param {String} processName The name of the process
					 */
					callSyncJobService: function(value, jobname, processName) {
						var config = {
							serviceName: "SyncJobService",
							methodName: "CreateSyncJob",
							data: {
								request: {
									JobName: jobname,
									ProcessName: processName,
									PeriodInMinutes: value
								}
							}
						};
						this.callService(config, this.BPMSoft.emptyFn, this);
					},

					/**
					 * Create a scheduler start the installation process indicators overdue appeals.
					 * @param {Integer} value The value of the system setting "Term inspection overdue treatment Minutes".
					 * @overridden
					 */
					callOverdueSetter: function(value) {
						this.callSyncJobService(value, "CaseOverduesSettingJob", "CaseOverduesSettingProcess");
					},

					/**
					 * The change in state CheckBox
					 * @param {Object} value The new value of the CheckBox after change.
					 */
					onCheckboxChecked: function(value) {
						this.$NeedReloadData = true;
						this.set("IsActive", value);
						this._addPropertyToProfile(this.showClosedCasesPropertyName, value);
						this.sandbox.publish("FiltersChanged", null, [this.sandbox.id]);
						CheckBoxFixedFilterStyle.onClick(value, this);
						var activeViewName = this.getActiveViewName();
						if (activeViewName === this.get("AnalyticsDataViewName")) {
							this.sandbox.publish("SectionUpdateFilter",
								null, [this.getQuickFilterModuleId()]);
						}
					},

					/**
					 * Initializes the setting of fixed filters.
					 * @overridden
					 */
					initFixedFiltersConfig: function() {
						var fixedFilterConfig = {
							entitySchema: this.entitySchema,
							filters: [
								{
									name: "Owner",
									caption: this.get("Resources.Strings.OwnerFilterCaption"),
									dataValueType: this.BPMSoft.DataValueType.LOOKUP,
									filter: BaseFiltersGenerateModule.OwnerFilter,
									columnName: "Owner",
									defValue: {
										value: this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
										displayValue: this.BPMSoft.SysValue.CURRENT_USER_CONTACT.displayValue
									}
								}
							]
						};
						this.set("FixedFilterConfig", fixedFilterConfig);
					},

					/**
					 * Set ID contextual help.
					 * @protected
					 */
					initContextHelp: function() {
						this.set("ContextHelpId", 1063);
						this.callParent(arguments);
					},

					/**
					 *@inheritDoc BPMSoft.GridUtilitiesV2#getFilters
					 *@overriden
					 */
					getFilters: function() {
						var filters = this.callParent(arguments);
						var isFinal = this.get("IsActive");
						if (!isFinal) {
							filters.add("FilterStatus", this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.EQUAL, "Status.IsFinal", isFinal));
						}
						return filters;
					}
				}
			};
		});
