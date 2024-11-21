define("MacrosListDetailModule", ["StructureExplorerUtilities", "MacrosListDetailModuleResources",
		"css!MacrosListDetailModule"],
	function(StructureExplorerUtilities, resources) {
		function getIcon(iconName) {
			const resourceImage = resources.localizableImages[iconName];
			return BPMSoft.ImageUrlBuilder.getUrl(resourceImage);
		}

		Ext.define("BPMSoft.configuration.WordPrintableMacrosViewModel", {
			alternateClassName: "BPMSoft.WordPrintableMacrosViewModel",
			extend: "BPMSoft.BaseViewModel",
			parentViewModel: null,

			columns: {
				SortingTypeList: {
					dataValueType: BPMSoft.DataValueType.COLLECTION,
					value: null
				},
				SortingType: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					value: null
				},
				IsIncreaseSortingPriorityButtonEnabled: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				IsDecreaseSortingPriorityButtonEnabled: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},

			constructor: function() {
				this.callParent(arguments);
				this.set("SortingTypeList", Ext.create("BPMSoft.Collection"));
				this._initSortingType();
				this.subscribeOnColumnChange("SortingType", this._onSortingTypeChange, this);
			},

			_getSortingTypes: function() {
				const result = {};
				result[BPMSoft.OrderDirection.ASC] = {
					value: BPMSoft.OrderDirection.ASC,
					displayValue: resources.localizableStrings.AscSortingLabel,
					imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.AscSortingIcon),
					imageConfig: resources.localizableImages.AscSortingIcon
				};
				result[BPMSoft.OrderDirection.DESC] = {
					value: BPMSoft.OrderDirection.DESC,
					displayValue: resources.localizableStrings.DescSortingLabel,
					imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DescSortingIcon),
					imageConfig: resources.localizableImages.DescSortingIcon
				};
				result[BPMSoft.OrderDirection.NONE] = {
					value: BPMSoft.OrderDirection.NONE,
					displayValue: resources.localizableStrings.NoSortingLabel,
					imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.NoSortingIcon),
					imageConfig: resources.localizableImages.NoSortingIcon
				};
				return result;
			},

			_initSortingType: function() {
				const sortingTypes = this._getSortingTypes();
				const sortingType = sortingTypes[this.get("sort")] || sortingTypes[BPMSoft.OrderDirection.NONE];
				this.set("SortingType", sortingType);
			},

			_onSortingTypeChange: function(model, lookupValue) {
				this.set("sort", (lookupValue && lookupValue.value) || BPMSoft.OrderDirection.NONE);
			},

			_getMacrosItemIndex: function() {
				return this.parentViewModel.$MacrosListCollection.indexOfKey(this.get("Id"));
			},

			onDestroy: function() {
				this.unsubscribeOnColumnChange("SortingType", this._onSortingTypeChange, this);
				this.callParent(arguments);
			},

			onEditClick: function() {
				this.parentViewModel.editMacros(this);
			},

			onRemoveClick: function() {
				this.parentViewModel.$MacrosListCollection.remove(this);
			},

			prepareSortingTypeList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.reloadAll(this._getSortingTypes());
			},

			onIncreaseSortingPriorityClick: function() {
				const index = this._getMacrosItemIndex();
				this.parentViewModel.moveMacrosListItem(index, index - 1);
			},

			onDecreaseSortingPriorityClick: function() {
				const index = this._getMacrosItemIndex();
				this.parentViewModel.moveMacrosListItem(index, index + 1);
			},

			getDisplayValue: function(lookupValue) {
				return lookupValue && lookupValue.displayValue;
			}

		});

		Ext.define("BPMSoft.Configuration.MacrosListViewModel", {
			alternateClassName: "BPMSoft.WordPrintableMacrosListViewModel",
			extend: "BPMSoft.BaseViewModel",
			Ext: null,
			BPMSoft: null,
			sandbox: null,
			sandboxTag: null,
			suspendChangeMacrosListMessage: false,
			entitySchema: null,

			columns: {
				MacrosListCollection: {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					value: null
				},
				ModuleSchemaName: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: null
				},
				IsSortingEnabled: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				DetailCaption: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: null
				},
				InfoButtonText: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: null
				},
				AddButtonLabel: {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: null
				},
			},

			//region Methods: Private

			_updateMacrosListItemButtonsVisibility: function() {
				const macrosListCollectionCount = this.$MacrosListCollection.getCount();
				this.$MacrosListCollection.each(function(item, index) {
					item.set("IsIncreaseSortingPriorityButtonEnabled",
						this.get("IsSortingEnabled") && index > 0);
					item.set("IsDecreaseSortingPriorityButtonEnabled",
						this.get("IsSortingEnabled") && index < macrosListCollectionCount - 1);
				}, this);
			},

			_onMacrosListChanged: function() {
				this._updateMacrosListItemButtonsVisibility();
				if (this.suspendChangeMacrosListMessage) {
					return;
				}
				const macrosList = this.$MacrosListCollection.mapArray(function(macrosViewModel) {
					return {
						"Id": macrosViewModel.$Id,
						"caption": macrosViewModel.$caption,
						"metaPath": macrosViewModel.$metaPath,
						"metaPathCaption": macrosViewModel.$metaPathCaption,
						"aggregationType": macrosViewModel.$aggregationType,
						"subFilters": macrosViewModel.$subFilters,
						"dataValueType": macrosViewModel.$dataValueType,
						"sort": macrosViewModel.$sort
					};
				}, this);
				this.sandbox.publish("MacrosListChanged", macrosList, [this.sandboxTag]);
			},

			_getStructureExplorerConfig: function() {
				return {
					schemaName: this.$ModuleSchemaName,
					excludeDataValueTypes: [
						BPMSoft.DataValueType.FILE,
						BPMSoft.DataValueType.COLOR
					],
					enableBlobDataValueType: true,
					useBackwards: true,
					firstColumnsOnly: false,
					autoHideMask: false,
					displayId: true
				};
			},

			_getMacrosSettingsConfig: function(viewModel) {
				return {
					leftExpressionCaption: viewModel.$caption,
					metaCaptionPath: viewModel.$metaPathCaption,
					aggregationType: viewModel.$aggregationType,
					dataValueType: viewModel.$dataValueType,
					serializedFilter: viewModel.$subFilters,
					isTiled: false,
					shouldHideLookupActions: true,
					isColumnSettingsHidden: true,
					isBackward: viewModel.$isBackward,
					referenceSchemaName: viewModel.$referenceSchemaName,
					aggregationFunction: viewModel.$aggregationFunction,
					lastReferenceSchemaName: viewModel.$lastReferenceSchemaName,
					schemaName: this.$ModuleSchemaName
				};
			},

			_createMacrosViewModel: function(columnValues) {
				const isBackward = columnValues.hasOwnProperty("isBackward")
					? columnValues.isBackward
					: columnValues.aggregationType !== BPMSoft.AggregationType.NONE;
				return Ext.create("BPMSoft.WordPrintableMacrosViewModel", {
					parentViewModel: this,
					values: {
						Id: columnValues.Id,
						caption: columnValues.caption,
						metaPath: columnValues.metaPath,
						metaPathCaption: columnValues.metaPathCaption,
						aggregationType: columnValues.aggregationType,
						dataValueType: columnValues.dataValueType,
						subFilters: columnValues.subFilters,
						isBackward: isBackward,
						referenceSchemaName: columnValues.referenceSchemaName,
						lastReferenceSchemaName: columnValues.lastReferenceSchemaName,
						sort: columnValues.sort
					}
				});
			},

			_getEntitySchemaByUId: function(uId, callback, scope) {
				const serviceConfig = {
					serviceName: "../ServiceModel/EntitySchemaService.svc",
					methodName: "GetEntitySchemaByUId",
					scope: this,
					data: {
						entitySchemaUId: uId
					}
				};
				BPMSoft.ConfigurationServiceProvider.callService(serviceConfig, function(schema) {
					this._getEntitySchema(schema.entitySchema.Name, callback, scope);
				}, this);
			},

			_getSchemaNameByMetaPath: function(entitySchemaName, path, callback, scope) {
				if (path.length === 0) {
					Ext.callback(callback, scope, [entitySchemaName]);
					return;
				}
				let metaPathItem = path.shift();
				const isBackwardResult = /^\[(.*):(.*)\]$/.exec(metaPathItem);
				if (isBackwardResult) {
					const entitySchemaUId = isBackwardResult[1];
					const columnUId = isBackwardResult[2];
					this._getEntitySchemaByUId(entitySchemaUId, function(entitySchema) {
						const column = entitySchema.getColumnByUId(columnUId);
						if (column.isLookup) {
							this._getSchemaNameByMetaPath(entitySchema.name, path, callback, scope);
						} else {
							Ext.callback(callback, scope, [entitySchema.name]);
						}
					}, this);
				} else {
					this._getEntitySchema(entitySchemaName, function(entitySchema) {
						const column = entitySchema.getColumnByUId(metaPathItem);
						if (column.isLookup) {
							this._getSchemaNameByMetaPath(column.referenceSchemaName, path, callback, scope);
						} else {
							Ext.callback(callback, scope, [entitySchemaName]);
						}
					}, this);
				}
			},

			_getMetaPathByPath: function(schemaName, path, metaPath, callback, scope) {
				if (path.length === 0) {
					Ext.callback(callback, scope, [metaPath]);
					return;
				}
				const pathItem = path.shift();
				const isBackwardResult = /^\[(.*):(.*)\]$/.exec(pathItem);
				if (isBackwardResult) {
					const entitySchemaName = isBackwardResult[1];
					const columnName = isBackwardResult[2];
					this._getEntitySchema(entitySchemaName, function(entitySchema) {
						const column = entitySchema.getColumnByName(columnName);
						metaPath.push("[" + entitySchema.uId + ":" + column.uId + "]");
						this._getMetaPathByPath(entitySchemaName, path, metaPath, callback, scope);
					}, this);
				} else {
					this._getEntitySchema(schemaName, function(entitySchema) {
						const column = entitySchema.getColumnByName(pathItem);
						metaPath.push(column.uId);
						this._getMetaPathByPath(column.referenceSchemaName, path, metaPath, callback, scope);
					}, this);
				}
			},

			_getAggregationType: function(columnSettings) {
				if (columnSettings.aggregationType) {
					return columnSettings.aggregationType;
				} else if (columnSettings.aggregationFunction) {
					return BPMSoft.AggregationType.COUNT;
				}
				return BPMSoft.AggregationType.NONE;
			},

			_createMacrosViewModelByColumnConfig: function(columnSettings, callback, scope) {
				this._getMetaPathByPath(this.$ModuleSchemaName, columnSettings.path, [], function(metaPath) {
					const captionPath = columnSettings.caption.join(".");
					const viewModel = this._createMacrosViewModel({
						Id: BPMSoft.generateGUID(),
						caption: captionPath,
						metaPathCaption: captionPath,
						metaPath: metaPath.join("."),
						aggregationType: this._getAggregationType(columnSettings),
						dataValueType: columnSettings.dataValueType,
						subFilters: null,
						isBackward: columnSettings.isBackward,
						referenceSchemaName: columnSettings.referenceSchemaName,
						lastReferenceSchemaName: columnSettings.lastReferenceSchemaName
					});
					Ext.callback(callback, scope, [viewModel]);
				}, this);
			},

			_onColumnSelected: function(selectedColumnConfig) {
				this._createMacrosViewModelByColumnConfig(selectedColumnConfig, function(viewModel) {
					if (selectedColumnConfig.aggregationFunction || selectedColumnConfig.metaPath.length > 1) {
						this._openMacrosSettingsPage(viewModel);
					} else {
						this.$MacrosListCollection.add(viewModel.$Id, viewModel);
					}
				}, this);
			},

			_getEntitySchema: function(name, callback, scope) {
				BPMSoft.require([name], callback, scope);
			},

			_isExpressionValueValid: function (dataValueType, expressionValue) {
				let valueIsValid = !Ext.isEmpty(expressionValue);
				switch (dataValueType) {
					case BPMSoft.DataValueType.INTEGER:
					case BPMSoft.DataValueType.FLOAT:
					case BPMSoft.DataValueType.FLOAT1:
					case BPMSoft.DataValueType.FLOAT2:
					case BPMSoft.DataValueType.FLOAT3:
					case BPMSoft.DataValueType.FLOAT4:
					case BPMSoft.DataValueType.MONEY:
						valueIsValid = Ext.isNumeric(expressionValue);
						break;
					case BPMSoft.DataValueType.GUID:
						valueIsValid = BPMSoft.isGUID(expressionValue);
						break;
					case BPMSoft.DataValueType.TEXT:
						valueIsValid = Ext.isString(expressionValue);
						break;
					default:
						break;
				}
				return valueIsValid;
			},

			_isFilterValueValid: function(filterItem) {
				if (!filterItem) {
					return false;
				}
				if (!filterItem.rightExpression && !filterItem.rightExpressions) {
					return true;
				}
				let isValid = true;
				let dataValueType = filterItem.dataValueType;
				let rightExpressionParameterValue;
				if (filterItem.rightExpression) {
					rightExpressionParameterValue = filterItem.rightExpression.parameter &&
						filterItem.rightExpression.parameter.getValue();
					if (!rightExpressionParameterValue && filterItem.rightExpression.functionArgument) {
						rightExpressionParameterValue = filterItem.rightExpression.functionArgument.parameter.value;
						dataValueType = filterItem.rightExpression.functionArgument.parameter.dataValueType;
					}
				}
				if (!BPMSoft.utils.common.isUndefined(rightExpressionParameterValue)) {
					isValid = this._isExpressionValueValid(dataValueType, rightExpressionParameterValue);
				} else {
					if (filterItem.rightExpressions) {
						filterItem.rightExpressions.forEach(function(rightExpression) {
							if (rightExpression instanceof BPMSoft.ParameterExpression) {
								const parameter = rightExpression.parameter;
								const isCurrentExpressionValid =
									this._isExpressionValueValid(dataValueType, parameter.getValue().value);
								if (!isCurrentExpressionValid) {
									const index = filterItem.rightExpressions.indexOf(rightExpression);
									filterItem.rightExpressions.splice(index, 1);
								}
							}
						}, this);
						isValid = filterItem.rightExpressions.length > 0;
					}
				}
				return isValid;
			},

			_removeUncompletedFilterItems: function(filterGroup) {
				const clonedItems = filterGroup.getItems().concat([]);
				clonedItems.forEach(function(item) {
					if (item.filterType === BPMSoft.FilterType.FILTER_GROUP) {
						this._removeUncompletedFilterItems(item);
						return;
					}
					if (!item.getIsCompleted() || !this._isFilterValueValid(item)) {
						filterGroup.remove(item);
					}
					if (item.isAggregative && item.leftExpression.subFilters) {
						this._removeUncompletedFilterItems(item.leftExpression.subFilters);
					}
				}, this);
			},

			//endregion

			//region Methods: Public

			init: function(macrosList) {
				const macrosListCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				macrosList.forEach(function(macros) {
					const viewModel = this._createMacrosViewModel(macros);
					macrosListCollection.add(viewModel.$Id, viewModel);
				}, this);
				macrosListCollection.on("changed", this._onMacrosListChanged, this);
				macrosListCollection.on("itemChanged", this._onMacrosListChanged, this);
				this.setColumnValue("MacrosListCollection", macrosListCollection, {preventValidation: true});
				this._updateMacrosListItemButtonsVisibility();
			},

			reInitialize: function(macrosList) {
				const macrosListCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				macrosList.forEach(function(macros) {
					const viewModel = this._createMacrosViewModel(macros);
					macrosListCollection.add(macros.Id, viewModel);
				}, this);
				this.suspendChangeMacrosListMessage = true;
				this.$MacrosListCollection.reloadAll(macrosListCollection);
				this.suspendChangeMacrosListMessage = false;
			},

			getEmptyMessageViewConfig: function(emptyMessageProperties) {
				return  {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["empty-message-ct"]
					},
					items: [{
						className: "BPMSoft.Label",
						classes: {
							labelClass: ["empty-message"]
						},
						caption: emptyMessageProperties.caption
					}]
				};
			},

			prepareEmptyMessageConfig: function(config) {
				const emptyMessageProperties = {
					caption: resources.localizableStrings.EmptyDetailMessageCaption,
				};
				const emptyMessageViewConfig = this.getEmptyMessageViewConfig(emptyMessageProperties);
				Ext.apply(config, emptyMessageViewConfig);
			},

			onGetMacrosListCollectionItemConfig: function(itemConfig) {
				itemConfig.config = {
					"className": "BPMSoft.Container",
					"id": "macros",
					"classes": {
						"wrapClassName": ["macros-ct"]
					},
					"markerValue": {"bindTo": "caption"},
					"items": [{
						"className": "BPMSoft.Container",
						"classes": {
							"wrapClassName": ["macros-row-main-info"]
						},
						"items": [{
							"className": "BPMSoft.Hyperlink",
							"caption": {"bindTo": "caption"},
							"markerValue": "caption",
							"classes": {
								"hyperlinkClass": this.get("IsSortingEnabled")
									? ["macros-link", "macros-link-with-sorting"]
									: ["macros-link"]
							},
							"click": {
								"bindTo": "onEditClick"
							}
						}, {
								"className": "BPMSoft.Container",
								"classes": {
									"wrapClassName": ["macros-sorting-edit-wrapper"]
								},
								"visible": this.get("IsSortingEnabled"),
								"items": [{
									"className": "BPMSoft.ComboBoxEdit",
									"prepareList": {"bindTo": "prepareSortingTypeList"},
									"list": {"bindTo": "SortingTypeList"},
									"value": {"bindTo": "SortingType"},
									"leftIconConfig": resources.localizableImages.SortingComboboxLeftIcon,
									"iconsVisible": true
								}, {
									"className": "BPMSoft.Label",
									"caption": {
										"bindTo": "SortingType",
										"bindConfig": {
											"converter": "getDisplayValue"
										}
									}
								}]
							}]
						}, {
							"className": "BPMSoft.Container",
							"classes": {
								"wrapClassName": ["macros-row-settings"]
							},
							"items": [{
								"className": "BPMSoft.Button",
								"click": {"bindTo": "onIncreaseSortingPriorityClick"},
								"visible": {"bindTo": "IsIncreaseSortingPriorityButtonEnabled"},
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"hint": resources.localizableStrings.IncreaseSortingButtonHint,
								"markerValue": "increaseSortingPriority",
								"styles": {
									"wrapperStyle": {
										"background":
											Ext.String.format("url({0}) 50% 50% no-repeat", getIcon("IncreaseSortingPriority"))
									}
								},
								"classes": {
									"wrapperClass": ["macros-item", "action-item"],
									"textClass": ["macros-item", "action-item"]
								}
							}, {
								"className": "BPMSoft.Button",
								"click": {"bindTo": "onDecreaseSortingPriorityClick"},
								"visible": {"bindTo": "IsDecreaseSortingPriorityButtonEnabled"},
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"hint": resources.localizableStrings.DecreaseSortingButtonHint,
								"markerValue": "descreaseSortingPriority",
								"styles": {
									"wrapperStyle": {
										"background":
											Ext.String.format("url({0}) 50% 50% no-repeat", getIcon("DecreaseSortingPriority"))
									}
								},
								"classes": {
									"wrapperClass": ["macros-item", "action-item"],
									"textClass": ["macros-item", "action-item"]
								}
							}, {
								"className": "BPMSoft.Button",
								"click": {"bindTo": "onEditClick"},
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"hint": resources.localizableStrings.EditButtonHint,
								"markerValue": "edit",
								"styles": {
									"wrapperStyle": {
										"background":
											Ext.String.format("url({0}) 50% 50% no-repeat", getIcon("EditIcon"))
									}
								},
								"classes": {
									"wrapperClass": ["macros-item", "action-item"],
									"textClass": ["macros-item", "action-item"]
								},
							}, {
								"className": "BPMSoft.Button",
								"click": {"bindTo": "onRemoveClick"},
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"hint": resources.localizableStrings.RemoveButtonHint,
								"markerValue": "remove",
								"styles": {
									"wrapperStyle": {
										"background":
											Ext.String.format("url({0}) 50% 50% no-repeat", getIcon("DeleteIcon"))
									}
								},
								"classes": {
									"wrapperClass": ["macros-item", "action-item"],
									"textClass": ["macros-item", "action-item"]
								},
							}]
						}
					]
				};
			},

			addMacros: function() {
				if (!this.$ModuleSchemaName) {
					this.showInformationDialog(this.$ModuleSchemaNameRequiredValidationMessage);
					return;
				}
				const config = this._getStructureExplorerConfig();
				StructureExplorerUtilities.Open(this.sandbox, config, this._onColumnSelected, this.renderTo, this);
			},

			_openMacrosSettingsPage: function(macrosViewModel) {
				this.currentMacrosViewModel = macrosViewModel;
				const columnSettingsConfig = this._getMacrosSettingsConfig(macrosViewModel);
				this.sandbox.publish("OpenMacrosSettingsPage", columnSettingsConfig, [this.sandboxTag]);
			},

			editMacros: function(macrosViewModel) {
				if (!macrosViewModel.referenceSchemaName) {
					this._getSchemaNameByMetaPath(this.$ModuleSchemaName, macrosViewModel.$metaPath.split("."),
						function(entitySchemaName) {
							macrosViewModel.$referenceSchemaName = entitySchemaName;
							macrosViewModel.$lastReferenceSchemaName = entitySchemaName;
							this._openMacrosSettingsPage(macrosViewModel);
						}, this);
					return;
				}
				this._openMacrosSettingsPage(macrosViewModel);
			},

			setMacrosSettings: function(columnSettings) {
				const filterGroup = BPMSoft.deserialize(columnSettings.serializedFilter);
				this._removeUncompletedFilterItems(filterGroup);
				const serializedFilter = filterGroup.serialize({serializeFilterManagerInfo: true});
				const viewModel = this.currentMacrosViewModel;
				viewModel.$caption = columnSettings.title;
				viewModel.$aggregationType = columnSettings.aggregationType;
				viewModel.$dataValueType = columnSettings.dataValueType;
				viewModel.$isBackward = columnSettings.isBackward;
				viewModel.$metaPathCaption = columnSettings.metaCaptionPath;
				viewModel.$subFilters = serializedFilter;
				viewModel.$referenceSchemaName = columnSettings.referenceSchemaName;
				viewModel.$leftExpressionColumnPath = columnSettings.leftExpressionColumnPath;
				this.$MacrosListCollection.addIfNotExists(viewModel.$Id, viewModel);
				this.currentMacrosViewModel = null;
			},

			moveMacrosListItem: function(fromIndex, toIndex) {
				const count = this.$MacrosListCollection.getCount();
				if (fromIndex < 0 || fromIndex >= count || toIndex < 0 || toIndex >= count) {
					return;
				}
				const item = this.$MacrosListCollection.getByIndex(fromIndex);
				this.$MacrosListCollection.removeByIndex(fromIndex);
				this.$MacrosListCollection.insert(toIndex, item.get("Id"), item);
			}

			//endregion

		});

		Ext.define("BPMSoft.Configuration.MacrosListDetailModule", {
			extend: "BPMSoft.core.BaseModule",
			alternateClassName: "BPMSoft.MacrosListDetailModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			isAsync: true,
			renderTo: "",
			sandboxTag: null,

			constructor: function() {
				this.callParent(arguments);
				this._registerMessages();
			},

			_getMessages: function() {
				return {
					"StructureExplorerInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"ColumnSelected": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"GetMacrosListDetailInfo": {
						"direction": BPMSoft.MessageDirectionType.PUBLISH,
						"mode": BPMSoft.MessageMode.PTP
					},
					"ReinitializeMacrosList": {
						"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
						"mode": BPMSoft.MessageMode.PTP
					},
					"RootEntitySchemaChanged": {
						"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
						"mode": BPMSoft.MessageMode.PTP
					},
					"MacrosListChanged": {
						"direction": BPMSoft.MessageDirectionType.PUBLISH,
						"mode": BPMSoft.MessageMode.PTP
					},
					"OpenMacrosSettingsPage": {
						"direction": BPMSoft.MessageDirectionType.PUBLISH,
						"mode": BPMSoft.MessageMode.PTP
					},
					"SetMacrosSettings": {
						"direction": BPMSoft.MessageDirectionType.SUBSCRIBE,
						"mode": BPMSoft.MessageMode.PTP
					},
				};
			},

			_registerMessages: function() {
				const messages = this._getMessages();
				this.sandbox.registerMessages(messages);
			},

			_unRegisterMessages: function() {
				const messages = this._getMessages();
				this.sandbox.unRegisterMessages(messages);
			},

			initViewModel: function(detailInfo) {
				const viewModel = this.viewModel = this.Ext.create("BPMSoft.WordPrintableMacrosListViewModel", {
					Ext: this.Ext,
					BPMSoft: this.BPMSoft,
					sandbox: this.sandbox,
					sandboxTag: this.sandboxTag,
					values: {
						ModuleSchemaName: detailInfo.rootEntitySchema,
						IsSortingEnabled: detailInfo.isSortingEnabled || false,
						DetailCaption: detailInfo.caption,
						InfoButtonText: detailInfo.infoButtonText,
						ModuleSchemaNameRequiredValidationMessage: detailInfo.moduleSchemaNameRequiredValidationMessage,
						AddButtonLabel: detailInfo.addButtonLabel
					}
				});
				viewModel.init(detailInfo.macrosList);
			},

			onDestroy: function() {
				this._unRegisterMessages();
				this.callParent(arguments);
			},

			_onReinitializeMacrosList: function(macrosList) {
				this.viewModel.reInitialize(macrosList);
			},

			_onRootEntitySchemaChanged: function(rootEntitySchema) {
				this.viewModel.$ModuleSchemaName = rootEntitySchema;
			},

			_onSetMacrosSettings: function(macrosSettingsConfig) {
				this.viewModel.setMacrosSettings(macrosSettingsConfig);
			},

			init: function(callback, scope) {
				if (this.viewModel && !this.viewModel.destroyed) {
					callback.call(scope);
					return;
				}
				const detailInfo = this.sandbox.publish("GetMacrosListDetailInfo", null, [this.sandboxTag]);
				this.sandbox.subscribe("ReinitializeMacrosList", this._onReinitializeMacrosList, this, [this.sandboxTag]);
				this.sandbox.subscribe("RootEntitySchemaChanged", this._onRootEntitySchemaChanged, this, [this.sandboxTag]);
				this.sandbox.subscribe("SetMacrosSettings", this._onSetMacrosSettings, this, [this.sandboxTag]);
				this.initViewModel(detailInfo);
				callback.call(scope);
			},

			getView: function() {
				return this.Ext.create("BPMSoft.ControlGroup", {
					"collapsed": false,
					"caption": {
						"bindTo": "DetailCaption"
					},
					"classes": {
						"wrapClass": ["macros-list"]
					},
					"tools": [
						{
							"className": "BPMSoft.InformationButton",
							"tips": [
								{
									"tip": {
										"initialAlignType": BPMSoft.AlignType.BOTTOM,
										"showDelay": 200,
										"content": "$InfoButtonText"
									},
									"settings": {
										"displayEvent": BPMSoft.TipDisplayEvent.HOVER,
										"hideOnMouseDown": false
									}
								}
							],
							"classes": {
								"wrapperClass": "info-button"
							}
						}
					],
					markerValue: "macros-list",
					items: [
						{
							"className": "BPMSoft.Container",
							"items": [
							{
								"className": "BPMSoft.Button",
								"caption": {
									"bindTo": "AddButtonLabel"
								},
								"imageConfig": resources.localizableImages.AddIcon,
								"classes": {
									"wrapperClass": "add-macros"
								},
								"markerValue": "addMacros",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"click": {"bindTo": "addMacros"},
								"tag": "addMacros"
							}, {
								"className": "BPMSoft.Container",
								"visible": {
									"bindTo": "MacrosListCollection",
									"bindConfig": {"converter": "isNotEmptyValue"}
								},
								"classes": {
									"wrapClassName": ["container-list-header"]
								},
								"items": [{
									"className": "BPMSoft.Label",
									"caption": resources.localizableStrings.ColumnNameLabel
								}, {
									"className": "BPMSoft.Label",
									"caption": resources.localizableStrings.SortDirectionLabel,
									"visible": {"bindTo": "IsSortingEnabled"}
								}]
							}, {
								"className": "BPMSoft.ContainerList",
								"collection": {"bindTo": "MacrosListCollection"},
								"classes": {"wrapClassName": ["container-list"]},
								"rowCssSelector": ".section-group-item",
								"onGetItemConfig": {"bindTo": "onGetMacrosListCollectionItemConfig"},
								"getEmptyMessageConfig": {"bindTo": "prepareEmptyMessageConfig"},
								"idProperty": "Id",
								"dataItemIdPrefix": "macros",
								"itemPrefix": "Macros-",
								"defaultItemConfig": {},
								"selectableRowCss": "section-group-item"
							}
						]
						}
					]
				});
			},

			render: function(renderTo) {
				const view = this.view = this.getView();
				view.bind(this.viewModel);
				view.render(renderTo);
			},

			destroy: function(config) {
				if (config && config.keepAlive === true) {
					return;
				}
				if (this.viewModel && !this.viewModel.destroyed) {
					this.viewModel.destroy();
				}
				this.viewModel = null;
			}
		});

		return BPMSoft.MacrosListDetailModule;
	}
);
