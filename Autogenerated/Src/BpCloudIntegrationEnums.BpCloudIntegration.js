define("BpCloudIntegrationEnums", function() {
	Ext.ns("BPMSoft.BpCloudIntegration.enums");

	BPMSoft.BpCloudIntegration.enums.ResponseCode = {
		SERVICE_UNAVAILABLE: -1,
		SUCCESS: 0,
		INVALID_API_KEY: 101,
		UNREACHABLE_RESOURCE: 105,
		ACCOUNT_ALREADY_EXISTS: 109,
		INVALID_AUTH_KEY: 110,
		GETTING_DOMAINS_ERROR: 111,
		ADDING_DOMAIN_ERROR: 112
	};

	BPMSoft.BpCloudIntegration.enums.SenderDomainStatus = {
		ACTIVE: "active"
	};

	BPMSoft.BpCloudIntegration.enums.Service = {
		CloudEmailService: "CloudEmailService"
	};
});
