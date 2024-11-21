define("UserPageV2", [],
	function() {
		return {
			entitySchemaName: "VwSysAdminUnit",
			messages: {},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "SysCulture",
					"values": {
						"controlConfig": {
							"prepareList": {"bindTo": "onPrepareSysCultureList"}
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				/**
				 * Culture list.
				 */
				"SysCultureList": {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				}
			},
			rules: {},
			methods: {

				/**
				 * @inheritDoc BasePageV2#init
				 * @protected
				 * @overridden
				 * @param {Function} callback Callback method.
				 * @param {Object} scope Callback method context.
				 */
				init: function(callback, scope) {
					this.callParent([
						function() {
							this.set("SysCultureList", this.Ext.create(BPMSoft.Collection));
							this.loadDefaultSysCultureValue(callback, scope);
						}, this
					]);
				},

				/**
				 * Load default culture if need.
				 * @protected
				 * @param {Function} callback Callback method.
				 * @param {Object} callback Callback method context.
				 */
				loadDefaultSysCultureValue: function(callback, scope) {
					var sysCulture = this.get("SysCulture");
					if (!this.Ext.isEmpty(sysCulture)) {
						this.Ext.callback(callback, scope);
						return;
					}
					this.BPMSoft.chain(
						function(next) {
							this.callService({
								"serviceName": "SysCultureService",
								"methodName": "GetDefaultCulture",
								"data": {}
							}, next, this);
						},
						function(next, response) {
							var recordId = response && response.GetDefaultCultureResult;
							if (this.BPMSoft.isGUID(recordId) && !this.BPMSoft.isEmptyGUID(recordId)) {
								this.loadLookupDisplayValue("SysCulture", recordId, next, this);
							} else {
								next();
							}
						},
						function() {
							this.Ext.callback(callback, scope);
						},
						this);
				},

				/**
				 * Creates culture entity schema query.
				 * @protected
				 * @return {BPMSoft.EntitySchemaQuery}
				 */
				createSysCultureQuery: function() {
					var esq = this.Ext.create(BPMSoft.EntitySchemaQuery, {rootSchemaName: "SysCulture"});
					this.initSysCultureQueryColumns(esq);
					this.initSysCultureQueryFilters(esq);
					return esq;
				},

				/**
				 * Initializes system culture query columns.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq Entity schema query.
				 */
				initSysCultureQueryColumns: function(esq) {
					esq.addColumn("Id");
					esq.addColumn("Name", "Code");
				},

				/**
				 * Initializes system culture query filters.
				 * @protected
				 * @virtual
				 */
				initSysCultureQueryFilters: function(esq) {
					esq.filters.add("ActiveLanguageFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Active", true));
				},

				/**
				 * Prepares culture list item.
				 * @protected
				 * @virtual
				 * @param {Object} item Culture list item.
				 * @return {Object}
				 */
				prepareSysCultureListItem: function(item) {
					return {
						value: item.get("Id"),
						displayValue: this.getSysCultureDisplayValue(item)
					};
				},

				/**
				 * Gets system culture display value.
				 * @protected
				 * @virtual
				 * @param {Object} item System culture.
				 * @return {String}
				 */
				getSysCultureDisplayValue: function(item) {
					return item.get("Code");
				},

				/**
				 * Event handler for prepare list event of system culture lookup.
				 */
				onPrepareSysCultureList: function() {
					var esq = this.createSysCultureQuery();
					esq.getEntityCollection(function(response) {
						if (!response || !response.success) {
							return;
						}
						var list = this.get("SysCultureList");
						var columnList = {};
						response.collection.each(function(item) {
							if (item.get("Code") === 'en-US') return;
							columnList[item.get("Id")] = this.prepareSysCultureListItem(item);
						}, this);
						list.clear();
						list.loadAll(columnList);
					}, this);
				}

			}
		};
	});
