define("ContactSearchDetail", ["ContactSearchDetailGridRowViewModel"],
		function() {
			return {
				/**
				 * ### ##### #######
				 * @type {String}
				 */
				entitySchemaName: "Contact",
				messages: {
					/**
					 * @message IsCaseIncluded
					 * ########## # ###### #########.
					 * @param {boolean} ####### ######### ### ############.
					 */
					"IsCaseIncluded": {
						mode: this.BPMSoft.MessageMode.BROADCAST,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message GetSelectButtonCaption
					 * ######## ####### ###### ######.
					 * @param {String} ####### ###### ######.
					 */
					"GetSelectButtonCaption": {
						mode: this.BPMSoft.MessageMode.BROADCAST,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				attributes: {
					"IsCaseIncluded": {
						dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"SelectButtonCaption": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				methods: {
					/**
					 * ######### ####### ### ###### # #### ########## ######### #### ######
					 * @protected
					 * @virtual
					 * @param {Object} config ############ ######, ### #### ######## #######.
					 * @param {Boolean} isReloadAll #### ########## ######.
					 */
					refreshRecords: function(config, isReloadAll) {
						var filters = this.Ext.create("BPMSoft.FilterGroup");
						var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
						filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
						var isArguments = false;
						if (config) {
							for (var item in config) {
								if (!this.Ext.isEmpty(config[item])) {
									isArguments = true;
									switch (item) {
										case "Case":
											filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
													this.BPMSoft.ComparisonType.CONTAIN,
													"[Case:Contact:Id].Number", config[item]));
											break;
										case "Account":
											filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
													this.BPMSoft.ComparisonType.CONTAIN,
													"[Account:Id:AccountId].Name", config[item]));
											break;
										case "Phone":
											filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
												this.BPMSoft.ComparisonType.CONTAIN,
												"[ContactCommunication:Contact:Id].Number", config[item]));
											break;
										default:
											filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
													this.BPMSoft.ComparisonType.CONTAIN,
													item, config[item]));
									}
								}
							}
						}
						if (!isArguments) {
							filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.EQUAL,
									"Id", this.BPMSoft.GUID_EMPTY));
						}
						filters.addItem(filterGroup);
						this.set("detailFilter", filters);
						if (isReloadAll) {
							this.updateDetail({reloadAll: true});
						}
					},
					/**
					 * @inheritDoc BPMSoft.BaseModuleSectionV2#init
					 * @overridden
					 */
					init: function() {
						this.callParent(arguments);
						this.refreshRecords(null, false);
					},
					/**
					 * ############# ## #########, ########### ### ###### ######
					 * @protected
					 * @overridden
					 */
					subscribeSandboxEvents: function() {
						this.sandbox.subscribe("UpdateDetail",
								function(config) {
									this.refreshRecords(config, true);
								},
								this, [this.sandbox.id]);
						this.sandbox.subscribe("IsCaseIncluded",
								function(config) {
									this.set("IsCaseIncluded", config);
								},
								this);
						this.sandbox.subscribe("GetSelectButtonCaption",
								function(config) {
									this.set("SelectButtonCaption", config);
								},
								this);
					},
					/**
					 * ######## ######### ########
					 * overridden
					 * @returns {Object}
					 */
					getFilters: function() {
						return this.get("detailFilter");
					},
					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
					 * @overridden
					 */
					addRecordOperationsMenuItems : this.BPMSoft.emptyFn,
					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
					 * @overridden
					 */
					addDetailWizardMenuItems: this.BPMSoft.emptyFn,
					/**
					 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
					 * @overridden
					 */
					getSwitchGridModeMenuItem : this.BPMSoft.emptyFn,
					/**
					 * @inheritdoc BPMSoft.GridUtilitiesV2#getIsLinkColumn
					 * @overridden
					 */
					getIsLinkColumn: function() {
						return false;
					},
					/**
					 * ############ ####### "########" ######## ######.
					 * @overridden
					 */
					onActiveRowAction: function() {
						this.sandbox.publish("DetailChanged", this.get("ActiveRow"), [this.sandbox.id]);
					},
					/**
					 * ######## ######## ###### ###### ############# ############# ####### ## ########### #######
					 * @protected
					 * @return {String} ########## ########
					 */
					getGridRowViewModelClassName: function() {
						return "BPMSoft.ContactSearchDetailGridRowViewModel";
					},
					/**
					 * ############## ######## ###### ############# ####### #####.
					 * ######### ########## #######
					 * #### ###### ####### ############ - #######
					 * #### ##### ######### - ####### #########
					 * @protected
					 * @overridden
					 */
					getGridRowViewModelConfig: function() {
						var gridRowViewModelConfig = this.callParent(arguments);
						gridRowViewModelConfig.values.CaseVisibility = this.get("IsCaseIncluded");
						gridRowViewModelConfig.values.SelectButtonCaption = this.get("SelectButtonCaption");
						return gridRowViewModelConfig;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "AddRecordButton"
					},
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"activeRowAction": {bindTo: "onActiveRowAction"},
							"activeRowActions": [
								{
									"className": "BPMSoft.Button",
									"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
									"caption": {"bindTo": "SelectButtonCaption"}
								}
							]
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);
