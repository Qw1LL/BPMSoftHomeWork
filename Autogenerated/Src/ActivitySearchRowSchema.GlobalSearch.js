define("ActivitySearchRowSchema", ["ProcessModuleUtilities"], function(ProcessModuleUtilities) {
	return {

		messages: {
			/**
			 * @message ProcessExecDataChanged
			 * Specifies that you have to transfer the data of a process.
			 */
			"ProcessExecDataChanged": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		methods: {

			/**
			 * @override
			 * @inheritdoc BPMSoft.BaseSearchRowSchemaViewModel#onPrimaryColumnLinkClick
			 */
			onPrimaryColumnLinkClick: function() {
				var parentMethod = this.getParentMethod();
				var parentMethodArguments = arguments;
				this.loadActivity(function() {
					var processElementId = this.get("ProcessElementId");
					var config = {
						procElUId: processElementId,
						recordId: this.get("Id"),
						scope: this,
						parentMethodArguments: parentMethodArguments,
						parentMethod: parentMethod
					};
					if (!ProcessModuleUtilities.tryShowProcessCard.call(this, config)) {
						parentMethod.apply(this, parentMethodArguments);
					}
				}, this);
				return false;
			},

			/**
			 * Loads activity by activity id.
			 * @private
			 * @param {Function} callback Callback function.
			 */
			loadActivity: function(callback) {
				var esq = this.getActivityEsq();
				esq.getEntity(this.get("Id"), function(response) {
					var activity = response && response.entity;
					var processElementId = activity && activity.get("ProcessElementId");
					this.set("ProcessElementId", processElementId);
					this.Ext.callback(callback, this);
				}, this);
			},

			/**
			 * Gets activity entity schema query with columns.
			 * @private
			 * @return {BPMSoft.EntitySchemaQuery} Entity schema query.
			 */
			getActivityEsq: function() {
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Activity"});
				esq.addColumn("ProcessElementId");
				return esq;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "EntitySchemaCaption"
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Account",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "ActivityCategory",
				"values": {
					"layout": {
						"column": 18,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Owner",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "DueDate",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Status",
				"values": {
					"layout": {
						"column": 18,
						"row": 1,
						"colSpan": 6
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
