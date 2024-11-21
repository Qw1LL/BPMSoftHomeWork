define("BaseGridDetailV2", ["WSFieldManagementMixin"],
	function(WSFieldManagementMixin) {
		return {
			messages: {},

			mixins: {
				WSFieldManagementMixin: "BPMSoft.WSFieldManagementMixin",
			},

			attributes: {
				"maxColorFilterNum":{
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": 0
				},
				"colorColumnsArray":{
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},
			},

			methods: {
				
				init: function() {
					
					var args = arguments;
		   			var parentMethod = this.getParentMethod();
		   			
		   			if (!this.entitySchemaName){
		   				parentMethod.apply(this, args);
	            		return false;
	            	}
					
					this.getGridColors(function(){
						if (parentMethod){
							parentMethod.apply(this, args);
				   		}
	                },"4fb31541-d34a-4b0d-bed1-a8c047faf1c4");
				},
				
				addGridDataColumns: function(esq) {
					this.callParent(arguments);
					this.addColorGridDataColumns(esq);
				},
				
				prepareResponseCollectionItem: function(item) {
					this.callParent(arguments);
					this.setColorToResonceItem(item);
				},
			},

			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
