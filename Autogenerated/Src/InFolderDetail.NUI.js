﻿define('InFolderDetail', ['ext-base', 'BPMSoft', 'sandbox', 'InFolderDetailStructure', 'InFolderDetailResources',
	'LookupUtilities', 'ConfigurationConstants'],
function(Ext, BPMSoft, sandbox, structure, resources, LookupUtilities, ConfigurationConstants) {
	structure.userCode = function() {
		var sectionName = this.filterPath;
		this.utilsConfig = {
			hiddenCopy: true,
			hiddenEdit: true
		};
		this.name = 'InFolderDetailViewModel';
		this.columnsConfig = [
			[
				{
					cols: 16,
					key: [
						{
							name: {
								bindTo: 'Folder'
							}
						}
					]
				},
				{
					cols: 8,
					key: [
						{
							name: {
								bindTo: 'CreatedBy'
							}
						}
					]
				}
			]
		];
		this.loadedColumns = [
			{
				columnPath: 'Folder'
			},
			{
				columnPath: 'CreatedBy'
			}
		];
		var parentAdd = this.methods.add;
		this.methods.add = function(tag) {
			parentAdd.call(this, null, this.addFolder);
		};
		this.methods.addFolder = function(tag) {
			var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
				rootSchemaName: sectionName + 'InFolder'
			});
			esq.addColumn('Folder');
			esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, sectionName, this.filterValue));
			esq.rowCount = 1000;
			esq.getEntityCollection(function(response) {
				if (response.success) {
					var inFolders = [];
					BPMSoft.each(response.collection.getItems(), function(item) {
						inFolders.push(item.values.Folder.value);
					}, this);
					var filterGroup = BPMSoft.createFilterGroup();
					if (inFolders.length > 0) {
						var notInFilter = BPMSoft.createColumnInFilterWithParameters(
							'Id', inFolders);
						notInFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
						filterGroup.addItem(notInFilter);
					}
					filterGroup.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, 'FolderType',
						ConfigurationConstants.Folder.Type.General));
					/*filterGroup.addItem(BPMSoft.createColumnIsNotNullFilter('Parent'));*/
					var config = {
						entitySchemaName: sectionName + 'Folder',
						multiSelect: true,
						filters: filterGroup
					};
					LookupUtilities.ThrowOpenLookupMessage(sandbox, config, this.addCallBack, this,
						this.getCardModuleSandboxId());
				}
			}, this);
		};

		this.methods.addCallBack = function(args) {
			var folderCollection = [];
			BPMSoft.each(args.selectedRows.collection.items, function(item) {
				folderCollection.push(item.value);
			}, this);

			if (folderCollection.length > 0) {
				var bq = Ext.create('BPMSoft.BatchQuery');
				BPMSoft.each(folderCollection, function(folderId) {
					bq.add(this.getFolderInsertQuery(folderId), this.onFolderInsert, this);
				}, this);
				bq.execute();
			}
		};

		this.methods.getFolderInsertQuery = function(folderId) {
			var insert = Ext.create('BPMSoft.InsertQuery', {
				rootSchemaName: sectionName + 'InFolder'
			});
			var id = BPMSoft.utils.generateGUID();
			insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("Folder", folderId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue(sectionName, this.filterValue, BPMSoft.DataValueType.GUID);
			return insert;
		};

		this.methods.onFolderInsert = function(response) {
			if (response && response.id) {
				var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: sectionName + 'InFolder'
				});
				var loadedColumns = this.loadedColumns;
				for(var column in loadedColumns) {
					esq.addColumn(loadedColumns[column].columnPath);
				}
				esq.getEntity(response.id, function(result) {
					var entity = result.entity;
					if (entity) {
						entity.entitySchema = this.entitySchema;
						var gridData =  this.get('gridData');
						var collection = new BPMSoft.Collection();
						collection.add(entity.get('Id'), entity);
//						collection.insert(0, entity.get('Id'), entity);
						this.set('gridEmpty', false);
						gridData.loadAll(collection);
					}
				}, this);
			}
		};
	};
	return structure;
});
