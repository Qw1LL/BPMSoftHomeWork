 define("PortalLeadPageV2",["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Lead",
			attributes: {
				"OpportunityOrOrder": {
					"caption": {"bindTo": "Resources.Strings.OpportunityOrOrderCaption"},
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"multiLookupColumns": ["Opportunity", "Order"]
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					if (this.isNewMode()) {
						this.setSalesChannelInNewMode();
						const valuesInNewMode = this.getValuesInNewMode();
						this.setModelAttributesInNewMode(valuesInNewMode);
					}
				},

				/**
				 * Sets default sales channel if card is open in new mode
				 * @protected
				 */
				setSalesChannelInNewMode: function () {
					this.$SalesChannel = {
						value: ConfigurationConstants.Opportunity.Type.PartnerSale
					};
				},

				/**
				 * Creates array of model values in new mode.
				 * @protected
				 * @returns {Array}
				 */
				getValuesInNewMode: function() { 
					const valuesInNewMode = [
						{"name": "Owner", "value": this.BPMSoft.SysValue.CURRENT_USER_CONTACT}
					];
					if (!BPMSoft.isEmptyGUID(this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT.value)) {
						valuesInNewMode.push({
							"name": "Partner",
							"value": this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT
						});
					}
					return valuesInNewMode;
				},

				/**
				 * Set model attributes when card is in new mode
				 * @protected
				 * @param {Array} valuesInNewMode
				 */
				setModelAttributesInNewMode: function(valuesInNewMode) {
					valuesInNewMode.forEach(this.setModelAttribute, this);
				},

				/**
				 * Set model attribute
				 * @protected
				 * @param {Object} attribute 
				 * @param {string} attribute.name Name of attribute
				 * @param {*} attribute.value Value of attribute
				 */
				setModelAttribute: function(attribute) {
					if (Ext.isEmpty(this.get(attribute.name))) {
						this.set(attribute.name, attribute.value);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getLookupPageConfig
				 * @override
				 */
				getLookupPageConfig: function () {
					const parentConfig = this.callParent(arguments);
					parentConfig.hideActions = true;
					return parentConfig;
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "merge",
					"name": "Contact",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "merge",
					"name": "Account",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "LeadPageDealInformationBlock",
					"propertyName": "items",
					"name": "OpportunityOrOrder",
					"values": {
						"markerValue": {"bindTo": "Resources.Strings.OpportunityOrOrderCaption"},
						"caption": {"bindTo": "Resources.Strings.OpportunityOrOrderCaption"},
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"enabled": false,
						"bindTo": "OpportunityOrOrder"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
