define("BaseSectionV2", ["WSFieldManagementMixin"],
	function(WSFieldManagementMixin) {
		return {
			messages: {},
			/**
			 * ######-####### (#######), ########### ################ ####### #####
			 */
			mixins: {
				WSFieldManagementMixin: "BPMSoft.WSFieldManagementMixin",
			},

			/**
			 * ######## ###### ############# #######
			 * @type {Object}
			 */
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

			properties: {},

			/**
			 * ###### ###### ############# #######
			 * @type {Object}
			 */
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
	                },"1e0234e0-5c4c-4193-9752-61ac0fb03c48");
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

			/**
			 * ############# #######
			 * @type {Object[]}
			 */
			diff: []
		};
	});
