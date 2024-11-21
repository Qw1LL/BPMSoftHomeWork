define("ProcessTaskExecutionDetailsActivityEditPage", ["ProcessTaskExecutionDetailsActivityEditPageResources",
	"css!ProcessTaskExecutionDetailsEditPage"],
	function(resources) {
		return {
			messages: {
				/**
				 * @message ValidateRecord
				 * Validates record.
				 */
				"ValidateRecord": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message SaveRecord
				 * Saves record.
				 */
				"GetChangedValues": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			entitySchemaName: "Activity",
			attributes: {
				/**
				 * Activity record identifier.
				 */
				"ActivityRecordId": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": BPMSoft.DataValueType.GUID
				},
				/**
				 * Owner column value.
				 */
				"Owner": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "Owner"
				},
				/**
				 * Role column value.
				 */
				"OwnerRole": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "OwnerRole"
				},
				/**
				 * StartDate column value.
				 */
				"StartDate": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "StartDate"
				},
				/**
				 * Title column value.
				 */
				"Title": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "Title"
				},
				/**
				 * DueDate column value.
				 */
				"DueDate": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "DueDate"
				},
				/**
				 * ShowInScheduler column value.
				 */
				"ShowInScheduler": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "ShowInScheduler"
				},
				/**
				 * RemindToOwner column value.
				 */
				"RemindToOwner": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "RemindToOwner"
				},
				/**
				 * RemindToOwnerDate column value.
				 */
				"RemindToOwnerDate": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "RemindToOwnerDate"
				},
				/**
				 * Priority column value.
				 */
				"Priority": {
					"type": BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
					"columnPath": "Priority"
				}
			},
			properties: {
				/**
				 * Activity columns to validate.
				 */
				activityColumnsToValidate: [
					"Title",
					"StartDate",
					"DueDate",
					"RemindToOwnerDate",
					"Priority"
				]
			},
			methods: {

				// region Methods: Private

				/**
				 * @private
				 */
				_onStartDateChange: function() {
					const startDate = this.get("StartDate");
					if (!Ext.isDate(startDate)) {
						return;
					}
					const previousStartDate = this.getPrevious("StartDate");
					const dueDate = this.get("DueDate");
					const dueDateShift = dueDate - previousStartDate;
					this.set("DueDate", new Date(startDate.getTime() + dueDateShift));
					const remindDate = this.get("RemindToOwnerDate");
					if (remindDate && this.get("RemindToOwner")) {
						const remindDateShift = previousStartDate - startDate;
						const newRemindDate = new Date(remindDate.getTime() - remindDateShift);
						this.set("RemindToOwnerDate", newRemindDate);
					}
				},

				/**
				 * @private
				 */
				_setRemindToOwner: function () {
					const remindToOwnerDate = this.get("RemindToOwnerDate");
					this.set("RemindToOwner", Ext.isDate(remindToOwnerDate));
				},

				/**
				 * @private
				 */
				_copyAdditionalAttributeValues: function(additionalAttributeValues) {
					BPMSoft.each(additionalAttributeValues, function(attributeValue, attributeName) {
						const existingValue = this.get(attributeName);
						if (existingValue?.value !== attributeValue?.value) {
							this.set(attributeName, attributeValue);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_onGetChangedValues: function(config) {
					this._copyAdditionalAttributeValues(config.additionalAttributeValues ?? {});
					this._setRemindToOwner();
					const changedColumnNames = this.getChangedEntityColumns();
					const changedValues = {};
					BPMSoft.each(changedColumnNames, function(columnName) {
						const dataValueType = this.columns[columnName].dataValueType;
						changedValues[columnName] = dataValueType === BPMSoft.DataValueType.LOOKUP
							? this.getLookupValue(columnName)
							: this.get(columnName);
					}, this);
					return changedValues;
				},

				/**
				 * @private
				 */
				_validateDueDate: function() {
					const startDate = this.get("StartDate");
					const dueDate = this.get("DueDate");
					if (!Ext.isEmpty(dueDate) && startDate > dueDate) {
						const invalidMessage = resources.localizableStrings.StartDateIsGreaterThanDueDate;
						this.showInformationDialog(invalidMessage);
						return false;
					}
					return true;
				},

				// endregion

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @param {Function} [callback] Callback function.
				 * @param {Object} [scope] Callback parameter.
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						BPMSoft.chain(
							function(next) {
								const activityRecordId = this.get("ActivityRecordId");
								this.loadEntity(activityRecordId, next, this);
							}, function() {
								const sandbox = this.sandbox;
								const tags = [sandbox.id];
								sandbox.subscribe("ValidateRecord", this.validate, this, tags);
								sandbox.subscribe("GetChangedValues", this._onGetChangedValues, this, tags);
								this.on("change:StartDate", this._onStartDateChange, this);
								this.on("change:DueDate", this._validateDueDate, this);
								this.on("change:RemindToOwnerDate", this._setRemindToOwner, this);
								Ext.callback(callback, scope);
							}, this);
					}, this]);
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#validate
				 * @override
				 */
				validate: function() {
					const isValid = this.callParent(arguments);
					if (!isValid) {
						return false;
					}
					return this._validateDueDate();
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#validateColumn
				 * @override
				 */
				validateColumn: function(columnName, options) {
					if (BPMSoft.contains(this.activityColumnsToValidate, columnName)) {
						return this.callParent(arguments);
					}
					return true;
				}

				// endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ActivityRecordsLayout",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [
							{
								"name": "Title",
								"contentType": this.BPMSoft.ContentType.LONG_TEXT,
								"layout": { "column": 0, "row": 0, "colSpan": 24 }
							}, {
								"name": "StartDate",
								"layout": { "column": 0, "row": 1, "colSpan": 24 }
							}, {
								"name": "DueDate",
								"layout": { "column": 0, "row": 2, "colSpan": 24 }
							}, {
								"name": "RemindToOwnerDate",
								"caption": resources.localizableStrings.DelayRemindBeforeCaption,
								"layout": { "column": 0, "row": 3, "colSpan": 24 }
							}, {
								"name": "Priority",
								"layout": { "column": 0, "row": 4, "colSpan": 24 },
								"contentType": BPMSoft.ContentType.ENUM
							}, {
								"name": "ShowInScheduler",
								"layout": { "column": 0, "row": 5, "colSpan": 24 },
								"wrapClass": ["show-in-scheduler-container"]
							}
						]
					}
				}
			]
		};
	});
