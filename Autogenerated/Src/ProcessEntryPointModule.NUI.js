define("ProcessEntryPointModule", ["ProcessEntryPointModuleResources", "BaseModule"], function(resources) {

	/**
	 * @class BPMSoft.configuration.ProcessEntryPointModule
	 */
	Ext.define("BPMSoft.configuration.ProcessEntryPointModule", {
		extend: "BPMSoft.BaseModule",
		alternateClassName: "BPMSoft.ProcessEntryPointModule",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		/**
		 *
		 */
		viewModel: null,

		/**
		 *
		 */
		config: {
			schema: {
				viewConfig: [{
					name: "name",
					itemType: BPMSoft.ViewItemType.GRID_LAYOUT,
					items: [
						{
							name: "Header",
							caption: resources.localizableStrings.ModuleHeader,
							itemType: BPMSoft.ViewItemType.LABEL,
							classes: {labelClass: ["label-margin", "information"]},
							layout: {
								colSpan: 24,
								column: 0,
								row: 0
							}
						},
						{
							name: "ProcessContainer",
							itemType: BPMSoft.ViewItemType.CONTAINER,
							items: [{
								"name": "Caption",
								"caption": resources.localizableStrings.ProcessElement,
								itemType: BPMSoft.ViewItemType.LABEL,
								classes: {labelClass: ["caption"]}
							}, {
								"name": "Process",
								"controlConfig": {"prepareList": {bindTo: "getProcesses"}},
								"labelConfig": {"visible": false},
								"layout": {
									"column": 0,
									"row": 1,
									"colSpan": 24
								}
							}],
							classes: {wrapClassName: ["process-container"]},
							layout: {
								colSpan: 24,
								column: 0,
								row: 1
							}
						},
						{
							name: "ButtonsContainer",
							itemType: BPMSoft.ViewItemType.CONTAINER,
							items: [{
								name: "OKButton",
								click: {bindTo: "onOKButtonClick"},
								caption: resources.localizableStrings.OkButtonCaption,
								style: BPMSoft.controls.ButtonEnums.style.ORANGE,
								itemType: BPMSoft.ViewItemType.BUTTON,
								classes: {textClass: ["button-margin"]}
							}, {
								name: "CancelButton",
								click: {bindTo: "onCancelButtonClick"},
								caption: resources.localizableStrings.CancelButtonCaption,
								itemType: BPMSoft.ViewItemType.BUTTON
							}],
							layout: {
								colSpan: 24,
								column: 0,
								row: 2
							}
						}
					]
				}]
			}
		},

		getViewModelClass: function() {
			return this.Ext.define("BPMSoft.configuration.ProcessEntryPointModel", {
				extend: "BPMSoft.BaseViewModel",
				Ext: null,
				BPMSoft: null,
				sandbox: null,

				columns: {
					Process: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.ENUM,
						isRequired: true
					}
				},

				/**
				 *
				 */
				init: function() {
					var info = this.sandbox.publish("GetProcessEntryPointInfo", null, [this.sandbox.id]);
					this.set("ProcessEntryPointInfo", info);
					this.set("ProcessList", info.processList);
				},

				/**
				 *
				 */
				onCancelButtonClick: function() {
					this.sandbox.publish("CloseProcessEntryPointModule", null, [this.sandbox.id]);
				},

				/**
				 *
				 * @param filter
				 * @param list
				 */
				getProcesses: function(filter, list) {
//					list.clear();
					list.loadAll(this.get("ProcessList"));
				},

				/**
				 *
				 */
				onOKButtonClick: function() {
					if (!this.validate()) {
						return;
					}
					var info = this.get("ProcessEntryPointInfo");
					this.openProcess(this.get("Process").value, info.primaryColumnValue);
					this.onCancelButtonClick();
				},

				openProcess: function(processElementUId, primaryColumnValue) {
					this.sandbox.publish("ProcessExecDataChanged", {
						procElUId: processElementUId,
						recordId: primaryColumnValue,
						scope: this,
						parentMethodArguments: {id: primaryColumnValue},
						parentMethod: function(args) {
							window.console.log(this.Ext.String.format("Process {0} Error", args.id));
						}
					});
				}
			});
		},

		/**
		 *
		 */
		getViewModel: function() {
			return Ext.create(this.viewModelClass, {
				Ext: this.Ext,
				sandbox: this.sandbox,
				BPMSoft: this.BPMSoft
			});
		},

		/**
		 * ############# #########, ######## #####, ########## ##### ###### ############# # #############.
		 * ##### ##### ####### # ############## ######### #############
		 * @virtual
		 */
		init: function() {
			if (!this.viewModel) {
				this.viewModelClass = this.getViewModelClass();
//				this.viewModelClass.openProcess = this.openProcess;
				this.config.viewModelClass = this.viewModelClass;
				this.viewModel = this.getViewModel(this.viewModelClass);
				this.viewModel.init();
			}
		},

		/**
		 *
		 * @param renderTo
		 */
		render: function(renderTo) {
			var viewGenerator = this.Ext.create("BPMSoft.ViewGenerator");
			viewGenerator.generate(this.config, function(viewConfig) {
				var containerName = "ProcessEntryPointModuleContainer";
				var view = this.Ext.create("BPMSoft.Container", {
					id: containerName,
					selectors: {wrapEl: "#" +  containerName},
					items: this.BPMSoft.deepClone(viewConfig),
					classes: {wrapClassName: ["process-entry-point-module"]}
				});
				view.bind(this.viewModel);
				view.render(renderTo);
			}, this);
		},

		/**
		 * ####### ### ######## ## ####### # ########## ######.
		 * @overridden
		 * @param {Object} config ######### ########### ######
		 */
		destroy: function(config) {
			if (config.keepAlive !== true) {
				if (this.viewModel) {
					this.viewModel = null;
				}
				this.callParent(arguments);
			}
		}
	});

	return BPMSoft.ProcessEntryPointModule;
});
