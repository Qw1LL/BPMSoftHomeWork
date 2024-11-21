define("ckeditor", ["ckeditor-base"], function() {
	var warningMessage = Ext.String.format(BPMSoft.Resources.ObsoleteMessages.ObsoleteModule,
		"ckeditor", "ckeditor-base");
	window.console.log(warningMessage);
});
