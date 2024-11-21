define("WSPattern1Page", ["StructureExplorerUtilities", "ViewUtilities", "ConfigurationItemGenerator",
		 "LookupUtilities", "WSEntitySchemaFilterProvider"], function(StructureExplorerUtilities, ViewUtilities, ConfigurationItemGenerator, LookupUtilities) {
	return {
		entitySchemaName: "WSPattern",
		attributes: {
			"checkColumn": {
				"dependencies": [
					{
						"columns": ["WSColumnCode","WSFolder","WSLookupCode","WSLookupValue", "WSLookup","WSSerializedFilter"],
						"methodName": "checkColumn"
					}
				]
			},
			
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
			"WSLookupValue":{
				"dependencies": [
					{
						"columns": ["WSLookupValue"],
						"methodName": "checkWSLookupValue"
					}
				]
			},
			"WSLookup":{
				"dependencies": [
					{
						"columns": ["WSLookup"],
						"methodName": "checkWSLookup"
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
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},
		},
		modules: /**SCHEMA_MODULES*/{
			"FilterModule": {
				"moduleId": "WSPattern1Page_FilterEditModule",
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
				this.checkWSLookup(2);
				this.checkWSLookupValue(2);
				
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
			
			checkWSLookup: function(start){
				if (!this.get("WSLookup") && (start !=2)){
					this.set("WSLookupValue","");
					this.set("WSLookupCode","");
				}
			},
			
			checkWSLookupValue: function(start){
				if (!this.get("WSLookupValue")){
					this.set("WSLookupGuid","");
					
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
								//this.set("WSName",this.get("WSFolder").displayValue + " - " + this.get("WSColumn") + " - " + this.get("WSLookupValue"));
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
			
			checkColumn: function(){
				if (this.get("WSFolder") && this.get("WSColumnCode")){
					
					var columName = arguments[1];
					
					var $this = this;
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					    rootSchemaName: "WSPattern"
					});
					
					esq.addColumn("WSColumnCode");
					esq.addColumn("WSRegular");
					esq.addColumn("WSNotes");
					esq.addColumn("WSName");
					esq.addColumn("WSFolder");
					//esq.addColumn("WSFolder.Code","Code");
					
					esq.filters.add("WSFolderFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSFolder", this.get("WSFolder").value));
					esq.filters.add("WSSerializedFilterFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSSerializedFilter", this.get("WSSerializedFilter")));
					esq.filters.add("WSColumnCodeFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSColumnCode", this.get("WSColumnCode")));
					//esq.filters.add("WSLookupFilter", this.BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "WSLookup", this.get("WSLookup")));
					
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
			
			save: function(){
				if (this.get("checkColumns")){
					this.showInformationDialog(this.get("Resources.Strings.CheckRulesForColumnsMessage"));
				} else {
					this.callParent(arguments);
				}
			},
			
			checkFolder: function(start){
				var $this = this;
				var module = this.get("WSFolder");
				if (module) {
					this.set("WSSchemaName", this.get("WSFolder").displayValue);
					this.set("WSSchemaId", this.get("WSFolder").value);
					if (start != 2){
						//this.set("WSName","");
						this.set("WSName",this.get("WSFolder").displayValue);
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
				
			/**
			 * Открытие окна StructureExplorer.
			 * @private
			 */
			openStructureExplorer: function() {
				var excludeDataValueTypes = [];
				
				for (key in this.BPMSoft.DataValueType) {
					if ( (key != "TEXT") && (key != "SHORT_TEXT") && (key != "SECURE_TEXT")  && (key != "METADATA_TEXT") && (key != "MEDIUM_TEXT") && (key != "MAXSIZE_TEXT") && (key != "LONG_TEXT") && (key != "LONG_TEXT") ){
						excludeDataValueTypes.push(BPMSoft.DataValueType[key]);
					}
            	}
            	
				var config = {
					useBackwards: false,
					ExpandVisible: false,
					excludeDataValueTypes: excludeDataValueTypes,
					displayId: true,
					firstColumnsOnly: true,
					schemaName: this.get("WSModuleName")
				};
				var handler = this.structureExplorerHandler;
				StructureExplorerUtilities.Open(this.sandbox, config, handler, this.renderTo, this);
			},
			
			openStructureExplorerForLookup: function(){
				var excludeDataValueTypes = [];
				
				for (key in this.BPMSoft.DataValueType) {
					if (key != "LOOKUP"){
						excludeDataValueTypes.push(BPMSoft.DataValueType[key]);
					}
            	}
				
				var config = {
					useBackwards: false,
					firstColumnsOnly: true,
					displayId: true,
					excludeDataValueTypes: excludeDataValueTypes,
					schemaName: this.get("WSModuleName")
				};
				var handler = this.structureExplorerHandlerForLookup;
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
				var columnCaption = args.leftExpressionCaption;
				var columnPath = args.leftExpressionColumnPath;
				this.set("WSColumnCode",columnPath);
				this.set("WSColumn",columnCaption);
			},
			
			structureExplorerHandlerForLookup: function(args) {
				var columnCaption = args.leftExpressionCaption;
				var columnPath = args.leftExpressionColumnPath;
				this.set("WSLookupCode",columnPath);
				this.set("WSLookupColumnCode",args.referenceSchemaName);
				this.set("WSLookup",columnCaption);
			},
			
			onDiscardChangesClick: function(callback, scope){
				
				if (this.isNew) {
					this.callParent(arguments);
					return;
				}
				this.set("IsEntityInitialized", false);
				this.loadEntity(this.getPrimaryColumnValue(), function() {
					this.updateButtonsVisibility(false, {
						force: true
					});
					this.initMultiLookup();
					this.set("IsEntityInitialized", true);
					this.discardDetailChange();
					this.updatePageHeaderCaption();
					
					this.checkFolder();
					this.Ext.callback(callback, scope);
				}, this);
				if (this.get("ForceUpdate")) {
					this.set("ForceUpdate", false);
				}
			},
			
			openLookupValue: function(){
				
				if (!this.get("WSLookupCode")){
					return false;
				}
				
				var config = {
                    entitySchemaName: this.get("WSLookupColumnCode"),
					multiSelect: false,
					columns: ["Id"]
                };
                
                var $this = this;
				var addCallback = function(args) {
					var selectedRows = args.selectedRows;
					if (selectedRows.getCount() > 0) {
						var lookupdata = selectedRows.getByIndex(0);
						$this.set("WSLookupValue", lookupdata.displayValue);
						$this.set("WSLookupGuid", lookupdata.value);
					}
				};
				LookupUtilities.Open(this.sandbox, config, addCallback, this);
			},
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "WSName576cd7eb-c948-4925-a4cb-015eae43034d",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "WSName"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WSIsActive7128ee60-71c1-493d-89c2-c2e07df9f42f",
				"values": {
					"layout": {
						"colSpan": 6,
						"rowSpan": 1,
						"column": 12,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "WSIsActive"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "WSFolder4a3e3727-f4da-46dc-a3ab-b0a0ea7a89ff",
				"values": {
					"layout": {
						"colSpan": 8,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "WSFolder"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "WSColumna6f470c4-ea8c-4038-bea6-0d54c6977980",
				"values": {
					"layout": {
						"colSpan": 8,
						"rowSpan": 1,
						"column": 8,
						"row": 1,
						"layoutName": "Header"
					},
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
				"index": 3
			},
			{
				"operation": "insert",
				"name": "WSColumnCode794a6b3f-17a3-495a-8d95-c747341ff724",
				"values": {
					"layout": {
						"colSpan": 8,
						"rowSpan": 1,
						"column": 16,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "WSColumnCode",
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			
			{
				"operation": "insert",
				"name": "WSMask2f22bf22-f0ca-48b2-b05f-b105d0202f83",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "Header"
					},
					"bindTo": "WSMask"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "WSPermitSymbolsda7c126c-f097-432e-922d-5d62cb2d99cb",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 5,
						"layoutName": "Header"
					},
					"bindTo": "WSPermitSymbols"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 9
			},
			{
				"operation": "insert",
				"name": "WSRegular046f8c72-0cc8-4de4-a2c4-e438f920fe59",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 6,
						"layoutName": "Header"
					},
					"bindTo": "WSRegular"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 10
			},
			{
				"operation": "insert",
				"name": "WSJSCodef5746ac0-85f8-4339-8ebc-cdea4f173f9c",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 3,
						"column": 0,
						"row": 8,
						"layoutName": "Header"
					},
					"bindTo": "WSJSCode",
					"enabled": true,
					"contentType": 0
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 11
			},
			{
				"operation": "insert",
				"name": "WSNotes0a7575e7-950e-4c80-afdc-b6dfa158ae23",
				"values": {
					"layout": {
						"colSpan": 12,
						"rowSpan": 1,
						"column": 0,
						"row": 11,
						"layoutName": "Header"
					},
					"bindTo": "WSNotes"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 12
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

