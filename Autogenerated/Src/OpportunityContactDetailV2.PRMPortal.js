define("OpportunityContactDetailV2", [],
	function() {
		return {
			entitySchemaName: "OpportunityContact",
			attributes: {
				"CustomColumnLinkHandlers": {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},
				/**
				 * Indicates that the user has SSP connection.
				 */
				"IsSspUser": {
					"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
					"value": BPMSoft.isCurrentUserSsp()
				},

				/**
				 * Open card method pointer to execute after master card saved.
				 */
				"OpenCardMethod": {
					"dataValueType": this.BPMSoft.DataValueType.OBJECT
				}
			},
			messages: {
				/**
				 * @message ContactSaved
				 * Notification when contact was changed and saved.
				 * @param {String} contactId Identifier of saved contact.
				 */
				"ContactSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function() {
					this._initCustomColumnLinkHandlers();
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
				 * @override
				 */
				subscribeSandboxEvents: function() {
					this.sandbox.subscribe("ContactSaved", this.onContactSaved, this, [this.sandbox.id]);
					this.callParent(arguments);
				},

				/**
				 * Opens page with created new contact.
				 * @param {Object} result Result of saving contact.
				 */
				onContactSaved: function(result) {
					if (result.CardMode === BPMSoft.ConfigurationEnums.CardOperation.ADD) {
						this.openContactInOpportunityPage(result.Id);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @override
				 */
				getAddRecordButtonVisible: function() {
					return this.$IsSspUser ? false : this.callParent(arguments);
				},

				/**
				 * AddContactButton button Click handler.
				 */
				onAddContactButtonClick: function() {
					this.saveMasterCard(this.openContactLookup, this);
				},

				/**
				 * CreateContactButton button Click handler.
				 */
				onCreateContactButtonClick: function() {
					this.saveMasterCard(this.createContactClick, this);
				},

				/**
				 * Save master card.
				 * @param {Function|null} callback Callback function on success master card saving.
				 * @param {Object|null} scope Scope for callback function.
				 */
				saveMasterCard: function(callback, scope) {
					if (!this.getIsCardValid()) {
						return;
					}
					const isNewCard = this.getIsCardNewRecordState();
					const isCardChanged = this.getIsCardChanged();
					if (isNewCard || isCardChanged) {
						const args = {
							isSilent: true,
							messageTags: [this.sandbox.id]
						};
						this.set("OpenCardMethod", callback);
						this.sandbox.publish("SaveRecord", args, [this.sandbox.id]);
					} else {
						Ext.callback(callback, scope || this);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#onCardSaved
				 * @override
				 */
				onCardSaved: function() {
					if (!this.get("IsSspUser")) {
						this.callParent(arguments);
						return;
					}
					const callback = this.get("OpenCardMethod");
					Ext.callback(callback, this);
				},

				/**
				 * Open lookup for contact choosing to add new record.
				 */
				openContactLookup: function() {
					const opportunityAccount = this.sandbox.publish("GetColumnsValues", ["Account"], [this.sandbox.id]);
					const lookupConfig = {
						entitySchemaName: "Contact",
						multiSelect: false,
						hideActions: true
					};
					if (opportunityAccount && opportunityAccount.Account && opportunityAccount.Account.value) {
						lookupConfig.filters = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Account", opportunityAccount.Account.value);
					}
					this.openLookup(lookupConfig, this.openContactInOpportunityPageWithSelectedContact, this);
				},

				/**
				 * Opens page with selected contact.
				 * @param {Object} result Lookup result.
				 * @param {BPMSoft.Collection} result.selectedRows Selected rows collection.
				 */
				openContactInOpportunityPageWithSelectedContact: function(result) {
					const item = result.selectedRows.first();
					const contactId = item && item.Id;
					this.openContactInOpportunityPage(contactId);
				},

				/**
				 * Opens page with contact.
				 * @param {Mixed} contactId Contact identifier.
				 * @protected
				 */
				openContactInOpportunityPage: function(contactId) {
					const opportunityContactValues = [];
					if (this.isNotEmpty(contactId)) {
						opportunityContactValues.push({
							"name": "Contact",
							"value": contactId
						});
					}
					opportunityContactValues.push({
						"name": "Opportunity",
						"value": this.$MasterRecordId
					});
					const config = {
						"schemaName": "OpportunityContactPageV2",
						"moduleId": this._getOpportunityContactPageId(),
						"isSeparateMode": false,
						"operation": this.BPMSoft.ConfigurationEnums.CardOperation.ADD,
						"defaultValues": opportunityContactValues
					};
					this.sandbox.publish("OpenCard", config, [this.sandbox.id]);
				},

				/**
				 * @private
				 */
				_initCustomColumnLinkHandlers: function() {
					const linkHandlersCollection = this.Ext.create("BPMSoft.Collection");
					linkHandlersCollection.add("Contact", "onContactLinkClick");
					this.set("CustomColumnLinkHandlers", linkHandlersCollection);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addColumnLink
				 * @override
				 */
				addColumnLink: function(item, column) {
					if (!this.BPMSoft.isCurrentUserSsp()) {
						this.callParent(arguments);
						return;
					}
					const columnPath = column.columnPath;
					const handlers = this.get("CustomColumnLinkHandlers");
					const columnHandler = handlers.find(columnPath);
					if (this.isEmpty(columnHandler)) {
						this.callParent(arguments);
					} else {
						item[columnHandler] = function() {
							const value = this.get(columnPath);
							return {
								caption: value,
								target: "_self",
								title: value,
								url: window.location.hash
							};
						};
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#linkClicked
				 * @override
				 */
				linkClicked: function(rowId, columnName) {
					if (this.BPMSoft.isCurrentUserSsp() && this._tryCallCustomColumnHandler(rowId, columnName)) {
						return false;
					}
					return this.callParent(arguments);
				},

				/**
				 * @private
				 */
				_tryCallCustomColumnHandler: function(rowId, columnName) {
					const handlers = this.get("CustomColumnLinkHandlers");
					const columnHandler = handlers.find(columnName);
					let result = false;
					if (this.isNotEmpty(columnHandler) && this.Ext.isFunction(this[columnHandler])) {
						this[columnHandler](rowId, columnName);
						result = true;
					}
					return result;
				},

				/**
				 * Handles click on contact row.
				 * @param {Guid} rowId Row identifier.
				 */
				onContactLinkClick: function(rowId) {
					const data = this.getGridData();
					const row = data.get(rowId);
					this.$RecordToReload = row.$Id;
					this.openContactMiniPage(this.BPMSoft.ConfigurationEnums.CardOperation.EDIT, row.$Contact.value);
				},

				/**
				 * Open mini page for creating contact.
				 */
				createContactClick: function() {
					this.openContactMiniPage(this.BPMSoft.ConfigurationEnums.CardOperation.ADD);
				},

				/**
				 * Opens contact mini page.
				 * @param {BPMSoft.ConfigurationEnums.CardOperation} operation Opening operation.
				 * @param {Guid} [recordId] Row identifier.
				 */
				openContactMiniPage: function(operation, recordId) {
					const config = {
						entitySchemaName: "Contact",
						operation: operation
					};
					if (this.isNotEmpty(recordId)) {
						config.recordId = recordId;
					}
					this.openMiniPage(config);
				},

				/**
				 * Add RecordToReload to defaultValues if it is needed.
				 * @param {Array} defaultValues Default values array.
				 */
				addRecordToReloadDefaultValue: function(defaultValues) {
					if (this.isNotEmpty(this.$RecordToReload)) {
						defaultValues.push({
							RecordToReload: this.$RecordToReload
						});
					}
				},

				/**
				 * Add default values from parent page.
				 * @param {Array} defaultValues Default values array.
				 */
				addOpportunityDefaultValues: function(defaultValues) {
					const opportunityValues = this.sandbox.publish("GetColumnsValues", ["Account"], [this.sandbox.id]);
					if (opportunityValues && opportunityValues.Account && opportunityValues.Account.value) {
						defaultValues.push({
							"name": "Account",
							"value": opportunityValues.Account.value
						});
					}
				},

				/**
				 * Creates default values for contact mini page.
				 * @return {Array} Default values for contact page.
				 */
				setupDefaultValues: function() {
					const defaultValues = [];
					this.addRecordToReloadDefaultValue(defaultValues);
					this.addOpportunityDefaultValues(defaultValues);
					return defaultValues;
				},

				/**
				 * @inheritdoc BPMSoft.MiniPageUtilities#openMiniPage
				 * @override
				 */
				openMiniPage: function(config) {
					if (this.BPMSoft.isCurrentUserSsp() &&
							(config.columnName === "Contact" || config.entitySchemaName === "Contact")) {
						config.miniPageSchemaName = "PortalContactMiniPage";
						config.showDelay =
							config.operation === this.BPMSoft.ConfigurationEnums.CardOperation.EDIT ? 0 : 3000;
						config.valuePairs = this.setupDefaultValues();
					}
					this.callParent(arguments);
				},

				/**
				 * @private
				 */
				_getOpportunityContactPageId: function() {
					return this.sandbox.id + "_OpportunityContactPageV2";
				},

				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#getUpdateDetailSandboxTags
				 * @override
				 */
				getUpdateDetailSandboxTags: function() {
					const tags = this.callParent(arguments);
					tags.push(this._getOpportunityContactPageId());
					return tags;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "AddRecord",
					"parentName": "Detail",
					"propertyName": "tools",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"menu": [],
						"imageConfig": {"bindTo": "Resources.Images.AddButtonImage"},
						"visible": {
							"bindTo": "IsSspUser"
						}
					}
				},
				{
					"operation": "insert",
					"name": "AddContactButton",
					"parentName": "AddRecord",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SelectContactCaption"},
						"click": {"bindTo": "onAddContactButtonClick"}
					}
				},
				{
					"operation": "insert",
					"name": "CreateContactButton",
					"parentName": "AddRecord",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.NewContactCaption"},
						"click": {"bindTo": "onCreateContactButtonClick"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
