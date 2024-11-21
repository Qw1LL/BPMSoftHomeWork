define('DocumentSection', ['Document', 'DocumentSectionStructure',
	'DocumentSectionResources', 'BaseFiltersGenerateModule', 'VisaHelper', 'css!VisaHelper'],
	function(Document, structure, resources, BaseFiltersGenerateModule, VisaHelper) {
	structure.userCode = function() {
		this.entitySchema = Document;
		this.contextHelpId = '1005';
		this.name = 'DocumentSectionViewModel';
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
								bindTo: 'Date'
							}
						}
					]
				},
				{
					cols: 3,
					key: [
						{
							name: {
								bindTo: 'Type'
							}
						}
					]
				},
				{
					cols: 3,
					key: [
						{
							name: {
								bindTo: 'Status'
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
		this.loadedColumns = [{
			columnPath: 'Number'
		}, {
			columnPath: 'Date'
		}, {
			columnPath: 'Type'
		}, {
			columnPath: 'Status'
		}, {
			columnPath: 'Owner'
		}];
		this.actions = getActions();
		this.fixedFilterConfig = {
			entitySchema: Document,
			filters: [
				{
					name: 'PeriodFilter',
					caption: resources.localizableStrings.PeriodFilterCaption,
					dataValueType: BPMSoft.DataValueType.DATE,
					startDate: {
						columnName: 'Date',
						defValue: BPMSoft.startOfWeek(new Date())
					},
					dueDate: {
						columnName: 'Date',
						defValue: BPMSoft.endOfWeek(new Date())
					}
				},
				{
					name: 'Owner',
					caption: resources.localizableStrings.OwnerFilterCaption,
					columnName: 'Owner',
					defValue: BPMSoft.SysValue.CURRENT_USER_CONTACT,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					filter: BaseFiltersGenerateModule.OwnerFilter
				}
			]
		};
		this.methods.esqConfig = {
			sort: {
				columns: [
					{
						name: 'Date',
						orderPosition: 0,
						orderDirection: BPMSoft.OrderDirection.ASC
					}
				]
			}
		};
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
