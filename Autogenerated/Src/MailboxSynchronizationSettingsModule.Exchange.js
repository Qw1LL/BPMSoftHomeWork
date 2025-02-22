﻿define("MailboxSynchronizationSettingsModule", ["sandbox", "ext-base", "BPMSoft",
		"MailboxSynchronizationSettingsModuleResources", "MailboxSyncSettingsViewModel", "css!MailboxSynchronizationSettingsModule"],
	function(sandbox, Ext, BPMSoft, resources) {
		var viewModel = null;
		var viewConfig;

		/**
		 * Factory for mailbox syncronization settings view.
		 * @protected
		 * @return {BPMSoft.Container} Instance of MailBoxSyncSettings View
		 */
		function getView() {
			if (!viewConfig) {
				viewConfig = {
					id: "main",
					classes: {
						wrapClassName: ["mainView-EmailSettings"]
					},
					markerValue: resources.localizableStrings.WindowCaptionEx,
					selectors: {
						wrapEl: "#main"
					},
					items: [
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
									className: "BPMSoft.Label",
									caption: resources.localizableStrings.AddMailService,
									click: {
										bindTo: "onAddButtonClick"
									},
									labelClass: ["label-addEmail"]
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
									type: "listed",
									primaryColumnName: "Id",
									primaryDisplayColumnName: "UserName",
									activeRow: {
										bindTo: "activeRowId"
									},
									columnsConfig: [
										{
											cols: 6,
											key: [
												{
													name: {
														bindTo: "SenderEmailAddress"
													},
													type: "title"
												}
											]
										},
										{
											cols: 6,
											key: [
												{
													name: {
														bindTo: "UserName"
													},
													type: "title"
												}
											]
										},
										{
											cols: 6,
											key: [
												{
													name: {
														bindTo: "Type"
													}
												}
											]
										},
										{
											cols: 6,
											key: [
												{
													name: {
														bindTo: "MailBoxOwner"
													}
												}
											]
										}
									],
									captionsConfig: [
										{
											cols: 6,
											name: "E-mail"
										},
										{
											cols: 6,
											name: resources.localizableStrings.UserNameGridCaption
										},
										{
											cols: 6,
											name: resources.localizableStrings.TypeGridCaption
										},
										{
											cols: 6,
											name: resources.localizableStrings.MailBoxOwnerCaption
										}
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
											caption: resources.localizableStrings.EditButtonCaptionEx,
											markerValue: resources.localizableStrings.EditButtonCaptionEx,
											tag: "Edit",
											visible: {
												bindTo: "isSchemaCanEditRight"
											}
										},
										{
											className: "BPMSoft.Button",
											style: BPMSoft.controls.ButtonEnums.style.ORANGE,
											caption: resources.localizableStrings.DeleteButtonCaptionEx,
											markerValue: resources.localizableStrings.DeleteButtonCaptionEx,
											tag: "Delete",
											visible: {
												"bindTo": "isSchemaCanDeleteRight"
											}
										},
										{
											className: "BPMSoft.Button",
											style: BPMSoft.controls.ButtonEnums.style.ORANGE,
											caption: resources.localizableStrings.EditRightsButtonCaption,
											markerValue: resources.localizableStrings.EditRightsButtonCaption,
											tag: "EditRights"
										}
									],
									watchedRowInViewport: {
										bindTo: "loadNext"
									}
								}
							]
						}
					]
				};
			}
			return Ext.create("BPMSoft.Container", BPMSoft.deepClone(viewConfig));
		}

		/**
		 * Factory for mailbox syncronization settings view model.
		 * @protected
		 * @return {BPMSoft.MailboxSyncSettingsViewModel} Instance of MailBoxSyncSettings ViewModel
		 */
		function getViewModel() {
			var viewModelConfig = {
				values: {
					activeRowId: null,
					mailboxGridData: Ext.create("BPMSoft.BaseViewModelCollection")
				},
				sandbox: sandbox,
				BPMSoft: BPMSoft,
				Ext: Ext
			};
			return Ext.create("BPMSoft.MailboxSyncSettingsViewModel", viewModelConfig);
		}

		/**
		 * Replaces the last element in the chain of states, if the module identifier differs from the current.
		 * @protected
		 */
		function initHistoryState() {
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			var newState = BPMSoft.deepClone(currentState);
			newState.moduleId = sandbox.id;
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
		}

		/**
		 * Registers module messages.
		 * @protected
		 */
		function registerMessages() {
			var messages = {
				"GetRecordInfo": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"AddMailBoxEvent": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"MultiDeleteStart": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},
				"MultiDeleteFinished": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			};
			sandbox.registerMessages(messages);
		}

		/**
		 * If flag openAddMailboxSyncSettings is setted to true, opens mailbox adding module.
		 * @private
		 */
		function openAddMailboxSyncSettingsIfNeed() {
			var state = sandbox.publish("GetHistoryState");
			if (state.state.openAddMailboxSyncSettings === true) {
				sandbox.publish("ReplaceHistoryState", {
					hash: state.hash.historyState
				});
				viewModel.methods.openAddMailboxSyncSettings();
			}
		}

		/**
		 * Initializes module
		 * @param {Function} [callback] Callback function.
		 * @param {Object} [scope] Callback scope.
		 * @protected
		 */
		function init(callback, scope) {
			registerMessages();
			initHistoryState();
			viewModel = getViewModel();
			viewModel.init(callback, scope);
		}

		function render(renderTo) {
			sandbox.publish("ChangeHeaderCaption", {
				caption: resources.localizableStrings.WindowCaptionEx,
				dataViews: new BPMSoft.Collection()
			});
			sandbox.subscribe("NeedHeaderCaption", function() {
				sandbox.publish("InitDataViews", {caption: resources.localizableStrings.WindowCaptionEx});
			}, this);
			
			var genView = getView();
			genView.bind(viewModel);
			genView.render(renderTo);
			openAddMailboxSyncSettingsIfNeed();
		}

		return {
			init: init,
			render: render
		};
	});
