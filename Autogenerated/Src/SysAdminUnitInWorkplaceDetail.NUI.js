﻿define('SysAdminUnitInWorkplaceDetail', ['ext-base', 'BPMSoft', 'sandbox', 'SysAdminUnitInWorkplace',
	'SysAdminUnitInWorkplaceDetailStructure', 'SysAdminUnitInWorkplaceDetailResources', 'LookupUtilities',
	'LocalizableHelper'],
	function(Ext, BPMSoft, sandbox, entitySchema,  structure, resources, LookupUtilities, LocalizableHelper) {
		structure.userCode = function() {
			this.loadAll = true;
			this.gridType = 'tiled';
			this.entitySchema = entitySchema;
			this.name = 'SysAdminUnitInWorkplaceDetailViewModel';
			this.editPageName = 'SysAdminUnitInWorkplacePage';
			this.columnsConfig = [];
			this.utilsConfig = {
				hideAction: true,
				hiddenCopy: true,
				hiddenEdit: true,
				hiddenView: true,
				hiddenSettings: true,
				useAdditionalAddButton: true
			};
			var parentAdd = this.methods.add;
			this.methods.add = function() {
				parentAdd.call(this, null, this.addModule);
			};
			this.methods.addModule = function() {
				var workplaceId = this.filterValue;
				var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: 'SysAdminUnitInWorkplace'
				});
				esq.addColumn('SysAdminUnit.Id', 'SysAdminUnitId');
				esq.filters.add('ExistsFilter', BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, 'SysWorkplace', workplaceId));
				esq.getEntityCollection(function(result) {
					var existsCollection = [];
					if (result.success) {
						BPMSoft.each(result.collection.getItems(), function(item) {
							existsCollection.push(item.get('SysAdminUnitId'));
						});
					}
					var config = {
						entitySchemaName: 'SysAdminUnit',
						multiSelect: true
					};
					var filterGroup = BPMSoft.createFilterGroup();
					if (existsCollection.length > 0) {
						var existsFilter = BPMSoft.createColumnInFilterWithParameters('Id', existsCollection);
						existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
						filterGroup.add('existsFilter', existsFilter);
					}
					var rolesFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.LESS,
						'SysAdminUnitTypeValue', 4);
					filterGroup.add('rolesFilter', rolesFilter);
					config.filters = filterGroup;
					LookupUtilities.ThrowOpenLookupMessage(sandbox, config, this.addCallBack, this,
						this.getCardModuleSandboxId());

				}, this);
			};
			this.methods.addCallBack = function(args) {
				var bq = Ext.create('BPMSoft.BatchQuery');
				this.selectedRows = args.selectedRows.getItems();
				this.selectedItems = [];
				this.selectedRows.forEach(function(item) {
					bq.add(this.getInsertQuery(item));
					this.selectedItems.push(item.value);
				}, this);
				if (bq.queries.length) {
					bq.execute(this.onItemInsert, this);
				}
			};
			this.methods.getInsertQuery = function(item) {
				var insert = Ext.create('BPMSoft.InsertQuery', {
					rootSchemaName: 'SysAdminUnitInWorkplace'
				});
				insert.setParameterValue('SysAdminUnit', item.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue('SysWorkplace', this.filterValue, BPMSoft.DataValueType.GUID);
				return insert;
			};
			this.methods.onItemInsert = function(response) {
				if (response && response.success) {
					var queryResult = response.queryResults;
					var rowIds = [];
					BPMSoft.each(queryResult, function(item) {
						if (item.id) {
							rowIds.push(item.id);
						}
					});
					var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
						rootSchema: entitySchema
					});
					var loadedColumns = this.loadedColumns;
					if (loadedColumns) {
						for (var column in loadedColumns) {
							esq.addColumn(loadedColumns[column].columnPath);
						}
					}
					var filter = BPMSoft.createColumnInFilterWithParameters("Id", rowIds);
					filter.comparisonType = BPMSoft.ComparisonType.EQUAL;
					esq.filters.add("id", filter);
					esq.getEntityCollection(function(response) {
						var items =  response.collection.getItems();
						if (items.length > 0) {
							var collection = new BPMSoft.Collection();
							BPMSoft.each(items, function(item) {
								collection.add(item.get('Id'), item);
							});
							this.set('gridEmpty', false);
							var gridData =  this.get('gridData');
							gridData.loadAll(collection);
						}
					}, this);
				}
			};
			this.methods.onActiveRowAction = function(tag) {
				if (tag === 'delete') {
					this['delete']();
				}
			};
			this.modifyGridConfig = function(config) {
				var customConfig = {
					activeRowAction: {
						bindTo: 'onActiveRowAction'
					},
					activeRowActions : [
						{
							className: 'BPMSoft.Button',
							style: BPMSoft.controls.ButtonEnums.style.ORANGE,
							caption: LocalizableHelper.localizableStrings.Delete,
							tag: 'delete'
						}
					]
				};
				return Ext.apply(config, customConfig);
			};
			this.methods.dblClickGridDetail = function() {
				return false;
			};
		};
		return structure;
	});
