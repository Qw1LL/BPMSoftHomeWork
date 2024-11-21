/**
 * @class BPMSoft.FileServiceProvider
 */
Ext.define("BPMSoft.configuration.FileServiceProvider", {
	extend: "BPMSoft.BaseFileLoadProvider",
	alternateClassName: "BPMSoft.FileServiceProvider",

	upload: function(config) {
		BPMSoft.FileService.upload(config);
	},

	download: function(config) {
		BPMSoft.FileService.download(config);
	}

});
if (BPMSoft.Features.getIsEnabled("UseMobileFileService")) {
	BPMSoft.FileLoader.setProvider(BPMSoft.FileServiceProvider);
}
