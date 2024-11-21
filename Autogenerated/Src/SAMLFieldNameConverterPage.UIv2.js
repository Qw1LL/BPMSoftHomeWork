define("SAMLFieldNameConverterPage", ["Contact", "EntityStructureHelper"],
	function(contact, EntityStructureHelper) {
		return {
			entitySchemaName: "SAMLFieldNameConverter",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {
				/**
				 * Contact field name column lookup for combobox.
 				 */
				"ContactFieldNameLookup": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				}
			},
			messages: {
				/**
				 * Get entity schema structure message.
				 * @message GetEntitySchema
				 */
				"GetEntitySchema": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * Get structure explorer parameters for current page.
				 * @message StructureExplorerInfo
				 */
				"StructureExplorerInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Updates ContactFieldName column value.
				 * @private
				 * @param {Object} column Current column object.
				 * @return {Object|null} Current column lookup value.
				 */
				_updateContactFieldName: function(column) {
					if (!Ext.isObject(column)) {
						return null;
					}
					const columnName = column.columnName;
					if (columnName) {
						this.set("ContactFieldName", columnName);
					}
					return column;
				},

				/**
				 * Creates current column lookup value.
				 * @private
				 * @param {String} columnName Current column name.
				 * @param {Object} [result] Current column lookup value.
				 * @return {Object|null} Current column lookup value.
				 */
				_getContactFieldColumn: function(columnName, result) {
					if (Ext.isObject(result)) {
						return result;
					}
					var column = contact.getColumnByName(columnName);
					return column && {
						displayValue: column.caption,
						value: column.uId
					};
				},

				/**
				 * Initialize EntityStructureHelper instance.
				 * @private
				 */
				_initEntityStructureHelper: function() {
					var params = {
						sa: this.sandbox
					};
					var additionalParams = this.sandbox.publish("StructureExplorerInfo", null, [this.sandbox.id]);
					this.Ext.apply(params, additionalParams);
					EntityStructureHelper.init(params);
				},

				//endregion

				//region Methods: Protected

				/**
				 * Fills contact columns list.
				 * @protected
				 * @param {String|null} [filter] Column caption filter.
				 * @param {BPMSoft.Collection} list Contact columns list.
				 */
				fillContactColumnsList: function(filter, list) {
					if (this.Ext.isEmpty(list)) {
						return;
					}
					list.clear();
					EntityStructureHelper.getItems({referenceSchemaName: "Contact"}, function(items) {
						this.BPMSoft.each(items, function(item) {
							item.markerValue = item.displayValue;
						});
						list.loadAll(items);
					}, false, this);
				},

				//endregion

				//region Methods: Public

				constructor: function() {
					this.callParent(arguments);
					this._initEntityStructureHelper();
				},

				/**
				 * Updates ContactFieldName column value and creates lookup value for selected column.
				 * @param {String|Object} column Current selected column.
				 * @return {Object|null} Selected column lookup value.
				 */
				onContactFieldNameChanged: function(column) {
					if (this.isEmpty(column)) {
						return null;
					}
					var columnLookupValue = this._updateContactFieldName(column);
					return this._getContactFieldColumn(column, columnLookupValue);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
