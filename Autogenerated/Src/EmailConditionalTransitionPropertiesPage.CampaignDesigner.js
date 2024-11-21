/**
 * EmailConditionalTransitionPropertiesPage edit page schema.
 * Parent: CampaignConditionalSequenceFlowPropertiesPage.
 * Parent: BaseProcessSchemaElementPropertiesPage.
 */
define("EmailConditionalTransitionPropertiesPage", ["BusinessRuleModule", "ModalBox",
		"CampaignEnums", "LookupUtilities", "SelectableItemListMixin"],
	function(BusinessRuleModule, ModalBox, CampaignEnums, LookupUtilities) {
		return {
			mixins: {
				SelectableItemListMixin: "BPMSoft.SelectableItemListMixin"
			},
			messages: {

				/**
				 * @message HyperlinkSelected
				 * Reacts on hyperlinks selected action.
				 */
				"HyperlinkSelected": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				},

				/**
				 * @message HyperlinkSelectCancel
				 * Reacts on hyperlinks cancelled selection action.
				 */
				"HyperlinkSelectCancel": {
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE,
					mode: BPMSoft.MessageMode.PTP
				}
			},
			attributes: {

				/**
				 * Values of lookup for ReactionMode
				 */
				"ReactionModeEnum": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						Default: {
							value: "0",
							captionName: "Resources.Strings.ReactionModeDefault"
						},
						WithCondition: {
							value: "1",
							captionName: "Resources.Strings.ReactionModeWithCondition"
						}
					}
				},

				/**
				 * Lookup for ReactionMode
				 */
				"ReactionMode": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},

				/**
				 * Condition when email is delivered
				 */
				"IsEmailDelivered": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Condition when email is opened
				 */
				"IsEmailOpened": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Condition when link is clicked
				 */
				"IsUrlClicked": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Condition when email is putted to spam folder
				 */
				"IsEmailPuttedToSpam": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Condition when user unsubscribed
				 */
				"IsRecipientUnsubscribed": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Condition when user replied
				 */
				 "IsRecipientReplied": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"onChange": "updateFlowDescription"
				},

				/**
				 * Array of selected canceled responses for current transition
				 */
				"UndeliveredResponseIds": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": []
				},

				/**
				 * Array of selected canceled responses for current transition
				 */
				"CanceledResponseIds": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": []
				},

				/**
				 * Collection of bulk email hyperlinks for lookup
				 */
				"HyperlinkCollection": {
					dataValueType: this.BPMSoft.DataValueType.COLLECTION,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: this.Ext.create("BPMSoft.BaseViewModelCollection")
				},

				/**
				 * Columns config of hyperlink data row
				 */
				"HyperlinkRowConfig": {
					dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {}
				},

				/**
				 * Array of selected BulkEmail hyperlinks
				 */
				"TransitionUrls": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isLookup": true,
					"referenceSchemaName": "BulkEmailHyperlink",
					"value": []
				},

				/**
				 * Lookup for selected BulkEmail hyperlink
				 */
				"HyperlinkIds": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": []
				},

				/**
				 * Array of track identifiers of selected BulkEmail hyperlinks
				 */
				"HyperlinkTrackIds": {
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": []
				},

				/**
				 * Text to show when hyperlink lookup items are selected
				 */
				"HyperlinkLookupCaption": {
					"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Condition is hyperlink existed and may be selected
				 */
				"IsUrlClickedEnabled": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Values of all responses.
				 */
				"ResponsesCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": new BPMSoft.Collection()
				},

				/**
				 * Values of canceled responses
				 */
				"CanceledResponsesCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Values of undelivered responses
				 */
				"UndeliveredResponsesCollection": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Caption for undelivered responses group
				 */
				"UndeliveredGroupCaption": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Caption for canceled responses group
				 */
				"CanceledGroupCaption": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Hint for selected responses of undelivered group
				 */
				"UndeliveredGroupHint": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Hint for selected responses of canceled group
				 */
				"CanceledGroupHint": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			rules: {

				/**
				 * Rule for ReactionConditionDecision
				 */
				"ReactionConditionDecision": {
					"BindReactionConditionDecisionRequiredToReactionMode": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "ReactionMode"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": "1"
							}
						}]
					}
				}
			},
			methods: {

				/**
				 * Subscribes on sandbox messages.
				 * @private
				 */
				_subscribeOnMessages: function() {
					var hyperlinkLookupModuleId = this._getHyperlinkLookupModuleId();
					this.sandbox.subscribe("HyperlinkSelected", this.onHyperlinkSelected,
						this, [hyperlinkLookupModuleId]);
					this.sandbox.subscribe("HyperlinkSelectCancel", this.closeModalBox,
						this, [hyperlinkLookupModuleId]);
				},

				/**
				 * Returns no hyperlinks hint visibility
				 * @private
				 * @returns {Boolean} True if no hyperlinks to select or  no linked email as source
				 */
				_canShowEmailClickedHint: function() {
					if (!this.getIsReactionModeWithConditions()) {
						return false;
					}
					var isUrlClickedEnabled = this.get("IsUrlClickedEnabled");
					return !isUrlClickedEnabled;
				},

				/**
				 * Returns sandbox id for hyperlink lookup module.
				 * @private
				 * @returns {String} Hyperlink lookup module sandbox id.
				 */
				_getHyperlinkLookupModuleId: function() {
					return this.sandbox.id + "_" + this.id + "_BulkEmailHyperlinkLookupModule";
				},

				/**
				 * Returns true when each hyperlink has a BPM track identifier.
				 * @private
				 * @param {BPMSoft.Collection} hyperlinks Collection of hyperlinks.
				 * @returns {Boolean} true when hyperlinks have a BPM track identifiers.
				 */
				_isContainsBpmTrackId: function(hyperlinks) {
					return Boolean(hyperlinks.findByFn(function(link) {
						return link.$BpmTrackId > 0;
					}));
				},

				/**
				 * Returns collection of grouped by track id hyperlinks.
				 * @private
				 * @param {BPMSoft.Collection} hyperlinks Collection of hyperlinks.
				 * @returns {BPMSoft.Collection} Collection of grouped by track id hyperlinks.
				 */
				_groupLinksByTrackId: function(hyperlinks) {
					var links = this.Ext.create("BPMSoft.BaseViewModelCollection");
					BPMSoft.each(hyperlinks, function(hyperlink) {
						if (links.getKeys().indexOf(hyperlink.$BpmTrackId) === -1) {
							links.add(hyperlink.$BpmTrackId, hyperlink);
						}
					}, this);
					return links;
				},

				/**
				 * Initializes array of selected BulkEmail hyperlinks.
				 * @private
				 * @param {BPMSoft.Collection} hyperlinks Collection of hyperlinks.
				 * @param {Boolean} isContainsBpmTrackId Sign for hyperlinks with BPM track id.
				 */
				_initSelectedHyperlinks: function(hyperlinks, isContainsBpmTrackId) {
					this.$TransitionUrls = [];
					var selectedIds = isContainsBpmTrackId ? this.$HyperlinkTrackIds : this.$HyperlinkIds;
					BPMSoft.each(hyperlinks, function(link) {
						var key = isContainsBpmTrackId ? link.$BpmTrackId : link.$Id;
						if (selectedIds.indexOf(key) !== -1) {
							this.$TransitionUrls.push(link);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_getSelectedResponses: function(responseIds, responseGroup) {
					var selectedResponseIds = [];
					var responses = this.getResponseConfig();
					BPMSoft.each(responses[responseGroup], function(id) {
						if (responseIds.indexOf(id) > -1) {
							selectedResponseIds.push(id);
						}
					}, this);
					return selectedResponseIds;
				},

				/**
				 * @private
				 */
				_initSelectedUndeliveredResponses: function(responseIds) {
					var selectedResponseIds = this._getSelectedResponses(responseIds, "IsEmailUndelivered");
					this.$UndeliveredResponseIds = selectedResponseIds;
				},

				/**
				 * @private
				 */
				_initSelectedCanceledResponses: function(responseIds) {
					var selectedResponseIds = this._getSelectedResponses(responseIds, "IsEmailCanceled");
					this.$CanceledResponseIds = selectedResponseIds;
				},

				/**
				 * Returns values of hyperlinks for lookup.
				 * @private
				 * @returns {Array[Object]} Hyperlinks values for lookup.
				 */
				_getHyperlinksValues: function() {
					var hyperlinks = [];
					BPMSoft.each(this.$HyperlinkCollection, function(hyperlink) {
						hyperlinks.push(hyperlink.values);
					}, this);
					return hyperlinks;
				},

				/**
				 * Returns configuration of hyperlink row for lookup.
				 * @private
				 * @returns {Object} Configuration of hyperlink row for lookup.
				 */
				_getHyperlinkRowConfig: function() {
					var hyperlink = this.$HyperlinkCollection.first();
					return hyperlink && hyperlink.rowConfig;
				},

				/**
				 * @private
				 */
				_extendResponses: function(responseIds, collectionName) {
					var selectedResponses = this.getSelectedOptions(collectionName);
					BPMSoft.each(selectedResponses, function(responseId) {
						responseIds.push(responseId);
					});
				},

				/**
				 * Returns string representation of selected email responses
				 * @protected
				 * @param { Boolean } isResponseActive visibility of responses' checkboxes
				 * @return {string} json of selected email response ids
				 */
				getSelectedHyperlinks: function(keyName) {
					return BPMSoft.reduce(this.$TransitionUrls, function(memo, hyperlink) {
						memo.push(hyperlink.get(keyName));
						return memo;
					}, []);
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @override
				 */
				init: function() {
					this.callParent(arguments);
					this._subscribeOnMessages();
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initPageAsync
				 * @override
				 */
				initPageAsync: function(element, callback, scope) {
					var parentMethod = this.getParentMethod();
					this.initSelectedHyperlinks(element.hyperlinkId, element.hyperlinkTrackId);
					BPMSoft.chain(
						this.loadHyperlinks,
						this.loadAllResponses,
						function() {
							this.initUndeliveredResponses();
							this.initCanceledResponses();
							parentMethod.call(this, element, callback, scope);
						},
						this
					);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#initElementProperties.
				 * @overridden
				 */
				 initElementProperties: function(element, callback, scope) {
					var isResponseBasedStart = element.isResponseBasedStart;
					this.initReactionMode(isResponseBasedStart);
					this.initEmailResponses(element.emailResponseId);
					this.updateUndeliveredResponses();
					this.updateCanceledResponses();
					this.callParent(arguments);
				 },

				/**
				 * Sets Bulk Email hyperlinks in view model.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Context.
				 * @param {Object} response Entity schema query response.
				 */
				onLoadHyperlinks: function(callback, scope, response) {
					var hyperlinks = response.collection;
					this.$IsUrlClickedEnabled = hyperlinks.getCount() > 0;
					this.$IsUrlClicked = this.$IsUrlClicked && this.$IsUrlClickedEnabled;
					if (this.$IsUrlClickedEnabled) {
						var isContainsBpmTrackId = this._isContainsBpmTrackId(hyperlinks);
						if (isContainsBpmTrackId) {
							hyperlinks = this._groupLinksByTrackId(hyperlinks);
						}
						this._initSelectedHyperlinks(hyperlinks, isContainsBpmTrackId);
						this.$HyperlinkCollection.clear();
						this.$HyperlinkCollection.loadAll(hyperlinks);
						this.$HyperlinkRowConfig = this._getHyperlinkRowConfig();
					}
					this.$HyperlinkLookupCaption = {
						displayValue: this.getBulkEmailHyperlinksValue(this.$TransitionUrls)
					};
					callback.call(scope);
				},

				/**
				 * Returns models for response items of specified group.
				 * @protected
				 * @param {String} responseGroup Response group name.
				 */
				getResponseItems: function(responseGroup) {
					var config = this.getResponseConfig();
					return BPMSoft.map(config[responseGroup], function(id) {
							var response = this.$ResponsesCollection.findByFn(function(el) {
								return el.$Id === id;
							});
							if (response) {
								return {
									name: response.$Name,
									value: response.$Id
								};
							}
						}, this)
						.filter(function(el) {
							return Boolean(el);
						});
				},

				/**
				 * Actualizes undelivered responses group info.
				 * @protected
				 */
				refreshUndeliveredGroupCaption: function(item) {
					this.$UndeliveredGroupCaption = this.getResponsesGroupCaption("UndeliveredResponsesCollection");
					this.$UndeliveredGroupHint = this.getResponsesGroupHint("UndeliveredResponsesCollection");
					this.updateFlowDescription();
				},

				/**
				 * Actualizes canceled responses group info.
				 * @protected
				 */
				refreshCanceledGroupCaption: function(item) {
					this.$CanceledGroupCaption = this.getResponsesGroupCaption("CanceledResponsesCollection");
					this.$CanceledGroupHint = this.getResponsesGroupHint("CanceledResponsesCollection");
					this.updateFlowDescription();
				},

				/**
				 * Initializes undelivered responses group.
				 * @protected
				 */
				initUndeliveredResponses: function() {
					var items = this.getResponseItems("IsEmailUndelivered");
					this.initItemsCollection("UndeliveredResponsesCollection", items, [], true);
					this.$UndeliveredResponsesCollection.on("itemChanged", this.refreshUndeliveredGroupCaption, this);
				},

				/**
				 * Updates undelivered responses group.
				 * @protected
				 */
				updateUndeliveredResponses: function() {
					this.updateItemsCollection("UndeliveredResponsesCollection", this.$UndeliveredResponseIds);
					this.refreshUndeliveredGroupCaption();
				},

				/**
				 * Initializes canceled responses group.
				 * @protected
				 */
				initCanceledResponses: function() {
					var items = this.getResponseItems("IsEmailCanceled");
					this.initItemsCollection("CanceledResponsesCollection", items, [], true);
					this.$CanceledResponsesCollection.on("itemChanged", this.refreshCanceledGroupCaption, this);
				},

				/**
				 * Updates canceled responses group.
				 * @protected
				 */
				updateCanceledResponses: function() {
					this.updateItemsCollection("CanceledResponsesCollection", this.$CanceledResponseIds);
					this.refreshCanceledGroupCaption();
				},

				/**
				 * Handler on load all responses request executed event.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Context.
				 * @param {Object} response Response.
				 */
				onLoadAllResponses: function(callback, scope, response) {
					this.$ResponsesCollection.reloadAll(response.collection);
					callback.call(scope);
				},

				/**
				 * Loads hyperlinks from Bulk Email.
				 * @protected
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Execution context.
				 */
				loadHyperlinks: function(callback, scope) {
					var sourceElement = this.getSourceElement();
					var bulkEmailId = sourceElement && sourceElement.marketingEmailId;
					if (!bulkEmailId) {
						this.$IsUrlClickedEnabled = this.$IsUrlClicked = false;
						callback.call(scope);
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmailHyperlink"
					});
					esq.addColumn("BpmTrackId");
					esq.addColumn("Caption");
					esq.addColumn("Url");
					esq.filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "BulkEmail", bulkEmailId)
					);
					esq.getEntityCollection(this.onLoadHyperlinks.bind(this, callback, scope), this);
				},

				/**
				 * Loads all available bulk email responses.
				 * @protected
				 */
				loadAllResponses: function(callback, scope) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "BulkEmailResponse"
					});
					esq.addColumn("Name");
					esq.getEntityCollection(this.onLoadAllResponses.bind(this, callback, scope), this);
				},

				/**
				 * Handles "cleariconclick" event of the TransitionUrlsLookup.
				 * Clears "TransitionUrls" and "HyperlinkIds" collection.
				 * @protected
				 */
				onHyperlinksClearButtonClicked: function() {
					this.$TransitionUrls = [];
					this.$HyperlinkIds = [];
					this.$HyperlinkTrackIds = [];
				},

				/**
				 * Config to map const ids of email responses to attributes or groups.
				 * @private
				 * @return {object} object for mapping ids to attributes.
				 */
				getResponseConfig: function() {
					return {
						"IsEmailDelivered": [CampaignEnums.BulkEmailResponses.DELIVERED],
						"IsEmailOpened": [CampaignEnums.BulkEmailResponses.OPEN],
						"IsUrlClicked": [CampaignEnums.BulkEmailResponses.CLICKS],
						"IsEmailPuttedToSpam": [CampaignEnums.BulkEmailResponses.SPAM_COMPLAINED],
						"IsRecipientUnsubscribed": [CampaignEnums.BulkEmailResponses.UNSUBSCRIBED],
						"IsRecipientReplied": [CampaignEnums.BulkEmailResponses.REPLIED],
						"IsEmailUndelivered": [
							CampaignEnums.BulkEmailResponses.DELIVERY_ERROR,
							CampaignEnums.BulkEmailResponses.SOFT_BOUNCE,
							CampaignEnums.BulkEmailResponses.HARD_BOUNCE
						],
						"IsEmailCanceled": [
							CampaignEnums.BulkEmailResponses.EMAIL_LIMIT_REACHED,
							CampaignEnums.BulkEmailResponses.REJECTED,
							CampaignEnums.BulkEmailResponses.CANCELED_UNSUB_FROM_ALL,
							CampaignEnums.BulkEmailResponses.CANCELED_SENDERS_NAME_NOT_VALID,
							CampaignEnums.BulkEmailResponses.CANCELED_SENDERS_DOMAIN_NOT_VERIFIED,
							CampaignEnums.BulkEmailResponses.CANCELED_DUPLICATED_EMAIL,
							CampaignEnums.BulkEmailResponses.CANCELED_EMAIL_NOT_PROVIDED,
							CampaignEnums.BulkEmailResponses.INVALID_EMAIL_ADDRESS,
							CampaignEnums.BulkEmailResponses.CANCELED_INCORRECT_EMAIL,
							CampaignEnums.BulkEmailResponses.CANCELED_INVALID_EMAIL,
							CampaignEnums.BulkEmailResponses.CANCELED_TEMPLATE_NOT_FOUND,
							CampaignEnums.BulkEmailResponses.CANCELED_UNSUBSCRIBED_BY_EMAIL_TYPE,
							CampaignEnums.BulkEmailResponses.STOPPED_MANUALLY,
							CampaignEnums.BulkEmailResponses.STOPPED_TIME_EXPIRED
						]
					};
				},

				/**
				 * Returns attribute names of all responses from delivered group.
				 * @protected
				 */
				getDeliveredResponses: function() {
					return ["IsEmailDelivered", "IsEmailOpened", "IsUrlClicked",
						"IsEmailPuttedToSpam", "IsRecipientUnsubscribed",  "IsRecipientReplied"];
				},

				/**
				 * @inheritdoc CampaignConditionalSequenceFlowPropertiesPage#subscribeEvents
				 * @overridden
				 */
				subscribeEvents: function() {
					this.callParent(arguments);
					this.on("change:ReactionMode", this.onReactionModeLookupChanged, this);
				},

				/**
				 * Handles change of the "ReactionMode" property.
				 * @private
				 * @return { void }
				 */
				onReactionModeLookupChanged: function() {
					var reactionModeEnum = this.get("ReactionModeEnum");
					var reactionMode = this.get("ReactionMode");
					var decisionModeEnabled = (reactionMode && reactionMode.value === reactionModeEnum.WithCondition.value);
					if (!decisionModeEnabled) {
						this.set("ReactionConditionDecision", null);
					}
					this.updateFlowDescription();
				},

				/**
				 * Returns list of the selected hyperlinks.
				 * @protected
				 */
				getBulkEmailHyperlinksList: function() {
					var hyperlinks = this.$TransitionUrls;
					var captionLength = 60;
					var hint = "";
					var linkTmp = "<a href=\"{0}\" target=\"_blank\">{1}</a>\r\n";
					if (hyperlinks) {
						hint = BPMSoft.reduce(hyperlinks, function(memo, hyperlink) {
							var caption = this.cutString(hyperlink.$Caption, captionLength);
							return memo + Ext.String.format(linkTmp, hyperlink.$Url, caption);
						}, "", this);
					}
					return hint;
				},

				/**
				 * Returns string with concat hyperlinks captions.
				 * @protected
				 * @param {Array} items Hyperlinks.
				 * @return {String}
				 */
				getBulkEmailHyperlinksValue: function(items) {
					return BPMSoft.reduce(items, function(memo, hyperlink) {
						return memo + hyperlink.$Caption + "; ";
					}, "");
				},

				/**
				 * Cut text for certain length.
				 * @param {String} strValue Target text.
				 * @param {Number} strLength Length limit.
				 * @private
				 * @return { string } cutted string
				 */
				cutString: function(strValue, strLength) {
					var ellipsis = Ext.String.ellipsis(strValue.substring(strLength), 0);
					return strValue.substring(0, strLength) + ellipsis;
				},

				/**
				 * For selected emailResponseId set attributes
				 * @param  {string} responseIdsJson json string for emailResponseId
				 * @private
				 */
				initEmailResponses: function(responseIdsJson) {
					if (!responseIdsJson) {
						return;
					}
					var responseIds = JSON.parse(responseIdsJson);
					var config = this.getResponseConfig();
					BPMSoft.each(config, function(propValue, propName) {
						if (propName === "IsEmailUndelivered" || propName === "IsEmailCanceled") {
							return true;
						}
						BPMSoft.each(propValue, function(el) {
							if (responseIds.indexOf(el) > -1) {
								this.set(propName, true);
							}
						}, this);
					}, this);
					this._initSelectedUndeliveredResponses(responseIds);
					this._initSelectedCanceledResponses(responseIds);
				},

				/**
				 * Sets selected hyperlinks
				 * @private
				 * @param  {String} hyperlinkIdsJson json string for selected hyperlinks
				 * @param  {String} hyperlinkTrackIdJson json string for track ids of selected hyperlinks
				 */
				initSelectedHyperlinks: function(hyperlinkIdJson, hyperlinkTrackIdJson) {
					if (!hyperlinkIdJson && !hyperlinkTrackIdJson) {
						return;
					}
					var hyperlinkTrackIds = this.getIds(hyperlinkTrackIdJson);
					if (hyperlinkTrackIds && hyperlinkTrackIds.length > 0) {
						this.$HyperlinkTrackIds = hyperlinkTrackIds;
						return;
					}
					var hyperlinkIds = this.getIds(hyperlinkIdJson);
					if (hyperlinkIds && hyperlinkIds.length > 0) {
						this.$HyperlinkIds = hyperlinkIds;
					}
				},

				/**
				 * Initializes value of the "ReactionMode" property.
				 * @private
				 * @param {String} value Initial value.
				 */
				initReactionMode: function(value) {
					var isDefault = !value;
					this.setLookupValue(isDefault, "ReactionMode",
						"WithCondition", this);
				},

				/**
				 * Returns Array of selected item ids
				 * @private
				 * @param  {string} idsJson json string of selected items
				 * @return {Array[string]} array of selected ids
				 */
				getIds: function(idsJson) {
					if (idsJson) {
						try {
							var ids = JSON.parse(idsJson);
							if (this.Ext.isArray(ids)) {
								return ids;
							}
						} catch (error) {
							return [];
						}
					}
					return [];
				},

				/**
				 * Loads values into user reaction mode combobox.
				 * @protected
				 * @param {Object} filter ComboboxEdit value.
				 * @param {BPMSoft.Collection} list List of comboboxEdit values.
				 */
				onPrepareReactionModeList: function(filter, list) {
					this.prepareList("ReactionModeEnum", list, this);
				},

				/**
				 * @inheritdoc CampaignConditionalSequenceFlowPropertiesPage#saveConditions
				 * @override
				 */
				saveConditions: function(flow) {
					this.callParent(arguments);
					var isResponseBasedStart = this.getIsReactionModeWithConditions();
					flow.isResponseBasedStart = isResponseBasedStart;
					if (isResponseBasedStart && this.$IsUrlClicked) {
						var isContainsBpmTrackId = this._isContainsBpmTrackId(this.$HyperlinkCollection);
						flow.hyperlinkTrackId = isContainsBpmTrackId
							? JSON.stringify(this.getSelectedHyperlinks("BpmTrackId"))
							: JSON.stringify([]);
							flow.hyperlinkId = isContainsBpmTrackId
							? JSON.stringify([])
							: JSON.stringify(this.getSelectedHyperlinks("Id"));
					} else {
						flow.hyperlinkId = flow.hyperlinkTrackId = JSON.stringify([]);
						this.$HyperlinkIds = this.$HyperlinkTrackIds = this.$TransitionUrls = [];
						this.$HyperlinkLookupCaption = { displayValue: "" };
					}
					flow.emailResponseId = this.getEmailResponseId(isResponseBasedStart);
				},

				/**
				 * Returns string representation of selected email responses
				 * @param { Boolean } isResponseActive visibility of responses' checkboxes
				 * @private
				 * @return {string} json of selected email response ids
				 */
				getEmailResponseId: function(isResponseActive) {
					var responseIds = [];
					if (isResponseActive) {
						var config = this.getResponseConfig();
						BPMSoft.each(config, function(propValue, propName) {
							if (this.get(propName)) {
								if (propName === "IsEmailCanceled" || propName === "IsEmailUndelivered") {
									return true;
								}
								responseIds = responseIds.concat(propValue);
							}
						}, this);
					}
					this._extendResponses(responseIds, "UndeliveredResponsesCollection");
					this._extendResponses(responseIds, "CanceledResponsesCollection");
					return JSON.stringify(responseIds);
				},

				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @overridden
				 */
				getContextHelpCode: function() {
					return "CampaignConditionalSequenceFlow";
				},

				/**
				 * @private
				 * @return {Boolean}
				 */
				getIsRecipientReplyEnabled: function() {
					return BPMSoft.Features.getIsEnabled("BulkEmailReplyTo")
						&& this.getIsReactionModeWithConditions();
				},

				/**
				 * Determines whether the value of the "ReactionMode" is not default value.
				 * @private
				 * @param {String} reactionMode Value of the ReactionMode lookup.
				 * @return {Boolean}
				 */
				getIsReactionModeWithConditions: function() {
					return this.isLookupValueEqual("ReactionMode", "1", this);
				},

				/**
				 * Returns left element for this sequence flow
				 * @protected
				 * @return {BPMSoft.CampaignSchemaElement} sourse element for transition
				 */
				getSourceElement: function() {
					var flowElement = this.get("ProcessElement");
					if (flowElement) {
						return flowElement.findSourceElement();
					}
					return null;
				},

				/**
				 * Determines whether the IsUrlTransaction checkbox checked.
				 * @private
				 * @return {Boolean} is urlclicked checked
				 */
				getIsUrlClickedChecked: function() {
					var urlTransition = this.get("IsUrlClicked");
					if (urlTransition) {
						var element = this.getSourceElement();
						if (element && element.marketingEmailId) {
							var isUrlClickedEnabled = this.get("IsUrlClickedEnabled");
							return this.getIsReactionModeWithConditions() && isUrlClickedEnabled;
						}
					}
					return false;
				},

				/**
				 * Gets hyperlink lookup config
				 * @protected
				 * @deprecated
				 * @return {object} lookup config object
				 */
				getHyperlinkLookupConfig: function() {
					var selectedValues = this.getSelectedIds();
					var config = this.getLookupConfig();
					config.selectedValues = selectedValues;
					config.multiSelect = true;
					config.entitySchemaName = "BulkEmailHyperlink";
					var filters = this.getCustomLookupFilters();
					if (filters) {
						config.filters = filters;
					}
					return config;
				},

				/**
				 * Inits custom lookup filters
				 * @protected
				 * @deprecated
				 * @return {object} custom lookup filters
				 */
				getCustomLookupFilters: function() {
					var filters = BPMSoft.createFilterGroup();
					var element = this.getSourceElement();
					if (element && element.marketingEmailId) {
						filters.addItem(BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "BulkEmail", element.marketingEmailId)
						);
					}
					return filters;
				},

				/**
				 * Returns Ids of selected hyperlinks.
				 * @private
				 * @deprecated
				 * @return {Array} selected hyperlink ids array
				 */
				getSelectedIds: function() {
					return BPMSoft.reduce(this.get("TransitionUrls"), function(memo, hyperlink) {
						memo.push(hyperlink.Id);
						return memo;
					}, []);
				},

				/**
				 * Loads hyperlinks lookup
				 * @protected
				 */
				loadBulkEmailHyperlinkSchemaLookup: function() {
					var moduleId = this._getHyperlinkLookupModuleId();
					var sourceElement = this.getSourceElement();
					var bulkEmailId = sourceElement && sourceElement.marketingEmailId;
					var selectedLinks = this.getSelectedHyperlinks("Id");
					var modalBoxContainer = ModalBox.show({
						heightPixels: 560,
						widthPixels: 820,
						boxClasses: ["hl-modal-box"]
					}, function() {
						this.sandbox.unloadModule(moduleId, modalBoxContainer.id);
					}, this);
					this.sandbox.loadModule("BulkEmailHyperlinkLookupModule", {
						renderTo: modalBoxContainer.id,
						id: moduleId ,
						keepAlive: false,
						parameters: {
							viewModelConfig: {
								BulkEmailId: bulkEmailId,
								Hyperlinks: this._getHyperlinksValues(),
								RowConfig: this.$HyperlinkRowConfig,
								SelectedItems: selectedLinks || []
							}
						}
					});
				},

				/**
				 * Handles select of hyperlinks event.
				 * @protected
				 * @param {BPMSoft.Collection} hyperlinks Collection of selected hyperlinks.
				 */
				onHyperlinkSelected: function(hyperlinks) {
					ModalBox.close();
					var links = hyperlinks.getItems();
					this.$TransitionUrls = links;
					this.$HyperlinkLookupCaption = {
						displayValue: this.getBulkEmailHyperlinksValue(links)
					};
				},

				/**
				 * Handles cancel select hyperlink event.
				 * Closes modal box.
				 * @public
				 */
				closeModalBox: function() {
					ModalBox.close();
				},

				/**
				 * Creates caption with element name
				 * @protected
				 * @return {string} custom caption with element name
				 */
				getQuestionCaption: function() {
					var caption = this.get("Resources.Strings.ReactionModeCaption");
					caption = this.Ext.String.format(caption, this.getSourceElement().getCaption());
					return caption;
				},

				/**
				 * Returns caption for selected delivered responses count.
				 * @protected
				 */
				getDeliveredResponsesCountCaption: function() {
					var responses = this.getDeliveredResponses();
					var counter = 0;
					BPMSoft.each(responses, function(responseAttribute) {
						if (this.get(responseAttribute)) {
							counter++;
						}
					}, this);
					return Ext.String.format("{0}/{1}", counter, responses.length);
				},

				/**
				 * Returns caption for specified group selected responses count.
				 * @protected
				 * @param {String} collectionName Name of group collection.
				 */
				getResponsesGroupCaption: function(collectionName) {
					var selected = this.getSelectedOptions(collectionName);
					var count = this.get(collectionName).getCount();
					return Ext.String.format("{0}/{1}", selected.length, count);
				},

				/**
				 * Returns hint text for specified response ids.
				 * @protected
				 * @param {Array} selectedResponseIds Ids of selected responses.
				 */
				getSelectedResponsesHint: function(selectedResponseIds) {
					return BPMSoft.reduce(selectedResponseIds, function(memo, responseId) {
						var response = this.$ResponsesCollection.findByFn(function(el) {
							return el.$Id === responseId;
						});
						if (response) {
							memo += Ext.String.format("{0}\r\n", response.$Name);
						}
						return memo;
					}, "", this);
				},

				/**
				 * Returns hint text for selected delivered responses group.
				 * @protected
				 */
				getDeliveredResponsesHint: function() {
					var responses = this.getDeliveredResponses();
					var selectedResponseIds = [];
					var config = this.getResponseConfig();
					BPMSoft.each(responses, function(responseAttribute) {
						if (this.get(responseAttribute)) {
							selectedResponseIds = selectedResponseIds.concat(config[responseAttribute]);
						}
					}, this);
					return this.getSelectedResponsesHint(selectedResponseIds);
				},

				/**
				 * Returns hint text for specified responses group.
				 * @protected
				 * @param {String} collectionName Name of responses group collection.
				 */
				getResponsesGroupHint: function(collectionName) {
					var responseIds = this.getSelectedOptions(collectionName);
					return this.getSelectedResponsesHint(responseIds);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ReactionContainer",
					"propertyName": "items",
					"parentName": "ContentContainer",
					"className": "BPMSoft.GridLayoutEdit",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 24},
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ReactionModeLabel",
					"parentName": "ReactionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "getQuestionCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ReactionMode",
					"parentName": "ReactionContainer",
					"propertyName": "items",
					"values": {
						"contentType": this.BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "onPrepareReactionModeList"
							}
						},
						"isRequired": true,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "DeliveredControlGroup",
					"parentName": "ReactionContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"classes": {
							"wrapClass": ["response-control-group"]
						},
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"className": "BPMSoft.ControlGroup",
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.DeliveredGroupCaption",
						"items": [],
						"tools": [{
							"id": "DeliveredControlGroupCountLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"classes": {"labelClass": ["responses-count-label"]},
							"caption": "$getDeliveredResponsesCountCaption",
							"hint": "$getDeliveredResponsesHint"
						}]
					}
				},
				{
					"operation": "insert",
					"name": "DeliveredControlGroupLayout",
					"parentName": "DeliveredControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": { "wrapClassName": ["email-responses-container"] },
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "UndeliveredControlGroup",
					"parentName": "ReactionContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"classes": {
							"wrapClass": ["response-control-group"]
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"collapsed": true,
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.UndeliveredGroupCaption",
						"items": [],
						"tools": [{
							"id": "UndeliveredControlGroupCountLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"classes": {"labelClass": ["responses-count-label"]},
							"caption": "$UndeliveredGroupCaption",
							"hint": "$UndeliveredGroupHint"
						}]
					}
				},
				{
					"operation": "insert",
					"name": "UndeliveredResponsesList",
					"parentName": "UndeliveredControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "UndeliveredResponsesCollection",
						"onGetItemConfig": "getMultiselectItemViewConfig",
						"classes": {
							"wrapClassName": ["responses-list"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "CanceledControlGroup",
					"parentName": "ReactionContainer",
					"propertyName": "items",
					"index": 2,
					"values": {
						"classes": {
							"wrapClass": ["response-control-group"]
						},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24
						},
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"collapsed": true,
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"caption": "$Resources.Strings.CanceledGroupCaption",
						"items": [],
						"tools": [{
							"id": "CanceledControlGroupCountLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"classes": {"labelClass": ["responses-count-label"]},
							"caption": "$CanceledGroupCaption",
							"hint": "$CanceledGroupHint"
						}]
					}
				},
				{
					"operation": "insert",
					"name": "CanceledResponsesList",
					"parentName": "CanceledControlGroup",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "CanceledResponsesCollection",
						"onGetItemConfig": "getMultiselectItemViewConfig",
						"classes": {
							"wrapClassName": ["responses-list"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"name": "IsEmailDelivered",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"caption": "$Resources.Strings.IsEmailDelivered",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 22
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"name": "IsEmailOpened",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"caption": "$Resources.Strings.IsEmailOpened",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 22
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"name": "IsUrlClicked",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"caption": "$Resources.Strings.IsUrlClicked",
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 22
						},
						"enabled": "$IsUrlClickedEnabled"
					}
				},
				{
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"name": "NoHyperlinkInformationButton",
					"values": {
						"layout": {"column": 21, "row": 2, "colSpan": 1},
						"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
						"content": {"bindTo": "Resources.Strings.NoHyperlinkHintMessage"},
						"controlConfig": {
							"classes": {
								"wrapperClass": "t-checkbox-information-button"
							},
							"visible": "$_canShowEmailClickedHint"
						}
					}
				},
				{
					"operation": "insert",
					"name": "UrlLabel",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 3,
							"row": 3,
							"colSpan": 8
						},
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.TransitionUrlCaption",
						"classes": {
							"labelClass": ["label-control"]
						},
						"visible": "$getIsUrlClickedChecked"
					}
				},
				{
					"operation": "insert",
					"name": "TransitionUrls",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"values": {
						"bindTo": "TransitionUrls",
						"visible": "$getIsUrlClickedChecked",
						"labelConfig": {
							"visible": false
						},
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
						"wrapClass": ["no-caption-control"],
						"layout": {
							"column": 11,
							"row": 3,
							"colSpan": 9
						},
						"controlConfig": {
							"loadVocabulary": "$loadBulkEmailHyperlinkSchemaLookup"
						},
						"cleariconclick": "$onHyperlinksClearButtonClicked",
						"value": "$HyperlinkLookupCaption",
						"hint": "$getBulkEmailHyperlinksList"
					}
				},
				{
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"name": "IsEmailPuttedToSpam",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"caption": "$Resources.Strings.IsEmailPuttedToSpam",
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 22
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"name": "IsRecipientUnsubscribed",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsReactionModeWithConditions"
							}
						},
						"caption": "$Resources.Strings.IsRecipientUnsubscribed",
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 22
						}
					}
				},
				{
					"name": "IsRecipientReplied",
					"operation": "insert",
					"parentName": "DeliveredControlGroupLayout",
					"propertyName": "items",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": {
							"bindTo": "ReactionMode",
							"bindConfig": {
								converter: "getIsRecipientReplyEnabled"
							}
						},
						"caption": "$Resources.Strings.IsRecipientReplied",
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 22
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
