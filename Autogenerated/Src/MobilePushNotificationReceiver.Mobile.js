/**
 * @class BPMSoft.configuration.PushNotificationReceiver
 * @abstract
 */
Ext.define("BPMSoft.configuration.PushNotificationReceiver", {
	extend: "BPMSoft.nativeApi.BasePushNotificationReceiver",
	alternateClassName: "BPMSoft.PushNotificationReceiver",

	/**
	 * @private
	 */
	synchronizeToCacheIfNeeded: function(modelName) {
		return new Promise(function(resolve) {
			if (!BPMSoft.ModelCache.isEnabled()) {
				resolve();
				return;
			}
			var cacheManager = BPMSoft.ModelCache.getManager(modelName);
			if (cacheManager && cacheManager instanceof BPMSoft.SynchronizableCacheManager) {
				BPMSoft.Mask.show();
				cacheManager.synchronizeToCache({
					cancellationId: BPMSoft.util.genGuid(),
				}).then(function() {
					BPMSoft.Mask.hide();
					resolve();
				}).catch(function(exception) {
					BPMSoft.Mask.hide();
					BPMSoft.Logger.error(exception);
				});
			} else {
				resolve();
			}
		});
	},

	/**
	 * @private
	 */
	openVisa: function(visaRecordId, visaEntityName) {
		BPMSoft.util.openFlutterPage({
			routeName: "VisaScreen",
			routeArguments: {
				recordId: visaRecordId,
				schemaName: visaEntityName
			},
			replace: false
		});
	},
	
	/**
	 * @private
	 */
	openFlutterEditPage: function(entityName, recordId) {
		if (!Ext.isFunction(BPMSoft.util.openFlutterPageByMetadata)) {
			BPMSoft.Logger.warn("There is no BPMSoft.util.openFlutterPageByMetadata in this version of app. You must update app");
			return;
		}
		BPMSoft.util.openFlutterPageByMetadata({
			type: BPMSoft.ScreenType.Edit,
			entityName: entityName,
			recordId: recordId
		});
	},

	/**
	 * Adds grid page to history state if there is no page has been opened.
	 * @protected
	 * @virtual
	 *
	 * @param {String} modelName Name of model
	 */
	openGridIfNeeded: function(modelName) {
		var mainController = BPMSoft.util.getMainController();
		var mainPageView = mainController.getView();
		var cardIsEmpty = mainPageView.getCardIsEmpty();
		if (cardIsEmpty) {
			mainPageView.setCardIsEmpty(false);
			mainPageView.selectByName(modelName, false, true);
			mainPageView.closeMenu();
			BPMSoft.util.openGridPage(modelName, {
				isStartPage: true,
				routeConfig: {
					skipLoading: true
				}
			});
		}
	},

	/**
	 * Opens page.
	 * @protected
	 * @virtual
	 * @param {String} modelName Name of model
	 * @param {String} recordId Id of recoed
	 */
	openPage: function(modelName, recordId) {
		var modelConfig = BPMSoft.ApplicationConfig.getModelConfig(modelName);
		var pageName = modelConfig && modelConfig[BPMSoft.PageTypes.Preview];
		if (!pageName) {
			BPMSoft.Logger.warn("PushNotificationReceiver.openPage: " +
				"Page for model '" + modelName + "' not found while opening page.");
			return;
		}
		this.openGridIfNeeded(modelName);
		BPMSoft.util.openPreviewPage(modelName, {
			recordId: recordId
		});
	},

	/**
	 * Checks, if record exists.
	 * @protected
	 * @virtual
	 * @param {String} modelName Name of model.
	 * @param {String} recordId Id of record.
	 * @param {Function} callback Callback function.
	 */
	checkRecordExistence: function(modelName, recordId, callback) {
		BPMSoft.StructureLoader.loadModelsWithDependencies({
			modelNames: [modelName],
			success: function() {
				var model = Ext.ClassManager.get(modelName);
				if (!model) {
					BPMSoft.Logger.warn("PushNotificationReceiver.checkRecordExistence: " +
						"Model with name '" + modelName + "' not found");
					return;
				}
				var queryConfig = Ext.create("BPMSoft.QueryConfig", {
					modelName: modelName,
					columns: [model.PrimaryColumnName]
				});
				model.load(recordId, {
					isCancelable: false,
					queryConfig: queryConfig,
					success: function(record) {
						var isExisted = !Ext.isEmpty(record);
						Ext.callback(callback, this, [isExisted]);
					},
					failure: function(record, operation) {
						var exception = operation.getError();
						BPMSoft.Logger.logException(BPMSoft.LogSeverityLevel.Error, exception);
						if (exception && exception instanceof BPMSoft.ODataItemNotFoundException) {
							Ext.callback(callback, this, [false]);
						}
					},
					scope: this
				});
			},
			scope: this
		});
	},

	/**
	 * Checks, if module available for opening preview page.
	 * @protected
	 * @virtual
	 * @param {String} moduleName Name of module.
	 * @return {Boolean} True, if available.
	 */
	checkIfModuleAvailable: function(moduleName) {
		var moduleConfig = BPMSoft.ApplicationConfig.getModuleConfig(moduleName);
		return moduleConfig && !moduleConfig.Hidden;
	},

	/**
	 * Called when notification has been tapped.
	 * @protected
	 * @virtual
	 * @param {Object} data Notification data.
	 */
	onTap: function(data) {
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "push",
				entityName: (!Ext.isEmpty(data)) ? data.entityName || data.visaEntityName : null,
				additionalInfo: (!Ext.isEmpty(data)) ? BPMSoft.encode(data) : null,
			}
		});
		if (data.visaRecordId && BPMSoft.Features.getIsEnabled("UseMobileFlutterApprovals")) {
			this.openVisa(data.visaRecordId, data.visaEntityName);
			return;
		}
		if (Ext.isEmpty(data.entityName) || Ext.isEmpty(data.recordId)) {
			return;
		}
		if (!this.checkIfModuleAvailable(data.entityName)) {
			BPMSoft.MessageBox.showMessage(BPMSoft.LS["PushNotificationReceiver.ModuleIsNotAvailable"]);
		} else {
			this.checkRecordExistence(data.entityName, data.recordId, function(isExisted) {
				if (isExisted) {
					this.synchronizeToCacheIfNeeded(data.entityName).then(function() {
						var entityName = data.entityName;
						var recordId = data.recordId;
						var moduleConfig = BPMSoft.ApplicationConfig.getModuleConfig(entityName);
						var isFlutterPage = moduleConfig && moduleConfig.screens;
						if (isFlutterPage) {
							this.openFlutterEditPage(entityName, recordId);
						} else {
							this.openPage(entityName, recordId);
						}
					}.bind(this));
				} else {
					var errorMessage = BPMSoft.ApplicationUtils.isOnlineMode() ?
						BPMSoft.LS["PushNotificationReceiver.RecordNotFound"] :
						BPMSoft.LS["PushNotificationReceiver.RecordNotLoaded"];
					BPMSoft.MessageBox.showMessage(errorMessage);
				}
			});
		}
	}

});

BPMSoft.PushNotification.setDefaultReceiver("BPMSoft.PushNotificationReceiver");
