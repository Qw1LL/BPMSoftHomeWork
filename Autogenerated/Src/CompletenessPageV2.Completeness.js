define("CompletenessPageV2", ["ServiceHelper", "CompletenessPageV2Resources", "css!CompletenessCSSV2"],
	function(ServiceHelper, resources) {
		return {
			entitySchemaName: "Completeness",
			details: /**SCHEMA_DETAILS*/ {
				"CompletenessParameters": {
					"schemaName": "CompletenessParameterDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Completeness"
					},
					"subscriber": function() {
						this.updateButtonsVisibility(true);
						this.set("ValidateDetail", true);
					}
				}
			} /**SCHEMA_DETAILS*/ ,
			messages: {
				/**
				 * @message GetTotalPercentage
				 * ######## ##### ########## ########## #######
				 * @param {Number} ##### ########## ########## #######
				 */
				"GetTotalPercentage": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetMasterRecordInfo
				 * Returns master record information.
				 */
				"GetMasterRecordInfo": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "remove",
				"name": "actions"
			}, {
				"operation": "insert",
				"name": "ScaleContainer",
				"parentName": "Header",
				"propertyName": "items",
				"values": {
					"id": "ScaleContainer",
					"selectors": {
						"wrapEl": "#ScaleContainer"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["scale-container", "control-width-15"],
					"markerValue": "ScaleContainer",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "ScaleLabelContainer",
				"parentName": "ScaleContainer",
				"propertyName": "items",
				"values": {
					"id": "ScaleLabelContainer",
					"selectors": {
						"wrapEl": "#ScaleLabelContainer"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-wrap"],
					"markerValue": "ScaleLabelContainer",
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "ScaleControlContainer",
				"parentName": "ScaleContainer",
				"propertyName": "items",
				"values": {
					"id": "ScaleControlContainer",
					"selectors": {
						"wrapEl": "#ScaleControlContainer"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["control-wrap"],
					"markerValue": "ScaleControlContainer",
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "ScaleIndicatorContainer",
				"parentName": "ScaleControlContainer",
				"propertyName": "items",
				"values": {
					"id": "ScaleIndicatorContainer",
					"selectors": {
						"wrapEl": "#ScaleIndicatorContainer"
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["scale-indicator-container"],
					"markerValue": "ScaleIndicatorContainer",
					"items": []
				}
			}, {
				"operation": "insert",
				"name": "ScaleLabel",
				"parentName": "ScaleLabelContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"labelClass": ["scale-caption", "t-label-is-required"]
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.ScaleCaption"
					}
				}
			}, {
				"operation": "insert",
				"name": "Min",
				"parentName": "ScaleIndicatorContainer",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"bindTo": "Min",
					"labelConfig": {
						"visible": false
					},
					"enabled": false,
					"useThousandSeparator": false
				}
			}, {
				"operation": "insert",
				"name": "MiddleFrom",
				"parentName": "ScaleIndicatorContainer",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"bindTo": "MiddleFrom",
					"labelConfig": {
						"visible": false
					},
					"useThousandSeparator": false
				}
			}, {
				"operation": "insert",
				"name": "MiddleTo",
				"parentName": "ScaleIndicatorContainer",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"bindTo": "MiddleTo",
					"labelConfig": {
						"visible": false
					},
					"useThousandSeparator": false
				}
			}, {
				"operation": "insert",
				"name": "Max",
				"parentName": "ScaleIndicatorContainer",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.INTEGER,
					"bindTo": "Max",
					"labelConfig": {
						"visible": false
					},
					"enabled": false,
					"useThousandSeparator": false
				}
			}, {
				"operation": "insert",
				"index": 1,
				"name": "ScaleIcon",
				"parentName": "ScaleControlContainer",
				"propertyName": "items",
				"values": {
					"id": "ScaleIcon",
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"imageConfig": {
						"bindTo": "Resources.Images.ScaleIcon"
					},
					"classes": {
						"wrapperClass": ["scale-icon"]
					},
					"selectors": {
						"wrapEl": "#ScaleIcon"
					},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
				}
			}, {
				"operation": "insert",
				"name": "CompletenessParameters",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			}] /**SCHEMA_DIFF*/ ,
			attributes: {
				/**
				 * ####### ####### ########### ####### ##########.
				 * @private
				 * @type {Boolean}
				 */
				StartCalculateCompleteness: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * ####### ######### ###### #########.
				 * @private
				 * @type {Boolean}
				 */
				ValidateDetail: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},
				/**
				 * Minimal value of indicator scale.
				 * @private
				 * @type {Number}
				 */
				Min: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.ScaleCaption,
					value: 0
				},

				/**
				 * "Middle from" value of indicator scale.
				 * @private
				 * @type {Number}
				 */
				MiddleFrom: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.ScaleCaption,
					value: 25
				},

				/**
				 * "Middle to" value of indicator scale.
				 * @private
				 * @type {Number}
				 */
				MiddleTo: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.ScaleCaption,
					value: 75
				},

				/**
				 * Maximal value of indicator scale.
				 * @private
				 * @type {Number}
				 */
				Max: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.ScaleCaption,
					value: 100
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initScale();
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("MiddleFrom", this.validateScale);
					this.addColumnValidator("MiddleTo", this.validateScale);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					this.sandbox.subscribe("GetMasterRecordInfo", this.onGetMasterRecordInfo, this,
						[this.getDetailId("CompletenessParameters")]);
				},

				/**
				 * Handles "GetMasterRecordInfo" message.
				 * @protected
				 * @return {Object} Master record information.
				 */
				onGetMasterRecordInfo: function() {
					return {
						entitySchemaName: this.get("EntitySchemaName"),
						typeColumnName: this.get("TypeColumnName"),
						typeColumnValue: this.get("TypeColumnValue")
					};
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
				 * @overridden
				 */
				onDiscardChangesClick: function() {
					this.initScale();
					if (!this.isNew) {
						this.updateDetails();
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#getHeader
				 * @overridden
				 */
				getHeader: function() {
					var header = this.get("Resources.Strings.CompletenessPageCaption");
					return this.Ext.String.format(header, this.get("Name"));
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#save
				 * @overridden
				 */
				save: function() {
					if (!this.validate()) {
						return false;
					}
					if (this.get("ValidateDetail")) {
						var funcArguments = arguments;
						var completenessParametersDetailId = this.getDetailId("CompletenessParameters");
						if (!this.sandbox.publish("ValidateDetail", null, [completenessParametersDetailId])) {
							return;
						}
						var totalPercentage = this.sandbox.publish("GetTotalPercentage",
							null, [completenessParametersDetailId]);
						if (totalPercentage !== 0 && totalPercentage !== 100) {
							var totalPercentageMessage = this.get("Resources.Strings.TotalPercentageNotCorrectMessage");
							this.BPMSoft.showInformation(totalPercentageMessage);
							return false;
						} else {
							var confirmationMessage = this.get("Resources.Strings.ConfirmSaveMessage");
							this.showConfirmationDialog(confirmationMessage, function(result) {
								if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									this.set("ValidateDetail", false);
									this.set("StartCalculateCompleteness", true);
									return this.save(funcArguments);
								} else {
									return false;
								}
							}, ["yes", "no"]);
						}
					} else {
						var scale = {
							sectorsBounds: {
								min: this.get("Min"),
								middleFrom: this.get("MiddleFrom"),
								middleTo: this.get("MiddleTo"),
								max: this.get("Max")
							}
						};
						this.set("Scale", this.Ext.encode(scale));
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					if (this.get("StartCalculateCompleteness")) {
						this.calculateCompleteness();
						this.set("StartCalculateCompleteness", false);
					}
					this.callParent(arguments);
				},

				/**
				 * Initializes scale.
				 * @protected
				 */
				initScale: function() {
					var scale = this.get("Scale");
					if (!this.Ext.isEmpty(scale)) {
						scale = this.Ext.decode(scale);
						var sectorsBounds = scale.sectorsBounds;
						if (!this.Ext.isEmpty(sectorsBounds)) {
							this.set("Min", sectorsBounds.min);
							this.setValidationInfo("Min", true);
							this.set("MiddleFrom", sectorsBounds.middleFrom);
							this.setValidationInfo("MiddleFrom", true);
							this.set("MiddleTo", sectorsBounds.middleTo);
							this.setValidationInfo("MiddleTo", true);
							this.set("Max", sectorsBounds.max);
							this.setValidationInfo("Max", true);
						}
					}
				},

				/**
				 * ######### #####.
				 * @param  {Number} columnValue ######## #######.
				 * @param  {Object} column #######.
				 * @return {Object} ############# #########.
				 */
				validateScale: function(columnValue, column) {
					var invalidMessage;
					var max = this.get("Max");
					var ext = this.Ext;
					if (!ext.isNumber(columnValue) || columnValue > max) {
						invalidMessage = this.get("Resources.Strings.ScaleWarning");
					} else if (columnValue < 0) {
						invalidMessage = this.get("Resources.Strings.ScaleBoundMoreLessZeroMessage");
					} else if (!ext.isEmpty(column)) {
						var columnName = column.name;
						var min = this.get("Min");
						var middleFrom = this.get("MiddleFrom");
						var middleTo = this.get("MiddleTo");
						switch (columnName) {
							case "MiddleFrom":
								if (columnValue <= min) {
									invalidMessage = this.get("Resources.Strings.ScaleBoundMoreLessWarning");
									invalidMessage = ext.String.format(invalidMessage, min + 1);
								} else if (columnValue >= middleTo) {
									invalidMessage = this.get("Resources.Strings.ScaleBoundMoreGreaterWarning");
									invalidMessage = ext.String.format(invalidMessage, middleTo - 1);
								}
								break;
							case "MiddleTo":
								if (columnValue <= middleFrom) {
									invalidMessage = this.get("Resources.Strings.ScaleBoundMoreLessWarning");
									invalidMessage = ext.String.format(invalidMessage, middleFrom + 1);
								} else if (columnValue >= max) {
									invalidMessage = this.get("Resources.Strings.ScaleBoundMoreGreaterWarning");
									invalidMessage = ext.String.format(invalidMessage, max - 1);
								}
								break;
						}
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				},

				/**
				 * ######## ###### ####### ########## #######.
				 * @protected
				 */
				calculateCompleteness: function() {
					var data = {
						completenessId: this.get("Id")
					};
					ServiceHelper.callService("CompletenessService",
						"RecalculateAllByCompleteness",
						null,
						data,
						this);
				}
			}
		};
	}
);
