/* globals Invoice: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "BPMSoft.configuration.InvoiceGridPageController",
	viewXClass: "BPMSoft.configuration.InvoiceGridPageView"
};

Ext.define("BPMSoft.configuration.store.InvoiceGridPage", {
	extend: "BPMSoft.store.BaseStore",
	alternateClassName: "BPMSoft.configuration.InvoiceGridPageStore",

	config: {
		model: "Invoice",
		controller: "BPMSoft.configuration.InvoiceGridPageController"
	}
});

if (BPMSoft.Features.getIsEnabled("UseMobileInvoiceCacheManager") && BPMSoft.ModelCache.isEnabled()) {
	Ext.define("BPMSoft.configuration.view.InvoiceGridPage", {
		extend: "BPMSoft.view.BaseGridPage.View",
		alternateClassName: "BPMSoft.configuration.InvoiceGridPageView",

		config: {
			id: "InvoiceGridPage",
			grid: {
				store: "BPMSoft.configuration.InvoiceGridPageStore"
			}
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		isStateButtonDisabled: function() {
			return false;
		}

	});

	Ext.define("BPMSoft.configuration.controller.InvoiceGridPage", {
		extend: "BPMSoft.controller.BaseGridPage",
		alternateClassName: "BPMSoft.configuration.InvoiceGridPageController",

		mixins: {
			cacheSyncStateMixin: "BPMSoft.CacheSyncStateControllerMixin"
		},

		statics: {
			Model: Invoice
		},

		config: {
			refs: {
				view: "#InvoiceGridPage"
			}
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		initializeGrid: function(gridView) {
			this.callParent(arguments);
			if (this.canUseCache()) {
				this.mixins.cacheSyncStateMixin.initializePageState.apply(this);
				BPMSoft.Application.on("resume", this.onApplicationResume, this);
			}
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		onInformationPanelRefreshButtonTap: function() {
			this.mixins.cacheSyncStateMixin.onInformationPanelRefreshButtonTap.apply(this, arguments);
			if (!BPMSoft.SyncManager.hasSyncOperations()) {
				this.synchronizeToCacheIfAvailable();
			}
		},

		/**
		 * Called when app is resumed.
		 * @protected
		 * @virtual
		 */
		onApplicationResume: function() {
			this.synchronizeToCacheIfAvailable();
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		setState: function(state, stateData) {
			this.callParent(arguments);
			this.mixins.cacheSyncStateMixin.setState.apply(this, [state, stateData]);
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		synchronizeToCacheIfAvailable: function() {
			this.callParent(arguments);
			this.mixins.cacheSyncStateMixin.setDataLoadingState.apply(this);
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		onStateButtonTap: function(view, state) {
			this.mixins.cacheSyncStateMixin.onStateButtonTap.apply(this, arguments);
		},

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		onMainModelSynchronized: function(hasChanges) {
			this.callParent(arguments);
			this.mixins.cacheSyncStateMixin.onMainModelSynchronized.apply(this, arguments);
		}

	});
} else {
	Ext.define("BPMSoft.configuration.view.InvoiceGridPage", {
		extend: "BPMSoft.view.BaseGridPage.View",
		alternateClassName: "BPMSoft.configuration.InvoiceGridPageView",

		config: {
			id: "InvoiceGridPage",
			grid: {
				store: "BPMSoft.configuration.InvoiceGridPageStore"
			}
		}

	});

	Ext.define("BPMSoft.configuration.controller.InvoiceGridPage", {
		extend: "BPMSoft.controller.BaseGridPage",
		alternateClassName: "BPMSoft.configuration.InvoiceGridPageController",

		statics: {
			Model: Invoice
		},

		config: {
			refs: {
				view: "#InvoiceGridPage"
			}
		}

	});
}
