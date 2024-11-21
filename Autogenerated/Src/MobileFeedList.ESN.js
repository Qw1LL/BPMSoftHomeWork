/**
 * @class BPMSoft.configuration.FeedList
 */
Ext.define("BPMSoft.configuration.FeedList", {
	extend: "Ext.BPMSoft.List",
	xtype: "cffeedlist",

	config: {

		/**
		 * @deprecated
		 */
		messageSymbolLimit: null,

		/**
		 * @inheritdoc
		 */
		shouldTruncateSymbols: false

	},

	/**
	 * Gets link html text.
	 * @private
	 * @param {BPMSoft.Configuration.LinkTypes} type Type of link.
	 * @param {String} title Title\content.
	 * @param {Object} attributes Attributes of dom element.
	 * @param {String} cls CSS class name.
	 * @returns {String} HTML text.
	 */
	getLinkHtml: function(type, title, attributes, cls) {
		var attributesText = "";
		BPMSoft.each(attributes, function(attribute, attributeName) {
			attributesText += attributeName.toLowerCase() + "='" + attribute + "' ";
		}, this);
		if (!cls) {
			cls = "";
		}
		return Ext.String.format("<div class='cf-link x-link {3}' type='{0}' {1}>{2}</div>",
			type, attributesText, title, cls);
	},

	/**
	 * Gets record by 'recordId' attribute in dom element.
	 * @param {HTMLElement} target Dom element.
	 * @protected
	 * @returns {BPMSoft.model.BaseModel} Record.
	 */
	getRecordByTarget: function(target) {
		var store = this.getStore();
		var recordId = target.getAttribute("recordId") || target.parentElement.getAttribute("recordId");
		return store.getById(recordId);
	},

	/**
	 * Replaces hyperlinks in text.
	 * @param {String} text Text.
	 * @private
	 * @returns {String} Text with proper format of hyperlinks.
	 */
	replaceHyperLinks: function(text) {
		var urlTemplateRegExp = BPMSoft.util.getUrlRegExp();
		text = text.replace(urlTemplateRegExp,
			function(link) {
				var position = arguments[6];
				if (text.substr(position - 5, 4) === "url=") {
					return link;
				}
				var url = link;
				if (!/^(https?):\/\//.test(url)) {
					url = "http://" + url;
				}
				return this.getLinkHtml(BPMSoft.Configuration.LinkTypes.Uri, link, {url: url});
			}.bind(this)
		);
		var emailTemplateRegExp = BPMSoft.util.getEmailRegExp();
		text = text.replace(emailTemplateRegExp,
			function(link) {
				return this.getLinkHtml(BPMSoft.Configuration.LinkTypes.Email, link, {email: link});
			}.bind(this)
		);
		return text;
	},

	/**
	 * Check if message is liked.
	 * @private
	 * @param {Object} target DOM element.
	 * @returns {Boolean} true, if message is liked.
	 */
	isMessageLiked: function(target) {
		var isLikedClassName = "cf-feed-list-item-liked";
		return BPMSoft.String.contains(target.className, isLikedClassName) ||
			BPMSoft.String.contains(target.parentElement.className, isLikedClassName);
	},

	/**
	 * Truncates text by given last symbol position.
	 * @private
	 * @param {String} message Text.
	 * @param {Number} lastSymbolPosition Last symbol position for truncating.
	 * @returns {String} Truncated text.
	 */
	truncateBySymbolPosition: function(message, lastSymbolPosition) {
		var htmlText = message.substr(0, lastSymbolPosition + 1);
		htmlText = htmlText.trim();
		htmlText = htmlText.replace(new RegExp("[.]*$"), "... ");
		htmlText += Ext.String.format("<span class='cf-read-more'>{0}</span>",
			BPMSoft.LS.MobileFeedListReadMoreLabel);
		return htmlText;
	},

	/**
	 * Truncates text by given limit ignoring all html tags.
	 * @private
	 * @param {String} htmlText Text with html.
	 * @param {Number} limit Limit of symbols.
	 * @returns {String} Truncated text with html.
	 */
	truncateHtmlText: function(htmlText, limit) {
		var htmlTextLength = htmlText.length;
		if (!Ext.isNumber(limit) || htmlTextLength <= limit) {
			return htmlText;
		}
		var newMessage = "";
		var isCurrentSymbolInsideTag = false;
		var messageCurrentLength = 0;
		var lastSymbolPosition = 0;
		var openedTagCount = 0;
		for (; lastSymbolPosition < htmlTextLength; lastSymbolPosition++) {
			var symbol = htmlText[lastSymbolPosition];
			newMessage = newMessage + symbol;
			var currentTag = htmlText.substr(lastSymbolPosition, 2);
			if (currentTag === "</" || currentTag === "/>") {
				openedTagCount--;
				isCurrentSymbolInsideTag = true;
				continue;
			}
			if (symbol === "<") {
				currentTag = htmlText.substr(lastSymbolPosition, 4);
				if (currentTag.toLowerCase() !== "<br>") {
					openedTagCount++;
				}
				isCurrentSymbolInsideTag = true;
				continue;
			}
			if (symbol === ">") {
				isCurrentSymbolInsideTag = false;
				continue;
			}
			if (isCurrentSymbolInsideTag) {
				continue;
			}
			messageCurrentLength++;
			if (messageCurrentLength >= limit && openedTagCount === 0) {
				break;
			}
		}
		if (messageCurrentLength >= limit && lastSymbolPosition < (htmlTextLength - 1)) {
			htmlText = this.truncateBySymbolPosition(newMessage, lastSymbolPosition);
		}
		return htmlText;
	},

	/**
	 * Formats message.
	 * @protected
	 * @virtual
	 * @param {String} message Text message.
	 * @returns {String} Formatted message.
	 */
	formatMessage: function(message) {
		if (!message) {
			return message;
		}
		message = message.replace(new RegExp("<\\/?(\\w+)[^>]*>", "gi"), function(tag, tagName) {
			tagName = tagName.toLowerCase();
			switch (tagName) {
				case "a":
				case "br":
					return tag;
				default:
					return "";
			}
		});
		var urlTemplateRegExp = BPMSoft.util.getUrlRegExp();
		message = message.replace(/<a.*?>(.*?)<\/a>/gi, function(link, title) {
			var recordId = BPMSoft.util.getAttributeValue(link, "data-value");
			if (recordId) {
				var schemaName = BPMSoft.util.getAttributeValue(link, "data-schemaname") || "Contact";
				title = BPMSoft.util.getAttributeValue(link, "title");
				if (this.isPreviewPageExisted(schemaName)) {
					return this.getLinkHtml(BPMSoft.Configuration.LinkTypes.Module, title, {
						modelName: schemaName,
						recordId: recordId
					});
				}
			} else {
				var url = BPMSoft.util.getAttributeValue(link, "href");
				if (url && url.match(urlTemplateRegExp)) {
					return this.getLinkHtml(BPMSoft.Configuration.LinkTypes.Uri, title, {url: url});
				}
			}
			return title;
		}.bind(this));
		return this.replaceHyperLinks(message);
	},

	/**
	 * Truncates message.
	 * @protected
	 * @virtual
	 * @param {String} message Text message.
	 * @returns {String} Truncated message.
	 */
	truncateMessage: function(message) {
		if (!message) {
			return message;
		}
		return this.truncateHtmlText(message, BPMSoft.List.MaxDisplaySymbols);
	},

	/**
	 * Checks if preview page is existed.
	 * @protected
	 * @virtual
	 * @param {String} schemaName Name of schema.
	 * @returns {Boolean} Returns true, if preview page exists.
	 */
	isPreviewPageExisted: function(schemaName) {
		var modelConfig = BPMSoft.ApplicationConfig.getModelConfig(schemaName);
		return modelConfig[BPMSoft.PageTypes.Preview];
	},

	/**
	 * Returns function for generating template for date.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating template for date.
	 */
	getApplyItemTplEntityRecordFn: function() {
		return function(values) {
			var pointSeparator = Ext.String.format("<div class=\"cf-feed-list-separator\">{0}</div>",
				BPMSoft.LocalizableStrings.MobileFeedListDotSeparator);
			var list = this.list;
			var store = list.getStore();
			var record = store.socialMessageEntitiesRecords[values.EntityId];
			var value = "";
			if (!record) {
				return value;
			}
			var displayValue = record.getPrimaryDisplayColumnValue() || "";
			var modelName = record.modelName;
			var moduleConfig = BPMSoft.ApplicationConfig.manifest.Modules[modelName];
			if (moduleConfig) {
				var iconConfig = moduleConfig.IconV2;
				if (iconConfig && iconConfig.ImageId) {
					var imageStyle = BPMSoft.util.getImageStyleByImageId(iconConfig.ImageId);
					var imageTpl = "<div class=\"cf-feed-list-module-icon\" style=\"{0}\"></div>";
					var imageHtml = Ext.String.format(imageTpl, imageStyle);
					if (displayValue) {
						displayValue += pointSeparator + imageHtml;
					} else {
						displayValue = imageHtml;
					}
				}
				value = displayValue;
				if (list.isPreviewPageExisted(record.modelName)) {
					value = list.getLinkHtml(BPMSoft.Configuration.LinkTypes.Module, displayValue, {
						modelName: record.modelName,
						recordId: record.getPrimaryColumnValue()
					});
				}
			} else {
				value = displayValue;
			}
			return value ? pointSeparator + value : "";
		};
	},

	/**
	 * Returns function for generating link image template.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating link image template.
	 */
	getApplyItemTplLinkImageFn: function() {
		return function(values, imageTpl) {
			var list = this.list;
			return list.getLinkHtml(BPMSoft.Configuration.LinkTypes.Module, imageTpl, {
				modelName: "Contact",
				recordId: values["CreatedBy.Id"]
			}, "cf-image-link");
		};
	},

	/**
	 * Checks if user has permissions for actions on item.
	 * @protected
	 * @virtual
	 * @param {Object} values Record data.
	 * @returns {Boolean} Has access.
	 */
	getUserHasPermissionsForItemActions: function(values) {
		var hasActions = (values["CreatedBy.Id"] === BPMSoft.CurrentUserInfo.contactId);
		return hasActions;
	},

	/**
	 * Returns function for generating template for date.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating template for date.
	 */
	getApplyItemTplDateFn: function() {
		return function(values) {
			var createdOn = values.CreatedOn;
			var today = Ext.Date.clearTime(new Date());
			var yesterday = BPMSoft.Date.add(today, Ext.Date.DAY, -1);
			var beforeYesterday = BPMSoft.Date.add(today, Ext.Date.DAY, -2);
			var dateValue;
			var timeString;
			if (createdOn >= today) {
				var hoursBefore = Ext.Date.diff(createdOn, new Date(), Ext.Date.HOUR);
				if (hoursBefore < 0) {
					hoursBefore = 0;
				}
				if (hoursBefore === 0) {
					var minutesBefore = Ext.Date.diff(createdOn, new Date(), Ext.Date.MINUTE);
					var minutesFormat = BPMSoft.LocalizableStrings.MobileFeedListMessageMinutesFormat;
					if (minutesBefore < 0) {
						minutesBefore = 0;
					}
					dateValue = Ext.String.format(minutesFormat, minutesBefore);
				} else {
					var todayFormat = BPMSoft.LocalizableStrings.MobileFeedListMessageTodayFormat;
					dateValue = Ext.String.format(todayFormat, hoursBefore);
				}
			} else if (createdOn >= yesterday) {
				timeString = Ext.Date.format(createdOn, BPMSoft.Date.getTimeFormat());
				var yesterdayFormat = BPMSoft.LocalizableStrings.MobileFeedListMessageYesterdayFormat;
				dateValue = Ext.String.format(yesterdayFormat, timeString);
			} else if (createdOn >= beforeYesterday) {
				timeString = Ext.Date.format(createdOn, BPMSoft.Date.getTimeFormat());
				var beforeYesterdayFormat =
					BPMSoft.LocalizableStrings.MobileFeedListMessageBeforeYesterdayFormat;
				dateValue = Ext.String.format(beforeYesterdayFormat, timeString);
			} else {
				var dateString = Ext.Date.format(createdOn, BPMSoft.Date.getDateFormat());
				timeString = Ext.Date.format(createdOn, BPMSoft.Date.getTimeFormat());
				var dateFormat = BPMSoft.LocalizableStrings.MobileFeedListMessageDateFormat;
				dateValue = Ext.String.format(dateFormat, dateString, timeString);
			}
			return Ext.String.format("<span>{0}</span>", dateValue);
		};
	},

	/**
	 * Returns function for generating template for count of likes.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating template for count of likes.
	 */
	getApplyItemTplLikesCountFn: function() {
		return function(values) {
			var value = values.LikeCount;
			var recordId = values.Id;
			var recordAttribute = Ext.String.format("recordId='{0}'", recordId);
			var label = BPMSoft.LocalizableStrings.MobileFeedListItemLikeCountLabel;
			return value ? "<span class='cf-feed-list-like-count-label' " + recordAttribute + ">" + label + ": " +
				value + "</span>" : "";
		};
	},

	/**
	 * Returns function for generating template for count of comments.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating template for count of comments.
	 */
	getApplyItemTplCommentsCountFn: function() {
		return function(values) {
			var value = values.CommentCount;
			var recordId = values.Id;
			var recordAttribute = Ext.String.format("recordId='{0}'", recordId);
			var label = BPMSoft.LocalizableStrings.MobileFeedListItemCommentCountLabel;
			return value ? "<span class='cf-feed-list-comment-count-label' " + recordAttribute + ">" + label + ": " +
				value + "</span>" : "";
		};
	},

	/**
	 * Returns function for generating like's button template.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating like's button template.
	 */
	getApplyItemTplLikeButtonFn: function() {
		return function(values) {
			var list = this.list;
			var store = list.getStore();
			var socialMessageLikedRecordIds = store.socialMessageLikedRecordIds || [];
			var recordId = values.Id;
			var recordAttribute = Ext.String.format("recordId='{0}'", recordId);
			var isLiked = (socialMessageLikedRecordIds.indexOf(recordId) !== -1);
			var likedCls = isLiked ? " cf-feed-list-item-liked" : " cf-feed-list-item-not-liked";
			var likeButtonLabel = "";
			if (this.showLikeButtonCaption !== false) {
				likeButtonLabel = BPMSoft.LocalizableStrings.MobileFeedListItemLikeButtonCaption;
			}
			return "<div class='cf-feed-list-item-like-button" + likedCls + "' " + recordAttribute +
				"><span class='cf-like-icon'>" + likeButtonLabel + "</span></div>";
		};
	},

	/**
	 * Returns function for generating comment's button template.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating comment's button template.
	 */
	getApplyItemTplCommentButtonFn: function() {
		return function(values) {
			var recordId = values.Id;
			var recordAttribute = Ext.String.format("recordId='{0}'", recordId);
			var commentButtonLabel = BPMSoft.LocalizableStrings.MobileFeedListItemCommentButtonCaption;
			return "<div class='cf-feed-list-item-comment-button' " + recordAttribute +
				"><span class='cf-comment-icon'>" + commentButtonLabel + "</span></div>";
		};
	},

	/**
	 * Returns function for generating delivery icon template.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating delivery icon template.
	 */
	getApplyItemTplIsDeliveredFn: function() {
		if (!BPMSoft.Features.getIsEnabled("UseHybridModeInMobileFeed")) {
			return Ext.emptyFn;
		}
		return function(values) {
			var list = this.list;
			var store = list.getStore();
			var modifiedRecordIds = store.socialMessageModifiedRecordIds || [];
			var recordId = values.Id;
			var recordAttribute = Ext.String.format("recordId='{0}'", recordId);
			var isDelivered = BPMSoft.ApplicationUtils.isOnlineMode() ? true :
				!Ext.Array.contains(modifiedRecordIds, recordId);
			var deliveredClassName = isDelivered ? "delivered" : "not-delivered";
			return Ext.String.format("<div class='cf-feed-list-item-delivery-icon-{0}' {1}></div>",
				deliveredClassName, recordAttribute);
		};
	},

	/**
	 * Returns function for generating actions' button template.
	 * @protected
	 * @virtual
	 * @returns {Function} Function for generating actions' button template.
	 */
	getApplyItemTplActionsButtonFn: function() {
		return function(values) {
			if (this.list.getUserHasPermissionsForItemActions(values)) {
				return "<div class='cf-feed-list-item-actions'></div>";
			}
		};
	},

	/**
	 * Handles tap on link in message.
	 * @param {Ext.event.Event} event Fired event.
	 * @protected
	 * @virtual
	 */
	onLinkTap: function(event) {
		event.stopEvent();
		var target = event.delegatedTarget;
		var attributes = target.attributes;
		var config = {};
		for (var i = 0, ln = attributes.length; i < ln; i++) {
			var attribute = attributes.item(i);
			var attributeName = attribute.name;
			if (attributeName !== "class") {
				config[attributeName] = attribute.value;
			}
		}
		this.fireEvent("linktap", this, config);
	},

	/**
	 * Handles tap on actions button.
	 * @param {Ext.event.Event} event Fired event.
	 * @param {HTMLElement} target Tapped element.
	 * @protected
	 * @virtual
	 */
	onItemActionsTap: function(event, target) {
		event.stopEvent();
		var record = this.getRecordByTarget(target);
		this.fireEvent("itemactionstap", this, record);
	},

	/**
	 * Handles tap on 'Like' button.
	 * @param {Ext.event.Event} event Fired event.
	 * @param {HTMLElement} target Tapped element.
	 * @protected
	 * @virtual
	 */
	onLikeButtonTap: function(event, target) {
		event.stopEvent();
		var record = this.getRecordByTarget(target);
		var store = this.getStore();
		var isLiked = this.isMessageLiked(target);
		store.setLiked(record, !isLiked);
		this.updateListItemByRecord(record);
		this.fireEvent("liketap", this, record, target);
	},

	/**
	 * Handles tap on 'Comment' button.
	 * @param {Ext.event.Event} event Fired event.
	 * @param {HTMLElement} target Tapped element.
	 * @protected
	 * @virtual
	 */
	onCommentButtonTap: function(event, target) {
		event.stopEvent();
		var record = this.getRecordByTarget(target);
		this.fireEvent("commenttap", this, record, target);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	initialize: function() {
		this.callParent(arguments);
		this.addCls("cf-feed-list");
		var containerElement = this.container.element;
		containerElement.on({
			tap: "onLinkTap",
			delegate: ".cf-link",
			scope: this
		});
		containerElement.on({
			tap: "onItemActionsTap",
			delegate: ".cf-feed-list-item-actions",
			scope: this
		});
		containerElement.on({
			tap: "onLikeButtonTap",
			delegate: ".cf-feed-list-item-like-button > .cf-like-icon",
			scope: this
		});
		containerElement.on({
			tap: "onCommentButtonTap",
			delegate: ".cf-feed-list-item-comment-button > .cf-comment-icon",
			scope: this
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	getDisplayValueForLookupColumn: function(value) {
		return value.getPrimaryDisplayColumnValue();
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	getApplyItemTplPrimaryColumnFn: function() {
		return function(values) {
			var config = this.primaryColumnConfig;
			var value = this.getValueByConfig(config, values);
			if (value) {
				return this.list.getLinkHtml(BPMSoft.Configuration.LinkTypes.Module, value, {
					modelName: "Contact",
					recordId: values["CreatedBy.Id"]
				});
			}
			return "<br>";
		};
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	getDefaultItemTpl: function() {
		var useImage = this.getUseIcons() || !!this.getImageColumn();
		var iconedCls = (useImage ? " x-iconed" + " x-iconed-" + this.getIconPosition() : "");
		return new Ext.XTemplate(
			"<div class=\"x-list-item-tpl" + iconedCls +
				"{[this.applyActionsClassName(values)]}\" {[this.applyRecordAttribute(values)]}>",
				"{[this.applyLinkImage(values, this.applyImage(values))]}",
				"<div class=\"cf-feed-list-item-header\">",
					"{[this.applyPrimaryColumn(values)]}",
					"<div class=\"cf-feed-list-item-header-info\">",
						"{[this.applyDate(values)]}{[this.applyEntityRecord(values)]}",
					"</div>",
				"</div>",
				"{[this.applyActionsButton(values)]}",
				"{[this.applyGroupColumns(values)]}",
				"{[this.applyIsDelivered(values)]}",
				"<div class=\"cf-feed-list-item-bottom-container\">",
					"<div class=\"cf-feed-list-item-info-container\">",
						"{[this.applyLikesCount(values)]}",
						"{[this.applyCommentsCount(values)]}",
					"</div>",
					"<div class=\"cf-feed-list-item-buttons-container\">",
						"{[this.applyLikeButton(values)]}",
						"{[this.applyCommentButton(values)]}",
					"</div>",
				"</div>",
			"</div>",
			this.getDefaultItemTplData()
		);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	getDefaultItemTplData: function() {
		var data = this.callParent(arguments);
		return Ext.apply(data, {
			applyRecordAttribute: function(values) {
				return Ext.String.format("recordId='{0}'", values.Id);
			},
			applyActionsClassName: function(values) {
				return this.getUserHasPermissionsForItemActions(values) ? " cf-has-actions" : "";
			}.bind(this),
			applyActionsButton: this.getApplyItemTplActionsButtonFn(),
			applyLinkImage: this.getApplyItemTplLinkImageFn(),
			applyDate: this.getApplyItemTplDateFn(),
			applyEntityRecord: this.getApplyItemTplEntityRecordFn(),
			applyLikesCount: this.getApplyItemTplLikesCountFn(),
			applyCommentsCount: this.getApplyItemTplCommentsCountFn(),
			applyLikeButton: this.getApplyItemTplLikeButtonFn(),
			applyCommentButton: this.getApplyItemTplCommentButtonFn(),
			applyIsDelivered: this.getApplyItemTplIsDeliveredFn(),
			list: this
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	prepareData: function() {
		var newData = this.callParent(arguments);
		var message = this.formatMessage(newData.Message);
		newData.Message = this.truncateMessage(message);
		return newData;
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overriden
	 */
	updateActions: function(actions) {
		actions = [];
		this.setOnItemDisclosure(false);
		return actions;
	},

	/**
	 * @inheritdoc
	 */
	convertDateTimeColumnData: function(value) {
		return value;
	},

	/**
	 * Updates list item by record.
	 * @param {String} record Instance of model.
	 */
	updateListItemByRecord: function(record) {
		var store = this.getStore();
		var recordId = record.getId();
		var recordIndex = store.data.keys.indexOf(recordId);
		var listItem = this.listItems[recordIndex];
		listItem.updateRecord(record);
	}
});
