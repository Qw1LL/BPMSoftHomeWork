define("VisaPage", ["ext-base", "BPMSoft", "VisaPageStructure", "VisaPageResources", "DocumentVisa",
	"ConfigurationEnums", "ActionButtonHelper", "VisaHelper",
	"BusinessRuleModule", "BaseVisa", "css!VisaHelper"],
	function(Ext, BPMSoft,  structure, resources, DocumentVisa, ConfigurationEnums,
	ActionButtonHelper, VisaHelper, BusinessRuleModule, BaseVisa) {
		structure.userCode = function() {
			var visaResources = VisaHelper.resources.localizableStrings;
			this.entitySchema = BaseVisa;
			this.name = "VisaCardViewModel";

			var config = {
				actions: [{
					name: "approve",
					color: "orange",
					caption: visaResources.Approve,
					click: {
						bindTo: "approve"
					}
				}, {
					name: "reject",
					color: "Red",
					caption: visaResources.Reject,
					click: {
						bindTo: "reject"
					}
				}, {
					name: "changeVizier",
					color: "orange",
					caption: visaResources.ChangeVisaOwner,
					click: {
						bindTo: "changeVizier"
					}
				}]
			};
			var actionButtonsItem = ActionButtonHelper.getActionButtonsConfig(config);
			actionButtonsItem.type = ConfigurationEnums.CustomViewModelSchemaItem.CUSTOM_ELEMENT;
			actionButtonsItem.visible = {
				bindTo: "IsFinal",
				bindConfig: {
					converter: function(value) {
						return !value;
					}
				}
			};

			this.schema.leftPanel = [
				{
					type: BPMSoft.ViewModelSchemaItem.GROUP,
					name: "baseElementsControlGroup",
					visible: true,
					collapsed: false,
					wrapContainerClass: "main-elements-control-group-container",
					items: [{
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "Id",
						columnPath: "Id",
						visible: false,
						viewVisible: false
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "IsFinal",
						columnPath: "Status.IsFinal",
						visible: false,
						viewVisible: false
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "Objective",
						columnPath: "Objective",
						dataValueType: BPMSoft.DataValueType.TEXT
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "VisaOwner",
						columnPath: "VisaOwner",
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupPageSettings: {
							captionLookup: VisaHelper.VisaLookupCaption
						}
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "IsAllowedToDelegate",
						columnPath: "IsAllowedToDelegate",
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "DelegatedFrom",
						columnPath: "DelegatedFrom",
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupPageSettings: {
							captionLookup: VisaHelper.VisaLookupCaption
						}
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "Status",
						columnPath: "Status",
						dataValueType: BPMSoft.DataValueType.LOOKUP
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "SetBy",
						columnPath: "SetBy",
						dataValueType: BPMSoft.DataValueType.LOOKUP
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "SetDate",
						columnPath: "SetDate",
						dataValueType: BPMSoft.DataValueType.DATE_TIME
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "IsCanceled",
						columnPath: "IsCanceled",
						dataValueType: BPMSoft.DataValueType.BOOLEAN
					}, {
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						name: "Comment",
						columnPath: "Comment",
						dataValueType: BPMSoft.DataValueType.TEXT,
						customConfig: {
							className: "BPMSoft.controls.MemoEdit",
							height: "100px"
						}
					},
					actionButtonsItem
					]
				}
			];

			this.actions = function() {
				var actions = [];
				actions.push({
					caption: "",
					className: "BPMSoft.MenuSeparator"
				}, {
					caption: visaResources.Approve,
					methodName: "approve"
				}, {
					caption: visaResources.Reject,
					methodName: "reject"
				});
				return actions;
			};
			this.methods.modificateBeforeBind = function() {
				this.set("isVisibleEditButton", false);
			};
			this.methods.getSchemaAdministratedByRecords = function() {
				return false;
			};
			this.methods.approve = function() {
				VisaHelper.approveAction(this, this.onSaved, this);
			};

			this.methods.reject = function() {
				VisaHelper.rejectAction(this, this.onSaved, this);
			};
			this.methods.changeVizier = function() {
				var scope = this;
				var currentId = this.get(this.entitySchema.primaryColumnName);
				var callback = function(response, updateObject) {
					for (var columnValue in updateObject) {
						scope.set(columnValue, updateObject[columnValue]);
					}
				};
				VisaHelper.changeVizierAction(
					currentId,
					this.entitySchema.name,
					this.getSandbox(),
					null,
					callback,
					this);
			};


		};

		return structure;
	});
