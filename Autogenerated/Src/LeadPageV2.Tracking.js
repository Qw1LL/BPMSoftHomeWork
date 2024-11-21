define("LeadPageV2",
	(function () {
		var dependencies = ["LeadPageV2Resources", "css!TrackingLeadPageV2CSS"];
		if (!Ext.isIEOrEdge) {
			dependencies.push("TrackingEventsFeedElement");
		}
		return dependencies;
	})(),
	function (resources) {
		return {
			entitySchemaName: "Lead",
			attributes: {

				/**
				 * Is should show blank slate.
				 */
				"IsBlankSlateVisible": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"value": false
				}
			},
			methods: {

				/**
				 * @private
				 */
				_isBlankSlateInvisible: function () {
					return !this.$IsBlankSlateVisible;
				},

				/**
				 * @private
				 */
				_getTrackingFeatureState: function () {
					return this.BPMSoft.Features.getIsEnabled("Tracking");
				},

				/**
				 * @private
				 */
				_setTrackingTabVisibility: function () {
					var tabCollection = this.get("TabsCollection");
					tabCollection.eachKey(function (tabName, tab) {
						if (tabName === "TrackingEventsTab") {
							tab.set("Visible", this._getTrackingFeatureState());
						}
					}, this);
				},

				/**
				 * @private
				 */
				_appendTrackingEventFeedDomElement: function () {
					const element = document.createElement("ts-tracking-events-feed");
					element.entityId = this.$PrimaryColumnValue;
					element.resources = resources;
					element.schema = "LEAD";
					element.id = "TrackingEventFeed";
					var eventFeedContainer = document.querySelector("#EventsFeedContainer");
					eventFeedContainer.appendChild(element);
				},

				/**
				 * @private
				 */
				_destroyTrackingEventFeedDomElement: function () {
					var trackingEventFeed = Ext.get("TrackingEventFeed");
					trackingEventFeed.destroy();
				},

				/**
				 * @private
				 */
				_recreateTrackingEventFeedDomElement: function () {
					this._destroyTrackingEventFeedDomElement();
					this._appendTrackingEventFeedDomElement();
				},

				/**
				 * @private
				 */
				_afterEventsFeedContainerRender: function () {
					if (this.$IsBlankSlateVisible) {
						return;
					}
					this._appendTrackingEventFeedDomElement();
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function () {
					this.callParent(arguments);
					if (this.$ActiveTabName === "TrackingEventsTab" && !this.$IsBlankSlateVisible) {
						this._recreateTrackingEventFeedDomElement();
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @override
				 */
				init: function () {
					this.callParent(arguments);
					this._setTrackingTabVisibility();
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#onRender
				 * @overridden
				 */
				onRender: function () {
					this.callParent(arguments);
					this.$IsBlankSlateVisible = this.Ext.isIEOrEdge;
				},

				/**
				 * Returns blank slate icon url.
				 * @protected
				 * @virtual
				 * @return {String} Blank slate icon url.
				 */
				getBlankSlateIcon: function () {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.BlankSlateIcon"));
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "TrackingEventsTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": "$Resources.Strings.TrackingEventsTabCaption",
						"items": [],
						"styles": {
							"height": "calc(100% - 3.8em)",
							"width": "100%"
						},
						"order": 4
					}
				},
				{
					"operation": "insert",
					"name": "TrackingEventsLayout",
					"parentName": "TrackingEventsTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TrackingEventsContainer",
					"parentName": "TrackingEventsLayout",
					"propertyName": "items",
					"values": {
						"markerValue": "TrackingEventsContainer",
						"id": "TrackingEventsContainer",
						"selectors": { "wrapEl": "#TrackingEventsContainer" },
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": { "column": 0, "row": 0, "rowSpan": 6, "colSpan": 24 },
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "WrongBrowserInfoContainer",
					"parentName": "TrackingEventsContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["wrong-browser-info-wrap"]
						},
						"styles": {
							"height": "100%",
							"width": "100%"
						},
						"visible": "$IsBlankSlateVisible",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "WrongBrowserInfoIcon",
					"parentName": "WrongBrowserInfoContainer",
					"propertyName": "items",
					"values": {
						"getSrcMethod": "getBlankSlateIcon",
						"readonly": true,
						"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage",
						"classes": {
							"wrapClass": ["wrong-browser-info-icon"]
						},
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24,
							"rowSpan": 5
						}
					}
				},
				{
					"operation": "insert",
					"name": "WrongBrowserInfoDescription",
					"parentName": "WrongBrowserInfoContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.BlankSlateDescription",
						"labelClass": ["wrong-browser-info-description"],
						"layout": {
							"column": 3,
							"row": 6,
							"colSpan": 20,
							"rowSpan": 6
						}
					}
				},
				{
					"operation": "insert",
					"name": "EventsFeedContainer",
					"parentName": "TrackingEventsContainer",
					"propertyName": "items",
					"values": {
						"id": "EventsFeedContainer",
						"items": [],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"afterrender": "$_afterEventsFeedContainerRender",
						"afterrerender": "$_afterEventsFeedContainerRender",
						"visible": "$_isBlankSlateInvisible"
					}
				}
			]
		};
	}
);