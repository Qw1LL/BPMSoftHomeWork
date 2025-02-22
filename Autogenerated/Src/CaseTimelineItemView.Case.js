﻿define("CaseTimelineItemView", ["BaseTimelineItemView", "ImageCustomGeneratorV2", "css!CaseTimelineItemView"],
	function() {
	/**
	 * @class BPMSoft.configuration.CaseTimelineItemView
	 * Case timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.CaseTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.CaseTimelineItemView",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#bodyVisibilityHeight
		 * @override
		 */
		bodyVisibilityHeight: 94,

		// endregion

		// region Methods: Protected

		/**
		 * Returns text with label and icon container view config.
		 * @protected
		 * @param {Object} itemConfig Item config.
		 * @param {String} itemConfig.labelBinding Label text.
		 * @param {String} itemConfig.textBinding Text binding function or column.
		 * @return {Object} Text with label and icon container view config.
		 */
		getTextWithLabelAndIconContainerViewConfig: function(itemConfig) {
			var containerId = BPMSoft.generateGUID();
			var config = {
				"name": "TextWithLabelContainer" + containerId,
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-text-with-label-container"]
				},
				"items": [
					this.getSimpleLabelViewConfig(itemConfig.labelBinding, "timeline-text-light"),
					this.getTextWithIconContainerConfig(itemConfig.textBinding)
				]
			};
			return config;
		},

		/**
		 * Returns text container view config.
		 * @protected
		 * @param {String} caption Caption config.
		 * @return {Object} Text container view config.
		 */
		getTextWithIconContainerConfig: function(caption) {
			return {
				"name": "TextContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-text-with-icon-container"]
				},
				"items": [
					this.getPriorityIconConfig(),
					this.getSimpleLabelViewConfig(caption, "timeline-text-normal")
				]
			};
		},

		/**
		 * Returns priority icon view config.
		 * @protected
		 * @return {Object} Priority icon view config.
		 */
		getPriorityIconConfig: function() {
			return {
				"name": "PriorityIcon",
				"itemType": BPMSoft.ViewItemType.IMAGE,
				"getSrcMethod": "getPriorityIconUrl",
				"visible": {
					"bindTo": "Priority",
					"bindConfig": {
						"converter": "isPriorityIconVisible"
					}
				},
				"readonly": true,
				"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
				"classes": {
					"wrapClass": ["timeline-item-priority-icon"]
				}
			};
		},

		/**
		 * Returns case info view config.
		 * @protected
		 * @return {Object} Case info view config.
		 */
		getCaseInfoContainerViewConfig: function() {
			var itemConfig = {
				labelBinding: "Resources.Strings.PriorityLabel",
				textBinding: "Priority"
			};
			return {
				"name": "CaseInfoContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"visible": {
					"bindTo": "IsExpanded"
				},
				"classes": {
					"wrapClassName": ["timeline-tile-info-container"]
				},
				"items": [
					this.getTextWithLabelAndIconContainerViewConfig(itemConfig),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.AuthorLabel", "Owner"),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.StatusLabel", "Status")
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			bodyConfig.items = [
				this.getCaseInfoContainerViewConfig(),
				this.getTextWithLabelContainerViewConfig("Resources.Strings.DescriptionLabel", "Description",
					{"cssWrapClass": "timeline-case-description-container"})
			];
			return bodyConfig;
		}

		// endregion

	});
});
