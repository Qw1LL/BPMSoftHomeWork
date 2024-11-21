define("AccountSectionV2", ["RightUtilities", "ConfigurationConstants"],
	function(RightUtilities, ConfigurationConstants) {
	return {
		entitySchemaName: "Account",
		attributes: {
			"canUseGoogleOrSocialFeaturesByBuildType": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		contextHelpId: "1001",
		messages: {
			/**
			 * @message GetMapsConfig
			 * ########## #########, ########### ### ###### ###### ####### ## #####
			 * @param {Object} #########, ############ ### ###### ###### ####### ## #####
			 */
			"GetMapsConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message SetInitialisationData
			 * ############# ########### ######### ###### # ########## #####
			 */
			"SetInitialisationData": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			/**
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				var sysSettings = ["BuildType"];
				BPMSoft.SysSettings.querySysSettings(sysSettings, function() {
					var buildType = BPMSoft.SysSettings.cachedSettings.BuildType &&
						BPMSoft.SysSettings.cachedSettings.BuildType.value;
					this.set("canUseGoogleOrSocialFeaturesByBuildType", buildType !==
						ConfigurationConstants.BuildType.Public);
				}, this);
			},

			/**
			 * @overridden
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1001);
				this.callParent(arguments);
			},

			/**
			 * ######## #######, ####### ###### ########## ########
			 * @protected
			 * @overridden
			 * @return {Object} ########## #######, ####### ###### ########## ########
			 */
			getGridDataColumns: function() {
				var gridDataColumns = this.callParent(arguments);
				if (!gridDataColumns.Name) {
					gridDataColumns.Name = {
						path: "Name"
					};
				}
				if (!gridDataColumns.PrimaryContact) {
					gridDataColumns.PrimaryContact = {
						path: "PrimaryContact"
					};
				}
				return gridDataColumns;
			},

			/**
			 * ######## "######## ## #####"
			 */
			openShowOnMap: function() {
				var items = this.getSelectedItems();
				var select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "Account"
				});
				select.addColumn("Id");
				select.addColumn("Name");
				select.addColumn("Address");
				select.addColumn("City");
				select.addColumn("Region");
				select.addColumn("Country");
				select.addColumn("GPSN");
				select.addColumn("GPSE");
				select.filters.add("AcountIdFilter", this.BPMSoft.createColumnInFilterWithParameters("Id", items));
				select.getEntityCollection(function(result) {
					if (result.success) {
						var mapsConfig = {
							mapsData: []
						};
						result.collection.each(function(item) {
							var address = [];
							if (item.get("Country") && item.get("Country").displayValue) {
								address.push(item.get("Country").displayValue);
							}
							if (item.get("Region") && item.get("Region").displayValue) {
								address.push(item.get("Region").displayValue);
							}
							if (item.get("City") && item.get("City").displayValue) {
								address.push(item.get("City").displayValue);
							}
							address.push(item.get("Address"));
							var dataItem = {
								caption: item.get("Name"),
								content: "<h2>" + item.get("Name") + "</h2><div>" + address.join(", ") + "</div>",
								address: item.get("Address") ? address.join(", ") : null,
								gpsN: item.get("GPSN"),
								gpsE: item.get("GPSE"),
								updateCoordinatesConfig: {
									schemaName: "Account",
									id: item.get("Id")
								}
							};
							mapsConfig.mapsData.push(dataItem);
						});
						var mapsModuleSandboxId = this.sandbox.id + "_MapsModule" + this.BPMSoft.generateGUID();
						this.sandbox.subscribe("GetMapsConfig", function() {
							return mapsConfig;
						}, [mapsModuleSandboxId]);
						this.sandbox.loadModule("MapsModule", {
							id: mapsModuleSandboxId,
							keepAlive: true
						});
					}
				}, this);
			},

			/**
			 * @obsolete
			 */
			findContactsInSocialNetworks: function() {
				var activeRowId = this.get("ActiveRow");
				var selectedRowId = this.get("SelectedRows");
				if (!activeRowId) {
					if (selectedRowId.length > 0) {
						activeRowId = selectedRowId[0];
					}
				}
				if (activeRowId) {
					var gridData = this.get("GridData");
					var activeRow = gridData.get(activeRowId);
					var recordName = activeRow.get(this.primaryDisplayColumnName);
					var config = {
						entitySchemaName: "Account",
						mode: "search",
						recordId: activeRowId,
						recordName: recordName
					};
					var historyState = this.sandbox.publish("GetHistoryState");
					this.sandbox.publish("PushHistoryState", {
						hash: historyState.hash.historyState,
						silent: true
					}, this);
					this.sandbox.loadModule("FindContactsInSocialNetworksModule", {
						renderTo: "centerPanel",
						id: this.sandbox.id + "_FindContactsInSocialNetworksModule",
						keepAlive: true
					});
					this.sandbox.subscribe("ResultSelectedRows", function(args) {
						this.set("Number", args.name);
						this.set("SocialMediaId", args.id);
					}, this, [this.sandbox.id + "_FindContactsInSocialNetworksModule"]);
					this.sandbox.subscribe("SetInitialisationData", function() {
						return config;
					}, [this.sandbox.id + "_FindContactsInSocialNetworksModule"]);
				}
			},

			/**
			 * ########## ######### ######## ####### # ###### ########### #######
			 * @protected
			 * @overridden
			 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ####### # ######
			 * ########### #######
			 */
			getSectionActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					Type: "BPMSoft.MenuSeparator",
					Caption: ""
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "openShowOnMap"},
					"Caption": {"bindTo": "Resources.Strings.ShowOnMapActionCaption"},
					"Enabled": {"bindTo": "isOpenShowOnMap"}
				}));
				return actionMenuItems;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGridContainer",
				"values": {
					"controlConfig": {
						"classes": ["account-grid"]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
