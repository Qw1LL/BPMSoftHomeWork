define("EscalationEditPage", ["ServiceDeskConstants", "BaseFiltersGenerateModule", "EscalationEditPageResources",
		"css!RecommendationModule"],
	function(ServiceDeskConstants, BaseFiltersGenerateModule, resources) {
		return {
			entitySchemaName: "Case",
			messages: {
				/**
				 * @message SetParametersInfo
				 * Set escalation parameters info to CasePageV2
				 */
				"SetParametersInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Owner column value.
				 */
				"Owner": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						hideActions: true,
						filter: BaseFiltersGenerateModule.OwnerFilter
					}
				},
				/**
				 * Group column value.
				 */
				"Group": {
					lookupListConfig: {
						hideActions: true,
						filter: function() {
							return this.BPMSoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue", [
								ServiceDeskConstants.SysAdminUnitType.Organization.Value,
								ServiceDeskConstants.SysAdminUnitType.Division.Value,
								ServiceDeskConstants.SysAdminUnitType.Managers.Value,
								ServiceDeskConstants.SysAdminUnitType.Team.Value
							]);
						}
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#getPageHeaderCaption
				 * @overridden
				 */
				getPageHeaderCaption: function() {
					return resources.localizableStrings.CaseEscalationCaption;
				},
				/**
				 * Check whether filled with at least one of the fields "Contact" or "Counterparty".
				 * @param {Function} callback The callback function.
				 * @param {Object} scope Execution scope.
				 */
				validateOwnerOrGroupFilling: function() {
					var owner = this.get("Owner");
					var group = this.get("Group");
					var result = "";
					if (this.Ext.isEmpty(owner) && this.Ext.isEmpty(group)) {
						var ownerColumnCaption = this.getColumnByName("Owner").caption;
						var groupColumnCaption = this.getColumnByName("Group").caption;
						result = this.Ext.String.format(
							this.get("Resources.Strings.WarningOwnerGroupRequire"),
							ownerColumnCaption, groupColumnCaption);
					}
					return result;
				},
				/**
				 * Processing clicking Escalate
				 * @private
				 */
				save: function() {
					var validationMessage = this.validateOwnerOrGroupFilling();
					if (!this.Ext.isEmpty(validationMessage)) {
						this.showInformationDialog(validationMessage);
						return;
					}
					var escalationProperties = {
						SupportLevel: this.get("SupportLevel"),
						Group: this.get("Group"),
						Owner: this.get("Owner")
					};
					this.sandbox.publish("SetParametersInfo", escalationProperties, [this.sandbox.id]);
					this.onCloseCardButtonClick();
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "insert",
					"name": "OwnerGroupRequireLabel",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"labelClass": ["t-label information recommendation owner-group-require-label"],
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.WarningOwnerGroupRequire"
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
					"name": "SupportLevel",
					"values": {
						"bindTo": "SupportLevel",
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24,
							"rowSpan": 1
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Group",
					"values": {
						"bindTo": "Group",
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24,
							"rowSpan": 1
						}
					},
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareGroup"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"bindTo": "Owner",
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 1
						}
					},
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareOwner"
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});
