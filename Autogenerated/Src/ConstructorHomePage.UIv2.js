define("ConstructorHomePage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "crt.IndicatorWidgetf02a4503-289d-ce00-7c28-9c7a2aaa6ef1",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 3,
						"rowSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetf02a4503289dce007c289c7a2aaa6ef1_title)#",
						"data": {
							"providing": {
								"schemaName": "SysAdminUnit",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"328ed89f-2cf3-42a0-ba0f-850ef8032777": {
												"filterType": 5,
												"comparisonType": 15,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "[SysUserSession:SysUser].Id"
												},
												"isAggregative": true,
												"dataValueType": 0,
												"subFilters": {
													"items": {
														"f0c0654a-a2d8-471e-88c2-404515af59f8": {
															"filterType": 2,
															"comparisonType": 1,
															"isEnabled": true,
															"trimDateTimeParameterToDate": false,
															"leftExpression": {
																"expressionType": 0,
																"columnPath": "SessionEndDate"
															},
															"isAggregative": false,
															"dataValueType": 7,
															"isNull": true
														},
														"7d20aa63-c846-47bb-992a-31d47d5600a3": {
															"items": {
																"d5c7396b-a138-49d7-8a5d-8d3eed287ab8": {
																	"filterType": 1,
																	"comparisonType": 3,
																	"isEnabled": true,
																	"trimDateTimeParameterToDate": true,
																	"leftExpression": {
																		"expressionType": 0,
																		"columnPath": "SessionStartDate"
																	},
																	"isAggregative": false,
																	"dataValueType": 7,
																	"rightExpression": {
																		"expressionType": 1,
																		"functionType": 1,
																		"macrosType": 4
																	}
																},
																"351af6aa-4e59-423a-bc11-da20ba0c5fa0": {
																	"filterType": 1,
																	"comparisonType": 3,
																	"isEnabled": true,
																	"trimDateTimeParameterToDate": true,
																	"leftExpression": {
																		"expressionType": 0,
																		"columnPath": "SessionStartDate"
																	},
																	"isAggregative": false,
																	"dataValueType": 7,
																	"rightExpression": {
																		"expressionType": 1,
																		"functionType": 1,
																		"macrosType": 3
																	}
																}
															},
															"logicalOperation": 1,
															"isEnabled": true,
															"filterType": 6,
															"rootSchemaName": "SysUserSession",
															"key": "7d20aa63-c846-47bb-992a-31d47d5600a3"
														}
													},
													"logicalOperation": 0,
													"isEnabled": true,
													"filterType": 6,
													"rootSchemaName": "SysUserSession",
													"key": "059afbd0-20bc-49d5-ad29-7cea91635d3c"
												}
											},
											"a99e7882-4abe-42de-8d9f-74649cb04a76": {
												"filterType": 1,
												"comparisonType": 4,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ConnectionType"
												},
												"isAggregative": false,
												"dataValueType": 4,
												"rightExpression": {
													"expressionType": 2,
													"parameter": {
														"dataValueType": 4,
														"value": 1
													}
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "SysAdminUnit"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidgetf02a4503289dce007c289c7a2aaa6ef1_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "large"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget36551d07-19c7-1252-aea4-35e530446ecf",
				"values": {
					"layoutConfig": {
						"column": 4,
						"row": 1,
						"colSpan": 3,
						"rowSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget36551d0719c71252aea435e530446ecf_title)#",
						"data": {
							"providing": {
								"schemaName": "VwExpiringLicense",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "VwExpiringLicense"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget36551d0719c71252aea435e530446ecf_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "large"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidgetd0b21510-a5ae-bfd9-e5f2-f7e52b2cb68d",
				"values": {
					"layoutConfig": {
						"column": 7,
						"row": 1,
						"colSpan": 3,
						"rowSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetd0b21510a5aebfd9e5f2f7e52b2cb68d_title)#",
						"data": {
							"providing": {
								"schemaName": "VwSysProcessLog",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"b7b59a69-060e-454d-9aa4-9135126cd9ab": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "StartDate"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 4
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "VwSysProcessLog"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidgetd0b21510a5aebfd9e5f2f7e52b2cb68d_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidgetb9c29e82-22a3-6992-760d-99ac65893f94",
				"values": {
					"layoutConfig": {
						"column": 10,
						"row": 1,
						"colSpan": 3,
						"rowSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetb9c29e8222a36992760d99ac65893f94_title)#",
						"data": {
							"providing": {
								"schemaName": "VwSysProcessLog",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"14422ed6-d545-4187-905d-25bb5ac07298": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "CompleteDate"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 4
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "VwSysProcessLog"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidgetb9c29e8222a36992760d99ac65893f94_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetc4975985-fb18-bfd8-b567-c6786ae46694",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 6,
						"rowSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetc4975985fb18bfd8b567c6786ae46694_title)#",
						"color": "navy-blue",
						"theme": "partial-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "#ResourceString(crtChartWidgetc4975985fb18bfd8b567c6786ae46694_xAxis)#",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"color": "violet",
								"type": "spline",
								"label": "#ResourceString(crtChartWidgetc4975985fb18bfd8b567c6786ae46694_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "ActiveUsersStatistics",
										"rowCount": 50,
										"grouping": {
											"column": [
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 6,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "DateValue",
															"expressionType": 0
														}
													}
												}
											],
											"type": "by-date-part"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 2,
													"aggregationEvalType": 0,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "SysUserCount"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"37d3aabb-ca37-462f-89a4-ee7a842d2b69": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "DateValue"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"macrosType": 4
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "ActiveUsersStatistics"
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"thousandSeparator": ","
									}
								}
							}
						],
						"seriesOrder": {
							"type": "by-grouping-value",
							"direction": 1
						}
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgeta52c0bfa-80e3-b15e-2ff5-60b13cdd78e0",
				"values": {
					"layoutConfig": {
						"column": 7,
						"row": 3,
						"colSpan": 6,
						"rowSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_title)#",
						"color": "coral",
						"theme": "partial-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "#ResourceString(crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_xAxis)#",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"color": "coral",
								"type": "spline",
								"label": "#ResourceString(crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "VwSysProcessLog",
										"rowCount": 50,
										"grouping": {
											"column": [
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 6,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "StartDate",
															"expressionType": 0
														}
													}
												}
											],
											"type": "by-date-part"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"bb58a143-9337-46a2-b74c-6b4a71fa3951": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "StartDate"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"macrosType": 4
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "VwSysProcessLog"
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"thousandSeparator": ","
									}
								}
							}
						],
						"seriesOrder": {
							"type": "by-grouping-value",
							"direction": 1
						}
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget778cabc9-ca84-3bd6-520d-cb76ede8de60",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 7,
						"colSpan": 9,
						"rowSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget778cabc9ca843bd6520dcb76ede8de60_title)#",
						"color": "navy-blue",
						"theme": "partial-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"color": "dark-green",
								"type": "line",
								"label": "#ResourceString(crtChartWidget778cabc9ca843bd6520dcb76ede8de60_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Contact",
										"rowCount": 50,
										"grouping": {
											"column": [
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 1,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 3,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												}
											],
											"type": "by-date-part"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"d5624381-1cb9-42ff-a2c3-31e724139ac7": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"macrosType": 4
														}
													},
													"e5d6cf31-417e-466b-b27b-71280c7cceea": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"functionArgument": {
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 4,
																	"value": 29
																}
															},
															"macrosType": 25
														}
													}
												},
												"logicalOperation": 1,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Contact"
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"thousandSeparator": ","
									}
								}
							},
							{
								"color": "navy-blue",
								"type": "line",
								"label": "#ResourceString(crtChartWidget778cabc9ca843bd6520dcb76ede8de60_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Account",
										"rowCount": 50,
										"grouping": {
											"column": [
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 1,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 3,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												}
											],
											"type": "by-date-part"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"f41934f1-e80c-4ba2-85f4-2932a5aa2b52": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"macrosType": 4
														}
													},
													"3b8be247-4dcc-4f3a-8e35-ac7eb42f743e": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"functionArgument": {
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 4,
																	"value": 29
																}
															},
															"macrosType": 25
														}
													}
												},
												"logicalOperation": 1,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Account"
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"thousandSeparator": ","
									}
								}
							},
							{
								"color": "red",
								"type": "line",
								"label": "#ResourceString(crtChartWidget778cabc9ca843bd6520dcb76ede8de60_series_2)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Activity",
										"rowCount": 50,
										"grouping": {
											"column": [
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 1,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 3,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												}
											],
											"type": "by-date-part"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"b87a7982-c65a-468d-89ba-015c780000d9": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"macrosType": 4
														}
													},
													"63cee2fa-8eb4-4715-9dc4-b566aba45f2f": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"functionArgument": {
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 4,
																	"value": 29
																}
															},
															"macrosType": 25
														}
													}
												},
												"logicalOperation": 1,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Activity"
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"thousandSeparator": ","
									}
								}
							}
						],
						"seriesOrder": {
							"type": "by-grouping-value",
							"direction": 1
						}
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidgetdb00dbf5-65a9-7c41-f8ab-24a6cbd21127",
				"values": {
					"layoutConfig": {
						"row": 7,
						"rowSpan": 3,
						"column": 10,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetdb00dbf565a97c41f8ab24a6cbd21127_title)#",
						"data": {
							"providing": {
								"schemaName": "VwSysProcessLog",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"47c33f9d-cbdd-4f92-8063-551fdc6fac67": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Status"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "SysProcessStatus",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Error",
																"Id": "f942c08d-b6e2-df11-971b-001d60e938c6",
																"value": "f942c08d-b6e2-df11-971b-001d60e938c6",
																"displayValue": "Error"
															}
														}
													}
												]
											},
											"8e14bbcc-3398-42d8-8c5a-665e0e00aa36": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ModifiedOn"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 4
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "VwSysProcessLog"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidgetdb00dbf565a97c41f8ab24a6cbd21127_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "large"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget92614f4c-e845-a46b-7185-f51c1ca91eee",
				"values": {
					"layoutConfig": {
						"row": 10,
						"rowSpan": 3,
						"column": 10,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget92614f4ce845a46b7185f51c1ca91eee_title)#",
						"data": {
							"providing": {
								"schemaName": "MLTrainSession",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"49d65fec-3de0-4ad0-bbb7-e4dc5b161da6": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "State"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "MLModelState",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Error",
																"Id": "3cb4ab63-b709-4982-83c4-53fbc888f333",
																"value": "3cb4ab63-b709-4982-83c4-53fbc888f333",
																"displayValue": "Error"
															}
														}
													}
												]
											},
											"cc07e4a2-08ba-46be-804c-711fec10406e": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "TrainedOn"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 4
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "MLTrainSession"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget92614f4ce845a46b7185f51c1ca91eee_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "large"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 8
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/
	};
});
