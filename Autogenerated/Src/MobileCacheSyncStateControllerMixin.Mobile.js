/**
 * @class BPMSoft.configuration.CacheSyncStateControllerMixin
 * Mixin that adds state of cache sync functionalilty in grid page.
 */
Ext.define("BPMSoft.configuration.CacheSyncStateControllerMixin", {
	alternateClassName: "BPMSoft.CacheSyncStateControllerMixin",

	/**
	 * @private
	 */
	hasExportConflicts: false,

	/**
	 * @private
	 */
	autoShowNoConnectionStatusPanel: null,

	/**
	 * @private
	 */
	stateData: null,

	/**
	 * @private
	 */
	isMainModelSynchronized: false,

	/**
	 * @private
	 */
	subscribeSyncManagerEvents: function() {
		BPMSoft.SyncManager.on("syncstart", this.onSynchronizationStarted, this);
		BPMSoft.SyncManager.on("syncfinish", this.onSynchronizationFinished, this);
		BPMSoft.SyncManager.on("syncfailed", this.onSynchronizationFailed, this);
	},

	/**
	 * @private
	 */
	unsubscribeSyncManagerEvents: function() {
		BPMSoft.SyncManager.un("syncstart", this.onSynchronizationStarted, this);
		BPMSoft.SyncManager.un("syncfinish", this.onSynchronizationFinished, this);
		BPMSoft.SyncManager.un("syncfailed", this.onSynchronizationFailed, this);
	},

	/**
	 * @private
	 */
	getImportLastSyncDateKey: function() {
		return this.getModelName() + "ImportLastSyncDate";
	},

	/**
	 * @private
	 */
	loadImportLastSyncDate: function() {
		var manager = this.getDataCacheManager();
		if (manager && manager instanceof BPMSoft.SynchronizableCacheManager) {
			return manager.getMainModelLastSyncDate();
		} else {
			return Promise.resolve();
		}
	},

	/**
	 * @private
	 */
	formatLastSyncDateMessage: function(lastSyncDate) {
		if (BPMSoft.util.isEmptyDate(lastSyncDate)) {
			return "";
		}
		var lastSyncDateFormatted = Ext.Date.format(lastSyncDate, BPMSoft.Date.getDateTimeFormat());
		return Ext.String.format("{0} {1}", BPMSoft.LS.GridPageLastSyncDateMessage, lastSyncDateFormatted);
	},

	/**
	 * @private
	 */
	getInformationPanelRefreshButtonConfig: function() {
		return {
			text: BPMSoft.LS.GridPageInformationPanelRefreshButtonText,
			cls: "cf-information-panel-refresh-button",
			iconCls: "ts-refresh-orange-icon",
			listeners: {
				tap: this.onInformationPanelRefreshButtonTap,
				scope: this
			}
		};
	},

	/**
	 * Initializes state of page.
	 * @protected
	 * @virtual
	 */
	initializePageState: function() {
		var isDetail = this.isDetail();
		if (!isDetail) {
			this.subscribeSyncManagerEvents();
			var view = this.getView();
			view.setState(BPMSoft.PageState.Default);
		}
	},

	/**
	 * Checks if main synchronization is finished.
	 * @protected
	 * @virtual
	 * @return {Boolean} True, if finished.
	 */
	isMainSyncFinished: function() {
		return !BPMSoft.SyncManager.hasActiveSyncOperations(BPMSoft.SyncRunType.Export) &&
			this.isMainModelSynchronized;
	},

	/**
	 * Sets page default state.
	 * @protected
	 * @virtual
	 */
	setDefaultState: function() {
		this.setState(BPMSoft.PageState.Default);
	},

	/**
	 * Sets page state for loading data action.
	 * @protected
	 * @virtual
	 */
	setDataLoadingState: function() {
		this.isMainModelSynchronized = false;
		this.setState(BPMSoft.PageState.DataLoading);
	},

	/**
	 * Handles state change.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.PageState} state State of page.
	 * @param {Object} stateData State properties.
	 */
	setState: function(state, stateData) {
		if (this.hasExportConflicts && state === BPMSoft.PageState.Default) {
			state = BPMSoft.PageState.DataLoadingError;
		} else {
			this.stateData = stateData;
		}
		if (state !== BPMSoft.PageState.DataLoading && state !== BPMSoft.PageState.NoConnection) {
			this.autoShowNoConnectionStatusPanel = false;
		}
		if (state === BPMSoft.PageState.NoConnection && this.autoShowNoConnectionStatusPanel) {
			this.showNoConnectionStateInformationPanel();
		}
	},

	/**
	 * Calls when cache model is synchronized.
	 * @protected
	 * @virtual
	 */
	onMainModelSynchronized: function() {
		this.isMainModelSynchronized = true;
		if (this.isMainSyncFinished()) {
			this.setDefaultState();
		}
	},

	/**
	 * Shows information panel for state "NoConnection".
	 * @protected
	 * @virtual
	 */
	showNoConnectionStateInformationPanel: function() {
		this.loadImportLastSyncDate().then(function(lastSyncDate) {
			var view = this.getView();
			var lastSyncDateMessage = lastSyncDate ? this.formatLastSyncDateMessage(lastSyncDate) : "";
			var panel = view.createStateInformationPanel(BPMSoft.PageState.NoConnection, {
				message: BPMSoft.LS.GridPageNoConnectionStateMessage,
				additionalMessage: lastSyncDateMessage,
				buttons: [this.getInformationPanelRefreshButtonConfig()]
			});
			var closeButton = panel.getCloseButton();
			closeButton.on("tap", this.onNoConnectionPanelCloseButtonTap, this);
			view.showStateInformationPanel(panel);
		}.bind(this));
	},

	/**
	 * Shows information panel for state "ServiceUnavailable".
	 * @protected
	 * @virtual
	 */
	showServiceUnavailableStateInformationPanel: function() {
		this.loadImportLastSyncDate().then(function(lastSyncDate) {
			var view = this.getView();
			var lastSyncDateMessage = lastSyncDate ? this.formatLastSyncDateMessage(lastSyncDate) : "";
			var panel = view.createStateInformationPanel(BPMSoft.PageState.ServiceUnavailable, {
				message: this.stateData.exception.getMessage(),
				additionalMessage: lastSyncDateMessage,
				buttons: [this.getInformationPanelRefreshButtonConfig()]
			});
			view.showStateInformationPanel(panel);
		}.bind(this));
	},

	/**
	 * Shows information panel for state "DataLoadingError", if error occurs while exporting.
	 * @protected
	 * @virtual
	 */
	showExportErrorInformationPanel: function() {
		var view = this.getView();
		var panel = view.createStateInformationPanel(BPMSoft.PageState.DataLoadingError, {
			message: BPMSoft.LS.GridPageExportErrorMessage,
			buttons: [
				{
					text: BPMSoft.LS.GridPageExportErrorMoreButtonText,
					cls: "cf-export-error-details-button",
					iconCls: "ts-info-blue-icon",
					listeners: {
						tap: this.onExportErrorDetailsButtonTap,
						scope: this
					}
				}
			]
		});
		view.showStateInformationPanel(panel);
	},

	/**
	 * Shows information panel for state "DataLoading".
	 * @protected
	 * @virtual
	 */
	showDataLoadingInformationPanel: function() {
		var view = this.getView();
		var panel = view.createStateInformationPanel(BPMSoft.PageState.DataLoading, {
			message: BPMSoft.LS.GridPageDataLoadingMessage
		});
		view.showStateInformationPanel(panel);
	},

	/**
	 * Shows information panel for state "Default".
	 * @protected
	 * @virtual
	 */
	showDataLoadedInformationPanel: function() {
		this.loadImportLastSyncDate().then(function(lastSyncDate) {
			var view = this.getView();
			var lastSyncDateMessage = lastSyncDate ? this.formatLastSyncDateMessage(lastSyncDate) : "";
			var panel = view.createStateInformationPanel(BPMSoft.PageState.Default, {
				message: BPMSoft.LS.GridPageDataLoadedMessage,
				additionalMessage: lastSyncDateMessage
			});
			view.showStateInformationPanel(panel);
		}.bind(this));
	},

	/**
	 * Called when synchronization started.
	 * @protected
	 * @virtual
	 */
	onSynchronizationStarted: function(syncManager, queueItem) {
		if (queueItem.getRunType() === BPMSoft.SyncRunType.Export) {
			this.setState(BPMSoft.PageState.DataLoading);
		}
	},

	/**
	 * Called when synchronization finished.
	 * @protected
	 * @virtual
	 */
	onSynchronizationFinished: function(syncManager, syncQueueItem) {
		if (syncQueueItem && syncQueueItem.getRunType() === BPMSoft.SyncRunType.Export) {
			this.hasExportConflicts = false;
		}
		if (this.isMainSyncFinished()) {
			this.setDefaultState();
		}
	},

	/**
	 * Called when synchronization failed.
	 * @protected
	 * @virtual
	 */
	onSynchronizationFailed: function(syncManager, syncQueueItem, exception) {
		if (exception instanceof BPMSoft.NoInternetConnectionException) {
			this.setState(BPMSoft.PageState.NoConnection);
		} else if (exception instanceof BPMSoft.ServiceUnavailableException) {
			this.setState(BPMSoft.PageState.ServiceUnavailable, {
				exception: exception
			});
		} else {
			this.hasExportConflicts = exception instanceof BPMSoft.DataExportException;
			this.setState(BPMSoft.PageState.DataLoadingError, {
				exception: exception
			});
		}
	},

	/**
	 * Called when state button has been tapped.
	 * @protected
	 * @virtual
	 */
	onStateButtonTap: function(view, state) {
		switch (state) {
			case BPMSoft.PageState.NoConnection:
				this.showNoConnectionStateInformationPanel();
				break;
			case BPMSoft.PageState.ServiceUnavailable:
				this.showServiceUnavailableStateInformationPanel();
				break;
			case BPMSoft.PageState.DataLoadingError:
				if (this.hasExportConflicts) {
					this.showExportErrorInformationPanel();
				} else {
					BPMSoft.MessageBox.showException(this.stateData.exception);
				}
				break;
			case BPMSoft.PageState.DataLoading:
				this.showDataLoadingInformationPanel();
				break;
			case BPMSoft.PageState.Default:
				this.showDataLoadedInformationPanel();
				break;
			default:
				break;
		}
	},

	/**
	 * Called when refresh data button of information panel has been tapped.
	 * @protected
	 * @virtual
	 */
	onInformationPanelRefreshButtonTap: function() {
		this.autoShowNoConnectionStatusPanel = true;
		var view = this.getView();
		view.hideStateInformationPanel();
		if (BPMSoft.SyncManager.hasSyncOperations()) {
			BPMSoft.SyncManager.reRunSync();
		}
	},

	/**
	 * Called when close button of "NoConnection" state panel has been tapped.
	 * @protected
	 * @virtual
	 */
	onNoConnectionPanelCloseButtonTap: function() {
		this.autoShowNoConnectionStatusPanel = false;
	},

	/**
	 * Called when export conflicts detail button of state panel has been tapped.
	 * @protected
	 * @virtual
	 */
	onExportErrorDetailsButtonTap: function() {
		var view = this.getView();
		view.hideStateInformationPanel(false);
		BPMSoft.util.openPage({
			controllerName: "BPMSoft.controller.MobileSyncLogPage",
			viewXClass: "BPMSoft.view.MobileSyncLogPage"
		});
	}

});
