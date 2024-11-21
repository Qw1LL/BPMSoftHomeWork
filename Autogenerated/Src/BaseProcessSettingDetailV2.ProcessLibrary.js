define("BaseProcessSettingDetailV2", function() {
	return {
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @overridden
			 */
			getDeleteRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
			 * @overridden
			 */
			addDetailWizardMenuItems: BPMSoft.emptyFn,

			/**
			 * Returns config for process element caption binding to element name.
			 * @protected
			 * @virtual
			 * @returns {Object} Config to bind process element caption to detail column. Contains fields
			 * detailColumn - name of detail column that will be replaced with process element caption,
			 * processElementUIdColumn - name of column in entity schema that identifies process element.
			 */
			getProcessElementCaptionColumnsConfig: BPMSoft.emptyFn,

			/**
			 * Returns if process element caption binding is active.
			 * @private
			 * @returns {Boolean}
			 */
			_useProcessElementCaption: function() {
				return !Ext.isEmpty(this.getProcessElementCaptionColumnsConfig());
			},

			/**
			 * Adds process element uId column to detail esq.
			 * @private
			 * @param {BPMSoft.EntitySchemaQuery} Grid data esq.
			 */
			_addProcessElementInfoColumn: function(esq) {
				var config = this.getProcessElementCaptionColumnsConfig();
				var processElementUIdColumn = Ext.create("BPMSoft.EntityQueryColumn", {
					columnPath: config.processElementUIdColumn
				});
				esq.addColumn(processElementUIdColumn, config.processElementUIdColumn);
			},

			/**
			 * Replaces process element captions for bound detail column.
			 * @private
			 * @param {BPMSoft.Collection} gridData Grid data collection.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			_replaceProcessElementCaptions: function(gridData, callback, scope) {
				var config = this.getProcessElementCaptionColumnsConfig();
				BPMSoft.chain(
					function(next) { BPMSoft.ProcessFlowElementSchemaManager.initialize(next, this); },
					function(next) { BPMSoft.ProcessSchemaManager.initialize(next, this); },
					function() {
						this._findProcessInstance(function(process) {
							gridData.each(function (viewModel) {
								var processElementUId = viewModel.get(config.processElementUIdColumn);
								var processElement = process.findItemByUId(processElementUId);
								viewModel.set(config.detailColumn, processElement.getCaption());
							}, this);
							callback.call(scope);
						}, this);
					},
					this
				);
			},

			/**
			 * @param callback
			 * @param scope
			 * @private
			 */
			_findProcessInstance: function(callback, scope) {
				var processId = this.get("MasterRecordId");
				BPMSoft.ProcessSchemaManager.findInstanceByUId(processId, function(process) {
					if (Ext.isEmpty(process)) {
						BPMSoft.ProcessSchemaManager.forceGetInstanceByUId(processId, function(forcedProcess) {
							callback.call(scope, forcedProcess);
						}, this);
					} else {
						callback.call(scope, process);
					}
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#updateLoadedGridData
			 * @override
			 */
			updateLoadedGridData: function(response, callback, scope) {
				if (this._useProcessElementCaption()) {
					this._replaceProcessElementCaptions(response.collection, function () {
						callback.call(scope, response);
					}, this);
				} else {
					callback.call(scope, response);
				}
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilitiesV2#initQueryColumns
			 * @override
			 */
			initQueryColumns: function(esq) {
				this.callParent(arguments);
				if (this._useProcessElementCaption()) {
					this._addProcessElementInfoColumn(esq);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
			 * @override
			 */
			getAddRecordButtonVisible: function() {
				return false;
			}
		}
	};
});
