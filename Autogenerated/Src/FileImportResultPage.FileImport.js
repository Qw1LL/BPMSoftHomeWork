define("FileImportResultPage", ["FileImportResultPageResources", "ModuleUtils"],
	function(resources, ModuleUtils) {
		return {
			attributes: {
				/**
				 * Imported records number.
				 */
				ImportedRowsCount: {dataValueType: BPMSoft.DataValueType.INTEGER},
				/**
				 * Not imported records number.
				 */
				NotImportedRowsCount: {dataValueType: BPMSoft.DataValueType.INTEGER},
				/**
				 * Processed records number.
				 */
				ProcessedRowsCount: {dataValueType: BPMSoft.DataValueType.INTEGER},
				/**
				 * Total records number.
				 */
				TotalRowsCount: {dataValueType: BPMSoft.DataValueType.INTEGER}
			},
			methods: {

				//region Methods: Private

				/**
				 * Initializes import parameters.
				 * @private
				 * @param {Function} callback Callback.
				 * @param {BPMSoft.core.BaseResponse} callback.response Server response.
				 * @param {Object} scope Context for callback function execution.
				 */
				getImportParameters: function(callback, scope) {
					var importSessionId = this.get("ImportSessionId");
					var config = {
						contractName: "GetImportSessionInfo",
						importSessionId: importSessionId
					};
					this.sendRequest(config, callback, scope);
				},

				/**
				 * Returns import process result.
				 * @private
				 * @return {Boolean}
				 */
				getIsImportSuccessful: function() {
					var totalRowsCount = this.get("TotalRowsCount");
					var importedRowsCount = this.get("ImportedRowsCount");
					return (totalRowsCount === importedRowsCount);
				},

				/**
				 * Returns true if import process end with errors.
				 * @private
				 * @return {Boolean}
				 */
				getIsImportNotSuccessful: function() {
					return !this.getIsImportSuccessful();
				},

				/**
				 * Initializes import parameters.
				 * @private
				 * @param {Object} response Server response.
				 * @param {Number} response.importObject Import object.
				 * @param {Number} response.importTags Import tags.
				 * @param {Number} response.totalRowsCount Total rows number.
				 * @param {Number} response.processedRowsCount Processed rows number.
				 * @param {Number} response.importedRowsCount Imported rows number.
				 * @param {Number} response.notImportedRowsCount Not imported rows number.
				 * @param {Function} callback Callback.
				 * @param {Object} scope Callback execution scope.
				 */
				initImportParameters: function(response, callback, scope) {
					if (response.success) {
						this.set("ImportObject", response.importObject);
						this.set("ImportTags", response.importTags);
						this.set("TotalRowsCount", response.totalRowsCount);
						this.set("ProcessedRowsCount", response.processedRowsCount);
						this.set("ImportedRowsCount", response.importedRowsCount);
						this.set("NotImportedRowsCount", response.notImportedRowsCount);
					}
					callback.call(scope);
				},

				//endregion

				//region Methods: Public

				/**
				 * @inheritdoc BPMSoft.BaseWizardStepPage#init
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.getImportParameters(function(response) {
							this.initImportParameters(response, function() {
								this.hideBodyMask();
								callback.call(scope);
							}, this);
						}, this);
					}, this]);
				},

				/**
				 * Closes window.
				 */
				onCloseButtonClick: function() {
					window.close();
				},

				closeButtonClick: function() {
					this.callParent(arguments);
					window.close();
				},

				/**
				 * Gets import status label caption.
				 * @return {String}
				 */
				getImportStatusLabelCaption: function() {
					var format = this.get("Resources.Strings.ImportStatusLabelFormat");
					var totalRowsCount = this.get("TotalRowsCount");
					var importedRowsCount = this.get("ImportedRowsCount");
					return this.Ext.String.format(format, totalRowsCount, importedRowsCount);
				},

				/**
				 * Gets not imported status label caption.
				 * @return {String}
				 */
				getNotImportedStatusLabelCaption: function() {
					var format = this.get("Resources.Strings.NotImportedStatusLabelFormat");
					var notImportedRowsCount = this.get("NotImportedRowsCount");
					return this.Ext.String.format(format, notImportedRowsCount);
				},

				/**
				 * Gets not imported status label visible.
				 * @return {Boolean}
				 */
				getNotImportedStatusLabelVisible: function() {
					var notImportedRowsCount = this.get("NotImportedRowsCount");
					return (notImportedRowsCount > 0);
				},

				/**
				 * Gets import log link.
				 * @return {String}
				 */
				getImportLogLink: function() {
					return "ViewModule.aspx#LookupSectionModule/FileImportLookupSection/ExcelImportLog";
				},

				/**
				 * Gets congratulation image.
				 * @return {String}
				 */
				getCongratulationImage: function() {
					var image = this.get("Resources.Images.CongratulationImage");
					return BPMSoft.ImageUrlBuilder.getUrl(image);
				},

				/**
				 * Returns header label.
				 * @return {String}
				 */
				getHeaderLabel: function() {
					var successImportLabel = this.get("Resources.Strings.Header");
					var failureImportLabel = this.get("Resources.Strings.FailureImportHeader");
					return this.getIsImportSuccessful() ? successImportLabel : failureImportLabel;
				},

				/**
				 * Gets imported data link visibility.
				 * @return {Boolean}
				 */
				getImportedDataLinkVisible: function() {
					var importObject = this.get("ImportObject");
					var importSchemaName = importObject ? importObject.name : "";
					var moduleStructure = importSchemaName
							? ModuleUtils.getModuleStructureByName(importSchemaName)
							: null;
					var importedRowsCount = this.get("ImportedRowsCount");
					return (importedRowsCount > 0) && !this.Ext.isEmpty(moduleStructure) &&
							!this.Ext.isEmpty(moduleStructure.sectionSchema);
				},

				/**
				 * Opens imported data.
				 * @param {Object} event Click event.
				 */
				openImportedData: function(event) {
					event.stopEvent();
					var body = {
						rootSchemaName: this.get("ImportObject").name,
						tags: this.get("ImportTags")
					};
					var message = {
						Id: this.BPMSoft.generateGUID(),
						Header: {
							Sender: "TagImport",
							BodyTypeName: "System.String"
						},
						Body: JSON.stringify(body)
					};
					this.BPMSoft.ServerChannel.postMessage(message);
					window.close();
				}

				//endregion

			},
			diff: [ 
				{
					"operation": "merge",
					"name": "HeaderContainer",
					"values": {
						"classes": {"wrapClassName": ["header-container", "results"]}
					}
				},
				{
					"operation": "remove",
					"name": "HeaderLabel",
					"values": {
						"caption": {"bindTo": "getHeaderLabel"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"name": "CongratulationImage",
					"propertyName": "items",
					"index": 0,
					"values": {
						"readonly": true,
						"defaultImage":
							BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.CongratulationImage),
						"getSrcMethod": "getCongratulationImage",
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl",
						"classes": {
							"wrapClass": ["congratulation-image-wrapper"]
						},
						"markerValue": "CongratulationImage"
					}
				},
				{
					"operation": "insert",
					"name": "DataImportFinishedLabel",
					"parentName": "HeaderLabelContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.DataImportFinishedLabelCaption"},
						"classes": {
							"labelClass": ["description-label"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "CenterContainer",
					"values": {
						"classes": {"wrapClassName": ["center-container", "results"]}
					}
				},
				{
					"operation": "insert",
					"parentName": "CenterContainer",
					"name": "DescriptionContainer",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["description-wrapper"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ImportStatusLabel",
					"parentName": "DescriptionContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getImportStatusLabelCaption"},
						"classes": {
							"labelClass": ["status-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "NotImportedStatusLabel",
					"parentName": "DescriptionContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "getNotImportedStatusLabelCaption"},
						"visible": {"bindTo": "getNotImportedStatusLabelVisible"},
						"classes": {
							"labelClass": ["status-label"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "ImportLogLink",
					"parentName": "DescriptionContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {
							"bindTo": "Resources.Strings.ImportLogLink"
						},
						"visible": {"bindTo": "getIsImportNotSuccessful"},
						"href": {"bindTo": "getImportLogLink"},
						"target": BPMSoft.controls.HyperlinkEnums.target.SELF,
						"classes": {
							"hyperlinkClass": ["import-log-link"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "OpenImportedDataLink",
					"parentName": "DescriptionContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.HYPERLINK,
						"caption": {"bindTo": "Resources.Strings.OpenImportedDataLink"},
						"visible": {"bindTo": "getImportedDataLinkVisible"},
						"click": {"bindTo": "openImportedData"},
						"classes": {
							"hyperlinkClass": ["import-log-link"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "FooterContainer",
					"name": "ButtonsContainer",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["buttons-wrapper"],
						"items": []
					}
				},
				{
					"operation": "merge",
					"parentName": "ButtonsContainer",
					"name": "CloseButton",
					"propertyName": "items",
					"values": {
						"generateId": false,
						"caption": {bindTo: "Resources.Strings.CloseButtonCaption"},
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"classes": {
							"wrapperClass": ["button"],
							"imageClass": ["button-image"]
						},
						"click": {"bindTo": "onCloseButtonClick"},
						"tag": "Close",
						"markerValue": "CloseResultPageButton"
					}
				},
				{
					"operation": "merge",
					"name": "FooterContainer",
					"values": {}
				},
				{
					"operation": "remove",
					"name": "NextButton"	
				}
			]
		};
	}
);
