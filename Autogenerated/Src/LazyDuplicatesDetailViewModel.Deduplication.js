define("LazyDuplicatesDetailViewModel", ["LazyDuplicatesDetailViewModelResources",
	"DuplicatesDetailViewModelV2"], function(resources) {
	Ext.define("BPMSoft.configuration.LazyDuplicatesDetailViewModel", {
		extend: "BPMSoft.DuplicatesDetailViewModel",
		alternateClassName: "BPMSoft.LazyDuplicatesDetailViewModel",
		
		_messages: {
			/**
			 * @message FetchGroupData
			 * Fetch group duplicates.
			 * @param {Object} config Load group data config.
			 * @param {String} config.groupId Group id.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback function scope.
			 */
			"FetchGroupData": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.propertiesTranslator = Ext.apply(this.propertiesTranslator, {
				"TotalDuplicatesPerGroup": "count",
				"TopDuplicatesPerGroup": "topDuplicatesPerGroup",
				"MaxDuplicatesPerRecord": "maxDuplicatesPerRecord"
			});
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		initProperties: function() {
			this.callParent(arguments);
			this.$IsAllGroupLoaded = this.$TopDuplicatesPerGroup >= this.$TotalDuplicatesPerGroup;
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		getModelColumns: function() {
			return Ext.apply(this.callParent(arguments), {
				IsGridLoading: { dataValueType: BPMSoft.DataValueType.BOOLEAN },
				IsAllGroupLoaded: { dataValueType: BPMSoft.DataValueType.BOOLEAN },
				TotalDuplicatesPerGroup: { dataValueType: BPMSoft.DataValueType.INTEGER },
				TopDuplicatesPerGroup: { dataValueType: BPMSoft.DataValueType.INTEGER },
				MaxDuplicatesPerRecord: { dataValueType: BPMSoft.DataValueType.INTEGER }
			});
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				this.sandbox.registerMessages(this._messages);
				this.initSelectAllCaption();
				Ext.callback(callback, scope);
			}]);
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		initSelectAllCaption: function() {
			this.$SelectAllCaption = this.isAllItemsSelected()
					? Ext.String.format(resources.localizableStrings.ClearAllBtnTpl, this.$TotalDuplicatesPerGroup)
					: Ext.String.format(resources.localizableStrings.SelectAllBtnTpl, this.$TotalDuplicatesPerGroup);
		},
		
		/**
		 * Load next duplicates in group.
		 */
		onLoadMoreButtonClick: function() {
			this.$IsGridLoading = true;
			const fetchGroupDataConfig = {
				groupId: this.$GroupId,
				callback: this.loadGroupDataCallback,
				scope: this
			};
			this.sandbox.publish("FetchGroupData", fetchGroupDataConfig, [this.sandbox.id]);
		},
		
		/**
		 * Prepares loaded duplicates and load row to grid.
		 * @protected
		 * @param {BPMSoft.BaseViewModelCollection} loadedCollection Loaded duplicates view models.
		 */
		loadGroupDataCallback: function(loadedCollection) {
			loadedCollection = this.clearLoadedRecords(loadedCollection);
			this.$IsGridLoading = false;
			const gridData = this.getGridData();
			gridData.loadAll(loadedCollection);
			this.$IsAllGroupLoaded = true;
		},
		
		/**
		 * @inheritdoc
		 * @override
		 */
		isAllRowsUnique: function() {
			return this.callParent(arguments) && this.$IsAllGroupLoaded;
		},

		/**
		 * @inheritdoc
		 * @override
		 */
		initCanLoadMoreData: BPMSoft.emptyFn
		
	});
});
