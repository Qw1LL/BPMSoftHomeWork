define("DashboardListedGridViewModel", 
	["DashboardListedGridViewModelResources", "GridUtilitiesV2", "DashboardGridViewModel",
		"MiniPageUtilities", "ContextCallUtilities", "PageUtilities"],
	function(resources) {
		Ext.define("BPMSoft.DashboardListedGridViewModel", {
			extend: "BPMSoft.DashboardGridViewModel",

			/**
			 * Max grid page row count.
			 * @protected
			 * @type {Number}
			 */
			maxPageRowCount: 30,

			/**
			 * Is full screen mode enabled tag.
			 * @protected
			 * @type {Boolean}
			 */
			fullScreenEnabled: false,

			/**
			 * List of classes to mix into this class.
			 * @type {Object}.
			 */
			mixins: {
				/**
				 * @class GridUtilities.
				 */
				GridUtilities: "BPMSoft.GridUtilities",

				/**
				 * @class MiniPageUtilities
				 */
				MiniPageUtilitiesMixin: "BPMSoft.MiniPageUtilities",

				/**
				 * @class ContextCallUtilities
				 */
				ContextCallUtilities: "BPMSoft.ContextCallUtilities",

				/**
				 * @class PageUtilities
				 */
				PageUtilities: "BPMSoft.PageUtilities"
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#addColumnLink
			 */
			addColumnLink: function() {
				return this.mixins.GridUtilities.addColumnLink.apply(this, arguments);
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#onLinkClick
			 */
			onLinkClick: function(rowId, columnPath) {
				var gridData = this.getGridData();
				var row = gridData.find(rowId);
				if (!row) {
					return;
				}
				var number = row.get(columnPath);
				if (!number) {
					return;
				}
				var isCalled = this.callCustomer({
					entityColumnName: columnPath,
					entitySchemaName: this.entitySchema.name,
					entityId: rowId,
					number: number
				});
				return !isCalled;
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#init
			 */
			init: function() {
				this.callParent(arguments);
				this.sandbox.registerMessages(this.messages);
				this.initResourcesValues(resources);
				this._initGridCellViewType();
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#initGridData
			 */
			initGridData: function() {
				this.callParent(arguments);
				this.set("IsPageable", true);
				this.set("CanLoadMoreData", true);
			},

			/**
			 * Initializes grid cell view type.
			 * @private
			 */
			_initGridCellViewType: function() {
				BPMSoft.ProfileUtilities.getProfile({
					profileKey: this.getProfileKey()
				}, function(profile) {
					this.set("GridCellViewType", profile && profile.gridCellViewType ||
						BPMSoft.GridCellViewType.ONELINE);
				}, this);
			},

			/**
			 * Returns profile grid settings key.
			 * @returns {String} Profile grid settings key.
			 */
			getProfileKey: function() {
				return this.sandbox.id;
			},

			/**
			 * On full screen button event handler.
			 */
			onFullScreenBtnClick: function() {
				var moduleId =  arguments && arguments[3];
				this.setFullScreenMode(moduleId);
			},

			/**
			 * Sets dashboard full screen mode.
			 * @protected
			 * @param {String} fullScreenElId Dashboard wrap element id.
			 */
			setFullScreenMode: function(fullScreenElId) {
				this.fullScreenEnabled = BPMSoft.toggleFullScreenMode(Ext.String.format("#{0}", fullScreenElId));
				this.set("WatchRowInViewport", this.fullScreenEnabled ? 1 : 0);
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#onDestroy
			 */
			onDestroy: function() {
				this.callParent(arguments);
				BPMSoft.utils.dom.setAttributeToBody("full-screen-enabled", false);
			},

			/**
			 * Switch grid cell view type.
			 */
			switchGridCellViewType: function() {
				var oneLineType = BPMSoft.GridCellViewType.ONELINE;
				var gridCellViewType = this.get("GridCellViewType") === oneLineType ?
					BPMSoft.GridCellViewType.MULTILINE : oneLineType;
				this.set("GridCellViewType", gridCellViewType);
				var listedGridUserConfig = {
					gridCellViewType: gridCellViewType
				};
				BPMSoft.utils.saveUserProfile(this.getProfileKey(), listedGridUserConfig, false);
			},

			/**
			 * Returns switch grid cell view type menu caption.
			 * @returns {String} Switch grid cell view type menu caption.
			 */
			getSwitchGridCellViewTypeMenuCaption: function() {
				return this.get("GridCellViewType") === BPMSoft.GridCellViewType.ONELINE ?
					this.get("Resources.Strings.MultiLineCaption") :
					this.get("Resources.Strings.OneLineCaption");
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#getRowCount
			 */
			getRowCount: function() {
				if (this.fullScreenEnabled) {
					return this.maxPageRowCount;
				}
				var rowCount = this.callParent(arguments);
				return rowCount >= this.maxPageRowCount ? this.maxPageRowCount : rowCount;
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#initQueryOptions
			 */
			initQueryOptions: function(esq) {
				this.callParent(arguments);
				if (esq.rowCount === this.getRowCount()) {
					esq.rowCount++;
				}
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#initCanLoadMoreData
			 */
			initCanLoadMoreData: function(responseCollection) {
				var collectionCount = responseCollection && responseCollection.getCount();
				var canLoadMore = collectionCount === this.getRowCount() + 1;
				if (canLoadMore) {
					responseCollection.removeByIndex(collectionCount - 1);
					collectionCount--;
				}
				this.set("CanLoadMoreData", canLoadMore);
				this.set("LastRecord", collectionCount > 0 ?
					responseCollection.getByIndex(collectionCount - 1) : null);
			},

			/**
			 * On grid load more button click event handler.
			 * @param {Ext.EventObject} event Event object.
			 */
			onLoadMoreBtnClick: function(event) {
				var eventTarget = event && event.target;
				this.setFullScreenMode(this._getDashboardWrapElIdByChildEl(eventTarget));
			},

			/**
			 * Returns dashboard wrap element id.
			 * @private
			 * @param {HTMLElement} el Dashboard child element.
			 * @returns {String} Dashboard wrap element id.
			 */
			_getDashboardWrapElIdByChildEl: function(el) {
				var target = Ext.get(el);
				if (!target) {
					return "";
				}
				var dashboardWrapEl = target.findParent(".dashboard-listed-grid");
				return dashboardWrapEl && dashboardWrapEl.id || "";
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.DashboardGridViewModel#loadGridData
			 */
			loadGridData: function() {
				if (this.get("CanLoadMoreData")) {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritdoc
			 * @override BPMSoft.GridUtilities#exportToExcel
			 */
			exportToExcel: function() {
				const config = {
					downloadFileName: this.getDownloadFileName(this.$caption)
				};
				this.callParent([config]);
			}

		});
		return {};
});
