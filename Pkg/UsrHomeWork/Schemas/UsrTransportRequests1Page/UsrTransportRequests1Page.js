define("UsrTransportRequests1Page", ["UsrRequestNumberEditControl"], function() {
	return {
		entitySchemaName: "UsrTransportRequests",
		attributes: {
			"UsrDriver": {
				lookupListConfig: {
					columns: ["Account", "Phone", "MobilePhone",  "Email", "Name"]
				},
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				dependencies: [
					{
						columns: ["UsrDriver"],
						methodName: "onDriverChanged"
					},
					{
						columns: ["UsrStatus"],
						methodName: "onStatusChanged"
					},
				]
			},
			"AddTeamButtonVisible": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"caption": "AddTeamButtonVisible",
				"dependencies": [
					{
						"columns": ["UsrStatus", "UsrCompany"],
						"methodName": "setAddTeamButtonVisibleAttribute"
					}
				]
			}
		},
		modules: /**SCHEMA_MODULES*/{
			"DriverInformation": {
				"config": {
					"schemaName": "UsrDriverInformation",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false,
					"parameters": {
						"viewModelConfig": {
							MasterColumnName: "UsrDriver"
						}
					}
				}
			}
		}/**SCHEMA_MODULES*/,
		messages: {
			"UsrDiriverChangedMessage": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		details: /**SCHEMA_DETAILS*/{
			"Files": {
				"schemaName": "FileDetailV2",
				"entitySchemaName": "UsrTransportRequestsFile",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "UsrTransportRequests"
				}
			},
			"UsrSchema0170b3d9Detail1e778d9e": {
				"schemaName": "UsrSchema0170b3d9Detail",
				"entitySchemaName": "UsrTransportRequestTeam",
				"filter": {
					"detailColumn": "UsrTransportRequests",
					"masterColumn": "Id"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
				setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("UsrRequestNumber", this.requestNumberColumnValidator);
		},

			onEntityInitialized: function () {
				this.callParent(arguments);
				this.setAddTeamButtonVisibleAttribute();
			},

			setAddTeamButtonVisibleAttribute: function() {
					let status = this.get("UsrStatus")?.displayValue;
					let company = this.get("UsrCompany")?.displayValue;
					
					if (status == "В планах" && company) {
						this.set("AddTeamButtonVisible", true);
						this.publishPropertyValueToSection("AddTeamButtonVisible", true);
						return;
				}
					this.set("AddTeamButtonVisible", false);
					this.publishPropertyValueToSection("AddTeamButtonVisible", false);
			},
			
			requestNumberColumnValidator: function(value) {
				console.log(value);
				const regexStr = /^\d{4}-\d{2}-\d{2}-\d{2}$/;
				if (!regexStr.test(value)) {
					return {
					invalidMessage: "Некорректный формат номера заявки"
				};
				}
				return {
					invalidMessage: ""
				};
			},

			onDriverChanged: async function() {
				const driverId = this.get("UsrDriver")?.value;
				await this.getActivityCount(driverId).
				then(this.onActivityFinded.bind(this)).
				catch(this.onActivityError.bind(this));
			},

			onStatusChanged: async function() {
				 const insert = this.getAddActivityInsertQuery();
				 insert.execute();
			},

			getFindActivityEsq: function(driverId) {
				if (!driverId) {
					return;
				}
				const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "Activity"
				});
				esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
				esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Contact", driverId)
				);
				const filter = BPMSoft.createColumnInFilterWithParameters("Status", ["201cfba8-58e6-df11-971b-001d60e938c6", "4bdbb88f-58e6-df11-971b-001d60e938c6"]);
				filter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				esq.filters.addItem(filter);
				
				return esq;
			},

			getActivityCount: function(driverId) {
				if (driverId) {
					return new Promise((resolve, reject) => {
						const esq = this.getFindActivityEsq(driverId);
						esq.getEntityCollection(function (result) {
							if (!result.success) {
								reject(result);
								return;
							}
							const activityCount = result.collection.first().get("Count")
							resolve(activityCount);
						}, this);
					});
				}
			},

			onActivityFinded: function(activityCount) {
				if (activityCount > 3) {
					this.showInformationDialog("На данного водителя назначено более 3х задач");
				} else {
					const tag = this.getDriverInformationModuleSandboxId();
					const arg = {};
					this.sandbox.publish("UsrDiriverChangedMessage", arg, [tag]);
					const update = this.getUpdateActivityESQ();
					update.execute();
				}
			},
			onActivityError: function(result) {
				this.showInformationDialog(result?.errorInfo?.message ?? "Ошибка");
			},

			getAddActivityInsertQuery: function() {
				const insert = Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "Activity"
				});

				insert.setParameterValue("Owner", this.get("UsrOwner"), this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Contact", this.get("UsrDriver"), this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Account", this.get("UsrCompany"), this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Title", this.get("UsrName"), this.BPMSoft.DataValueType.TEXT);
				insert.setParameterValue("StartDate", new Date(), this.BPMSoft.DataValueType.DATE_TIME);
				insert.setParameterValue("DueDate", new Date(), this.BPMSoft.DataValueType.DATE_TIME);
				insert.setParameterValue("UsrTransportRequest", this.get("Id"), this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Status", "394d4b84-58e6-df11-971b-001d60e938c6", this.BPMSoft.DataValueType.GUID);

				return insert;
			},

			getUpdateActivityESQ: function() {
				const id = this.get("Id");
				const driver = this.get("UsrDriver").value;
				const update = Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "Activity"
				});
				update.filters.add("byId", update.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "UsrTransportRequest", id));

				update.setParameterValue("Contact", driver, BPMSoft.DataValueType.GUID);

				return update;
			},

			getDriverInformationModuleSandboxId: function () {
				return this.sandbox.id + "_module_DriverInformation";
			},

			onAddTeam: function() {
					window.alert("blabla");
			},
			
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AddTeam",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": "Добавить команду", // знаю, что есть ресурсы, не добавлял для ускорения выполненя задачи "bindTo": "Resources.Strings.blabla
					"click": { "bindTo": "onAddTeam" }, 
					"visible": { "bindTo": "AddTeamButtonVisible" },
					"classes": { "textClass": ["actions-button-margin-right"] }
				}
			},
			{
				"operation": "insert",
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"name": "DriverInformation",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "UsrNamee24b5889-4392-43d6-92c6-4da4eb14b0fb",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "UsrName"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UsrRequestNumber16f962cf-fc60-4a10-bc02-b5c8c4ceea93",
				"values": {
					"className": "BPMSoft.UsrRequestNumberEditControl",
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "UsrRequestNumber"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UsrStatusf6b68ce8-08ee-43b5-b4b8-badb38226c9f",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "UsrStatus"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UsrDescriptiona8eb73f0-5eeb-4cc6-a3e6-39c7696a8730",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "UsrDescription"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UsrDeliveryAddress985fa067-6904-4b52-8ea4-09a2a2106c6e",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 11,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "UsrDeliveryAddress"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UsrCar2649684a-59e8-44e4-bbad-2da72eb3d31b",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "UsrCar",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UsrDrivercd45b981-061d-4ec2-883d-ceb2c3573cec",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 11,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "UsrDriver"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "UsrOwner3f0d893f-ba4e-4862-8848-ccf26c1441c7",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "UsrOwner"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "UsrCompany05efea84-8978-4180-aa21-da5e9dd6cb28",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 11,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "UsrCompany"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 0
				}
			},
			{
				"operation": "insert",
				"name": "UsrSchema12567df0Detail28fda340",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "ESNTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UsrSchema0170b3d9Detail1e778d9e",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "ESNTab",
				"propertyName": "items",
				"index": 2
			}
		]/**SCHEMA_DIFF*/
	};
});
