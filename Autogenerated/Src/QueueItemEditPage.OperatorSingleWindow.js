define("QueueItemEditPage", ["BPMSoft", "css!QueueItemEditPageCSS"], function(BPMSoft) {
	return {
		messages: {
			/**
			 * @message QueueItemPostponed
			 * ########### ##### ######### ######## ########## ## ######### ######## #######.
			 */
			"QueueItemPostponed": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message CloseQueueItemEdit
			 * ########### ### ######## ######## ###### ######## #######.
			 */
			"CloseQueueItemEdit": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {},
		attributes: {
			"Id": {
				"isRequired": false
			},
			"NextProcessingDate": {
				"isRequired": true
			}
		},
		methods: {

			updateQueueItemData: function(callback) {
				var primaryColumnValue = this.get("PrimaryColumnValue");
				var updateQuery = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: this.entitySchemaName
				});
				updateQuery.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, this.primaryColumnName, primaryColumnValue));
				updateQuery.setParameterValue("NextProcessingDate", this.get("NextProcessingDate"),
					this.BPMSoft.DataValueType.DATE_TIME);
				updateQuery.execute(callback);
			},

			init: function(callback, scope) {
				this.callParent([function() {
					var primaryColumnValue = this.get("PrimaryColumnValue");
					this.loadEntity(primaryColumnValue, callback.bind(scope || this));
				}, this]);
			},

			onRender: function() {
				this.callParent(arguments);
				this.hideBodyMask();
			},

			onSaveButtonClick: function() {
				if (this.validate()) {
					this.updateQueueItemData(function() {
						var sandbox = this.sandbox;
						//sandbox.publish("BackHistoryState");
						sandbox.publish("QueueItemPostponed");
					}.bind(this));
				}
			},

			onCancelButtonClick: function() {
				this.sandbox.publish("CloseQueueItemEdit", null, [this.sandbox.id]);
			}
		},
		diff:  /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "QueueItemDataContainer",
				"propertyName": "items",
				"values": {
					"id": "QueueItemDataContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"selectors": {
						"wrapEl": "#QueueItemDataContainer"
					},
					"classes": {
						"wrapClassName": ["QueueItemDataContainer"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NextProcessingDate",
				"parentName": "QueueItemDataContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "NextProcessingDate",
					"layout": {"column": 0, "row": 1, "colSpan": 24}
				}
			},
			{
				"operation": "insert",
				"name": "QueueItemButtonsContainer",
				"propertyName": "items",
				"values": {
					"id": "QueueItemDataButtons",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"selectors": {
						"wrapEl": "#QueueItemDataButtons"
					},
					"classes": {
						"wrapClassName": ["queue-item-edit-buttons"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "QueueItemButtonsContainer",
				"propertyName": "items",
				"name": "SaveButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"click": {"bindTo": "onSaveButtonClick"},
					"visible": true
				}
			},
			{
				"operation": "insert",
				"parentName": "QueueItemButtonsContainer",
				"propertyName": "items",
				"name": "CancelButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"click": {"bindTo": "onCancelButtonClick"},
					"visible": true
				}
			}
		]
	}
});
