define("WordPrintableConverter", ["ext-base", "BPMSoft", "FilterConverter", "FilterConverterConnector"], function() {
	Ext.define("BPMSoft.configuration.WordPrintableConverter", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.WordPrintableConverter",
		singleton: true,

		_aggregationTypesMap: {
			"None": BPMSoft.AggregationType.NONE,
			"Count": BPMSoft.AggregationType.COUNT,
			"Sum": BPMSoft.AggregationType.SUM,
			"Avg": BPMSoft.AggregationType.AVG,
			"Min": BPMSoft.AggregationType.MIN,
			"Max": BPMSoft.AggregationType.MAX,
		},

		_getClientAggregationType: function(value) {
			const aggregationType = this._aggregationTypesMap[value];
			return aggregationType ? aggregationType : BPMSoft.AggregationType.NONE;
		},

		_getServerAggregationTypeName: function(aggregationType) {
			const aggregationTypeNames = Object.keys(this._aggregationTypesMap);
			for (let index in aggregationTypeNames) {
				const aggregationTypeName = aggregationTypeNames[index];
				if (this._aggregationTypesMap[aggregationTypeName] === aggregationType) {
					return aggregationTypeName;
				}
			}
			return "None";
		},

		_getClientDataValueType: function(serverDataValueTypeName) {
			return BPMSoft.ServerDataValueTypeName[serverDataValueTypeName];
		},

		_getServerDataValueTypeName: function(dataValueType) {
			const serverDataValueTypeNames = Object.keys(BPMSoft.ServerDataValueTypeName);
			for (let index in serverDataValueTypeNames) {
				const serverDataValueTypeName = serverDataValueTypeNames[index];
				if (BPMSoft.ServerDataValueTypeName[serverDataValueTypeName] === dataValueType) {
					return serverDataValueTypeName;
				}
			}
			return null;
		},

		_convertTo7xOrderDirection: function(orderDirection5x) {
			switch (orderDirection5x) {
				case "Ascending":
					return BPMSoft.OrderDirection.ASC;
				case "Descending":
					return BPMSoft.OrderDirection.DESC;
				default:
					return BPMSoft.OrderDirection.NONE;
			}
		},

		_convertTo5xOrderDirection: function(orderDirection7x) {
			switch (orderDirection7x) {
				case BPMSoft.OrderDirection.ASC:
					return "Ascending";
				case BPMSoft.OrderDirection.DESC:
					return "Descending";
				default:
					return undefined;
			}
		},

		_removeFilterKeys: function(filterGroup) {
			delete filterGroup.key;
			const clonedItems = filterGroup.getItems().concat([]);
			clonedItems.forEach(function(item) {
				if (item.filterType === BPMSoft.FilterType.FILTER_GROUP) {
					this._removeFilterKeys(item);
					return;
				}
				delete item.key;
				if (item.isAggregative && item.leftExpression.subFilters) {
					this._removeFilterKeys(item.leftExpression.subFilters);
				}
			}, this);
		},

		_convertFiltersFrom5x: function(filters, callback, scope) {
			const self = this;
			BPMSoft.FilterConverter.deserializeFilterEditData(filters, function(result) {
				self._removeFilterKeys(result.filterEditData);
				Ext.callback(callback, scope, [result.filterEditData]);
			}, this);
		},

		_convertFiltersTo5x: function(filters, callback, scope) {
			const deserializedFilters = BPMSoft.deserialize(filters);
			BPMSoft.FilterConverterConnector.convert(deserializedFilters, function(result) {
				Ext.callback(callback, scope, [result]);
			});
		},

		_is5xFilter: function(filterStr) {
			if (!filterStr) {
				return true;
			}
			const filter = BPMSoft.deserialize(filterStr);
			return filter.hasOwnProperty("_isFilter");
		},

		_convertMacrosListFiltersFrom5x: function(macrosList, callback, scope) {
			if (macrosList.length === 0) {
				Ext.callback(callback, scope, [macrosList]);
				return;
			}
			BPMSoft.chainForArray(macrosList, function(macros) {
				return function(next) {
					if (this._is5xFilter(macros.subFilters)) {
						this._convertFiltersFrom5x(macros.subFilters, function(convertedFilters) {
							let serializationInfo = convertedFilters.getDefSerializationInfo();
							serializationInfo.serializeFilterManagerInfo = true;
							macros.subFilters = convertedFilters.serialize(serializationInfo);
							next();
						});
					} else {
						next();
					}
				};
			}, function() {
				Ext.callback(callback, scope, [macrosList]);
			}, this);
		},

		_convertMacrosListFiltersTo5x: function(macrosList, callback, scope) {
			if (this._canUse7xFilters() || macrosList.length === 0) {
				Ext.callback(callback, scope, [macrosList]);
				return;
			}
			BPMSoft.chainForArray(macrosList, function(macros) {
				return function(next) {
					this._convertFiltersTo5x(macros.subFilters, function(filters) {
						macros.subFilters = filters;
						next();
					})
				};
			}, function() {
				Ext.callback(callback, scope, [macrosList]);
			}, this);
		},

		_convertMacrosListFromAngularDto: function(value, callback, scope) {
			let macrosList = [];
			if (value) {
				macrosList = JSON5.parse(value);
				macrosList.forEach(function(macros) {
					macros.Id = BPMSoft.generateGUID();
					macros.dataValueType = this._getClientDataValueType(macros.dataValueType);
					macros.aggregationType = this._getClientAggregationType(macros.aggregationType);
					macros.sort = this._convertTo7xOrderDirection(macros.sort);
				}, this);
				this._convertMacrosListFiltersFrom5x(macrosList, callback, scope);
				return;
			}
			Ext.callback(callback, scope, [macrosList]);
		},

		_convertMacrosListToAngularDto: function(macrosListDto, callback, scope) {
			const macrosList = macrosListDto.map(function(macros) {
				const macrosDto = BPMSoft.deepClone(macros);
				macrosDto.dataValueType = this._getServerDataValueTypeName(macrosDto.dataValueType);
				macrosDto.aggregationType = this._getServerAggregationTypeName(macrosDto.aggregationType);
				macrosDto.sort = this._convertTo5xOrderDirection(macros.sort);
				delete macrosDto.Id;
				return macrosDto;
			}, this);
			this._convertMacrosListFiltersTo5x(macrosList, function(macrosList) {
				const angularMacrosListDto = JSON5.stringify(macrosList);
				Ext.callback(callback, scope, [angularMacrosListDto]);
			}, this);
		},

		_convertTablePartFromAngularDto: function(tablePart, callback, scope) {
			BPMSoft.chain(
				function(next) {
					if (this._canUse7xFilters()) {
						this._convertMacrosListFromAngularDto(tablePart.macrosSettings || tablePart.macrosList, function(convertedMacrosList) {
							tablePart.macrosSettings = JSON.stringify(convertedMacrosList);
							next();
						}, this);
					} else {
						this._convertMacrosListFromAngularDto(tablePart.macrosList, function(convertedMacrosList) {
							tablePart.macrosList = JSON.stringify(convertedMacrosList);
							next();
						}, this);
					}
				},
				function() {
					if (this._canUse7xFilters()) {
						if (!tablePart.filterSettings) {
							this._convertFiltersFrom5x(tablePart.filter, function(convertedFilter) {
								tablePart.filterSettings = convertedFilter.serialize({serializeFilterManagerInfo: true});
								callback.call(scope);
							});
						} else {
							callback.call(scope);
						}
					} else {
						this._convertFiltersFrom5x(tablePart.filter, function(convertedFilter) {
							tablePart.filter = convertedFilter.serialize({serializeFilterManagerInfo: true});
							callback.call(scope);
						});
					}
				},
				this
			);
		},

		_convertTablePartToAngularDto: function(tablePart, callback, scope) {
			BPMSoft.chain(
				function(next) {
					if (this._canUse7xFilters()) {
						const macrosList = JSON.parse(tablePart.macrosSettings);
						this._convertMacrosListToAngularDto(macrosList, function(convertedMacrosList) {
							tablePart.macrosSettings = convertedMacrosList;
							next();
						}, this);
					} else {
						const macrosList = JSON.parse(tablePart.macrosList);
						this._convertMacrosListToAngularDto(macrosList, function(convertedMacrosList) {
							tablePart.macrosList = convertedMacrosList;
							next();
						}, this);
					}
				},
				function() {
					if (!this._canUse7xFilters()) {
						this._convertFiltersTo5x(tablePart.filter, function(convertedFilter) {
							tablePart.filter = convertedFilter;
							callback.call(scope);
						});
					} else {
						callback.call(scope);
					}
				},
				this
			);
		},

		_convertTablePartsFromAngularDto: function(angularTablePartsDto, callback, scope) {
			const tableParts = BPMSoft.deepClone(angularTablePartsDto);
			if (tableParts.length === 0) {
				Ext.callback(callback, scope, [tableParts]);
				return;
			}
			BPMSoft.chain(
				function(next) {
					BPMSoft.chainForArray(tableParts, function(tablePart) {
						return function(innerNext) {
							this._convertTablePartFromAngularDto(tablePart, innerNext, this);
						};
					}, next, this);
				},
				function() {
					Ext.callback(callback, scope, [tableParts]);
				},
				this
			);
		},

		_convertTablePartsToAngularDto: function(tablePartsDto, callback, scope) {
			if (tablePartsDto.length === 0) {
				Ext.callback(callback, scope, [tablePartsDto]);
				return;
			}
			BPMSoft.chain(
				function(next) {
					BPMSoft.chainForArray(tablePartsDto, function(tablePart) {
						return function(innerNext) {
							this._convertTablePartToAngularDto(tablePart, innerNext, this);
						};
					}, next, this);
				},
				function() {
					Ext.callback(callback, scope, [tablePartsDto]);
				},
				this
			);
		},
		
		_canUse7xFilters: function() {
			return BPMSoft.Features.getIsEnabled("Use7xFiltersForWordReports");
		},

		convertFromAngularDto: function(isNew, dto, callback, scope) {
			BPMSoft.chain(
				function(next) {
					this._convertTablePartsFromAngularDto(dto.tableParts, function(tablePartsDto) {
						next({
							tablePartsDto: tablePartsDto
						});
					}, this);
				},
				function(next, convertedData) {
					if (this._canUse7xFilters()) {
						this._convertMacrosListFromAngularDto(dto.macrosSettings || dto.macrosList, function(macrosListDto) {
							convertedData.macrosSettingsDto = macrosListDto;
							convertedData.macrosListDto = dto.macrosList;
							next(convertedData);
						}, this);
					} else {
						this._convertMacrosListFromAngularDto(dto.macrosList, function(macrosListDto) {
							convertedData.macrosSettingsDto = dto.macrosSettings;
							convertedData.macrosListDto = macrosListDto;
							next(convertedData);
						}, this);
					}
				},
				function(next, convertedData) {
					const entityDto = {
						isNew: isNew,
						columnValues: {
							Id: dto.id,
							Caption: dto.caption,
							SysModule: dto.moduleId ? {value: dto.moduleId, displayValue: dto.moduleName} : null,
							ModuleSchemaName: dto.moduleSchemaName,
							Type: dto.typeId ? {value: dto.typeId, displayValue: dto.typeName} : null,
							ShowInSection: dto.showInSection,
							ShowInCard: dto.showInCard,
							ConvertInPDF: dto.convertInPDF,
							MacrosList: convertedData.macrosListDto,
							MacrosSettings: convertedData.macrosSettingsDto,
							TableParts: convertedData.tablePartsDto
						}
					};
					Ext.callback(callback, scope, [entityDto]);
				},
				this
			);
		},

		convertToAngularDto: function(entityDto, callback, scope) {
			const columnValues = entityDto.columnValues;
			BPMSoft.chain(
				function(next) {
					this._convertTablePartsToAngularDto(columnValues.TableParts, function(tablePartsDto) {
						next({
							tablePartsDto: tablePartsDto
						});
					}, this);
				},
				function(next, convertedData) {
					if (this._canUse7xFilters()) {
						this._convertMacrosListToAngularDto(columnValues.MacrosSettings, function(macrosListDto) {
							convertedData.macrosSettingsDto = macrosListDto;
							convertedData.macrosListDto = columnValues.MacrosList;
							next(convertedData);
						}, this);
					} else {
						this._convertMacrosListToAngularDto(columnValues.MacrosList, function(macrosListDto) {
							convertedData.macrosSettingsDto = columnValues.MacrosSettings;
							convertedData.macrosListDto = macrosListDto;
							next(convertedData);
						}, this);
					}
				},
				function(next, convertedData) {
					const angularDto = {
						id: columnValues.Id,
						caption: columnValues.Caption,
						moduleId: columnValues.SysModule.value,
						moduleName: columnValues.SysModule.displayValue,
						typeId: columnValues.Type.value,
						typeName: columnValues.Type.displayValue,
						showInSection: columnValues.ShowInSection,
						showInCard: columnValues.ShowInCard,
						convertInPDF: columnValues.ConvertInPDF,
						macrosList: convertedData.macrosListDto,
						macrosSettings: convertedData.macrosSettingsDto,
						tableParts: convertedData.tablePartsDto
					};
					Ext.callback(callback, scope, [angularDto]);
				},
				this
			);
		},
	});

	return BPMSoft.WordPrintableConverter;
});
