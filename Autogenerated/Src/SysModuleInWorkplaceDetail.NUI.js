define("SysModuleInWorkplaceDetail", ["ext-base", "BPMSoft", "sandbox", "SysModuleInWorkplace",
	"SysModuleInWorkplaceDetailStructure", "SysModuleInWorkplaceDetailResources", "LookupUtilities",
	"LocalizableHelper", "ServiceHelper"],
	function(Ext, BPMSoft, sandbox, entitySchema, structure, resources, LookupUtilities, LocalizableHelper,
		ServiceHelper) {
	structure.userCode = function() {
		this.loadAll = true;
		this.entitySchema = entitySchema;
		this.name = "SysModuleInWorkplaceDetailViewModel";
		this.columnsConfig = [];
		this.loadedColumns = [
			{
				columnPath: "Position"
			}
		];
		this.gridType = "tiled";
		this.methods.esqConfig = {
			sort: {
				columns: [
					{
						name: "Position",
						orderPosition: 0,
						orderDirection: BPMSoft.OrderDirection.ASC
					}
				]
			}
		};
		this.utilsConfig = {
			hideAction: true,
			hiddenCopy: true,
			hiddenEdit: true,
			hiddenView: true,
			hiddenSettings: true,
			useAdditionalAddButton: true
		};
		var parentAdd = this.methods.add;
		var setPosition = function(recordId, position, callback, scope) {
			var data = {
				tableName: entitySchema.name,
				primaryColumnValue: recordId,
				position: position,
				grouppingColumnNames: "SysWorkplaceId"
			};
			ServiceHelper.callService("RightsService", "SetCustomRecordPosition", callback, data, scope);
		};
		var scrollTo = document.body.scrollTop = document.documentElement.scrollTop = 0;
		this.methods.onActiveRowAction = function(tag) {
			if (tag === "delete") {
				this.delete();
			}
			var recordId = this.get("activeRow");
			var gridData = this.get("gridData");
			var activeRow = gridData.get(recordId);
			var position = activeRow.get("Position");
			if (tag === "up") {
				if (position > 0) {
					position--;
				}
			}
			if (tag === "down") {
				position++;
			}
			setPosition(recordId, position, function(response) {
				scrollTo = document.body.scrollTop || document.documentElement.scrollTop;
				gridData.clear();
				this.load();
			}, this);
		};
		this.methods.init = function() {
			if (!Ext.isEmpty(scrollTo) && scrollTo > 0) {
				Ext.getBody().dom.scrollTop = scrollTo;
				Ext.getDoc().dom.documentElement.scrollTop = scrollTo;
				scrollTo = 0;
			}
		};
		this.modifyGridConfig = function(config) {
			var customConfig = {
				activeRowAction: {
					bindTo: "onActiveRowAction"
				},
				activeRowActions: [
					{
						className: "BPMSoft.Button",
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						imageConfig: LocalizableHelper.localizableImages.Up,
						tag: "up"
					},
					{
						className: "BPMSoft.Button",
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						imageConfig: LocalizableHelper.localizableImages.Down,
						tag: "down"
					},
					{
						className: "BPMSoft.Button",
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						caption: LocalizableHelper.localizableStrings.Delete,
						tag: "delete"
					}
				]
			};
			return Ext.apply(config, customConfig);
		};
		this.methods.add = function(tag) {
			parentAdd.call(this, null, this.addModule);
		};
		this.methods.addModule = function(tag) {
			var workplaceId = this.filterValue;
			var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysModuleInWorkplace"
			});
			esq.addColumn("SysModule.Id", "SysModuleId");
			esq.filters.add("ExistsFilter", BPMSoft.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "SysWorkplace", workplaceId));
			esq.getEntityCollection(function(result) {
				var existsCollection = [];
				if (result.success) {
					BPMSoft.each(result.collection.getItems(), function(item) {
						existsCollection.push(item.get("SysModuleId"));
					});
				}
				var config = {
					entitySchemaName: "SysModule",
					multiSelect: true
				};
				var filterGroup = BPMSoft.createFilterGroup();
				if (existsCollection.length > 0) {
					var existsFilter = BPMSoft.createColumnInFilterWithParameters("Id", existsCollection);
					existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
					filterGroup.add("existsFilter", existsFilter);
				}
				var nuiModulesFilter = BPMSoft.createColumnIsNotNullFilter("SectionModuleSchemaUId");
				filterGroup.add("nuiModulesFilter", nuiModulesFilter);
				config.filters = filterGroup;
				LookupUtilities.ThrowOpenLookupMessage(sandbox, config, this.addCallBack, this,
					this.getCardModuleSandboxId());

			}, this);
		};
		this.methods.addCallBack = function(args) {
			var bq = Ext.create("BPMSoft.BatchQuery");
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
			var insert = Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "SysModuleInWorkplace"
			});
			insert.setParameterValue("SysModule", item.value, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("SysWorkplace", this.filterValue, BPMSoft.DataValueType.GUID);
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
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
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
					var items = response.collection.getItems();
					if (items.length > 0) {
						var collection = new BPMSoft.Collection();
						BPMSoft.each(items, function(item) {
							collection.add(item.get("Id"), item);
						});
						this.set("gridEmpty", false);
						var gridData = this.get("gridData");
						gridData.loadAll(collection);
					}
				}, this);
			}
		};
		this.methods.dblClickGridDetail = function() {
			return false;
		};
	};
	return structure;
});
