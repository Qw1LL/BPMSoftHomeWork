define("SiteEventTypePage", ["SiteEventTypePageResources", "EventTrackingEnums"],
function(resources, EventTrackingEnums) {
	return {
		entitySchemaName: "SiteEventType",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Name",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"name": "WebsiteEventType",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "WebsiteEventType",
					"caption": {
						"bindTo": "Resources.Strings.WebsiteEventTypeCaption"
					},
					"contentType": BPMSoft.ContentType.ENUM,
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "IsActive",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11,
						"rowSpan": 1
					},
					"wrapClass": ["no-margin-bottom"],
					"bindTo": "IsActive",
					"caption": {
						"bindTo": "Resources.Strings.IsActiveCaption"
					},
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GeneralInfoTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0,
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.GeneralInfoTabCaption"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"name": "GeneralInfoBlock",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "GeneralInfoBlock",
				"propertyName": "items",
				"name": "GeneralInfoContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "SelectorType",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					},
					"bindTo": "SelectorType",
					"caption": {
						"bindTo": "Resources.Strings.SelectorTypeCaption"
					},
					"contentType": BPMSoft.ContentType.ENUM,
					"enabled": true,
					"visible": {
						"bindTo": "SelectorTypeIsVisible"
					}
				},
				"parentName": "GeneralInfoContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Identifier",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11,
						"rowSpan": 1
					},
					"bindTo": "Identifier",
					"caption": {
						"bindTo": "IdentifierCaption"
					},
					"tip": {
						"content": {"bindTo": "IdentifierHint"},
						"displayMode": BPMSoft.controls.TipEnums.displayMode.WIDE,
						"tools": []
					},
					"enabled": true
				},
				"parentName": "GeneralInfoContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "remove",
				"name": "ESNTab"
			}
		]/**SCHEMA_DIFF*/,
		attributes: {
			"SelectorTypeIsVisible": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"IdentifierCaption": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			/**
			 * Hint for event identifier hint
			 */
			"IdentifierHint": {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			}
		},
		methods: {
			/**
			 * The initialization function module.
			 * @overridden
			 */
			init: function() {
				this.on("change:SelectorType", this.onChangeSelectorType, this);
				this.on("change:WebsiteEventType", this.onChangeWebsiteEventType, this);
				this.callParent(arguments);
			},

			/**
			 * Sets identifier caption.
			 * @protected
			 */
			setIdentifierCaption: function() {
				var websiteEvent = this.get("WebsiteEventType");
				var isClickEventType = false;
				if (websiteEvent && websiteEvent.value === EventTrackingEnums.WebsiteEventType.CLICK) {
					this.set("SelectorTypeIsVisible", true);
					this.set("IdentifierCaption", resources.localizableStrings.IdentifierCaption);
					isClickEventType = true;
				} else {
					this.set("SelectorTypeIsVisible", false);
					this.set("IdentifierCaption", resources.localizableStrings.PageUrlCaption);
				}
				this.setIdentifierHint(isClickEventType);
			},

			/**
			 * Sets identifier hint.
			 * @protected
			 */
			setIdentifierHint: function(isClickEventType) {
				var websiteEvent = this.get("WebsiteEventType");
				if (websiteEvent && websiteEvent.value === EventTrackingEnums.WebsiteEventType.CLICK) {
					var selector = this.get("SelectorType");
					if (selector || isClickEventType) {
						if (selector && selector.value === EventTrackingEnums.SelectorType.BY_JQUERY_SELECTOR) {
							this.set("IdentifierHint", resources.localizableStrings.IdentifierSelectorHint);
						} else if (selector && selector.value === EventTrackingEnums.SelectorType.BY_CLASS) {
							this.set("IdentifierHint", resources.localizableStrings.IdentifierClassHint);
						} else {
							this.set("IdentifierHint", resources.localizableStrings.IdentifierIdHint);
						}
					}
				} else {
					this.set("IdentifierHint", resources.localizableStrings.PageUrlHint);
				}
			},

			/**
			 * SelectorType change event handler.
			 */
			onChangeSelectorType: function() {
				this.setIdentifierHint();
			},

			/**
			 * WebsiteEventType change event handler.
			 */
			onChangeWebsiteEventType: function() {
				this.setIdentifierCaption();
			}
		},
		rules: {},
		userCode: {}
	};
});
