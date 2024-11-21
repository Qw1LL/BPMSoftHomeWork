define("EmployeeCareerPage", ["ViewModelColumnValidator"], function() {
	return {
		entitySchemaName: "EmployeeCareer",
		attributes: {

			/**
			 * Organization structure unit.
			 */
			"OrgStructureUnit": {
				"lookupConfig": {
					"hierarchical": true
				}
			}

		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.configuration.BaseSchemaViewModel#setValidationConfig
			 * @overridden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("DueDate", this.validateDueDate);
				this.addColumnValidator("ProbationDueDate", this.validateProbationDueDate);
			},

			/**
			 * Creates validator.
			 * @protected
			 * @return {Object}
			 */
			createValidator: function() {
				return this.Ext.create("BPMSoft.ViewModelColumnValidator");
			},

			/**
			 * Validates due date.
			 * @protected
			 * @return {Object} Validation information.
			 */
			validateDueDate: function() {
				var validator = this.createValidator();
				return validator.validateDates(this, "DueDate", "StartDate",
					this.get("Resources.Strings.DateIsLessThanDateMessageTemplate"));
			},

			/**
			 * Validates probation due date.
			 * @protected
			 * @return {Object} Validation information.
			 */
			validateProbationDueDate: function() {
				var validator = this.createValidator();
				return validator.validateDates(this, "ProbationDueDate", "StartDate",
					this.get("Resources.Strings.DateIsLessThanDateMessageTemplate"));
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "actions"
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Account",
				"values": {
					layout: { row: 0, column: 0, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "OrgStructureUnit",
				"values": {
					layout: { row: 0, column: 13, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "EmployeeJob",
				"values": {
					"contentType": BPMSoft.ContentType.ENUM,
					layout: { row: 1, column: 0, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "FullJobTitle",
				"values": {
					layout: { row: 1, column: 13, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "StartDate",
				"values": {
					layout: { row: 2, column: 0, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "DueDate",
				"values": {
					layout: { row: 2, column: 13, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "ProbationDueDate",
				"values": {
					layout: { row: 3, column: 0, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "ReasonForDismissal",
				"values": {
					layout: { row: 3, column: 13, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "IsCurrent",
				"values": {
					layout: { row: 4, column: 0, colSpan: 11 }
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
