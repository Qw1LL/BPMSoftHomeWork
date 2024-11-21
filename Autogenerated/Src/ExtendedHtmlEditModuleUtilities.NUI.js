define("ExtendedHtmlEditModuleUtilities", [], function() {

	/**
	 * @class BPMSoft.configuration.ExtendedHtmlEditModuleUtilities
	 */
	Ext.define("BPMSoft.configuration.mixins.ExtendedHtmlEditModuleUtilities", {
		alternateClassName: "BPMSoft.ExtendedHtmlEditModuleUtilities",

		/**
		 * @inheritdoc BPMSoft.BasePageV2#init
		 * @overridden
		 */
		init: function() {
			var entitiesList = this.Ext.create("BPMSoft.Collection");
			this.set("entitiesList", entitiesList);
		},

		/**
		 * Fills entities list.
		 * @protected
		 * @param {String} filterValue Filter value
		 * @param {BPMSoft.Collection} list Collection
		 */
		prepareEntitiesExpandableList: function(filterValue, list) {
			this.getEntities(filterValue, function(entities) {
				var result = this.prepareEntities(entities);
				list.clear();
				list.loadAll(result);
			}, this);
		},

		/**
		 * Returns entities for list.
		 * @protected
		 * @param {BPMSoft.Collection} entities
		* @return {Object}
		 */
		prepareEntities: function(entities) {
			var result = {};
			entities.each(function(entity) {
				var primaryColumnValue = entity.get("Id");
				result[primaryColumnValue] = this.prepareEntity(entity);
			}, this);
			return result;
		},

		/**
		 * Returns entity for list.
		 * @protected
		 * @param {BPMSoft.BaseViewModel} entity
		 * @return {Object}
		 */
		prepareEntity: function(entity) {
			var body = entity.get("Body");
			var value = entity.get("Name");
			return {
				value: value.replace(/"/g, "'"),
				displayValue: value,
				body: body
			};
		},

		/**
		 * Render list item event handler.
		 * @protected
		 * @param {Object} item List element
		 */
		onEntitiesListViewItemRender: function(item) {
			/*jshint quotmark: false */
			var displayValue = item.value;
			var primaryInfoHtml = [
				"<label class='listview-item-primaryInfo' data-value='" + displayValue + "'>",
				displayValue.toString(),
				"</label>"
			].join("");

			var tpl = [
				"<div class='listview-item' data-value='" + displayValue + "'>",
				primaryInfoHtml,
				"</div>"
			];
			item.customHtml = tpl.join("");
			/*jshint quotmark: true */
		},

		/**
		 * Returns entities by filter.
		 * @protected
		 * @throws {BPMSoft.ArgumentNullOrEmptyException}
		 * @param {String} filterValue Filter value
		 * @param {Function} callback
		 * @param {Object} scope Execution scope
		 */
		getEntities: function(filterValue, callback, scope) {
			if (this.Ext.isEmpty(filterValue)) {
				throw this.Ext.create("BPMSoft.ArgumentNullOrEmptyException");
			}
			var esq = this.getEsqForRetrivingEntities();
			esq.getEntityCollection(function(response) {
				if (response && response.success) {
					callback.call(scope, response.collection);
				}
			}, this);
		},

		/**
		 * Returns instance of BPMSoft.EntitySchemaQuery for search entities by filter.
		 * @protected
		 * @param {String} filterValue Filter value.
		 * @return {BPMSoft.EntitySchemaQuery} Query for retriving entities.
		 */
		getEsqForRetrivingEntities: function(filterValue) {
			var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "EmailTemplate"
			});
			esq.addColumn("Name");
			esq.addColumn("Body");
			var paramDataType = this.BPMSoft.DataValueType.TEXT;
			var lookupFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.START_WITH,
				"Name", filterValue, paramDataType);
			esq.filters.addItem(lookupFilter);
			esq.filters.addItem(this.getFilterForObject());
			return esq;
		},

		/**
		 * Returns filter to filter entities by current schema.
		 * @private
		 * @return {BPMSoft.CompareFilter} Filter by schema name.
		 */
		getFilterForObject: function() {
			var objectFilterGroup = this.BPMSoft.createFilterGroup();
			objectFilterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
			var sectionEntitySchema = this.get("SectionEntitySchemaName");
			objectFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
				this.BPMSoft.ComparisonType.EQUAL, "[SysSchema:UId:Object].Name",
				sectionEntitySchema || this.entitySchemaName));
			objectFilterGroup.addItem(this.BPMSoft.createColumnIsNullFilter("Object"));
			return objectFilterGroup;
		},

/**
		 * Returns instance of BPMSoft.EntitySchemaQuery with column RecordInactive.
		 * @protected
		 * @return {BPMSoft.EntitySchemaQuery} Query for retriving entities.
		 */

		configEmailTemplateEsq: function () {
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "EmailTemplate",
			});
			esq.addColumn("RecordInactive");

			return esq
		},

			/**
		 * Returns entity  with column RecordInactive
		 * @protected
		 * @param {Function} callback
		 * @param {Object} scope Execution scope
		 */

		getEntityEmailTemplate: function(callback,scope) {
			const esq = this.configEmailTemplateEsq()
			esq.getEntityCollection(function (result) {
				if (!result.success) {
					return;
				}
				else {
					callback.call(scope, result.collection)
				}
		}, this)
	},

		/**
		 * Open e-mail templates lookup button handler.
		 * @param {Object} control CKEditor
		 * @protected
		 */
		onOpenEmailTemplate: function(control) {
			var config = {
				entitySchemaName: "EmailTemplate",
				columns: ["Body", "Subject"],
				multiSelect: false
			};
			var callback = function(args) {
				this.onOpenEmailTemplateCallback(args, control);
			};
			const filterGroup = this.BPMSoft.createFilterGroup();
			BPMSoft.chain(
				function(next) {
					this.getEntityEmailTemplate(function(entities) {
						const isRecordInactiveNotFound = entities.rowConfig.RecordInactive?.isNotFound
						if (isRecordInactiveNotFound) {
							next()
							return
						}
						config.columns.push("RecordInactive")
						filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
							"RecordInactive", false))
						next()
					}, this);
				},
				 function() {
					filterGroup.addItem(this.getFilterForObject());
					filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
						"TemplateType", "74FF0CEE-6593-482F-A62F-6DDE6E17AB5E"));
					config.filters = filterGroup;
					this.openLookup(config, callback, this);
				 }, this
			)
		},

		/**
		 * Open e-mail templates lookup button handler callback.
		 * @param {Object} args Context arguments
		 * @param {Object} control
		 * @protected
		 */
		onOpenEmailTemplateCallback: function(args, control) {
			this.addCallBack(args, control);
		},

		/**
		 * On select item callback.
		 * @param {Object} args
		 * @param {Object} result
		 * @protected
		 */
		addCallBack: function(args, result) {
			var selectedItems = args.selectedRows.getItems();
			if (!selectedItems.length) {
				return;
			}
			var item = {
				body: selectedItems[0].Body,
				value: selectedItems[0].Name,
				isFromButton: true
			};
			const extendedHtmlEditModule = result.control;
			extendedHtmlEditModule.setTrackingValue(item, function(bodyValue) {
				bodyValue = bodyValue || extendedHtmlEditModule.getBodyValue() || BPMSoft.emptyString;
				this.set("Body", bodyValue.trim());
			}, this);
		}
	});
});
