define("CampaignDroppableContainer", function() {

	/**
	 * @class BPMSoft.configuration.CampaignDroppableContainer
	 * ##### ######## ########## ########## # ####### ##### #############.
	 */
	var droppableContainer = Ext.define("BPMSoft.controls.CampaignDroppableContainer", {
		alternateClassName: "BPMSoft.CampaignDroppableContainer",
		extend: "BPMSoft.Container",

		mixins: {
			droppable: "BPMSoft.Droppable"
		},

		/**
		 * @inheritdoc BPMSoft.component#onAfterRender
		 * @overridden
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			this.mixins.droppable.onAfterRender.apply(this, arguments);
		},

		/**
		 * @inheritdoc BPMSoft.component#onAfterReRender
		 * @overridden
		 */
		onAfterReRender: function() {
			this.callParent(arguments);
			this.mixins.droppable.onAfterReRender.apply(this, arguments);
		},

		/**
		 * @inheritdoc BPMSoft.component#onDestroy
		 * @overridden
		 */
		onDestroy: function() {
			this.mixins.droppable.onDestroy.apply(this, arguments);
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.Droppable#getGroupName
		 * @overridden
		 */
		getGroupName: function() {
			return "CampaignDroppableContainer";
		}
	});

	return droppableContainer;
});
