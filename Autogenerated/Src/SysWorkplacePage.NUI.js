define('SysWorkplacePage', ['ext-base', 'BPMSoft', 'sandbox', 'SysWorkplace', 'SysWorkplacePageStructure',
	'SysWorkplacePageResources', 'ServiceHelper', 'css!SysWorkplaceHelper'],
	function(Ext, BPMSoft, sandbox, entitySchema, structure, resources, serviceHelper) {
	structure.userCode = function() {
		this.entitySchema = entitySchema;
		this.name = 'SysWorkplaceCardViewModel';
		this.schema.leftPanel = [
			{
				type: BPMSoft.ViewModelSchemaItem.GROUP,
				name: 'baseElementsControlGroup',
				visible: true,
				collapsed: false,
				wrapContainerClass: 'main-elements-control-group-container',
				items: [
					{
						type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
						name: 'Name',
						columnPath: 'Name',
						dataValueType: BPMSoft.DataValueType.TEXT,
						visible: true
					},
					{
						type: BPMSoft.ViewModelSchemaItem.ATTRIBUTE,
						columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						caption: resources.localizableStrings.LoaderCaption,
						name: 'LoaderIdEnum',
						dataValueType: BPMSoft.DataValueType.ENUM,
						visible: false,
						viewVisible: false,
						isCollection: true,
						customConfig: {
							className: 'BPMSoft.ComboBoxEdit',
							list: {
								bindTo: 'LoaderIdEnumList'
							},
							prepareList: {
								bindTo: 'getLoaderIdItems'
							}
						}
					},
					{
						type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
						name: 'LoaderId',
						columnPath: 'LoaderId',
						dataValueType: BPMSoft.DataValueType.TEXT,
						visible: false,
						viewVisible: false,
						dependencies: ['LoaderIdEnum'],
						methodName: 'setLoaderIdFromLoaderIdEnum'
					}
				]
			},
			{
				name: 'sysAdminUnits',
				schemaName: 'SysAdminUnitInWorkplaceDetail',
				type: BPMSoft.ViewModelSchemaItem.DETAIL,
				filterPath: 'SysWorkplace',
				filterValuePath: 'Id',
				caption: resources.localizableStrings.SysAdminUnitsDetailCaption,
				visible: true,
				collapsed: false,
				ignoreProfile: true,
				leftWidth: '60%',
				rightWidth: '40%',
				wrapContainerClass: 'control-group-container'
			}
		];
		this.schema.rightPanel = [
			{
				name: 'modules',
				schemaName: 'SysModuleInWorkplaceDetail',
				type: BPMSoft.ViewModelSchemaItem.DETAIL,
				filterPath: 'SysWorkplace',
				filterValuePath: 'Id',
				caption: resources.localizableStrings.ModulesDetailCaption,
				visible: true,
				collapsed: false,
				ignoreProfile: true,
				wrapContainerClass: 'control-group-container'
			}
		];
		this.leftPanelStyles = {
			width: '420px'
		};
		this.rightPanelStyles = {
			width: '450px',
			marginLeft: '497px',
			paddingLeft: '20px'
		};
		this.cardConfig = {
			hideActions: true,
			hideGoTo: true
		};
		this.methods.onSaved = function() {
			serviceHelper.callService('WorkplaceService', 'ResetScriptCache', function(response) {
				sandbox.publish('RefreshWorkplace');
			});
			return true;
		};

		this.methods.getClientUnitSchemaQuery = function(UID) {
			var selectClientUnitSchema = Ext.create('BPMSoft.EntitySchemaQuery', {
				rootSchemaName: 'VwSysClientUnitSchema'
			});
			selectClientUnitSchema.addColumn('Id');
			selectClientUnitSchema.addColumn('UId');
			selectClientUnitSchema.addColumn('Name');
			selectClientUnitSchema.addColumn('Caption');
			selectClientUnitSchema.addColumn('SysWorkspace.Id');

			var filterName = 'FilterVwSysClientUnitSchema';
			if (UID) {
				selectClientUnitSchema.filters.add(filterName + 'UID',
					selectClientUnitSchema.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, 'UId', UID));
			}
			selectClientUnitSchema.filters.add(filterName,
				selectClientUnitSchema.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
					'SysWorkspace.Id', BPMSoft.core.enums.SysValue.CURRENT_WORKSPACE.value));
			return selectClientUnitSchema;
		};
		this.methods.getLoaderIdItems = function(filter, list) {
			if (list === null) {
				return;
			}
			list.clear();
			var selectClientUnitSchema = this.getClientUnitSchemaQuery();
			selectClientUnitSchema.getEntityCollection(function(result) {
				var collection = result.collection;
				var columns = {};
				if (collection && collection.collection.length > 0) {
					BPMSoft.each(collection.collection.items, function(item) {
						var columnDisplayValue = item.values.Caption;
						var it = {
							displayValue: columnDisplayValue,
							value: item.values.UId
						};
						if (!list.contains(item.values.UId)) {
							columns[item.values.UId] = it;
						}
					}, this);
					list.loadAll(columns);
				}
			}, this);
		};
		this.methods.setLoaderIdFromLoaderIdEnum = function() {
			var LoaderIdEnum = this.get('LoaderIdEnum');
			if (!Ext.isEmpty(LoaderIdEnum) &&
				!Ext.isEmpty(LoaderIdEnum.displayValue) &&
				LoaderIdEnum.value !== 'oldKey') {
				this.set('LoaderId', LoaderIdEnum.value);
			} else if (LoaderIdEnum === null) {
				this.set('LoaderId', null);
			}
		};
		this.methods.init = function() {
			var LoaderId = this.get('LoaderId');
			if (!Ext.isEmpty(LoaderId)) {
				var selectClientUnitSchema = this.getClientUnitSchemaQuery(LoaderId);
				selectClientUnitSchema.getEntityCollection(function(result) {
					var collection = result.collection;
					if (collection && collection.collection.length > 0) {
						BPMSoft.each(collection.collection.items, function(item) {
							var columnDisplayValue = item.values.Caption;
							var it = {
								displayValue: columnDisplayValue,
								value: item.values.UId
							};
							this.set('LoaderIdEnum', it);
						}, this);
					}
				}, this);
			}
		};
	};
	return structure;
});
