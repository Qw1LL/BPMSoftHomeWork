﻿define("PortalMessageFileDetail", [], function () {
	return {
		messages: {
			/**
			* @message HideFileDetailContainer
			* Switch FileDetailContainer, visibility into off mode.
			* FileDetailContainer defined in parent page.
			*/
			"HideFileDetailContainer": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},

		methods: {

			/**
			 * @private
			 */
			_isNeedLoadDataFromService: function() {
				return this.BPMSoft.Features.getIsEnabled("SecurePortalMessageFileInHistory");
			},

			_getLastValue: function() {
				const lastElement = this.getGridData().last();
				return lastElement ? lastElement.$Id : BPMSoft.GUID_EMPTY;
			},

			/**
			 * @private
			 */
			_getServiceConfig: function () {
				const lastValue = this._getLastValue();
				const rowsCount = this.getRowCount();
				return {
					"serviceName": "PortalMessageFileService",
					"methodName": "GetPortalMessageFiles",
					"data": {
						"portalMessageId": this.$MasterRecordId,
						"readingOptions": {
							"rowCount": rowsCount,
							"lastValue": lastValue
						}
					}
				};
			},

			/**
			 * @inheritdoc BPMSoft.FileDetailV2#loadContainerListData
			 * @override
			 */
			loadContainerListData: function(callback) {
				this._isNeedLoadDataFromService() ? this.loadFilesFromService(callback) : this.callParent(arguments);
			},

			/**
			 * Load portal message file from service.
			 * @protected
			 */
			loadFilesFromService: function(callback) {
				const config = this._getServiceConfig();
				this.callService(config, function(response) {
					if (response && response.GetPortalMessageFilesResult) {
						this.loadResponseToGrid(response.GetPortalMessageFilesResult.PortalMessageFiles);
						this.manageMasterCardContainerVisibilty();
					}
					Ext.callback(callback, this);
				}, this);
			},

			/**
			 * Load files received from web service into detail grid.
			 * @protected
			 * @param {Array} files
			 */
			loadResponseToGrid: function(files) {
				const canLoadMoreData = this.getShowMoreButtonVisibility(files.length);
				this.set("CanLoadMoreData", canLoadMoreData); 
				const viewModels = Ext.create("BPMSoft.Collection");
				BPMSoft.each(files, function (file) {
					const viewModel = this.createViewModelFromServiceResponse(file);
					viewModels.addIfNotExists(file.Id, viewModel);
				}, this);
				const gridData = this.getGridData();
				gridData.loadAll(viewModels);
			},

			/**
			 * Hide detail container in master card of no files was loaded into grid.
			 * @protected
			 */
			manageMasterCardContainerVisibilty: function() {
				const renderedItems = this.getGridData().getItems();
				if (renderedItems.length === 0) {
					this.sandbox.publish("HideFileDetailContainer", null, [this.sandbox.id]);
				}
			},

			/**
			 * Return value for CanLoadMoreData attribute.
			 * @protected
			 * @param {Number} arrayLength
			 * @returns {Boolean} True, if detail can load more data.
			 */
			getShowMoreButtonVisibility: function(arrayLength) {
				const rowCount = this.getRowCount();
				return arrayLength >= rowCount;
			},

			/**
			* Initializes ViewModel instance by query result.
			* @protected
			* @param {Object} values data for ImageListViewModel, recieved from web-service.
			* @returns {BPMSoft.ImageListViewModel} viewmodel for portal message file.
			*/
			createViewModelFromServiceResponse: function(values) {
				const viewModelClassName = this.getGridRowViewModelClassName();
				const viewModelConfig = this.getAdditionalViewModelConfig();
				viewModelConfig.values = values;
				viewModelConfig.entitySchema = this.getGridEntitySchema();
				const viewModel = Ext.create(viewModelClassName, viewModelConfig);
				this.bindItemViewModelMethods(viewModel);
				this.decorateItem(viewModel);
				return viewModel;
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});