define("DashboardFunnelEnums", ["DashboardFunnelEnumsResources", "DashboardEnums"],
	function() {

		/** @enum
		 *  ############ ##### ###### - ######## ####### ### ####### ###### */
		BPMSoft.DashboardEnums.WidgetType.OpportunityFunnel = {
			"view": {
				"moduleName": "OpportunityFunnelModuleV2",
				"configurationMessage": "GetChartConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "OpportunityFunnelDesigner"
					}
				}
			}
		};
		BPMSoft.DashboardEnums.WidgetColorSet = [
				/** 0: Orange */
			"#F9763D",
			/** 1: Yellow (Mustard) */
			"#FBD24E",
			/** 2: Cornflower blue (Blue) */
			"#7299F8",
			/** 3: Sky blue */
			"#BFE4FF",
			/** 4: Bright green */
			"#BCE941",
			/** 5: Violet (Violet) */
			"#ADA7FC",
			/** 6: Cool green (Green) */
			"#33B864",
			/** 7: Leaf green */
			"#76C224",
			/** 8: Red-orange */
			"#F14E07",
			/** 9: Rust */
			"#C13E06",
			/** 10: Cerise pink (Coral) */
			"#EC3B83",
			/** 11: Mango */
			"#FFC324",
			/** 12: Dark cyan (Dark-turquoise) */
			"#008B8B",
			/** 13: Eucalypt (Turquoise) */
			"#44D7A8",
			/** 14: Dodger blue (Navy) */
			"#1E90FF",
			/** 15: Dark orchid */
			"#9932CC"
		]	
		Ext.ns("BPMSoft.DashboardFunnelEnums");

		/** @enum
		 *  ############ ##### ####### ###### */
		BPMSoft.DashboardFunnelEnums.FunnelType = {
			/** ####### ## ########## ###### */
			BY_NUMBER: 0,
			/** ######### # ###### ###### */
			TO_FIRST_STAGE: 1,
			/** ######### ###### */
			STAGE_CONVERSION: 2
		};
	});

