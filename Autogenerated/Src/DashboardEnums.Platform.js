define("DashboardEnums", ["DashboardEnumsResources"], function (resources) {

	Ext.ns("BPMSoft.DashboardEnums");

	BPMSoft.DashboardEnums.WidgetType = {
		"Chart": {
			"view": {
				"moduleName": "ChartModule",
				"configurationMessage": "GetChartConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "ChartDesigner"
					}
				}
			}
		},
		"Indicator": {
			"view": {
				"moduleName": "IndicatorModule",
				"configurationMessage": "GetIndicatorConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "IndicatorDesigner"
					}
				}
			}
		},
		"Gauge": {
			"view": {
				"moduleName": "GaugeModule",
				"configurationMessage": "GetGaugeConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "GaugeDesigner"
					}
				}
			}
		},
		"DashboardGrid": {
			"view": {
				"moduleName": "DashboardGridModule",
				"configurationMessage": "GetDashboardGridConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "DashboardGridDesigner"
					}
				}
			}
		},
		"Module": {
			"view": {},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "ModuleConfigEdit"
					}
				}
			}
		},
		"WebPage": {
			"view": {
				"moduleName": "WebPageModule",
				"configurationMessage": "GetWebPageConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "WebPageDesigner"
					}
				}
			}
		}
	};

	if (BPMSoft.Features.getIsEnabled("FullPipeline")) {
		BPMSoft.DashboardEnums.WidgetType.FullPipeline = {
			"view": {
				"moduleName": "FullPipelineModule",
				"configurationMessage": "GetChartConfig"
			},
			"design": {
				"moduleName": "ConfigurationModuleV2",
				"configurationMessage": "GetModuleConfig",
				"resultMessage": "PostModuleConfig",
				"stateConfig": {
					"stateObj": {
						"designerSchemaName": "FullPipelineDesigner"
					}
				}
			}
		};
	}

	/** @enum
	 *  Pipeline slice types enumeration. */
	BPMSoft.DashboardEnums.PipelineSliceType = {
		/** Pipeline by count */
		BY_COUNT: 0,
		/** To first stage pipeline conversion */
		TO_FIRST_STAGE: 1,
		/** Stages pipeline conversion */
		STAGE_CONVERSION: 2
	};

	/** @enum
	 *  ############ ####### ############# # ###### ######## */
	BPMSoft.DashboardEnums.ChartDisplayMode = {
		/** ##### ####### */
		CHART: 0,
		/** ##### ###### */
		GRID: 1
	};

	/** @enum
	 *  ############ ####### ########### ####### ### #######
	 **/
	BPMSoft.DashboardEnums.ChartAxisPosition = {
		/** ## ########## */
		NONE: 0,
		/** ##### */
		LEFT: 1,
		/** ###### */
		RIGHT: 2
	};

	/** @enum
	 *  Chart sort types enum
	 **/
	BPMSoft.DashboardEnums.ChartOrderBy = {
		/** By group field */
		GROUP_BY_FIELD: "GroupByField",
		/** By selection result */
		CHART_ENTITY_COLUMN: "ChartEntityColumn",
		/*By custom column*/
		CUSTOM_COLUMN: "CustomColumn"
	};

	/** @enum
	 *  ############ ########### ######### #######
	 **/
	BPMSoft.DashboardEnums.ChartOrderDirection = {
		/** ## ########### */
		ASCENDING: "Ascending",
		/** ## ######## */
		DESCENDING: "Descending"
	};

	/** @enum
	 * ##### ###### ########.
	 */
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
	];

	/** @enum
	 * ###### ########### ###### # ###### #####.
	 */
	BPMSoft.DashboardEnums.StyleColors = {
		"widget-orange": BPMSoft.DashboardEnums.WidgetColorSet[0],
		"widget-mustard": BPMSoft.DashboardEnums.WidgetColorSet[1],
		"widget-blue": BPMSoft.DashboardEnums.WidgetColorSet[2],
		"widget-sky-blue": BPMSoft.DashboardEnums.WidgetColorSet[3],
		"widget-bright-green": BPMSoft.DashboardEnums.WidgetColorSet[4],
		"widget-violet": BPMSoft.DashboardEnums.WidgetColorSet[5],
		"widget-green": BPMSoft.DashboardEnums.WidgetColorSet[6],
		"widget-leaf-green": BPMSoft.DashboardEnums.WidgetColorSet[7],
		"widget-red-orange": BPMSoft.DashboardEnums.WidgetColorSet[8],
		"widget-rust": BPMSoft.DashboardEnums.WidgetColorSet[9],
		"widget-coral": BPMSoft.DashboardEnums.WidgetColorSet[10],
		"widget-mango": BPMSoft.DashboardEnums.WidgetColorSet[11],
		"widget-dark-turquoise": BPMSoft.DashboardEnums.WidgetColorSet[12],
		"widget-turquoise": BPMSoft.DashboardEnums.WidgetColorSet[13],
		"widget-navy": BPMSoft.DashboardEnums.WidgetColorSet[14],
		"widget-dark-orchid": BPMSoft.DashboardEnums.WidgetColorSet[15],
	};

	/** @enum
	 * ############ ###### ######## ###### # ## ########### # #############.
	 */
	BPMSoft.DashboardEnums.WidgetColor = {
		"widget-orange": {
			value: "widget-orange",
			displayValue: resources.localizableStrings.StyleOrange,
			imageConfig: resources.localizableImages.ImageOrange
		},
		"widget-bright-green": {
			value: "widget-bright-green",
			displayValue: resources.localizableStrings.StyleBrightGreen,
			imageConfig: resources.localizableImages.ImageBrightGreen
		},
		"widget-red-orange": {
			value: "widget-red-orange",
			displayValue: resources.localizableStrings.StyleRedOrange,
			imageConfig: resources.localizableImages.ImageRedOrange
		},
		"widget-dark-turquoise": {
			value: "widget-dark-turquoise",
			displayValue: resources.localizableStrings.StyleDarkTurquoise,
			imageConfig: resources.localizableImages.ImageDarkTurquoise
		},
		"widget-mustard": {
			value: "widget-mustard",
			displayValue: resources.localizableStrings.StyleMustard,
			imageConfig: resources.localizableImages.ImageMustard
		},
		"widget-violet": {
			value: "widget-violet",
			displayValue: resources.localizableStrings.StyleViolet,
			imageConfig: resources.localizableImages.ImageViolet
		},
		"widget-rust": {
			value: "widget-rust",
			displayValue: resources.localizableStrings.StyleRust,
			imageConfig: resources.localizableImages.ImageRust
		},
		"widget-turquoise": {
			value: "widget-turquoise",
			displayValue: resources.localizableStrings.StyleTurquoise,
			imageConfig: resources.localizableImages.ImageTurquoise
		},
		"widget-blue": {
			value: "widget-blue",
			displayValue: resources.localizableStrings.StyleBlue,
			imageConfig: resources.localizableImages.ImageBlue
		},
		"widget-green": {
			value: "widget-green",
			displayValue: resources.localizableStrings.StyleGreen,
			imageConfig: resources.localizableImages.ImageGreen
		},
		"widget-coral": {
			value: "widget-coral",
			displayValue: resources.localizableStrings.StyleCoral,
			imageConfig: resources.localizableImages.ImageCoral
		},
		"widget-navy": {
			value: "widget-navy",
			displayValue: resources.localizableStrings.StyleNavy,
			imageConfig: resources.localizableImages.ImageNavy
		},
		"widget-sky-blue": {
			value: "widget-sky-blue",
			displayValue: resources.localizableStrings.StyleSkyBlue,
			imageConfig: resources.localizableImages.ImageSkyBlue
		},
		"widget-leaf-green": {
			value: "widget-leaf-green",
			displayValue: resources.localizableStrings.StyleLeafGreen,
			imageConfig: resources.localizableImages.ImageLeafGreen
		},
		"widget-mango": {
			value: "widget-mango",
			displayValue: resources.localizableStrings.StyleMango,
			imageConfig: resources.localizableImages.ImageMango
		},
		"widget-dark-orchid": {
			value: "widget-dark-orchid",
			displayValue: resources.localizableStrings.StyleDarkOrchid,
			imageConfig: resources.localizableImages.ImageDarkOrchid
		},
	};
});
