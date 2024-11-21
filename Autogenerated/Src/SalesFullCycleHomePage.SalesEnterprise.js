define("SalesFullCycleHomePage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		"viewConfigDiff": /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget3894d151-f9b8-1ae5-6a7c-f588c0a68a72",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 3,
						"rowSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget3894d151f9b81ae56a7cf588c0a68a72_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Amount"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"e02ea365-a507-47c9-9b64-a55ff7c19098": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Stage"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "OpportunityStage",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Closed won",
																"Id": "60d5310c-5be6-df11-971b-001d60e938c6",
																"value": "60d5310c-5be6-df11-971b-001d60e938c6",
																"displayValue": "Closed won"
															}
														}
													}
												]
											},
											"1de7d797-68e2-49b7-9d25-96c740927d5d": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "DueDate"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 13
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget3894d151f9b81ae56a7cf588c0a68a72_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget3104134a-ef61-7eda-335c-ef8ce3a43622",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 4,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget3104134aef617eda335cef8ce3a43622_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
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
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget3104134aef617eda335cef8ce3a43622_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetc01981dc-f2dd-1a54-bcfc-4de1241c5d82",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 4,
						"column": 7,
						"colSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetc01981dcf2dd1a54bcfc4de1241c5d82_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "green",
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetc01981dcf2dd1a54bcfc4de1241c5d82_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"aggregationType": 2,
													"aggregationEvalType": 0,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Amount"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"ec66ac2a-c780-4111-b4e9-fd56046b0106": {
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
															"macrosType": 19
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetc01981dcf2dd1a54bcfc4de1241c5d82_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"aggregationType": 2,
													"aggregationEvalType": 0,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Amount"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"ec66ac2a-c780-4111-b4e9-fd56046b0106": {
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
															"macrosType": 19
														}
													},
													"fad7c590-47de-4991-acc2-9231a09bf5c2": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Stage"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "OpportunityStage",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Closed lost",
																		"Id": "a9aafdfe-2242-4f42-8cd5-2ae3b9556d79",
																		"value": "a9aafdfe-2242-4f42-8cd5-2ae3b9556d79",
																		"displayValue": "Closed lost"
																	}
																}
															}
														]
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
								"color": "celestial-blue",
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetc01981dcf2dd1a54bcfc4de1241c5d82_series_2)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"aggregationType": 2,
													"aggregationEvalType": 0,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Amount"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"ec66ac2a-c780-4111-b4e9-fd56046b0106": {
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
															"macrosType": 19
														}
													},
													"fad7c590-47de-4991-acc2-9231a09bf5c2": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Stage"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "OpportunityStage",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Closed won",
																		"Id": "60d5310c-5be6-df11-971b-001d60e938c6",
																		"value": "60d5310c-5be6-df11-971b-001d60e938c6",
																		"displayValue": "Closed won"
																	}
																}
															}
														]
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"index": 2
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget5ba45467-8b98-8003-56fd-ca6550d0632a",
				"values": {
					"layoutConfig": {
						"row": 3,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget5ba454678b98800356fdca6550d0632a_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Amount"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"9b50ed86-c3c6-47e8-bf7a-d1bc89c7524c": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Stage"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "OpportunityStage",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Closed won",
																"Id": "60d5310c-5be6-df11-971b-001d60e938c6",
																"value": "60d5310c-5be6-df11-971b-001d60e938c6",
																"displayValue": "Closed won"
															}
														}
													}
												]
											},
											"08155765-d9ae-4d06-87e0-ac7816a5e172": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "DueDate"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 19
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": null,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget5ba454678b98800356fdca6550d0632a_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget70f3f787-02ba-acac-e086-32d1157ed47d",
				"values": {
					"layoutConfig": {
						"row": 3,
						"rowSpan": 2,
						"column": 4,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget70f3f78702baacace08632d1157ed47d_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Amount"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"552eac66-67f9-4e6b-90c3-7bd61dacf211": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "DueDate"
												},
												"isAggregative": false,
												"dataValueType": 7,
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 19
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget70f3f78702baacace08632d1157ed47d_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetf368597f-d371-7b15-ac9b-18285fe46c22",
				"values": {
					"layoutConfig": {
						"row": 5,
						"rowSpan": 4,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetf368597fd3717b15ac9b18285fe46c22_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "green",
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetf368597fd3717b15ac9b18285fe46c22_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"638741dd-5d79-4fa0-8d4a-54a9d9c0c27e": {
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
															"macrosType": 13
														}
													},
													"5baaa3b0-4528-4685-95e2-72edf12a36cc": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "IsPrimary"
														},
														"isAggregative": false,
														"dataValueType": 12,
														"rightExpression": {
															"expressionType": 2,
															"parameter": {
																"dataValueType": 12,
																"value": true
															}
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
								"color": "celestial-blue",
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetf368597fd3717b15ac9b18285fe46c22_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"638741dd-5d79-4fa0-8d4a-54a9d9c0c27e": {
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
															"macrosType": 13
														}
													},
													"5baaa3b0-4528-4685-95e2-72edf12a36cc": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "IsPrimary"
														},
														"isAggregative": false,
														"dataValueType": 12,
														"rightExpression": {
															"expressionType": 2,
															"parameter": {
																"dataValueType": 12,
																"value": false
															}
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"name": "crt.ChartWidgetccc3d1a8-0b31-0f07-1f98-14a28381ad75",
				"values": {
					"layoutConfig": {
						"row": 5,
						"rowSpan": 4,
						"column": 4,
						"colSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetccc3d1a80b310f071f9814a28381ad75_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "green",
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetccc3d1a80b310f071f9814a28381ad75_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"0d656298-26d5-42ff-8f37-881fc91cc100": {
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
															"macrosType": 19
														}
													},
													"7dae03f7-f2d1-405e-91d0-f47772660a64": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "IsPrimary"
														},
														"isAggregative": false,
														"dataValueType": 12,
														"rightExpression": {
															"expressionType": 2,
															"parameter": {
																"dataValueType": 12,
																"value": true
															}
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
								"color": "celestial-blue",
								"type": "bar",
								"label": "#ResourceString(crtChartWidgetccc3d1a80b310f071f9814a28381ad75_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"0d656298-26d5-42ff-8f37-881fc91cc100": {
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
															"macrosType": 19
														}
													},
													"7dae03f7-f2d1-405e-91d0-f47772660a64": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "IsPrimary"
														},
														"isAggregative": false,
														"dataValueType": 12,
														"rightExpression": {
															"expressionType": 2,
															"parameter": {
																"dataValueType": 12,
																"value": false
															}
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"name": "crt.ChartWidgetd03d48b8-623a-c013-53b7-9613bc52160b",
				"values": {
					"layoutConfig": {
						"row": 5,
						"rowSpan": 4,
						"column": 10,
						"colSpan": 3
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetd03d48b8623ac01353b79613bc52160b_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "celestial-blue",
								"type": "line",
								"label": "#ResourceString(crtChartWidgetd03d48b8623ac01353b79613bc52160b_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "LeadType"
												}
											},
											"type": "by-value"
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
														"columnPath": "Amount"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"fc3c2e3e-7ebf-4034-85ff-0483e7a8707d": {
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
															"macrosType": 19
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "LeadType"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"index": 7
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget8cd32822-aa8f-61d3-274e-eeb8d64463d0",
				"values": {
					"layoutConfig": {
						"row": 9,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget8cd32822aa8f61d3274eeeb8d64463d0_title)#",
						"data": {
							"providing": {
								"schemaName": "Lead",
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
											"611fc1b1-c474-4c6b-afb5-0040b9b496c3": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "QualifyStatus.IsFinal"
												},
												"isAggregative": false,
												"dataValueType": 12,
												"rightExpression": {
													"expressionType": 2,
													"parameter": {
														"dataValueType": 12,
														"value": false
													}
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Lead"
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
							"template": "#ResourceString(crtIndicatorWidget8cd32822aa8f61d3274eeeb8d64463d0_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget7103d8e8-3dbf-4a07-4744-35c241979c96",
				"values": {
					"layoutConfig": {
						"row": 9,
						"rowSpan": 2,
						"column": 4,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget7103d8e83dbf4a07474435c241979c96_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
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
											"26c3c0ca-80cc-4ac8-be8d-eae4a95a4039": {
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
													"macrosType": 13
												}
											},
											"7b95d519-e16f-46b7-b615-6e2c9916e67d": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Stage.End"
												},
												"isAggregative": false,
												"dataValueType": 12,
												"rightExpression": {
													"expressionType": 2,
													"parameter": {
														"dataValueType": 12,
														"value": false
													}
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget7103d8e83dbf4a07474435c241979c96_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 9
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget64d40412-2432-3995-f94d-a035913b62b1",
				"values": {
					"layoutConfig": {
						"row": 9,
						"rowSpan": 2,
						"column": 7,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget64d4041224323995f94da035913b62b1_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Amount"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"71ac1823-13ab-4bb7-b3d4-9052f06a3a7a": {
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
													"macrosType": 13
												}
											},
											"fb7a7b36-6afa-4e43-bbd9-ce97aea34383": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Stage.End"
												},
												"isAggregative": false,
												"dataValueType": 12,
												"rightExpression": {
													"expressionType": 2,
													"parameter": {
														"dataValueType": 12,
														"value": false
													}
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget64d4041224323995f94da035913b62b1_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 10
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget0b1e7bb8-1041-38e3-be6d-b256b6d1023d",
				"values": {
					"layoutConfig": {
						"row": 9,
						"rowSpan": 2,
						"column": 10,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget0b1e7bb8104138e3be6db256b6d1023d_title)#",
						"data": {
							"providing": {
								"schemaName": "Opportunity",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Amount"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"6ee348df-b3fc-453d-9c17-db11da405c1b": {
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
													"macrosType": 13
												}
											},
											"49a360da-c5f3-4792-a9c6-afe08b4bfcfa": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Type"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "OpportunityType",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Partner sale",
																"Id": "c4505efc-6cf5-4b0c-b984-55076bc235f0",
																"value": "c4505efc-6cf5-4b0c-b984-55076bc235f0",
																"displayValue": "Partner sale"
															}
														}
													}
												]
											},
											"e937aff1-d23d-4a4d-a15f-a378b2920fed": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Stage.End"
												},
												"isAggregative": false,
												"dataValueType": 12,
												"rightExpression": {
													"expressionType": 2,
													"parameter": {
														"dataValueType": 12,
														"value": false
													}
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Opportunity"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget0b1e7bb8104138e3be6db256b6d1023d_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 11
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget59d8342a-9f5d-54fb-16ff-7c40b9c80e8e",
				"values": {
					"layoutConfig": {
						"row": 11,
						"rowSpan": 5,
						"column": 1,
						"colSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget59d8342a9f5d54fb16ff7c40b9c80e8e_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "celestial-blue",
								"type": "bar",
								"label": "#ResourceString(crtChartWidget59d8342a9f5d54fb16ff7c40b9c80e8e_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Stage"
												}
											},
											"type": "by-value"
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
														"columnPath": "Amount"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"5ac7bde7-74ed-4503-a9f3-6731ce65ec06": {
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
															"macrosType": 13
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Stage"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"index": 12
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget9b2f05a9-8df0-a36b-1366-334a92e4b0e2",
				"values": {
					"layoutConfig": {
						"row": 11,
						"rowSpan": 5,
						"column": 7,
						"colSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget9b2f05a98df0a36b1366334a92e4b0e2_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"type": "bar",
								"label": "#ResourceString(crtChartWidget9b2f05a98df0a36b1366334a92e4b0e2_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Lead",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"909b1fb3-d86c-47c4-b294-8bd6c281a2d4": {
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
															"macrosType": 19
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Lead"
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
								"color": "celestial-blue",
								"type": "bar",
								"label": "#ResourceString(crtChartWidget9b2f05a98df0a36b1366334a92e4b0e2_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Lead",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"909b1fb3-d86c-47c4-b294-8bd6c281a2d4": {
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
															"macrosType": 19
														}
													},
													"6e0d3158-2783-42d2-ae79-5f209d4fb15e": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "QualifyStatus.IsFinal"
														},
														"isAggregative": false,
														"dataValueType": 12,
														"rightExpression": {
															"expressionType": 2,
															"parameter": {
																"dataValueType": 12,
																"value": false
															}
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Lead"
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
								"type": "bar",
								"label": "#ResourceString(crtChartWidget9b2f05a98df0a36b1366334a92e4b0e2_series_2)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"e61225c5-2b43-41eb-bb6d-e576e1beb16a": {
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
															"macrosType": 19
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
								"color": "violet",
								"type": "bar",
								"label": "#ResourceString(crtChartWidget9b2f05a98df0a36b1366334a92e4b0e2_series_3)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"e61225c5-2b43-41eb-bb6d-e576e1beb16a": {
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
															"macrosType": 19
														}
													},
													"8976d775-2f1e-4964-9434-e8d6db59f6c0": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Stage"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "OpportunityStage",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Closed won",
																		"Id": "60d5310c-5be6-df11-971b-001d60e938c6",
																		"value": "60d5310c-5be6-df11-971b-001d60e938c6",
																		"displayValue": "Closed won"
																	}
																}
															}
														]
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"index": 13
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget5497c710-c0aa-db1a-7963-04dcd939fd5f",
				"values": {
					"layoutConfig": {
						"row": 16,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget5497c710c0aadb1a796304dcd939fd5f_title)#",
						"data": {
							"providing": {
								"schemaName": "ContactForecast",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Value"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"748162da-d1f4-45a6-91bd-8d1494cddb05": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ForecastColumn"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "ForecastColumn",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Expected",
																"Id": "f0a300db-27df-40ae-8fe0-0ebfd63609cc",
																"value": "f0a300db-27df-40ae-8fe0-0ebfd63609cc",
																"displayValue": "Expected"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Expected",
																"Id": "430f9f9b-30d8-4b14-8c83-6b818206bc63",
																"value": "430f9f9b-30d8-4b14-8c83-6b818206bc63",
																"displayValue": "Expected"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Expected",
																"Id": "c0548377-62b0-4506-9f72-c4af2416d787",
																"value": "c0548377-62b0-4506-9f72-c4af2416d787",
																"displayValue": "Expected"
															}
														}
													}
												]
											},
											"a3e18a07-9988-4712-827e-919731ffeb23": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Period"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Period",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "1st quarter of 2021",
																"Id": "38579c2d-4e22-4383-a026-78f6994788df",
																"value": "38579c2d-4e22-4383-a026-78f6994788df",
																"displayValue": "1st quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "2nd quarter of 2021",
																"Id": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																"value": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																"displayValue": "2nd quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "3rd quarter of 2021",
																"Id": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																"value": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																"displayValue": "3rd quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "4th quarter of 2021",
																"Id": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																"value": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																"displayValue": "4th quarter of 2021"
															}
														}
													}
												]
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "ContactForecast"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget5497c710c0aadb1a796304dcd939fd5f_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 14
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget6d547146-b391-fc45-bc26-c96dd5bc1549",
				"values": {
					"layoutConfig": {
						"row": 16,
						"rowSpan": 6,
						"column": 4,
						"colSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget6d547146b391fc45bc26c96dd5bc1549_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "green",
								"type": "horizontal-bar",
								"label": "#ResourceString(crtChartWidget6d547146b391fc45bc26c96dd5bc1549_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "ContactForecast",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Period"
												}
											},
											"type": "by-value"
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
														"columnPath": "Value"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"707ece83-01f0-4822-96ae-75ae4411453b": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "ForecastColumn"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "ForecastColumn",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Title": "Expected",
																		"Id": "f0a300db-27df-40ae-8fe0-0ebfd63609cc",
																		"value": "f0a300db-27df-40ae-8fe0-0ebfd63609cc",
																		"displayValue": "План"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Title": "Expected",
																		"Id": "430f9f9b-30d8-4b14-8c83-6b818206bc63",
																		"value": "430f9f9b-30d8-4b14-8c83-6b818206bc63",
																		"displayValue": "План"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Title": "Expected",
																		"Id": "c0548377-62b0-4506-9f72-c4af2416d787",
																		"value": "c0548377-62b0-4506-9f72-c4af2416d787",
																		"displayValue": "План"
																	}
																}
															}
														]
													},
													"8a32455e-c410-409a-870e-02c127f49065": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Period"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "Period",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "1st quarter of 2021",
																		"Id": "38579c2d-4e22-4383-a026-78f6994788df",
																		"value": "38579c2d-4e22-4383-a026-78f6994788df",
																		"displayValue": "1-й квартал 2021"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "2nd quarter of 2021",
																		"Id": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																		"value": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																		"displayValue": "2-й квартал 2021"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "3rd quarter of 2021",
																		"Id": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																		"value": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																		"displayValue": "3-й квартал 2021"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "4th quarter of 2021",
																		"Id": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																		"value": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																		"displayValue": "4-Й квартал 2021"
																	}
																}
															}
														]
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "ContactForecast"
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
								"color": "celestial-blue",
								"type": "horizontal-bar",
								"label": "#ResourceString(crtChartWidget6d547146b391fc45bc26c96dd5bc1549_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "ContactForecast",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Period"
												}
											},
											"type": "by-value"
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
														"columnPath": "Value"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"707ece83-01f0-4822-96ae-75ae4411453b": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "ForecastColumn"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "ForecastColumn",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Title": "Actual",
																		"Id": "30931e69-f505-4abb-81e1-1e1711846837",
																		"value": "30931e69-f505-4abb-81e1-1e1711846837",
																		"displayValue": "Факт"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Title": "Actual",
																		"Id": "7dc7e50b-0e0b-4e44-b4fa-98d285f50111",
																		"value": "7dc7e50b-0e0b-4e44-b4fa-98d285f50111",
																		"displayValue": "Факт"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Title": "Actual",
																		"Id": "1d2d596e-cede-474a-9c9c-d128b92e89dd",
																		"value": "1d2d596e-cede-474a-9c9c-d128b92e89dd",
																		"displayValue": "Факт"
																	}
																}
															}
														]
													},
													"8a32455e-c410-409a-870e-02c127f49065": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Period"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "Period",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "1st quarter of 2021",
																		"Id": "38579c2d-4e22-4383-a026-78f6994788df",
																		"value": "38579c2d-4e22-4383-a026-78f6994788df",
																		"displayValue": "1-й квартал 2021"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "2nd quarter of 2021",
																		"Id": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																		"value": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																		"displayValue": "2-й квартал 2021"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "3rd quarter of 2021",
																		"Id": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																		"value": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																		"displayValue": "3-й квартал 2021"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "4th quarter of 2021",
																		"Id": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																		"value": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																		"displayValue": "4-й квартал 2021"
																	}
																}
															}
														]
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "ContactForecast"
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
							"type": "by-aggregation-value",
							"direction": 1,
							"seriesIndex": 0
						}
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 15
			},
			{
				"operation": "insert",
				"name": "crt.FunnelWidgete70bcb34-7a6c-5866-09ff-dfc02443c9f6",
				"values": {
					"layoutConfig": {
						"row": 16,
						"rowSpan": 12,
						"column": 8,
						"colSpan": 5
					},
					"type": "crt.FunnelWidget",
					"config": {
						"title": "#ResourceString(crtFunnelWidgete70bcb347a6c586609ffdfc02443c9f6_title)#",
						"color": "blue",
						"entities": [
							{
								"schemaName": "Opportunity",
								"calculatedOperations": [
									{
										"operation": "Amount",
										"targetColumnName": "Budget"
									}
								],
								"connectedWith": null,
								"filters": {
									"items": {},
									"logicalOperation": 0,
									"isEnabled": true,
									"filterType": 6,
									"rootSchemaName": "Opportunity"
								}
							}
						]
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 16
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidgetf9ae3759-c038-1b74-8139-368bb503e99d",
				"values": {
					"layoutConfig": {
						"row": 18,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetf9ae3759c0381b748139368bb503e99d_title)#",
						"data": {
							"providing": {
								"schemaName": "ContactForecast",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Value"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"e5855d63-bf12-4a80-8922-de6f8a6a05fa": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ForecastColumn"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "ForecastColumn",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Actual",
																"Id": "30931e69-f505-4abb-81e1-1e1711846837",
																"value": "30931e69-f505-4abb-81e1-1e1711846837",
																"displayValue": "Actual"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Actual",
																"Id": "7dc7e50b-0e0b-4e44-b4fa-98d285f50111",
																"value": "7dc7e50b-0e0b-4e44-b4fa-98d285f50111",
																"displayValue": "Actual"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Actual",
																"Id": "1d2d596e-cede-474a-9c9c-d128b92e89dd",
																"value": "1d2d596e-cede-474a-9c9c-d128b92e89dd",
																"displayValue": "Actual"
															}
														}
													}
												]
											},
											"6ec9e9d4-de19-46f1-876b-c90e4da6dcd1": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Period"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Period",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "1st quarter of 2021",
																"Id": "38579c2d-4e22-4383-a026-78f6994788df",
																"value": "38579c2d-4e22-4383-a026-78f6994788df",
																"displayValue": "1st quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "2nd quarter of 2021",
																"Id": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																"value": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																"displayValue": "2nd quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "3rd quarter of 2021",
																"Id": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																"value": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																"displayValue": "3rd quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "4th quarter of 2021",
																"Id": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																"value": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																"displayValue": "4th quarter of 2021"
															}
														}
													}
												]
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "ContactForecast"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidgetf9ae3759c0381b748139368bb503e99d_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 17
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget2ab0d21f-dcc0-7efa-ae36-847aab272f71",
				"values": {
					"layoutConfig": {
						"row": 20,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget2ab0d21fdcc07efaae36847aab272f71_title)#",
						"data": {
							"providing": {
								"schemaName": "ContactForecast",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 3,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Value"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"8cfaa2a0-da9f-4040-a124-7536a9c9f4cf": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ForecastColumn"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "ForecastColumn",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Actual, %",
																"Id": "5e33c5a7-619d-455f-b5d6-b2e5c6467719",
																"value": "5e33c5a7-619d-455f-b5d6-b2e5c6467719",
																"displayValue": "Actual, %"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Actual, %",
																"Id": "e84702ad-ae9e-474b-910d-cf8148803ff1",
																"value": "e84702ad-ae9e-474b-910d-cf8148803ff1",
																"displayValue": "Actual, %"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Title": "Actual, %",
																"Id": "69b8bd22-3869-4b2b-9892-dc576e3a9408",
																"value": "69b8bd22-3869-4b2b-9892-dc576e3a9408",
																"displayValue": "Actual, %"
															}
														}
													}
												]
											},
											"bd557f90-3ef7-455c-ad50-519124d204df": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Period"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Period",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "1st quarter of 2021",
																"Id": "38579c2d-4e22-4383-a026-78f6994788df",
																"value": "38579c2d-4e22-4383-a026-78f6994788df",
																"displayValue": "1st quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "2nd quarter of 2021",
																"Id": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																"value": "786af432-6de5-4c6e-83e9-30777d3e8bb5",
																"displayValue": "2nd quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "3rd quarter of 2021",
																"Id": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																"value": "c3a58bc1-84ec-4620-a9b0-44f55e7338fc",
																"displayValue": "3rd quarter of 2021"
															}
														}
													},
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "4th quarter of 2021",
																"Id": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																"value": "b5a47acf-86b4-496e-abe8-edcd375a980b",
																"displayValue": "4th quarter of 2021"
															}
														}
													}
												]
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "ContactForecast"
									}
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidget2ab0d21fdcc07efaae36847aab272f71_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "black"
						},
						"theme": "without-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 18
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget8c018a43-f355-4753-154f-ef8b06b5737b",
				"values": {
					"layoutConfig": {
						"row": 22,
						"rowSpan": 6,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget8c018a43f3554753154fef8b06b5737b_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "celestial-blue",
								"type": "horizontal-bar",
								"label": "#ResourceString(crtChartWidget8c018a43f3554753154fef8b06b5737b_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Lead",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"95cf208f-0e8c-4460-9708-b5ad67d7ab1a": {
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
															"macrosType": 19
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Lead"
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
				"index": 19
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget42906ad5-4155-9640-0295-bb98c7790c46",
				"values": {
					"layoutConfig": {
						"row": 22,
						"rowSpan": 6,
						"column": 4,
						"colSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget42906ad5415596400295bb98c7790c46_title)#",
						"color": "blue",
						"theme": "full-fill",
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
								"color": "celestial-blue",
								"type": "horizontal-bar",
								"label": "#ResourceString(crtChartWidget42906ad5415596400295bb98c7790c46_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Opportunity",
										"rowCount": 50,
										"grouping": {
											"column": [
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
												},
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 4,
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
													"c8e0b394-4393-4565-a6ac-06f2041ca465": {
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
															"macrosType": 19
														}
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Opportunity"
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
				"index": 20
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/
	};
});
