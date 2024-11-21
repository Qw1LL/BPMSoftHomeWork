define("SocialChannelPage", ["ext-base", "BPMSoft", "SocialChannel", "SocialChannelPageStructure",
	"SocialChannelPageResources", "ServiceHelper", "ConfigurationEnums"],
	function(Ext, BPMSoft, entitySchema, structure, resources,
	ServiceHelper, ConfigurationEnums) {
		structure.userCode = function() {
			this.entitySchema = entitySchema;
			this.name = "SocialChannelPageViewModel";

			this.methods.modifyLeftUtilsConfig = function(config) {
				var subscribeButtonConfig = {
					className: "BPMSoft.Button",
					caption: resources.localizableStrings.SubscribeButtonCaption,
					visible: {
						bindTo: "getSubscribeButtonVisible"
					},
					click: {
						bindTo: "onSubscribeChannelClick"
					}
				};
				var unsubscribeButtonConfig = {
					className: "BPMSoft.Button",
					caption: resources.localizableStrings.UnsubscribeButtonCaption,
					visible: {
						bindTo: "getUnsubscribeButtonVisible"
					},
					click: {
						bindTo: "onUnsubscribeChannelClick"
					}
				};
				config.items.unshift(subscribeButtonConfig, unsubscribeButtonConfig);
				return config;
			};

			this.methods.getUnsubscribeButtonVisible = function() {
				if (this.action !== ConfigurationEnums.CardState.View) {
					return false;
				} else if (this.get("canSubscribe") === false) {
					return true;
				}
				return false;
			};

			this.methods.getSubscribeButtonVisible = function() {
				if (this.action !== ConfigurationEnums.CardState.View) {
					return false;
				} else if (this.get("canSubscribe")) {
					return true;
				}
				return false;
			};

			this.methods.getIsSubscribed = function(callback) {
				ServiceHelper.callService("SocialSubscriptionService", "GetIsUserSubscribed", function(response) {
					var result = response.GetIsUserSubscribedResult;
					this.set("canSubscribe", !result);
					if (callback) {
						callback.call(this);
					}
				}, {entityId: this.get("Id")}, this);
			};

			this.methods.onSubscribeChannelClick = function() {
				if (this.get("canSubscribe")) {
					ServiceHelper.callService("SocialSubscriptionService", "SubscribeUser", function() {
						this.set("canSubscribe", false);
					}, {
						entityId: this.get("Id"),
						entitySchemaUId: this.entitySchema.uId
					}, this);
				}
			};

			this.methods.onUnsubscribeChannelClick = function() {
				ServiceHelper.callService("SocialSubscriptionService", "UnsubscribeUser", function() {
					this.set("canSubscribe", true);
				}, {
					entityId: this.get("Id")
				}, this);
			};

			this.methods.onImageChange = function(image) {
				if (image) {
					var callbackSuccess = function(imageId) {
						var imageData = {
							value: imageId,
							displayValue: "Image"
						};
						this.set(this.primaryImageColumnName, imageData);
					};
					var callbackError = Ext.emptyFn;
					var data = {
						onComplete: callbackSuccess,
						onError: callbackError,
						scope: this,
						file: image
					};
					BPMSoft.ImageApi.upload(data);
				}
			};

			this.methods.updatePublisherRightKind = function() {
				var publisherRightKind = this.get("PublisherRightKindGroup");
				this.set("PublisherRightKind", publisherRightKind);
			};

			var socialChannelImageConfig = resources.localizableImages.SocialChannelImage;
			var socialChannelImageUrl = BPMSoft.ImageUrlBuilder.getUrl(socialChannelImageConfig);

			this.methods.getSrcMethod = function() {
				var result = "";
				var primaryImageColumnValue = this.get(this.primaryImageColumnName);
				if (primaryImageColumnValue) {
					result = this.getSchemaImageUrl();
				} else {
					result = socialChannelImageUrl;
				}
				return result;
			};

			this.methods.beforeFileSelected = function() {
				return true;
			};

			this.methods.setCurrentDate = function() {
				var creationDate = new Date();
				this.set("Date", creationDate);
			};

			this.methods.init = function() {
				this.getIsSubscribed();
				this.setCurrentDate();
			};

			BPMSoft.applySchemaItemProperties(this.schema.leftPanel, "Image", {
				defaultImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.SocialChannelImage)
			});

			this.getItemViewHeader = function() {
				var headerConfig = {
					columns: [{
						dataValueType: BPMSoft.DataValueType.IMAGE,
						name: "Image",
						columnPath: "Image",
						getSrcMethod: "getSrcMethod",
						onPhotoChange: "onImageChange",
						defaultImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.SocialChannelImage),
						beforefileselected: "beforeFileSelected",
						visible: true
					}]
				};
				return headerConfig;
			};

			this.schema.leftPanel = [{
				type: BPMSoft.ViewModelSchemaItem.GROUP,
				name: "baseElementsControlGroup",
				visible: true,
				collapsed: false,
				wrapContainerClass: "main-elements-control-group-container",
				items: [{
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: "Title",
					columnPath: "Title",
					dataValueType: BPMSoft.DataValueType.TEXT
				}, {
					dataValueType: BPMSoft.DataValueType.IMAGE,
					name: "Image",
					columnPath: "Image",
					getSrcMethod: "getSrcMethod",
					onPhotoChange: "onImageChange",
					defaultImage: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.SocialChannelImage),
					beforefileselected: "beforeFileSelected"
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					name: "Description",
					columnPath: "Description",
					dataValueType: BPMSoft.DataValueType.TEXT,
					customConfig: {
						className: "BPMSoft.controls.MemoEdit",
						height: "100px"
					}
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					columnType: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.DATE,
					name: "Date",
					columnPath: "CreatedOn",
					customConfig: {
						enabled: false
					}
				}, {
					type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					name: "PublisherRightKind",
					columnPath: "PublisherRightKind",
					visible: false,
					dependencies: ["PublisherRightKindGroup"],
					methodName: "updatePublisherRightKind"
				}, {
					type: ConfigurationEnums.CustomViewModelSchemaItem.RADIO_GROUP,
					name: "PublisherRightKind",
					caption: resources.localizableStrings.PublisherRightKind,
					items: [{
						caption: resources.localizableStrings.AllUsersPublisherRights,
						tag: true
					}, {
						caption: resources.localizableStrings.EditorsPublisherRights,
						tag: false
					}]
				}]
			}];
		};
		return structure;
	});
