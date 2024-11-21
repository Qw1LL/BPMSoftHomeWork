/**
 * Account profile class.
 * @class BPMSoft.AccountProfileSchemaPRM
 */
define("AccountProfileSchemaPRM", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Account",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseProfileSchema#getLookupConfig
				 * @overridden
				 */
				getLookupConfig: function() {
					var config = this.callParent(arguments);
					var filter = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.AccountType.Partner);
					if (this.isEmpty(config.filters)) {
						var filters = this.BPMSoft.createFilterGroup();
						config.filters = filters;
					}
					config.filters.add("AccountTypeFilter", filter);
					return config;
				},
				
									/**
					 * Generates href config for setLinkValue method of BPMSoft.BaseEdit
					 * @param {String | undefined } name View model Name field value
					 * @returns {{caption: String, url: String}} Config to show value as link in control
					 */
									generateAccountLink: function (name) {
										return {
											url: name ? this.getProfileHeaderURL() : '',
											caption: name ? name : ''
										}
									},
				
									//endregion
			},			
			diff: [
				{
					"operation": "remove",
					"name": "ProfileHeaderValue"
				},
				{
					"operation": "merge",
					"name": "ProfileModuleContainer",
					"values": {
						"wrapClass": ["profile-module-container", "account-profile"]
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "ProfileContentContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "Name",
						"enabled": false,
						"showValueAsLink": true,
						"href":  {
							"bindTo": "Name",
							"bindConfig": {converter: "generateAccountLink"}
						},
						"controlConfig": {
							"linkmouseover": {"bindTo": "onProfileLinkMouseOver"}
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "FullSlateHeader",
					"parentName": "ProfileHeaderContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"classes": {
							"labelClass": "blank-slate-header"
						},
						"selectors": {
							"wrapEl": "#BlankSlateHeader"
						},
						"caption": { "bindTo": "getBlankSlateHeaderCaption" },
						"layout": {
							"column": 3,
							"row": 0,
							"colSpan": 20
						}
					}
				}
			]
		};
	}
);
