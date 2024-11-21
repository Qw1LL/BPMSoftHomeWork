define('ActivityParticipantDetail', ['ext-base', 'BPMSoft', 'sandbox', 'ActivityParticipant',
	'ConfigurationConstants', 'ActivityParticipantDetailStructure',
	'ActivityParticipantDetailResources', 'LookupUtilities'],
	function(Ext, BPMSoft, sandbox, ActivityParticipant, ConfigurationConstants,
		structure, resources, LookupUtilities) {

		structure.userCode = function() {
			this.entitySchema = ActivityParticipant;
			this.name = 'ActivityParticipantDetailViewModel';
			this.utilsConfig = {
				hiddenCopy: true,
				hiddenEdit: true,
				hiddenView: true
			};
			this.columnsConfig = [
				[{
					cols: 12,
					key: [{
						name: {
							bindTo: 'Participant'
						}
					}]
				}, {
					cols: 12,
					key: [{
						name: {
							bindTo: 'Participant.JobTitle'
						}
					}]
				}, {
					cols: 8,
					key: [{
						name: {
							bindTo: 'Role'
						}
					}]
				}, {
					cols: 8,
					key: [{
						name: {
							bindTo: 'Participant.Phone'
						}
					}]
				}, {
					cols: 8,
					key: [{
						name: {
							bindTo: 'Participant.MobilePhone'
						}
					}]
				}, {
					cols: 8,
					key: [{
						name: {
							bindTo: 'Participant.Email'
						}
					}]
				}]
			];
			this.loadedColumns = [{
				columnPath: 'Participant'
			}, {
				columnPath: 'Participant.JobTitle'
			}, {
				columnPath: 'Participant.Phone'
			}, {
				columnPath: 'Participant.MobilePhone'
			}, {
				columnPath: 'Participant.Email'
			}, {
				columnPath: 'Role'
			}];

			var parentAdd = this.methods.add;
			this.methods.add = function(tag) {
				parentAdd.call(this, null, this.addParticipant);
			};
			this.methods.addParticipant = function(tag) {
				var activityId = this.filterValue;
				var roleId = ConfigurationConstants.Activity.ParticipantRole.Participant;
				var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: ActivityParticipant.name
				});
	//			esq.rowCount = 1000;
				esq.addColumn('Id');
				esq.addColumn('Participant.Id', 'ContactId');
				esq.filters.add('filterActivity', BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, 'Activity', activityId));
				esq.filters.add('filterRole', BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Role", roleId));
				esq.getEntityCollection(function(result) {
					var existsContactsCollection = [];
					if (result.success) {
						BPMSoft.each(result.collection.getItems(), function(item) {
							existsContactsCollection.push(item.values.ContactId);
						});
					}
					var config = {
						entitySchemaName: 'Contact',
						multiSelect: true,
						columns: ['JobTitle', 'MobilePhone', 'Email']
					};
					if (existsContactsCollection.length > 0) {
						var existsFilter = BPMSoft.createColumnInFilterWithParameters('Id', existsContactsCollection);
						existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
						config.filters = existsFilter;
					}
					LookupUtilities.ThrowOpenLookupMessage(sandbox, config, this.addCallBack, this,
						this.getCardModuleSandboxId());

				}, this);
			};
			this.methods.addCallBack = function(args) {
				var bq = Ext.create('BPMSoft.BatchQuery');
				var activityId = this.filterValue;
				this.selectedRows = args.selectedRows.getItems();
				this.selectedItems = [];
				this.selectedRows.forEach(function(item) {
					item.ActivityId = activityId;
					bq.add(this.getContactInsertQuery(item));
					this.selectedItems.push(item.value);
				}, this);
				if (bq.queries.length) {
					bq.execute(this.onContactInsert, this);
				}
			};
			this.methods.getContactInsertQuery = function(item) {
				var roleId = ConfigurationConstants.Activity.ParticipantRole.Participant;
				var insert = Ext.create('BPMSoft.InsertQuery', {
					rootSchemaName: 'ActivityParticipant'
				});
				insert.setParameterValue('Activity', item.ActivityId, BPMSoft.DataValueType.GUID);
				insert.setParameterValue('Participant', item.value, BPMSoft.DataValueType.GUID);
				insert.setParameterValue('Role', roleId, BPMSoft.DataValueType.GUID);
				return insert;
			};
			this.methods.onContactInsert = function(response) {
				var filterCollection = [];
				response.queryResults.forEach(function(item) {
					filterCollection.push(item.id);
				});
				var esq = Ext.create('BPMSoft.EntitySchemaQuery', {
					rootSchemaName: ActivityParticipant.name
				});
				esq.addColumn(this.entitySchema.primaryColumnName);
				BPMSoft.each(this.loadedColumns, function(item) {
					esq.addColumn(item.columnPath);
				});
				esq.filters.add('recordId', BPMSoft.createColumnInFilterWithParameters('Id', filterCollection));
				esq.getEntityCollection(function(result) {
					if (result.success) {
						var resultCollection = result.collection;
						resultCollection.each(function(item) {
							item.entitySchema = this.entitySchema;
							item.id = item.values.Id;
						}, this);
						this.set('gridLoading', false);
						this.set('gridEmpty', false);
						this.get('gridData').loadAll(resultCollection);
					}
				}, this);
			};
			var parentDelete = this.methods['delete'];
			this.methods['delete'] = function() {
				var selectedRows = this.GetSelectedItems();
				var deleteRows = [];
				var gridData = this.get('gridData');
				var roleId = ConfigurationConstants.Activity.ParticipantRole.Responsible;
				var isResponsibleExists = false;
				BPMSoft.each(selectedRows, function(rowId) {
					var row = gridData.get(rowId);
					if (Ext.isEmpty(row.values.Role) || (row.values.Role.value !== roleId)) {
						deleteRows.push(rowId);
					} else {
						isResponsibleExists = true;
					}
				}, this);
				if (isResponsibleExists) {
					this.showInformationDialog(resources.localizableStrings.WarningResponsibleDelete);
				}
				if (deleteRows.length > 0) {
					this.setSelectedItems(deleteRows);
					parentDelete.call(this);
				}
			};
		};
		return structure;
	});
