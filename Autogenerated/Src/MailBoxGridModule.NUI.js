define('MailBoxGridModule', ['ext-base', 'BPMSoft', 'sandbox',
	'MailBoxGridModuleResources'],
	function(Ext, BPMSoft, sandbox, resources) {

		function getActiveRow(scope) {
			var activeRow = scope.get('activeRowId')
			if (activeRow !== undefined) {
				var gridData = scope.get('gridData')
				return gridData.get(activeRow);
			}
			return null;
		}

		function getView() {
			var container = Ext.create('BPMSoft.Container', {
				id: 'main',
				selectors: {
					wrapEl: '#main'
				},
				items: [
					{
						className: 'BPMSoft.Container',
						id: 'windowCaptionContainer',
						selectors: {
							wrapEl: '#windowCaptionContainer'
						},
						classes: {
							wrapClassName: ['window-caption-container']
						},
						items: [
							{
								className: 'BPMSoft.Label',
								caption: resources.localizableStrings.WindowCaption,
								classes: {
									labelClass: ['windowcaption-label']
								},
								width: '100%'
							}
						]
					},
					{
						className: 'BPMSoft.Container',
						id: 'addNewBtnContainer',
						selectors: {
							wrapEl: '#addNewBtnContainer'
						},
						classes: {
							wrapClassName: ['addnew-button-container']
						},
						items: [
							{
								className: 'BPMSoft.Button',
								id: 'btnAddNew',
								caption: resources.localizableStrings.AddNewCaption,
								width: '150px',
								style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
								click: {
									bindTo: 'onAddNewBtnClick'
								}
							}
						]
					},
					{
						className: 'BPMSoft.Container',
						id: 'gridContainer',
						selectors: {
							wrapEl: '#gridContainer'
						},
						classes: {
							wrapClassName: ['grid-container']
						},
						items: [
							{
								className: 'BPMSoft.Grid',
								type: 'tiled',
								primaryColumnName: 'Id',
								activeRow: {
									bindTo: 'activeRowId'
								},
								columnsConfig: [
									{
										cols: 24,
										key: [
											{
												name: {
													bindTo: 'Name'
												}
											}
										]
									}
								],
								collection: {
									bindTo: 'gridData'
								},
								activeRowAction: {
									bindTo: 'onActiveRowAction'
								},
								activeRowActions: [{
									className: 'BPMSoft.Button',
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									caption: resources.localizableStrings.DeleteCaption,
									tag: 'Delete'
								},
								{
									className: 'BPMSoft.Button',
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									caption: resources.localizableStrings.TuneCaption,
									tag: 'Tune'
								},
								{
									className: 'BPMSoft.Button',
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									caption: resources.localizableStrings.AccessCaption,
									tag: 'Access'
								}]
							}
						]
					}
				]
			});
			return container;
		}

		function getViewModel() {
			var model = Ext.create('BPMSoft.BaseViewModel', {
				values: {
					activeRowId: null,
					gridData: Ext.create('BPMSoft.BaseViewModelCollection', {
						rowConfig: { Id: 'Id', Name: 'Name'}
					})
				},
				methods: {
					getData: function() {
					},
					onActiveRowAction: function(tag) {
						var activeRow = getActiveRow(this);
						if (activeRow !== null) {
							var id = activeRow.values['Id'];
							var name = activeRow.values['Name'];
						}
					}
				}
			});
			return model;
		}

		function render(renderTo) {
			var view = getView();
			//var viewModel = getViewModel();
			//viewModel.getData();
			//view.bind(viewModel);
			view.render(renderTo);
		}

		return {
			render: render
		}
	});
