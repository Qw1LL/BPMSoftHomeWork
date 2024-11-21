define('MailboxFolderSyncSettingsModule', ['sandbox', 'ext-base', 'BPMSoft', 'MailboxFolderSyncSettingsModuleResources'],
	function(sandbox, Ext, BPMSoft, resources) {

		function getView() {
			var container = Ext.create('BPMSoft.Container', {
				id: 'main',
				selectors: {
					wrapEl: '#main'
				},
				items: [
					{
						className: 'BPMSoft.Label',
						caption: resources.localizableStrings.WindowCaption,
						classes: {
							labelClass: ['page-caption-label']
						},
						width: '100%'
					},
					{
						className: 'BPMSoft.Container',
						id: 'topButtons',
						selectors: {
							wrapEl: '#topButtons'
						},
						items: [
							{
								className: 'BPMSoft.Button',
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								caption: resources.localizableStrings.SaveButtonCaption,
								click: {
									bindTo: 'onSaveButtonClick'
								}
							},
							{
								className: 'BPMSoft.Button',
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								caption: resources.localizableStrings.CancelButtonCaption,
								click: {
									bindTo: 'onCancelButtonClick'
								}
							}
						]
					},
					{
						className: 'BPMSoft.Container',
						id: 'mainContainer',
						selectors: {
							wrapEl: '#mainContainer'
						},
						items: [
							{
								className: 'BPMSoft.Container',
								id: 'leftContainer',
								classes: {
									wrapClassName: [
										'left-container'
									]
								},
								selectors: {
									wrapEl: '#leftContainer'
								},
								items: [
									{
										className: 'BPMSoft.Label',
										caption: resources.localizableStrings.GroupsSectionCaption,
										classes: {
											labelClass: ['section-caption-label']
										},
										width: '100%'
									},
									{
										className: 'BPMSoft.Grid',
										id: 'main-grid',
										type: 'listed',
										hierarchical: true,
										multiSelect: true,
										primaryColumnName: 'Id',
										hierarchicalColumnName: 'ParentId',
										activeRow: {
											bindTo: 'activeRowId'
										},
										selectedRows: {
											bindTo: 'selectedRows'
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
											bindTo: 'folderGridData'
										},
										watchedRowInViewport: {
											bindTo: 'loadNext'
										}
									}
								]
							},
							{
								className: 'BPMSoft.Container',
								id: 'rightContainer',
								visible: false,
								classes: {
									wrapClassName: [
										'right-container'
									]
								},
								selectors: {
									wrapEl: '#rightContainer'
								},
								items: [
									{
										className: 'BPMSoft.Label',
										caption: resources.localizableStrings.FolderCreateSection,
										classes: {
											labelClass: ['section-caption-label']
										},
										width: '100%'
									},
									{
										className: 'BPMSoft.Label',
										caption: resources.localizableStrings.AddFolderCaption,
										classes: {
											labelClass: ['caption-label']
										},
										width: '100%'
									},
									{
										id: 'NewFolderNameEdit',
										className: 'BPMSoft.TextEdit',
										value: {
											bindTo: 'NewFolderName'
										},
										classes: {
											wrapClassName: [
												'button-margin'
											]
										}
									},
									{
										className: 'BPMSoft.Button',
										style: BPMSoft.controls.ButtonEnums.style.ORANGE,
										caption: resources.localizableStrings.AddButtonCaption,
										click: {
											bindTo: 'onAddButtonClick'
										}
									}
								]
							}
						]
					}
				]
			});
			return container;
		}

		function getViewModel() {
			return Ext.create('BPMSoft.BaseViewModel', {
				values: {
					activeRowId: null,
					folderGridData: new BPMSoft.Collection(),
					NewFolderName: null,
					mailboxId: null,
					mailboxName: null,
					mailServerId: null,
					mailboxPassword: null,
					selectedRows: null
				},
				methods: {
					getData: function(mailboxId, mailboxName, mailServerId, mailboxPassword, folders) {
						var requestUrl = BPMSoft.workspaceBaseUrl + '/rest/ImapUtilitiesService/GetMailboxFolders';
						var data = {
							mailboxId: mailboxId,
							mailboxName: mailboxName,
							mailServerId: mailServerId,
							mailboxPassword: mailboxPassword
						};
						var scope = this;
						Ext.Ajax.request({
							url: requestUrl,
							headers: {
								'Accept': 'application/json',
								'Content-Type': 'application/json'
							},
							method: 'POST',
							jsonData: data,
							success: function(response, opts) {
								var responseItems = BPMSoft.decode(response.responseText);
								var collection = this.get('folderGridData');
								collection.clear();
								var results = {};
								var selectedRows = [];
								selectedRows.push(responseItems[0].Id);
								for (var i = 0; i < responseItems.length; i++) {
									results[responseItems[i].Id] = Ext.create("BPMSoft.BaseViewModel", {
										rowConfig: {
											Id: { dataValueType: BPMSoft.DataValueType.TEXT },
											Name: {dataValueType: BPMSoft.DataValueType.TEXT },
											ParentId: {dataValueType:  BPMSoft.DataValueType.TEXT },
											Path: {dataValueType: BPMSoft.DataValueType.TEXT}
										},
										values: responseItems[i]
									});
									var path = responseItems[i].Path;
									if (folders.indexOf(path) > -1) {
										selectedRows.push(responseItems[i].Id);
									}
								}
								scope.set('selectedRows', selectedRows);
								collection.loadAll(results);
								var map = collection.collection.map;
								var keys = collection.collection.keys;
								var items = collection.getItems();
								for (var i = 0; i < items.length; i++) {
									var item = items[i];
									var itemId = item.values.Id;
									map[itemId] = item;
									keys[i] = itemId;
								}
							},
							scope: this
						});
					},
					onAddButtonClick: function() {
						var requestUrl = BPMSoft.workspaceBaseUrl + '/rest/ImapUtilitiesService/CreateNewFolder';
						var data = {
							newFolderPath: this.get('NewFolderName'),
							mailboxId: this.get('mailboxId')
						};
						var scope = this;
						Ext.Ajax.request({
							url: requestUrl,
							headers: {
								'Accept': 'application/json',
								'Content-Type': 'application/json'
							},
							method: 'POST',
							jsonData: data,
							success: function(response, opts) {
								scope.set('NewFolderName', '');
							},
							scope: this
						});
					},
					onSaveButtonClick: function() {
						saveChosenFoldersList(this);
						//sandbox.publish('BackHistoryState');
					},
					onCancelButtonClick: function() {
						sandbox.publish('BackHistoryState');
					}
				}
			});
		}

		function saveChosenFoldersList(scope) {
			var selectedRows = scope.get('selectedRows');
			var collection = scope.get('folderGridData').collection.items;
			var checkedCollection = new Array(collection.length);
			for (var i = 0; i < collection.length; i++) {
				checkedCollection[i] = BPMSoft.deepClone(collection[i].values);
				checkedCollection[i].isChecked = (Ext.Array.indexOf(selectedRows, checkedCollection[i].Id) > -1)
					|| (checkedCollection[i].ParentId == null)
					|| (checkedCollection[i].ParentId == '');
			}
			for (var j = 0; j < checkedCollection.length; j++) {
				var currentItem = checkedCollection[j];
				if (currentItem.isChecked) {
					continue;
				}
				currentItemId = currentItem.Id;
				currentItemParentId = currentItem.ParentId;
				for (var k = 0; k < checkedCollection.length; k++) {
					if (checkedCollection[k].ParentId == currentItemId) {
						checkedCollection[k].ParentId = currentItemParentId;
					}
				}
			}
			var l = 0;
			while (l < checkedCollection.length) {
				if (!checkedCollection[l].isChecked) {
					checkedCollection.splice(l, 1);
				} else {
					l++;
				}
			}
			sandbox.publish('ResultSelectedRows', {
				folders: checkedCollection
			}, [sandbox.id]);
			sandbox.publish('BackHistoryState');
		}

		function init() {
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
		}

		function render(renderTo) {
			var view = getView();
			var viewModel = getViewModel();
			var historyState = sandbox.publish('GetParams', null, [sandbox.id]);
			if (historyState) {
				viewModel.set('mailboxId', historyState.mailboxId);
				viewModel.set('mailboxName', historyState.mailboxName);
				viewModel.set('mailServerId', historyState.mailServerId);
				viewModel.set('mailboxPassword', historyState.mailboxPassword);
				viewModel.getData(historyState.mailboxId, historyState.mailboxName,
					historyState.mailServerId, historyState.mailboxPassword, historyState.folders);
			}
			view.bind(viewModel);
			view.render(renderTo);
			/*var grid = Ext.getCmp('main-grid');
			grid.setRowSelected('bpmcrm.BPMSoft', true);
			grid.addRowActions('bpmcrm.BPMSoft');
			grid.fireEvent('selectRow', 'bpmcrm.BPMSoft');
			grid.getSelectedRows();
			grid.fireEvent('rowsSelectionChanged'); */
		}

		return {
			init: init,
			render: render
		};
	});
