﻿define("DefaultValueWebLeadFormModule", ["ext-base", "BPMSoft", "sandbox",
		"DefaultValueWebLeadFormModuleResources", "Lead", "CardViewGenerator", "LookupUtilities", "ViewUtilities",
		"GeneratedWebForm", "ConfigurationEnums"],
	function(Ext, BPMSoft, sandbox, resources, lead, cardViewGenerator, LookupUtilities, ViewUtilities,
			GeneratedWebForm, ConfigurationEnums) {
		function createConstructor(context) {
			var recordId;
			var renderContainer;
			var view;
			var viewModel;
			var viewConfig;
			var itemsContainer;
			var action = '';
			var columnsCount = 0;
			var Ext = context.Ext;
			var sandbox = context.sandbox;
			var BPMSoft = context.BPMSoft;
			var columnItems = Ext.create("BPMSoft.Collection");

			var getItemViewConfig = function(columnName, action) {
				var column = lead.columns[columnName];
				var columnDataValueType = column.dataValueType;
				column.type = BPMSoft.ViewModelSchemaItem.ATTRIBUTE;
				var controlConfig;
				var id = columnName + "ValueConatiner";
				var result = {
					className: "BPMSoft.Container",
					id: id,
					selectors: {
						wrapEl: "#" + id
					},
					classes: {
						wrapClassName: "detail-edit-container-user-class"
					}
				};
				if (action === ConfigurationEnums.CardState.View) {
					var captionConfig = cardViewGenerator.generateLabelConfig(lead, column, {}, false, 'left', action);
					var valueConfig = cardViewGenerator.generateLabelConfig(lead, column, {}, true, 'right', action);
					result.items = [captionConfig, valueConfig];
				} else {
					controlConfig = BPMSoft.getControlConfigByDataValueType(columnDataValueType);
					if (columnDataValueType === BPMSoft.DataValueType.BOOLEAN) {
						controlConfig.checked = {
							bindTo: columnName
						};
					} else {
						controlConfig.value = {
							bindTo: columnName
						};
					}
					if (isLookup(columnDataValueType)) {
						controlConfig.list = {
							bindTo: getLookupListColumnName(columnName)
						};
						controlConfig.tag = columnName;
						controlConfig.loadVocabulary = {
							bindTo: 'loadVocabulary'
						};
					}

					result.items = [
						{
							className: "BPMSoft.Container",
							id: "captionContainer" + id,
							selectors: {
								wrapEl: "#captionContainer" + id
							},
							classes: {
								wrapClassName: "controlCaption"
							},
							items: [
								{
									className: "BPMSoft.Label",
									caption: column.caption,
									width: (action !== ConfigurationEnums.CardState.View) ? "80%" : "100%"
								},
								{
									className: "BPMSoft.Button",
									classes: { wrapperClass: 'detail-delete-btn-user-class' },
									imageConfig: resources.localizableImages.DeleteIcon,
									style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
									click: {
										bindTo: "deleteItem"
									},
									tag: columnName,
									visible: (action !== ConfigurationEnums.CardState.View),
									enabled: (action !== ConfigurationEnums.CardState.View)
								}
							]
						},
						controlConfig
					];
				}
				return result;
			};

			var getMainViewConfig = function() {
				var addMenuItems = [];
				var columns = lead.columns;
				BPMSoft.each(columns, function(item) {
					if ((item.usageType === 0) && (item.name.indexOf("Str") === -1)) {
						addMenuItems.push({
							caption: item.caption,
							tag: item.name,
							click: {
								bindTo: "addItem"
							},
							enabled: {
								bindTo: getColumnAddItemEnabledPropertyName(item.name)
							}
						});
					}
				});
				var headerConfig = getHeaderConfig();
				var recommendationConfig = ViewUtilities.getContainerConfig('usertask-recommendation');
				recommendationConfig.items = [
					Ext.create('BPMSoft.Label', {
						id: 'usertask-recommendation-label',
						selectors: {
							wrapEl: '#usertask-recommendation-label'
						},
						caption: ((action === ConfigurationEnums.CardState.View) && (columnsCount === 0))
							? resources.localizableStrings.DefaultValuesNotSetHintMessage
							: resources.localizableStrings.SettingsHintMessage,
						visible: ((action !== ConfigurationEnums.CardState.View) || (columnsCount === 0))
					})
				];
				var config = [
					headerConfig,
					{
						className: "BPMSoft.Container",
						id: "utils",
						selectors: {
							wrapEl: "#utils"
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "utils-left",
								selectors: {
									wrapEl: "#utils-left"
								},
								items: [
									{
										className: "BPMSoft.Button",
										caption: resources.localizableStrings.SaveButtonCaption,
										click: {
											bindTo: "saveValues"
										},
										visible: (action !== ConfigurationEnums.CardState.View),
										style: BPMSoft.controls.ButtonEnums.style.ORANGE
									}, {
										className: "BPMSoft.Button",
										caption: resources.localizableStrings.EditButtonCaption,
										click: {
											bindTo: "edit"
										},
										visible: (action === ConfigurationEnums.CardState.View)
									}, {
										className: "BPMSoft.Button",
										caption: resources.localizableStrings.CancelButtonCaption,
										click: {
											bindTo: "back"
										}
									},
									{
										className: "BPMSoft.Button",
										caption: resources.localizableStrings.AddColumnButtonCaption,
										menu: {
											items: addMenuItems
										},
										visible: (action !== ConfigurationEnums.CardState.View)
									}
								]
							}
						]
					},
					recommendationConfig,
					{
						className: "BPMSoft.Container",
						id: "autoGeneratedLeftContainer",
						selectors: {
							wrapEl: "#autoGeneratedLeftContainer"
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "columnsContainer",
								selectors: {
									wrapEl: "#columnsContainer"
								},
								items: []
							}
						]
					}
				];
				return config;
			};

			var getViewModel = function() {
				var initValues = {
					header: ""
				};
				var columns = lead.columns;
				BPMSoft.each(columns, function(item) {
					initValues[getColumnAddItemEnabledPropertyName(item.name)] = true;
				});
				return Ext.create("BPMSoft.BaseViewModel", {
					entitySchema: lead,
					values: initValues,
					methods: {
						saveValues: function() {
							var columnValues = [];
							columnItems.eachKey(function(key) {
								var columnValue = viewModel.get(key);
								if (columnValue && columnValue.value) {
									try {
										Ext.decode(columnValue.value);
									}
									catch (e) {
										columnValue.value = BPMSoft.encode(columnValue.value);
									}
								}
								columnValue = BPMSoft.encode(columnValue);
								columnValues.push({
									columnName: key,
									value: columnValue
								});
							});
							var update = Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: 'GeneratedWebForm'
							});
							var filters = update.filters;
							var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								'Id', recordId);
							filters.add('IdFilter', idFilter);
							update.setParameterValue('EntityDefaultValues', BPMSoft.encode(columnValues),
								GeneratedWebForm.columns["EntityDefaultValues"].dataValueType);
							update.execute(function(result) {
								if (result.success) {
									viewModel.back();
								} else {
									this.showInformationDialog(result.errorInfo.message);
								}
							});
						},
						edit: function() {
							var moduleId = sandbox.id + '_edit';
							var params = sandbox.publish('GetHistoryState');
							sandbox.publish('PushHistoryState', {hash: params.hash.historyState,
								stateObj: {
									entitySchemaName: GeneratedWebForm.name,
									cardSandBoxId: sandbox.id,
									recordId: params.state.recordId,
									action: ConfigurationEnums.CardState.Edit
								}
							});
							sandbox.loadModule('DefaultValueWebLeadFormModule', {
								renderTo: Ext.get("centerPanel"),
								keepAlive: true,
								id: moduleId
							});
						},
						back: function() {
							sandbox.publish("BackHistoryState");
						},
						addItem: function(columnName) {
							var itemViewConfig = getItemViewConfig(columnName, action);
							var itemView = Ext.create("BPMSoft.Container", Ext.clone(itemViewConfig));
							addColumn(columnName);
							itemsContainer.add(itemView);
							itemView.bind(viewModel);
							getColumnsContainerItems().push(itemViewConfig);
							columnItems.add(columnName, itemViewConfig);
							this.set(getColumnAddItemEnabledPropertyName(columnName), false);
						},
						deleteItem: function(arg1, arg2, arg3, columnName) {
							var item = columnItems.removeByKey(columnName);
							var el = Ext.getCmp(item.id);
							itemsContainer.remove(el);
							var items = getColumnsContainerItems();
							var index = items.indexOf(item);
							items = items.splice(index, 1);
							el.destroy();
							itemsContainer.reRender();
							viewModel.set(getColumnAddItemEnabledPropertyName(columnName), true);
						},
						loadVocabulary: function(args, tag) {
							var config = {
								entitySchemaName: this.entitySchema.columns[tag].referenceSchemaName,
								multiSelect: false,
								columnName: tag,
								columnValue: this.get(tag),
								searchValue: args.searchValue
							};
							var handler = function(args) {
								var columnName = args.columnName;
								var collection = args.selectedRows.collection;
								if (collection.length > 0) {
									this.set(columnName, collection.items[0]);
								}
							};
							openLookup(config, handler);
						},
						onUrlClick: function(columnPath) {
							var value = this.get(columnPath);
							if (BPMSoft.isUrl(value, false)) {
								if (!BPMSoft.isUrl(value, true)) {
									value = 'http://' + value;
								}
								window.open(value);
							}
						}
					}
				});
			};

			var openLookup = function(config, handler) {
				LookupUtilities.Open(sandbox, config, handler, viewModel, renderContainer);
			};

			var getLookupListColumnName = function(columnName) {
				return columnName + "List";
			};

			var getColumnAddItemEnabledPropertyName = function(columnName) {
				return "addItemEnabled" + columnName;
			};

			var getColumnsContainerItems = function() {
				return viewConfig[3].items[0].items;
			};

			var addColumn = function(columnName) {
				var column = lead.columns[columnName];
				var columnDataValueType = column.dataValueType;
				viewModel.set(columnName, null);
				if (isLookup(columnDataValueType)) {
					viewModel.set(getLookupListColumnName(columnName), new BPMSoft.Collection());
					viewModel.columns[columnName] = {
						name: columnName,
						referenceSchemaName: column.referenceSchemaName,
						isLookup: true,
						dataValueType: columnDataValueType
					};
				}
			};

			var getHeaderConfig = function() {
				var mainContainer = ViewUtilities.getContainerConfig('header', 'header');
				var headerNameContainer = ViewUtilities.getContainerConfig('header-name-container', 'header-name-container');
				headerNameContainer.items = [{
					className: "BPMSoft.Label",
					id: 'header-name',
					caption: {
						bindTo: "header"
					}
				}];
				mainContainer.items = [
					headerNameContainer
				];
				return mainContainer;
			};

			var render = function(renderTo) {
				renderContainer = renderTo;
				var historyState = sandbox.publish("GetHistoryState");
				var state = historyState.state;
				if (!viewConfig || (state && (state.action === ConfigurationEnums.CardState.View))) {
					if (state && state.recordId) {
						recordId = state.recordId;
					} else {
						recordId = historyState.hash.historyState.split("/")[1];
					}
					if (state && (state.action === ConfigurationEnums.CardState.View)) {
						action = state.action;
						columnItems = Ext.create("BPMSoft.Collection");
					}
					var select = Ext.create('BPMSoft.EntitySchemaQuery', {rootSchemaName: "GeneratedWebForm"});
					select.addColumn('Name');
					select.addColumn('EntityDefaultValues');
					select.getEntity(recordId, function(result) {
						if (result.success) {
							var entity = result.entity;
							var existingValuesObj = entity ? entity.get("EntityDefaultValues") : null;
							columnsCount = Ext.isEmpty(existingValuesObj) ? 0 : BPMSoft.decode(existingValuesObj).length;
							viewConfig = getMainViewConfig();
							innerRender();
							//viewModel.set("header", resources.localizableStrings.MainHeaderCaption);
							if (existingValuesObj) {
								var existingValues = BPMSoft.decode(existingValuesObj);
								BPMSoft.each(existingValues, function(item) {
									var columnName = item.columnName;
									var columnValue = BPMSoft.decode(item.value);
									if (columnValue && columnValue.value) {
										columnValue.value = BPMSoft.decode(columnValue.value);
									}
									var itemViewConfig = getItemViewConfig(columnName, action);
									var itemView = Ext.create("BPMSoft.Container", Ext.clone(itemViewConfig));
									addColumn(columnName);
									itemsContainer.add(itemView);
									itemView.bind(viewModel);
									getColumnsContainerItems().push(itemViewConfig);
									columnItems.add(columnName, itemViewConfig);
									viewModel.set(getColumnAddItemEnabledPropertyName(columnName), false);
									viewModel.set(columnName, columnValue);
								});
							}
						}
					}, this);
				} else {
					innerRender();
				}
			};

			var innerRender = function() {
				mainViewConfig = Ext.clone(viewConfig);
				view = Ext.create("BPMSoft.Container", {
					id: "mainContainer",
					selectors: {
						wrapEl: "#mainContainer"
					},
					items: mainViewConfig
				});
				if (!viewModel) {
					viewModel = getViewModel();
				}
				view.bind(viewModel);
				view.render(renderContainer);
				itemsContainer = Ext.getCmp("columnsContainer");

				sandbox.publish("InitDataViews", {
					caption: resources.localizableStrings.MainHeaderCaption,
					dataViews: false
				});
			};

			var isLookup = function(dataValueType) {
				return dataValueType === BPMSoft.DataValueType.LOOKUP ||
					dataValueType === BPMSoft.DataValueType.ENUM;
			};

			var init = function() {
				var state = sandbox.publish('GetHistoryState');
				var currentHash = state.hash;
				var currentState = state.state || {};
				if (currentState.moduleId === sandbox.id) {
					return;
				}
				var newState = BPMSoft.deepClone(currentState);
				newState.moduleId = sandbox.id;
				sandbox.publish('ReplaceHistoryState', {
					stateObj: newState,
					pageTitle: null,
					hash: currentHash.historyState,
					silent: true
				});
			};
			return Ext.define('DefaultValueWebLeadFormModule', {
				init: init,
				render: render,
				destroy: function(config) {
					this.callParent(arguments);
				}
			});
		}

	return createConstructor;
});
