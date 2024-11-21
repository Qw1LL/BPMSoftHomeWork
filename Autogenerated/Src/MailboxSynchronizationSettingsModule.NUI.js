define("MailboxSynchronizationSettingsModule", ["sandbox", "ext-base", "BPMSoft",
		"MailboxSynchronizationSettingsModuleResources", "ServiceHelper", "MaskHelper"],
	function(sandbox, Ext, BPMSoft, resources, ServiceHelper, MaskHelper) {
		var viewModel = null;
		var viewConfig;

		function getView() {
			viewConfig = Ext.create("BPMSoft.Container", {
				id: "main",
				markerValue: resources.localizableStrings.WindowCaption,
				selectors: {
					wrapEl: "#main"
				},
				items: [
					{
						className: "BPMSoft.Label",
						caption: resources.localizableStrings.WindowCaption,
						classes: {
							labelClass: ["page-caption-label"]
						},
						width: "100%"
					},
					{
						className: "BPMSoft.Container",
						id: "topButtons",
						selectors: {
							wrapEl: "#topButtons"
						},
						classes: {
							wrapClassName: ["container-spacing"]
						},
						items: [
							{
								className: "BPMSoft.Button",
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								caption: resources.localizableStrings.AddButtonCaption,
								click: {
									bindTo: "onAddButtonClick"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "consumerSecretEdit",
						selectors: {
							wrapEl: "#consumerSecretEdit"
						},
						classes: {
							wrapClassName: ["container-spacing"]
						},
						items: [
							{
								className: "BPMSoft.Grid",
								type: "tiled",
								primaryColumnName: "Id",
								primaryDisplayColumnName: "UserName",
								activeRow: {
									bindTo: "activeRowId"
								},
								columnsConfig: [
									[
										{
											cols: 24,
											key: [
												{
													name: {
														bindTo: "UserName"
													},
													type: "title"
												}
											]
										}
									]
								],
								collection: {
									bindTo: "mailboxGridData"
								},
								activeRowAction: {
									bindTo: "onActiveRowSelect"
								},
								activeRowActions: [
									{
										className: "BPMSoft.Button",
										style: BPMSoft.controls.ButtonEnums.style.ORANGE,
										caption: resources.localizableStrings.EditButtonCaption,
										markerValue: resources.localizableStrings.EditButtonCaption,
										tag: "Edit"
									},
									{
										className: "BPMSoft.Button",
										style: BPMSoft.controls.ButtonEnums.style.ORANGE,
										caption: resources.localizableStrings.DeleteButtonCaption,
										markerValue: resources.localizableStrings.DeleteButtonCaption,
										tag: "Delete"
									}
								],
								watchedRowInViewport: {
									bindTo: "loadNext"
								}
							}
						]
					}
				]
			});
			return viewConfig;
		}

		function getViewModel() {
			return Ext.create("BPMSoft.BaseViewModel", {
				values: {
					activeRowId: null,
					mailboxGridData: Ext.create("BPMSoft.BaseViewModelCollection")
				},
				methods: {

					getData: function() {
						Ext.Ajax.request({
							url: BPMSoft.workspaceBaseUrl + "/rest/ImapUtilitiesService/GetMailboxes",
							headers: {
								"Accept": "application/json",
								"Content-Type": "application/json"
							},
							method: "POST",
							success: function(response) {
								var responseItems = BPMSoft.decode(response.responseText);
								var collection = this.get("mailboxGridData");
								collection.clear();
								var results = {};
								for (var i = 0; i < responseItems.length; i++) {
									var mailbox = responseItems[i];
									results[mailbox.Id] = Ext.create("BPMSoft.BaseViewModel", {
										rowConfig: {
											Id: { dataValueType: BPMSoft.DataValueType.GUID },
											UserName: {dataValueType: BPMSoft.DataValueType.TEXT }
										},
										values: mailbox
									});
								}
								collection.loadAll(results);
								var map = collection.collection.map;
								var keys = collection.collection.keys;
								var items = collection.getItems();
								for (var y = 0; y < items.length; y++) {
									var item = items[y];
									var itemId = item.values.Id;
									map[itemId] = item;
									keys[y] = itemId;
								}
								MaskHelper.HideBodyMask();
							},
							scope: this
						});
					},

					onActiveRowSelect: function(tag) {
						if (tag === "Delete") {
							this.onDeleteButtonClick();
						} else if (tag === "Edit") {
							this.onEditButtonClick();
						}
					},

					onAddButtonClick: function() {
						sandbox.publish("PushHistoryState", {
								hash: "MailboxSynchronizationSettingsPageModule",
								stateObj: { id: null }
							});
					},

					/**
					 * ####### ######### ######## #### # ############### #######, ########## ## ####.
					 */
					onDeleteButtonClick: function() {
						var recordId = this.get("activeRowId");
						if (!recordId) {
							return;
						}
						var messageBoxConfig = {
							style: BPMSoft.MessageBoxStyles.ORANGE
						};
						this.showConfirmationDialog(resources.localizableStrings.DeleteConfirmation,
								function getSelectedButton(returnCode) {
							if (returnCode !== BPMSoft.MessageBoxButtons.YES.returnCode) {
								return;
							}
							this.set("activeRowId", null);
							MaskHelper.ShowBodyMask();
							var deleteQuery = Ext.create("BPMSoft.DeleteQuery", {
								rootSchemaName: "MailboxSyncSettings"
							});
							deleteQuery.filters.addItem(
								deleteQuery.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
								"Id", recordId));
							deleteQuery.execute(function(response) {
								if (!response.success) {
									MaskHelper.HideBodyMask();
									this.showConfirmationDialog(resources.localizableStrings.RecordCannotBeDeleted);
									var errorInfo = response.errorInfo;
									throw new BPMSoft.UnknownException({
										message: errorInfo.message
									});
								}
								this.removeScheduledSynchronizationJob(function() {
									this.getData();
								}, this);
							}, this);
						}, ["yes", "no"], messageBoxConfig);
					},

					/**
					 * ####### ############### ####### ############# ##### ### ######## ############.
					 * @param {Function} callback ####### ######### ######.
					 * @param {Object} scope ######## ###### ####### ######### ######.
					 */
					removeScheduledSynchronizationJob: function(callback, scope) {
						var methodName = "CreateDeleteSyncJob";
						ServiceHelper.callService({
							serviceName: "MailboxSynchronizationSettingsService",
							methodName: methodName,
							data: {create: false},
							callback: function(response) {
								var result = response[methodName + "Result"];
								if (result) {
									MaskHelper.HideBodyMask();
									this.showInformationDialog(result);
									return;
								}
								callback.call(scope);
							},
							scope: this
						});
					},

					onEditButtonClick: function() {
						var recordId = this.get("activeRowId");
						sandbox.publish("PushHistoryState", {
								hash: "MailboxSynchronizationSettingsPageModule",
								stateObj: {id: recordId}
							});
					}
				}
			});
		}

		function init() {

		}

		function render(renderTo) {
			if (viewModel) {
				var config = BPMSoft.deepClone(viewConfig);
				var genView = Ext.create(config.className || "BPMSoft.Container", config);
				genView.bind(viewModel);
				genView.render(renderTo);
				return;
			}
			var view = getView();
			viewModel = getViewModel();
			viewModel.getData();
			view.bind(viewModel);
			view.render(renderTo);
		}

		return {
			init: init,
			render: render
		};
	});
