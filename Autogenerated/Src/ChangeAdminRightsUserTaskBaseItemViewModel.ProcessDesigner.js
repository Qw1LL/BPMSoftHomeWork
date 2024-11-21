define("ChangeAdminRightsUserTaskBaseItemViewModel", ["Contact", "SysAdminUnit",
	"ProcessUserTaskConstants", "ProcessSchemaUserTaskUtilities", "ProcessMiniEditPageMixin"
], function(Contact, SysAdminUnit, processUserTaskConstants, processSchemaUserTaskUtilities) {

	/**
	 * Rights view model for the change admin rights user task.
	 */
	Ext.define("BPMSoft.model.ChangeAdminRightsUserTaskBaseItemViewModel", {
		extend: "BPMSoft.BaseModel",
		alternateClassName: "BPMSoft.ChangeAdminRightsUserTaskBaseItemViewModel",

		Ext: null,
		BPMSoft: null,
		sandbox: null,

		mixins: {
			processMiniEditPageMixin: "BPMSoft.ProcessMiniEditPageMixin"
		},

		columns: {
			"Id": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			"Name": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			"CanRead": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			"CanEdit": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			"CanDelete": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			"Source": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				value: BPMSoft.ProcessSchemaParameterValueSource.ConstValue
			},

			"Grantee": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				value: processUserTaskConstants.ChangeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS
			},

			"Value": {
				dataValueType: BPMSoft.DataValueType.MAPPING
			},

			"Visible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			"ParameterEditToolsButtonMenu": {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				value: Ext.create("BPMSoft.BaseViewModelCollection")
			},

			"packageUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			"ProcessElement": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Entity schema uId.
			 */
			"EntitySchemaUId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Current operation.
			 */
			"Operation": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Collection of opposite operation view models.
			 */
			"OppositeRightsCollection": {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Parent module instance.
			 */
			"ParentModule": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Item uId.
			 */
			"uId": {
				dataValueType: BPMSoft.DataValueType.GUID
			}
		},

		// region Methods: Private

		/**
		 * Returns object with value and displayValue properties.
		 * @private
		 * @param {Object} collection Enum object.
		 * @param {String} value Value.
		 * @return {Object} Value and displayValue.
		 */
		getValueFromEnum: function(collection, value) {
			var result = {};
			this.BPMSoft.each(collection, function(item) {
				if (item.value === value) {
					result = item;
					return false;
				}
			}, this);
			return result;
		},

		/**
		 * Generates name for new parameter.
		 * @private
		 * @param {BPMSoft.Collection} collection parameters.
		 * @param {String} prefix Prefix of new parameter name.
		 * @return {String} Name of new parameter.
		 */
		getParameterName: function(collection, prefix) {
			var filterFn = function(item, name) {
				var accept = item.name === name;
				return accept;
			};
			var itemName = processSchemaUserTaskUtilities.generateItemUniqueName(prefix, collection, filterFn);
			return itemName;
		},

		/**
		 * Generates caption for new parameter.
		 * @private
		 * @param {BPMSoft.Collection} collection parameters.
		 * @param {String} prefix Prefix of new parameter caption.
		 * @return {String} Caption of new parameter.
		 */
		getParameterCaption: function(collection, prefix) {
			var filterFn = function(item, name) {
				var caption = item.caption;
				var accept = caption.getValue() === name;
				return accept;
			};
			var itemCaption = processSchemaUserTaskUtilities.generateItemUniqueName(prefix, collection, filterFn);
			return itemCaption;
		},

		/**
		 * Returns loaded mini edit page Id.
		 * @private
		 * @return {String} Loaded mini edit page Id.
		 */
		getOpenedEditPageModuleId: function() {
			var operation = this.get("Operation");
			var suffix = operation === processUserTaskConstants.ChangeAdminRightsUserTaskOperation.ADD
				? processUserTaskConstants.ChangeAdminRightsUserTaskOperation.DELETE
				: processUserTaskConstants.ChangeAdminRightsUserTaskOperation.ADD;
			return Ext.String.format("{0}{1}{2}", this.sandbox.id, suffix.toLowerCase(), "edit");
		},

		/**
		 * Updates name attribute if displayValue is lookup value.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Object} scope Environment object callback function.
		 */
		updateNameValue: function(callback, scope) {
			var utils = BPMSoft.FormulaParserUtils;
			var value = this.get("Value");
			var parameterRegex = BPMSoft.process.constants.PARAMETER_REGEX;
			var match = parameterRegex.exec(value.value);
			parameterRegex.lastIndex = 0;
			if (match && match.length === 2) {
				var macrosBody = match[1];
				if (utils.getIsLookupMappingValue(macrosBody)) {
					var packageUId = this.get("packageUId");
					BPMSoft.FormulaParserUtils.getLookupDisplayValue(macrosBody, packageUId, function(result) {
						this.set("Name", result.value);
						callback.call(scope);
					}, this);
					return;
				}
			}
			callback.call(scope);
		},

		/**
		 * Returns edit item menu visible.
		 * @private
		 * @return {Boolean}
		 */
		getEditMenuItemVisible: function() {
			var grantee = this.get("Grantee").value;
			var allRolesAndUsers = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS;
			var itemVisible = grantee !== allRolesAndUsers.value;
			return itemVisible;
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc BPMSoft.ProcessMiniEditPageMixin#closeOpenedEditPage
		 * @override
		 */
		closeOpenedEditPage: function(openedItemId) {
			this.mixins.processMiniEditPageMixin.closeOpenedEditPage.apply(this, arguments);
			var oppositeRightsCollection = this.get("OppositeRightsCollection");
			if (!oppositeRightsCollection.contains(openedItemId)) {
				return;
			}
			var item = oppositeRightsCollection.get(openedItemId);
			item.set("Visible", true);
			this.set(this.getActiveItemId(), null);
			if (item.get("IsNew")) {
				oppositeRightsCollection.removeByKey(openedItemId);
			}
			var pageId = this.getOpenedEditPageModuleId();
			this.sandbox.unloadModule(pageId);
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#saveItemInfo
		 * @override
		 */
		saveItemInfo: function(itemInfo) {
			this.mixins.processMiniEditPageMixin.saveItemInfo.call(this, itemInfo);
			var element = this.get("ProcessElement");
			var filterGrantee = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee.DATA_SOURCE_FILTER;
			var allRolesAndUsers = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS;
			var grantee = this.get("Grantee");
			if (filterGrantee !== grantee && allRolesAndUsers !== grantee &&
				!element.findParameterByUId(this.get("Id"))) {
				this.addParameter();
			}
			this.updateNameValue(function() {
				var source = this.BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
				if (grantee !== filterGrantee && grantee !== allRolesAndUsers) {
					var value = this.get("Value");
					source = this.Ext.isObject(value) ? value.source : source;
				}
				this.set("Source", source);
			}, this);
		},

		/**
		 * Adds parameter to element.
		 * @protected
		 */
		addParameter: function() {
			var elementParameter = this.createParameter();
			var element = this.get("ProcessElement");
			elementParameter.processFlowElementSchema = element;
			element.parameters.add(elementParameter.uId, elementParameter);
		},

		/**
		 * Creates process parameter.
		 * @protected
		 * @return {BPMSoft.ProcessSchemaParameter} Process element parameter.
		 */
		createParameter: function() {
			var parameterName = "";
			var referenceSchemaUId = "";
			var element = this.get("ProcessElement");
			var parentSchema = element.parentSchema;
			var processSchemaUId = parentSchema.uId;
			var parameters = element.parameters;
			var grantee = this.get("Grantee");
			var consts = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee;
			var parameterCaption = this.getParameterCaption(parameters, grantee.displayValue);
			if (grantee === consts.ROLE) {
				parameterName = this.getParameterName(parameters, "Role");
				referenceSchemaUId = SysAdminUnit.uId;
			} else {
				parameterName = this.getParameterName(parameters, "Employee");
				referenceSchemaUId = Contact.uId;
			}
			var parameterMetaData = {
				uId: this.get("Id"),
				caption: Ext.create("BPMSoft.LocalizableString", {
					cultureValues: parameterCaption
				}),
				createdInSchemaUId: processSchemaUId,
				modifiedInSchemaUId: processSchemaUId,
				referenceSchemaUId: referenceSchemaUId,
				name: parameterName,
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				sourceValue: {
					value: "",
					source: this.BPMSoft.ProcessSchemaParameterValueSource.None,
					displayValue: Ext.create("BPMSoft.LocalizableString", {
						cultureValues: ""
					})
				}
			};
			var elementParameter = this.Ext.create("BPMSoft.ProcessSchemaParameter", parameterMetaData);
			return elementParameter;
		},

		/**
		 * Converts view model attributes to server object.
		 * @protected
		 */
		convertViewModelAttributesToServerObject: function() {
			var grantee = this.get("Grantee") || {};
			var granteeValue = this.Ext.isObject(grantee) ? grantee.value : null;
			var source = this.get("Source") || "";
			var value = this.get("Value") || "";
			value = this.Ext.isObject(value) ? value.value : value;
			var result = {
				"Id": this.get("Id"),
				"ParameterName": this.get("ParameterName"),
				"Name": this.get("Name"),
				"CanRead": this.get("CanRead"),
				"CanEdit": this.get("CanEdit"),
				"CanDelete": this.get("CanDelete"),
				"Source": source.toString(),
				"Grantee": granteeValue,
				"Value": value
			};
			return result;
		},

		/**
		 * Convert server object to view model attributes.
		 * @protected
		 * @param {Object} values Object.
		 */
		convertServerObjectToViewModelAttributes: function(values) {
			var grantee = this.getValueFromEnum(processUserTaskConstants.ChangeAdminRightsUserTaskGrantee,
				values.Grantee);
			var element = this.get("ProcessElement");
			var parameter = Ext.isEmpty(values.ParameterName)
				? element.findParameterByUId(values.Id)
				: element.findParameterByName(values.ParameterName);
			var id = parameter && parameter.uId || values.Id;
			this.set("Id", id);
			this.set("Name", values.Name);
			this.set("ParameterName", parameter && parameter.name);
			this.set("OldName", values.Name);
			this.set("CanRead", values.CanRead);
			this.set("CanEdit", values.CanEdit);
			this.set("CanDelete", values.CanDelete);
			this.set("Source", values.Source);
			this.set("Grantee", grantee);
			this.set("Value", values.Value);
			this.set("ParentCollection", this.parentCollection);
			this.initValue();
		},

		/**
		 * Returns whether view model use mapping control edit.
		 * @protected
		 * @return {Boolean}
		 */
		isMapping: function() {
			var grantee = this.get("Grantee");
			var granteeValue = grantee.value;
			var granteeType = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee;
			var isMapping = (granteeValue === granteeType.ROLE.value) ||
				(granteeValue === granteeType.EMPLOYEE.value);
			return isMapping;
		},

		/**
		 * Initialize Value attribute.
		 * @protected
		 */
		initValue: function() {
			var isMapping = this.isMapping();
			if (isMapping) {
				var processElement = this.get("ProcessElement");
				var id = this.get("Id");
				var parameter = processElement.findParameterByUId(id);
				if (parameter) {
					var mappingValue = parameter.getMappingValue();
					this.set("Value", mappingValue);
				}
			}
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#onItemDeleteClick
		 * @override
		 */
		onItemDeleteClick: function() {
			this.mixins.processMiniEditPageMixin.onItemDeleteClick.apply(this, arguments);
			var consts = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee;
			var grantee = this.get("Grantee");
			if (grantee === consts.ROLE || grantee === consts.EMPLOYEE) {
				var element = this.get("ProcessElement");
				var parameter = element.findParameterByUId(this.get("Id"));
				if (parameter) {
					var parameters = element.parameters;
					parameters.remove(parameter);
				}
			}
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#getProcessMiniEditPageName
		 * @override
		 */
		getProcessMiniEditPageName: function() {
			return "ChangeAdminRightsUserTaskMiniEditPage";
		},

		/**
		 * @inheritdoc BPMSoft.ProcessMiniEditPageMixin#onLoadMinEditPageClick
		 * @protected
		 */
		onLoadMinEditPageClick: function() {
			var allRolesGrantee = processUserTaskConstants.ChangeAdminRightsUserTaskGrantee.ALL_ROLES_AND_USERS;
			if (this.get("Grantee") === allRolesGrantee) {
				return;
			}
			this.mixins.processMiniEditPageMixin.onLoadMinEditPageClick.apply(this, arguments);
		},

		/**
		 * Returns marker value for label.
		 * @protected
		 * @return {String} markerValue of label.
		 */
		getLabelMarkerValue: function() {
			return this.getMarkerValue();
		},
		/**
		 * Returns marker value for tool button.
		 * @protected
		 * @return {String} markerValue of tool button.
		 */
		getToolButtonMarkerValue: function() {
			var itemName = "Tool";
			return this.getMarkerValue(itemName);
		},

		/**
		 * Returns marker value for right level button.
		 * @protected
		 * @return {String} markerValue of right level button.
		 */
		getRightLevelButtonMarkerValue: function() {
			var itemName = "RightLevel";
			return this.getMarkerValue(itemName);
		},

		/**
		 * Returns marker value for read checkbox.
		 * @protected
		 * @return {String} markerValue of read checkbox.
		 */
		getReadCheckBoxMarkerValue: function() {
			var itemName = "ReadCheckBox";
			return this.getMarkerValue(itemName);
		},

		/**
		 * Returns marker value for edit checkbox.
		 * @protected
		 * @return {String} markerValue of edit checkbox.
		 */
		getEditCheckBoxMarkerValue: function() {
			var itemName = "EditCheckBox";
			return this.getMarkerValue(itemName);
		},

		/**
		 * Returns marker value for delete checkbox.
		 * @protected
		 * @return {String} markerValue of delete checkbox.
		 */
		getDeleteCheckBoxMarkerValue: function() {
			var itemName = "DeleteCheckBox";
			return this.getMarkerValue(itemName);
		},

		/**
		 * Returns marker value for item.
		 * @protected
		 * @param {String} itemName Name item.
		 * @return {String} markerValue of item.
		 */
		getMarkerValue: function(itemName) {
			var blockName = this.getBlockName();
			itemName = itemName ? itemName : "";
			var name = this.get("Name");
			var parentCollection = this.parentCollection;
			var currentIndex = parentCollection.indexOf(this);
			var markerValue = Ext.String.format("{0}-{1}-{2}-{3}", blockName, name, itemName, currentIndex);
			return markerValue;
		},

		/**
		 * Get block items name.
		 * @private
		 * @return {String} Block name.
		 */
		getBlockName: function() {
			return "BaseItem";
		}

		//endregion

	});

	return BPMSoft.ChangeAdminRightsUserTaskBaseItemViewModel;
});
