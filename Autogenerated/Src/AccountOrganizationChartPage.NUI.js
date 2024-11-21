define('AccountOrganizationChartPage', ['ext-base', 'BPMSoft', 'sandbox', 'AccountOrganizationChart',
'AccountOrganizationChartPageStructure', 'AccountOrganizationChartPageResources', 'BusinessRuleModule'],
	function(Ext, BPMSoft, sandbox, AccountOrganizationChart, structure, resources, BusinessRuleModule) {
		structure.userCode = function() {
			this.entitySchema = AccountOrganizationChart;
			this.name = 'AccountOrganizationChartPageViewModel';
			this.getItemViewHeader = function() {
				return {
					columns: [
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Account',
							columnPath: 'Account',
							viewVisible: true,
							labelClass: 'campaign-campaignname'
						}
					]
				};
			};
			this.methods.onDepartmentChange = function() {
				var department = this.get('Department');
				if (!Ext.isEmpty(department)) {
					this.set('CustomDepartmentName', department.displayValue);
				} else {
					this.set('CustomDepartmentName', null);
				}
			};
			this.schema.leftPanel = [
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Account',
					columnPath: 'Account',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true,
					viewVisible: true,
					customConfig: {
						readonly: true
					}
				}, {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'CustomDepartmentName',
					columnPath: 'CustomDepartmentName',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true,
					viewVisible: true,
					dependencies: ['Department'],
					methodName: 'onDepartmentChange'
				}, {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Department',
					columnPath: 'Department',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true
				}, {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Manager',
					columnPath: 'Manager',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true,
					filter: function() {
						return BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							'[ContactCareer:Contact].Account', this.get('Account').value);
					}
				}, {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Description',
					columnPath: 'Description',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true,
					customConfig: {
						className: 'BPMSoft.controls.MemoEdit',
						height: '100px'
					}
				}, {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Id',
					columnPath: 'Id',
					visible: false,
					viewVisible: false
				}, {
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Parent',
					columnPath: 'Parent',
					visible: false,
					viewVisible: false
				}
			];
		};
		return structure;
	});
