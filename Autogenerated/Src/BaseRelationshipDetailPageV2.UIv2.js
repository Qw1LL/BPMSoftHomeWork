define("BaseRelationshipDetailPageV2", [], function() {
	return {
		entitySchemaName: "Relationship",
		attributes: {
			"RelationType": {
				lookupListConfig: {
					filter: function() {
						var relationTypeFilterName = this.getRelType(false);
						return this.getFilterByRelationTypeFilterName(relationTypeFilterName);
					}
				},
				dependencies: [{
					columns: ["ReverseRelationType"],
					methodName: "setRelationTypeByReverseRelationType"
				}]
			},
			"ReverseRelationType": {
				lookupListConfig: {
					filter: function() {
						var relationTypeFilterName = this.getRelType(true);
						return this.getFilterByRelationTypeFilterName(relationTypeFilterName, "ReverseRelationType");
					}
				},
				dependencies: [{
					columns: ["RelationType"],
					methodName: "setReverseRelationTypeByRelationType"
				}]
			},
			"RelationTypeFilter": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			"AccountA": {
				lookupListConfig: {
					columns: ["Parent"]
				}
			},
			"AccountB": {
				lookupListConfig: {
					columns: ["Parent"],
					filter: function() {
						var accountA = this.get("AccountA");
						return this.getFilterByRelationColumn(accountA, "Account");
					}
				}
			},
			"ContactB": {
				lookupListConfig: {
					filter: function() {
						var contactA = this.get("ContactA");
						return this.getFilterByRelationColumn(contactA);
					}
				}
			}
		},
		columns: {
			"Mode": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				name: "Mode"
			}
		},
		details: /**SCHEMA_DETAILS*/ {} /**SCHEMA_DETAILS*/ ,
		messages: {
			"GetAddMode": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"GetMasterRecordId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * #####, ############## ##### ############# #######
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.initParentAccountRelationType();
				this.getAddMode();
				this.getMasterRecordId();
				this.initIfAIsPrimary();
				this.setRelationTypeFilterByColumn();
				if (!Ext.isEmpty(this.get("Mode"))) {
					this.set("Active", true);
				}
				if (this.get("RelationTypeFilter") === "Account") {
					this.addColumnValidator("AccountB", this.validateEmptyFieldB);
				}
				if (this.get("RelationTypeFilter") === "Contact") {
					this.addColumnValidator("ContactB", this.validateEmptyFieldB);
				}
			},

			/**
			 * ######### ##### ############ ########/######## ##########
			 */
			initParentAccountRelationType: function() {
				this.BPMSoft.SysSettings.querySysSettings(["ParentAccountRelationType"], function(values) {
					this.set("ParentAccountRelationType", values.ParentAccountRelationType);
					if (values.ParentAccountRelationType) {
						this.setRelationType(values.ParentAccountRelationType.value, "ChildAccountRelationType", this);
					}
				}, this);
			},

			/**
			 * Checks mandatory field while saving.
			 * @param {Object} value Db field value.
			 * @return {Object} Message.
			 */
			validateEmptyFieldB: function(value) {
				var message = "";
				if (!value) {
					message = this.get("Resources.Strings.RequiredFieldIsEmptyMessage");
				}
				return {
					invalidMessage: message
				};
			},

			/**
			 * ############ ########## ########
			 * @override
			 * @protected
			 */
			save: function() {
				if (this.validate()) {
					this.callParent(arguments);
				}
			},

			/**
			 * #####, ########## ## ######### ######### ###########
			 * @private
			 * @return {Boolean}
			 */
			getAccountVisibility: function() {
				return !Ext.isEmpty(this.get("AccountA"));
			},

			/**
			 * ######### ###### ########## ######
			 * @private
			 */
			getAddMode: function() {
				var mode = this.sandbox.publish("GetAddMode", null, [this.sandbox.id]);
				if (mode) {
					this.set("Mode", mode);
				}
			},

			/**
			 * ######### ###### ########## ######
			 * @private
			 */
			initIfAIsPrimary: function() {
				var mode = this.get("Mode");
				if (mode) {
					this.set("AIsPrimary", true);
				} else {
					var masterRecordId = this.get("MasterRecordId");
					if (this.getAccountVisibility()) {
						if (this.get("AccountA").value === masterRecordId) {
							this.set("AIsPrimary", true);
						} else {
							this.set("AIsPrimary", false);
						}
					} else {
						if (this.get("ContactA").value === masterRecordId) {
							this.set("AIsPrimary", true);
						} else {
							this.set("AIsPrimary", false);
						}
					}
				}
			},

			/**
			 * #####, ########## ## ######### ######### ###########
			 * @private
			 * @return {Boolean}
			 */
			getMainAccountPrimaryVisibility: function() {
				return !Ext.isEmpty(this.get("AccountA")) && this.getIfAIsPrimary();
			},

			/**
			 * #####, ########## ## ######### ######### ########
			 * @private
			 * @return {Boolean}
			 */
			getMainContactPrimaryVisibility: function() {
				return !Ext.isEmpty(this.get("ContactA")) && this.getIfAIsPrimary();
			},

			/**
			 * #####, ########## ## ######### ########## ########
			 * @private
			 * @return {Boolean}
			 */
			getRelatedContactPrimaryVisibility: function() {
				return (this.get("Mode") === "AddContact" ||
					this.get("RelationTypeFilter") === "Contact") && this.getIfAIsPrimary();
			},

			/**
			 * #####, ########## ## ######### ########## ###########
			 * @private
			 * @return {Boolean}
			 */
			getRelatedAccountPrimaryVisibility: function() {
				return (this.get("Mode") === "AddAccount" ||
					this.get("RelationTypeFilter") === "Account") && this.getIfAIsPrimary();
			},

			/**
			 * #####, ########## ## ######### ######### ###########
			 * @private
			 * @return {Boolean}
			 */
			getMainAccountSecondaryVisibility: function() {
				return !Ext.isEmpty(this.get("AccountB")) && !this.getIfAIsPrimary();
			},

			/**
			 * #####, ########## ## ######### ######### ########
			 * @private
			 * @return {Boolean}
			 */
			getMainContactSecondaryVisibility: function() {
				return !Ext.isEmpty(this.get("ContactB")) && !this.getIfAIsPrimary();
			},

			/**
			 * #####, ########## ## ######### ########## ########
			 * @private
			 * @return {Boolean}
			 */
			getRelatedContactSecondaryVisibility: function() {
				return (this.get("Mode") === "AddContact" || this.get("ContactA")) && this.getIfBIsPrimary();
			},

			/**
			 * Returns secondary related account container visibility.
			 * @private
			 * @return {Boolean}
			 */
			getRelatedAccountSecondaryVisibility: function() {
				var accountA = this.get("AccountA");
				var accountB = this.get("AccountB");
				return Boolean((this.get("Mode") === "AddAccount" || accountA || accountB)
						&& this.getIfBIsPrimary());
			},

			/**
			 * ######### ###### ########## ######
			 * @private
			 * @return {Boolean}
			 */
			getIfAIsPrimary: function() {
				return this.get("AIsPrimary");
			},

			/**
			 * ######### ###### ########## ######
			 * @private
			 * @return {Boolean}
			 */
			getIfBIsPrimary: function() {
				return !this.get("AIsPrimary");
			},

			/**
			 * ######### Id ###### ######### #######
			 * @private
			 */
			getMasterRecordId: function() {
				var recordId = this.sandbox.publish("GetMasterRecordId", null, [this.sandbox.id]);
				if (recordId) {
					this.set("MasterRecordId", recordId);
				}
			},

			/**
			 * ######### ######### ########
			 * @return {*}
			 */
			getHeader: function() {
				return this.get("Resources.Strings.PageCaption");
			},

			/**
			 * ######### ######## ####### #### ########### ########
			 * @private
			 */
			getRelType: function(reverse) {
				var relType = this.get("RelationTypeFilter");
				var result = "For";
				if (!reverse) {
					if (!Ext.isEmpty(relType)) {
						if (this.get("AccountA")) {
							result = result + "Account" + relType;
						}
						if (this.get("ContactA")) {
							result = result + "Contact" + relType;
						}
					}
				} else {
					if (!Ext.isEmpty(relType)) {
						if (this.get("AccountA")) {
							result = result + relType + "Account";
						}
						if (this.get("ContactA")) {
							result = result + relType + "Contact";
						}
					}
				}
				return result;
			},

			/**
			 * ##### ######### ######## # ########### ####### "RelationTypeFilter"
			 * @private
			 */
			setRelationTypeFilterByColumn: function() {
				var relType = this.get("RelationTypeFilter");
				if (Ext.isEmpty(relType)) {
					if (this.get("AccountB") || this.get("Mode") === "AddAccount") {
						this.set("RelationTypeFilter", "Account");
					}
					if (this.get("ContactB") || this.get("Mode") === "AddContact") {
						this.set("RelationTypeFilter", "Contact");
					}
				}
			},

			/**
			 * Sets relation type to target view model column.
			 * @private
			 * @param {*} result Query result.
			 * @param {*} columnName Target view model column name.
			 */
			_setRelationTypeCallback: function(result, columnName) {
				if (!result || !result.success) {
					return;
				}
				var item = result.entity;
				if (!item) {
					return;
				}
				var reverseRelationType = {
					displayValue: item.get("ReverseRelationType.Name"),
					value: item.get("ReverseRelationType.Id")
				};
				var currentValue = this.get(columnName);
				if ((Ext.isEmpty(currentValue) || 
						currentValue.displayValue !== reverseRelationType.displayValue)) {
					this.set(columnName, reverseRelationType);
				}
			},

			/**
			 * Method gets and sets feedback objects.
			 * @private
			 * @param {String} relationTypeId Relation id.
			 * @param {String} columnName Name of column in wich will be set feedback.
			 * @param {Object} scope Context in which the method is performed.
			 */
			setRelationType: function(relationTypeId, columnName, scope) {
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "RelationType"
				});
				esq.addColumn("Id");
				esq.addColumn("Name");
				esq.addColumn("ReverseRelationType.Id");
				esq.addColumn("ReverseRelationType.Name");
				esq.getEntity(relationTypeId, function(result) {
					this._setRelationTypeCallback(result, columnName);
				}, scope);
			},

			/**
			 * Returns relation filter by column name. 
			 * @private
			 * @param {String} targetColumnName Relation type column name for check.
			 */
			_getRelationFilter: function(targetColumnName) {
				var isReverse = targetColumnName === "ReverseRelationType";
				var relationFilterName = this.getRelType(isReverse);
				return this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					relationFilterName,
					true);
			},

			/**
			* Returns relation type filter. 
			* @private
			* @param {Object} relationType Relation type column value.
			* @param {Object} reverseRelationType Reverse relation type column value.
			*/
			_getRelationTypeFilter: function(relationType, reverseRelationType) {
				var filterGroup = this.BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"Id",
					relationType.value));
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"ReverseRelationType",
					reverseRelationType.value));
				return filterGroup;
			},

			/**
			* Returns reverse relation type filter. 
			* @private
			* @param {Object} relationType Relation type column value.
			* @param {Object} reverseRelationType Reverse relation type column value.
			*/
			_getReverseRelationTypeFilter: function(relationType, reverseRelationType) {
				var filterGroup = this.BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"Id",
					reverseRelationType.value));
				filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL,
					"ReverseRelationType",
					relationType.value));
				return filterGroup;
			},

			/**
			 * Checks if need change relation type by target view model column.
			 * @private
			 * @param {String} targetColumnName Target view model column.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			_needChangeRelationType: function(targetColumnName, callback, scope) {
				var reverseRelationType = this.get("ReverseRelationType");
				var relationType = this.get("RelationType");
				if (this.Ext.isEmpty(reverseRelationType) || this.Ext.isEmpty(relationType)) {
					this.Ext.callback(callback, scope, [true]);
					return;
				}
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "RelationType"
				});
				esq.addColumn("Id");
				esq.filters.addItem(this._getRelationFilter(targetColumnName));
				var mainFilterGroup = esq.createFilterGroup();
				mainFilterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
				mainFilterGroup.addItem(this._getRelationTypeFilter(relationType, reverseRelationType));
				mainFilterGroup.addItem(this._getReverseRelationTypeFilter(relationType, reverseRelationType));
				esq.filters.addItem(mainFilterGroup);
				esq.getEntityCollection(function(result) {
					if (result && result.success) {
						var collection = result.collection;
						var canChange = collection.isEmpty();
						this.Ext.callback(callback, scope, [canChange]);
					}
				}, this);
			},

			/**
			 * ##### ######### ######## # ####### "### ###########"
			 * @private
			 */
			setRelationTypeByReverseRelationType: function() {
				var reverseRelationType = this.get("ReverseRelationType");
				if (reverseRelationType) {
					this._needChangeRelationType("RelationType", function(result) {
						if (result === true) {
							this.setRelationType(reverseRelationType.value, "RelationType", this);
						}
					}, this);
				} else {
					this.set("RelationType", null);
				}
			},

			/**
			 * ##### ######### ######## # ####### "######## ### ###########"
			 * @private
			 */
			setReverseRelationTypeByRelationType: function() {
				var relationType = this.get("RelationType");
				if (relationType) {
					this._needChangeRelationType("ReverseRelationType", function(result) {
						if (result === true) {
							this.setRelationType(relationType.value, "ReverseRelationType", this);
						}
					}, this);
				} else {
					this.set("ReverseRelationType", null);
				}
			},

			/**
			 * Getting filter by interconnection type.
			 * @param {String} relationModeName Relationship mode Account-Account, Account-Contact and other.
			 * @param {String} columnName Column name.
			 * @return {Object} Main filter group.
			 * @private
			 */
			getFilterByRelationTypeFilterName: function(relationModeName, columnName) {
				var mainFilterGroup = this.Ext.create("BPMSoft.FilterGroup");
				var ext = this.Ext;
				if (!ext.isEmpty(relationModeName)) {
					var leftExpression = relationModeName;
					mainFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						leftExpression,
						true));
				}
				if (this.isAddMode() && relationModeName === "ForAccountAccount") {
					var accountA = this.get("AccountA");
					var accountB = this.get("AccountB");
					var parentAccountA = ext.isEmpty(accountA) ? null : accountA.Parent;
					var parentAccountB = ext.isEmpty(accountB) ? null : accountB.Parent;
					var parentAccountRelationType = this.get("ParentAccountRelationType");
					var childAccountRelationType = this.get("ChildAccountRelationType");
					if (!ext.isEmpty(parentAccountRelationType) && !ext.isEmpty(childAccountRelationType)) {
						var excludedIds = [];
						if (!ext.isEmpty(parentAccountA) && columnName !== "ReverseRelationType") {
							excludedIds = [childAccountRelationType.value];
						} else {
							if (!ext.isEmpty(parentAccountB)) {
								if (columnName === "ReverseRelationType") {
									excludedIds = [childAccountRelationType.value];
								} else {
									excludedIds = [parentAccountRelationType.value];
								}
							}
						}
						var excludedFilters = this.BPMSoft.createColumnInFilterWithParameters(
							"Id",
							excludedIds);
						excludedFilters.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
						mainFilterGroup.addItem(excludedFilters);
					}
				}
				return mainFilterGroup;
			},

			/**
			 * Gets filter by relationship column.
			 * @param {Object} columnValue Column value.
			 * @param {String} columnName Column name.
			 * @return {Object} Main filter group.
			 * @private
			 */
			getFilterByRelationColumn: function(columnValue, columnName) {
				var ext = this.Ext;
				var mainFilterGroup = ext.create("BPMSoft.FilterGroup");
				if (columnValue) {
					mainFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.NOT_EQUAL,
						"Id",
						columnValue.value));
					if (this.isAddMode() && columnName === "Account") {
						var account = this.get("AccountA");
						var parent = ext.isEmpty(account) ? null : account.Parent;
						var relationType = this.get("RelationType");
						var parentAccountRelationType = this.get("ParentAccountRelationType");
						var childAccountRelationType = this.get("ChildAccountRelationType");
						var isParentAccountRelationType = !ext.isEmpty(relationType) &&
							!ext.isEmpty(parentAccountRelationType) &&
							relationType.value === parentAccountRelationType.value;
						var isChildAccountRelationType = !ext.isEmpty(relationType) &&
							!ext.isEmpty(childAccountRelationType) &&
							relationType.value === childAccountRelationType.value;
						if (isParentAccountRelationType) {
							mainFilterGroup.addItem(this.BPMSoft.createColumnIsNullFilter("Parent"));
						} else {
							if (isChildAccountRelationType && !ext.isEmpty(parent)) {
								mainFilterGroup.addItem(this.BPMSoft.createColumnIsNotNullFilter("Parent"));
							}
						}
					}
				}
				return mainFilterGroup;
			}
		},
		diff: /**SCHEMA_DIFF*/ [{
				"operation": "merge",
				"propertyName": "items",
				"name": "Tabs",
				"values": {
					"visible": false
				}
			}, {
				"operation": "merge",
				"propertyName": "items",
				"name": "actions",
				"values": {
					"visible": false
				}
			},

			////////////////////////////////////////////////////////////////
			/////////////////////STRAIGHT RELATION ROW//////////////////////
			////////////////////////////START///////////////////////////////
			{
				"operation": "insert",
				"parentName": "Header",
				"name": "AContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					}
				}
			}, {
				"operation": "insert",
				"parentName": "Header",
				"name": "RelatedObjectsAContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			}, {
				"operation": "insert",
				"parentName": "Header",
				"name": "StraightRelationTypeContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			//ContactA/AccountA- ########, ContactB/AccountB- ########(PRIMARY)
			{
				"operation": "insert",
				"parentName": "AContainer",
				"propertyName": "items",
				"name": "MainAccountPrimary",
				"values": {
					"bindTo": "AccountA",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryAccountCaption"
					},
					"visible": {
						"bindTo": "getMainAccountPrimaryVisibility"
					},
					"enabled": false
				}
			}, {
				"operation": "insert",
				"parentName": "AContainer",
				"propertyName": "items",
				"name": "MainContactPrimary",
				"values": {
					"bindTo": "ContactA",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryContactCaption"
					},
					"visible": {
						"bindTo": "getMainContactPrimaryVisibility"
					},
					"enabled": false
				}
			}, {
				"operation": "insert",
				"parentName": "StraightRelationTypeContainer",
				"propertyName": "items",
				"name": "RelationTypePrimary",
				"values": {
					"bindTo": "RelationType",
					"caption": {
						"bindTo": "Resources.Strings.RelationTypeCaption"
					},
					"visible": {
						"bindTo": "getIfAIsPrimary"
					},
					"contentType": "BPMSoft.ContentType.ENUM",
					"isRequired": true
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsAContainer",
				"propertyName": "items",
				"name": "RelatedAccountPrimary",
				"values": {
					"bindTo": "AccountB",
					"caption": {
						"bindTo": "Resources.Strings.RelatedAccountCaption"
					},
					"visible": {
						"bindTo": "getRelatedAccountPrimaryVisibility"
					},
					"isRequired": {
						"bindTo": "getRelatedAccountPrimaryVisibility"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsAContainer",
				"propertyName": "items",
				"name": "RelatedContactPrimary",
				"values": {
					"bindTo": "ContactB",
					"caption": {
						"bindTo": "Resources.Strings.RelatedContactCaption"
					},
					"visible": {
						"bindTo": "getRelatedContactPrimaryVisibility"
					},
					"isRequired": {
						"bindTo": "getRelatedContactPrimaryVisibility"
					}
				}
			},
			//ContactB/AccountB- ########,ContactA/AccountA- ######## (SECONDARY)
			{
				"operation": "insert",
				"parentName": "AContainer",
				"propertyName": "items",
				"name": "MainAccountSecondary",
				"values": {
					"bindTo": "AccountB",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryAccountCaption"
					},
					"visible": {
						"bindTo": "getMainAccountSecondaryVisibility"
					},
					"enabled": false
				}
			}, {
				"operation": "insert",
				"parentName": "AContainer",
				"propertyName": "items",
				"name": "MainContactSecondary",
				"values": {
					"bindTo": "ContactB",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryContactCaption"
					},
					"visible": {
						"bindTo": "getMainContactSecondaryVisibility"
					},
					"enabled": false
				}
			}, {
				"operation": "insert",
				"parentName": "StraightRelationTypeContainer",
				"propertyName": "items",
				"name": "RelationTypeSecondary",
				"values": {
					"bindTo": "ReverseRelationType",
					"caption": {
						"bindTo": "Resources.Strings.RelationTypeCaption"
					},
					"layout": {
						"column": 8,
						"row": 0,
						"colSpan": 8
					},
					"visible": {
						"bindTo": "getIfBIsPrimary"
					},
					"contentType": "BPMSoft.ContentType.ENUM",
					"isRequired": true
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsAContainer",
				"propertyName": "items",
				"name": "RelatedAccountSecondary",
				"values": {
					"bindTo": "AccountA",
					"caption": {
						"bindTo": "Resources.Strings.RelatedAccountCaption"
					},
					"visible": {
						"bindTo": "getRelatedAccountSecondaryVisibility"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsAContainer",
				"propertyName": "items",
				"name": "RelatedContactSecondary",
				"values": {
					"bindTo": "ContactA",
					"caption": {
						"bindTo": "Resources.Strings.RelatedContactCaption"
					},
					"visible": {
						"bindTo": "getRelatedContactSecondaryVisibility"
					}
				}
			},
			////////////////////////////////////////////////////////////////
			/////////////////////STRAIGHT RELATION ROW//////////////////////
			///////////////////////////FINISH///////////////////////////////

			///////////////////////////////////////////////////////////////
			/////////////////////REVERSE RELATION ROW//////////////////////
			////////////////////////////START//////////////////////////////
			{
				"operation": "insert",
				"parentName": "Header",
				"name": "BContainer",
				"propertyName": "items",
				"values": {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					}
				}
			}, {
				"operation": "insert",
				"parentName": "Header",
				"name": "ReverseRelationTypeContainer",
				"propertyName": "items",
				"values": {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11
					}
				}
			}, {
				"operation": "insert",
				"parentName": "Header",
				"name": "RelatedObjectsBContainer",
				"propertyName": "items",
				"values": {
					itemType: BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			//ContactA/AccountA- ########, ContactB/AccountB- ########(PRIMARY)
			{
				"operation": "insert",
				"parentName": "BContainer",
				"propertyName": "items",
				"name": "ReverseAccountPrimary",
				"values": {
					"bindTo": "AccountB",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryAccountCaption"
					},
					"visible": {
						"bindTo": "getRelatedAccountPrimaryVisibility"
					},
					"isRequired": {
						"bindTo": "getRelatedAccountPrimaryVisibility"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "BContainer",
				"propertyName": "items",
				"name": "ReverseContactPrimary",
				"values": {
					"bindTo": "ContactB",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryContactCaption"
					},
					"visible": {
						"bindTo": "getRelatedContactPrimaryVisibility"
					},
					"isRequired": {
						"bindTo": "getRelatedContactPrimaryVisibility"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "ReverseRelationTypeContainer",
				"propertyName": "items",
				"name": "ReverseRelationTypePrimary",
				"values": {
					"bindTo": "ReverseRelationType",
					"caption": {
						"bindTo": "Resources.Strings.RelationTypeCaption"
					},
					"visible": {
						"bindTo": "getIfAIsPrimary"
					},
					"contentType": "BPMSoft.ContentType.ENUM",
					"isRequired": true
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsBContainer",
				"propertyName": "items",
				"name": "ReverseRelatedAccountPrimary",
				"values": {
					"bindTo": "AccountA",
					"caption": {
						"bindTo": "Resources.Strings.RelatedAccountCaption"
					},
					"visible": {
						"bindTo": "getMainAccountPrimaryVisibility"
					},
					"enabled": false
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsBContainer",
				"propertyName": "items",
				"name": "ReverseRelatedContactPrimary",
				"values": {
					"bindTo": "ContactA",
					"caption": {
						"bindTo": "Resources.Strings.RelatedContactCaption"
					},
					"visible": {
						"bindTo": "getMainContactPrimaryVisibility"
					},
					"enabled": false
				}
			},
			//ContactB/Account- ########, ContactB/AccountB- ########(SECONDARY)
			{
				"operation": "insert",
				"parentName": "BContainer",
				"propertyName": "items",
				"name": "ReverseAccountSecondary",
				"values": {
					"bindTo": "AccountA",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryAccountCaption"
					},
					"visible": {
						"bindTo": "getRelatedAccountSecondaryVisibility"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "BContainer",
				"propertyName": "items",
				"name": "ReverseContactSecondary",
				"values": {
					"bindTo": "ContactA",
					"caption": {
						"bindTo": "Resources.Strings.PrimaryContactCaption"
					},
					"visible": {
						"bindTo": "getRelatedContactSecondaryVisibility"
					}
				}
			}, {
				"operation": "insert",
				"parentName": "ReverseRelationTypeContainer",
				"propertyName": "items",
				"name": "ReverseRelationTypeSecondary",
				"values": {
					"bindTo": "RelationType",
					"caption": {
						"bindTo": "Resources.Strings.RelationTypeCaption"
					},
					"layout": {
						"column": 8,
						"row": 1,
						"colSpan": 8
					},
					"visible": {
						"bindTo": "getIfBIsPrimary"
					},
					"contentType": "BPMSoft.ContentType.ENUM",
					"isRequired": true
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsBContainer",
				"propertyName": "items",
				"name": "ReverseRelatedAccountSecondary",
				"values": {
					"bindTo": "AccountB",
					"caption": {
						"bindTo": "Resources.Strings.RelatedAccountCaption"
					},
					"visible": {
						"bindTo": "getMainAccountSecondaryVisibility"
					},
					"enabled": false
				}
			}, {
				"operation": "insert",
				"parentName": "RelatedObjectsBContainer",
				"propertyName": "items",
				"name": "ReverseRelatedContactSecondary",
				"values": {
					"bindTo": "ContactB",
					"caption": {
						"bindTo": "Resources.Strings.RelatedContactCaption"
					},
					"visible": {
						"bindTo": "getMainContactSecondaryVisibility"
					},
					"enabled": false
				}
			},
			///////////////////////////////////////////////////////////////
			/////////////////////REVERSE RELATION ROW//////////////////////
			///////////////////////////FINISH///////////////////////////////
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Active",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 11
					}
				}
			}, {
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Description",
				"values": {
					"contentType": this.BPMSoft.ContentType.LONG_TEXT,
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 24
					}
				}
			}
		] /**SCHEMA_DIFF*/ ,
		rules: {},
		userCode: {}
	};
});
