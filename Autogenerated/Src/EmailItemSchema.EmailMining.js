define("EmailItemSchema", ["EmailConstants", "EmailEnrichmentMixin", "EmailMiningEnums", "EmailHelper",
		"css!EmailItemSchemaCSS"], function(EmailConstants) {
			return {
				entitySchemaName: EmailConstants.entitySchemaName,

				messages: {

					/**
					 * Update contact enrichment page visibility.
					 */
					"ContactEnrichmentPageVisibilityChanged": {
						"mode": BPMSoft.MessageMode.PTP,
						"direction": BPMSoft.MessageDirectionType.PUBLISH
					}
				},

				attributes: {

					/**
					 * Source item for web analytics.
					 * @protected
					 * @type {String}
					 */
					"CallerSource": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"value": "EmailPanel"
					}
				},
				mixins: {

					/**
					 * @class BPMSoft.EmailEnrichmentMixin
					 * Email enrichment mixin.
					 */
					EmailEnrichmentMixin: "BPMSoft.EmailEnrichmentMixin"
				},
				methods: {

					/**
					 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
					 * @overridden
					 */
					init: function(callback, scope) {
						this.callParent([function() {
							if (!this.getCanLoadEnrichActions()) {
								this.Ext.callback(callback, scope);
								return;
							}
							this.getContactsFromServer(function(response) {
								this.addEnrichContactsToActionMenu(response, callback, scope);
							}, this);
						}, this]);
					},

					/**
					 * Adds to action menu contacts for enrichment.
					 * @protected
					 * @param {Object} response Enrichment service response object config.
					 * @param {Object[]} response.CloudStateResponse.data Contacts array for enrichment.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					addEnrichContactsToActionMenu: function(response, callback, scope) {
						var result = response && response.CloudStateResponse;
						var data = result.data;
						if (!data || data.length === 0) {
							return this.Ext.callback(callback,scope);
						}
						var enrichmentMenuItems = this.$ActionsMenuCollection;
						var isEnrichMenuFilled = enrichmentMenuItems.any(function(item) {
							try {
								var tag = item.$Tag;
								var itemContact = Ext.decode(tag);
								var enrichmentContact = data[0];
								return itemContact && itemContact.enrchTextDataId === enrichmentContact.EnrchTextDataId;
							} catch (e) {
								return false;
							}
						});
						if (isEnrichMenuFilled) {
							return this.Ext.callback(callback,scope);
						}
						this.set("Response", result);
						this.initEnrichmentCollection();
						this.Ext.callback(callback,scope);
					},

					/**
					 * Creates contact enrichment window additional config.
					 * @protected
					 * @return {Object} Contact enrichment window additional config.
					 */
					getAdditionalWindowConfig: function() {
						var enrchEmailDataId = this.get("EnrchEmailData");
						var config = {
							enrchEmailDataId: (enrchEmailDataId && enrchEmailDataId.value)
						};
						return config;
					},

					/**
					 * Returns true if enrich contact actions can be loaded from server, false otherwise.
					 * @protected
					 * @virtual
					 * @return {Boolean} Can load enrich contact actions from server.
					 */
					getCanLoadEnrichActions: function() {
						var status = this.get("EnrchEmailData.Status");
						var enrchEmailData = this.get("EnrchEmailData");
						var reloadActions = this.get("ReloadActions");
						this.set("ReloadActions", false);
						var statusEnum = this.BPMSoft.EmailMiningEnums.EnrichEmailDataStatus;
						return reloadActions || (enrchEmailData && status !== statusEnum.ENRICHED);
					},

					/**
					 * @inheritdoc BPMSoft.EmailItemSchema#setColumnValues
					 * @overridden
					 */
					setColumnValues: function(entity) {
						this.callParent(arguments);
						this.set("EnrchEmailData", entity.get("EnrchEmailData"));
						this.set("EnrchEmailData.Status", entity.get("EnrchEmailData.Status"));
					},

					/**
					 * Returns actions button icon.
					 * @param {Boolean} isCloudVisible Is cloud icon visible.
					 * @return {Object} actions button icon.
					 */
					getActionsImage: function(isCloudVisible) {
						return isCloudVisible
							? this.get("Resources.Images.ContactEnrichmentIcon")
							: this.get("Resources.Images.ActionsButtonImage");
					},

					/**
					 * Returns message header marker value.
					 * @param {Boolean} isCloudVisible Is cloud icon visible.
					 * @return {String} message header marker value.
					 */
					getHeaderMarker: function(isCloudVisible) {
						return isCloudVisible ? "ShowCloud EmailEnrichmentIcon" : "HideCloud";
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "EmailHeader",
						"values": {
							"markerValue": {
								"bindTo": "isCloudVisible",
								"bindConfig": {
									"converter": "getHeaderMarker"
								}
							}
						}
					},
					{
						"operation": "merge",
						"name": "ActionsButton",
						"values": {
							"imageConfig": {
								"bindTo": "isCloudVisible",
								"bindConfig": {
									"converter": "getActionsImage"
								}
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});

