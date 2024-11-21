define('LeadPage', ['ext-base', 'BPMSoft', 'Lead', 'LeadPageStructure', 'LeadPageResources',
	'BusinessRuleModule', 'GeneralDetails', 'ConfigurationConstants', 'MaskHelper', 'css!LeadCSS'],
	function(Ext, BPMSoft, Lead, structure, resources, BusinessRuleModule, GeneralDetails,
			ConfigurationConstants, MaskHelper) {
		var businessRuleModule = BusinessRuleModule;
		structure.userCode = function() {
			var sandbox = this.sandbox;
			this.entitySchema = Lead;
			this.contextHelpId = '1009';
			this.name = 'LeadCardViewModel';
			this.schema.rightPanel = [
				{
					name: 'leadActivity',
					schemaName: 'ActivityDetail',
					type: BPMSoft.ViewModelSchemaItem.DETAIL,
					filterPath: 'Lead',
					filterValuePath: 'Id',
					caption: resources.localizableStrings.ActivityDetailCaption,
					visible: true,
					collapsed: false,
					leftWidth: '60%',
					rightWidth: '40%',
					wrapContainerClass: 'control-group-container'
				},
				GeneralDetails.Notes('Notes',
					{
						collapsed: false
					},
					{
						enabled: {
							bindTo: 'isCheckedEnabled'
						}
					}),
					GeneralDetails.File('Lead')
				];
			this.schema.leftPanel = [
				{
					type: BPMSoft.ViewModelSchemaItem.GROUP,
					name: 'baseElementsControlGroup',
					visible: true,
					collapsed: false,
					wrapContainerClass: 'main-elements-control-group-container',
					items: [
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							name: 'isCheckedEnabled',
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							visible: false,
							viewVisible: false
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'LeadName',
							columnPath: 'LeadName',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: false,
							viewVisible: false
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Id',
							columnPath: 'Id',
							visible: false,
							viewVisible: false

						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Account',
							columnPath: 'Account',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Contact',
							columnPath: 'Contact',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Title',
							columnPath: 'Title',
							dataValueType: BPMSoft.DataValueType.ENUM,
							visible: true,
							advancedVisible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'FullJobTitle',
							columnPath: 'FullJobTitle',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Status',
							columnPath: 'Status',
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							visible: true,
							advancedVisible: true,
							enabled: false,
							customConfig: {
								enabled: false
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Commentary',
							columnPath: 'Commentary',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							advancedVisible: true,
							customConfig: {
								className: 'BPMSoft.controls.MemoEdit',
								height: '100px',
								classes: {
									wrapClass: 'notes-memo-user-class'
								},
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						}
					]
				},
				{
					type: BPMSoft.ViewModelSchemaItem.GROUP,
					name: 'categorisation',
					caption: resources.localizableStrings.CategorisationGroupCaption,
					visible: true,
					collapsed: false,
					wrapContainerClass: 'control-group-container',
					items: [
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'InformationSource',
							columnPath: 'InformationSource',
							dataValueType: BPMSoft.DataValueType.ENUM,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Industry',
							columnPath: 'Industry',
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'AnnualRevenue',
							columnPath: 'AnnualRevenue',
							dataValueType: BPMSoft.DataValueType.ENUM,
							visible: true,
							advancedVisible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'EmployeesNumber',
							columnPath: 'EmployeesNumber',
							columns: ['Position'],
							dataValueType: BPMSoft.DataValueType.ENUM,
							visible: true,
							advancedVisible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						}
					]
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'QualifiedContact',
					columnPath: 'QualifiedContact',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: false,
					customConfig: {
						enabled: {
							bindTo: 'isCheckedEnabled'
						}
					}
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'QualifiedAccount',
					columnPath: 'QualifiedAccount',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: false,
					customConfig: {
						enabled: {
							bindTo: 'isCheckedEnabled'
						}
					}
				},
				{
					type: BPMSoft.ViewModelSchemaItem.GROUP,
					name: 'communications',
					caption: resources.localizableStrings.Communications,
					visible: true,
					collapsed: false,
					wrapContainerClass: 'control-group-container',
					items: [
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'BusinesPhone',
							columnPath: 'BusinesPhone',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'MobilePhone',
							columnPath: 'MobilePhone',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Email',
							columnPath: 'Email',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Fax',
							columnPath: 'Fax',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Website',
							columnPath: 'Website',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						}
					]
				},
				{
					type: BPMSoft.ViewModelSchemaItem.GROUP,
					name: 'useCommunication',
					caption: resources.localizableStrings.UseCommunicationGroupCaption,
					visible: true,
					collapsed: true,
					wrapContainerClass: 'control-group-container',
					items: [
						{
							type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
							name: 'DoNotUseEmail',
							columnPath: 'DoNotUseEmail',
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'DoNotUsePhone',
							columnPath: 'DoNotUsePhone',
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'DoNotUseFax',
							columnPath: 'DoNotUseFax',
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'DoNotUseSMS',
							columnPath: 'DoNotUseSMS',
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'DoNotUseMail',
							columnPath: 'DoNotUseMail',
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						}
					]
				},
				{
					type: BPMSoft.ViewModelSchemaItem.GROUP,
					name: 'address',
					caption: resources.localizableStrings.AddressGroupCaption,
					visible: true,
					collapsed: false,
					wrapContainerClass: 'control-group-container',
					items: [
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'AddressType',
							columnPath: 'AddressType',
							dataValueType: BPMSoft.DataValueType.ENUM,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Country',
							columnPath: 'Country',
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Region',
							columnPath: 'Region',
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							},
							rules: [
								{
									ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
									autocomplete: true,
									baseAttributePatch: 'Country',
									comparisonType: BPMSoft.ComparisonType.EQUAL,
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: 'Country'
								}
							]
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'City',
							columnPath: 'City',
							dataValueType: BPMSoft.DataValueType.LOOKUP,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							},
							rules: [
								{
									ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
									autocomplete: true,
									baseAttributePatch: 'Country',
									comparisonType: BPMSoft.ComparisonType.EQUAL,
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: 'Country'
								},
								{
									ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
									autocomplete: true,
									baseAttributePatch: 'Region',
									comparisonType: BPMSoft.ComparisonType.EQUAL,
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: 'Region'
								}
							]
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Zip',
							columnPath: 'Zip',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						},
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Address',
							columnPath: 'Address',
							dataValueType: BPMSoft.DataValueType.TEXT,
							visible: true,
							customConfig: {
								className: 'BPMSoft.controls.MemoEdit',
								height: '100px',
								enabled: {
									bindTo: 'isCheckedEnabled'
								}
							}
						}
					]
				}
			];

			BPMSoft.each(this.schema.leftPanel, function(item) {
				item.leftWidth = '39%';
				item.rightWidth = '54%';
			});

			this.methods.save = function() {
				var account = this.get('Account');
				var contact = this.get('Contact');
				if (!account && !contact) {
					this.showInformationDialog(resources.localizableStrings.requiredFieldsMessage);
					return false;
				}
				else {
					return true;
				}
			};
			this.methods.qualifyLead = function() {
				var recordId = this.get('Id');
				var token = 'QualifyLead/' + recordId;
				sandbox.publish('ReplaceHistoryState', { hash: token});
			};

			this.methods.saveLead = function() {
				MaskHelper.ShowBodyMask();
				var state = sandbox.publish('GetHistoryState');
				if (this.get('Account') || this.get('Contact')) {
					this.saveEntity(this.qualifyLead);
				}
				else {
					this.showInformationDialog(resources.localizableStrings.requiredFieldsMessage);
				}
			};

			function DisqualifyLead(statusId) {
				var account = this.get('Account');
				var contact = this.get('Contact');
				if (!account && !contact) {
					this.showInformationDialog(resources.localizableStrings.requiredFieldsMessage);
					return;
				}
				var scope = this;
				this.showConfirmationDialog(resources.localizableStrings.DisqualifyLeadActionMessage,
					function(returnCode) {
						if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
							scope.set('Status', {value: statusId});
							scope.save();
						}
					}, ['yes', 'no']);
			}

			this.methods.QualifyLost = function() {
				DisqualifyLead.call(this, ConfigurationConstants.Lead.Status.QualifiedAsLost);
			};

			this.methods.QualifyNoConnection = function() {
				DisqualifyLead.call(this, ConfigurationConstants.Lead.Status.QualifiedAsNoConnection);
			};

			this.methods.QualifyNotInterested = function() {
				DisqualifyLead.call(this, ConfigurationConstants.Lead.Status.QualifiedAsNotInterested);
			};
			this.methods.DisqualifyGroup = function() {

			};


			this.methods.loadLookupName = function(schemaName, id, attributeName) {
				var select = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: schemaName
				});
				select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, 'value');
				select.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_DISPLAY_COLUMN, 'displayValue');
				select.getEntity(id, function(result) {
					var entity = result.entity;
					if (entity) {
						this.set(attributeName, entity.get('displayValue'));
					}
				}, this);
			};

			this.methods.updateActivitiesContacts = function(contactId, lead) {
				var select = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: 'Activity'
				});
				select.addColumn('Id');
				select.addColumn('Contact');
				select.addColumn('Account');
				select.filters.add("LeadFilter",
					select.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, 'Lead', this.get('Id')));

				select.getEntityCollection(function(result) {
					var collection = result.collection;
					collection.each(function(item) {
						var activityId = item.get('Id');
						var update = Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: 'Activity'
						});
						var filters = update.filters;
						var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							'Id', activityId);
						filters.add('IdFilter', idFilter);
						update.setParameterValue('Contact', contactId, BPMSoft.DataValueType.GUID);
						update.execute();
					});
				}, this);
			};
			this.methods.updateActivitiesAccounts = function(accountId, lead) {
				var select = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: 'Activity'
				});
				select.addColumn('Id');
				select.addColumn('Contact');
				select.addColumn('Account');
				select.filters.add("LeadFilter",
					select.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, 'Lead', this.get('Id')));

				select.getEntityCollection(function(result) {
					var collection = result.collection;
					collection.each(function(item) {
						var activityId = item.get('Id');
						var update = Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: 'Activity'
						});
						var filters = update.filters;
						var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							'Id', activityId);
						filters.add('IdFilter', idFilter);
						update.setParameterValue('Account', accountId, BPMSoft.DataValueType.GUID);
						update.execute();
					});
				}, this);
			};

			this.methods.init = function() {
				var account = this.get('Account');
				if (BPMSoft.isGUID(account)) {
					this.set('Account', null);
					this.loadLookupName('Account', account, 'Account');
				}
				var contact = this.get('Contact');
				if (BPMSoft.isGUID(contact)) {
					this.set('Contact', null);
					this.loadLookupName('Contact', contact, 'Contact');
				}
				var queryParams = sandbox.publish('GetHistoryState');
				var createdmessage = '';
				if (queryParams.state.Qualified) {
					if (queryParams.state.contactName && queryParams.state.isContactQualifyAsNew) {
						createdmessage += Ext.String.format(resources.localizableStrings.createdContactMessage,
							queryParams.state.contactName);
						queryParams.state.contactName = null;
					}
					if (queryParams.state.accountName && queryParams.state.isAccountQualifyAsNew) {
						if (createdmessage) {
							createdmessage += ' ';
						}
						createdmessage += Ext.String.format(resources.localizableStrings.createdAccountMessage,
							queryParams.state.accountName);
						queryParams.state.accountName = null;
					}
					if (queryParams.state.createdOpportunityTitle) {
						if (createdmessage) {
							createdmessage += ' ';
						}
						createdmessage += Ext.String.format(resources.localizableStrings.createdOpportunityMessage,
							queryParams.state.createdOpportunityTitle);
						queryParams.state.createdOpportunityTitle = null;
					}
					if (createdmessage) {
						this.showInformationDialog(createdmessage);
					}
					if (queryParams.state.contactId) {
						this.updateActivitiesContacts(queryParams.state.contactId, this.get('Id'));
					}
					if (queryParams.state.accountId) {
						this.updateActivitiesAccounts(queryParams.state.accountId, this.get('Id'));
					}
					queryParams.state.Qualified = false;
					var currentHash = queryParams.hash;
					var currentState = queryParams.state;
					var newState = BPMSoft.deepClone(queryParams);
					sandbox.publish('ReplaceHistoryState', {
						stateObj: newState,
						pageTitle: null,
						hash: currentHash.historyState,
						silent: true
					});
				}
				BPMSoft.SysSettings.querySysSettingsItem('LeadStatusDef',
					function(value) {
						if (value && !this.get('Status')) {
							var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
								rootSchemaName: 'LeadStatus'
							});
							esq.addColumn('Id');
							esq.addColumn('Name');
							esq.getEntity(value, function(result) {
								var entity = result.entity;
								if (entity) {
									var sysSetting = {
										displayValue: entity.get('Name'),
										value: entity.get('Id')
									};
									this.set('Status', sysSetting);
								}
							}, this);
						}
						var isCE = this.get('isCheckedEnabled');
						var status = this.get('Status');
						var vm = this;
						if (isCE === undefined) {
							BPMSoft.SysSettings.querySysSettingsItem('LeadStatusDef',
								function(value) {
									var viewModel = vm;
									if (status) {
										isCE = status.value === value;
										viewModel.set('isCheckedEnabled', isCE);
										viewModel.set('isQualifyVisible', isCE);
									}
								}, this);
						}
					}, this);
			};
			this.actions = [
				{
					caption: resources.localizableStrings.QualifyLeadActionCaption,
					schemaName: 'QualifyLead',
					methodName: 'saveLead',
					customConfig: {
						visible: {
							bindTo: 'isQualifyVisible'
						}
					}
				},
				{
					caption: resources.localizableStrings.disqualifyLeadActionCaption,
					methodName: 'DisqualifyGroup',
					isRootMenu: true,
					customConfig: {
						visible: {
							bindTo: 'isQualifyVisible'
						}
					},
					menu: {
						items: [
							{
								caption: resources.localizableStrings.disqualifyLeadLost,
								click: {
									bindTo: 'QualifyLost'
								}
							},
							{
								caption: resources.localizableStrings.disqualifyLeadNoConnection,
								click: {
									bindTo: 'QualifyNoConnection'
								}
							},
							{
								caption: resources.localizableStrings.disqualifyLeadNotInterested,
								click: {
									bindTo: 'QualifyNotInterested'
								}
							}
						]
					}
				}
			];
		};
		return structure;
	});
