/**
 * Parent: BaseDcmSchemaElementPropertiesPage => ApprovalUserTaskPropertiesPage => ProcessFlowElementPropertiesPage
 * => BaseProcessSchemaElementPropertiesPage
 */
define("DcmApprovalUserTaskPropertiesPage", ["ConfigurationConstants", "DcmConstants", "ConfigurationItemGenerator"
], function(ConfigurationConstants) {
	return {

		/**
		 * Use base DCM schema (BaseDcmSchemaElementPropertiesPage)
		 * @type {Boolean}
		 */
		useBaseDcmSchema: true,

		attributes: {
			/**
			 * @inheritdoc BPMSoft.BaseDcmSchemaElementPropertiesPage#UseConditions
			 * @override
			 */
			"UseConditions": {
				"value": true
			}
		},

		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getParentEntitySchemaUId: function(callback, scope) {
				var element = this.get("DcmElement");
				var parentSchema = element.parentSchema;
				var entitySchema = parentSchema.entitySchema;
				this._getSectionByEntitySchema(entitySchema.uId, function(section) {
					var sectionId = section && section.getId();
					var sysModuleVisa = this.findSysModuleVisa(sectionId);
					var parentEntitySchemaUId = sysModuleVisa ? entitySchema.uId : null;
					callback.call(scope, parentEntitySchemaUId);
				}, this);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc ApprovalUserTaskPropertiesPage#initSection
			 * @override
			 */
			initSection: function() {
				var parentMethod = this.getParentMethod(this, arguments);
				if (!this.get("EntitySchemaUId")) {
					this._getParentEntitySchemaUId(function(parentEntitySchemaUId) {
						this.set("EntitySchemaUId", parentEntitySchemaUId);
						parentMethod();
					}, this);
				} else {
					parentMethod();
				}
			},

			/**
			 * @inheritdoc ApprovalUserTaskPropertiesPage#initRecordId
			 * @override
			 */
			initRecordId: function() {
				var parentMethod = this.getParentMethod(this, arguments);
				this._getParentEntitySchemaUId(function(parentEntitySchemaUId) {
					var isParentEntitySchema = this.get("EntitySchemaUId") === parentEntitySchemaUId;
					if (isParentEntitySchema) {
						var element = this.get("DcmElement");
						var parameter = element.getParameterByName("RecordId");
						if (!parameter.hasValue()) {
							parameter.referenceSchemaUId = this.get("EntitySchemaUId");
							element.parentSchema.setParameterDefaultValue(parameter);
						}
					}
					parentMethod();
				}, this);
			},

			/**
			 * @inheritdoc BaseDcmSchemaElementPropertiesPage#getDefaultRequiredType
			 * @override
			 */
			getDefaultRequiredType: function() {
				return BPMSoft.DcmConstants.ElementRequiredType.REQUIRED;
			},

			/**
			 * @inheritdoc BaseDcmSchemaElementPropertiesPage#getConditionsResultList
			 * @override
			 */
			getConditionsResultList: function() {
				return ConfigurationConstants.VisaStatus;
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
