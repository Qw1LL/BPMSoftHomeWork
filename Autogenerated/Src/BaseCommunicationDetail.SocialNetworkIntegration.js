define("BaseCommunicationDetail", ["CommunicationUtils", "SocialSearch"], function(CommunicationUtils) {
	return {
		attributes: {
			SocialSearchModuleId: {dataValueType: BPMSoft.DataValueType.TEXT}

		},
		messages: {
			/**
			 * @message
			 * ########## ######### ### ######### ########## # ######## ### ######.
			 */
			"GetDetailInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message
			 * ########## ######### ######### ######### ####### ########.
			 */
			"PushHistoryState": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message SearchResultBySocialNetworks
			 * ######## ######### ###### ## ########## #####.
			 */
			"SearchResultBySocialNetworks": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				this.sandbox.subscribe("SearchResultBySocialNetworks", this.onSearchResultBySocialNetworks, this);
			},

			/**
			 * ############ ######### ###### ####### ###### # ########## ####.
			 * @private
			 * @param {Object} searchResult ######### ###### ####### ###### # ########## ####.
			 * @param {BPMSoft.Collection} searchResult.selectedItems ######### ######### ####### ## ######## ######.
			 */
			onSearchResultBySocialNetworks: function(searchResult) {
				var collection = searchResult.selectedItems;
				collection.each(function(item) {
					var newItem = this.addItem(item.get("CommunicationType"));
					newItem.set("Number", item.get("Name"));
					newItem.set("SocialMediaId", item.get("Id"));
				}, this);
			},

			/**
			 * ########## ############### ## #### ######## ##### ######### ###### ######.
			 * @protected
			 * @param {String} communicationTypeFilter ### ######## #####.
			 * @return {BPMSoft.Collection} ############### ## #### ######## ##### ######### ###### ######.
			 */
			getCommunications: function(communicationTypeFilter) {
				var collection = this.get("Collection");
				var filteredCollection = collection.filterByFn(function(communication) {
					var communicationType = communication.get("CommunicationType");
					if (!communicationType) {
						return false;
					}
					return (communicationType.value === communicationTypeFilter);
				});
				return filteredCollection;
			},

			/**
			 * ######### ###### ###### # ########## #####.
			 * @protected
			 * @param {Object} config ######### ######## ######.
			 * @param {String} config.schemaName ######## #####, ####### ##### ############## #######.
			 */
			loadSocialSearchModule: function(config) {
				var moduleId = this.sandbox.id + "_SocialSearch";
				var detailInfo = this.getDetailInfo();
				var moduleConfig = {
					moduleId: moduleId,
					moduleName: "SocialSearch",
					stateObj: {},
					instanceConfig: {
						isSchemaConfigInitialized: true,
						schemaName: config.schemaName,
						searchQuery: detailInfo.masterRecordDisplayValue
					}
				};
				this.sandbox.publish("OpenCard", moduleConfig, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseCommunicationDetail#addMenuItem
			 * @overridden
			 */
			addMenuItem: function(typeMenuItems, communicationType) {
				var value = communicationType.get("Id");
				if (CommunicationUtils.isSocialNetworkType(value)) {
					return;
				}
				this.callParent(arguments);
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "SocialNetworksContainer",
				"parentName": "Detail",
				"propertyName": "tools",
				"values": {
					"visible": {"bindTo": "getToolsVisible"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["social-networks-container"],
					"items": []
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
