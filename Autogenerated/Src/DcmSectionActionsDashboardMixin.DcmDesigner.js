define("DcmSectionActionsDashboardMixin", [
	"DcmSectionActionsDashboardMixinResources",
	"ProcessModuleV2",
	"SectionActionsDashboard",
	"DcmSchemaManager",
	"DcmElementSchemaManager"
], function(resources, ProcessModule) {

	/**
	 * Provides the ability to work with dcm schema.
	 */
	Ext.define("BPMSoft.configuration.mixins.DcmSectionActionsDashboardMixin", {
		alternateClassName: "BPMSoft.DcmSectionActionsDashboardMixin",

		/**
		 * Collection of allowed actions.
		 * @type {BPMSoft.Collection}
		 */
		permissionsStages: null,

		//region Methods: Private

		/**
		 * Returns dcm schema config.
		 * @private
		 * @return {Object}
		 */
		getDcmConfig: function() {
			return this.getMasterEntityParameterValue("DcmConfig") || {};
		},

		/**
		 * Init DcmSchema instance.
		 * @private
		 * @param {String} dcmSchemaUId Dcm schema ID.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initDcmSchema: function(dcmSchemaUId, callback, scope) {
			if (BPMSoft.Features.getIsEnabled("UseDcmSchemaInfoInDcmActionsDashboard")) {
				BPMSoft.DcmSchemaManager.getSchemaInfo(dcmSchemaUId, callback, scope);
				return;
			}
			BPMSoft.chain(
				function(next) {
					BPMSoft.DcmElementSchemaManager.initialize(next, this);
				},
				function() {
					BPMSoft.DcmSchemaManager.getSchemaInstance(dcmSchemaUId, callback, scope);
				}, this
			);
		},

		/**
		 * Init ActionsColumnName property.
		 * @private
		 */
		initActionsColumnName: function() {
			const dcmSchema = this.get("DcmSchema");
			const entitySchema = this.get("EntitySchema");
			const actionsColumn = BPMSoft.findWhere(entitySchema.columns, {uId: dcmSchema.stageColumnUId});
			this.set("ActionsColumnName", actionsColumn && actionsColumn.name);
		},

		/**
		 * Creates item for actions collection.
		 * @private
		 * @param {BPMSoft.Designers.DcmSchemaStage} stage Dcm schema stage.
		 * @return {BPMSoft.BaseViewModel}
		 */
		createDcmActionsItem: function(stage) {
			const item = Ext.create("BPMSoft.BaseViewModel");
			item.set("Id", stage.stageRecordId);
			item.set("Caption", this._getStageCaption(stage));
			item.set("Color", stage.color);
			item.set("StageUId", stage.uId);
			item.set("ParentStageUId", stage.parentStageUId || "");
			if (this.getIsFeatureEnabled("DcmStagesPermissions")) {
				item.set("Permissions", stage.permissions || "");
				item.set("UsePermissions", stage.usePermissions || false);
			}
			return item;
		},

		/**
		 * Sets availableStages property for action object.
		 * @private
		 * @param {BPMSoft.model.BaseViewModel} actionsItem Actions collection item.
		 */
		setDcmAvailableStages: function(actionsItem) {
			const dcmSchema = this.get("DcmSchema");
			const sourceStageUId = actionsItem.get("StageUId");
			const outgoingConnections = dcmSchema.stageConnections.getOutgoingConnections(sourceStageUId);
			const availableStages = outgoingConnections.map(function(connection) {
				const referenceStage = dcmSchema.stages.get(connection.target);
				return referenceStage.stageRecordId;
			});
			actionsItem.set("AvailableStages", availableStages);
		},

		/**
		 * Creates collection of actions.
		 * @private
		 * @return {BPMSoft.BaseViewModelCollection}
		 */
		createDcmActionsCollection: function() {
			const dcmSchema = this.get("DcmSchema");
			const stages = dcmSchema.stages;
			const collection = Ext.create("BPMSoft.BaseViewModelCollection");
			stages.each(function(stage) {
				const actionsItem = this.createDcmActionsItem(stage);
				this.setDcmAvailableStages(actionsItem);
				collection.add(stage.stageRecordId, actionsItem);
			}, this);
			return collection;
		},

		/**
		 * Init ActionsCollection property.
		 * @private
		 */
		initDcmActionsCollection: function() {
			let collection = this.createDcmActionsCollection();
			collection = this.createActionsMenu(collection);
			this.handleActiveActionChange(collection);
		},

		/**
		 * Set attribute IsActualDcmSchema by module DcmConfig.
		 * @private
		 * @param {Object} dcmConfig Dcm config object.
		 */
		setIsActualDcmSchema: function(dcmConfig) {
			const dcmSchemaUId = dcmConfig.dcmSchemaUId;
			const actualDcmSchemaUId = dcmConfig.actualDcmSchemaUId;
			this.set("IsActualDcmSchema", actualDcmSchemaUId && dcmSchemaUId !== actualDcmSchemaUId);
		},

		/**
		 * Asks user to confirm cancel current dcmSchema.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Boolean} callback.result Flag that indicates whether user confirm to cancel case or not.
		 * @param {Object} scope The scope of callback function.
		 */
		confirmCancelCurrentDcmSchema: function(callback, scope) {
			const confirmMessage = resources.localizableStrings.ConfirmCancelCurrentCaseMessage;
			const yesButtonCaption = resources.localizableStrings.ContinueButtonCaption;
			const yes = BPMSoft.MessageBoxButtons.YES.returnCode;
			const cancel = BPMSoft.MessageBoxButtons.CANCEL.returnCode;
			const yesButton = {
				className: "BPMSoft.Button",
				returnCode: yes,
				caption: yesButtonCaption
			};
			this.showConfirmationDialog(confirmMessage, function(returnCode) {
				callback.call(scope, returnCode === yes);
			}, [yesButton, cancel], {defaultButton: 1});
		},

		/**
		 * @private
		 */
		_changeToAppropriateDcmInstance: function(callback, scope) {
			const recordId = this.getEntitySchemaPrimaryColumnValue();
			const request = Ext.create("BPMSoft.ChangeToAppropriateDcmInstanceRequest", {
				entitySchemaName: this.$EntitySchema.name,
				recordId: recordId,
				currentStageId: this.$ActiveActionId
			});
			request.execute(callback, scope);
		},

		/**
		 * Returns entity schema query for select process data ID for running dcmSchema process.
		 * @private
		 * @return {BPMSoft.EntitySchemaQuery}
		 */
		getRunningProcessDataIdEsq: function() {
			const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SysProcessData"
			});
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, "Id");
			const recordId = this.getEntitySchemaPrimaryColumnValue();
			const filter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"[SysProcessElementData:SysProcess:Id].[SysEntityCommonPrcEl:ProcessElement:Id].RecordId",
				recordId);
			esq.filters.addItem(filter);
			return esq;
		},

		/**
		 * Returns process data ID for running dcmSchema process.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {String} callback.processDataId Process data ID.
		 * @param {Object} scope The scope of callback function.
		 */
		getRunningProcessDataId: function(callback, scope) {
			const esq = this.getRunningProcessDataIdEsq();
			esq.getEntityCollection(function(response) {
				const result = response.collection.first();
				const processDataId = result && result.get("Id");
				callback.call(scope, processDataId);
			}, scope);
		},

		/**
		 * Cancel running dcmSchema by process data ID.
		 * @private
		 * @param {String} processDataId Process data record ID.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		cancelDcmSchema: function(processDataId, callback, scope) {
			ProcessModule.services.cancelExecution(scope, {processDataIds: processDataId}, callback);
		},

		/**
		 * Run actual dcmSchema process by saving record.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		runActualDcmSchema: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					const dcmConfig = this.getDcmConfig();
					this.initDcmSchema(dcmConfig.actualDcmSchemaUId, next, this);
				},
				function(next, dcmSchemaInstance) {
					const firstStage = dcmSchemaInstance.stages.first();
					const stageCaption = this._getStageCaption(firstStage);
					const stageId = firstStage.stageRecordId;
					this.set("ActiveActionId", stageId);
					const columnName = this.get("ActionsColumnName");
					this.setMasterEntityParameterValue(columnName, {value: stageId, displayValue: stageCaption});
					this.sandbox.publish("SaveRecord", {isSilent: true, callback: next}, [this.sandbox.id]);
				},
				function() {
					callback.call(scope);
				}, this
			);
		},

		/**
		 * Reload ActionDashboard control for new running dcmSchema.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		reloadActionsDashboard: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					const sandbox = this.sandbox;
					sandbox.publish("UpdateDcmActionsDashboardConfig", {callback: next, scope: this}, [sandbox.id]);
				},
				function(next) {
					const dcmConfig = this.getDcmConfig();
					this.setIsActualDcmSchema(dcmConfig);
					this.initDcmSchema(dcmConfig.dcmSchemaUId, next, this);
				},
				function(next, dcmSchemaInstance) {
					this.set("DcmSchema", dcmSchemaInstance);
					this._initStageLookupData(next, this);
				},
				function(next) {
					this.initDcmActionsAndPermissions(next, this);
				},
				function() {
					this.onReloadDashboardItems();
					callback.call(scope);
				}, this
			);
		},

		/**
		 * Change dcmSchema to actual.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		changeDcmSchema: function(callback, scope) {
			const isEnabled = BPMSoft.Features.getIsEnabled("ChangeToAppropriateDcmInstance");
			const actions = [function(next) {
				this.sandbox.publish("SaveRecord", {isSilent: true, callback: next}, [this.sandbox.id]);
			}];
			if (isEnabled) {
				actions.push(this._changeToAppropriateDcmInstance);
			} else {
				actions.push(this.getRunningProcessDataId);
				actions.push(function(next, processDataId) {
					processDataId ? this.cancelDcmSchema(processDataId, next, this) : next();
				});
				actions.push(this.runActualDcmSchema);
			}
			actions.push(this.reloadActionsDashboard);
			actions.push(function() {
				callback.call(scope);
			});
			BPMSoft.chain.apply(this, actions);
		},

		/**
		 * Change dcmSchema to actual with user confirmation.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		tryChangeDcmSchema: function(callback, scope) {
			this.confirmCancelCurrentDcmSchema(function(result) {
				if (result) {
					this.changeDcmSchema(callback, scope);
				} else {
					callback.call(scope);
				}
			}, this);
		},

		/**
		 * Reset stage column depends on starting dcm schema.
		 * @private
		 */
		resetStageColumn: function() {
			if (this._canResetStageColumn()) {
				const firstStage = this.get("ActionsCollection").first();
				const id = firstStage.get("Id");
				const caption = firstStage.get("Caption");
				this.set("ActiveActionId", id);
				const columnName = this.get("ActionsColumnName");
				this.setMasterEntityParameterValue(columnName, {
					value: id,
					displayValue: caption
				});
			}
		},

		/**
		 * @private
		 */
		_canResetStageColumn: function() {
			const dcmConfig = this.getDcmConfig();
			return !dcmConfig.runningSchemaUId && dcmConfig.actualDcmSchemaUId &&
				this._getIsDcmFilteredColumnsChanged();
		},

		/**
		 * @private
		 */
		_getStageCaption: function(stage) {
			const stageLookupData = this.get("StageLookupData");
			const lookupItem = stageLookupData[stage.stageRecordId];
			return lookupItem || (stage.caption || "").toString();
		},

		/**
		 * @private
		 */
		_initStageLookupData: function(callback, scope) {
			this.set("StageLookupData", null);
			const dcmSchema = this.get("DcmSchema");
			if (!dcmSchema) {
				return Ext.callback(callback, scope);
			}
			const entitySchema = this.get("EntitySchema");
			const actionsColumn = _.find(entitySchema.columns, {uId: dcmSchema.stageColumnUId});
			const actionsSchemaName = actionsColumn.referenceSchemaName;
			let primaryColumnName, primaryDisplayColumnName;
			BPMSoft.chain(
				function(next) {
					this.set("ActionsSchemaName", actionsSchemaName);
					this.setActionsPrimaryColumnNames(next, this);
				},
				function(next) {
					primaryColumnName = this.get("ActionsPrimaryColumnName");
					primaryDisplayColumnName = this.get("ActionsPrimaryDisplayColumnName");
					const selectConfig = {
						entitySchemaName: actionsSchemaName,
						addToStore: true,
						columnsInfo: [
							{columnName: primaryColumnName},
							{columnName: primaryDisplayColumnName}
						]
					};
					BPMSoft.DataManager.select(selectConfig, next, this);
				},
				function(next, dataCollection) {
					const stageLookupData = {};
					dataCollection.collection.each(function(item) {
						const viewModel = item.viewModel;
						const id = viewModel.get(primaryColumnName);
						const caption = viewModel.get(primaryDisplayColumnName);
						stageLookupData[id] = caption;
					}, this);
					this.set("StageLookupData", stageLookupData);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * @private
		 */
		_getIsDcmFilteredColumnsChanged: function() {
			return this.sandbox.publish("IsDcmFilterColumnChanged", null, [this.sandbox.id]);
		},

		//endregion

		//region Methods: Protected

		/**
		 * Init ActionsCollection property.
		 * @protected
		 */
		initDcmActionsInternal: function() {
			this.initActionsColumnName();
			this.setActiveActionId();
			this.initDcmActionsCollection();
		},

		//endregion

		//region Methods: Public

		/**
		 * Init DcmConfig initial values.
		 */
		initDcmConfig: function() {
			const dcmConfig = this.getDcmConfig();
			this.values = this.values || {};
			Ext.mergeIf(this.values, dcmConfig);
		},

		/**
		 * Init Dcm ActionsDashboard, init DcmSchema if needed.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initDcmActionsDashboard: function(callback, scope) {
			const dcmConfig = this.getDcmConfig();
			this.setIsActualDcmSchema(dcmConfig);
			const dcmSchema = this.get("DcmSchema");
			const dcmSchemaUId = dcmConfig.dcmSchemaUId;
			if (dcmSchema || !dcmSchemaUId) {
				return callback.call(scope);
			}
			BPMSoft.chain(
				function(next) {
					this.initDcmSchema(dcmSchemaUId, next, this);
				},
				function(next, dcmSchemaInstance) {
					this.set("DcmSchema", dcmSchemaInstance);
					this._initStageLookupData(next, this);
				},
				function() {
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Initialize permissionsStages collection.
		 * @param {Guid} dcmSchemaUId Dcm schema unique identifier.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		initPermissionsStages: function(dcmSchemaUId, callback, scope) {
			if (!dcmSchemaUId) {
				const dcmSchema = this.get("DcmSchema");
				dcmSchemaUId = dcmSchema && dcmSchema.uId;
			}
			if (this.getIsFeatureDisabled("DcmStagesPermissions") || !dcmSchemaUId) {
				return Ext.callback(callback, scope);
			}
			this.callService({
				serviceName: "DcmService",
				methodName: "GetAllowedStagesForCurrentUser",
				data: {
					dcmSchemaUId: dcmSchemaUId
				}
			}, function(response) {
				const result = response.GetAllowedStagesForCurrentUserResult;
				const permissionsStages = Ext.create("BPMSoft.Collection");
				if (result) {
					result.forEach(function (item) {
						permissionsStages.add(item, item);
					}, this);
				}
				this.set("permissionsStages", permissionsStages);
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * Get can use action, exist action StageUId in allowed stages.
		 * @param {BPMSoft.BaseViewModel} action Stage control items.
		 * @return {boolean} True, if permissions is available for current user, otherwise false.
		 */
		getCanUseAction: function(action) {
			const permissionStages = this.get("permissionsStages");
			if (this.getIsFeatureDisabled("DcmStagesPermissions") || this.isEmpty(permissionStages)) {
				return true;
			}
			return permissionStages.contains(action.$StageUId);
		},

		/**
		 * Reinitialize section actions dashboard.
		 */
		reInitializeActionsDashboard: function() {
			const dcmConfig = this.getDcmConfig();
			this.setIsActualDcmSchema(dcmConfig);
			const dcmSchemaUId = dcmConfig.dcmSchemaUId;
			if (dcmSchemaUId) {
				BPMSoft.chain(
					function(next) {
						this.initDcmSchema(dcmSchemaUId, next, this);
					},
					function(next, dcmSchemaInstance) {
						this.set("DcmSchema", dcmSchemaInstance);
						this._initStageLookupData(next, this);
					},
					function(next) {
						this.initDcmActionsAndPermissions(next, this);
					},
					function() {
						this.resetStageColumn();
						this.set("HeaderVisible", true);
					}, this
				);
			} else {
				const hasAnyDcm = this.getMasterEntityParameterValue("HasAnyDcm");
				if (hasAnyDcm) {
					this.set("HeaderVisible", false);
				}
				this.set("DcmSchema", null);
			}
		},

		/**
		 * Determines whether the item is the menu item to the previous item.
		 * @param {BPMSoft.model.BaseViewModel} item Target menu item.
		 * @param {BPMSoft.model.BaseViewModel} previousItem Previous menu item.
		 * @return {Boolean}
		 */
		isDcmMenuItem: function(item, previousItem) {
			const itemUId = previousItem && previousItem.get("StageUId");
			const parentStageUId = item.get("ParentStageUId");
			return parentStageUId === itemUId;
		},

		/**
		 * Handler for click on ActualDcmSchemaInformation button link.
		 */
		onActualDcmSchemaInformationButtonLinkClick: function() {
			const maskId = BPMSoft.Mask.show("#centerPanelContainer");
			this.tryChangeDcmSchema(function() {
				BPMSoft.Mask.hide(maskId);
			}, this);
			return false;
		},

		/**
		 * Init ActionsCollection and stage permissions.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		initDcmActionsAndPermissions: function(callback, scope) {
			this.initPermissionsStages(null, function() {
				this.initDcmActionsInternal();
				Ext.callback(callback, scope);
			}, this);
		},

		/**
		 * Init ActionsCollection property.
		 * @deprecated Use {@link #initDcmActionsAndPermissions} instead.
		 */
		initDcmActions: function() {
			this.initDcmActionsInternal();
		},

		/**
		 * Returns value of the ViewModel parameter.
		 * @param {String} parameterName Name of the ViewModel parameter.
		 * @return {Object} Value.
		 */
		getMasterEntityParameterValue: function(parameterName) {
			const sandbox = this.sandbox;
			const result = sandbox.publish("GetColumnsValues", [parameterName], [sandbox.id]) || {};
			return result[parameterName];
		},

		/**
		 * @deprecated Will be removed in the future releases.
		 */
		getIsMasterEntityChanged: function() {
			return this.sandbox.publish("IsEntityChanged", null, [this.sandbox.id]);
		}

		//endregion

	});

	return Ext.create("BPMSoft.DcmSectionActionsDashboardMixin");
});
