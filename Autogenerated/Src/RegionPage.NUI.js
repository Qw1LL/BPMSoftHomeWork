define('RegionPage', ['ext-base', 'BPMSoft', 'sandbox',
	'Region', 'RegionPageStructure', 'RegionPageResources', 'GeneralDetails', 'LookupUtilities'],
	function(Ext, BPMSoft, sandbox, entitySchema, structure, resources, GeneralDetails, LookupUtilities) {
	structure.userCode = function() {
		this.entitySchema = entitySchema;
		this.name = 'RegionCardViewModel';
		this.schema.leftPanel = LookupUtilities.GetBaseLookupPageStructure();
	};
	structure.finalizeStructure = function() {
		var baseElementsControlGroup = this.find('baseElementsControlGroup');
		var items = baseElementsControlGroup.items;
		items.splice(2, 0, {
			type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
			name: 'Country',
			columnPath: 'Country',
			dataValueType: BPMSoft.DataValueType.LOOKUP,
			visible: true
		});
		baseElementsControlGroup.items = items;
	};
	return structure;
});
