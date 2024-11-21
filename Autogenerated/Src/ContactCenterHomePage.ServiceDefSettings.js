define("ContactCenterHomePage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		"viewConfigDiff": /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "crt.IndicatorWidget3967fb6c-1eae-87de-a92a-309c74d4194d",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 1,
						"colSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget3967fb6c1eae87dea92a309c74d4194d_title)#",
						"data": {
							"providing": {
								"schemaName": "Case",
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
											"38846652-2771-4393-815f-8ddc9c2098a3": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Owner"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Contact",
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 2
												}
											},
											"77741142-515d-440d-bcc0-e83f3e6c07c7": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Status.IsResolved"
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
											"b31ed3f0-894e-4931-a6e4-575e1c1ee25c": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Status.IsFinal"
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
										"rootSchemaName": "Case"
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
							"template": "#ResourceString(crtIndicatorWidget3967fb6c1eae87dea92a309c74d4194d_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "dark-turquoise"
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
				"name": "crt.IndicatorWidgetef54470f-777d-cae1-0816-84e6aaa2c389",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 3,
						"colSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetef54470f777dcae1081684e6aaa2c389_title)#",
						"data": {
							"providing": {
								"schemaName": "Case",
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
											"7d35028d-f217-48a1-bec7-4c9d7745487d": {
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
												"referenceSchemaName": "CaseStatus",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Waiting for response",
																"IsFinal": false,
																"Id": "3859c6e7-cbcb-486b-ba53-77808fe6e593",
																"Image": "",
																"value": "3859c6e7-cbcb-486b-ba53-77808fe6e593",
																"displayValue": "Waiting for response"
															}
														}
													}
												]
											},
											"66fb695d-a02d-4a91-94d7-a3d06bf3b114": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Owner"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Contact",
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 2
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Case"
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
							"template": "#ResourceString(crtIndicatorWidgetef54470f777dcae1081684e6aaa2c389_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "dark-turquoise"
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
				"name": "crt.IndicatorWidgetd49c93e9-3a93-a771-85ef-130cf5a692c1",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 5,
						"colSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetd49c93e93a93a77185ef130cf5a692c1_title)#",
						"data": {
							"providing": {
								"schemaName": "Case",
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
											"045544b2-49bc-42ab-9f52-cf5a9278a967": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Owner"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Contact",
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 2
												}
											},
											"2bcd8ed1-ccde-4f56-8a20-28d16ba5467a": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": true,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "SolutionProvidedOn"
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
										"rootSchemaName": "Case"
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
							"template": "#ResourceString(crtIndicatorWidgetd49c93e93a93a77185ef130cf5a692c1_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "dark-turquoise"
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
				"name": "crt.IndicatorWidget7d69b944-e372-5f03-bebe-564967e73fde",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 7,
						"colSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidget7d69b944e3725f03bebe564967e73fde_title)#",
						"data": {
							"providing": {
								"schemaName": "Case",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 3,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "SatisfactionLevel.Point"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"9d4d903f-f174-45f2-8d18-65e2e766cd0c": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Owner"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Contact",
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 2
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Case"
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
							"template": "#ResourceString(crtIndicatorWidget7d69b944e3725f03bebe564967e73fde_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "dark-turquoise"
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
				"name": "crt.IndicatorWidgete5431195-3d1c-11e3-6252-9e284250181f",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 9,
						"colSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgete54311953d1c11e362529e284250181f_title)#",
						"data": {
							"providing": {
								"schemaName": "Call",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 3,
											"aggregationEvalType": 0,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Duration"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"c5f88028-e1e7-4f33-a872-0eabdf3324c6": {
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
													"macrosType": 7
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Call"
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
							"template": "#ResourceString(crtIndicatorWidgete54311953d1c11e362529e284250181f_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "dark-turquoise"
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
				"name": "crt.IndicatorWidgetfd860957-37d5-108a-5f2b-d617a5927f0e",
				"values": {
					"layoutConfig": {
						"row": 1,
						"rowSpan": 2,
						"column": 11,
						"colSpan": 2
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(crtIndicatorWidgetfd86095737d5108a5f2bd617a5927f0e_title)#",
						"data": {
							"providing": {
								"schemaName": "Activity",
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
											"15deb25d-d373-424c-b1b0-a928923abf17": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ActivityCategory"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "ActivityCategory",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Email",
																"Id": "8038a396-7825-e011-8165-00155d043204",
																"value": "8038a396-7825-e011-8165-00155d043204",
																"displayValue": "Email"
															}
														}
													}
												]
											},
											"c63d08df-5613-4b8e-bde4-e2d24b2de0ff": {
												"filterType": 1,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "CreatedBy"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "Contact",
												"rightExpression": {
													"expressionType": 1,
													"functionType": 1,
													"macrosType": 2
												}
											}
										},
										"logicalOperation": 0,
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
						},
						"text": {
							"template": "#ResourceString(crtIndicatorWidgetfd86095737d5108a5f2bd617a5927f0e_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "dark-turquoise"
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
				"name": "crt.ChartWidget2709e252-60fe-e39e-4e4d-6a1cecdd7e34",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 4,
						"rowSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget2709e25260fee39e4e4d6a1cecdd7e34_title)#",
						"color": "dark-turquoise",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidget2709e25260fee39e4e4d6a1cecdd7e34_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Case",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Status"
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
															"columnPath": "Status"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Case"
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
				"name": "crt.ChartWidgeta481328f-c811-4227-3189-008e01653ebf",
				"values": {
					"layoutConfig": {
						"row": 3,
						"rowSpan": 4,
						"column": 5,
						"colSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgeta481328fc81142273189008e01653ebf_title)#",
						"color": "dark-turquoise",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidgeta481328fc81142273189008e01653ebf_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Case",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Status"
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
													"3fd3e62b-4fe8-41d2-af73-605f4a0b2dc5": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Status.IsResolved"
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
													"1d3f5253-c9d0-4e21-bb38-7bd14f5648ce": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Status.IsFinal"
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
															"columnPath": "Status"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Case"
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
				"name": "crt.ChartWidgetdad38bed-0482-bae2-242b-d17b35779e45",
				"values": {
					"layoutConfig": {
						"row": 3,
						"rowSpan": 4,
						"column": 9,
						"colSpan": 4
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidgetdad38bed0482bae2242bd17b35779e45_title)#",
						"color": "dark-turquoise",
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
								"type": "doughnut",
								"label": "#ResourceString(crtChartWidgetdad38bed0482bae2242bd17b35779e45_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Case",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Priority"
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
													"d97963b6-f48c-46b3-bf89-16afb51b1b30": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Status.IsResolved"
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
													"1a1c2443-9e44-4505-9d83-6b68508fd5ec": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Status.IsFinal"
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
															"columnPath": "Priority"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Case"
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
				"index": 8
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget196acc26-ccef-8b4a-83cb-f85032871740",
				"values": {
					"layoutConfig": {
						"row": 7,
						"rowSpan": 5,
						"column": 1,
						"colSpan": 5
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget196acc26ccef8b4a83cbf85032871740_title)#",
						"color": "dark-turquoise",
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
								"color": "purple",
								"type": "line",
								"label": "#ResourceString(crtChartWidget196acc26ccef8b4a83cbf85032871740_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "Case",
										"rowCount": 50,
										"grouping": {
											"column": {
												"expression": {
													"expressionType": 0,
													"columnPath": "Owner"
												}
											},
											"type": "by-value"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 3,
													"aggregationEvalType": 0,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "SatisfactionLevel.Point"
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
															"columnPath": "Owner"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Case"
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
				"index": 9
			},
			{
				"operation": "insert",
				"name": "crt.ChartWidget9726d63a-71a0-3c6c-ddd8-66837466bf2b",
				"values": {
					"layoutConfig": {
						"row": 7,
						"rowSpan": 5,
						"column": 6,
						"colSpan": 7
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(crtChartWidget9726d63a71a03c6cddd866837466bf2b_title)#",
						"color": "dark-turquoise",
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
								"color": "dark-turquoise",
								"type": "line",
								"label": "#ResourceString(crtChartWidget9726d63a71a03c6cddd866837466bf2b_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Case",
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
															"columnPath": "SolutionProvidedOn",
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
															"columnPath": "SolutionProvidedOn",
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
															"columnPath": "SolutionProvidedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Case"
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
								"color": "coral",
								"type": "line",
								"label": "#ResourceString(crtChartWidget9726d63a71a03c6cddd866837466bf2b_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "OmniChat",
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
															"columnPath": "CompletionDate",
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
															"columnPath": "CompletionDate",
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
															"columnPath": "CompletionDate"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "OmniChat"
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
								"type": "line",
								"label": "#ResourceString(crtChartWidget9726d63a71a03c6cddd866837466bf2b_series_2)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"schemaName": "Call",
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
															"columnPath": "StartDate",
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
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "StartDate"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Call"
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
								"color": "orange",
								"type": "line",
								"label": "#ResourceString(crtChartWidget9726d63a71a03c6cddd866837466bf2b_series_3)#",
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
													"b4937f5c-789f-4037-aa5d-49565399d256": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "ActivityCategory"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "ActivityCategory",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Email",
																		"Id": "8038a396-7825-e011-8165-00155d043204",
																		"value": "8038a396-7825-e011-8165-00155d043204",
																		"displayValue": "Email"
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
				"index": 10
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/
	};
});
