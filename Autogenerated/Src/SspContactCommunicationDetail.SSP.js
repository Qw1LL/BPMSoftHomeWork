define("SspContactCommunicationDetail", [], function() {
		return {
			entitySchemaName: "ContactCommunication",
			messages: {},
			attributes: {},
			methods: {

				/**
				* @inheritdoc BPMSoft.BaseCommunicationDetail#getToolsMenuItems
				* @override
				*/
				getToolsMenuItems: function() {
					let communicationTypes = this.$CommunicationTypes;
					communicationTypes = communicationTypes.filterByFn(function(item) { 
						return item.$Name !== "Facebook";
					}, this);
					this.$CommunicationTypes =  communicationTypes.filterByFn(function(item) { 
						return item.$Name !== "Twitter";
					}, this);
					return this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "FacebookButton",
					"parentName": "SocialNetworksContainer",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "TwitterButton",
					"parentName": "SocialNetworksContainer",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/
		};
	});