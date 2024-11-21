define("UserQuestionProcessPageV2Utilities", ["BPMSoft", "UserQuestionProcessPageV2UtilitiesResources"],
	function(BPMSoft) {
		/**
		 * ########## ############### ############# ######### ########## (###### ##############).
		 * @private
		 * @param {Object} executionData ###### ########## ######## ##.
		 * @return {Object} ############### ############# ######### ########## (###### ##############).
		 */
		function getRadioGroupCustomDiff(executionData) {
			var customDiff = [];
			customDiff.push({
				"operation": "insert",
				"parentName": "UserQuestionContentBlock",
				"name": "UserQuestionRadioGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"items": [],
					"value": {
						"bindTo": "radioButtonsGroup"
					},
					"layout": {"column": 0, "row": 0, "colSpan": 11}
				}
			});
			var i = 0;
			var decisionOptions = executionData.decisionOptions;
			BPMSoft.each(decisionOptions, function(decisionOption) {
				customDiff.push({
					"operation": "insert",
					"parentName": "UserQuestionRadioGroup",
					"propertyName": "items",
					"name": "RadioButton" + i,
					"values": {
						"caption": decisionOption.Caption,
						"value": decisionOption.Name,
						"markerValue": decisionOption.Caption
					}
				});
				i++;
			});
			return customDiff;
		}
		/**
		 * ########## ############### ############# ######### ########## (#######).
		 * @private
		 * @param {Object} executionData ###### ########## ######## ##.
		 * @return {Object} ############### ############# ######### ########## (#######).
		 */
		function getCheckBoxesCustomDiff(executionData) {
			var customDiff = [];
			var i = 0;
			var decisionOptions = executionData.decisionOptions;
			BPMSoft.each(decisionOptions, function(decisionOption) {
				customDiff.push({
					"operation": "insert",
					"parentName": "UserQuestionContentBlock",
					"propertyName": "items",
					"name": "UserQuestionCheckBox" + i,
					"values": {
						"bindTo": decisionOption.Name.toString(),
						"caption": decisionOption.Caption,
						"layout": {"column": 0, "row": i, "colSpan": 11}
					}
				});
				i++;
			});
			return customDiff;
		}
		return {
			/**
			 * ########## ###### ############### ######## ######.
			 * @public
			 * @param {Object} executionData ###### ########## ######## ##.
			 * @return {Object} ###### ############### ######## ######.
			 */
			getCustomValues: function(executionData) {
				var decisionOptions = executionData.decisionOptions;
				var decisionMode = executionData.decisionMode;
				var customValues = {
					QuestionText: executionData.questionText,
					isDecisionRequired: executionData.isDecisionRequired,
					radioButtonsGroup: null,
					processElementUId: executionData.procElUId,
					decisionMode: decisionMode,
					decisionOptions: decisionOptions
				};
				if (decisionMode === 0) {
					BPMSoft.each(decisionOptions, function(decisionOption) {
						if (decisionOption.DefChecked === true || decisionOption.DefChecked === "True") {
							customValues.radioButtonsGroup = decisionOption.Name;
						}
					});
				} else {
					BPMSoft.each(decisionOptions, function(decisionOption) {
						customValues[decisionOption.Name.toString()] = decisionOption.DefChecked === true ||
							decisionOption.DefChecked === "True";
					});
				}
				return customValues;
			},
			/**
			 * ########## ###### ############### ########## ######.
			 * @public
			 * @param {Object} executionData ###### ########## ######## ##.
			 * @return {Object} ###### ############### ########## ######.
			 */
			getCustomAttributes: function(executionData) {
				var decisionOptions = executionData.decisionOptions;
				var decisionMode = executionData.decisionMode;
				var customAttributes = {};
				if (decisionMode === 0) {
					if (BPMSoft.Features.getIsDisabled("BasePageV2UseForceUpdateInProcessMode")){
						customAttributes.radioButtonsGroup = {
							dataValueType: BPMSoft.DataValueType.TEXT,
							isProcessUserTaskParameterAttribute: true
						};
					}
				} else {
					BPMSoft.each(decisionOptions, function(decisionOption) {
						customAttributes[decisionOption.Name.toString()] = {
							dataValueType: BPMSoft.DataValueType.BOOLEAN,
							isProcessUserTaskParameterAttribute: true
						};
					});
				}
				customAttributes.QuestionText = {
					dataValueType: BPMSoft.DataValueType.TEXT
				};
				return customAttributes;
			},
			/**
			 * ########## ############### ############# ######### ########## ########.
			 * @public
			 * @param {Object} executionData ###### ########## ######## ##.
			 * @return {Object} ############### ############# ######### ########## ########.
			 */
			getCustomDiff: function(executionData) {
				return executionData.decisionMode === 0 ?
					getRadioGroupCustomDiff(executionData) : getCheckBoxesCustomDiff(executionData);
			}
		};
	});
