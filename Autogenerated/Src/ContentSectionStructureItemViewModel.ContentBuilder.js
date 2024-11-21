/**
 * View model for content structure item in container list. E.g. column, group.
 */
define("ContentSectionStructureItemViewModel", ["ContentSectionStructureItemViewModelResources",
		"BaseContentStructureItemViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.ContentSectionStructureItemViewModel
		 */
		Ext.define("BPMSoft.configuration.ContentSectionStructureItemViewModel", {
			extend: "BPMSoft.BaseContentStructureItemViewModel",
			alternateClassName: "BPMSoft.ContentSectionStructureItemViewModel",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePrefix
			 * @override
			 */
			markerValuePrefix: "column-item",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#markerValuePostfix
			 * @override
			 */
			markerValuePostfix: "column-item-container",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#itemType
			 * @override
			 */
			itemType: "column",
			/**
			 * @inheritdoc BaseContentStructureItemViewModel#wrapClassNames
			 * @override
			 */
			wrapClassNames: {
				container: "section-column-item-container",
				item: "section-column-item",
				caption: "section-column-caption",
				width: "section-column-width",
				widthContainer: "section-column-width-container"
			},
			columns: {
				"MinWidth": {
					dataValueType: BPMSoft.DataValueType.FLOAT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: 5
				},
				"Width": {
					dataValueType: BPMSoft.DataValueType.FLOAT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"CanChangeWidth": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},

			/**
			 * Returns marker value for the input control of the column width.
			 * @private
			 */
			_getWidthInputMarkerValue: function() {
				return "width-" + this.getLabelMarkerValue();
			},

			/**
			 * @private
			 */
			_getWidthControlConfig: function() {
				return {
					id: "column-width-container",
					className: "BPMSoft.Container",
					classes: { wrapClassName: [this.wrapClassNames.widthContainer] },
					items: [
						{
							className: "BPMSoft.IntegerEdit",
							value: "$Width",
							enabled: "$CanChangeWidth",
							blur: "$onColumnWidthChanged",
							enterkeypressed: "$onColumnWidthChanged",
							markerValue: "$_getWidthInputMarkerValue"
						},
						{
							className: "BPMSoft.Label",
							caption: "%",
							enabled: "$CanChangeWidth"
						}
					]
				};
			},

			/**
			 * Handles width changed event triggered by user.
			 * @protected
			 */
			onColumnWidthChanged: function() {
				if (this.parentViewModel.$IsInUpdateMode) {
					return;
				}
				this.parentViewModel.fireEvent("columnwidthchanged", this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#setCaption
			 * @override
			 */
			setCaption: function(index) {
				var title = resources.localizableStrings.BaseStructureItemTitle;
				this.callParent([index, title]);
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#getBaseStructureItemViewConfig
			 * @override
			 */
			getBaseStructureItemViewConfig: function() {
				var itemViewConfig = this.callParent(arguments);
				var widthControlConfig = this._getWidthControlConfig();
				itemViewConfig.items.push(widthControlConfig);
				return itemViewConfig;
			},

			/**
			 * @inheritDoc BaseContentStructureItemViewModel#getStructureItemConfig
			 * @override
			 */
			getStructureItemConfig: function () {
				var config = this.callParent(arguments);
				config.Width = this.$Width;
				config.RelativeWidth = this.$RelativeWidth;
				return config;
			}

			// #endregion

		});
	}
);
