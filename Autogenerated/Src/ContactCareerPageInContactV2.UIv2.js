define("ContactCareerPageInContactV2", ["css!ContactPageV2CSS"], function() {
	return {
		entitySchemaName: "ContactCareer",
		attributes: {
			"JobTitle": {
				name: "JobTitle",
				dataValueType: BPMSoft.DataValueType.TEXT,
				dependencies: [
					{
						columns: ["Job"],
						methodName: "onJobChange"
					}
				]
			},
			"DueDate": {
				name: "DueDate",
				dataValueType: BPMSoft.DataValueType.DATE,
				dependencies: [
					{
						columns: ["Current"],
						methodName: "onCurrentChange"
					}
				]
			}
		},
		methods: {

			/**
			 * ############# ######## ## #########
			 * @protected
			 * @overridden
			 */
			getDefaultValues: function() {
				var defValues = this.callParent(arguments);
				defValues.push({
					name: "Current",
					value: true
				},
				{
					name: "Primary",
					value: true
				});
				return defValues;
			},

			/**
			 * ############# ######## #### "###### ######## #########" ### ######### ######## #### "#########"
			 * @protected
			 * @virtual
			 */
			onJobChange: function() {
				var job = this.get("Job");
				if (!Ext.isEmpty(job)) {
					this.set("JobTitle", job.displayValue);
				}
			},

			/**
			 * ############# ######## #### "##########" ### ######### ######## #### "#######"
			 * @protected
			 * @virtual
			 */
			onCurrentChange: function() {
				var dueDate = this.get("Current") ? null : new Date();
				this.set("DueDate", dueDate);
			},

			/**
			 * ########## ######## ###### #############.
			 * #### ############ ############ ########, ####### ######### # ############# ########## #######.
			 * ##### ########## callback-#######.
			 * @protected
			 * @overridden
			 * @param {Function} callback callback-#######
			 * @param {BPMSoft.BaseSchemaViewModel} scope ######## ########## callback-#######
			 */
			asyncValidate: function(callback, scope) {
				this.callParent([function(result) {
					if (!result.success) {
						callback.call(scope, result);
						return;
					}
					var startDate = this.get("StartDate");
					var dueDate = this.get("DueDate");
					if (dueDate !== null) {
						if (startDate > dueDate) {
							this.showInformationDialog(this.get("Resources.Strings.WarningWrongDate"));
							this.hideBodyMask();
							return;
						}
					}
					callback.call(scope, result);
				}, this]);
			},

			/**
			 * ###### ###### # ##, ######### #### ## # ####### ######## #########
			 * # ########## "#######", "########" ##### ######
			 * @protected
			 * @virtual
			 * @param {String} contactId ############# ########
			 * @param {Function} callback callback-#######
			 * @param {Object} scope ######## ########## ####### callback
			 * @param {Object} result ##### #######
			 */
			getContactCareerCollection: function(contactId, callback, scope, result) {
				var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "ContactCareer"});
				select.addColumn("Id");
				select.addColumn("Contact");
				select.addColumn("Account");
				select.addColumn("Job");
				select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.NOT_EQUAL,
					"Id", this.get("Id")));
				select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Contact", contactId));
				select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Current", true));
				select.filters.addItem(select.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Primary", true));
				select.getEntityCollection(function(response) {
					this.onGetSelectResult(response, callback, scope, result);
				}, this);
			},

			/**
			 * ######## ####### # ########## ####### # ##,
			 * ######## #### ######### ### ####, ##### ######## ############
			 * ######## ## ######### ###### # ######### "#######" ##########
			 * @protected
			 * @virtual
			 * @param {Object} response ####### ########## # ########## #######
			 * @param {Function} callback callback-#######
			 * @param {Object} scope ######## ########## ####### callback
			 * @param {Object} result ##### #######
			 */
			onGetSelectResult: function(response, callback, scope, result) {
				var entityCollection = response.collection;
				var buttonsConfig = {
					buttons: [
						this.BPMSoft.MessageBoxButtons.YES.returnCode,
						this.BPMSoft.MessageBoxButtons.NO.returnCode
					],
					defaultButton: 0
				};
				if (entityCollection.getCount() > 0) {
					var message = this.get("Resources.Strings.ChangeContactJob");
					var oldContact = entityCollection.getItems()[0].get("Contact").displayValue;
					var oldAccount =  entityCollection.getItems()[0].get("Account").displayValue;
					var oldJob = entityCollection.getItems()[0].get("Job");
					var oldJobTitle = "";
					if (oldJob) {
						oldJobTitle = oldJob.displayValue;
					}
					this.showInformationDialog(Ext.String.format(message, oldContact, oldAccount, oldJobTitle),
							function(returnCode) {
								this.getSelectedButton(returnCode, callback, scope, result, entityCollection);
							}, buttonsConfig);
				} else {
					callback.call(scope, result);
				}
			},

			/**
			 * ######## ##### ############ ## ###### # #### #########
			 * @protected
			 * @virtual
			 * @param {String} returnCode ##### ############ ## ###### ## #### #########
			 * @param {Function} callback callback-#######
			 * @param {Object} scope ######## ########## ####### callback
			 * @param {Object} result ##### #######
			 * @param {Object} entityCollection ####### ########## # ########## #######
			 */
			getSelectedButton: function(returnCode, callback, scope, result, entityCollection) {
				if (returnCode === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.onAnswerYes(entityCollection, returnCode, callback, scope, result);
				} else {
					this.onAnswerNo(entityCollection, returnCode, callback, scope, result);
				}
			},

			/**
			 * ######### ######### ###### ###### (######),
			 * ############# ## ####### "#######" = "####",
			 * # ##### #### ##########
			 * @protected
			 * @virtual
			 * @param {Object} entityCollection ####### ########## # ########## #######
			 * @param {String} returnCode ##### ############ ## ###### ## #### #########
			 * @param {Function} callback callback-#######
			 * @param {Object} scope ######## ########## ####### callback
			 * @param {Object} result ##### #######
			 */
			onAnswerNo: function(entityCollection, returnCode, callback, scope, result) {
				var oldContactCareer = entityCollection.getItems()[0].get("Id");
				var update = Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "ContactCareer"
				});
				update.filters.add("ContactIdFilter",
						update.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id", oldContactCareer));
				update.setParameterValue("Current", false, this.BPMSoft.DataValueType.BOOLEAN);
				update.setParameterValue("DueDate", new Date(), this.BPMSoft.DataValueType.DATE);
				update.execute(function() {
					callback.call(scope, result);
				});
			},

			/**
			 * ######### ######### ###### ###### (######),
			 * ############# ## ####### "########" = "####"
			 * @protected
			 * @virtual
			 * @param {Object} entityCollection ####### ########## # ########## #######
			 * @param {String} returnCode ##### ############ ## ###### ## #### #########
			 * @param {Function} callback callback-#######
			 * @param {Object} scope ######## ########## ####### callback
			 * @param {Object} result ##### #######
			 */
			onAnswerYes: function(entityCollection, returnCode, callback, scope, result) {
				var oldContactCareer = entityCollection.getByIndex(0).get("Id");
				var update = Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "ContactCareer"
				});
				update.filters.addItem(update.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Id", oldContactCareer));
				update.setParameterValue("Primary", false, this.BPMSoft.DataValueType.BOOLEAN);
				update.execute(function() {
					callback.call(scope, result);
				});
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Contact",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Contact",
					"enabled": false,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "Account",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Account",
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "Primary",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Primary",
					"layout": {
						"column": 13,
						"row": 6,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"name": "Current",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Current",
					"layout": {
						"column": 18,
						"row": 6,
						"colSpan": 6
					}
				}
			},

			{
				"operation": "insert",
				"name": "Job",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Job",
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					},
					"contentType": BPMSoft.ContentType.ENUM
				}
			},
			{
				"operation": "insert",
				"name": "JobTitle",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "JobTitle",
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "Department",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Department",
					"contentType": BPMSoft.ContentType.ENUM,
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "DecisionRole",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "DecisionRole",
					"contentType": BPMSoft.ContentType.ENUM,
					"layout": {
						"column": 13,
						"row": 3,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "StartDate",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "StartDate",
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "DueDate",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "DueDate",
					"layout": {
						"column": 13,
						"row": 4,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "JobChangeReason",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "JobChangeReason",
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 11
					},
					"contentType": BPMSoft.ContentType.ENUM
				}
			},
			{
				"operation": "insert",
				"name": "Description",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"bindTo": "Description",
					"layout": {
						"column": 13,
						"row": 5,
						"colSpan": 11
					},
					"contentType": BPMSoft.ContentType.LONG_TEXT
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
