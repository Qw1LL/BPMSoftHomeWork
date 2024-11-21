define('GeneratedWebFormPage', ['ext-base', 'BPMSoft', 'sandbox',
		'GeneratedWebForm', 'GeneratedWebFormPageStructure', 'GeneratedWebFormPageResources',
		'GeneratedWebFormUtilities', 'ConfigurationEnums'],
	function(Ext, BPMSoft, sandbox, GeneratedWebForm, structure, resources, GeneratedWebFormUtilities,
			ConfigurationEnums) {
		structure.userCode = function() {
			this.entitySchema = GeneratedWebForm;
			this.name = 'GeneratedWebFormCardViewModel';
			if (Ext.isEmpty(this.entityInfo)) {
				this.entityInfo = {};
			}
			var pageConfig = this.entityInfo.pageConfig;
			if (Ext.isEmpty(pageConfig)) {
				pageConfig = {
					commandLine: false
				};
			} else {
				pageConfig.commandLine = false;
			}
			this.entityInfo.pageConfig = pageConfig;
			var leftPanelItems = [
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Id',
					columnPath: 'Id',
					visible: false,
					viewVisible: false
				},
				{
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Name',
					columnPath: 'Name',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true
				},
				{
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'ExternalURL',
					columnPath: 'ExternalURL',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true,
					customConfig: {
						className: 'BPMSoft.controls.MemoEdit',
						height: '100px'
					}
				},
				{
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: 'ReturnURL',
					columnPath: 'ReturnURL',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true,
					customConfig: {
						className: 'BPMSoft.controls.MemoEdit',
						height: '100px'
					}
				}
			];
			var descriptionItem = {
				type: BPMSoft.ViewModelSchemaItem.GROUP,
				name: 'generatedWebFormDescriptionGroup',
				caption: resources.localizableStrings.DescriptionGroupCaption,
				collapsed: true,
				collapsedchanged: {
					bindTo: 'onDetailCollapsedChanged'
				},
				visible: true,
				leftWidth: '60%',
				rightWidth: '100%',
				wrapContainerClass: 'control-group-container',
				items: [
					{
						type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
						name: 'Description',
						columnPath: 'Description',
						dataValueType: BPMSoft.DataValueType.TEXT,
						visible: true,
						customConfig: {
							className: 'BPMSoft.controls.MemoEdit',
							height: '100px'
						}
					}
				]
			};
			if (this.action !== ConfigurationEnums.CardState.View) {
				this.schema.leftPanel = [
					{
						type: BPMSoft.ViewModelSchemaItem.GROUP,
						name: 'baseElementsControlGroup',
						visible: true,
						collapsed: false,
						wrapContainerClass: 'main-elements-control-group-container',
						items: leftPanelItems
					}
				];

				this.schema.rightPanel = [descriptionItem];
			} else {
				leftPanelItems.push(descriptionItem);
				this.schema.customPanel = leftPanelItems;
			}

			this.methods.getHeader = function() {
				return resources.localizableStrings.PageHeader;
			};

			this.methods.init = function() {
				var scope = this;
				scope.set("FormFieldsConfigured", false);
				scope.set("DesignFormFieldsToSaveCode", false);
				sandbox.subscribe("IncomingPtp", function(result) {
						if (typeof result === 'boolean') {
							scope.set("FormFieldsConfigured", result);
							if (scope.get("DesignFormFieldsToSaveCode") && result) {
								scope.set("DesignFormFieldsToSaveCode", false);
								GeneratedWebFormUtilities.saveFormCodeToFile(scope, scope.get(scope.primaryColumnName));
							}
						} else {
							scope.set("FormFields", result);
						}
					}, ["ViewModule_CardModule_GeneratedWebForm"]);
				GeneratedWebFormUtilities.initCanManageWebForms(this);
			};

			this.methods.save = function() {
				if (!Ext.isEmpty(this.get("FormFields")) || this.get("FormFieldsConfigured")) {
					this.set("FormFieldsConfigured", false);
					this.saveEntity(this.onSaved, this);
				} else {
					this.showConfirmationDialog(resources.localizableStrings.ConfigureFormFields,
						configureFormFields, ['yes', 'no']);
				}
			};

			this.methods.onSaved = function() {
				sandbox.publish('CardModuleResponse', {
					action: this.action,
					success: true,
					uId: this.get(this.entitySchema.primaryColumnName)
				}, [sandbox.id]);
				sandbox.publish('BackHistoryState');
			};

			this.methods.saveFormCodeToFile = function() {
				var recordId = this.get(this.primaryColumnName);
				GeneratedWebFormUtilities.saveFormCodeToFile(this, recordId);
			};

			this.methods.openLeadEditPageDesigner = function() {
				var recordId = this.get(this.primaryColumnName);
				if (this.action === ConfigurationEnums.CardState.Add) {
					var scope = this;
					this.saveEntity(function(result) {
						if (!result) {
							return;
						}
						GeneratedWebFormUtilities.openLeadEditPageDesigner(scope, recordId, scope.action);
					}, this);
				} else {
					GeneratedWebFormUtilities.openLeadEditPageDesigner(this, recordId, this.action);
				}
			};

			this.methods.openDefaultValuesWebLeadForm = function() {
				if (this.action === ConfigurationEnums.CardState.Add) {
					var scope = this;
					this.saveEntity(function(result) {
						if (!result) {
							return;
						}
						configureDefaultValues(scope);
					}, this);
				} else {
					configureDefaultValues(this);
				}
			};

			var configureFormFields = function(result) {
				if (result === BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.saveEntity(function() {
						this.openLeadEditPageDesigner();
					}, this);
					this.action = ConfigurationEnums.CardState.Edit;
				} else {
					this.saveEntity(this.onSaved, this);
				}
			};

			var configureDefaultValues = function(scope) {
				var moduleId = sandbox.id + '_DefValuesModule';
				var params = sandbox.publish('GetHistoryState');
				sandbox.publish('PushHistoryState', {hash: params.hash.historyState,
					stateObj: {
						entitySchemaName: scope.entitySchema.name,
						cardSandBoxId: sandbox.id,
						recordId: scope.get(scope.primaryColumnName),
						action: scope.action
					}
				});
				sandbox.loadModule('DefaultValueWebLeadFormModule', {
					renderTo: scope.renderTo,
					keepAlive: true,
					id: moduleId
				});
			};

			var actions = this.actions;
			if (!actions) {
				actions = [];
			}
			actions.push(
				{
					caption: resources.localizableStrings.CustomizeLeadColumnsFormCaption,
					methodName: "openLeadEditPageDesigner",
					visible: {
						bindTo: 'canManageWebForms'
					}
				}, {
					caption: resources.localizableStrings.CustomizeDefaultValuesFormCaption,
					methodName: "openDefaultValuesWebLeadForm",
					visible: {
						bindTo: 'canManageWebForms'
					}
				}, {
					caption: resources.localizableStrings.SaveFormCodeToFileCaption,
					methodName: "saveFormCodeToFile",
					enabled: {
						bindTo: (this.action === ConfigurationEnums.CardState.Add)
					},
					visible: {
						bindTo: 'canManageWebForms'
					}
				}
			);
			this.actions = actions;
		};
		return structure;
	});
