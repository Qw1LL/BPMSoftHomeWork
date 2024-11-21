define('LeadEditPageDesignerHelper', ['ext-base', 'BPMSoft', 'GeneratedWebForm', 'Lead'],
	function(Ext, BPMSoft, GeneratedWebForm, Lead) {
		function getWebFormLeadColumnsContainerName() {
			return 'leftPanel';
		}
		function getWebFormLeadColumnsContainer(schema) {
			if (!schema.hasOwnProperty(getWebFormLeadColumnsContainerName())) {
				return null;
			}
			return schema[getWebFormLeadColumnsContainerName()];
		}
		function addWebFormLeadColumn(schema, column, checkDuplicates) {
			var container = getWebFormLeadColumnsContainer(schema.schema);
			var canAddColumn = true;
			if (checkDuplicates) {
				container.forEach(function(item)  {
					canAddColumn = canAddColumn && (item.columnPath !== column.columnPath);
				}, this);
			}
			if (canAddColumn) {
				var containerItem = BPMSoft.deepClone(column);
				container.push(containerItem);
			}
		}
		function addWebFormLeadColumns(schema, webFormLeadColumns) {
			webFormLeadColumns.getItems().forEach(function(item) {
				this.addWebFormLeadColumn(schema, item, true);
			}, this);
		}
		function replaceWebFormLeadColumn(schema, column) {
			var container = getWebFormLeadColumnsContainer(schema.schema);
			container.forEach(function(item) {
				if (item.columnPath === column.columnPath) {
					container[container.indexOf(item)] = BPMSoft.deepClone(column);
					return;
				}
			}, this);
		}
		function loadWebFormLeadColumns(recordId, action, callback, scope) {
			var webFormLeadColumns = new BPMSoft.Collection();
			var select = Ext.create('BPMSoft.EntitySchemaQuery', {
				rootSchema: GeneratedWebForm
			});
			select.rowCount = 1;
			select.addColumn('Id');
			select.addColumn('FormFields');
			select.filters.add('filterId', BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, 'Id', recordId));
			select.getEntityCollection(function(result) {
				if (result.success) {
					var leadColumns = Lead.columns;
					var defaultLeadColumnsArray = (action === "view") ? [] : [
						{
							field: leadColumns.Contact.name,
							caption: leadColumns.Contact.caption,
							isRequired: true
						},
						{
							field: leadColumns.Email.name,
							caption: leadColumns.Email.caption,
							isRequired: true
						},
						{
							field: leadColumns.Account.name,
							caption: leadColumns.Account.caption,
							isRequired: false
						},
						{
							field: leadColumns.BusinesPhone.name,
							caption: leadColumns.BusinesPhone.caption,
							isRequired: false
						}
					];
					var leadColumnsArray;
					if (result.collection.getCount() > 0) {
						var item = result.collection.getByIndex(0);
						var leadColumnsData = item.get('FormFields', BPMSoft.DataValueType.TEXT);
						leadColumnsArray = Ext.JSON.decode(leadColumnsData, true);
						leadColumnsArray = (leadColumnsArray && leadColumnsArray.length > 0)
							? leadColumnsArray
							: defaultLeadColumnsArray;
					} else  {
						leadColumnsArray = defaultLeadColumnsArray;
					}
					leadColumnsArray.forEach(function(item) {
						var webFormLeadColumn = {
							EditStructureContainerId: BPMSoft.generateGUID(),
							name: item.field,
							columnPath: item.field,
							caption: item.caption,
							isRequired: item.isRequired,
							dataValueType: BPMSoft.DataValueType.TEXT,
							type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE
						};
						webFormLeadColumns.add(item.field, BPMSoft.deepClone(webFormLeadColumn));
					}, this);
				}
				callback.call(scope || this, webFormLeadColumns);
			}, scope || this);
		}
		function getWebFormLeadColumnsData(webFormLeadColumns) {
			var result = [];
			webFormLeadColumns.getItems().forEach(function(item) {
				result.push({
					field: item.columnPath,
					caption: item.caption,
					isRequired: item.isRequired
				});
			}, this);
			return result;
		}
		function moveWebFormLeadColumn(schema, oldIndex, newIndex) {
			var container = getWebFormLeadColumnsContainer(schema.schema);
			if (newIndex > container.length || newIndex < 0 ||
				oldIndex > container.length || oldIndex < 0  ||
				oldIndex === newIndex) {
				return;
			}
			var item = container[oldIndex];
			container.splice(oldIndex, 1);
			container.splice(newIndex, 0, item);
		}


		return {
			getWebFormLeadColumnsContainer: getWebFormLeadColumnsContainer,
			addWebFormLeadColumn: addWebFormLeadColumn,
			addWebFormLeadColumns: addWebFormLeadColumns,
			replaceWebFormLeadColumn: replaceWebFormLeadColumn,
			loadWebFormLeadColumns: loadWebFormLeadColumns,
			getWebFormLeadColumnsData: getWebFormLeadColumnsData,
			moveWebFormLeadColumn: moveWebFormLeadColumn
		};
	});
