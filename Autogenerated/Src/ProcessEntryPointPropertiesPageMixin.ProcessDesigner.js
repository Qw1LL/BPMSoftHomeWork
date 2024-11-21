define("ProcessEntryPointPropertiesPageMixin", ["ProcessModuleUtilities", "Contact"], function(Utilities, Contact) {
	/**
	 * Implements work with SchemaUId attribute in process properties page.
	 */
	Ext.define("BPMSoft.configuration.mixins.ProcessEntryPointPropertiesPageMixin", {
		alternateClassName: "BPMSoft.ProcessEntryPointPropertiesPageMixin",

		//region Methods: Protected

		/**
		 * Init entity schemas list.
		 * @protected
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		initEntitySchemas: function(callback, scope) {
			var schemasFilter = this.getSchemaListFilter("EntitySchemaManager");
			Utilities.getSchemasByFilter(schemasFilter, function(schemas) {
				var entitySchemas = Ext.create("BPMSoft.Collection");
				entitySchemas.loadAll(schemas);
				this.set("EntitySchemas", entitySchemas);
				callback.call(scope);
			}, this);
		},

		/**
		 * Returns schema list filter.
		 * @protected
		 * @param {String} managerName Schema manager name.
		 * @return {Object}
		 */
		getSchemaListFilter: function(managerName) {
			var element = this.get("ProcessElement");
			var parentSchema = element.parentSchema;
			var filter = {
				ManagerName: managerName,
				PackageUId: parentSchema.packageUId,
				UseExtendParent: false,
				ExcludedSchemas: []
			};
			return filter;
		},

		/**
		 * The event handler for preparing entity schemas drop-down list.
		 * @protected
		 * @param {Object} filter Filters for data preparation.
		 * @param {BPMSoft.Collection} list The data for the drop-down list.
		 */
		onPrepareEntitySchemaList: function(filter, list) {
			if (BPMSoft.isEmptyObject(list)) {
				return;
			}
			list.clear();
			var parameterName = this.getEntitySchemaParameterName();
			var selectedSchema = this.get(parameterName);
			var entitySchemas = this.get("EntitySchemas");
			if (selectedSchema) {
				entitySchemas = entitySchemas.filterByFn(function(schema) {
					return schema.value !== selectedSchema.value;
				});
			}
			list.loadAll(entitySchemas);
		},
		/**
		 * Returns Entity schema parameter name.
		 * @protected
		 * @return {string}
		 */
		getEntitySchemaParameterName: function() {
			return "EntitySchemaUId";
		},
		/**
		 * Initializes EntitySchemaUId parameter.
		 * @protected
		 * @param {ProcessElement} element Process element.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function scope.
		 */
		initEntitySchema: function(element, callback, scope) {
			var parameterName = this.getEntitySchemaParameterName();
			var parameter = element.findParameterByName(parameterName);
			var mappingValue = parameter.getMappingValue();
			var entitySchemaUId = mappingValue.value;
			var changeEventName = "change:" + parameterName;
			if (BPMSoft.isEmptyGUID(entitySchemaUId) || Ext.isEmpty(entitySchemaUId)) {
				this.on(changeEventName, this.onEntitySchemaUIdChanged, this);
				callback.call(scope);
				return;
			}
			Utilities.loadSchemaDisplayValue(entitySchemaUId, function(displayValue) {
				this.set(parameterName, {
					value: entitySchemaUId,
					displayValue: displayValue
				});
				this.on(changeEventName, this.onEntitySchemaUIdChanged, this);
				callback.call(scope);
			}, this);
		},

		/**
		 * Handles after connection object schema changed, resets connection instance object.
		 * @protected
		 * @param {BPMSoft.BaseViewModel} model Page view model.
		 * @param {Object} entitySchema New entity schema value.
		 */
		onEntitySchemaUIdChanged: function(model, entitySchema) {
			entitySchema = entitySchema || {};
			var entitySchemaUId = entitySchema.value;
			if (Ext.isEmpty(entitySchemaUId)) {
				this.set("EntityId", null);
			} else {
				var entity = this.get("EntityId") || {};
				this.set("EntityId", {
					value: null,
					displayValue: null,
					source: BPMSoft.ProcessSchemaParameterValueSource.None,
					referenceSchemaUId: entitySchemaUId,
					dataValueType: entity.dataValueType
				});
			}
		},

		/**
		 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
		 * @override
		 */
		getParameterReferenceSchemaUId: function(elementParameter) {
			var referenceSchemaUId;
			if(elementParameter.name === "OwnerId"){
				referenceSchemaUId = Contact.uId;
			} else {
				var entitySchema = this.get("EntitySchemaUId");
				referenceSchemaUId = entitySchema ? entitySchema.value : null;
			}
			return referenceSchemaUId;
		}

		//endregion

	});
});
