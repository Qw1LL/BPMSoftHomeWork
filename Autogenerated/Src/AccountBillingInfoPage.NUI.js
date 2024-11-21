define('AccountBillingInfoPage', ['ext-base', 'BPMSoft', 'sandbox', 'AccountBillingInfo',
	'AccountBillingInfoPageStructure', 'AccountBillingInfoPageResources'],
	function(Ext, BPMSoft, sandbox, AccountBillingInfo, structure, resources) {
		structure.userCode = function() {
			this.entitySchema = AccountBillingInfo;
			this.name = 'AccountBillingInfoCardViewModel';
			var contactCareerFilter = function() {
				return BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					'[ContactCareer:Contact].Account',
					this.get('Account').value);
			};

			this.schema.leftPanel = [
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
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true,
					customConfig: {
						enabled: false
					}
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Name',
					columnPath: 'Name',
					dataValueType: BPMSoft.DataValueType.TEXT,
					visible: true,
					viewVisible: true
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Country',
					columnPath: 'Country',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					columns: ['BillingInfo'],
					visible: true,
					viewVisible: true
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'BillingInfo',
					columnPath: 'BillingInfo',
					customConfig: {
						className: 'BPMSoft.controls.MemoEdit',
						height: '100px'
					},
					visible: true,
					viewVisible: true,
					dependencies: ['Country'],
					methodName: 'countryChanged'
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'AccountManager',
					columnPath: 'AccountManager',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true,
					viewVisible: true//,
					//filter: contactCareerFilter
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'ChiefAccountant',
					columnPath: 'ChiefAccountant',
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					visible: true,
					viewVisible: true//,
					//filter: contactCareerFilter
				},
				{
					type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
					name: 'Description',
					columnPath: 'Description',
					visible: true,
					customConfig: {
						className: 'BPMSoft.controls.MemoEdit',
						height: '100px'
					}
				}
			];
			BPMSoft.applySchemaItemProperties(this.schema.leftPanel, 'AccountManager', {
				filter: contactCareerFilter
			});
			BPMSoft.applySchemaItemProperties(this.schema.leftPanel, 'ChiefAccountant', {
				filter: contactCareerFilter
			});

			this.getItemViewHeader = function() {
				return {
					columns: [
						{
							type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
							name: 'Account',
							columnPath: 'Account',
							viewVisible: true,
							labelClass: 'account-accountname'
						}
					]
				};
			};
			this.methods.countryChanged = function() {
				var buttonsConfig = {
					buttons: [BPMSoft.MessageBoxButtons.YES.returnCode,
						BPMSoft.MessageBoxButtons.NO.returnCode],
					defaultButton: 0
				};
				var billingInfo = this.get('BillingInfo');
				var country = this.get('Country');
				if (!Ext.isEmpty(country)) {
					if (billingInfo) {
						this.showInformationDialog(resources.localizableStrings.CountryIsChange,
							this.getSelectedButton, buttonsConfig);
					}
					else {
						this.set('BillingInfo', country.BillingInfo);
					}
				}
			};
			this.methods.getSelectedButton = function(returnCode) {
				if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
					var country = this.get('Country');
					this.set('BillingInfo', country.BillingInfo);
				}
			};
		};

		return structure;
	});
