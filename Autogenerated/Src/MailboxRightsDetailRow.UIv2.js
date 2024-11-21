define("MailboxRightsDetailRow", ["MailboxRightsDetailRowResources"], function() {
	var rightOperationTypes = BPMSoft.RightsEnums.operationTypes;
	return {
		entitySchemaName: "EmailDefRights",
		attributes: {
			/**
			 * SysAdminUnit column.
			 * @type {Object}
			 */
			"SysAdminUnit": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				lookupListConfig: {
					filter: function() {
						return this.getMailboxOwnerFilter();
					}
				}
			},
			/**
			 * Is row in edit mode flag.
			 * @type {Boolean}
			 */
			"IsEditMode": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Is send from mailbox allowed flag.
			 * @type {Boolean}
			 */
			"SendAllowed": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Is mailbox content access allowed flag.
			 * @type {Boolean}
			 */
			"ContentAccessAllowed": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Is mailbox edit allowed flag.
			 * @type {Boolean}
			 */
			"MailboxEditAllowed": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Record operations array.
			 * @type {Object[]}
			 */
			"MailboxOperations": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Record operations array.
			 * @type {Object[]}
			 */
			"EmailDefRights": {
				dataValueType: this.BPMSoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Is row visible flag.
			 * @type {Boolean}
			 */
			"RowVisible": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
				value: true
			},
			/**
			 * Is row changes saved flag.
			 * @type {Boolean}
			 */
			"IsSaved": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN
			},
			/**
			 * Is row edit enabled flag.
			 * @type {Boolean}
			 */
			"IsEnabled": {
				dataValueType: this.BPMSoft.DataValueType.BOOLEAN
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Sets operation flags state.
			 * @private
			 */
			_setOperationFlags: function() {
				if (this.$MailboxOperations[rightOperationTypes.read]) {
					this.$SendAllowed = true;
				}
				if (this.$EmailDefRights[rightOperationTypes.read] || this.$EmailDefRights[rightOperationTypes.edit]) {
					this.$ContentAccessAllowed = true;
				}
				if (this.$MailboxOperations[rightOperationTypes.edit]) {
					this.$MailboxEditAllowed = true;
				}
			},

			/**
			 * Sets mailbox record right operation in operations array.
			 * @private
			 * @param{Integer} operation Operation code.
			 * @param {Object} operationConfig Operation configuration object.
			 */
			_setOperation: function(operation, operationConfig) {
				var config = this.$MailboxOperations[operation] || this._getNewMailboxOperation(operation);
				this.Ext.apply(config, operationConfig);
				this.$MailboxOperations[operation] = config;
			},

			/**
			 * Sets mailbox email default record operation in operations array.
			 * @private
			 * @param{Integer} operation Operation code.
			 * @param {Object} emailDefRight Email default record right operation configuration object.
			 */
			_setEmailOperation: function(operation, emailDefRight) {
				this.$EmailDefRights[operation] = emailDefRight;
			},

			/**
			 * Creates new mailbox record right operation.
			 * @private
			 * @param {Integer} operation Operation code.
			 * @return {Object} operationConfig Operation configuration object.
			 */
			_getNewMailboxOperation: function(operation) {
				return {
					"Id": this.BPMSoft.generateGUID(),
					"Operation": operation,
					"Position": 0,
					"RightLevel": this.BPMSoft.RightsEnums.rightLevels.allow.Value,
					"SysAdminUnit": this.BPMSoft.deepClone(this.$SysAdminUnit),
					"isDeleted": false,
					"isNew": true,
					"useDenyRights": false
				};
			},

			/**
			 * Sets mailbox record right operation values using current row state.
			 * @private
			 * @param {Object} operationConfig Operation configuration object.
			 */
			_setOperationValues: function(operationConfig) {
				operationConfig.isDeleted = !this._getMailboxOperationState(operationConfig.Operation)
					|| !this.$IsEnabled;
			},

			/**
			 * Returns current mailbox operation state.
			 * @private
			 * @param {Integer} operation Operation code.
			 * @return {Boolean} Current operation state.
			 */
			_getMailboxOperationState: function(operation) {
				if (operation === rightOperationTypes.read) {
						return this.$SendAllowed || this.$MailboxEditAllowed;
				}
				if (operation === rightOperationTypes.edit) {
						return this.$MailboxEditAllowed;
				}
			},

			/**
			 * Returns current mailbox email operation state.
			 * @private
			 * @return {Boolean} Current operation state.
			 */
			_getEmailOperationState: function() {
				return this.$ContentAccessAllowed;
			},

			/**
			 * Creates email default record right operation save query.
			 * @private
			 * @param {Integer} operation Operation code.
			 * @param {Guid} mailboxId Current mailbox unique identifier.
			 * @return {BPMSoft.InsertQuery|BPMSoft.UpdateQuery|BPMSoft.DeleteQuery|null} Email default record
			 * right operation save query.
			 */
			_getOperationSaveQuery: function(operation, mailboxId) {
				var emailDefRight = this.$EmailDefRights[operation];
				if (this.isEmpty(emailDefRight)) {
					if (this._getEmailOperationState(operation) && this.$IsEnabled) {
						return this._getInsertEmailDefRight(operation, mailboxId);
					} else {
						return null;
					}
				} else {
					if (!this._getEmailOperationState(operation) || !this.$IsEnabled) {
						return this._getDeleteEmailDefRight(emailDefRight);
					} else {
						return null;
					}
				}
			},

			/**
			 * Creates email default record right operation insert query.
			  * @private
			 * @param {Integer} operation Operation code.
			 * @param {Guid} mailboxId Current mailbox unique identifier.
			 * @return {BPMSoft.InsertQuery} Email default record right operation insert query.
			 */
			_getInsertEmailDefRight: function(operation, mailboxId) {
				var insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: "EmailDefRights"
				});
				insert.setParameterValue("Record", mailboxId, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("SysAdminUnit", this.$SysAdminUnit.value,
					this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue("Operation", operation, this.BPMSoft.DataValueType.INTEGER);
				insert.setParameterValue("Position", 0, this.BPMSoft.DataValueType.INTEGER);
				insert.setParameterValue("RightLevel", this.BPMSoft.RightsEnums.rightLevels.allow.Value,
					this.BPMSoft.DataValueType.INTEGER);
				return insert;
			},

			/**
			 * Creates email default record right operation delete query.
			 * @private
			 * @param {BPMSoft.BaseViewModel} emailDefRight Emaildefault record right operation instance.
			 * @return {BPMSoft.DeleteQuery} Email default record right operation delete query.
			 */
			_getDeleteEmailDefRight: function(emailDefRight) {
				var del = this.Ext.create("BPMSoft.DeleteQuery", {
					rootSchemaName: "EmailDefRights"
				});
				var filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(del.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Id", emailDefRight.$Id));
				del.filters = filters;
				return del;
			},

			//endregion

			//region Methods: Protected

			/**
			 * Sends changed event to show save settings button.
			 * @protected
			 */
			showSaveButton: function() {
				this.$IsSaved = false;
				this.fireEvent("changed", this);
			},

			/**
			 * Returns row container marker value.
			 * @protected
			 * @return {String} Row container marker value.
			 */
			getContainerMarkerValue: function() {
				return this.$SysAdminUnit && !this.$IsEditMode ? this.$SysAdminUnit.displayValue : "AddNewRight";
			},

			/**
			 * Creates mailbox owner filter for SysAdminUnit lookup.
			 * @protected
			 * @return {BPMSoft.FilterGroup} Mailbox owner filter.
			 */
			getMailboxOwnerFilter: function() {
				let selectedItems = this.sandbox.publish("GetSelectedAdminUnits", null, [this.sandbox.id]);
				let mailboxOwnerFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL,
					"Id", this.$MailboxOwner.value);
				let filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(mailboxOwnerFilter);
				const notInFilter = this.BPMSoft.createColumnInFilterWithParameters(
					"Id", selectedItems);
				notInFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				filters.addItem(notInFilter);
				return filters;
			},

			/**
			 * Checks is edit controls enabled in row.
			 * @protected
			 * @return {Boolean} Is edit controls enabled in row.
			 */
			getIsEnabled: function() {
				return this.isNotEmpty(this.$SysAdminUnit) && this.$IsEnabled;
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritDoc BPMSoft.core.mixins.EntityBaseViewModelMixin#getLookupQuery
			 * @overridden
			 */
			getLookupQuery: function() {
				var esq = this.callParent(arguments);
				esq.filters.addItem(this.getMailboxOwnerFilter());
				return esq;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSchemaViewModel#constructor.
			 * @overridden
			 */
			constructor: function() {
				this.addEvents(
					/**
					 * @event
					 * Record operation add canceled event.
					 */
					"cancel",
					/**
					 * @event
					 * Record operation changed event.
					 */
					"changed",
					/**
					 * @event
					 * Record operation saved event.
					 */
					"saved"
				);
				this.$MailboxOperations = [];
				this.$EmailDefRights = [];
				this.callParent(arguments);
			},

			/**
			 * Save button click handler.
			 */
			onSave: function(value) {
				if (this.isEmpty(this.$SysAdminUnit) && this.isEmpty(value)) {
					return;
				}
				this.$IsEditMode = false;
				this.fireEvent("saved", this);
			},

			/**
			 * Cancel button click handler. Fires "cancel" event.
			 */
			onCancel: function() {
				if (!this.getIsEnabled()) {
					this.fireEvent("cancel", this);
				}
			},

			/**
			 * Delete button click handler.
			 */
			deleteRow: function() {
				this.$SendAllowed = false;
				this.$ContentAccessAllowed = false;
				this.$MailboxEditAllowed = false;
				this.$RowVisible = false;
				this.onCancel();
				this.showSaveButton();
			},

			/**
			 * Sets mailbox record right operation in operations array.
			 * @param {Object} data Mailbox record right operation configuration object.
			 */
			setMailboxOperation: function(data) {
				var operationConfig = this.BPMSoft.deepClone(data);
				this._setOperation(operationConfig.Operation, operationConfig);
				this._setOperationFlags();
			},

			/**
			 * Sets mailbox email default record right operation in operations array.
			 * @param {BPMSoft.BaseViewModel} emailDefRight Email default record right operation instance.
			 */
			setEmailOperation: function(emailDefRight) {
				this._setEmailOperation(emailDefRight.$Operation, emailDefRight);
				this._setOperationFlags();
			},

			/**
			 * Returns current mailbox record right operations objects array.
			 * @return {Object[]} Current mailbox record right operations.
			 */
			getMailboxOperations: function() {
				var result = [];
				if (this.isEmpty(this.$SysAdminUnit) || this.$IsSaved || !this.$IsEnabled) {
					return result;
				}
				this.BPMSoft.each([rightOperationTypes.read, rightOperationTypes.edit], function(operation) {
					var operationConfig = this.$MailboxOperations[operation] || this._getNewMailboxOperation(operation);
					this._setOperationValues(operationConfig);
					if (!operationConfig.isNew || !operationConfig.isDeleted) {
						result.push(operationConfig);
					}
				}, this);
				return result;
			},

			/**
			 * Creates email default record right operations save queries array.
			 * @return {BPMSoft.BaseQuery[]} Email default record right operations save queries.
			 */
			getEmailDefRightsSaveQueries: function(mailboxId) {
				var result = [];
				if (this.isEmpty(this.$SysAdminUnit) || this.$IsSaved) {
					return result;
				}
				this.BPMSoft.each([rightOperationTypes.read, rightOperationTypes.edit], function(operation) {
					var emailDefRightQuery = this._getOperationSaveQuery(operation, mailboxId);
					if (this.isNotEmpty(emailDefRightQuery)) {
						result.push(emailDefRightQuery);
					}
				}, this);
				return result;
			}

			//endregion
		},
		diff: [
			{
				"operation": "insert",
				"name": "AdminRightsContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"markerValue": {"bindTo": "getContainerMarkerValue"},
					"visible": {"bindTo": "RowVisible"},
					"wrapClass": ["admin-rights-container"]
				}
			}, {
				"operation": "insert",
				"name": "AdminRightsDisplayContainer",
				"parentName": "AdminRightsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["admin-rights-display-container"]
				}
			},
			{
				"operation": "insert",
				"name": "SysAdminUnitLabelContainer",
				"parentName": "AdminRightsDisplayContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["label-display-container"]
				}
			},	
			{
				"operation": "insert",
				"name": "SysAdminUnit",
				"parentName": "SysAdminUnitLabelContainer",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"focused": true,
					"enabled": {"bindTo": "IsEnabled"},
					"change": {"bindTo": "onSave"},
					"wrapClass": ["admin-unit-lookup"],
					"visible": {
						"bindTo": "SysAdminUnit",
						"bindConfig": {
							"converter": function(value) {
								return Ext.isEmpty(value);
							}
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "SysAdminUnitName",
				"parentName": "SysAdminUnitLabelContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "SysAdminUnit"},
					"classes": {
						"labelClass": ["controlCaption"]
					},
					"visible": {
						"bindTo": "SysAdminUnit",
						"bindConfig": {
							"converter": function(value) {
								return !Ext.isEmpty(value);
							}
						}
					}
				}
			}, {
				"operation": "insert",
				"name": "DeleteRowButton",
				"parentName": "SysAdminUnitLabelContainer",
				"propertyName": "items",
				"values": {
					"click": {"bindTo": "deleteRow"},
					"itemType": this.BPMSoft.ViewItemType.BUTTON,
					"classes": {
						"imageClass": ["button-background-no-repeat"]
					},
					"imageConfig": {
						"bindTo": "Resources.Images.DeleteRowIcon"
					},
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"enabled": {"bindTo": "IsEnabled"}
				}
			}, 
			{
				"operation": "insert",
				"name": "CheckBoxDisplayContainer",
				"parentName": "AdminRightsDisplayContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["checkbox-display-container"]
				}
			},
			{
				"operation": "insert",
				"name": "MailboxEditAllowedCheckbox",
				"parentName": "CheckBoxDisplayContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "MailboxEditAllowed",
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"labelConfig": {"visible": false},
					"controlConfig": {
						"checkedchanged": {"bindTo": "showSaveButton"},
						"enabled": {"bindTo": "getIsEnabled"}
					},
					"classes": {
						"wrapClassName": ["rights-checkbox"]
					}
				}
			}, {
				"operation": "insert",
				"name": "SendAllowedCheckbox",
				"parentName": "CheckBoxDisplayContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "SendAllowed",
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"labelConfig": {"visible": false},
					"controlConfig": {
						"checkedchanged": {"bindTo": "showSaveButton"},
						"enabled": {"bindTo": "getIsEnabled"}
					},
					"classes": {
						"wrapClassName": ["rights-checkbox"]
					}
				}
			}, {
				"operation": "insert",
				"name": "ContentAccessAllowedCheckbox",
				"parentName": "CheckBoxDisplayContainer",
				"propertyName": "items",
				"values": {
					"bindTo": "ContentAccessAllowed",
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"labelConfig": {"visible": false},
					"controlConfig": {
						"checkedchanged": {"bindTo": "showSaveButton"},
						"enabled": {"bindTo": "getIsEnabled"}
					},
					"classes": {
						"wrapClassName": ["rights-checkbox"]
					}
				}
			}]
	};
});
