define('ActivitySection', ['ext-base', 'BPMSoft', 'sandbox', 'Activity', 'ActivitySectionStructure',
	'ActivitySectionResources', 'ProcessModule', 'SectionViewGenerator', 'ActionUtilitiesModule',
	'ConfigurationEnums', 'ConfigurationConstants', 'EmailUtilities', 'BaseFiltersGenerateModule', 'MaskHelper',
	'ExchangeNUIConstants'],
	function(Ext, BPMSoft, sandbox, Activity, structure, resources, processModule, SectionViewGenerator,
	actionUtilities, ConfigurationEnums, ConfigurationConstants, EmailUtilities,
	BaseFiltersGenerateModule, MaskHelper, ExchangeNUIConstants) {
		structure.userCode = function() {

			function downloadMessages(collection) {
				var requestsCount = 0;
				var messageArray = [];
				BPMSoft.each(collection, function(item) {
					var requestUrl;
					if (item.get('MailServerTypeId') === ExchangeNUIConstants.MailServer.Type.Exchange) {
						requestUrl = BPMSoft.workspaceBaseUrl +
							'/ServiceModel/ProcessEngineService.svc/LoadExchangeEmailsProcess/' +
							'Execute?ResultParameterName=LoadResult' +
							'&SenderEmailAddress=' + item.get('SenderEmailAddress');
					} else {
						requestUrl = BPMSoft.workspaceBaseUrl +
							'/ServiceModel/ProcessEngineService.svc/LoadImapEmailsProcess/' +
							'Execute?ResultParameterName=LoadResult' +
							'&MailBoxFolderId=' + item.get('Id');
					}
					MaskHelper.ShowBodyMask();
					requestsCount++;
					Ext.Ajax.request({
						url: requestUrl,
						timeout: 180000,
						headers: {
							'Content-Type': 'application/json',
							'Accept': 'application/json'
						},
						method: 'POST',
						scope: this,
						callback: function(request, success, response) {
							if (success) {
								var responseData = Ext.decode(
									Ext.decode(response.responseXML.firstChild.textContent)
								);
								if (responseData.Messages.length > 0) {
									messageArray = messageArray.concat(responseData.Messages);
								}
							}
							if (--requestsCount <= 0) {
								this.clear();
								this.load();
								var message = resources.localizableStrings.LoadImapEmailsResultEx;
								if (messageArray.length > 0) {
									message = '';
									BPMSoft.each(messageArray, function(element) {
										message = message.concat(Ext.String.format('[{0}]: {1} ', element.key,
											element.message));
									}, this);
								}
								MaskHelper.HideBodyMask();
								BPMSoft.utils.showInformation(
									message, null, null,
									{ buttons: ['ok'] });
							}
						}
					});
				}, this);
			}

			this.methods.loadEmails = function() {
				if (!this.get('isMailboxSyncExist')) {
					var buttonsConfig = {
						buttons: [BPMSoft.MessageBoxButtons.OK.returnCode],
						defaultButton: 0
					};
					BPMSoft.showInformation(resources.localizableStrings.MailboxSettingsEmptyEx,
						function() {}, this, buttonsConfig);
					return;
				}
				var select = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: 'ActivityFolder'
				});
				select.addColumn('Id');
				select.addColumn('[MailboxSyncSettings:MailboxName:Name].SenderEmailAddress', 'SenderEmailAddress');
				select.addColumn('[MailboxSyncSettings:MailboxName:Name].MailServer.Type.Id', 'MailServerTypeId');
				select.filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					'[MailboxSyncSettings:MailboxName:Name].SysAdminUnit', BPMSoft.SysValue.CURRENT_USER.value));
				select.getEntityCollection(function(response) {
					if (response.success) {
						downloadMessages.call(this, response.collection.getItems());
					}
				}, this);
			};

		};
		return structure;
	});
