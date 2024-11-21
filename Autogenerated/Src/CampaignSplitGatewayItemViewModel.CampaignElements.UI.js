/**
 * View model for campaign split gateway outgoing flow collection item.
 */
define("CampaignSplitGatewayItemViewModel", ["CampaignSplitGatewayItemViewModelResources", "ImageView"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.CampaignSplitGatewayItemViewModel
		 */
		Ext.define("BPMSoft.configuration.CampaignSplitGatewayItemViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.CampaignSplitGatewayItemViewModel",
			parentViewModel: null,
			columns: {
				/**
				 * Distribution value for current flow.
				 * @type {Number}
				 */
				Value: {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.INTEGER
				}
			},

			/**
			 * @private
			 */
			_getInputMarkerValue: function() {
				return Ext.String.format("split-gateway-value-{0}", this.$ElementCaption);
			},

			/**
			 * @private
			 */
			_highlightFlow: function(state) {
				if (this.parentViewModel && this.parentViewModel.highlightFlow) {
					this.parentViewModel.highlightFlow(this.$Id, state);
				}
			},

			/**
			 * Returns current item view config to render.
			 * @public
			 * @returns {Object}
			 */
			getViewConfig: function() {
				return {
					className: "BPMSoft.Container",
					classes: { wrapClassName: ["split-flow-item"] },
					items: [
						{
							className: "BPMSoft.Container",
							classes: { wrapClassName: ["distribution-value-container"] },
							items: [
								{
									className: "BPMSoft.IntegerEdit",
									value: "$Value",
									enabled: "$CanChangeValue",
									blur: "$onBlur",
									focus: "$onFocus",
									markerValue: "$_getInputMarkerValue",
									enterkeypressed: "$onFlowValueChanged",
									classes: {wrapClass: "percent-input"}
								},
								{
									className: "BPMSoft.Label",
									caption: "%",
									classes: { labelClass: ["percent-label"]}
								},
								{
									className: "BPMSoft.Container",
									classes: {wrapClassName: ["element-info-container"]},
									items: [
										{
											className: "BPMSoft.ImageView",
											imageSrc: "$ElementIcon",
											classes: { wrapClass: ["element-icon"]}
										},
										{
											className: "BPMSoft.Label",
											caption: "$ElementCaption",
											classes: { labelClass: ["element-caption"]}
										}
									]
								}
							]
						}
					]
				};
			},

			/**
			 * Handles distribution changed event triggered by user.
			 * @protected
			 */
			onFlowValueChanged: function() {
				if (this.$Value > 100) {
					this.$Value = 100;
				}
				if (this.$Value < 1) {
					this.$Value = 1;
				}
				if (this.parentViewModel && this.parentViewModel.onFlowValueChanged) {
					var count = this.parentViewModel.$Flows.getCount();
					var maxValue = 100 - count + 1;
					if (this.$Value > maxValue) {
						this.$Value = maxValue;
					}
					this.parentViewModel.onFlowValueChanged({
						value: this.$Value,
						id: this.$Id,
						transitionId: this.$TransitionId
					});
				}
			},

			/**
			 * Handler on input focus event.
			 */
			onFocus: function() {
				this._highlightFlow(true);
			},

			/**
			 * Handler on input blur event.
			 */
			onBlur: function() {
				this.onFlowValueChanged();
				this._highlightFlow(false);
			}
		});
	}
);
