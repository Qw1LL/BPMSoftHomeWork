define("DcmPageMixin", ["ext-base", "BPMSoft", "DcmPageMixinResources", "DcmMixin"
], function(Ext, BPMSoft) {
	Ext.define("BPMSoft.configuration.mixins.DcmPageMixin", {
		extend: "BPMSoft.configuration.mixins.DcmMixin",
		alternateClassName: "BPMSoft.DcmPageMixin",

		activityConnectionColumnName: null,

		/**
		 * Event filter column names.
		 * @private
		 * @type {String}
		 */
		_eventFilterColumnNames: null,

		/**
		 * Array filtered columns.
		 * @private
		 * @type {Array}
		 */
		_filteredColumns: null,

		//region Methods: Private

		/**
		 * Returns EntitySchemaQuery for schema EntityConnection filtered by SysEntitySchemaUId.
		 * @private
		 * @param {String} entitySchemaUId Entity schema unique identifier.
		 * @return {BPMSoft.EntitySchemaQuery}
		 */
		getEntityConnectionSchemaQuery: function(entitySchemaUId) {
			const config = {
				rootSchemaName: "EntityConnection",
			};
			if (BPMSoft.Features.getIsEnabled("DcmOptimizationFeature")) {
				config.clientESQCacheParameters = {
					cacheItemName: "EntityConnection_" + entitySchemaUId,
				};
			}
			const esq = new BPMSoft.EntitySchemaQuery(config);
			esq.addColumn("ColumnUId");
			const filter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"SysEntitySchemaUId", entitySchemaUId);
			esq.filters.addItem(filter);
			return esq;
		},

		/**
		 * Looking for activity connection reference column name for current page entity schema.
		 * @private
		 * @param {Function} callback The callback function.
		 * @param {String} callback.column Found column name or empty string.
		 * @param {Object} scope The scope of callback function.
		 */
		findActivityConnectionColumnName: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					if (!Ext.isEmpty(this.activityConnectionColumnName, true)) {
						callback.call(scope, this.activityConnectionColumnName);
					} else if (BPMSoft.Features.getIsEnabled("DcmOptimizationFeature")) {
						BPMSoft.require(["Activity"], next, this);
					} else {
						this.getEntitySchemaByName("Activity", next, this);
					}
				},
				function(next, activity) {
					const esq = this.getEntityConnectionSchemaQuery(activity.uId);
					esq.getEntityCollection(function(result) {
						let referenceColumn = null;
						result.collection.each(function(item) {
							referenceColumn = BPMSoft.findWhere(activity.columns, {
								uId: item.get("ColumnUId"),
								referenceSchemaName: this.entitySchemaName
							});
							if (referenceColumn) {
								return false;
							}
						}, this);
						if (!referenceColumn) {
							console.warn("Column" + this.entitySchemaName + " was not found in EntityCollection for Activity schema");
						}
						this.activityConnectionColumnName = referenceColumn ? referenceColumn.name : "";
						callback.call(scope, this.activityConnectionColumnName);
					}, this);
				}, this
			);
		},

		/**
		 * Subscribes on view model column changes to actualize DcmActionsDashboard.
		 * @private
		 * @param {Function} callback The Callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		subscribeOnColumnsChange: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					BPMSoft.DcmUtilities.getFilteredColumns(this, next, this);
				},
				function(next, filteredColumns) {
					this._filteredColumns = Ext.clone(filteredColumns);
					if (filteredColumns.length > 0) {
						const eventNames = filteredColumns.map(function(columnName) {
							return "change:" + columnName;
						});
						const event = this._eventFilterColumnNames = eventNames.join(" ");
						this.on(event, this.actualizeDcmActionsDashboard, this);
					}
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Set empty dcm config (when HasAnyDcm is false).
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		setEmptyDcmConfig: function(callback, scope) {
			BPMSoft.chain(
				(next) => this.createDcmConfig({}, next, this),
				(next, dcmConfig) => {
					this.set("DcmConfig", dcmConfig);
					this.set("HasActiveDcm", false);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Updates DcmActionsDashboardModule configuration.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		updateDcmActionsDashboardConfig: function(callback, scope) {
			if (!this.get("HasAnyDcm")) {
				this.setEmptyDcmConfig(callback, scope);
				return;
			}
			BPMSoft.chain(
				function(next) {
					BPMSoft.DcmUtilities.findRunningDcmSchemaUId(this, next, this);
				},
				function(next, runningSchemaUId, isRunningSchemaActive) {
					if (runningSchemaUId && BPMSoft.DcmSchemaManager.getCanUseProcessVersions()) {
						BPMSoft.DcmSchemaManager.findItemByUId(runningSchemaUId, function (item) {
							Ext.callback(next, this, [runningSchemaUId, isRunningSchemaActive, item.versionParentUId]);
						}, this);
					} else {
						Ext.callback(next, this, [runningSchemaUId, isRunningSchemaActive]);
					}
				},
				function(next, runningSchemaUId, isRunningSchemaActive, runningSchemaVersionParentUId) {
					const dcmSchemaManagerItem = BPMSoft.DcmUtilities.findActualDcmSchemaManagerItem(this);
					const actualSchemaUId = dcmSchemaManagerItem ? dcmSchemaManagerItem.getUId() : null;
					const isAnotherVersionActual = actualSchemaUId !== runningSchemaUId &&
						runningSchemaVersionParentUId === dcmSchemaManagerItem?.versionParentUId;
					const config = {
						dcmSchemaUId: isRunningSchemaActive ? runningSchemaUId : actualSchemaUId,
						actualDcmSchemaUId: actualSchemaUId,
						runningSchemaUId: runningSchemaUId,
						isAnotherVersionActual: isAnotherVersionActual
					};
					this.createDcmConfig(config, next, this);
				},
				function(next, dcmConfig) {
					this.set("DcmConfig", dcmConfig);
					this.set("HasActiveDcm", true);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Update information about running dcm schema. Applied for feature: DcmOptimizationFeature
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		updateRunningDcmSchema: function(callback, scope) {
			if (!this.get("HasAnyDcm")) {
				this.setEmptyDcmConfig(callback, scope);
				return;
			}
			BPMSoft.chain(
				(next) => BPMSoft.DcmUtilities.findRunningDcmSchemaUId(this, next, this),
				(next, runningSchemaUId, isRunningSchemaActive) => {
					if (runningSchemaUId && BPMSoft.DcmSchemaManager.getCanUseProcessVersions()) {
						BPMSoft.DcmSchemaManager.findItemByUId(runningSchemaUId, function (item) {
							next(runningSchemaUId, isRunningSchemaActive, item.versionParentUId);
						}, this);
					} else {
						next(runningSchemaUId, isRunningSchemaActive);
					}
				},
				(next, runningSchemaUId, isRunningSchemaActive, runningSchemaVersionParentUId) => {
					const config = {
						dcmSchemaUId: isRunningSchemaActive ? runningSchemaUId : null,
						runningSchemaUId: runningSchemaUId,
					};
					this.set("DcmRunningConfig", {
						runningSchemaUId: runningSchemaUId,
						isRunningSchemaActive: isRunningSchemaActive,
						runningSchemaVersionParentUId: runningSchemaVersionParentUId,
					});
					this.createDcmConfig(config, next, this);
				},
				(next, dcmConfig) => {
					this.set("DcmConfig", {
						...dcmConfig,
						...this.get("DcmConfig"),
					});
					this.set("HasActiveDcm", true);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Update information about actual dcm schema. Applied for feature: DcmOptimizationFeature
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 */
		updateActualDcmSchema: function(callback, scope) {
			if (!this.get("HasAnyDcm")) {
				this.setEmptyDcmConfig(callback, scope);
				return;
			}
			BPMSoft.chain(
				(next) => {
					if (this.get("DcmRunningConfig")) {
						next();
					} else {
						this.on("change:DcmRunningConfig", next, this);
					}
				},
				(next) => {
					const {isRunningSchemaActive, runningSchemaUId, runningSchemaVersionParentUId} = this.get("DcmRunningConfig");
					const dcmSchemaManagerItem = BPMSoft.DcmUtilities.findActualDcmSchemaManagerItem(this);
					const actualSchemaUId = dcmSchemaManagerItem ? dcmSchemaManagerItem.getUId() : null;
					const isAnotherVersionActual = actualSchemaUId !== runningSchemaUId &&
						runningSchemaVersionParentUId === dcmSchemaManagerItem?.versionParentUId;
					const config = {
						dcmSchemaUId: isRunningSchemaActive ? runningSchemaUId : actualSchemaUId,
						actualDcmSchemaUId: actualSchemaUId,
						runningSchemaUId: runningSchemaUId,
						isAnotherVersionActual: isAnotherVersionActual,
					};
					this.createDcmConfig(config, next, this);
				},
				(next, dcmConfig) => {
					this.set("DcmConfig", dcmConfig);
					this.set("HasActiveDcm", true);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Creates new dcm module config.
		 * @private
		 * @param {Object} config Configuration object.
		 * @param {String} config.dcmSchemaUId Current dcm schema identifier.
		 * @param {String} [config.actualDcmSchemaUId] Actual dcm schema identifier.
		 * @param {String} config.runningSchemaUId Running dcm schema identifier.
		 * @param {boolean} [config.isAnotherVersionActual] Whether another version ia actual.
		 * @param {boolean} [config.isRunningSchemaActive] Whether running schema is active.
		 * @param {String} [config.runningSchemaVersionParentUId] Running dcm schema version parent identifier.
		 * @param {Function} callback The callback function.
		 * @param {Object} callback.dcmConfig New dcm config.
		 * @param {Object} scope The scope of callback function.
		 */
		createDcmConfig: function(config, callback, scope) {
			const newDcmConfig = {
				"dcmSchemaUId": config.dcmSchemaUId || null,
				"actualDcmSchemaUId": config.actualDcmSchemaUId || null,
				"runningSchemaUId": config.runningSchemaUId || null,
				"isAnotherVersionActual": config.isAnotherVersionActual || false,
				"isRunningSchemaActive": config.isRunningSchemaActive || false,
				"runningSchemaVersionParentUId": config.runningSchemaVersionParentUId || null,
				"entitySchemaName": this.entitySchemaName
			};
			BPMSoft.chain(
				function(next) {
					this.findActivityConnectionColumnName(next, this);
				},
				function(next, activityColumnName) {
					if (activityColumnName) {
						newDcmConfig.dashboardConfig = {
							"Activity": {
								"masterColumnName": "Id",
								"referenceColumnName": activityColumnName,
								"referenceColumnSchemaName": this.entitySchemaName
							}
						};
					}
					callback.call(scope, newDcmConfig);
				}, this
			);
		},

		/**
		 * Subscribes for ActionsDashboard messages.
		 * @private
		 */
		subscribeActionsDashboardMessages: function() {
			const dcmActionsDashboardModuleId = this.getModuleId("DcmActionsDashboardModule");
			this.sandbox.subscribe("UpdateDcmActionsDashboardConfig", function(config) {
				this.updateDcmActionsDashboardConfig(config.callback, config.scope);
			}, this, [dcmActionsDashboardModuleId]);
			this.sandbox.subscribe("IsDcmFilterColumnChanged", this._isDcmFilterColumnsChanged, this,
				[dcmActionsDashboardModuleId]);
		},

		/**
		 * @private
		 */
		_isDcmFilterColumnsChanged: function() {
			const changeColumns = this.getChangedEntityColumns();
			const result = _.intersection(changeColumns, this._filteredColumns);
			return result.length > 0;
		},

		//endregion

		//region Methods: Public

		/**
		 * Initializes DcmActionsDashboard visibility.
		 * @param {Function} [callback] Callback method.
		 * @param {Object} [scope] Callback method context.
		 */
		initDcmActionsDashboardVisibility: function(callback, scope) {
			if (!this.entitySchema) {
				this.set("HasActiveDcm", false);
				return Ext.callback(callback, scope);
			}
			if (!this.get("HasAnyDcm")) {
				BPMSoft.chain(
					function(next) {
						this.createDcmConfig({}, next, this);
					},
					function(next, dcmConfig) {
						this.set("DcmConfig", dcmConfig);
						this.set("HasActiveDcm", false);
						Ext.callback(callback, scope);
					}, this
				);
				return;
			}
			BPMSoft.chain(
				(nextOutside) => {
					if (BPMSoft.Features.getIsEnabled("DcmOptimizationFeature")) {
						BPMSoft.chain(
							(next) => this.updateRunningDcmSchema(next, this),
							() => nextOutside(),
							this
						);
					} else {
						BPMSoft.chain(
							(next) => this.subscribeOnColumnsChange(next, this),
							(next) => this.updateDcmActionsDashboardConfig(next, this),
							() => nextOutside(),
							this
						);
					}
				},
				() => {
					this.subscribeActionsDashboardMessages();
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Unsubscribes on view model column changes.
		 */
		unsubscribeOnColumnsChange: function() {
			this.un(this._eventFilterColumnNames, this.actualizeDcmActionsDashboard, this);
		},

		/**
		 * Actualize DcmActionsDashboard. If new dcm schema is available, sets actual DcmConfig attribute value and
		 * publish ReInitializeActionsDashboard message.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function call context.
		 */
		actualizeDcmActionsDashboard: function(callback, scope) {
			BPMSoft.chain(
				function(next) {
					this.updateDcmActionsDashboardConfig(next, this);
				},
				function() {
					const tags = [
						this.getModuleId("ActionsDashboardModule"),
						this.getModuleId("DcmActionsDashboardModule")
					];
					this.sandbox.publish("ReInitializeActionsDashboard", null, tags);
					Ext.callback(callback, scope);
				}, this
			);
		},

		/**
		 * Pre-initialize dcm actions dashboard visibility.
		 */
		preInitDcmActionsDashboardVisibility: function() {
			this.set("PreInitDcmActionsDashboardVisibility", true);
			if (!this.isNewMode()) {
				this.set("Id", this.get("PrimaryColumnValue"));
			}
			this.initDcmActionsDashboardVisibility();
		},

		/**
		 * Post-initialize dcm actions dashboard visibility.
		 */
		postInitDcmActionsDashboardVisibility: function() {
			if (this.get("PreInitDcmActionsDashboardVisibility")) {
				this.set("PreInitDcmActionsDashboardVisibility", false);
				BPMSoft.chain(
					(next) => this.subscribeOnColumnsChange(next, this),
					(next) => this.updateActualDcmSchema(next, this),
					this,
				);
			} else {
				this.initDcmActionsDashboardVisibility();
			}
		}

		//endregion

	});
	return Ext.create("BPMSoft.DcmPageMixin");
});
