define("MLSimilarCaseDetail", ["ProcessModuleUtilities", "GoogleTagManagerUtilities",
		"MLSimilarCaseSearchConstants", "ControlGridModule", "css!MLSimilarCaseDetailCss"], function(
			ProcessModuleUtilities, GoogleTagManagerUtilities, MLSimilarCaseSearchConstants) {
	return {
		entitySchemaName: "MLSimilarCase",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ControlGrid",
					"controlColumnName": "PredictionQuality",
					"applyControlConfig": {"bindTo": "applyControlConfig"}
				}
			},
			{
				"operation": "insert",
				"parentName": "Detail",
				"propertyName": "tools",
				"name": "FindSimilarButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": {"bindTo": "findSimilarCases"},
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig" : {"bindTo": "Resources.Images.RefreshButtonImage"},
					"classes": {
						"wrapperClass": ["refresh-button-wrapper"],
						"imageClass": ["refresh-button-image"]
					},
				}
			},
			{
				"operation": "remove",
				"name": "AddRecordButton"
			}
		]/**SCHEMA_DIFF*/,
		properties: {
			findSimilarProcessCode: "SimilarCasesSearch",
			findSimilarTag: "FindSimilarCases",
			predictionQualitySetTag: "PredictionQualitySet"
		},
		methods: {

			/**
			 * Perform update of prediction quality in DB.
			 * @param row {BPMSoft.BaseViewModel} similar case row view model.
			 * @param quality {String} quality to set.
			 */
			updateRowPredictionQuality: function(row, quality) {
				this.sendAnalytics(this.predictionQualitySetTag);
				let qualityToSet = quality;
				if (row.$PredictionQuality.value === quality) {
					qualityToSet = MLSimilarCaseSearchConstants.PredictionQuality.Undefined;
				}
				const update = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "MLSimilarCase"
				});
				update.filters.add("IdFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Id", row.$Id));
				update.setParameterValue("PredictionQuality", qualityToSet,
					this.BPMSoft.DataValueType.GUID);
				update.execute(function(result) {
					if (result.success) {
						this.updateDetail({primaryColumnValue: row.$Id});
					}
				}, this);
			},

			/**
			 * Get data to send to Google analytics.
			 * @param tag {String} Google analytics action tag.
			 * @returns {*}
			 */
			getGoogleTagManagerData: function(tag) {
				const data = this.callParent();
				this.Ext.apply(data, {
					action: tag
				});
				return data;
			},

			/**
			 * Send Google analytics data.
			 */
			sendAnalytics: function(tag) {
				if (!this.$IsGoogleTagManagerEnabled) {
					return;
				}
				const data = this.getGoogleTagManagerData(tag);
				GoogleTagManagerUtilities.actionModule(data);
			},

			/**
			 * Handles useful prediction button click.
			 */
			onUsefulClick: function() {
				this.updateRowPredictionQuality(this, MLSimilarCaseSearchConstants.PredictionQuality.Useful);
			},

			/**
			 * Handles useless prediction button click.
			 */
			onUselessClick: function() {
				this.updateRowPredictionQuality(this, MLSimilarCaseSearchConstants.PredictionQuality.Useless);
			},

			/**
			 * Passes indicator config by reference.
			 * @param {Object} control Configuration object.
			 * @override
			 */
			applyControlConfig: function(control) {
				control.config = {
					className: "BPMSoft.Container",
					classes: {
						"wrapClassName": ["quality-buttons-container"]
					},
					items: [
						{
							className: "BPMSoft.Button",
							imageConfig: {
								bindTo: "PredictionQuality",
								bindConfig: {
									converter: "getUsefulButtonImage"
								}
							},
							classes: {
								imageClass:["useful-button"]
							},
							click: {
								bindTo: "onUsefulClick"
							},
							pressed: {
								bindTo: "PredictionQuality",
								bindConfig: {
									converter: "getIsUsefulButtonPressed"
								}
							},
							markerValue: "Like"
						},
						{
							className: "BPMSoft.Button",
							imageConfig: {
								bindTo: "getUselessButtonImage"
							},
							classes: {
								imageClass: ["useless-button"]
							},
							click: {
								bindTo: "onUselessClick"
							},
							pressed: {
								bindTo: "PredictionQuality",
								bindConfig: {
									converter: "getIsUselessButtonPressed"
								}
							},
							markerValue: "Dislike"
						}
					]
				};
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#addColumnLink
			 * @override
			 */
			addColumnLink: function(item) {
				const context = this;
				item.onUsefulClick = this.onUsefulClick;
				item.onUselessClick = this.onUselessClick;
				item.getUsefulButtonImage = function() {
					return context.get("Resources.Images.UsefulButtonImage");
				};
				item.getUselessButtonImage = function() {
					return context.get("Resources.Images.UselessButtonImage");
				};
				item.getIsUsefulButtonPressed = function() {
					return this.$PredictionQuality.value === MLSimilarCaseSearchConstants.PredictionQuality.Useful;
				};
				item.getIsUselessButtonPressed = function() {
					return this.$PredictionQuality.value === MLSimilarCaseSearchConstants.PredictionQuality.Useless;
				};
				item.updateRowPredictionQuality = this.updateRowPredictionQuality.bind(this);
				return this.callParent(arguments);
			},

			/**
			 * Run process for similar case search.
			 */
			findSimilarCases: function() {
				this.sendAnalytics(this.findSimilarTag);
				const processParameters = {
					"CaseId": this.$MasterRecordId
				};
				ProcessModuleUtilities.executeProcess({
					"sysProcessName": this.findSimilarProcessCode,
					"parameters": processParameters,
					"callback": function() {
						this.updateDetail({
							reloadAll: true
						});
						this.hideBodyMask();
					},
					"scope": this
				});
			},

			/**
			 * Sets sorting order for columns.
			 * @overriden
			 */
			getGridDataColumns: function() {
				const gridDataColumns = this.callParent(arguments);
				gridDataColumns.Score = {
					path: "Score",
					orderPosition: 0,
					orderDirection: this.BPMSoft.OrderDirection.DESC
				};
				return gridDataColumns;
			}
		}
	};
});
