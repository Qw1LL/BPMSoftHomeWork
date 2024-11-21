define("WelcomeScreen", ["ModalBox", "AcademyUtilities"], function(ModalBox) {
	return {
		attributes: {
			"WelcomeScreenVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			"VideoScreenVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			"UseLMSDocumentation": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			"ProductNameEdition": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			"WelcomeScreenVideoUrl": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: ""
			}
		},

		methods: {

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					var sysSettingsNameArray = ["UseLMSDocumentation", "ProductName", "ProductEdition",
						"WelcomeScreenVideoUrl"];
					this.BPMSoft.SysSettings.querySysSettings(sysSettingsNameArray,
						function(values) {
							if (values) {
								this.set("UseLMSDocumentation", values.UseLMSDocumentation);
								this.set("WelcomeScreenVideoUrl", values.WelcomeScreenVideoUrl);
								this.setProduct(values.ProductName, values.ProductEdition);
							}
							callback.call(scope);
						}, this);
				}, this]);
			},

			/**
			 * Sets Product property.
			 * @protected
			 * @param {String} productName Name of product.
			 * @param {String} productEdition Name of product edition.
			 */
			setProduct: function(productName, productEdition) {
				var params = [];
				if (productName) {
					params.push(this.Ext.String.htmlDecode(productName));
				}
				if (productEdition) {
					params.push(productEdition);
				}
				var product = params.join(" ");
				this.set("Product", product);
			},

			/**
			 * @inheritdoc BPMSoft.BasePage#onRender
			 * @overridden
			 */
			onRender: function() {
				this.set("WelcomeScreenVisible", true);
				this.set("VideoScreenVisible", false);
			},

			/**
			 * Handles a click on the "Play" button
			 * @private
			 */
			onPlayButtonClick: function() {
				this.set("WelcomeScreenVisible", false);
				this.set("VideoScreenVisible", true);
				var html = this.getVideo();
				var videoContainer = this.Ext.get("VideoContainer");
				this.Ext.create("BPMSoft.HtmlControl", {
					id: "videoControl",
					renderTo: videoContainer,
					html: html,
					selectors: {
						wrapEl: ".video-wrapper"
					}
				});
			},

			/**
			 * ######### ########.
			 * @private
			 */
			onAcademyButtonClick: function() {
				var config = {
					callback: function(url) {
						window.open(url, "_blank");
					},
					contextHelpCode: "WelcomeScreen",
					scope: this
				};
				BPMSoft.AcademyUtilities.getUrl(config);
			},

			/**
			 * ######### ############## ####.
			 * @private
			 */
			onCloseButtonClick: function() {
				ModalBox.close();
			},

			/**
			 * ########## ######## #########, ############ #######, ### ###.
			 * @return {boolean}
			 */
			useLMSDocumentation: function() {
				return this.get("UseLMSDocumentation");
			},

			/**
			 * ########## ###### # ######### ########.
			 * @return {String}
			 */
			getProduct: function() {
				return this.get("Product");
			},

			/**
			 * ########## ###### # html ### ########### #####.
			 * @return {String}
			 */
			getVideo: function() {
				var html = "<iframe width=\"996\" height=\"698\" src=\"{0}\" frameborder=\"0\" allowfullscreen></iframe>";
				var welcomeScreenVideoUrl = this.get("WelcomeScreenVideoUrl");
				return this.Ext.String.format(html, welcomeScreenVideoUrl);
			},

			/**
			 * ########## ######### ###### ############ #####.
			 * @return {boolean}
			 */
			getPlayButtonVisible: function() {
				var welcomeScreenVideoUrl = this.get("WelcomeScreenVideoUrl");
				return !this.Ext.isEmpty(welcomeScreenVideoUrl);
			}
		},

		diff: [
			//ScreenContainer
			{
				"operation": "insert",
				"name": "ScreenContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["screen"]
					},
					"items": []
				}
			},
			//WelcomeScreen
			{
				"operation": "insert",
				"parentName": "ScreenContainer",
				"name": "WelcomeScreen",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["welcome-screen"]
					},
					"visible": {bindTo: "WelcomeScreenVisible"},
					"items": []
				}
			},
			//CloseButton
			{
				"operation": "insert",
				"parentName": "ScreenContainer",
				"name": "CloseButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"click": {bindTo: "onCloseButtonClick"},
					"markerValue": "CloseButton",
					"imageConfig": {"bindTo": "getCloseButtonImageConfig"},
					"classes": {
						wrapperClass: ["close-button-wrapper"]
					}
				}
			},
			//WelcomeText
			{
				"operation": "insert",
				"name": "WelcomeText",
				"parentName": "WelcomeScreen",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["welcome-text-wrapper"]
					},
					"items": []
				}
			},
			//WelcomeTextStart
			{
				"operation": "insert",
				"name": "WelcomeTextStartLabel",
				"parentName": "WelcomeText",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.WelcomeTextStartLabel"}
				}
			},
			//WelcomeTextProductVersion
			{
				"operation": "insert",
				"name": "WelcomeTextProduct",
				"parentName": "WelcomeText",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "getProduct"}
				}
			},
			//PlayButtonContainer
			{
				"operation": "insert",
				"parentName": "WelcomeScreen",
				"name": "PlayButtonContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			//PlayButton
			{
				"operation": "insert",
				"parentName": "PlayButtonContainer",
				"name": "PlayButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.PlayButtonImage"},
					"click": {bindTo: "onPlayButtonClick"},
					"markerValue": "PlayButton",
					"classes": {
						wrapperClass: ["play-button-wrapper"]
					},
					"visible": {bindTo: "getPlayButtonVisible"}
				}
			},
			//Academy
			{
				"operation": "insert",
				"name": "Academy",
				"parentName": "WelcomeScreen",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["academy-wrapper"]
					},
					"visible": {bindTo: "UseLMSDocumentation"},
					"items": []
				}
			},
			//AcademyHint
			{
				"operation": "insert",
				"name": "AcademyHint",
				"parentName": "Academy",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.AcademyHintLabel"}
				}
			},
			//AcademyButtonContainer
			{
				"operation": "insert",
				"parentName": "Academy",
				"name": "AcademyButtonContainer",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["academy-button-wrapper"]
					},
					"items": []
				}
			},
			//AcademyButton
			{
				"operation": "insert",
				"parentName": "AcademyButtonContainer",
				"name": "AcademyButton",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {bindTo: "Resources.Strings.AcademyButtonCaption"},
					"click": {bindTo: "onAcademyButtonClick"},
					"markerValue": "AcademyButton",
					"classes": {
						wrapperClass: ["academy-button-wrapper"]
					}
				}
			},
			//VideoScreen
			{
				"operation": "insert",
				"parentName": "ScreenContainer",
				"name": "VideoScreen",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["video-screen"]
					},
					"visible": {bindTo: "VideoScreenVisible"},
					"items": []
				}
			},
			//VideoContainer
			{
				"operation": "insert",
				"name": "VideoContainer",
				"parentName": "VideoScreen",
				"propertyName": "items",
				"values": {
					"id": "VideoContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						wrapClassName: ["video-wrapper"]
					},
					items: []
				}
			}
		]
	};
});
