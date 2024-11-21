define('ForLookupPage', ['ext-base', 'BPMSoft', 'sandbox', 'ForLookupPageResources', 'SysModule', 'LocalizationUtilities'],
	function(Ext, BPMSoft, sandbox, resources, SysModule, LocalizationUtilities) {
/*
		function getItemsConfig() {
			return [
				{
					className: 'BPMSoft.Container',
					id: 'controlsContainerShowLookupPage',
					selectors: {
						wrapEl: '#controlsContainerShowLookupPage'
					},
					items: [
						{
							className: 'BPMSoft.Button',
							caption: 'Load',//resources.localizableStrings.SelectButtonCaption,
							tag: 'ShowLookupPageButton',
							click: {
								bindTo: 'onClick'
							}
						},
						{
							className: 'BPMSoft.Button',
							caption: 'Test Query',
							click: {
								bindTo: 'testQuery'
							}
						},
						{
							className: 'BPMSoft.TextEdit',
							id: 'textEditForLookupPage',
							value: {
								bindTo: 'schemaName'
							}
						}
					]
				},
				{
					className: 'BPMSoft.Container',
					id: 'lookupPageContainer',
					selectors: {
						wrapEl: '#lookupPageContainer'
					},
					items: []
				}
			];
		}

		function getView(itemsConfig) {
			var view = Ext.create('BPMSoft.Container', {
				id: 'containerForLookupPage',
				selectors: {
					wrapEl: '#containerForLookupPage'
				},
				items: itemsConfig
			});
			return view;
		}

		function getViewModel() {
			return Ext.create('BPMSoft.BaseViewModel', {
				values: {
					schemaName: ''
				},
				methods: {
					onClick: function() {
						var lookupContainer = Ext.get('containerForLookupPage');
						sandbox.loadModule('LookupPage', { renderTo: lookupContainer});
					},
					testQuery: function() {
						var select = Ext.create('BPMSoft.EntitySchemaQuery', {
							rootSchema: SysModule
						});
						select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, 'Id');
						LocalizationUtilities.addLocalizableColumn(select, 'Caption',
							'1A778E3F-0A8E-E111-84A3-00155D054C03', 'CaptionCulture1');
						LocalizationUtilities.addLocalizableColumn(select, 'Caption',
							'A5420246-0A8E-E111-84A3-00155D054C03', 'CaptionCulture2');
						LocalizationUtilities.addLocalizableColumn(select, 'ModuleHeader',
							'1A778E3F-0A8E-E111-84A3-00155D054C03', 'ModuleHeaderCulture1');
						LocalizationUtilities.addLocalizableColumn(select, 'ModuleHeader',
							'A5420246-0A8E-E111-84A3-00155D054C03', 'ModuleHeaderCulture2');
						LocalizationUtilities.addLocalizableColumn(select, 'Caption');
						LocalizationUtilities.addLocalizableColumn(select, 'ModuleHeader');
						select.getEntityCollection(function(response) {

						});
					}
				}
			});
		}

		function render(renderTo) {
			var itemsConfig = getItemsConfig();
			var view = getView(itemsConfig);
			var viewModel = getViewModel();
			view.bind(viewModel);
			sandbox.subscribe('getLookupInfo', function() {
				var lookupInfo = {
					entitySchemaName: viewModel.get('schemaName')
				};
				return lookupInfo;
			});
			sandbox.subscribe('resultSelectedRows', function(args) {
				var s = args.selectedRows;
				alert(s.collection.items);
				alert(s.collection.keys);
			});
			view.render(renderTo);
		}

		function init() {
		}

		return {
			init: init,
			render: render
		};
	}*/
	var viewModel;
	var view;
	var renderContainer;
	var moduleId;
	var clientapplicationId;

	function render1(renderTo) {
		moduleId = sandbox.id;
		var goldCrownVisibleBinding = {
			bindTo: 'Field1',
			bindConfig: {
				converter: function(x) {
					if (x && x.value === '0') {
						return true;
					}
					return false;
				}
			}
		};
		var masterCardBinding = {
			bindTo: 'Field1',
			bindConfig: {
				converter: function(x) {
					if (x && x.value === '1') {
						return true;
					}
					return false;
				}
			}
		};

		view = Ext.create('BPMSoft.ControlGroup', {
			id: 'CardParameterModule-main',
			caption: 'Заголовок группы',
			selectors: {
				wrapEl: '#CardParameterModule-main'
			},
//				classes: {
//					wrapClassName: 'table-container'
//				},
			items: [
				{
					className: 'BPMSoft.Container',
					id: 'CardParameterModule-leftContainer',
					selectors: {
						wrapEl: '#CardParameterModule-leftContainer'
					},
//						classes: {
//							wrapClassName: ['header']
//						},
					items: [
						{
							className: 'BPMSoft.Label',
							caption: 'Отображение полей'
						},
						{
							className: 'BPMSoft.ComboBoxEdit',
							value: {
								bindTo: 'Field1'
							},
							list: {
								bindTo: 'Field1List'
							},
							prepareList: {
								bindTo: 'PrepareList'
							}
						},
						{
							className: 'BPMSoft.Label',
							caption: 'Поле 0',
							visible: goldCrownVisibleBinding
						},
						{
							className: 'BPMSoft.Label',
							caption: 'Поле 1-0',
							visible: masterCardBinding
						},
						{
							className: 'BPMSoft.TextEdit',
							visible: {
								bindTo: 'Field1',
								bindConfig: {
									converter: function(x) {
										if (x && x.value) {
											return true;
										}
										return false;
									}
								}
							}
						},
						{
							className: 'BPMSoft.Label',
							caption: 'Поле 1-1',
							visible: masterCardBinding
						},
						{
							className: 'BPMSoft.TextEdit',
							visible: masterCardBinding
						}
					]
				}
			]
		});

		if (viewModel) {
			view.bind(viewModel);
			view.render(renderTo);
			return;
		}

		viewModel = Ext.create('BPMSoft.BaseViewModel', {
			columns: {
				Field1: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isRequired: true,
					isLookup: true
				}
			},
			values: {
				Field1List: new BPMSoft.Collection()
			},
			methods: {
				PrepareList: function(filter, list) {
					list.clear();
					var items = {
						'0': {
							value: '0',
							displayValue: '0'
						},
						'1': {
							value: '1',
							displayValue: '1'
						}
					};
					list.loadAll(items);
				}
			}
		});
		view.bind(viewModel);
		view.render(renderTo);
		renderContainer = renderTo;
	}

	function init() {
		var state = sandbox.publish('GetHistoryState');
		var currentHash = state.hash;
		var currentState = state.state || {};
		if (currentState.moduleId === sandbox.id) {
			return;
		}
		sandbox.publish('ReplaceHistoryState', {
			stateObj: {
				moduleId: sandbox.id
			},
			pageTitle: null,
			hash: currentHash.historyState,
			silent: true
		});
	}

	return {
		init: init,
		render: render1
	};
});
