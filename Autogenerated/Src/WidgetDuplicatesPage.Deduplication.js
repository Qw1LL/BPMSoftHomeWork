define("WidgetDuplicatesPage", [
		"ChatContactDuplicatesDetailViewConfig", 
		"ChatContactDuplicatesDetailViewModel",
		"css!LazyDuplicatesPageCSS"], function() {
	return {
		columns: {
			"IsRecordsMerged": { 
				"dataValueType": BPMSoft.DataValueType.BOOLEAN
		 	}
		},
		mixins: {
			QueryCancellationMixin: "BPMSoft.QueryCancellationMixin",
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_addQueryColumns: function(esq) {
				const columns = this.getDuplicatesColumns();
				this.BPMSoft.each(columns, function(column) {
					esq.addColumn(column);
				}, this);
			},


			/**
			 * @private
			 */
			_getDuplicatesData: function(duplicatesContacts) {
				let rows = [];
				const items = duplicatesContacts.getItems();
				this.BPMSoft.each(items, function(item) {
					rows.push(item.values);
				}, this);
				return {
					"groups": [
						{
							"groupId": 1,
							"rows": rows
						}
					],
					"rowConfig": duplicatesContacts.rowConfig
				};
			},

			/**
			 * Merge entities handler
			 * @protected
			 */
			onMergeEntityDuplicatesExecuted: function (mergedRecordsIds) {
				this.callParent(arguments);
				const state = this.sandbox.publish("GetHistoryState").state;
				if (mergedRecordsIds.includes(state.CurrentEntityId)) {
					this.$IsRecordsMerged = true;
				}
			},

			/**
			 * @private
			 */
			 _redirectToEntitySection: function() {
				const state = this.sandbox.publish("GetHistoryState").state;
				const moduleStructure = this.getModuleStructure(state.EntitySchemaName);
				this.sandbox.publish("PushHistoryState", {hash: moduleStructure.sectionModule + "/" + moduleStructure.sectionSchema});
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onCloseClick
			 * @overriden
			 */
			onCloseClick: function() {
				if (this.$IsRecordsMerged) {
					this._redirectToEntitySection();
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Returns query to duplicates entity.
			 * @protected
			 * @param {Array} duplicateEntitiesIds Identifiers of duplicate entities.
			 * @returns {Object} Query to entity.
			 */
			getDuplicatesEntitiesEsq: function(schemaName, duplicateEntitiesIds) {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: schemaName
				});
				this._addQueryColumns(esq);
				esq.filters.addItem(this.BPMSoft.createColumnInFilterWithParameters("Id", duplicateEntitiesIds));
				if (this.getIsFeatureEnabled("DuplicatesPageFilters")) {
					this.applyCustomFilters(esq);
				}
				return esq;
			},

			/**
			 * Applies user's custom filters to query.
			 * @protected
			 * @param {BPMSoft.EntitySchemaQuery} esq EntitySchemaQuery instance. 
			 */
			applyCustomFilters: function(esq) {
				const filters = this.getCustomFiltersGroup();
				esq.filters.addItem(filters);
			},

			/**
			 * Forms duplicates entities identifiers collection from history state.
			 * @protected
			 * @param {Object} state History State.
			 * @param {Array} state.DuplicateEntitiesIds Duplicates entities identifiers.
			 * @param {Array} state.CurrentEntityId Current entity identifier.
			 * @returns {Array} Formed duplicates entities identifiers collection.
			 */
			formDuplicatesCollection: function(state) {
				let duplicateEntitiesIds = state.DuplicateEntitiesIds || [];
				duplicateEntitiesIds = duplicateEntitiesIds.slice();
				duplicateEntitiesIds.push(state.CurrentEntityId);
				return duplicateEntitiesIds;
			},

			/**
			 * @inheritdoc DuplicatesPageV2#getDeduplicationResults
			 * @overridden
			 */
			getDeduplicationResults: function() {
				const state = this.sandbox.publish("GetHistoryState").state;
				let duplicateEntitiesIds = this.formDuplicatesCollection(state);
				const esq =  this.getDuplicatesEntitiesEsq(state.EntitySchemaName, duplicateEntitiesIds);
				esq.getEntityCollection(function(result) {
					if (result.success) {
						const collection = result.collection;
						this._setSourceEntityInCollection(collection);
						const data = this._getDuplicatesData(collection);
						this.processDeduplicationResults(data);
					}
				}, this);
				const key = "getDeduplicationResults";
				this.registerSentQuery(key, esq);
			},

			/**
			 * Registers sent queries in a module-wide object by their keys.
			 * Cancels previously sent query with the same key.
			 * @protected
			 * @param {String} key A string to uniquely identify the query.
			 * @param {BPMSoft.BaseQuery} esq A Query to be registered.
			 **/
			registerSentQuery: function(key, esq) {
				this.mixins.QueryCancellationMixin.registerSentQuery.call(this, key, esq);
			},

			/**
			 * Finds root entity and sets IsSourceEntity attribute.
			 * @private
			 * @param {BPMSoft.Collection} collection Duplicates entities collection.
			 */
			_setSourceEntityInCollection: function(collection) {
				const state = this.sandbox.publish("GetHistoryState").state;
				const rootEntity = collection.find(state.CurrentEntityId);
				if (rootEntity) {
					rootEntity.values.IsSourceEntity = true;
				}
			},

			/**
			 * @inheritdoc DuplicatesPageV2#getDuplicatesDetailModuleRootContainerId
			 * @overridden
			 */
			getDuplicatesDetailModuleRootContainerId: function (id) {
				return Ext.String.format("WidgetDuplicatesPageDuplicateContainerContainer-{0}-listItem",
					id);
			},

			/**
			 * @inheritdoc DuplicatesPageV2#getDuplicatesGroupDetailConfig
			 * @overridden
			 */
			getDuplicatesGroupDetailConfig: function() {
				const config = this.callParent(arguments);
				const state = this.sandbox.publish("GetHistoryState").state;
				config.viewConfigClassName = this.getDuplicatesDetailViewConfigClassName();
				config.viewModelClassName = this.getDuplicatesDetailViewModelClassName();
				config.currentContactId = state.CurrentEntityId;
				return config;
			},

			/**
			 * Returns name of detail viewConfig class.
			 * @protected
			 * @returns {String} Name of detail viewConfig class.
			 */
			getDuplicatesDetailViewConfigClassName: function() {
				return "BPMSoft.ChatContactDuplicatesDetailViewConfig";
			},

			/**
			 * Returns name of detail viewModel class.
			 * @protected
			 * @returns {String} Name of detail viewModel class.
			 */
			getDuplicatesDetailViewModelClassName: function() {
				return "BPMSoft.ChatContactDuplicatesDetailViewModel";
			},

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["card-content-container", "duplicates-content-wrap", "lazy-duplicates-page"]
				}
			}
		]
	};
 });