define("AccountCommunicationDetail", ["AccountCommunicationDetailResources", "BPMSoft", "Contact",
		"ConfigurationEnums", "ConfigurationConstants"], function(resources, BPMSoft, Contact, ConfigurationEnums,
		ConfigurationConstants) {
	return {

		/**
		 * ### ########
		 */
		entitySchemaName: "AccountCommunication",
		messages: {
			/**
			 * @message ReloadCard
			 * Notify about the card is reload.
			 */
			"ReloadCard": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {
			/**
			 * ####### ######## ##### LinkedIn ## ####### ####
			 * @param {Object} esq ###### ####### #####
			 */
			initCommunicationTypesFilters: function(esq) {
				this.callParent(arguments);
				if (Contact.columns.LinkedIn && Contact.columns.LinkedIn.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.None) {
					var linkedInFilter = BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.NOT_EQUAL, "Id", ConfigurationConstants.CommunicationTypes.LinkedIn);
					esq.filters.addItem(linkedInFilter);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#onSaved
			 * @overridden
			 */
			onSaved: function() {
				this.callParent(arguments);
				this.sandbox.publish("ReloadCard", null, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#initMasterDetailColumnMapping
			 * @overridden
			 */
			initMasterDetailColumnMapping: function() {
				this.set("MasterDetailColumnMapping",[
					{
						"CommunicationType": ConfigurationConstants.CommunicationTypes.MainPhone,
						"MasterEntityColumn": "Phone"
					},
					{
						"CommunicationType": ConfigurationConstants.CommunicationTypes.AdditionalPhone,
						"MasterEntityColumn": "AdditionalPhone"
					},
					{
						"CommunicationType": ConfigurationConstants.CommunicationTypes.Fax,
						"MasterEntityColumn": "Fax"
					},
					{
						"CommunicationType": ConfigurationConstants.CommunicationTypes.Web,
						"MasterEntityColumn": "Web"
					},
					{
						"CommunicationType": ConfigurationConstants.CommunicationTypes.Email,
						"MasterEntityColumn": "Email"
					},
				]);
			}
		}
	};
});
