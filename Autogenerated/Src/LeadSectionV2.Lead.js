define("LeadSectionV2", ["BPMSoft", "BaseFiltersGenerateModule", "MapsUtilities", "css!LeadCSS"],
	function(BPMSoft, BaseFiltersGenerateModule, MapsUtilities) {
		return {
			entitySchemaName: "Lead",
			attributies: {
				/**
				 * Maps provider config.
				 */
				"MapsProviderConfig": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: null
				},

				/**
				 * Is maps provider config valid.
				 */
				"IsMapsProviderConfigValid": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				}
			},
			columns: {},
			messages: {
				"GetMapsConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {
				init: function() {
					let parentInit = this.getParentMethod(this, arguments);

					MapsUtilities.getMapsProviderConfigAsync()
						.then(value => {
							this.$MapsProviderConfig = value;
							this.$IsMapsProviderConfigValid = Boolean(this.$MapsProviderConfig?.isValid);
							parentInit();
						});
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#initFixedFiltersConfig
				 * @overridden
				 */
				initFixedFiltersConfig: function() {
						var fixedFilterConfig = {
							entitySchema: this.entitySchema,
							filters: [
								{
									name: "Owner",
									caption: this.get("Resources.Strings.OwnerFilterCaption"),
									dataValueType: BPMSoft.DataValueType.LOOKUP,
									filter: BaseFiltersGenerateModule.OwnerFilter,
									columnName: "Owner"
								}
							]
						};
						this.set("FixedFilterConfig", fixedFilterConfig);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSection#getAddMiniPageDefaultValues
				 * @overridden
				 */
				getAddMiniPageDefaultValues: function() {
					var defaultValues = this.callParent(arguments);
					defaultValues.push({
						name: "IsFromSection",
						value: true
					});
					return defaultValues;
				},

				/**
				 * Initializing context help
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1009);
					this.callParent(arguments);
				},

				/**
				 * Action "Show on map"
				 */
				openShowOnMap: function() {
					this.showBodyMask();
					var items = this.getSelectedItems();
					var select = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Lead"
					});
					select.addColumn("Id");
					select.addColumn("LeadName");
					select.addColumn("Address");
					select.addColumn("City");
					select.addColumn("Region");
					select.addColumn("Country");
					select.filters.add("LeadIdFilter", BPMSoft.createColumnInFilterWithParameters("Id", items));
					select.getEntityCollection(function(result) {
						if (result.success) {
							var mapsConfig = {
								mapsData: []
							};
							result.collection.each(function(item) {
								var fullAddress = [];
								var country = item.get("Country");
								if (country) {
									fullAddress.push(country.displayValue);
								}
								var region = item.get("Region");
								if (region) {
									fullAddress.push(region.displayValue);
								}
								var city = item.get("City");
								if (city) {
									fullAddress.push(city.displayValue);
								}
								var address = item.get("Address");
								fullAddress.push(address);

								var leadName = item.get("LeadName");
								var dataItem = {
									caption: leadName,
									content: "<h2>" + leadName + "</h2><div>" + fullAddress.join(", ") + "</div>",
									address: address ? fullAddress.join(", ") : null
								};
								mapsConfig.mapsData.push(dataItem);
							});
							var uniqueMapsId = BPMSoft.generateGUID();
							var mapsModuleSandboxId = this.sandbox.id + "_MapsModule" + uniqueMapsId;
							this.sandbox.subscribe("GetMapsConfig", function() {
								return mapsConfig;
							}, [mapsModuleSandboxId]);
							this.sandbox.loadModule("MapsModule", {
								id: mapsModuleSandboxId,
								keepAlive: true
							});
						}
						this.hideBodyMask();
					}, this);
				},

				/**
				 * Returns a collection of action section in the register display mode
				 * @protected
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} Returns a collection of action section in the
				 * register display mode
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
				/*
				 *	actionMenuItems.addItem(this.getButtonMenuItem({
				 *		Click: { bindTo: "openShowOnMap" },
				 *		Caption: { "bindTo": "Resources.Strings.ShowOnMap" },
				 *		Enabled: { "bindTo": "isAnySelected" },
				 *		Tag: "ShowOnMap"
				 *	}));
				 */
					return actionMenuItems;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				/*{
					"operation": "insert",
					"parentName": "DisqualifyGroupAction",
					"propertyName": "menu",
					"name": "DisqualifyLostLeadAction",
					"values": {
						"caption": { "bindTo": "Resources.Strings.DisqualifyLeadLost" },
						"click": { "bindTo": "onCardAction" },
						"tag": "disqualifyLost"
					}
				},
				{
					"operation": "insert",
					"parentName": "DisqualifyGroupAction",
					"propertyName": "menu",
					"name": "DisqualifyLeadNoConnectionAction",
					"values": {
						"caption": { "bindTo": "Resources.Strings.DisqualifyLeadNoConnection" },
						"click": { "bindTo": "onCardAction" },
						"tag": "disqualifyNoConnection"
					}
				},
				{
					"operation": "insert",
					"parentName": "DisqualifyGroupAction",
					"propertyName": "menu",
					"name": "DisqualifyLeadNotInterestedAction",
					"values": {
						"caption": { "bindTo": "Resources.Strings.DisqualifyLeadNotInterested" },
						"click": { "bindTo": "onCardAction" },
						"tag": "disqualifyNotInterested"
					}
				}*/
			]/**SCHEMA_DIFF*/
		};
	});
