﻿define('InvoiceSection', ['Invoice', 'InvoiceSectionStructure', 'InvoiceSectionResources', 'ActionUtilitiesModule',
	'BaseFiltersGenerateModule', 'VisaHelper', 'css!VisaHelper'],
	function(Invoice, structure, resources, ActionUtilitiesModule, BaseFiltersGenerateModule, VisaHelper) {
		structure.userCode = function() {
			this.entitySchema = Invoice;
			this.contextHelpId = '1004';
			this.name = 'InvoiceSectionViewModel';
			this.columnsConfig = [
				[
					{
						cols: 24,
						key: [
							{
								name: {
									bindTo: 'Number'
								},
								type: 'title'
							}
						]
					}
				],
				[
					{
						cols: 6,
						key: [
							{
								name: {
									bindTo: 'DueDate'
								}
							}
						]
					},
					{
						cols: 3,
						key: [
							{
								name: {
									bindTo: 'PrimaryAmount'
								}
							}
						]
					},
					{
						cols: 4,
						key: [
							{
								name: {
									bindTo: 'PrimaryPaymentAmount'
								}
							}
						]
					},
					{
						cols: 3,
						key: [
							{
								name: {
									bindTo: 'Account'
								}
							}
						]
					},
					{
						cols: 3,
						key: [
							{
								name: {
									bindTo: 'Contact'
								}
							}
						]
					},
					{
						cols: 3,
						key: [
							{
								name: {
									bindTo: 'Owner'
								}
							}
						]
					}
				]
			];
			this.loadedColumns = [
				{
					columnPath: 'Number'
				},
				{
					columnPath: 'DueDate'
				},
				{
					columnPath: 'PrimaryAmount'
				},
				{
					columnPath: 'PrimaryPaymentAmount'
				},
				{
					columnPath: 'Account'
				},
				{
					columnPath: 'Contact'
				},
				{
					columnPath: 'Owner'
				}
			];
			this.loadCardReports = true;

			this.methods.esqConfig = {
				sort: {
					columns: [
						{
							name: 'DueDate',
							orderPosition: 0,
							orderDirection: BPMSoft.OrderDirection.ASC
						}
					]
				}
			};
			this.methods.modifyGridConfig = function(defaultConfig) {
				var cardReports = BPMSoft.configuration.Storage.InvoicePageReports;
				if (cardReports) {
					var reports = [];
					cardReports.collection.getItems().forEach(function(report) {
						var caption = report.get('Caption') || report.get('NonLocalizedCaption');
						var isDevExpress = report.get('Type.Name') === 'DevExpress';
						var schemaId = isDevExpress ? report.get('SysReportSchemaUId') : report.get('Id');
						reports.push({
							tag: 'report' + '_' + caption + '_' + schemaId + '_' + report.get('Type.Name'),
							caption: caption
						});
					});
					if (reports.length === 1) {
						defaultConfig.activeRowActions.push({
							className: 'BPMSoft.Button',
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: resources.localizableStrings.PrintButtonCaption,
							tag: reports[0].tag,
							styles: {wrapperStyle: {'float': 'right'}},
							imageConfig: resources.localizableImages.PrintButtonImage
						});
					} else if (reports.length > 1) {
						defaultConfig.activeRowActions.push({
							className: 'BPMSoft.Button',
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: resources.localizableStrings.PrintButtonCaption,
							menu: {items: reports},
							styles: {wrapperStyle: {'float': 'right'}},
							imageConfig: resources.localizableImages.PrintButtonImage
						});
					}
				}
			};

			this.fixedFilterConfig = {
				entitySchema: Invoice,
				filters: [
					{
						name: 'PeriodFilter',
						caption: resources.localizableStrings.PeriodFilterCaption,
						dataValueType: BPMSoft.DataValueType.DATE,
						columnName: 'StartDate',
						startDate: {
							defValue: BPMSoft.startOfWeek(new Date())
						},
						dueDate: {
							defValue: BPMSoft.endOfWeek(new Date())
						}
					},
					{
						name: 'Owner',
						caption: resources.localizableStrings.OwnerFilterCaption,
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						filter: BaseFiltersGenerateModule.OwnerFilter,
						columnName: 'Owner',
						defValue: {
							value: BPMSoft.SysValue.CURRENT_USER_CONTACT.value,
							displayValue: BPMSoft.SysValue.CURRENT_USER_CONTACT.displayValue
						}
					}
				]
			};

			this.actions = getActions();
			this.methods.sendToVisa = VisaHelper.SendToVisaMethod;
		};

		function getActions() {
			var actions = [];
			var visaElement = BPMSoft.deepClone(VisaHelper.SendToVisaMenuItem);
			visaElement.enabled = {
				bindTo: 'isSingleSelected'
			};
			actions.push({
				caption: '',
				className: 'BPMSoft.MenuSeparator'
			}, visaElement);
			return actions;
		}
		return structure;
	});
