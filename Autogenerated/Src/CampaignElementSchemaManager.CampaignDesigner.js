define("CampaignElementSchemaManager", ["CampaignBaseAudienceSchema", "ProcessCampaignSequenceFlowSchema",
		"ProcessCampaignConditionalSequenceFlowSchema", "ProcessEmailConditionalTransitionSchema",
		"ProcessLandingConditionalTransitionSchema", "ProcessEventConditionalTransitionSchema", "MarketingEmailSchema",
		"AddCampaignParticipantSchema", "ExitFromCampaignSchema", "CampaignLandingSchema", "CampaignEventSchema",
		"CampaignTimerSchema", "CampaignStartSignalSchema", "CampaignAddObjectSchema", "CampaignUpdateObjectSchema",
		"CampaignStartLandingSchema", "CampaignStartEventSchema", "CampaignAddToEventSchema", "CampaignSplitGatewaySchema",
		"CampaignDeduplicatorSchema", "ProcessSplitGatewayTransitionSchema"],
	function() {
		Ext.define("BPMSoft.manager.CampaignElementSchemaManager", {
			extend: "BPMSoft.BaseProcessFlowElementSchemaManager",
			alternateClassName: "BPMSoft.CampaignElementSchemaManager",
			singleton: true,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaManager#managerName
			 * @protected
			 * @overridden
			 */
			managerName: "CampaignElementSchemaManager",

			/**
			 * Returns if element can be copied.
			 * @param {BPMSoft.ProcessBaseElementSchema} element Element to be copied.
			 * @return {Boolean} Returns true if element can be copied.
			 */
			allowElementCopy: function(element) {
				return !!(element && element.managerItemUId);
			},

			/**
			 * @inheritdoc BPMSoft.BaseProcessFlowElementSchemaManager#initialize
			 * @protected
			 * @overridden
			 */
			initialize: function() {
				this._initCoreElementClassNames();
				this.callParent(arguments);
			},

			/**
			 * Fills coreElementClassNames property
			 * with default Campaign designer element class names.
			 * @private
			 */
			_initCoreElementClassNames: function() {
				this.coreElementClassNames = _.union([
					{ itemType: "BPMSoft.ProcessLaneSetSchema" },
					{ itemType: "BPMSoft.ProcessCampaignSequenceFlowSchema" },
					{ itemType: "BPMSoft.ProcessCampaignConditionalSequenceFlowSchema" },
					{ itemType: "BPMSoft.ProcessEmailConditionalTransitionSchema" },
					{ itemType: "BPMSoft.ProcessEventConditionalTransitionSchema" },
					{ itemType: "BPMSoft.ProcessSplitGatewayTransitionSchema" },
					{ itemType: "BPMSoft.ProcessLandingConditionalTransitionSchema" },
					{ itemType: "BPMSoft.MarketingEmailSchema" },
					{ itemType: "BPMSoft.AddCampaignParticipantSchema" },
					{ itemType: "BPMSoft.CampaignStartSignalSchema" },
					{ itemType: "BPMSoft.CampaignStartEventSchema" },
					{ itemType: "BPMSoft.CampaignStartLandingSchema" },
					{ itemType: "BPMSoft.CampaignAddToEventSchema" },
					{ itemType: "BPMSoft.CampaignEventSchema" },
					{ itemType: "BPMSoft.CampaignAddObjectSchema" },
					{ itemType: "BPMSoft.CampaignUpdateObjectSchema" },
					{ itemType: "BPMSoft.CampaignDeduplicatorSchema" },
					{ itemType: "BPMSoft.CampaignSplitGatewaySchema" },
					{ itemType: "BPMSoft.CampaignLandingSchema" },
					{ itemType: "BPMSoft.CampaignTimerSchema" },
					{ itemType: "BPMSoft.ExitFromCampaignSchema" }
				], this.coreElementClassNames);
			}
		});
	}
);
