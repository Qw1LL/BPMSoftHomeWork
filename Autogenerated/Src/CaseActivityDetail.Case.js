define("CaseActivityDetail", [],
	function() {
		return {
			entitySchemaName: "Activity",
			messages: {},
			attributes: {},
			methods: {
				/**
				 * @inheritdoc BaseGridDetailV2#addRecord
				 * @protected
				 * @overridden
				 */
				addRecord: function() {
					this.setNewActivityDefaultValues();
					this.callParent(arguments);
				},

				/**
				 * Overrides default values for new activity object.
				 * @protected
				 */
				setNewActivityDefaultValues: function() {
					var columns = ["Contact", "Account"];
					var values = this.sandbox.publish("GetColumnsValues", columns, [this.sandbox.id]);
					var defaultValues = this.get("DefaultValues");
					if (values.Contact) {
						this.setDefaultValue(defaultValues, "Contact", values.Contact.value);
					}
					if (values.Account) {
						this.setDefaultValue(defaultValues, "Account", values.Account.value);
					}
				},

				/**
				 * Checks defaultValues and sets or adds new value.
				 * @protected
				 * @param {Array} defaultValues Array of default values.
				 * @param {String} name Field name to set.
				 * @param {Object} value Field value to set.
				 */
				setDefaultValue: function(defaultValues, name, value) {
					for (var i = 0; i < defaultValues.length; i++) {
						if (defaultValues[i].name === name) {
							defaultValues[i] = {name: name,
								value: value};
							return;
						}
					}
					defaultValues.push({name: name,
						value: value});
				},

				/**
				 * Clears previous default values.
				 * @protected
				 * @obsolete
				 * @param {Array} defaultValues Default values.
				 */
				clearPreviousDefaultValues: function(defaultValues) {
					var columnsToClear = ["Contact", "Account"];
					this.BPMSoft.each(columnsToClear, function(column) {
						for (var i = 0; i < defaultValues.length; i++) {
							if (defaultValues[i].name === column) {
								defaultValues.splice(i, 1);
								i--;
							}
						}
					}, this);
				},

				/**
				 * Opens a card filled with default values.
				 * @obsolete
				 * @param {String} operation Operation.
				 * @param {String} typeColumnValue Type column value.
				 * @param {String} recordId Record identifier.
				 * @param {Object} editPage Edit page.
				 * @param {Array} defaultValues Default values.
				 */
				openCardWithValuePairs: function(operation, typeColumnValue, recordId, editPage, defaultValues) {
					var obsoleteMessage = BPMSoft.Resources.ObsoleteMessages.ObsoleteMethodMessage;
					this.log(Ext.String.format(obsoleteMessage, "openCardWithValuePairs", "openCard"));
					var schemaName = editPage.get("SchemaName");
					var cardModuleId = this.getEditPageSandboxId(editPage);
					var openCardConfig = {
						moduleId: cardModuleId,
						schemaName: schemaName,
						operation: operation,
						id: recordId,
						valuePairs: defaultValues
					};
					this.sandbox.publish("OpenCard", openCardConfig, [this.sandbox.id]);
				}
			},

			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
