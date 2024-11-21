define("FullscreenHeaderSchema", [
	"css!MainHeaderModule",
	"css!FullscreenViewModule",
	"css!FullscreenHeaderModule"], function() {
		return {
			attributes: {
				/**
				 * Page header caption.
				 * @private
				 * @type {String}
				 */
				"PageHeaderCaption": {
					dataValueType: this.BPMSoft.DataValueType.TEXT,
					value: ""
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this.subscribeSandboxEvents();
				},

				/**
				 * Subscribes for sandbox events.
				 * @protected
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("UpdatePageHeaderCaption", function(args) {
						if (args.hasOwnProperty("pageHeaderCaption")) {
							this.set("PageHeaderCaption", args.pageHeaderCaption ||
								this.get("Resources.Strings.DefaultPageHeaderCaption"));
						}
					}, this);
				}

				//endregion

			},
			diff: [
				{
					"operation": "insert",
					"name": "FullscreenModuleHeaderContainer",
					"values": {
						"id": "caption",
						"selectors": {wrapEl: "#caption"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["caption-class"],
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "PageHeaderCaption",
					"parentName": "FullscreenModuleHeaderContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "PageHeaderCaption"},
					}
				}
			]
		};
	}
);
