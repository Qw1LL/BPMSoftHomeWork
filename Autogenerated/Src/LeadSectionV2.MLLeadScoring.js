define("LeadSectionV2", ["DesktopPopupNotification"],
	function(DesktopPopupNotification) {
		return {
			entitySchemaName: "Lead",

			methods: {

				/**
				 * Return name of lead by its id.
				 * @param {String} id Lead's id.
				 * @param {Function} callback Callback functions with lead name.
				 * @private
				 */
				_getLeadName: function(id, callback) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: this.entitySchemaName
					});
					esq.addColumn("LeadName");
					esq.getEntity(id, function(response) {
						var leadName = response.success ? response.entity.$LeadName : null;
						this.Ext.callback(callback, this, [leadName]);
					}, this);
				},

				/**
				 * Shows desktop notification after lead was successfully score.
				 * @param {String} leadId Lead's id.
				 * @param {Number} predictedScore The result of scoring.
				 * @private
				 */
				_showLeadScoredDesktopNotification: function(leadId, predictedScore) {
					this._getLeadName(leadId, function(leadName) {
						var config = DesktopPopupNotification.createConfig();
						var image = this.get("Resources.Images.MLIcon");
						var title = this.Ext.String.format(this.get("Resources.Strings.LeadScoredTitle"),
							leadName);
						var body = this.Ext.String.format(this.get("Resources.Strings.LeadScoredBody"),
							Math.round(predictedScore * 100));
						DesktopPopupNotification.show(Ext.apply(config, {
							title: title,
							body: body,
							icon: BPMSoft.ImageUrlBuilder.getUrl(image)
						}));
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseSectionV2#getSectionActions
				 * @override
				 */
				getSectionActions: function() {
					var actionMenuItems = this.callParent(arguments);
					actionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					actionMenuItems.addItem(this.getButtonMenuItem({
						Caption: "$Resources.Strings.ScoreLeadActionCaption",
						Enabled: {
							bindTo: "isSingleSelected"
						},
						ImageConfig: this.get("Resources.Images.MLIconSvg"),
						Click: {
							bindTo: "scoreLeadAction"
						}
					}));
					return actionMenuItems;
				},

				_sendScoreLeadActionAnalytics: function() {
					if (!this.$IsGoogleTagManagerEnabled) {
						return;
					}
					const data = this.getGoogleTagManagerData();
					this.Ext.apply(data, {
						action: "LeadScoringAction"
					});
					BPMSoft.GoogleTagManagerUtilities.actionModule(data);
				},

				/**
				 * Evaluates predictive score for selected lead entity.
				 */
				scoreLeadAction: function() {
					this._sendScoreLeadActionAnalytics();
					var activeRow = this.getActiveRow();
					var activeRowId = activeRow.get("Id");
					this.callService({
						serviceName: "MLPredictorService",
						methodName: "ScoreEntity",
						data: {
							entitySchemaUId: this.entitySchema.uId,
							entitySchemaTargetColumnUId: this.entitySchema.getColumnByName("PredictiveScore").uId,
							entityId: activeRowId
						}
					}, function(response) {
						var scoreEntityResult = response.result || {};
						var exitCode = scoreEntityResult.exitCode;
						if (exitCode === 0) {
							if (activeRow.get("PredictiveScore") != null) {
								activeRow.loadEntity(activeRowId);
							}
							this._showLeadScoredDesktopNotification(activeRowId, scoreEntityResult.predictedScore);
						} else {
							var errorMessage = exitCode === 1
								? "Resources.Strings.ScoreLeadActionNoModelsErrorMessage"
								: "Resources.Strings.ScoreLeadActionGeneralErrorMessage";
							BPMSoft.showErrorMessage(this.get(errorMessage));
						}
					}.bind(this));
				}

			},
			diff: /**SCHEMA_DIFF*/ [
			]/**SCHEMA_DIFF*/
		};
	});
