define("ProcessSchemaParameterViewConfig", [
	"ProcessSchemaParameterViewConfigResources",
	"css!ProcessSchemaParameterViewConfig"
], function(resources) {

	Ext.define("BPMSoft.ProcessSchemaParameterViewConfig", {
		extend: "BPMSoft.BaseObject",

		statics: {

			/**
			 * Generates process schema parameter view config.
			 * @param {String} [idPrefix] Prefix in generated id of elements.
			 * @returns {Object}
			 */
			generate: function(idPrefix) {
				if (Ext.isEmpty(idPrefix)) {
					idPrefix = "";
				}
				return {
					"id": "item",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"markerValue": "$MarkerValue",
					"items": [{
						"id": idPrefix + "item-view",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": "$MarkerValue",
						"visible": {
							"bindTo": "Visible"
						},
						"wrapClass": ["parameter-ct"],
						"items": [{
							"id": idPrefix + "ParameterImagesContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"markerValue": "$MarkerValue",
							"items": [{
								"id": idPrefix + "parameter-images",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"markerValue": "$MarkerValue",
								"wrapClass": ["parameter-datavaluetype-ct"],
								"items": [{
									"id": "ParameterDataValueType",
									"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
									"readonly": true,
									"markerValue": "$MarkerValue",
									"imageSrc": {
										"bindTo": "DataValueTypeImage"
									},
									"name": "ParameterDataValueType"
								}, {
									"id": "ParameterDirection",
									"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
									"readonly": true,
									"markerValue": "$MarkerValue",
									"visible": {
										"bindTo": "getCanShowParameterDirection"
									},
									"imageSrc": {
										"bindTo": "DirectionImage"
									},
									"imageContainerClasses": ["parameter-direction"],
									"name": "ParameterDirection"
								}],
								"name": "parameterDirection"
							}],
							"name": "parameterImagesContainer"
						}, {
							"id": idPrefix + "ParameterValueContainer",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["parameter-value-ct", "placeholderOpacity"],
							"markerValue": "$MarkerValue",
							"items": [{
								"id": "ParameterToolsContainer",
								"itemType": BPMSoft.ViewItemType.CONTAINER,
								"markerValue": "$MarkerValue",
								"wrapClass": ["tools-container-wrapClass"],
								"items": [{
									"id": "LabelWrap",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"markerValue": "$MarkerValue",
									"wrapClass": ["label-container-wrapClass"],
									"items": [{
										"id": "ParameterCaption",
										"itemType": BPMSoft.ViewItemType.LABEL,
										"caption": {
											"bindTo": "Caption"
										},
										"tag": {
											"containerId": idPrefix + "item-edit"
										},
										"isRequired": {
											"bindTo": "IsRequired"
										},
										"classes": {
											"labelClass": ["t-label-proc-param", "label-link"]
										},
										"click": {
											"bindTo": "onParameterLabelClick"
										},
										"name": "ParameterCaption"
									}],
									"name": "LabelWrap"
								}, {
									"id": idPrefix + "ToolsButtonWrap",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"markerValue": "$MarkerValue",
									"wrapClass": ["tools-button-container-wrapClass"],
									"items": [{
										"id": "ParameterEditToolsButton",
										"itemType": BPMSoft.ViewItemType.BUTTON,
										"style": "transparent",
										"imageConfig": {
											"source": 3,
											"params": {
												"schemaName": "ProcessFlowElementPropertiesPage",
												"resourceItemName": "ParameterEditToolsButtonImage",
												"hash": "df03c3177a972b7f3b6987430f988ca3"
											}
										},
										"menu": {
											"items": {
												"bindTo": "ParameterEditToolsButtonMenu"
											}
										},
										"classes": {
											"imageClass": ["button-background-no-repeat"],
											"wrapperClass": ["detail-tools-button-wrapper"],
											"menuClass": ["detail-tools-button-menu"]
										},
										"name": "ParameterEditToolsButton"
									}
									],
									"name": "ToolsButtonWrap"
								}
								],
								"name": "ParameterToolsContainer"
							},
							{
								"id": idPrefix + "Value",
								"itemType": BPMSoft.ViewItemType.COMPONENT,
								"className": "BPMSoft.MappingEdit",
								"visible": {
									"bindTo": "getShouldShowValueControl"
								},
								"value": { "bindTo": "Value" },
								"enabled": { "bindTo": "CanAssignSourceValue" },
								"isRequired": { "bindTo": "IsRequired" },
								"openEditWindow": { "bindTo": "openExtendedMappingEditWindow" },
								"prepareMenu": { "bindTo": "onPrepareMenu" },
								"tag": "Value",
								"menu": {
									"items": {
										"bindTo": "MenuItems"
									}
								},
								"placeholder": resources.localizableStrings.MappingPlaceholderCaption,
								"name": "Value",
								"cleariconclick": "$onClearIconClick"
							}
							],
							"name": "ParameterValueContainer"
						}
						],
						"name": "itemView"
					}, {
						"id": idPrefix + "item-edit",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"markerValue": "$MarkerValue",
						"visible": {
							"bindTo": "Visible",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
						"wrapClass": ["parameter-edit-ct"],
						"items": [],
						"name": "itemEdit"
					}, {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"collapsed": "$HideNestedItems",
						"caption": "$ControlGroupCaption",
						"id": "nested-control-group",
						"name": "nestedControlGroup",
						"tag": "nestedControlGroup",
						"items": [{
							"id": idPrefix + "nested-item-add",
							"name": "addNestedParameter",
							"caption": resources.localizableStrings.AddNesstedParameterCaption,
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"imageConfig": resources.localizableImages.AddButtonImage,
							"classes": { "wrapperClass": ["nested-parameters", "nested-parameters-add"] },
							"visible": "$CanAddNestedItems",
							"enabled": {
								"bindTo": "IsNestedParameterEditPageOpened",
								"bindConfig": {
									"converter": "invertBooleanValue"
								}
							},
							"menu": {
								"items": {
									"bindTo": "AddButtonMenu"
								}
							}
						},{
							"id": "nested-parameters",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"markerValue": "$MarkerValue",
							"wrapClass": ["nested-parameters"],
							"items": []
						}],
						"visible": {
							"bindTo": "getShouldShowNestedItems"
						}
					}],
					"visible": "$isAvailable",
					"name": "parameterItem"
				};
			},

			/**
			 * Returns container view config.
			 * @param {String} id Container ID.
			 * @param {Array} wrapClassName Wrap class name.
			 * @param {Array} items Child items.
			 * @param {Object} [visible] Flag that indicates container visibility.
			 * @return {Object} Container config.
			 */
			getContainerConfig: function(id, wrapClassName, items, visible) {
				const container = {
					className: "BPMSoft.Container",
					id: id,
					selectors: {wrapEl: "#" + id},
					items: items || [],
					visible: Ext.isObject(visible) ? visible : true
				};
				if (!Ext.isEmpty(wrapClassName)) {
					container.classes = {
						wrapClassName: wrapClassName
					};
				}
				return container;
			},

			/**
			 * Returns basic mapping edit configuration for parameter.
			 */
			getParameterMappingEditBaseConfig: function() {
				return {
					isRequired: {
						bindTo: "IsRequired"
					},
					placeholder: resources.localizableStrings.MappingPlaceholderCaption
				};
			}

		}

	});

	return BPMSoft.ProcessSchemaParameterViewConfig;

});
