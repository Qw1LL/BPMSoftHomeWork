define("SysMobileWorkplacePage", ["MobileDesignerUtils"],
	function(MobileDesignerUtils) {
		return {
			entitySchemaName: "SysMobileWorkplace",
			details: /**SCHEMA_DETAILS*/{
				SysRole: {
					schemaName: "SysRoleInMobWorkplaceDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysMobileWorkplace"
					},
					defaultValues: {
						SysMobileWorkplace: {
							masterColumn: "Id"
						}
					}
				}
			}/**SCHEMA_DETAILS*/,
			messages: {
				"RerenderModule": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"GetWorkplace": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {

				/**
				 * ### sysOperation, ## ######## ##### ############## ######## #### ####### # #######.
				 */
				"SecurityOperationName": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: "CanManageMobileApplication"
				},

				/**
				 * Indicates if current workplace was configured.
				 */
				"IsWorkplaceConfigured": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}

			},
			methods: {

				init: function () {
					this.callParent(arguments);
					var viewModuleContainer = this.Ext.get("ViewModuleContainer");
					viewModuleContainer.addCls("sys-mobile-workplace-page");
				},

				destroy: function() {
					var viewModuleContainer = this.Ext.get("ViewModuleContainer");
					viewModuleContainer.removeCls("sys-mobile-workplace-page");
					this.callParent(arguments);
				},

				/**
				 * @private
				 */
				columnCodeValidator: function() {
					var message = "";
					var code = this.get("Code");
					if (!Ext.isEmpty(code)) {
						var codeRegExp = new RegExp("^[a-zA-Z0-9_]+$");
						if (!codeRegExp.test(code)) {
							message = Ext.String.format(this.get("Resources.Strings.WrongCodeMessage"), code);
						}
					}
					return {invalidMessage: message};
				},

				/**
				 * @private
				 */
				validateUniqueCode: function(callback, scope) {
					var result = {
						success: true
					};
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn("Id");
					esq.filters.add("primaryColumnFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", this.get("PrimaryColumnValue")));
					esq.filters.add("codeFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Code", this.get("Code")));
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							if (response.collection.getCount() > 0) {
								result.message = this.get("Resources.Strings.CodeNotUnique");
								result.success = false;
							}
							callback.call(scope, result);
						}
					}, this);
				},

				/**
				 * @private
				 */
				isCodeEnabled: function() {
					return !this.isEditMode();
				},

				/**
				 * @inheritDoc BasePageV2#subscribeSandboxEvents
				 * @protected
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("GetWorkplace", function() {
						var workplaceId = this.get("PrimaryColumnValue");
						return {
							id: workplaceId
						};
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					if (this.get("ActiveTabName") === "WorkplaceSectionsTab") {
						this.loadWorkplaceSectionsModule();
					}
				},

				/**
				 * ######### ###### ######## ######## #####.
				 * @protected
				 * @virtual
				 */
				loadWorkplaceSectionsModule: function() {
					var moduleId = this.sandbox.id + "_MobileWorkplaceSectionsModule";
					var rendered = this.sandbox.publish("RerenderModule", {
						renderTo: "WorkplaceSectionsTab"
					}, [moduleId]);
					if (!rendered) {
						this.sandbox.loadModule("MobileWorkplaceSectionsModule", {
							renderTo: "WorkplaceSectionsTab",
							id: this.moduleId
						});
					}
				},

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @protected
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Code", this.columnCodeValidator);
				},

				/**
				 * @inhericDoc BasePageV2#asyncValidate
				 * @protected
				 * @overridden
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						BPMSoft.chain(
							function(next) {
								if (this.isNewMode()) {
									this.validateUniqueCode(function(response) {
										if (this.validateResponse(response)) {
											next();
										}
									}, this);
								} else {
									next();
								}
							},
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				},

				/**
				 * @inheritDoc BasePageV2#onSaved
				 * @protected
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					if (this.isNewMode() && !this.get("IsWorkplaceConfigured")) {
						this.set("IsWorkplaceConfigured", true);
						MobileDesignerUtils.openDesignerModule(this.get("Code"));
					}
				},

				/**
				 * Handles "Set up sections" button click.
				 */
				onSetupSectionsButtonClick: function() {
					this.save();
					if (!this.isNewMode() && !this.get("IsWorkplaceConfigured")) {
						this.set("IsWorkplaceConfigured", true);
						MobileDesignerUtils.openDesignerModule(this.get("Code"));
					}
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Name",
						"textSize": 0,
						"labelConfig": {
							"visible": true
						},
						"enabled": true
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Code",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Code",
						"textSize": 0,
						"labelConfig": {
							"visible": true
						},
						"enabled": {
							"bindTo": "Code",
							"bindConfig": {
								"converter": "isCodeEnabled"
							}
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "RolesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.RolesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "RolesTab",
					"propertyName": "items",
					"name": "SysRole",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "remove",
					"name": "actions"
				},
				{
					"operation": "merge",
					"name": "SaveButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"name": "SetupSectionsButton",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.SetupSectionsButtonCaption"},
						"classes": {"textClass": ["actions-button-margin-right"]},
						"click": {"bindTo": "onSetupSectionsButtonClick"},
						"visible": true
					},
					"index": 0
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
