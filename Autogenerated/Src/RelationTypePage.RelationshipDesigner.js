define("RelationTypePage", ["RelationshipDesignerConstants",
	"BusinessRuleModule"], function(RelationshipDesignerConstants, BusinessRuleModule) {
		return {
			entitySchemaName: "RelationType",
			attributes: {
				"ForAccountContact": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					dependencies: [{
						columns: ["ForAccountContact"],
						methodName: "validateForAccountContact"
					}]
				},
				"ForContactAccount": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					dependencies: [{
						columns: ["ForContactAccount"],
						methodName: "validateForContactAccount"
					}]
				},
				"ForAccountAccount": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					dependencies: [{
						columns: ["ForAccountAccount"],
						methodName: "validateForAccountAccount"
					}]
				},
				"ForContactContact": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					dependencies: [{
						columns: ["ForContactContact"],
						methodName: "validateForContactContact"
					}]
				},
				"IncludeIntoContainer": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					enabled: false,
					dependencies: [{
						columns: [
							"RelationConnectionType",
							"ForAccountAccount",
							"ForAccountContact",
							"ForContactAccount",
							"ForContactContact"
						],
						methodName: "updateIncludeIntoContainer"
					}]
				},
				"RelationConnectionType": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isRequired: true,
					dependencies: [{
						columns: ["RelationConnectionType"],
						methodName: "validateRelationConnectionType"
					}]
				},
				"Position": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isRequired: true,
					dependencies: [{
						columns: ["Position"],
						methodName: "validatePosition"
					}]
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_isFormalConnection: function() {
					return !this.Ext.isEmpty(this.$RelationConnectionType) &&
						this.$RelationConnectionType.value === RelationshipDesignerConstants.ConnectionType.Formal;
				},

				/**
				 * @private
				 */
				_isNotFormalConnection: function() {
					return !this.Ext.isEmpty(this.$RelationConnectionType) &&
						this.$RelationConnectionType.value === RelationshipDesignerConstants.ConnectionType.NotFormal;
				},

				/**
				 * @private
				 */
				_isDirectConnection: function() {
					return !this.Ext.isEmpty(this.$Position) &&
						this.$Position.value === RelationshipDesignerConstants.RelationTypePosition.Direct;
				},

				/**
				 * @private
				 */
				_isHorizontalConnection: function() {
					return !this.Ext.isEmpty(this.$Position) &&
						this.$Position.value === RelationshipDesignerConstants.RelationTypePosition.Horizontal;
				},

				/**
				 * @private
				 */
				_isReverseConnection: function() {
					return !this.Ext.isEmpty(this.$Position) &&
						this.$Position.value === RelationshipDesignerConstants.RelationTypePosition.Reverse;
				},

				/**
				 * @private
				 */
				_isContactAccountFormalDirectConnection: function() {
					return this.$ForContactAccount && this._isFormalConnection() && this._isDirectConnection();
				},

				/**
				 * @private
				 */
				_isAccountContactFormalReverseConnection: function() {
					return this.$ForAccountContact && this._isFormalConnection() && this._isReverseConnection();
				},

				_isContactInConnection: function() {
					return this.$ForAccountContact || this.$ForContactAccount || this.$ForContactContact;
				},

				/**
				 * @private
				 */
				_isRowInvalid: function() {
					if (!this._getIncludeIntoContainer()) {
						return false;
					}
					return this._isNotFormalConnection() ||
						this._isHorizontalConnection() ||
						this._isContactAccountFormalDirectConnection() ||
						this._isAccountContactFormalReverseConnection();
				},

				/**
				 * Validate that it is impossible to create an informal relation type with IncludeIntoContainer == true.
				 * @private
				 */
				_validateRelationTypeRow: function(callback, scope) {
					if (this._isRowInvalid()) {
						this.showInformationDialog(
							this.get("Resources.Strings.ConnectionTypeInvalidMessage"),
							callback.bind(scope));
					}
				},

				_getIncludeIntoContainer: function() {
					return this._isFormalConnection() && this._isContactInConnection();
				},

				//endregion

				//region Methods: Public

				/**
				 * Update value for IncludeIntoContainer
				 */
				updateIncludeIntoContainer: function() {
					this.$IncludeIntoContainer = this._getIncludeIntoContainer();
				},

				/**
				 * Validate row with updated RelationConnectionType value.
				 */
				validateRelationConnectionType: function() {
					this._validateRelationTypeRow(function() {
						this.$RelationConnectionType = undefined;
					}, this);
				},

				/**
				 * Validate row with updated Position value.
				 */
				validatePosition: function() {
					this._validateRelationTypeRow(function() {
						this.$Position = undefined;
					}, this);
				},

				/**
				 * Validate row with updated ForAccountContact value.
				 */
				validateForAccountContact: function() {
					this._validateRelationTypeRow(function() {
						this.$ForAccountContact = false;
					}, this);
				},

				/**
				 * Validate row with updated ForContactAccount value.
				 */
				validateForContactAccount: function() {
					this._validateRelationTypeRow(function() {
						this.$ForContactAccount = false;
					}, this);
				},

				/**
				 * Validate row with updated ForAccountAccount value.
				 */
				validateForAccountAccount: function() {
					this._validateRelationTypeRow(function() {
						this.$ForAccountAccount = false;
					}, this);
				},

				/**
				 * Validate row with updated ForContactContact value.
				 */
				validateForContactContact: function() {
					this._validateRelationTypeRow(function() {
						this.$ForContactContact = false;
					}, this);
				}

				//endregion

			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			rules: {
				"IncludeIntoContainer": {
					"AlwaysDisabled": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": false
							}
						}]
					}
				},
				"ReverseRelationType": {
					"ReverseRelationTypeRequired": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "Position"
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": RelationshipDesignerConstants.RelationTypePosition.Reverse
							}
						}]
					}
				}
			}
		};
	});
