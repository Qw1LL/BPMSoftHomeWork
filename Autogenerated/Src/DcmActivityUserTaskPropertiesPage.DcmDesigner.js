/**
 * Parent: BaseDcmSchemaElementPropertiesPage => ActivityUserTaskPropertiesPage => BaseActivityUserTaskPropertiesPage
 * => BaseUserTaskPropertiesPage => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("DcmActivityUserTaskPropertiesPage", [],
	function() {
		return {

			/**
			 * Use base DCM schema.
			 * @type {Boolean}
			 */
			useBaseDcmSchema: true,

			attributes: {
				/**
				 * Activity result list.
				 */
				"ActivityResultList": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

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

				_initActivityResultList: function(callback, scope) {
					const esq = new BPMSoft.EntitySchemaQuery({rootSchemaName: "ActivityCategoryResultEntry"});
					esq.addColumn("ActivityCategory");
					esq.addColumn("[ActivityResult:Id:ActivityResult].Id", "ResultId");
					esq.addColumn("[ActivityResult:Id:ActivityResult].Name", "ResultName", {
						orderDirection: BPMSoft.OrderDirection.ASC,
						orderPosition: 1
					});
					esq.execute(function(response) {
						this.set("ActivityResultList", response.collection);
						callback.call(scope);
					}, this);
				},

				_subscribeActivityCategoryChanged: function() {
					this.on("change:ActivityCategory", this._onActivityCategoryChanged, this);
				},

				_onActivityCategoryChanged: function() {
					const conditions = this.get("Conditions");
					conditions.clear();
				},

				// endregion

				// region Methods: Protected

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function(callback, scope) {
					const parentMethod = this.getParentMethod();
					this._initActivityResultList(function() {
						parentMethod.call(this, callback, scope);
					}, this);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @override
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						this._subscribeActivityCategoryChanged();
						callback.call(scope);
					}, this]);
				},

				/**
				 * @inheritdoc BaseDcmSchemaElementPropertiesPage#getConditionsResultList
				 * @override
				 */
				getConditionsResultList: function() {
					const activityCategory = this.get("ActivityCategory");
					if (Ext.isEmpty(activityCategory)) {
						return null;
					}
					const allResultList = this.get("ActivityResultList");
					const resultsByCategory = allResultList.filterByFn(function (item) {
						return item.get("ActivityCategory").value === activityCategory.value;
					}, this);
					const preparedResults = {};
					resultsByCategory.each(function(item) {
						const id = item.get("ResultId");
						const name = item.get("ResultName");
						preparedResults[id] = {
							value: id,
							displayValue: name
						};
					}, this);
					return preparedResults;
				}

				// endregion

			},

			diff: /**SCHEMA_DIFF*/[
			]/**SCHEMA_DIFF*/
		};
	}
);
