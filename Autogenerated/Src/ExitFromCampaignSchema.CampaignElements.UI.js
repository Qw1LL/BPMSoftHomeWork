define("ExitFromCampaignSchema", ["ExitFromCampaignSchemaResources",
		"CampaignEnums", "CampaignBaseAudienceSchema"],
	function(resources, CampaignEnums) {
		/**
		 * @class BPMSoft.manager.ExitFromCampaignSchema
		 * Schema of base audience element.
		 */
		Ext.define("BPMSoft.manager.ExitFromCampaignSchema", {
			extend: "BPMSoft.CampaignBaseAudienceSchema",
			alternateClassName: "BPMSoft.ExitFromCampaignSchema",

			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin"
			},

			/**
			 * UId of current manager item.
			 */
			managerItemUId: "b2700fee-9034-4bdf-88a9-fb3ddff92f4f",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#name
			 */
			name: "ExitFromCampaign",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#caption
			 */
			caption: resources.localizableStrings.Caption,

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
			editPageSchemaName: "ExitFromCampaignPage",

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
			 * @override
			 */
			typeName: "BPMSoft.Configuration.ExitFromCampaignElement, BPMSoft.Configuration",

			/**
			 * Type of element
			 * @type {string}
			 */
			elementType: CampaignEnums.CampaignSchemaElementTypes.EXIT_AUDIENCE,

			/**
			 * Background fill color.
			 * @protected
			 * @type {String}
			 */
			color: "rgba(253, 112, 67, 1)",

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
			 * @override
			 */
			width: 55,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
			 * @override
			 */
			height: 55,

			/**
			 * FolderId from which participants should be added into campaign.
			 */
			folderId: null,

			/**
			 * Search data string to filter audience to exclude.
			 * @type {String}
			 */
			filter: null,

			/**
			 * Flag to indicate that audience exclude is provided by filter.
			 * @type {Boolean}
			 */
			hasFilter: false,

			/**
			 * Flag to indicate that element is campaign goal or not.
			 */
			isCampaignGoal: false,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#outgoingConnectionsLimit
			 * @override
			 */
			outgoingConnectionsLimit: 0,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessFlowElementSchema#getConnectionUserHandles
			 * @override
			 */
			getConnectionUserHandles: function() {
				return [];
			},

			/**
			 * @inheritdoc BPMSoft.CampaignBaseElementSchema#getElementMarkers
			 * @override
			 */
			getElementMarkers: function() {
				var markers = {};
				if (this.isCampaignGoal) {
					markers.goal = { name: "Goal" };
				}
				if (!this.hasFilter && !Ext.isEmpty(this.folderId)) {
					markers.folder = { name: "ExitFolder" };
				}
				if (this.hasFilter  && !Ext.isEmpty(this.filter)) {
					markers.filter = { name: "ExitFilter" };
				}
				return markers;
			},

			/**
			 * @inheritDoc BPMSoft.CampaignBaseElementSchema#initTitleImage
			 * @override
			 */
			initTitleImage: function() {
				if (this.isCampaignGoal && !Ext.isEmpty(this.folderId) && !this.hasFilter) {
					this.titleImage = resources.localizableImages.TitleIsGoalWithFolderImage;
				} else if (this.isCampaignGoal) {
					this.titleImage = this.hasFilter
						? resources.localizableImages.TitleIsGoalWithFilterImage
						: resources.localizableImages.TitleIsGoalImage;
				} else if (!Ext.isEmpty(this.folderId) && !this.hasFilter) {
					this.titleImage = resources.localizableImages.TitleWithFolderImage;
				} else {
					this.titleImage = this.hasFilter
						? resources.localizableImages.TitleWithFilterImage
						: resources.localizableImages.TitleImage;
				}
			},

			/**
			 * @inheritDoc BPMSoft.CampaignBaseElementSchema#initLargeImage
			 * @override
			 */
			initLargeImage: function() {
				if (this.isCampaignGoal && !Ext.isEmpty(this.folderId) && !this.hasFilter) {
					this.largeImage = resources.localizableImages.LargeIsGoalWithFolderImage;
				} else if (this.isCampaignGoal) {
					this.largeImage = this.hasFilter
						? resources.localizableImages.LargeIsGoalWithFilterImage
						: resources.localizableImages.LargeIsGoalImage;
				} else if (!Ext.isEmpty(this.folderId) && !this.hasFilter) {
					this.largeImage = resources.localizableImages.LargeWithFolderImage;
				} else {
					this.largeImage = this.hasFilter
						? resources.localizableImages.LargeWithFilterImage
						: resources.localizableImages.LargeImage;
				}
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @override
			 */
			getSerializableProperties: function() {
				var baseSerializableProperties = this.callParent(arguments);
				return Ext.Array.push(baseSerializableProperties, ["folderId", "isCampaignGoal",
					"filter", "hasFilter"]);
			}
		});
		return BPMSoft.ExitFromCampaignSchema;
	});
