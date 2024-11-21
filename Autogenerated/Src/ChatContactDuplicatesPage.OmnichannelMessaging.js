 define("ChatContactDuplicatesPage", ["ChatContactDuplicatesDetailViewConfig", "ChatContactDuplicatesDetailViewModel"],
		function() {
			return {
				methods: {

					// region Methods: Private

					/**
					 * @private
					 */
					_addContactColumns: function(esq) {
						const columns = this.getDuplicatesColumns();
						this.BPMSoft.each(columns, function(column) {
							esq.addColumn(column);
						}, this);
					},

					/**
					 * @private
					 */
					_getDuplicatesContactData: function(duplicatesContacts) {
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

					// endregion

					// region Methods: Protected

					/**
					 * Returns query to Contact entity.
					 * @protected
					 * @param {Array} contactsId Identifiers of contacts.
					 * @returns {Object} Query to Contact entity
					 */
					getDuplicatesContactEsq: function(contactsId) {
						const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Contact"
						});
						this._addContactColumns(esq);
						const filter = this.BPMSoft.createColumnInFilterWithParameters("Id", contactsId);
						filter.comparisonType = this.BPMSoft.ComparisonType.EQUAL;
						esq.filters.add("contactFilter", filter);
						return esq;
					},
					
					/**
					 * @inheritdoc DuplicatesPageV2#getDeduplicationResultsCallback
					 * @overridden
					 */
					getDeduplicationResultsCallback: function() {
						const state = this.sandbox.publish("GetHistoryState").state;
						const contacts = state.DuplicatesContacts;
						const esq =  this.getDuplicatesContactEsq(contacts);
						esq.getEntityCollection(function(result) {
							if (result.success) {
								const data = this._getDuplicatesContactData(result.collection);
								this.processDeduplicationResults(data);
							}
						}, this);
					},

					/**
					 * @inheritdoc DuplicatesPageV2#getDuplicatesDetailModuleRootContainerId
					 * @overridden
					 */
					getDuplicatesDetailModuleRootContainerId: function (id) {
						return Ext.String.format("ChatContactDuplicatesPageDuplicateContainerContainer-{0}-listItem",
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
						config.currentContactId = state.CurrentContactId;
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
					}

					// endregion

				}
			};
		});
