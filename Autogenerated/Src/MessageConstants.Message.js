define("MessageConstants", [], function() {
	var fileDisplayTemplate = "<span>{0}</span>";
	var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
	var urlTemplate = {
		FileUrlTemplate: "<a href='" + workspaceBaseUrl + "/rest/FileService/GetFile/{0}/{1}'>{2}</a>"
	};
	return {
		UrlTemplate: urlTemplate,
		FileDisplayTemplate: fileDisplayTemplate
	};
});
