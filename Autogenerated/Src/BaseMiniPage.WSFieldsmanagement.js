define("BaseMiniPage", ["BaseMiniPageResources","WSFieldManagementMixin","jQuery", "WSInputMask"], function(resources, WSFieldManagementMixin) {
	return {
		mixins: {
			WSFieldManagementMixin: "BPMSoft.WSFieldManagementMixin",
		},
		messages: {
		},
		attributes: {
			"maxColumnValue": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": 1
			},
			"maskTimeout":{
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": ""
			},
			"allLoads": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": 500
			},
			"countLoads": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": 0
			},
			"usePatterns":{
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": false
			},
			"PatternCollection": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
			},
		},
		methods: {
			
			save: function(){
				if (this.checkPatternsBeforeSave()){
					this.callParent(arguments);
				}
			},

			beforeEntityColumnChanged: function(columnName, columnValue) {
				this.resetPatterns(columnName, columnValue);
				this.reloadColors();
				this.loadColorColumns(true);
			},
			
            onEntityInitialized: function(){
            	this.callParent(arguments);
            	
            	if (!this.entitySchemaName){
            		return false;
            	}
            	this.getPatternsData();
            	this.getFieldsColors();
            },
			
			close: function() {
				this.reloadMasks();
				this.reloadColors();
				this.callParent(arguments);
			},
			
			onDiscardChangesClick: function(callback, scope){
				this.callParent([function() {
					this.reloadMasks();
					this.loadColumns(true);
					this.reloadColors();
					this.loadColorColumns(true);
				}, this]);
			},
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
