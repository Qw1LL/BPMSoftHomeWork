/**
 * Parent: BaseProcessMiniEditPage
 */
define("ProcessSchemaUsingMiniEditPage", ["BPMSoft", "ProcessSchemaUsingMiniEditPageResources"],
	function(BPMSoft, resources) {
		return {
			attributes: {
				/**
				 * Name of 'Using'.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Name": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.NameCaption,
					"isRequired": true
				},
				/**
				 * Alias of 'Using'.
				 * @type {BPMSoft.dataValueType.TEXT}
				 */
				"Alias": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"caption": resources.localizableStrings.AliasCaption
				}
			},
			methods: {
				//region Methods: Protected

				/**
				 * @inheritdoc BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("Name", this.usingNameValidator);
					this.addColumnValidator("Name", this.duplicateValueValidator);
				},

				/**
				 * @inheritdoc BaseProcessMiniEditPage#getSaveButtonHint
				 * @returns {undefined}
				 */
				getSaveButtonHint: function() {
					return this.get("IsEditable")
						? undefined
						: resources.localizableStrings.InheritedItemSaveButtonHint;
				},

				/**
				 * Executes name validation info.
				 * @protected
				 * @param {String} value Parameter name.
				 * @return {Object} Validation info.
				 */
				usingNameValidator: function(value) {
					var message = "";
					var reqExp = /^(global::|[a-zA-Z]{1})(\.[a-zA-Z]|[a-zA-Z0-9])*$/;
					if (!reqExp.test(value)) {
						message = this.get("Resources.Strings.WrongItemNameMessage");
					}
					return {
						invalidMessage: message
					};
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/ [
				{
				"operation": "insert",
				"parentName": "Controls",
				"propertyName": "items",
				"name": "Name",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"value": {
						"bindTo": "Name"
					},
					"enabled": { "bindTo": "IsEditable" },
					"isRequired": true,
					"classes": {
						"labelClass": ["t-label-proc"]
					},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"parentName": "Controls",
				"propertyName": "items",
				"name": "Alias",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"value": {
						"bindTo": "Alias"
					},
					"enabled": { "bindTo": "IsEditable" },
					"classes": {
						"labelClass": ["t-label-proc"]
					},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"wrapClass": ["top-caption-control"]
				}
			}
		] /**SCHEMA_DIFF*/
		};
	});

