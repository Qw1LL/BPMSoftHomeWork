define("ContentPreviewSchema", ["BPMSoft"],
	function(BPMSoft) {
		return {
			messages: {

				/**
				 * ########## ######### ######### ######### ###### ######### ####### #######.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ########## ######### ### ######### ########## ############# ######### #######.
				 */
				"GetColumnConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ########## ######### ### ######### ########## ############# ######### #######.
				 */
				"GetSchemaColumnsNames": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ########## ######### ### ######### ########## ############# ######### #######.
				 */
				"GetDesignerDisplayConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ########## ######### ### ######### ############## ###### ### ##### ##### ###########.
				 */
				"GetNewLookupPackageUId": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

			},
			methods: {

				/**
				 * ######### ########### ####.
				 * @protected
				 * @virtual
				 */
				close: function() {
					this.destroyModule();
				},

				/**
				 * ######### html # iframe #############.
				 * @protected
				 * @virtual
				 * @param {String} html ##### ### ####### # iframe.
				 */
				insertHtmlToIframe: function(html) {
					var iframe = Ext.get("preview-content-iframe");
					if (!iframe) {
						return;
					}
					var headRegex = /(<head.*?>[\s\S]*<\/head>)/;
					var bodyRegex = /(<body.*?>[\s\S]*<\/body>)/;
					var headHtml = headRegex.test(html) ? headRegex.exec(html)[1] : "";
					var bodyHtml = bodyRegex.test(html) ? bodyRegex.exec(html)[1] : html;
					var iframeDocument = iframe.dom.contentWindow.document;
					iframeDocument.head.innerHTML = headHtml;
					iframeDocument.body.innerHTML = bodyHtml;
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#onRender
				 * @overridden
				 */
				onRender: function() {
					this.updateSize(800, 550);
					var moduleInfo = this.get("moduleInfo");
					var displayHtml = moduleInfo.displayHtml;
					this.insertHtmlToIframe(displayHtml);
					this.hideBodyMask();
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "ContentContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"styles": {
							height: "98%",
							width: "98%"
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "testLabel",
					"parentName": "ContentContainer",
					"propertyName": "items",
					"values": {
						"generator": function() {
							return {
								"selectors": {"wrapEl": "#preview-content-iframe"},
								"className": "BPMSoft.HtmlControl",
								"html": "<iframe id='preview-content-iframe' class='preview-content-iframe'" +
									"width='100%' height='100%'></iframe>"
							};
						}
					}
				},
				{
					"operation": "insert",
					"name": "HeaderContainer",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "CloseButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
						"click": {"bindTo": "close"}
					}
				}
			]
		};
	});
