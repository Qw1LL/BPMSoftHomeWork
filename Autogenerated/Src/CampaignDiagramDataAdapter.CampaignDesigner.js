define("CampaignDiagramDataAdapter", ["CampaignEnums", "CampaignDiagramElements", "CampaignDiagramElementManager"],
		function(CampaignEnums) {
	Ext.define("BPMSoft.CampaignDesigner.CampaignDiagramDataAdapter", {
		extend: "BPMSoft.BaseDiagramDataAdapter",
		alternateClassName: "BPMSoft.CampaignDiagramDataAdapter",

		/**
		 * Config of diagram element badges.
		 * @type {Object}
		 */
		badgesConfig: {},

		/**
		 * List of supported types of badges.
		 * @type {Array}
		 */
		badgeTypes: [
			"history",
			"suspended",
			"error",
			"processing",
			"nonCompleted",
			"completed"
		],

		/**
		 * Flag to indicate data extensibility mode state.
		 * @type {Boolean}
		 */
		useExtendedMode: true,

		/**
		 * @private
		 */
		_getBadgeColorByType: function(type) {
			switch(type) {
				case "history":
					return CampaignEnums.AnalyticsBadgesColors.HISTORY;
				case "completed":
					return CampaignEnums.AnalyticsBadgesColors.COMPLETED;
				case "processing":
					return CampaignEnums.AnalyticsBadgesColors.IN_PROGRESS;
				case "nonCompleted":
					return CampaignEnums.AnalyticsBadgesColors.NON_COMPLETED;
				case "suspended":
					return CampaignEnums.AnalyticsBadgesColors.SUSPENDED;
				case "error":
					return CampaignEnums.AnalyticsBadgesColors.ERROR;
			}
		},

		/**
		 * @private
		 */
		_isBadgeVisible: function(badgeKey) {
			switch(badgeKey) {
				case "historyParticipantsCount":
					return !!this.badgesConfig.showHistory;
				case "completedParticipantsCount":
					return !!this.badgesConfig.showComplete;
				case "processingParticipantsCount":
					return !!this.badgesConfig.showProcessing;
				case "nonCompletedParticipantsCount":
					return !!this.badgesConfig.showNonComplete;
				case "suspendedParticipantsCount":
					return !!this.badgesConfig.showSuspended;
				case "errorParticipantsCount":
					return !!this.badgesConfig.showError;
			}
		},

		/**
		 * @private
		 */
		_getBadgeConfig: function(item, type, side, index) {
			if (!item.stats) {
				return;
			}
			var attName = type + "ParticipantsCount";
			var count = item.stats[attName];
			if (!count) {
				return;
			}
			var fill = this._getBadgeColorByType(type);
			var rx = side === "right" ? item.size.width : 0;
			var ry = -8 - 20 * index;
			return {
				caption: count.toString(),
				type: "label",
				parent: item.uId,
				itemName: item.name + "_" + type,
				rx: rx,
				ry: ry,
				id: item.uId + "_" + type + "_badge_label",
				backgroundStyle: {
					type: "ellipse",
					fill: fill,
					padding: 2.5
				},
				horizontalAlignment: "center",
				verticalAlignment: "center",
				style: {
					fill: "#fff"
				}
			};
		},

		/**
		 * @private
		 */
		_getBackgroundLabelConfig: function(item, badgesCount, maxLabelWidth) {
			var rx = Math.round(item.size.width / 2) - 1;
			var ry = -32 - badgesCount * 16;
			var height = 24 + badgesCount * 16;
			return {
				id: item.uId + "_background_label",
				raiseOnMouseOver: true,
				type: "label",
				parent: item.uId,
				itemName: item.name + "_background",
				caption: " ",
				rx: rx,
				ry: ry,
				height: height,
				width: 56 + maxLabelWidth,
				backgroundStyle: {
					type: "rect",
					fill: "#FFF",
					stroke: "#E5E5E5",
					strokeWidth: 1,
					cornerRadius: 4,
					filter: {
						name: "InfoLabelShadow_filter",
						color: "#00000029",
						opacity: 1,
						offsetX: 0,
						offsetY: 3,
						blur: 6,
					}
				},
				horizontalAlignment: "center",
				verticalAlignment: "top",
				style: {
					outlineClass: "info_outline",
					fill: "#FFF"
				}
			};
		},

		/**
		 * @private
		 */
		_getColorLabelConfig: function(item, type, isRtl, index, maxLabelWidth) {
			var fill = this._getBadgeColorByType(type);
			var rtlMultiplier = isRtl ? -1 : 1;
			var rx = Math.round(item.size.width / 2 - 1 + rtlMultiplier * (-((56 + maxLabelWidth) / 2) + 20));
			var ry = -32 - index * 16;
			return {
				id: item.uId + "_" + type + "_color_label",
				raiseOnMouseOver: true,
				type: "label",
				parent: item.uId,
				itemName: item.name + "_color_" + type,
				caption: " ",
				rx: rx,
				ry: ry,
				width: 8,
				height: 8,
				backgroundStyle: {
					type: "rect",
					cornerRadius: 2,
					fill: fill
				},
				horizontalAlignment: "center",
				verticalAlignment: "top",
				style: {
					outlineClass: "info_outline",
				}
			};
		},

		/**
		 * @private
		 */
		_getTextLabelConfig: function(item, type, isRtl, index, participantsCount, labelWidth) {
			var textAlign = isRtl ? "right" : "left";
			var rtlMultiplier = isRtl ? -1 : 1;
			var rx = Math.round(item.size.width / 2) - 1 + 4 * rtlMultiplier;
			var ry = -35 - index * 16;
			return {
				id: item.uId + "_" + type + "_badge_label",
				raiseOnMouseOver: true,
				type: "label",
				parent: item.uId,
				itemName: item.name + "_" + type,
				caption: this._getFormattedNumberString(participantsCount),
				rx: rx,
				ry: ry,
				height: 8,
				width: labelWidth,
				horizontalAlignment: "center",
				verticalAlignment: "top",
				style: {
					outlineClass: "info_outline",
					fill: "#171717",
					font: "normal normal normal 9px/13px Open Sans",
					textAlign: textAlign
				}
			};
		},

		/**
		 * @private
		 */
		_getAdditionalLabelConfig: function(labelConfig, items) {
			const labels = {};
			const element = items.findByPath("uId", labelConfig.parentUId);
			const caption = element.caption && element.caption.getValue();
			const label = labels[labelConfig.uId] = {
				id: labelConfig.uId,
				type: "label",
				parent: labelConfig.parentUId,
				itemName: labelConfig.name,
				caption: caption,
			};
			if (!BPMSoft.isNull(labelConfig.x)) {
				label.rx = labelConfig.x;
			}
			if (!BPMSoft.isNull(labelConfig.y)) {
				label.ry = labelConfig.y;
			}
			return labels;
		},

		/**
		 * @private
		 */
		_getLabelsConfigAsBubbles: function(item) {
			var labels = {};
			var badge;
			var leftIndex = 0;
			var rightIndex = 0;
			var leftSideName = BPMSoft.getIsRtlMode() ? "right" : "left";
			var rightSideName = BPMSoft.getIsRtlMode() ? "left" : "right";
			badge = this._getBadgeConfig(item, "error", rightSideName, rightIndex);
			if (this.badgesConfig.showError && badge) {
				labels[badge.id] = Ext.apply({}, badge);
				rightIndex++;
			}
			badge = this._getBadgeConfig(item, "suspended", rightSideName, rightIndex);
			if (this.badgesConfig.showSuspended && badge) {
				labels[badge.id] = Ext.apply({}, badge);
				rightIndex++;
			}
			badge = this._getBadgeConfig(item, "completed", rightSideName, rightIndex);
			if (this.badgesConfig.showComplete && badge) {
				labels[badge.id] = Ext.apply({}, badge);
				rightIndex++;
			}
			badge = this._getBadgeConfig(item, "history", leftSideName, leftIndex);
			if (this.badgesConfig.showHistory && badge) {
				labels[badge.id] = Ext.apply({}, badge);
				leftIndex++;
			}
			badge = this._getBadgeConfig(item, "processing", leftSideName, leftIndex);
			if (this.badgesConfig.showProcessing && badge) {
				labels[badge.id] = Ext.apply({}, badge);
				leftIndex++;
			}
			badge = this._getBadgeConfig(item, "nonCompleted", leftSideName, leftIndex);
			if (this.badgesConfig.showNonComplete && badge) {
				labels[badge.id] = Ext.apply({}, badge);
				leftIndex++;
			}
			return labels;
		},

		/**
		 * @private
		 */
		_getLabelWidthByValue: function(value) {
			var str = value.toString();
			var len = str.length;
			var numberOfSpaces = Math.trunc((len - 1) / 3);
			return Math.round(5 * len  + 4 * numberOfSpaces);
		},

		/**
		 * @private
		 */
		_getMaxLabelWidth: function(itemsCollection) {
			var maxValue = 0;
			BPMSoft.each(itemsCollection, function(item) {
				BPMSoft.each(item.stats, function(value, propName) {
					if (this._isBadgeVisible(propName)) {
						maxValue = Math.max(value, maxValue);
					}
				}, this);
			}, this);
			return this._getLabelWidthByValue(maxValue) + 2;
		},

		/**
		 * @private
		 */
		_getFormattedNumberString: function(number) {
			var str = number.toString();
			var length = str.length;
			if (length <= 3) {
				return str;
			}
			for (var i = length; i >= 3; i--) {
				if (i % 3 === 0) {
					str = Ext.String.insert(str, " ", -i);
				}
			}
			return str;
		},

		/**
		 * @private
		 */
		_getLabelsConfigAsInfoBlock: function(item, maxLabelWidth) {
			if (!item.stats) {
				return {};
			}
			var stats = BPMSoft.filter(item.stats, function(x, propName) {
				var isBadgeVisible = this._isBadgeVisible(propName);
				return isBadgeVisible && item.stats[propName] > 0;
			}, this);
			var badgesCount = stats.length;
			if (badgesCount === 0) {
				return {};
			}
			var labels = {};
			var isRtl = BPMSoft.getIsRtlMode();
			var backgroundLabel = this._getBackgroundLabelConfig(item, badgesCount, maxLabelWidth);
			labels[backgroundLabel.id] = backgroundLabel;
			var labelIndex = 0;
			this.badgeTypes.forEach(function(type) {
				var attrName = type + "ParticipantsCount";
				var participantsCount = item.stats[attrName];
				var isBadgeVisible = this._isBadgeVisible(attrName);
				if (isBadgeVisible && participantsCount && participantsCount > 0) {
					var colorLabel = this._getColorLabelConfig(item, type, isRtl, labelIndex, maxLabelWidth);
					var textLabel = this._getTextLabelConfig(item, type, isRtl, labelIndex++, participantsCount, maxLabelWidth);
					labels[colorLabel.id] = colorLabel;
					labels[textLabel.id] = textLabel;
				}
			}, this);

			return labels;
		},

		/**
		 * @private
		 */
		_getConnectionDescription: function(item) {
			if (this.useExtendedMode) {
				return item.description.toString();
			}
			return "";
		},

		/**
		 * @inheritdoc BPMSoft.BaseDiagramDataAdapter#hasEmbeddedLabel
		 * @override
		 */
		hasEmbeddedLabel: function(item) {
			var typeWithoutLabel = this.getType(item);
			return !typeWithoutLabel;
		},

		/**
		 * @inheritdoc BPMSoft.BaseDiagramDataAdapter#getExecutedCountLabels
		 * @override
		 */
		getExecutedCountLabels: function(item, itemsCollection) {
			if (BPMSoft.Features.getIsEnabled("CampaignAnalyticsInfoLabels")) {
				var maxLabelWidth = this._getMaxLabelWidth(itemsCollection);
				return this._getLabelsConfigAsInfoBlock(item, maxLabelWidth);
			}
			return this._getLabelsConfigAsBubbles(item);
		},

		/**
		 * @inheritdoc BPMSoft.BaseDiagramDataAdapter#getType
		 * @override
		 */
		getType: function(item) {
			var type = BPMSoft.CampaignDiagramElementManager.findItemByClassName(item.typeName);
			return type ? type.type : this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseDiagramDataAdapter#getElementConfig
		 * @override
		 */
		getElementConfig: function(schema, item) {
			var config = this.callParent(arguments);
			if (!config) {
				return null;
			}
			var diagramElement = BPMSoft.CampaignDiagramElementManager.findItemByClassName(item.typeName);
			if (diagramElement) {
				Ext.apply(config, {
					largeImage: diagramElement.titleImage,
					shapeFormType: diagramElement.shapeFormType,
					diagramNodeType: diagramElement.diagramNodeType,
					markers: item.getElementMarkers()
				});
			}
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.BaseDiagramDataAdapter#getLabelConfig
		 * @override
		 */
		getLabelConfig: function(labelConfig, items) {
			if (labelConfig instanceof BPMSoft.CampaignLabelSchema) {
				return this._getAdditionalLabelConfig(labelConfig, items);
			}
			return this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseDiagramDataAdapter#getConnectionConfig
		 * @override
		 */
		getConnectionConfig: function(item) {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				description: this._getConnectionDescription(item),
				caption: config.caption || ""
			});
			return config;
		}
	});
});
