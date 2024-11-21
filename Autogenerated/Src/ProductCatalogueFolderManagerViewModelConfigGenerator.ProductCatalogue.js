define("ProductCatalogueFolderManagerViewModelConfigGenerator", ["FolderManagerViewModelConfigGenerator"],
	function() {
		return Ext.define("BPMSoft.ProductCatalogueFolderManagerViewModelConfigGenerator", {
			extend: "BPMSoft.FolderManagerViewModelConfigGenerator",

			/**
			 * @inheritdoc BPMSoft.FolderManagerViewModelConfigGenerator#generate
			 * @override
			 */
			generate: function() {
				var viewModelConfig = this.callParent(arguments);
				Ext.merge(viewModelConfig, {
					values: {
						IsProductSelectMode: true,
						IsCloseButtonVisible: false,
						IsFoldersContainerVisible: true,
						IsExtendCatalogueFilterContainerVisible: false
					}
				});
				return viewModelConfig;
			}
		});
	}
);
