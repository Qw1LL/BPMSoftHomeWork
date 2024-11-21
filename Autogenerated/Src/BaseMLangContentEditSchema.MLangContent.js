define("BaseMLangContentEditSchema", ["ConfigurationEnums", "EmailTemplateMLangContentBuilderEnumsModule", "ESNHtmlEditModule"], function(ConfigurationEnums, EmailTemplateMLangContentBuilderEnumsModule) {
	return {
		attributes: {
			/**
			 * Indicates is template data loaded.
			 */
			"IsTemplateDataLoaded": {
				"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		diff: [],
		messages: {
			/**
			 * @message SaveRecord
			 * Save record.
			 * @type {Object}
			 */
			"SaveRecord": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message UpdateCardProperty
			 * Sets attributes for card.
			 * @type {Object}
			 */
			"UpdateCardProperty": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message ValidateCard
			 * Run validate process and returns true if card valid.
			 */
			"ValidateCard": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetColumnsValues
			 * Returns requested column values.
			 */
			"GetColumnsValues": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message UpdateMultilingualColumnsValues
			 * Sets column values.
			 */
			"UpdateMultilingualColumnsValues": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message LanguageTabsChanged
			 * Language collection was changed.
			 */
			"LanguageTabsChanged": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetCardState
			 * Returns card state
			 */
			"GetCardState": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Return entity schema query.
			 * @returns {BPMSoft.EntitySchemaQuery} Entity schema query.
			 * @private
			 */
			_getMultilingualQuery: function() {
				var parameters = this.get("parameters");
				var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: parameters.sourceEntitySchemaName
				});
				esq.addColumn("Id", "RowId");
				BPMSoft.each(parameters.columnList, function(column){
					esq.addColumn(column.name);
				}, this);
				if (parameters.isDefaultLanguage) {
					esq.filters.add("IdFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Id", parameters.recordId)
					);
				} else {
					esq.filters.add("ParentEntityFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, parameters.multilingualConnectionColumnName,
							parameters.recordId));
					esq.filters.add("LanguageFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Language", parameters.languageId));
				}
				return esq;
			},

			/**
			 * Indicates the completion of data initialization on templates.
			 * @private
			 */
			_tplDataLoaded: function() {
				this.set("IsTemplateDataLoaded", true, { silent: true });
			},

			//endregion

			//region Methods: Protected

			/**
			 * Return content builder url.
			 * @protected
			 * @virtual
			 */
			getContentBuilderUrl: function(contentBuilderMode, recordId, tag) {
				return EmailTemplateMLangContentBuilderEnumsModule.getContentBuilderUrl(
					contentBuilderMode, recordId, tag);
			},

			/**
			 * Returns content builder mode.
			 * @protected
			 * @virtual
			 */
			getContentBuilderMode: function(isMultilingual) {
				return isMultilingual
					? EmailTemplateMLangContentBuilderEnumsModule.ContentBuilderMode.EMAILTEMPLATELANG
					: EmailTemplateMLangContentBuilderEnumsModule.ContentBuilderMode.EMAILTEMPLATE;
			},

			/**
			 * Use sendChangedValues instead of this method.
			 * @param {Object} value Column value.
			 * @param {Object} tag Column name.
			 * @protected
			 * @obsolete
			 * @virtual
			 */
			updateMLangEntityValue: function(value, tag) {
				var update = Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: this.get("parameters").sourceEntitySchemaName
				});
				update.enablePrimaryColumnFilter(this.get("RowId"));
				update.setParameterValue(tag, value, BPMSoft.DataValueType.TEXT);
				update.execute();
			},

			/**
			 * Sets property value to the card.
			 * @param {String} value Property value.
			 * @param {String} key Property key.
			 * @param {Object} [options] Set options.
			 * @protected
			 * @virtual
			 */
			updateCardProperty: function(value, key, options) {
				this.sandbox.publish("UpdateCardProperty", {
					key: key,
					value: value,
					options: options
				}, [this.getPageSandboxId()]);
			},


			/**
			 * Save card.
			 * @public
			 * @returns {Boolean} Is saved.
			 */
			saveCard: function() {
				var sandboxId = this.getPageSandboxId();
				var args = {
					isSilent: true,
					messageTags: [sandboxId]
				};
				if (this.sandbox.publish("ValidateCard", args, [sandboxId])) {
					this.sandbox.publish("SaveRecord", args, [sandboxId]);
					return true;
				}
				return false;
			},

			/**
			 * Returns page sandbox identifier.
			 * @protected
			 * @virtual
			 * @returns {string} Sandbox identifier.
			 */
			getPageSandboxId: function() {
				return this.sandbox.id.substring(0, this.sandbox.id.lastIndexOf("_"));
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
						this.onChannelMessage, this);
			},

			/**
			 * On channel message event handler.
			 * @param {Object} channel Channel.
			 * @param {Object} message Channel message.
			 * @protected
			 * @virtual
			 */
			onChannelMessage: function(channel, message) {
				if (this.Ext.isEmpty(message)) {
					return;
				}
				var header = message.Header;
				if (!(header.Sender === this.getContentBuilderMode(false) ||
						header.Sender === this.getContentBuilderMode(true))) {
					return;
				}
				var messageObject = this.BPMSoft.decode(message.Body || "{}");
				var parameters = this.get("parameters");
				var primaryColumnValue;
				if(!this.getIsFeatureEnabled("MultiLanguageContentBuilderEnabled")) {
					var isDefaultLanguage = parameters.isDefaultLanguage;
					primaryColumnValue = isDefaultLanguage ? parameters.recordId : parameters.multilingualRecordId;
				} else {
					primaryColumnValue = parameters.recordId;
				}
				if (messageObject.recordId !== primaryColumnValue) {
					return;
				}
				if(!this.getIsFeatureEnabled("MultiLanguageContentBuilderEnabled")) {
					this.loadColumnValuesFromDb();
				} else {
					this.sandbox.publish("LanguageTabsChanged", {}, [this.getPageSandboxId()]);
				}
			},

			/**
			 * Load columns values fom data base.
			 * @virtual
			 */
			loadColumnValuesFromDb: function() {
				var esq = this._getMultilingualQuery();
				esq.getEntityCollection(function(result) {
					if (result.success) {
						var resultEntity = result.collection.getByIndex(0);
						var parameters =  this.get("parameters");
						this.set("RowId", parameters.multilingualRecordId);
						this.BPMSoft.each(parameters.columnList, function(column) {
							this.set(column.name, resultEntity.get(column.name));
							if(!parameters.isDefaultLanguage){
								this.sendChangedValues(resultEntity.get(column.name), column.name);
							}
						}, this);
					}
				}, this);
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#onRender
			 * @overridden
			 */
			onRender: function() {
				this.callParent(arguments);
				var state = this.sandbox.publish("GetCardState", null, [this.getPageSandboxId()]);
				if (state.state === ConfigurationEnums.CardStateV2.COPY) {
					this.loadCopyValues();
					return;
				}
				this.loadColumnValues();
			},

			/**
			 * Load entity schema copied column values.
			 * @protected
			 * @virtual
			 */
			loadCopyValues: function() {
				var parameters = this.get("parameters");
				this.set("RowId", parameters.recordId);
				this.BPMSoft.each(parameters.copyValues, function(column) {
					this.set(column.name, column.value);
				}, this);
				this._tplDataLoaded();
			},

			/**
			 * Load entity schema column values.
			 * @protected
			 * @virtual
			 */
			loadColumnValues: function() {
				var parameters =  this.get("parameters");
				var multiLanguageContent = parameters.multiLanguageContent;
				if(!parameters.multiLanguageContent) {
					this.loadColumnValuesFromDb();
				} else {
					this.BPMSoft.each(parameters.columnList, function(column) {
						var contentValue = multiLanguageContent.find(function(item) {
							return item.name === column.name;
						});
						this.set(column.name, contentValue.value);
					}, this);
				}
				this._tplDataLoaded();
			},

			//endregion

			//region Methods: Public

			/**
			 * On edit button click event handler.
			 * @public
			 */
			onEditButtonClick: function() {
				var tag = arguments[3];
				var parameters = this.get("parameters");
				var isDefaultLanguage = parameters.isDefaultLanguage;
				var contentBuilderMode;
				var recordId;
				if (this.getIsFeatureEnabled("MultiLanguageContentBuilderEnabled") || isDefaultLanguage) {
					recordId = parameters.recordId;
				} else {
					recordId = parameters.multilingualRecordId;
				}
				if (!this.saveCard()) {
					return;
				}
				if(this.getIsFeatureEnabled("MultiLanguageContentBuilderEnabled") || isDefaultLanguage) {
					contentBuilderMode = this.getContentBuilderMode(false);
				} else {
					contentBuilderMode = this.getContentBuilderMode(true);
				}
				var contentBuilderUrl = this.getContentBuilderUrl(contentBuilderMode, recordId, tag);
				window.open(contentBuilderUrl);
			},

			/**
			 * Send updated column values into card.
			 * @param {Object} value Column value.
			 * @param {String} tag Column name.
			 * @protected
			 */
			sendChangedValues: function(value, tag) {
				var params = this.get("parameters");
				var multilingualColumn = {
					"name": tag,
					"value": value
				};
				this.sandbox.publish("UpdateMultilingualColumnsValues", {
					"languageId": params.languageId,
					"multilingualColumn": multilingualColumn
				}, [this.getPageSandboxId()]);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSchemaModule#destroy
			 * @overridden
			 */
			destroy: function() {
				this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE, this.onChannelMessage, this);
				this.callParent(arguments);
			},

			/**
			 * Control value changed action.
			 * @param {Object} value Column value.
			 * @param {Object} tag Column name.
			 * @public
			 */
			onControlValueChanged: function(value, tag) {
				if (!this.get("IsTemplateDataLoaded")) {
					return;
				}
				var parameters = this.get("parameters");
				var isDefaultLanguage = parameters.isDefaultLanguage;
				if (isDefaultLanguage) {
					this.updateCardProperty(value, tag);
		 			this.sendChangedValues(value, tag);
				} else {
					this.sendChangedValues(value, tag);
				}
			}

			//endregion

		}
	};
});
