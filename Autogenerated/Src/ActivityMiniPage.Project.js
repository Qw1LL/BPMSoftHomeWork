define("ActivityMiniPage", ["ProjectServiceHelper"], function(ProjectServiceHelper) {
	return {
		entitySchemaName: "Activity",
		attributes: {
			/**
			 * Activity entity project column.
			 * @type {Object}
			 */
			"Project": {
				"lookupListConfig": {
					"columns": ["Account", "Contact", "Opportunity"],
					"filters": [
						function() {
							return this.getProjectFilters();
						}
					]
				},
				"dependencies": [
					{
						"columns": ["Project"],
						"methodName": "onProjectChange"
					}
				]
			},

			/**
			 * Names of entities that linked with project.
			 * @type {String[]}
			 */
			"ProjectLinkedEntities": {
				"value": ["Account", "Contact", "Opportunity"]
			}
		},
		methods: {
			/**
			 * Calls on project change.
			 * @private
			 */
			onProjectChange: function() {
				var project = this.get("Project");
				if (project) {
					var linkedEntities = this.get("ProjectLinkedEntities");
					linkedEntities.forEach(function(entityName) {
						var entityValue = project[entityName];
						if (entityValue && !this.get(entityName)) {
							this.set(entityName, entityValue);
						}
					}, this);
					ProjectServiceHelper.getProjectFullName(project.value, function(projectName) {
						this.set("FullProjectName", projectName);
					}, this);
				}
			},

			/**
			 * Returns project filters.
			 * @private
			 * @return {BPMSoft.FilterGroup} Project filters.
			 */
			getProjectFilters: function() {
				var linkedEntities = this.get("ProjectLinkedEntities");
				var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
				filterGroup.add("ParentProject", this.BPMSoft.createColumnIsNullFilter("ParentProject"));
				linkedEntities.forEach(function(entityName) {
					var entity = this.get(entityName);
					if (entity && entity.value) {
						filterGroup.add(entityName + "Connection", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, entityName, entity.value));
					}
				}, this);
				return filterGroup;
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
