define("PortalSupplyPaymentDetailV2", [],
	function() {
		return {
			entitySchemaName: "SupplyPaymentElement",
			methods: {

				/**
				 * @inheritdoc BPMSoft.BaseGridDetail#getAddTypedRecordButtonVisible
				 */
				getAddTypedRecordButtonVisible: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getCellControlsConfig
				 * @override
				 */
				getCellControlsConfig: function() {
					const controlsConfig = this.callParent(arguments);
					this.Ext.apply(controlsConfig, {
						enabled: false
					});
					return controlsConfig;
				},

				/**
				 * @inheritdoc BPMSoft.SupplyPaymentDetailV2#getModuleInfoResponse
				 * @override
				 */
				getModuleInfoResponse: function() {
					const parentResponse = this.callParent(arguments);
					parentResponse.schemaName = "PortalSupplyPaymentProductDetailModalBox";
					return parentResponse;
				},

				/**
				 * @inheritdoc BPMSoft.SupplyPaymentDetailV2#getModalBoxProductDetailId
				 * @override
				 */
				getModalBoxProductDetailId: function() {
					return this.sandbox.id + "_PortalSupplyPaymentProductDetailModalBox";
				},

				/**
				 * @inheritdoc BPMSoft.SupplyPaymentDetailV2#onClearProductsButtonClick
				 * @override
				 */
				onClearProductsButtonClick: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
				 * @override
				 */
				getDeleteRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @override
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @override
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @override
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn
			},
			diff: [
				{
					"operation": "remove",
					"name": "activeRowActionSave"
				},
				{
					"operation": "remove",
					"name": "activeRowActionOpenCard"
				},
				{
					"operation": "remove",
					"name": "activeRowActionCancel"
				},
				{
					"operation": "remove",
					"name": "activeRowActionRemove"
				}
			]
		};
	}
);
