define("WSColourOfField1Page", ["StructureExplorerUtilities", "ViewUtilities", "ConfigurationItemGenerator",
		 "LookupUtilities","WSEntitySchemaFilterProvider"], function(StructureExplorerUtilities, ViewUtilities, ConfigurationItemGenerator, LookupUtilities) {
	return {
		entitySchemaName: "WSColourOfField",
		attributes: {
			"WSFolder": {
				"dependencies": [
					{
						"columns": ["WSFolder"],
						"methodName": "checkFolder"
					}
				],
				lookupListConfig: {
                	filter: function() {
                		var filterGroup = Ext.create("BPMSoft.FilterGroup");
                        filterGroup.add("ManagerNameFilter", BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "ManagerName", "EntitySchemaManager")); 
                        filterGroup.add("ExtendParent", BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "ExtendParent", false)); 
                        return filterGroup;
                	}
                }
			},
			"checkColumn": {
				"dependencies": [
					{
						"columns": ["WSColumnCode","WSFolder", "WSContact", "WSSerializedFilter", "WSColorRuleType"],
						"methodName": "checkColumn"
					}
				]
			},
			"checkWSColorRuleType":{
				"dependencies": [
					{
						"columns": ["WSColorRuleType"],
						"methodName": "checkWSColorRuleType"
					}
				]
			},
			"WSColumn":{
				"dependencies": [
					{
						"columns": ["WSColumn"],
						"methodName": "checkWSColumn"
					}
				]
			},
			"WSContact":{
				"dependencies": [
					{
						"columns": ["WSContact"],
						"methodName": "checkWSContact"
					}
				]
			},
			"LookupList": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			"LookupVirtual": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"caption": {
					"bindTo": "lookupCaption"
				}
			},
			"checkColumns": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": true
			},
			"showColumns": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": true
			},
			"showPriorities": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},
		},
		modules: /**SCHEMA_MODULES*/{
			"FilterModule": {
				"moduleId": "WSColourOfField1Page_FilterEditModule",
				"moduleName": "FilterEditModule",
				"config": {}
			}
		}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		messages: {
			/**
			 * @message GetTypeSchemaName
			 * Указывает значения параметров
			 */
			"GetTypeSchemaName": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message StructureExplorerInfo
			 * Необходимо для работы StructureExplorerUtilities
			 */
			"StructureExplorerInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message ColumnSelected
			 * Необходимо для работы StructureExplorerUtilities
			 */
			"ColumnSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			
			GetFilterModuleConfig: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			OnFiltersChanged: {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			SetFilterModuleConfig: {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		methods: {
			onEntityInitialized: function() {
				this.callParent(arguments);
				if (this.get("WSFolder")){
					this.set("WSSchemaName", this.get("WSFolder").displayValue);
					this.set("WSSchemaId", this.get("WSFolder").value);
				} else {
					if (this.get("WSSchemaId") && this.get("WSSchemaName")){
						this.set("WSFolder", {value: this.get("WSSchemaId"), displayValue: this.get("WSSchemaName")});
					}
				}
				this.checkColumn();
				this.checkFolder(2);
				
				this.checkWSColumn(2);
				this.checkWSContact();
				this.checkWSColorRuleType();
				
				if (this.get("WSColumnCode")){
					this.set("lookupCaption",this.get("WSColumnCode"));
					this.set("WSReferenceSchemaName",this.get("WSColumnCode"))
				}
			},
			
			getFilterEditModuleId: function() {
				return this.modules.FilterModule.moduleId;
			},

			subscribeFilterModuleMessages: function() {
				var moduleId = this.getFilterEditModuleId();
				var $this = this;
				this.sandbox.subscribe("OnFiltersChanged", function(args) {
					$this.set("WSSerializedFilter", args.serializedFilter);
				}, this, [moduleId]);
				this.sandbox.subscribe("GetFilterModuleConfig", function() {
					var baseName = "BaseEntity";
					if (this.get("WSModuleName")){
						baseName = this.get("WSModuleName");
					}
					return {
						rootSchemaName: baseName,
						filters: this.get("WSSerializedFilter"),
						//actionsVisible: false,
						//useDcmMainRecord: false,
					};
				}, this, [moduleId]);
			},
			
			checkWSColorRuleType: function(){
				this.set("showColumns",false);
				this.set("showPriorities",true);
				if (this.get("WSColorRuleType")){
					if (this.get("WSColorRuleType").value == "a08d7efd-6ca5-4ba3-86bb-35d4ebd7e02e"){
						this.set("showColumns",true);
						this.set("showPriorities",false);
					}
				}
			},
			
			checkFolder: function(start){
				var $this = this;
				var module = this.get("WSFolder");
				//$this.set("WSSerializedFilter", "");
				if (module) {
					this.set("WSSchemaName", this.get("WSFolder").displayValue);
					this.set("WSSchemaId", this.get("WSFolder").value);
					if (start != 2){
						//this.set("WSName","");
						//this.set("WSName",this.get("WSFolder").displayValue);
					} else {
						this.subscribeFilterModuleMessages();
					}
					
					this.getSchemaName(module.value, function(moduleSchemaName) {
						$this.set("WSModuleName", moduleSchemaName);
						
						$this.sandbox.publish("SetFilterModuleConfig",{
							rootSchemaName: moduleSchemaName,
							filters: $this.get("WSSerializedFilter"),
						},[$this.getFilterEditModuleId()]);
					});
				} else {
					if (start != 2){
						//this.set("WSName","");
					} else {
						this.subscribeFilterModuleMessages();
					}
					$this.set("WSSerializedFilter", "");
					$this.sandbox.publish("SetFilterModuleConfig",{
						rootSchemaName: "BaseEntity",
					},[$this.getFilterEditModuleId()]);
				}
			},
			checkColumn: function(){
				if (this.get("WSFolder")){
					
					var columName = arguments[1];
					
					var $this = this;
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					    rootSchemaName: "WSColourOfField"
					});
					
					esq.addColumn("WSColumnCode");
					esq.addColumn("WSFolder");
					esq.addColumn("WSContact");
					
					if (this.get("WSContact")){
						esq.filters.add("WSContactFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSContact", this.get("WSContact").value));
					}
					if (this.get("WSRole")){
						esq.filters.add("WSRoleFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSRole", this.get("WSRole").value));
					}
					if (this.get("WSFolder")){
						esq.filters.add("WSFolderFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder", this.get("WSFolder").value));
					}
					if (this.get("WSColorRuleType")){
						esq.filters.add("WSColorRuleTypeFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColorRuleType", this.get("WSColorRuleType").value));
					}
					if (this.get("WSColumnCode")){
						esq.filters.add("WSColumnCodeFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColumnCode", this.get("WSColumnCode")));
					}
					esq.filters.add("WSSerializedFilterFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSSerializedFilter", this.get("WSSerializedFilter")));
					
					esq.getEntityCollection(function (result) {
					    if (!result.success) {
					        // обработка/логирование ошибки, например
					        console.log("Ошибка запроса данных");
					        return;
					    }
					    var count = 0;
					    result.collection.each(function(item) {
					    	if ($this.get("Id") != item.get("Id")){
					    		count++;
					    	}
						});
						
						if (count > 0){
							$this.set("checkColumns",true);
						} else{
							$this.set("checkColumns",false);
						}
						
					},this);
				}
			},
			checkWSColumn: function(start){
				if (!this.get("WSColumn")){
					this.set("WSColumnCode","");
					if (this.get("WSFolder") && (start !=2)){
						//this.set("WSName",this.get("WSFolder").displayValue);
					}
				} else {
					if (this.get("WSFolder") && (start !=2)){
						//this.set("WSName",this.get("WSFolder").displayValue + " - " + this.get("WSColumn"));
					}
				}
			},
			checkWSContact: function(start){
				if (!this.get("WSContact")){
					
					if (start !=2){
						if (this.get("WSFolder")){
							if (this.get("WSColumn")){
								//this.set("WSName",this.get("WSFolder").displayValue + " - " + this.get("WSColumn"));
							} else {
								//this.set("WSName",this.get("WSFolder").displayValue);
							}
						} else {
							if (this.get("WSColumn")){
								//this.set("WSName"," - " + this.get("WSColumn"));
							} else {
								//this.set("WSName","");
							}
						}
					}
				} else {
					if (start !=2){
						if (this.get("WSFolder")){
							if (this.get("WSColumn")){
								//this.set("WSName",this.get("WSFolder").displayValue + " - " + this.get("WSColumn") + " - " + this.get("WSContact").displayValue);
							} else {
								//this.set("WSName",this.get("WSFolder").displayValue);
							}
						} else {
							if (this.get("WSColumn")){
								this.set("WSName"," - " + this.get("WSColumn"));
							} else {
								//this.set("WSName","");
							}
						}
					}
				}
			},
			save: function(){
				if (this.get("checkColumns")){
					this.showInformationDialog(this.get("Resources.Strings.ColorValidErrorMessage"));
				} else {
					this.callParent(arguments);
				}
			},
			
			openStructureExplorer: function() {
				
				var config = {
					useBackwards: false,
					ExpandVisible: false,
					displayId: true,
					firstColumnsOnly: true,
					schemaName: this.get("WSModuleName")
				};
				var handler = this.structureExplorerHandler;
				StructureExplorerUtilities.Open(this.sandbox, config, handler, this.renderTo, this);
			},
			
			getSchemaName: function(recordId, callback) {
				var select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "SysSchema"
				});
				select.addColumn("Name");
				select.getEntity(recordId, function(result) {
					if (result) {
						var entity = result.entity;
						var code = entity.get("Name");
						callback.call(this, code);
					}
				});
			},
			
			/**
			 * Обработчик выбора StructureExplorer.
			 * Обновляет свойства viewModel согласно выбору в окне StructureExplorer.
			 * @param args {Object} Содержит результат работы пользователя.
			 */
			structureExplorerHandler: function(args) {
				console.log(args)
				var columnCaption = args.leftExpressionCaption;
				var columnPath = args.leftExpressionColumnPath;
				this.set("WSColumnCode",columnPath);
				this.set("WSColumn",columnCaption);
			},
			
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			
			{
				"operation": "insert",
				"name": "WSNamed5f25b43-4623-4a47-ab5b-c9f614a34df5",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "WSName"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "WSColorRuleType",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 9,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "WSColorRuleType"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WSActiveccedfec7-dc4b-4231-bc41-0509bae0fec1",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 17,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "WSActive"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WSContact4be102aa-adfe-48b1-a99b-da4a9e7e6f8d",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "WSContact"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "WSRoled06a5a14-113c-43de-83b8-ae35e8f5acc4",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 9,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "WSRole"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "WSPriority",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 17,
						"row": 1,
						"layoutName": "Header"
					},
					"visible":{"bindTo":"showPriorities"},
					"bindTo": "WSPriority"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "WSFoldera7ef87a3-acd5-4fda-9d19-b576e110058d",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "WSFolder"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "WSColumn25e4223f-482b-4a57-8bb1-a33a9be6148f",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 9,
						"row": 2,
						"layoutName": "Header"
					},
					"visible":{"bindTo":"showColumns"},
					"bindTo": "WSColumn",
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"rightIconClasses": [
							"custom-right-item",
							"lookup-edit-right-icon"
						],
						"rightIconClick": {
							"bindTo": "openStructureExplorer"
						}
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "WSColumnCode6985994a-5e46-468e-8af6-b12c9cdfbf16",
				"values": {
					"layout": {
						"colSpan": 7,
						"rowSpan": 1,
						"column": 17,
						"row": 2,
						"layoutName": "Header"
					},
					"visible":{"bindTo":"showColumns"},
					"bindTo": "WSColumnCode",
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "WSColorLabel",
				"values": {
					"layout": {
						"colSpan": 0,
						"rowSpan": 1,
						"column": 6,
						"row": 3
					},
					"itemType": 6,
					"caption": {
						"bindTo": "Resources.Strings.WSColorCaption"
					},
					"classes": {
						"labelClass": [
							"label-small"
						]
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "WSColor751ace99-ab5e-4338-8ccf-3b87f45855a6",
				"values": {
					"layout": {
						"colSpan": 4,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "Header"
					},
					"wrapClass": ["hidden"],
					"bindTo": "WSColor"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 11
			},
			{
				"operation": "insert",
				"name": "WSColorFontLabel",
				"values": {
					"layout": {
						"colSpan": 0,
						"rowSpan": 1,
						"column": 8,
						"row": 3
					},
					"itemType": 6,
					"caption": {
						"bindTo": "Resources.Strings.WSColorFontCaption"
					},
					"classes": {
						"labelClass": [
							"label-small"
						]
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "WSColorFont546b00b2-ddbe-47e2-8ea6-ea85decab25c",
				"values": {
					"layout": {
						"colSpan": 4,
						"rowSpan": 1,
						"column": 9,
						"row": 3,
						"layoutName": "Header"
					},
					"wrapClass": ["hidden"],
					"bindTo": "WSColorFont"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 12
			},
			{
				"operation": "insert",
				"name": "WSColora49b2d73-5f51-4f97-8700-b9ccc8558ed5",
				"values": {
					"layout": {
						"colSpan": 4,
						"rowSpan": 1,
						"column": 0,
						"row": 5,
						"layoutName": "Header"
					},
					"value": {
						"bindTo": "WSColor"
					},
					"itemType": 18
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 9
			},
			{
				"operation": "insert",
				"name": "WSColorFonted831cc7-c5f2-4c2e-8897-9282052a8538",
				"values": {
					"layout": {
						"colSpan": 4,
						"rowSpan": 1,
						"column": 9,
						"row": 5,
						"layoutName": "Header"
					},
					"value": {
						"bindTo": "WSColorFont"
					},
					"itemType": 18
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 10
			},
			{
				"operation": "insert",
				"name": "SettingsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.SettingsTabCaption"
					},
					"items": [],
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			
			{
				"operation": "insert",
				"name": "FilterReportSettingsControlGroup",
				"values": {
					"itemType": 15,
					"caption": {
						"bindTo": "Resources.Strings.FilterControlGroupCaption"
					},
					"items": [],
				},
				"parentName": "SettingsTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FilterReportSettingsGridLayout",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "FilterReportSettingsControlGroup",
				"propertyName": "items",
				"index": 0
			},
			
			{
				"operation": "insert",
				"name": "FilterModule",
				"values": {
					"id": "FilterModule",
					"itemType": 4,
					"items": [],
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
				},
				"parentName": "FilterReportSettingsGridLayout",
				"propertyName": "items",
				"index": 0
			},
		]/**SCHEMA_DIFF*/
	};
});
