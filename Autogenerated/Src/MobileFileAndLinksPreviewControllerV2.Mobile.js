Ext.define("FileAndLinksPreviewPage.Controller", {
	extend: "BPMSoft.controller.BasePreviewPage",

	/**
	 * Name of the file model.
	 */
	fileModel: null,

	/**
	 * @protected
	 * @virtual
	 */
	initializeView: function(view) {
		this.callParent(arguments);
		var panel = view.getPanel();
		panel.on({
			scope: this,
			embeddeddetailitemapplied: this.onFileAndLinksEmbeddedDetailItemApplied
		});
	},

	/**
	 * @protected
	 * @virtual
	 */
	onFileAndLinksEmbeddedDetailItemApplied: function(record, detailItem) {
		if (record.modelName !== this.fileModel) {
			return;
		}
		var typeId = record.get("Type").getId();
		var isKnowledgeBaseLink = (typeId === BPMSoft.Configuration.FileTypeGUID.KnowledgeBaseLink);
		var isFile = ((typeId === BPMSoft.Configuration.FileTypeGUID.File) || isKnowledgeBaseLink);
		var showColumn = isFile ? "Data" : "Name";
		var hideColumn = isFile ? "Name" : "Data";
		detailItem.getItems().each(function(item) {
			if (item.isDecorator && !item.isField) {
				item = item.getComponent();
			}
			var columnName = item.getName && item.getName();
			if (showColumn === columnName) {
				if (isKnowledgeBaseLink) {
					item.setLabel(BPMSoft.LocalizableStrings.PreviewPageKnowledgeBaseLinkCaption);
				}
				item.show();
			} else if (hideColumn === columnName) {
				item.hide();
			}
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onFilePreview: function(field) {
		BPMSoft.util.downloadRecordFile({
			record: field.getRecord(),
			dataColumnName: field.getName(),
			fileName: field.getDisplayValue(),
			success: function(path, record) {
				var typeId = record.get("Type").getId();
				if (typeId === BPMSoft.Configuration.FileTypeGUID.EntityLink) {
					BPMSoft.Configuration.openFileByEntityLink({
						cancellationId: this.getCancellationId("openFileByEntityLink"),
						fileUrl: path,
						failure: function(config) {
							if (config && config.fileNotFound) {
								BPMSoft.MessageBox.showMessage(BPMSoft.LocalizableStrings.FileByEntityLinkNotFound);
							}
						},
						scope: this
					});
				} else {
					this.openFileByPath(path, record);
				}
			},
			failure: function(exception) {
				this.onFileOpenFailure(exception);
			},
			scope: this
		});
	}
});
