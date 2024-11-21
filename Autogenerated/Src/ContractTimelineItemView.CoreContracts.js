define("ContractTimelineItemView", ["BaseTimelineItemView"],
	function() {
		/**
		 * @class BPMSoft.configuration.ContractTimelineItemView
		 * Contract timeline item view class.
		 */
		Ext.define("BPMSoft.configuration.ContractTimelineItemView", {
			alternateClassName: "BPMSoft.ContractTimelineItemView",
			extend: "BPMSoft.BaseTimelineItemView",

			// region Methods: Protected

			/**
			 * Returns Contract info view config.
			 * @protected
			 * @return {Object} Contract info view config.
			 */
			getContractInfoContainerViewConfig: function() {
				var dateFieldConfig = {
					"textValueConverter": "getFormattedShortDate"
				};
				return {
					"name": "ContractInfoContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["timeline-tile-info-container"]
					},
					"items": [
						this.getTextWithLabelContainerViewConfig("Resources.Strings.TypeLabel", "Type"),
						this.getTextWithLabelContainerViewConfig("Resources.Strings.EndDateLabel", "EndDate", dateFieldConfig),
						this.getTextWithLabelContainerViewConfig("Resources.Strings.StateLabel", "State")
					]
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
			 * @override
			 */
			getBodyViewConfig: function() {
				var bodyConfig = this.callParent(arguments);
				bodyConfig.items = [this.getContractInfoContainerViewConfig()];
				return bodyConfig;
			}

			// endregion

		});
	});
