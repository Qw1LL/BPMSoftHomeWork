BPMSoft.Configuration.FilesAndLinksDetailFileSources = {
	Gallery: 0,
	Camera: 1,
	Link: 2
};

Ext.define("FileAndLinksEditPage.Controller", {
	extend: "BPMSoft.controller.BaseEditPage",

	inheritableStatics: {

		addDefaultBusinessRules: function() {
			var fileModel = this.prototype.fileModel;
			BPMSoft.sdk.Model.addBusinessRule(fileModel, {
				name: "FileAndLinksEditPageRequirementRule",
				ruleType: BPMSoft.RuleTypes.Requirement,
				requireType: BPMSoft.RequirementTypes.OneOf,
				message: BPMSoft.LocalizableStrings["Sys.RequirementRule.message"],
				triggeredByColumns: ["Data", "Name"]
			});
			BPMSoft.sdk.Model.addBusinessRule(fileModel, {
				name: "FileAndLinksEditPageVisibilityRule",
				ruleType: "BPMSoft.FileAndLinksBusinessRule"
			});
		}

	},

	fileModel: null,

	/**
	 * @private
	 */
	fileTypePicker: null,

	/**
	 * @private
	 */
	currentFileParameters: null,

	/**
	 * @private
	 */
	cameraQuality: null,

	/**
	 * @private
	 */
	showFileTypePicker: function() {
		var picker = this.getFileTypePicker();
		if (!picker.getParent()) {
			Ext.Viewport.add(picker);
		}
		picker.show();
	},

	/**
	 * @private
	 */
	getFileTypePicker: function() {
		if (!this.fileTypePicker) {
			Ext.define("BPMSoft.MobileFileAndLinksEditControllerPickerModel", {
				extend: "BPMSoft.model.BaseModel",
				config: {
					fields: [
						{name: "Caption", type: "string"},
						{name: "Source", type: "number"}
					]
				}
			});
			var pickerStore = Ext.create("BPMSoft.store.BaseStore", {
				model: "BPMSoft.MobileFileAndLinksEditControllerPickerModel",
				data: [
					{
						Caption: BPMSoft.LocalizableStrings.FileAndLinksEditPageFileSourceCamera,
						Source: BPMSoft.Configuration.FilesAndLinksDetailFileSources.Camera
					},
					{
						Caption: BPMSoft.LocalizableStrings.FileAndLinksEditPageFileSourceGallery,
						Source: BPMSoft.Configuration.FilesAndLinksDetailFileSources.Gallery
					},
					{
						Caption: BPMSoft.LocalizableStrings.FileAndLinksEditPageFileSourceLink,
						Source: BPMSoft.Configuration.FilesAndLinksDetailFileSources.Link
					}
				]
			});
			this.fileTypePicker = Ext.create("Ext.BPMSoft.ComboBoxPicker", {
					component: {
						primaryColumn: "Caption",
						store: pickerStore,
						listeners: {
							scope: this,
							itemtap: this.onFileTypePickerItemTap
						},
						disableSelection: true
					},
					toolbar: {
						clearButton: false
					},
					title: BPMSoft.LocalizableStrings.EditPageFileTypePickerTitleV2,
					popup: true
				}
			);
		}
		return this.fileTypePicker;
	},

	/**
	 * @private
	 */
	onCameraFailure: function(exception) {
		BPMSoft.Mask.hide();
		var innerException = exception.getInnerException();
		if (innerException instanceof BPMSoft.UnsupportedFileSourceException) {
			BPMSoft.MessageBox.showMessage(innerException.getMessage());
		} else {
			BPMSoft.MessageBox.showException(exception);
		}
	},

	/**
	 * @private
	 */
	onCameraCapture: function(fileName, url) {
		if (fileName && url) {
			this.currentFileParameters = {
				fileName: fileName,
				url: url
			};
			BPMSoft.controller.BaseEditPage.prototype.onEmbeddedDetailAddButtonTap.apply(this, this.currentArguments);
		}
		BPMSoft.Mask.hide();
	},

	/**
	 * @private
	 */
	onFileTypePickerItemTap: function(el, index, target, record) {
		var source = record.get("Source");
		this.currentFileParameters = null;
		switch (source) {
			case BPMSoft.Configuration.FilesAndLinksDetailFileSources.Gallery:
				this.currentFileTypeGUID = BPMSoft.Configuration.FileTypeGUID.File;
				BPMSoft.Mask.show();
				BPMSoft.Camera.captureFromGallery({
					success: this.onCameraCapture,
					failure: this.onCameraFailure,
					scope: this
				});
				break;
			case BPMSoft.Configuration.FilesAndLinksDetailFileSources.Camera:
				this.currentFileTypeGUID = BPMSoft.Configuration.FileTypeGUID.File;
				BPMSoft.Camera.captureFromCamera({
					quality: this.cameraQuality,
					success: this.onCameraCapture,
					failure: this.onCameraFailure,
					scope: this
				});
				break;
			case BPMSoft.Configuration.FilesAndLinksDetailFileSources.Link:
				this.currentFileTypeGUID = BPMSoft.Configuration.FileTypeGUID.Link;
				BPMSoft.controller.BaseEditPage.prototype.onEmbeddedDetailAddButtonTap.apply(this, this.currentArguments);
				break;
		}
	},

	/**
	 * @private
	 */
	processEmbeddedDetailItemApplied: function(record, fileTypeRecord, args) {
		record.set("Type", fileTypeRecord);
		BPMSoft.controller.BaseEditPage.prototype.onEmbeddedDetailItemApplied.apply(this, args);
		if (this.currentFileParameters) {
			record.set("Data", this.currentFileParameters.url, true);
			record.set("Name", this.currentFileParameters.fileName, true);
			var field = this.getFieldByColumnName("Data", record);
			field.setDisplayValue(this.currentFileParameters.fileName);
		} else {
			this.processLink(record);
		}
	},

	/**
	 * @private
	 */
	processLink: function(record) {
		var typeId = record.get("Type").getId();
		if (BPMSoft.Configuration.FileTypeGUID.Link === typeId && !Ext.isEmpty(record.get("Data"))) {
			/*
				HACK: For binary columns (Data field) OData always returns some value, although in the case of
				link to the file it is wrong. Here we clear this value.
				And in order to column is not considered a change, do it directly.
			*/
			record.data.Data = null;
		}
	},


	/**
	 * @overridden
	 */
	onEmbeddedDetailItemApplied: function(record) {
		if (record.modelName !== this.fileModel) {
			this.callParent(arguments);
			return;
		}
		if (!record.phantom) {
			this.processLink(record);
			this.callParent(arguments);
			return;
		}
		var me = this;
		var args = arguments;
		var fileTypeModel = Ext.ModelManager.getModel("FileType");
		var isSimple = fileTypeModel.isSimple();
		if (isSimple) {
			var fileTypeRecord = BPMSoft.model.BaseModel.getSimpleLookupRecord(this.currentFileTypeGUID, "FileType");
			this.processEmbeddedDetailItemApplied(record, fileTypeRecord, args);
		} else {
			fileTypeModel.load(this.currentFileTypeGUID, {
				success: function(loadedRecord) {
					me.processEmbeddedDetailItemApplied(record, loadedRecord, args);
				},
				failure: function() {
					BPMSoft.controller.BaseEditPage.prototype.onEmbeddedDetailItemApplied.apply(me, args);
				}
			});
		}
		this.currentFileTypeGUID = null;
	},

	/**
	 * @overridden
	 */
	onEmbeddedDetailAddButtonTap: function(embeddedDetail) {
		var fileColumnSet = this.getColumnSetByColumnName("File", Ext.create(this.fileModel));
		if (fileColumnSet && fileColumnSet.getId() === embeddedDetail.getId()) {
			var detailColumns = BPMSoft.sdk.RecordPage.getColumns(this.self.Model, fileColumnSet.getName());
			this.cameraQuality = detailColumns.get("Data").columnConfig.quality;
			this.currentArguments = arguments;
			this.showFileTypePicker();
		} else {
			this.callParent(arguments);
		}
	},

	/**
	 * @overridden
	 */
	getColumnSets: function(modelName) {
		var columnSetConfigs = BPMSoft.sdk.RecordPage.getColumnSets(modelName);
		var columnSets = this.callParent(arguments);
		for (var i = 0, ln = columnSets.length; i < ln; i++) {
			var columnSet = columnSets[i];
			var columnSetName = columnSet.name;
			var columnSetConfig = columnSetConfigs.getByKey(columnSetName);
			if (columnSetConfig.modelName === this.fileModel) {
				columnSet.cls = "x-file-detail";
			}
		}
		return columnSets;
	}

});
