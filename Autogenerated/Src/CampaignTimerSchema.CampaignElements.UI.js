 /**
 * Schema of campaign timer element.
 */
define("CampaignTimerSchema", ["CampaignTimerSchemaResources", "CampaignEnums",
		"CampaignBaseElementSchema"],
	function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignTimerSchema
	 * Schema of campaign timer element.
	 */
	Ext.define("BPMSoft.manager.CampaignTimerSchema", {
		extend: "BPMSoft.CampaignBaseElementSchema",
		alternateClassName: "BPMSoft.CampaignTimerSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "9782fbc6-22c0-456c-8b0f-35133afdfc8f",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "CampaignTimer",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#group
		 */
		group: "Intermediates",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#TitleImage
		 */
		titleImage: resources.localizableImages.TitleImage,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#LargeImage
		 */
		largeImage: resources.localizableImages.LargeImage,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#SmallImage
		 */
		smallImage: resources.localizableImages.SmallImage,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: "CampaignTimerPage",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_TIMER,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Configuration.CampaignTimerElement, BPMSoft.Configuration",

		/**
		 * Background fill color.
		 * @protected
		 * @type {String}
		 */

		color: "rgba(246, 145, 0, 1)",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
		 * @overridden
		 */
		width: 55,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
		 * @overridden
		 */
		height: 55,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#nodeType
		 * @overridden
		 */
		nodeType: BPMSoft.diagram.UserHandlesConstraint.Event,

		/**
		 * Timer expression type property.
		 * @protected
		 * @type {number}
		 */
		expressionType: BPMSoft.TimerExpressionTypes.Empty,

		/**
		 * Cron expression property.
		 * @protected
		 * @type {string}
		 */
		cronExpression: null,

		/**
		 * Sign for use custom time zone.
		 * @protected
		 * @type {Boolean}
		 */
		useCustomTimeZone: false,

		/**
		 * Time zone offset property.
		 * @protected
		 * @type {TimeZoneInfo}
		 */
		timeZoneOffset: null,

		/**
		 * Sign for use exact time and not period.
		 * @protected
		 * @type {Boolean}
		 */
		useExactTime: false,

		/**
		 * Exact time property.
		 * @protected
		 * @type {Time}
		 */
		exactTime: null,

		/**
		 * Period start time property.
		 * @protected
		 * @type {Time}
		 */
		periodStartTime: null,

		/**
		 * Period end time property.
		 * @protected
		 * @type {Time}
		 */
		periodEndTime: null,

		/**
		 * Validity start time property.
		 * @protected
		 * @type {DateTime}
		 */
		startDateTime: null,

		/**
		 * Sign for use start date time.
		 * @protected
		 * @type {Boolean}
		 */
		useStartDateTime: false,

		/**
		 * Validity end time property.
		 * @protected
		 * @type {DateTime}
		 */
		endDateTime: null,

		/**
		 * Sign for use end date time.
		 * @protected
		 * @type {Boolean}
		 */
		useEndDateTime: false,

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			if (!BPMSoft.CampaignElementGroups.Items.contains("Intermediates")) {
				BPMSoft.CampaignElementGroups.Items.add("Intermediates", {
					name: "Intermediates",
					caption: resources.localizableStrings.IntermediatesGroupCaption
				});
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.mixins.CampaignElementMixin#getElementSpecificPropertiesNames
		 * @overridden
		 */
		getElementSpecificPropertiesNames: function() {
			return  ["useExactTime", "exactTime", "periodStartTime", "periodEndTime", "timeZoneOffset",
				"useCustomTimeZone", "expressionType", "cronExpression"];
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["useExactTime", "exactTime", "periodStartTime",
				"periodEndTime", "useStartDateTime", "startDateTime", "useEndDateTime", "endDateTime",
				"timeZoneOffset", "useCustomTimeZone", "expressionType", "cronExpression"]);
		}
	});
	return BPMSoft.CampaignTimerSchema;
});
