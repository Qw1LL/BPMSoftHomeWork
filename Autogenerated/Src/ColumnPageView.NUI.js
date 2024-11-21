define('ColumnPageView', ['ext-base', 'BPMSoft', 'ColumnPageViewResources', 'CardViewGenerator', 'ColumnHelper'],
	function(Ext, BPMSoft, resources, CardViewGenerator, ColumnHelper) {
		function getLabelContainerConfig(columnName, config) {
			return {
				className: 'BPMSoft.Container',
				id: columnName + 'CheckBoxContainer',
				selectors: {
					wrapEl: '#' + columnName + 'CheckBoxContainer'
				},
				classes: {
					wrapClassName: ['custom-inline']
				},
				items: config
			};
		}

		function getContainerConfig(name, classes) {
			var config = {
				className: 'BPMSoft.Container',
				id: name + 'Container',
				selectors: {
					wrapEl: '#' + name + 'Container'
				},
				items: []
			};
			if (Ext.isArray(classes)) {
				config.classes = {
					wrapClassName: classes
				};
			}
			return config;
		}

		function getLookupRadioConfig(tag) {
			return [
				{
					className: 'BPMSoft.RadioButton',
					tag: tag,
					enabled: {
						bindTo: 'isEnabled'
					},
					checked: {
						bindTo: 'lookupToken'
					}
				},
				{
					className: 'BPMSoft.Label',
					caption: resources.localizableStrings['Lookup' + tag + 'Caption']
				}
			];
		}

		function getItemConfig(columnName, captionName, dataValueType, binding) {
			var _captionName = captionName || columnName;
			var config = {
				type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
				name: columnName,
				columnPath: columnName,
				caption: resources.localizableStrings[_captionName + 'Caption'],
				dataValueType: dataValueType
			};
			return config;
		}

		function getLookupConfig() {

			var nameItemConfig = getItemConfig('LookupName', 'Name', BPMSoft.DataValueType.TEXT);
			var captionItemConfig = getItemConfig('LookupCaption', 'LookupCaption', BPMSoft.DataValueType.TEXT);
			var itemConfig = getItemConfig('Lookup', 'Lookup', BPMSoft.DataValueType.LOOKUP);

			var controlConfig = CardViewGenerator.generateControlConfig(this, itemConfig, {});
			Ext.apply(controlConfig, {
				enabled: {
					bindTo: 'isExistLookupEnabled'
				}
			});

			var nameControlConfig = CardViewGenerator.generateControlConfig(this, nameItemConfig, {});
			Ext.apply(nameControlConfig, {
				enabled: {
					bindTo: 'isNewLookupEnabled'
				}
			});
			var captionControlConfig = CardViewGenerator.generateControlConfig(this, captionItemConfig, {});
			Ext.apply(captionControlConfig, {
				enabled: {
					bindTo: 'isNewLookupEnabled'
				}
			});

			var config = getContainerConfig.call(this, 'lookup', ['lookupContainer']);
			var radioBoxExistConfig = getContainerConfig.call(this, 'lookupExist', ['custom-inline']);
			radioBoxExistConfig.items = getLookupRadioConfig.call(this, 'Exist');
			var controlExistConfig = getContainerConfig.call(this, 'lookupExistControl', ['lookupTypeContainer']);
			controlExistConfig.items.push(CardViewGenerator.generateLabelConfig(this, itemConfig, {}));
			controlExistConfig.items.push(controlConfig);
			var radioBoxNewConfig = getContainerConfig.call(this, 'lookupNew', ['custom-inline']);
			radioBoxNewConfig.items = getLookupRadioConfig.call(this, 'New');
			var controlNewConfig = getContainerConfig.call(this, 'lookupNewControl', ['lookupTypeContainer']);
			controlNewConfig.items.push(CardViewGenerator.generateLabelConfig(this, captionItemConfig, {}));
			controlNewConfig.items.push(captionControlConfig);
			controlNewConfig.items.push(CardViewGenerator.generateLabelConfig(this, nameItemConfig, {}));
			controlNewConfig.items.push(nameControlConfig);
			config.items.push(radioBoxExistConfig, controlExistConfig, radioBoxNewConfig, controlNewConfig);
			return config;
		}

		function getConfig(columnsCollection) {
			var controlsConfig = [];
			var enabledColumns = ['Title', 'IsRequired', 'IsMultiline', 'IsEnum'];
			var enumColumns = ['StringType', 'FloatType', 'DateType'];
			BPMSoft.each(columnsCollection, function(columnName) {
				var column = this.columns[columnName];
				var itemConfig = getItemConfig(columnName, columnName, column.dataValueType);
				if (enumColumns.indexOf(columnName) >= 0) {
					this.columns[columnName].isRequired = true;
					itemConfig.columnType = BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN;
					itemConfig.customConfig = {
						list: {
							bindTo: 'EnumList'
						},
						prepareList: {
							bindTo: 'loadEnumItems'
						}
					};
				}
				var labelConfig = CardViewGenerator.generateLabelConfig(this, itemConfig, {});
				var controlConfig = CardViewGenerator.generateControlConfig(this, itemConfig, {});
				if (enabledColumns.indexOf(columnName) < 0) {
					controlConfig.enabled = {
						bindTo: 'isEnabled'
					};
				}
				if (columnName === 'Lookup') {
					controlsConfig.push(getLookupConfig.call(this));
				} else {
					if (column.dataValueType === BPMSoft.DataValueType.BOOLEAN) {
						controlsConfig.push(getLabelContainerConfig.call(this, columnName,
							[labelConfig, controlConfig]));
					} else {
						controlsConfig.push(labelConfig, controlConfig);
					}
				}
				if (columnName === 'Name') {
					var prefix = BPMSoft.SysSettings.cachedSettings.SchemaNamePrefix;
					if (!Ext.isEmpty(prefix) && prefix.length > 0) {
						controlsConfig.push({
							className: 'BPMSoft.Label',
							id: 'prefixLabel',
							caption: Ext.String.format(resources.localizableStrings.PrefixMask, prefix)
						});
					}
				}
			}, this);
			return controlsConfig;
		}

		function generate(columnConfig, viewModel) {
			var columnsCollection = ['Title', 'Name'];
			switch (columnConfig.type.enumName) {
				case ColumnHelper.Type.STRING.enumName:
					columnsCollection.push('StringType', 'IsMultiline');
					break;
				case ColumnHelper.Type.FLOAT.enumName:
					if (columnConfig.type.baseDataType !== 'Integer') {
						columnsCollection.push('FloatType');
					}
					break;
				case ColumnHelper.Type.DATE.enumName:
					columnsCollection.push('DateType');
					break;
				case ColumnHelper.Type.LOOKUP.enumName:
					columnsCollection.push('Lookup', 'IsEnum');
					break;
			}
			if (columnConfig.type.enumName !== ColumnHelper.Type.BOOLEAN.enumName) {
				columnsCollection.push('IsRequired');
			}
			var controlsConfig = getConfig.call(viewModel, columnsCollection);

			var viewConfig = {
				id: 'mergeDuplicatesContainer',
				selectors: {
					wrapEl: '#mergeDuplicatesContainer'
				},
				items: [
					{
						className: 'BPMSoft.Container',
						id: 'captionContainer',
						selectors: {
							wrapEl: '#captionContainer'
						},
						classes: {
							wrapClassName: ['captionContainer']
						},
						items: [
							{
								className: 'BPMSoft.Label',
								id: 'captionLabel',
								caption: {
									bindTo: 'getHeader'
								}
							}
						]
					},
					{
						className: 'BPMSoft.Container',
						id: 'buttonsContainer',
						selectors: {
							wrapEl: '#buttonsContainer'
						},
						items: [
							{
								className: 'BPMSoft.Button',
								id: 'acceptButton',
								caption: resources.localizableStrings.AcceptButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								tag: 'AcceptButton',
								click: {
									bindTo: 'onAcceptClick'
								}
							},
							{
								className: 'BPMSoft.Button',
								id: 'cancelButton',
								caption: resources.localizableStrings.CancelButtonCaption,
								tag: 'CancelButton',
								click: {
									bindTo: 'onCancelClick'
								}
							},
							{
								className: 'BPMSoft.Container',
								id: 'controlsContainer',
								selectors: {
									wrapEl: '#controlsContainer'
								},
								items: controlsConfig
							}
						]
					}
				]
			};

			return viewConfig;
		}

		return {
			generate: generate
		};
	});
