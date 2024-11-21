define("ProcessLogDetail", ["ProcessLogDetailResources", "ProcessLogActions", "BaseSectionGridRowViewModel"],
	function(resources) {
	return {
		mixins: {
			ProcessLogActions: "BPMSoft.ProcessLogActions"
		},
		methods: {
			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @protected
			 * @overridden
			 */
			getSwitchGridModeMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#getGridRowViewModelClassName
			 * @overriden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.BaseSectionGridRowViewModel";
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollection
			 * @overriden
			 */
			prepareResponseCollection: function(collection) {
				this.mixins.GridUtilities.prepareResponseCollection.call(this, collection);
				this.initCancelExecution(collection);
			},

			/**
			 * @inheritdoc GridUtilitiesV2#onActiveRowAction
			 * @overridden
			 */
			onActiveRowAction: function(tag, primaryColumnValue) {
				switch (tag) {
					case "openProperties":
						this.editRecord();
						break;
					case "showProcessDiagram":
						this.showProcessDiagram(primaryColumnValue);
						break;
					case "cancelExecution":
						this.cancelExecutionConfirmation();
						break;
					default:
						break;
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.mixins.ProcessLogActions.init.call(this, callback, scope);
				}, this]);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"getEmptyMessageConfig": {"bindTo": "getEmptyMessageConfig"},
					"activeRowActions": [
						{
							"className": "BPMSoft.Button",
							"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
							"caption": resources.localizableStrings.OpenPropertiesPageButtonCaption,
							"tag": "openProperties"
						},
						{
							"className": "BPMSoft.Button",
							"caption": resources.localizableStrings.ProcessDiagramButtonCaption,
							"tag": "showProcessDiagram"
						},
						{
							"className": "BPMSoft.Button",
							"caption": resources.localizableStrings.CancelExecutionButtonCaption,
							"tag": "cancelExecution",
							"visible": {
								"bindTo": "canCancelProcessExecution"
							}
						}

					],
					"listedZebra": true,
					"activeRowAction": { bindTo: "onActiveRowAction" }
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
