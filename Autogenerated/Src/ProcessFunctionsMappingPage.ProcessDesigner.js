define("ProcessFunctionsMappingPage", ["BPMSoft", "GridUtilitiesV2"],
	function(BPMSoft) {
		return {
			mixins: {
				GridUtilities: "BPMSoft.GridUtilities"
			},
			attributes: {
				"GridData": {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				"ActiveRow": {
					dataValueType: BPMSoft.DataValueType.TEXT
				}
			},
			messages: {
				"GetProcessSchema": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				},
				"ResultSelectedRows": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"ResultActiveRow": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				"GetSelectedProcessParameter": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				"GetParameterMappingInfo": {
					direction: BPMSoft.MessageDirectionType.PUBLISH,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @overridden
				 */
				init: function(callback) {
					this.callParent([function() {
						this.initGridData();
						this.initGridRowViewModel(function() {
							this.getGridCollection(function(collection) {
								this.loadGridCollection(collection);
								this.on("change:ActiveRow", this.onChangeActiveRow, this);
								this.sandbox.subscribe(
									"GetSelectedProcessParameter", this.getSelectedData, this, [this.sandbox.id]);
								callback.call(this);
							});
						}, this);
					}, this]);
				},
				/**
				 * Active row change handler.
				 * @protected
				 * @virtual
				 */
				onChangeActiveRow: function() {
					var selectedRows = this.getSelectedRows();
					this.sandbox.publish("ResultActiveRow", selectedRows, [this.sandbox.id]);
				},
				/**
				 * Returns grid collection.
				 * @protected
				 * @param {Function} callback Callback function.
				 */
				getGridCollection: function(callback) {
					var dataCollection = BPMSoft.process.constants.FUNCTIONS;
					callback.call(this, dataCollection);
				},
				/**
				 * Initialize grid data.
				 * @private
				 */
				initGridData: function() {
					this.set("GridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
				},
				/**
				 * Loads grid data.
				 * @private
				 */
				loadGridCollection: function(dataCollection) {
					var collection = this.get("GridData");
					collection.clear();
					var gridRowViewModelName = this.getGridRowViewModelClassName();
					var gridRowsList = {};
					BPMSoft.each(dataCollection, function(item) {
						var value = item.value;
						var displayValue = item.displayValue;
						displayValue = displayValue.replace(BPMSoft.process.constants.FORMULA_ARGUMENTS_REGEX, "()");
						gridRowsList[value] = this.Ext.create(gridRowViewModelName, {
							rowConfig: {
								Value: {
									dataValueType: BPMSoft.DataValueType.TEXT
								},
								DisplayValue: {
									dataValueType: BPMSoft.DataValueType.TEXT
								}
							},
							values: {
								Value: value,
								DisplayValue: displayValue
							}
						});
					}, this);
					collection.loadAll(gridRowsList);
				},
				/**
				 * Returns selected function.
				 * @protected
				 * @return {Object} Selected data.
				 * @return {String} return.value Selected item value.
				 * @return {String} return.displayValue Selected item display value.
				 */
				getSelectedData: function() {
					var primaryColumnValue = this.get("ActiveRow");
					if (!primaryColumnValue) {
						return null;
					}
					var gridData = this.get("GridData");
					if (!gridData.find(primaryColumnValue)) {
						return null;
					}
					var activeRow =  gridData.get(primaryColumnValue);
					var value = activeRow.get("Value");
					var displayValue = activeRow.get("DisplayValue");
					return {
						value: value,
						displayValue: displayValue
					};
				},
				/**
				 * Returns selected data.
				 * @private
				 * @return {Object}
				 */
				getSelectedRows: function() {
					var selectedData = this.getSelectedData();
					var result = new BPMSoft.Collection();
					if (selectedData) {
						result.add(selectedData.value, selectedData);
					}
					return {
						selectedRows: result
					};
				},
				/**
				 * Handler for double click.
				 * @private
				 */
				onGridDoubleClick: function() {
					var selectedRows = this.getSelectedRows();
					this.sandbox.publish("ResultSelectedRows", selectedRows, [this.sandbox.id]);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "DataGrid",
					"propertyName": "items",
					"values": {
						"primaryColumnName": "Value",
						"primaryDisplayColumnName": "DisplayValue",
						"itemType": BPMSoft.ViewItemType.GRID,
						"type": "listed",
						"listedZebra": true,
						"collection": {"bindTo": "GridData"},
						"activeRow": {"bindTo": "ActiveRow"},
						"openRecord": {"bindTo": "onGridDoubleClick"},
						"columnsConfig": [{
							cols: 24,
							key: [{
								name: {bindTo: "DisplayValue"}
							}]
						}]
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
