define("MarketingHomePage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		"viewConfigDiff": /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget76003462-724c-35d3-1805-b63c6bd265f2",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 3,
						"rowSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget76003462724c35d31805b63c6bd265f2_title)#",
						"data": {
							"providing": {
								"schemaName": "CampaignPlanner",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "PlannedBudget"
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
										"rootSchemaName": "CampaignPlanner"
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
							"template": "#ResourceString(crtIndicatorWidget76003462724c35d31805b63c6bd265f2_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "celestial-blue"
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
				"name": "crt.ChartWidget1ca09c1a-1936-6f75-1fd9-0815a0ca4567",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 7,
						"column": 4,
						"colSpan": 5
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget1ca09c1a19366f751fd90815a0ca4567_title)#",
						"color": "blue",
						"theme": "without-fill",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidget1ca09c1a19366f751fd90815a0ca4567_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "MktgActivity",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Channel"
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
														"columnPath": "SpentBudget"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Channel"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "MktgActivity"
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
				"index": 1
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget03267900-6c82-fcfb-b531-ff6e5ec24fec",
				"values": {
					"layoutConfig": {
						"column": 9,
						"row": 1,
						"colSpan": 4,
						"rowSpan": 7
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget032679006c82fcfbb531ff6e5ec24fec_title)#",
						"color": "blue",
						"theme": "without-fill",
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
								"label": "#ResourceString(crtChartWidget032679006c82fcfbb531ff6e5ec24fec_series_0)#",
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
														"datePartType": 3,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "[CampaignParticipant:Contact].Campaign.StartDate",
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
															"columnPath": "[CampaignParticipant:Contact].Campaign.StartDate",
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
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "[CampaignParticipant:Contact].Campaign.StartDate"
														}
													}
												},
												"logicalOperation": 0,
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
								"style": "orange",
								// "style": "green",
								"type": "bar",
								"label": "#ResourceString(crtChartWidget032679006c82fcfbb531ff6e5ec24fec_series_1)#",
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
				"index": 2
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidgetf31e2dc7-3d33-b8f6-4bd6-d71625236ac1",
				"values": {
					"layoutConfig": {
						"row": 3,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetf31e2dc73d33b8f64bd6d71625236ac1_title)#",
						"data": {
							"providing": {
								"schemaName": "CampaignPlanner",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "PrimarySpentBudget"
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
										"rootSchemaName": "CampaignPlanner"
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
							"template": "#ResourceString(crtIndicatorWidgetf31e2dc73d33b8f64bd6d71625236ac1_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "celestial-blue"
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
				"name": "crt.IndicatorWidget2418d31e-a322-2448-3ec9-e8684921d6ea",
				"values": {
					"layoutConfig": {
						"row": 5,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget2418d31ea32224483ec9e8684921d6ea_title)#",
						"data": {
							"providing": {
								"schemaName": "BulkEmail",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "SendCount"
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
										"rootSchemaName": "BulkEmail"
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
							"template": "#ResourceString(crtIndicatorWidget2418d31ea32224483ec9e8684921d6ea_template)#",
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
				"index": 4
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget906aac6d-9c70-3bdb-a5ff-9f5501b3938f",
				"values": {
					"layoutConfig": {
						"row": 7,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget906aac6d9c703bdba5ff9f5501b3938f_title)#",
						"data": {
							"providing": {
								"schemaName": "BulkEmail",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 2,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "DeliveredCount"
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
										"rootSchemaName": "BulkEmail"
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
							"template": "#ResourceString(crtIndicatorWidget906aac6d9c703bdba5ff9f5501b3938f_template)#",
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
				"index": 5
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetdd155a15-6359-5aa6-895a-cb50cc5af4d2",
				"values": {
					"layoutConfig": {
						"row": 8,
						"rowSpan": 5,
						"column": 4,
						"colSpan": 5
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetdd155a1563595aa6895acb50cc5af4d2_title)#",
						"color": "blue",
						"theme": "without-fill",
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
								"color": "orange",
								"type": "spline",
								"label": "#ResourceString(crtChartWidgetdd155a1563595aa6895acb50cc5af4d2_series_0)#",
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
													"1b39ae18-3b7c-480d-97b4-7adf6dce6afd": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "LeadSource"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "LeadSource",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "BPMStudio marketing",
																		"Id": "4f7f26f5-facc-47d4-900b-9d9b1eb1c505",
																		"value": "4f7f26f5-facc-47d4-900b-9d9b1eb1c505",
																		"displayValue": "BPMStudio marketing"
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
								"type": "spline",
								"label": "#ResourceString(crtChartWidgetdd155a1563595aa6895acb50cc5af4d2_series_2)#",
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
													"32fc7e34-c9c3-424c-84c6-086820c4b563": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "LeadSource"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "LeadSource",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Google",
																		"Id": "a417d1e3-2029-4c17-8e15-c6a586d1a9b7",
																		"value": "a417d1e3-2029-4c17-8e15-c6a586d1a9b7",
																		"displayValue": "Google"
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
								"color": "dark-green",
								"type": "spline",
								"label": "#ResourceString(crtChartWidgetdd155a1563595aa6895acb50cc5af4d2_series_5)#",
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
													"5da90680-470d-4962-978b-cd2dd09b3c90": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "LeadSource"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "LeadSource",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Other source",
																		"Id": "f5e73b24-bd68-45ba-9ec6-dee40a35c615",
																		"value": "f5e73b24-bd68-45ba-9ec6-dee40a35c615",
																		"displayValue": "Other source"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Twitter",
																		"Id": "2c97826d-18ab-4e12-9e91-60a709315444",
																		"value": "2c97826d-18ab-4e12-9e91-60a709315444",
																		"displayValue": "Twitter"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Vkontakte",
																		"Id": "567c32ed-e42c-4815-a7ac-3e3bbf7bd77d",
																		"value": "567c32ed-e42c-4815-a7ac-3e3bbf7bd77d",
																		"displayValue": "Vkontakte"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Yandex",
																		"Id": "3c133642-8dbc-4f6c-a0c3-c4a0c4c0aab8",
																		"value": "3c133642-8dbc-4f6c-a0c3-c4a0c4c0aab8",
																		"displayValue": "Yandex"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Yandex.Direct",
																		"Id": "339fbdd8-2ca0-4a40-98a5-1b4b96a01661",
																		"value": "339fbdd8-2ca0-4a40-98a5-1b4b96a01661",
																		"displayValue": "Yandex.Direct"
																	}
																}
															},
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Google AdWords",
																		"Id": "6177c15b-5439-4c60-ba46-4d2eb201270e",
																		"value": "6177c15b-5439-4c60-ba46-4d2eb201270e",
																		"displayValue": "Google AdWords"
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
				"index": 6
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetb2ba2e95-2022-0457-e9e2-1dd267a27ef6",
				"values": {
					"layoutConfig": {
						"row": 8,
						"rowSpan": 5,
						"column": 9,
						"colSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetb2ba2e9520220457e9e21dd267a27ef6_title)#",
						"color": "blue",
						"theme": "without-fill",
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
								"color": "light-blue",
								"type": "horizontal-bar",
								"label": "#ResourceString(crtChartWidgetb2ba2e9520220457e9e21dd267a27ef6_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "CampaignParticipant",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Campaign"
												}
											},
											"type": "by-value"
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
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Campaign"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "CampaignParticipant"
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
							"direction": 2,
							"seriesIndex": 0
						}
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget7a6f5c28-4436-4fd7-06e6-456a0fbbfb8a",
				"values": {
					"layoutConfig": {
						"row": 9,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget7a6f5c2844364fd706e6456a0fbbfb8a_title)#",
						"data": {
							"providing": {
								"schemaName": "BulkEmail",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 3,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Opens"
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
										"rootSchemaName": "BulkEmail"
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
							"template": "#ResourceString(crtIndicatorWidget7a6f5c2844364fd706e6456a0fbbfb8a_template)#",
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
				"index": 8
			},
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget797789e5-52e7-7d0c-9ba0-363314051e37",
				"values": {
					"layoutConfig": {
						"row": 11,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget797789e552e77d0c9ba0363314051e37_title)#",
						"data": {
							"providing": {
								"schemaName": "BulkEmail",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 3,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Clicks"
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
										"rootSchemaName": "BulkEmail"
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
							"template": "#ResourceString(crtIndicatorWidget797789e552e77d0c9ba0363314051e37_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "red"
						},
						"theme": "full-fill"
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 9
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetb80d9519-3681-14c2-16e0-377b63db285c",
				"values": {
					"layoutConfig": {
						"row": 13,
						"rowSpan": 5,
						"column": 1,
						"colSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetb80d9519368114c216e0377b63db285c_title)#",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidgetb80d9519368114c216e0377b63db285c_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Lead",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "LeadSource"
												}
											},
											"type": "by-value"
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
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "LeadSource"
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
				"index": 10
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget964db88e-cf83-2d2d-0f3a-02eb2f8856f4",
				"values": {
					"layoutConfig": {
						"column": 5,
						"row": 13,
						"colSpan": 4,
						"rowSpan": 5
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget964db88ecf832d2d0f3a02eb2f8856f4_title)#",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidget964db88ecf832d2d0f3a02eb2f8856f4_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Lead",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Region"
												}
											},
											"type": "by-value"
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
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Region"
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
				"index": 11
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidgetc7095e73-e779-dd43-a7a8-add2fcf15c5c",
				"values": {
					"layoutConfig": {
						"column": 9,
						"row": 13,
						"colSpan": 4,
						"rowSpan": 5
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetc7095e73e779dd43a7a8add2fcf15c5c_title)#",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidgetc7095e73e779dd43a7a8add2fcf15c5c_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Lead",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Industry"
												}
											},
											"type": "by-value"
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
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Industry"
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
				"index": 12
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget399cc321-3bad-7c1e-a175-bbce18f80361",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 18,
						"colSpan": 12,
						"rowSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget399cc3213bad7c1ea175bbce18f80361_title)#",
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
								"color": "violet",
								"type": "bar",
								"label": "#ResourceString(crtChartWidget399cc3213bad7c1ea175bbce18f80361_series_0)#",
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
													"3c8911c1-ea0d-4d75-ad2b-83565f46d44e": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "QualifyStatus"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "QualifyStatus",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Disqualified",
																		"Id": "128c3718-771a-4d1e-9035-6fa135ca5f70",
																		"value": "128c3718-771a-4d1e-9035-6fa135ca5f70",
																		"displayValue": "Disqualified"
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
								"color": "light-blue",
								"type": "line",
								"label": "#ResourceString(crtChartWidget399cc3213bad7c1ea175bbce18f80361_series_1)#",
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
													"ce326f49-8f67-40b1-8085-f8e692434fc6": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "QualifyStatus"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "QualifyStatus",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Satisfied",
																		"Id": "0a0808c5-5415-41f0-bea3-118cc3089959",
																		"value": "0a0808c5-5415-41f0-bea3-118cc3089959",
																		"displayValue": "Satisfied"
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
				"index": 13
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/
	};
});
