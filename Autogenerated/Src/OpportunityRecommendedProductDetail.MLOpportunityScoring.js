define("OpportunityRecommendedProductDetail", ["ProcessModuleUtilities", "GoogleTagManagerUtilities"], function(
		ProcessModuleUtilities, GoogleTagManagerUtilities) {
	return {
		entitySchemaName: "RecommendedProduct",
		properties: {
			productCopyTag: "OpportunityPageRecommendedProductsCopy",
			productsRefreshTag: "OpportunityPageRecommendedProductsRefresh"
		},
		methods: {
			_getFromDefaultValues: function(key) {
				const defaultValues = this.$DefaultValues;
				return defaultValues.find(function(item) {
					return item.name === key;
				});
			},

			_getRecommendToEntity: function() {
				const contact = this._getFromDefaultValues("Contact");
				return !this.Ext.isEmpty(contact)
					? contact
					: this._getFromDefaultValues("Account");
			},

			_getSingleProductInsert: function(item) {
				const opportunityId = this._getFromDefaultValues("Opportunity").value;
				const insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "OpportunityProductInterest"
				});
				insert.setParameterValue("Opportunity", opportunityId, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Product", item.$Product.value, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Quantity", 1, this.BPMSoft.DataValueType.FLOAT);
				return insert;
			},

			_insertProductCollection: function(collection) {
				const batchInsert = this.Ext.create("BPMSoft.BatchQuery");
				this.BPMSoft.each(collection, function(item) {
					const insert = this._getSingleProductInsert(item);
					batchInsert.add(insert);
				}, this);
				if (batchInsert.queries.length > 0) {
					batchInsert.execute(this._sendReloadMessage, this);
				}
			},

			_sendReloadMessage: function() {
				this.sandbox.publish("DetailChanged", null, [this.sandbox.id]);
			},

			getGoogleTagManagerData: function(tag) {
				const data = this.callParent();
				this.Ext.apply(data, {
					action: tag
				});
				return data;
			},

			sendAnalytics: function(tag) {
				if (!this.$IsGoogleTagManagerEnabled) {
					return;
				}
				const data = this.getGoogleTagManagerData(tag);
				GoogleTagManagerUtilities.actionModule(data);
			},

			getIsAddAllProductsButtonEnabled: function() {
				return !this.$IsGridEmpty;
			},

			getIsAddSelectedProductsButtonEnabled: function() {
				const hasSingleActiveRow = !this.$MultiSelect && Boolean(this.$ActiveRow);
				const hasMultipleActiveRows = this.$MultiSelect && this.$SelectedRows && this.$SelectedRows.length > 0;
				return hasSingleActiveRow || hasMultipleActiveRows;
			},

			addAllProductsToOpportunity: function() {
				this.sendAnalytics(this.productCopyTag);
				this._insertProductCollection(this.$Collection);
			},

			addSelectedProductsToOpportunity: function() {
				this.sendAnalytics(this.productCopyTag);
				if (!this.$ActiveRow && (this.$MultiSelect && !this.$SelectedRows)) {
					return;
				}
				const selectedRows = this.$MultiSelect ? this.$SelectedRows : [this.$ActiveRow];
				const collection = [];
				this.BPMSoft.each(this.$Collection, function(item) {
					if (selectedRows.includes(item.$Id)) {
						collection.push(item);
					}
				}, this);
				this._insertProductCollection(collection);
			},

			refreshRecommendations: function() {
				this.sendAnalytics(this.productsRefreshTag);
				const recommendToEntity = this._getRecommendToEntity();
				const processName = recommendToEntity.name === "Contact"
					? "ProductRecommendationForContact"
					: "ProductRecommendationForAccount";
				const processParameters = {};
				processParameters[recommendToEntity.name + "Id"] = recommendToEntity.value;
				ProcessModuleUtilities.executeProcess({
					"sysProcessName": processName,
					"parameters": processParameters,
					"callback": function() {
						this.updateDetail({
							reloadAll: true
						});
						this.hideBodyMask();
					},
					"scope": this
				});
			}
		},
		diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "tools",
				"name": "RefreshRecommendationsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "refreshRecommendations"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"clickDebounceTimeout": 2000,
					"caption": {
						"bindTo": "Resources.Strings.RefreshRecommendationButtonCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "tools",
				"name": "AddAllProductsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "addAllProductsToOpportunity"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"clickDebounceTimeout": 2000,
					"caption": {
						"bindTo": "Resources.Strings.AddAllProductsButtonCaption"
					},
					"enabled": {
						"bindTo": "getIsAddAllProductsButtonEnabled"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "tools",
				"name": "AddSelectedProductsButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "addSelectedProductsToOpportunity"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"clickDebounceTimeout": 2000,
					"caption": {
						"bindTo": "Resources.Strings.AddSelectedProductsButtonCaption"
					},
					"enabled": {
						"bindTo": "getIsAddSelectedProductsButtonEnabled"
					}
				}
			},
			{
				"operation": "remove",
				"name": "AddRecordButton"
			}
		]
	};
});
