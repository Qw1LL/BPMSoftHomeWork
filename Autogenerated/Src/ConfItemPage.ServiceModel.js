define("ConfItemPage", [],
	function() {
		return {
			entitySchemaName: "ConfItem",
			messages: {
				/**
				 * @message UpdateRelationshipDetail
				 * ######### ###### ############ ##
				 */
				"UpdateRelationshipDetail": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			details: /**SCHEMA_DETAILS*/{
				"ServiceItem": {
					"schemaName": "ServiceInConfItemDetail",
					"filterMethod": "getServiceItemDetailFilter",
					"defaultValues": {
						"ConfItem": {
							"masterColumn": "Id"
						}
					}
				},
				"ConfItemRelationship": {
					"schemaName": "ConfItemRelationshipDetail",
					"filterMethod": "getConfItemRelationshipDetailFilter",
					"defaultValues": {
						"ConfItemA": {
							"masterColumn": "Id"
						}
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "RelationshipTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.RelationshipTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "RelationshipControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"visible": false,
						"items": []
					},
					"parentName": "RelationshipTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ServiceItem",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "RelationshipTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "ConfItemRelationship",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "RelationshipTab",
					"propertyName": "items",
					"index": 2
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				/**
				 * ############# ## ####### ########## ######.
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("UpdateRelationshipDetail", this.onUpdateRelationshipDetail, this);
				},
				/**
				 * ######### ###### ## ########.
				 */
				onUpdateRelationshipDetail: function() {
					this.updateDetail({
						detail: "ConfItemRelationship"
					});
				},

				/**
				 * ####### ####### ###### ConfItemRelationship.
				 * @return {BPMSoft.createFilterGroup}
				 */
				getConfItemRelationshipDetailFilter: function() {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.add("ConfItemFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "ConfItemA", this.get("Id")));
					return filterGroup;
				},

				/**
				 * ####### ####### ###### ServiceItem.
				 * @return {BPMSoft.createFilterGroup}
				 */
				getServiceItemDetailFilter: function() {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.add("ConfItemFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "ConfItem", this.get("Id")));
					return filterGroup;
				},
				/**
				 * ########## ####### ## ######## "########## ###########".
				 * ### ####### ## ###### "########## ###########" ########### ######## ########### ###.
				 */
				openServiceModelModule: function() {
					var defaultValues = [{
						"id": this.getCurrentRecordId(),
						"schemaName": this.getEntitySchemaName(),
						"name": this.get("Name")
					}];
					this.openCardInChain({
						"schemaName": "ServiceModelPage",
						"moduleId": this.sandbox.id + "_ServiceModelPage",
						"isSeparateMode": false,
						"defaultValues": defaultValues
					});
				},
				/**
				 * ######### ######## # ###### ######## ## ######## ############## ############.
				 * @overridden
				 */
				getActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						"Tag": "openServiceModelModule",
						"Caption": this.get("Resources.Strings.OpenServiceModelModuleCaption"),
						"Enabled": !this.isNewMode()
					}));
					return actionMenuItems;
				}
			}
		};
	});
