define("MailingProvidersDetail", ["ContainerListGenerator",	"ContainerList"],
	function() {
		return {
			entitySchemaName: "MailingProviderInfo",
			messages: {
			},
			attributes: {
				/**
				 * Providers collection.
				 */
				"ProvidersCollection": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"value": Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Selected provider.
				 */
				"SelectedProvider": {
					"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					"value": null
				},

				/**
				 * Is button to connect a provider enable or not.
				 */
				"IsConnectProviderButtonEnable": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				},

				/**
				 * Is button to make provider as default enable or not.
				 */
				"IsMakeProviderAsDefaultButtonEnable": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			methods: {

				/**
				 * Connect the provider, if it is not connected.
				 * @private
				 */
				connectSelectedProvider: function() {
					var data = {
						"request": {
							"services": [
								{
									"serviceName": "CloudEmailService",
									"settings": {
										"provider": this.$SelectedProvider.$ProviderName
									}
								}
							]
						}
					};
					var serviceConfig = {
						serviceName: "MailingService",
						methodName: "ConnectMailingProvider",
						data: data
					};
					this.callService(serviceConfig, function(response) {
						var result = response.ConnectMailingProviderResult;
						if (result && result.Message !== '') {
							this.showInformationDialog(result.Message);
						} else {
							this.reloadGridData();
							this.$IsConnectProviderButtonEnable = false;
						}
					});
				},

				/**
				 * Make the provider as default, if it is not default.
				 * @private
				 */
				makeSelectedProviderAsDefault: function() {
					var data = {
						"request": {
							"services": [
								{
									"serviceName": "CloudEmailService",
									"settings": {
										"provider": this.$SelectedProvider.$ProviderName,
										"useProviderAsDefault": true
									}
								}
							]
						}
					};
					var serviceConfig = {
						serviceName: "MailingService",
						methodName: "ConnectMailingProvider",
						data: data
					};
					this.callService(serviceConfig, function(response) {
						var result = response.ConnectMailingProviderResult;
						if (result && result.Message !== '') {
							this.showInformationDialog(result.Message);
						} else {
							this.reloadGridData();
							this.$IsMakeProviderAsDefaultButtonEnable = false;
						}
					});
				},

				/**
				 * Creates the view model to map to a datagrid.
				 * @private
				 * @return {Boolean} The view model to map to a datagrid.
				 */
				createProviderViewModel: function(sourceItem) {
					var id = this.BPMSoft.generateGUID();
					return Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Id: id,
							ProviderName: sourceItem.providerName,
							IsConnected: sourceItem.isConnected
								? this.get("Resources.Strings.StatusConnected")
								: this.get("Resources.Strings.StatusNotConnected"),
							IsDefault: sourceItem.isDefault
						},
						columns: {
							Id: {
								name: "Id",
								dataValueType: BPMSoft.DataValueType.GUID
							},
							ProviderName: {
								name: "ProviderName",
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							IsConnected: {
								name: "IsConnected",
								dataValueType: BPMSoft.DataValueType.TEXT
							},
							IsDefault: {
								name: "IsDefault",
								dataValueType: BPMSoft.DataValueType.BOOLEAN
							},
						}
					});
				},

				/**
				 * Fills the provider collection with the available providers.
				 * @private
				 */
				fillAvailableProviders: function(accountResponse) {
					if (!accountResponse.AccountInfo.ApiKey) {
						this.$ProvidersCollection.clear();
						this.loadTempCollection();
						return;
					}
					var serviceConfig = {
						serviceName: "MailingService",
						methodName: "GetAvailableProviders",
						data: null
					};
					this.callService(serviceConfig, function(response) {
						if (response && response.availableProviders) {
							var tempCollection = Ext.create("BPMSoft.BaseViewModelCollection");
							var tempItem;
							this.BPMSoft.each(response.availableProviders, function(sourceItem) {
								tempItem = this.createProviderViewModel(sourceItem);
								tempCollection.add(tempItem.$Id, tempItem);
							}, this);
							this.$ProvidersCollection.clear();
							this.$ProvidersCollection.loadAll(tempCollection);
						}
					});
				},

				/**
				 * Handles "selectRow" event of the DataGrid.
				 * @param {String} columnId Identifier of the selected column.
				 * @private
				 */
				rowSelected: function(columnId) {
					var selectedProvider = this.$ProvidersCollection.get(columnId);
					this.$SelectedProvider = selectedProvider;
					var isProviderConnected = selectedProvider.$IsConnected === this.get("Resources.Strings.StatusConnected");
					this.$IsConnectProviderButtonEnable = !isProviderConnected;
					this.$IsMakeProviderAsDefaultButtonEnable = isProviderConnected && !selectedProvider.$IsDefault;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getToolsVisible
				 * @overridden
				 */
				getToolsVisible: function() {
					return false;
				},

				/**
				 * @inheritdoc GridUtilitiesV2#loadGridData
				 * @override
				 */
				loadGridData: function() {
					this.BPMSoft.BpmCrmCloudServiceApi.accountInfo(this.fillAvailableProviders, this);					
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "MailingProvidersInfoButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {"bindTo": "Resources.Strings.ProvidersInfoButtonMessage"},
						"controlConfig": {
							"classes": {
								"wrapperClass": "info-button-providers-detail",
								"imageClass": "info-button-image"
							}
						}
					},
					"parentName": "Detail",
					"propertyName": "tools"
				},
				{
					"operation": "insert",
					"name": "RefreshButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": {"bindTo": "reloadGridData"},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": {"bindTo": "Resources.Strings.RefreshButtonCation"}
					}
				},
				{
					"operation": "insert",
					"name": "ConnectProviderButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"enabled": { "bindTo": "IsConnectProviderButtonEnable"},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": { "bindTo": "connectSelectedProvider" },
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": { "bindTo": "Resources.Strings.ConnectProviderButtonCation" }
					}
				},
				{
					"operation": "insert",
					"name": "MakeProviderAsDefaultButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"values": {
						"enabled": { "bindTo": "IsMakeProviderAsDefaultButtonEnable" },
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"click": { "bindTo": "makeSelectedProviderAsDefault" },
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"caption": { "bindTo": "Resources.Strings.MakeProviderAsDefaultButtonCaption" }
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID,
						"type": this.BPMSoft.GridType.LISTED,
						"listedZebra": true,
						"collection": "$ProvidersCollection",
						"selectRow": { "bindTo": "rowSelected" },
						"rowDataItemMarkerColumnName": "ProviderName",
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});