define("CampaignDiagramPropertyLandingPage", ["CampaignDiagramPropertyLandingPageResources", "BPMSoft"],
	function() {
		return {
			entitySchemaName: "GeneratedWebForm",
			methods: {
				/**
				 * ########## ######### ##### ############ ### ######### ########.
				 * @protected
				 * @overridden
				 * @return {Array} ######### #####.
				 */
				getUsedColumns: function() {
					return [
						"Id",
						"Name",
						"ExternalURL",
						"State",
						"Type"
					];
				},

				/**
				 * Returns link object for site url.
				 * @return {Object}
				 */
				getExternalURLLink: function() {
					return this.getLink(this.get("ExternalURL"));
				},

				/**
				 * Site url link click handler.
				 * @return {Boolean} True if uses default handler.
				 */
				onExternalLinkClick: function() {
					var value = this.get("ExternalURL");
					return (!Ext.isEmpty(value) && window.open(value, "_blank"));
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#CampaignDiagramPropertyEntityPage
				 */
				formLookupConfig: function(entity) {
					var config = this.callParent(arguments);
					return this.Ext.apply(config, {
						Type: entity.get("Type")
					});
				},

				/**
				 * Returns link object.
				 * @return {Object}
				 */
				getLink: function(value) {
					if (BPMSoft.isUrl(value)) {
						return {
							url: value,
							caption: value
						};
					}
				},

				/**
				 * @inheritdoc BPMSoft.CampaignDiagramPropertyEntityPage#getCustomLookupFilters
				 * @overridden
				 */
				getCustomLookupFilters: function() {
					if (this.getIsFeatureEnabled("OutboundCampaign")) {
						var diagramElementInEdges = this.get("DiagramElementInEdges");
						if (!Ext.isEmpty(diagramElementInEdges)) {
							var filterGroup = this.BPMSoft.createFilterGroup();
							filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
							filterGroup.addItem(this.BPMSoft.createColumnInFilterWithParameters(
								"Type.SchemaUid.Name", [
									"EventTarget",
									"Lead"
								]));
							return filterGroup;
						}
					}
					return this.callParent(arguments);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "CampaignDiagramPropertyDescriptionContainer"
				},
				{
					"operation": "merge",
					"name": "CampaignDiagramPropertyEntityMainContainer",
					"values": {
						"wrapClass": ["main", "fields-container"]
					}
				},
				{
					"operation": "insert",
					"name": "ExternalURL",
					"parentName": "CampaignDiagramPropertyEntityMainContainer",
					"propertyName": "items",
					"values": {
						"isRequired": false,
						"showValueAsLink": true,
						"controlConfig": {
							"enabled": false,
							"setValidationInfo": BPMSoft.emptyFn,
							"href": {"bindTo": "getExternalURLLink"},
							"linkclick": {"bindTo": "onExternalLinkClick"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "State",
					"parentName": "CampaignDiagramPropertyEntityMainContainer",
					"propertyName": "items",
					"values": {
						"controlConfig": {
							"enabled": false,
							"setValidationInfo": BPMSoft.emptyFn
						},
						"isRequired": false
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
