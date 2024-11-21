define("MainMenuTileGenerator", ["ext-base", "BPMSoft", "ModuleUtils", "ViewGeneratorV2"
], function(Ext, BPMSoft, ModuleUtils) {

	Ext.define("BPMSoft.configuration.MainMenuTileGenerator", {
		extend: "BPMSoft.configuration.ViewGenerator",
		alternateClassName: "BPMSoft.MainMenuTileGenerator",

		/**
		 * Generates configuration view for {BPMSoft.ContainerList}.
		 * @protected
		 * @virtual
		 * @param {Object} config Element configuration.
		 * @return {Object} Returns generated view for {BPMSoft.ContainerList}.
		 */
		generateMainMenuTile: function(config) {
			var clonedConfig = BPMSoft.deepClone(config);
			var result = this.generateTileView(clonedConfig);
			return result;
		},

		/**
		 * Generates view of tile.
		 * @protected
		 * @virtual
		 * @param {Object} config Tile configuration.
		 * @return {Object} Returns generated view of tile.
		 */
		generateTileView: function(tile) {
			var tileId = "tile-" + tile.name;
			var tileItemsContainerCfg = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: ["items-container"]
				},
				items: []
			};
			var iconContainer = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: ["image-panel"]
				}
			};
			if (tile.icon) {
				var iconUrl = BPMSoft.ImageUrlBuilder.getUrl(tile.icon);
				iconContainer.styles = {
					"wrapStyles": {"background-image": "url(" + iconUrl + ")"}
				};
			}
			var items = this.generateTileItems(tile.items);
			tileItemsContainerCfg.items = items;
			var wrapClasses = ["tile"];
			if (!Ext.isEmpty(tile.cls)) {
				var customClasses = Ext.isArray(tile.cls) ? tile.cls : [tile.cls];
				wrapClasses = wrapClasses.concat(customClasses);
			}
			const chevronId = tileId + '-chevron';
			var tileContainer = {
				className: "BPMSoft.Container",
				id: tileId,
				classes: {
					wrapClassName: wrapClasses
				},
				markerValue: tile.markerValue || tile.caption,
				items: [
					{
						className: "BPMSoft.Container",
						classes: {
							wrapClassName: ["view-panel"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: tileId + "-color-panel",
								items: [
									{
										className: "BPMSoft.ImageView",
										imageSrc: BPMSoft.ImageUrlBuilder.getUrl(tile.icon),
										classes: {
											wrapClass: ["image-panel"]
										}
									},
									{
										className: "BPMSoft.Label",
										id: tileId + "-caption",
										caption: tile.caption,
										classes: {
											labelClass: ["tile-caption"]
										}
									},
									{
										className: "BPMSoft.Button",
										id: chevronId,
										classes: {
											wrapperClass: ['tile-chevron']
										},
										listeners: {
											click: this.toggleHideClassInContentPanel
										}
									}
								]
							},
							{
								className: "BPMSoft.Container",
								classes: {
									wrapClassName: ["content-panel"]
								},
								items: [
									tileItemsContainerCfg
								]
							}
						]
					}
				]
			};
			if (!Ext.isEmpty(tile.visible)) {
				tileContainer.visible = tile.visible;
			}
			return tileContainer;
		},

		/**
		 * Generate link label template.
		 * @protected
		 * @param {config} config Template configuration.
		 * @param {String} config.code Label code.
		 * @param {String} config.icon Label icon.
		 * @param {String} config.label Label caption.
		 * @throws {BPMSoft.ArgumentNullOrEmptyException} If config argument is empty.
		 * @return {Array} Link label template.
		 */
		generateBPMSoftLinkLabelTemplate: function(config) {
			if (!config) {
				throw new BPMSoft.ArgumentNullOrEmptyException({argumentName: "config"});
			}
			var code = config.code;
			var icon = config.icon;
			var label = config.label;
			var format = Ext.String.format;
			return [
				format("<a id=\"{0}-link\" class=\"{0}-link menu-link\">", code),
				format("<img id=\"{0}-icon\" class=\"{0}-icon\" src=\"{1}\"/>", code, icon),
				format("<label id=\"{0}-label\" class=\"{0}-label\">{1}</label>", code, label),
				"</a>"
			];
		},

		/**
		 * Generate link container config.
		 * @protected
		 * @param {config} config Configuration.
		 * @param {String} config.code Container code.
		 * @param {Boolean} config.visible Container visible.
		 * @param {String} config.caption Caption.
		 * @param {Array} config.labelTemplate Label template.
		 * @param {String} config.markerValue Marker value.
		 * @throws {BPMSoft.ArgumentNullOrEmptyException} If config argument is empty.
		 * @return {Object} Link container config.
		 */
		generateBPMSoftLinkContainerConfig: function(config) {
			if (!config) {
				throw new BPMSoft.ArgumentNullOrEmptyException({argumentName: "config"});
			}
			var code = config.code;
			var format = Ext.String.format;
			return {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: [format("{0}-container", code), "menu-link-container"]
				},
				visible: config.visible,
				id: format("{0}-container-el", code),
				items: [
					{
						className: "BPMSoft.Label",
						classes: {
							labelClass: [format("{0}-caption", code), "menu-caption"]
						},
						caption: config.caption
					},
					{
						className: "BPMSoft.Component",
						tpl: config.labelTemplate,
						selectors: {
							wrapEl: format("#{0}-icon", code)
						}
					}
				],
				markerValue: config.markerValue
			};
		},

		/**
		 * Generate title items.
		 * @protected
		 * @param {Array} itemsCfg Title items config.
		 * @return {Array} Title items.
		 */
		generateTileItems: function(itemsCfg) {
			var result = [];
			BPMSoft.each(itemsCfg, function(item) {
				var tileItemContainer = {
					className: "BPMSoft.Container",
					classes: {
						wrapClassName: ["tile-item"]
					},
					visible: (item.visible === undefined) ? true : item.visible,
					items: []
				};
				var moduleName = item.moduleName;
				var tag = item.tag;
				var caption = item.caption;
				if (!Ext.isEmpty(moduleName)) {
					var module = ModuleUtils.getModuleStructureByName(moduleName);
					tag = tag || ModuleUtils.getModuleTag(moduleName);
					caption = caption || (module && module.moduleCaption);
				}
				var tileItemView =
					{
						className: "BPMSoft.Hyperlink",
						caption: caption,
						markerValue: item.markerValue || caption,
						tag: tag
					};
				if (item.click) {
					tileItemView.click = item.click;
				}
				tileItemContainer.items.push(tileItemView);
				result.push(tileItemContainer);
			}, this);
			return result;
		},

		/**
		 * Generate video panel config.
		 * @param {Object} config Video panel config.
		 * @param {Object} config.playBtnIcon Play button config.
		 * @param {Object} config.activePlayBtnIcon Active play button config.
		 * @param {Object} config.playlist Playlist.
		 * @param {Object} config.markerValue Marker value.
		 * @return {Object} Video panel config.
		 */
		generateVideoPanel: function(config) {
			var playBtnIcon = "";
			var activePlayBtnIcon = "";
			var defaultVideoUrl = "";
			if (config.loadVideo !== false) {
				playBtnIcon = BPMSoft.ImageUrlBuilder.getUrl(config.playBtnIcon);
				activePlayBtnIcon = BPMSoft.ImageUrlBuilder.getUrl(config.activePlayBtnIcon);
			}
			var playlist = this.generatePlayList(config.playlist, playBtnIcon, activePlayBtnIcon);
			if (config.loadVideo !== false) {
				defaultVideoUrl = playlist.length > 0 ? playlist[0].href : "";
			}
			var result = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: ["video-container", "right-item"]
				},
				"id": "VideoPanel",
				"selectors": {"wrapEl": "#VideoPanel"},
				markerValue: config.markerValue || "video-container",
				items: [
					{
						className: "BPMSoft.Container",
						html: "<iframe name=\"bpmcrm-video\" id=\"bpmcrm-video\" width=\"560\" height=\"315\"" +
						" src=\"" + encodeURI(defaultVideoUrl) + "\" frameborder=\"0\" allowfullscreen></iframe>",
						selectors: {
							wrapEl: "#bpmcrm-video"
						}
					}
				]
			};
			result.items = result.items.concat(playlist);
			result.visible = (playlist.length > 0);
			return result;
		},

		/**
		 * Generate playlist.
		 * @param {Array} itemsCfg Items config.
		 * @param {String} playBtnIcon Play button icon.
		 * @return {Array} Playlist.
		 */
		generatePlayList: function(itemsCfg, playBtnIcon) {
			var playlist = [];
			BPMSoft.each(itemsCfg, function(item) {
				if (!Ext.isEmpty(item.videoUrl)) {
					var playlistItem = {
						className: "BPMSoft.Hyperlink",
						tpl: [
							"<a id=\"{id}\" name=\"{name}\" href=\"{href}\" target=\"{target}\"" +
							" class=\"{hyperlinkClass}\" style=\"{hyperlinkStyle}\" title=\"{hint}\" type=\"{type}\">",
							"<div class=\"{videoLinkImageClass}\" style=\"{playBtnStyle}\"></div>{caption}",
							"</a>"
						],
						target: "bpmcrm-video",
						href: item.videoUrl,
						caption: item.caption,
						classes: {
							hyperlinkClass: ["ts-box-sizing", "video-link"],
							videoLinkImageClass: ["play-video-image"]
						},
						tplData: {
							playBtnStyle: {
								"background-image": "url(" + playBtnIcon + ")"
							}
						}
					};
					playlist.push(playlistItem);
				}
			}, this);
			return playlist;
		},

		generateSearchBar: function(config) {
			const inputContainerId = 'searchInputContainer';
			const inputWrapper = 'inputWrapper';
			return {
				className: 'BPMSoft.Container',
				classes: {
					wrapClassName: ["input-container"]
				},
				id: inputContainerId,
				selectors: {
					wrapEl: `#${inputContainerId}`,
					el: `#${inputContainerId}`,
				},
				items: [
					{
						className: 'BPMSoft.Container',
						id: inputWrapper,
						selectors: {
							wrapEl: `#${inputWrapper}`
						},
						items: [
							{
								className: 'BPMSoft.TextEdit',
								id: 'searchBar',
								classes: {
									editInputClass: 'search-bar',
									wrapClass: 'search-bar-wrap'
								},
								placeholder: config.inputPlaceholder,
								selectors: {
									wrapEl: `#${inputWrapper}`
								},
								listeners: {
									keyup: this.searchInContainer
								}
							},
						]
					},
					{
						className: 'BPMSoft.Container',
						id: 'searchIcon',
						selectors: {
							wrapEl: `#searchIcon`,
							el: `#searchIcon`,
						},
						items: [
							{
								className: 'BPMSoft.Button',
								classes: {
									wrapperClass: 'search-icon'
								},
								imageConfig: config.searchIcon,
								selectors: {
									wrapEl: "#searchIcon"
								},
								listeners: {
									click: this.searchInContainer
								}
							}
						]
					}
				]
			}
		},

		/**
		 * Generate mobile banner container config.
		 * @param {Object} config Academy banner config.
		 * @param {Object} config.androidIcon Android icon config.
		 * @param {String} config.androidUrl Android app url.
		 * @param {String} config.androidLabel Android app label.
		 * @param {Object} config.iosIcon iOS icon config.
		 * @param {String} config.iosUrl iOS app url.
		 * @param {String} config.iosLabel iOS app label.
		 * @param {Boolean} config.visible Banner container config.
		 * @param {String} config.markerValue Marker value.
		 * @param {String} config.caption Banner container caption.
		 * @return {Object} Mobile banner container config.
		 */
		generateMobileAppBaner: function(config) {
			var itemsInfo = [
				{
					id: "app-store",
					storeLink: config.iosUrl,
					icon: config.iosIcon,
					label: config.iosLabel
				},
				{
					id: "play-market",
					storeLink: config.androidUrl,
					icon: config.androidIcon,
					label: config.androidLabel
				}
			];
			var items = itemsInfo.map(function(item) {
				return {
					className: "BPMSoft.Component",
					tpl: [
						"<a id=\"" + item.id + "\" class=\"{linkClass}\" href=\"{storeLink}\" target=\"_blank\" rel=\"nofollow\">",
						"<img src=\"{imageUrl}\" class=\"{imageClass}\" alt=\"Download on the " + item.label + "\">",
						"<span>{label}</span>",
						"</a>"
					],
					tplData: {
						storeLink: item.storeLink,
						imageUrl: BPMSoft.ImageUrlBuilder.getUrl(item.icon),
						label: item.label
					},
					classes: {
						linkClass: ["mobile-app-link", "menu-link"],
						imageClass: ["mobile-app-image"]
					},
					selectors: {wrapEl: "#" + item.id},
					markerValue: item.id
				};
			});
			var result = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: ["mobile-apps-container", "right-item"]
				},
				visible: config.visible,
				markerValue: config.markerValue || "mobile-apps-container",
				items: [
					{
						className: "BPMSoft.Label",
						caption: config.caption
					},
					{
						className: "BPMSoft.Container",
						classes: {wrapClassName: ["mobile-apps-links-container"]},
						items: items
					}
				]
			};
			return result;
		},

		/**
		 * Generate accounts links container config.
		 * @param {Object} config Accounts links config.
		 * @param {Array} config.socialAccounts Social accounts config.
		 * @param {String} config.wrapClassName Wrap class name.
		 * @param {String} config.markerValue Marker value.
		 * @param {Object} config.gettingStartedIcon Getting started icon config.
		 * @param {String} config.gettingStartedLabel Getting started label.
		 * @param {Boolean} config.isGettingStartedVisible Getting started link visible.
		 * @param {String} config.gettingStartedCaption Getting started caption.
		 * @param {Object} config.communityIcon Community icon config.
		 * @param {String} config.communityLabel Academy label.
		 * @param {Boolean} config.IsComunityPanelVisible Academy link visible.
		 * @param {String} config.communityCaption Academy caption.
		 * @param {Object} config.marketplaceIcon Marketplace icon config.
		 * @param {String} config.marketplaceLabel Academy label.
		 * @param {Boolean} config.isMarketplacePanelVisible Academy link visible.
		 * @param {String} config.marketplaceCaption Academy caption.
		 * @param {Object} config.academyIcon Academy icon config.
		 * @param {String} config.academyLabel Academy label.
		 * @param {Boolean} config.isAcademyVisible Academy link visible.
		 * @param {String} config.academyCaption Academy caption.
		 * @param {Boolean} config.IsSdkPanelVisible SDK panel visible.
		 * @param {String} config.sdkCaption SDK panel caption.
		 * @param {String} config.sdkIcon SDK icon config.
		 * @param {Boolean} config.IsSocialAccountsPanelVisible Social accounts panel visible.
		 * @param {String} config.socialAccountsCaption Social accounts panel caption.
		 * @return {Object} Accounts links container config.
		 */
		generateBPMSoftAccountsLinks: function(config) {
			var socialAccountItems = this.generateSocialAccountButtons(config.socialAccounts);
			var gettingStartedIcon = BPMSoft.ImageUrlBuilder.getUrl(config.gettingStartedIcon);
			var communityIcon = BPMSoft.ImageUrlBuilder.getUrl(config.communityIcon);
			var marketplaceIcon = BPMSoft.ImageUrlBuilder.getUrl(config.marketplaceIcon);
			var academyIcon = BPMSoft.ImageUrlBuilder.getUrl(config.academyIcon);
			var sdkIcon = BPMSoft.ImageUrlBuilder.getUrl(config.sdkIcon);
			var wrapClassName = ["references-container", "right-item"];
			if (!Ext.isEmpty(config.wrapClassName)) {
				var customClasses = Ext.isArray(config.wrapClassName)
					? config.wrapClassName
					: [config.wrapClassName];
				wrapClassName = wrapClassName.concat(customClasses);
			}
			var gettingStartedTemplate = this.generateBPMSoftLinkLabelTemplate({
				"code": "gettingStarted",
				"icon": gettingStartedIcon,
				"label": config.gettingStartedLabel
			});
			var academyTemplate = this.generateBPMSoftLinkLabelTemplate({
				"code": "academy",
				"icon": academyIcon,
				"label": config.academyLabel
			});
			var communityTemplate = this.generateBPMSoftLinkLabelTemplate({
				"code": "community",
				"icon": communityIcon,
				"label": config.communityLabel
			});
			var marketplaceTemplate = this.generateBPMSoftLinkLabelTemplate({
				"code": "marketplace",
				"icon": marketplaceIcon,
				"label": config.marketplaceLabel
			});
			var sdkTemplate = this.generateBPMSoftLinkLabelTemplate({
				"code": "sdk",
				"icon": sdkIcon,
				"label": config.sdkCaption
			});
			var gettingStartedContainer = this.generateBPMSoftLinkContainerConfig({
				"code": "gettingStarted",
				"visible": config.isGettingStartedVisible,
				"caption": config.gettingStartedCaption,
				"labelTemplate": gettingStartedTemplate,
				"markerValue": "GettingStartedContainer"
			});
			var academyContainer = this.generateBPMSoftLinkContainerConfig({
				"code": "academy",
				"visible": config.isAcademyVisible,
				"caption": config.academyCaption,
				"labelTemplate": academyTemplate,
				"markerValue": "AcademyContainer"
			});
			var communityContainer = this.generateBPMSoftLinkContainerConfig({
				"code": "community",
				"visible": config.IsComunityPanelVisible,
				"caption": config.communityCaption,
				"labelTemplate": communityTemplate,
				"markerValue": "CommunityContainer"
			});
			var marketplaceContainer = this.generateBPMSoftLinkContainerConfig({
				"code": "marketplace",
				"visible": config.isMarketplacePanelVisible,
				"caption": config.marketplaceCaption,
				"labelTemplate": marketplaceTemplate,
				"markerValue": "MarketplaceContainer"
			});
			var sdkContainer = this.generateBPMSoftLinkContainerConfig({
				"code": "sdk",
				"visible": config.IsSdkPanelVisible,
				"caption": config.sdkCaption,
				"labelTemplate": sdkTemplate,
				"markerValue": "SdkContainer"
			});
			var result = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: wrapClassName
				},
				markerValue: config.markerValue || "references-container",
				items: [
					sdkContainer,
					gettingStartedContainer,
					academyContainer,
					communityContainer,
					marketplaceContainer,
					{
						className: "BPMSoft.Container",
						classes: {wrapClassName: ["main-social-networks-container"]},
						visible: config.IsSocialAccountsPanelVisible,
						items: [
							{
								className: "BPMSoft.Label",
								classes: {labelClass: ["social-networks-caption"]},
								caption: config.socialAccountsCaption
							},
							socialAccountItems
						]
					}
				]
			};
			return result;
		},

		/**
		 * Generate social account buttons container config.
		 * @param {Array} itemsCfg Items config.
		 * @return {Object} Social account buttons container config.
		 */
		generateSocialAccountButtons: function(itemsCfg) {
			var socialAccountContainer = {
				className: "BPMSoft.Container",
				classes: {
					wrapClassName: ["social-networks-container"]
				}
			};
			var items = [];
			BPMSoft.each(itemsCfg, function(item) {
				var itemIcon = BPMSoft.ImageUrlBuilder.getUrl(item.icon);
				var itemCfg = {
					className: "BPMSoft.Hyperlink",
					tpl: [
						"<a id=\"{id}\" name=\"{name}\" href=\"{href}\" target=\"_blank\"" +
						" class=\"{hyperlinkClass}\" style=\"{hyperlinkStyle}\" title=\"{hint}\" type=\"{type}\">",
						"<img src=\"{imageSrc}\">",
						"</a>"
					],
					tplData: {
						imageSrc: itemIcon
					},
					href: item.href,
					classes: {
						hyperlinkClass: ["social-network"]
					},
					markerValue: item.markerValue
				};
				items.push(itemCfg);
			}, this);
			socialAccountContainer.items = items;
			return socialAccountContainer;
		},

		/**
		 * toggle hide class for hide content-panel links
		 * @param event event
		 */
		toggleHideClassInContentPanel: function (event) {
			const chevronEl = event.el.dom;
			const controlPanelEl = chevronEl.parentNode.parentNode.lastChild;

			chevronEl.classList.toggle('tile-chevron__hide');
			controlPanelEl.classList.toggle('content-panel__hide');
		},

		/**
		 * search in the left container by the entered word
		 * @param event event
		 */
		searchInContainer: function (event) {
			const currentMainContainer = Ext.get('left-container').el.dom;
			const inputValue = Ext.get('searchBar-el').el.dom.value.trim();
			const searchRegExp = new RegExp(inputValue, 'gi')

			currentMainContainer.childNodes.forEach(el => {
				const wrapEl = el;
				const itemsContainer = el.firstChild.lastChild.firstChild.childNodes;
				let hiddenItem = 0;

				itemsContainer.forEach(item => {
					if (!searchRegExp.test(item.textContent)) {
						item.classList.add('hide');
						hiddenItem++;
					} else {
						item.classList.contains('hide') ? item.classList.remove('hide') : '';
					}
				});

				if (itemsContainer.length === hiddenItem) {
					wrapEl.classList.add('hide');
				} else {
					wrapEl.classList.contains('hide') ? wrapEl.classList.remove('hide') : '';
				}
			});
		}
	});

	return new BPMSoft.configuration.MainMenuTileGenerator();
});
