define("ServiceEnums", ["ServiceEnumsResources"], function(resources) {

	/**
	 * ServiceParameterType
	 * @type {{BODY: number, URL_SEGMENT: number, QUERY_STRING: number, HTTP_HEADER: number, COOKIE: number}}
	 */
	BPMSoft.services.enums.ServiceParameterTypeCaption = {};
	BPMSoft.services.enums.ServiceParameterTypeCaption[BPMSoft.services.enums.ServiceParameterType.BODY] =
		resources.localizableStrings.ParameterTypeBodyText;
	BPMSoft.services.enums.ServiceParameterTypeCaption[BPMSoft.services.enums.ServiceParameterType.URL_SEGMENT] =
		resources.localizableStrings.ParameterTypeUrlSegmentText;
	BPMSoft.services.enums.ServiceParameterTypeCaption[BPMSoft.services.enums.ServiceParameterType.QUERY_STRING] =
		resources.localizableStrings.ParameterTypeQueryStringText;
	BPMSoft.services.enums.ServiceParameterTypeCaption[BPMSoft.services.enums.ServiceParameterType.HTTP_HEADER] =
		resources.localizableStrings.ParameterTypeHttpHeaderStringText;
	BPMSoft.services.enums.ServiceParameterTypeCaption[BPMSoft.services.enums.ServiceParameterType.COOKIE] =
		resources.localizableStrings.ParameterTypeCookieStringText;

	/**
	 * Service data value type captions.
	 * @type {Enum}
	 */
	BPMSoft.services.enums.DataValueTypeCaption = {
		Text: resources.localizableStrings.DataValueTypeNameText,
		Integer: resources.localizableStrings.DataValueTypeNameInteger,
		Float: resources.localizableStrings.DataValueTypeNameFloat,
		Boolean: resources.localizableStrings.DataValueTypeNameBoolean,
		DateTime: resources.localizableStrings.DataValueTypeNameDateTime,
		Guid: resources.localizableStrings.DataValueTypeNameGuid,
		Date: resources.localizableStrings.DataValueTypeNameDate,
		Time: resources.localizableStrings.DataValueTypeNameTime,
		Object: resources.localizableStrings.DataValueTypeNameObject
	};

	/**
	 * Authorization type captions.
	 * @type {Enum}
	 */
	BPMSoft.services.enums.AuthTypeCaption = {};
	BPMSoft.services.enums.AuthTypeCaption[BPMSoft.services.enums.AuthType.None] =
		resources.localizableStrings.AuthTypeNameNone;
	BPMSoft.services.enums.AuthTypeCaption[BPMSoft.services.enums.AuthType.Basic] =
		resources.localizableStrings.AuthTypeNameBasic;
	BPMSoft.services.enums.AuthTypeCaption[BPMSoft.services.enums.AuthType.Digest] =
		resources.localizableStrings.AuthTypeNameDigest;
	BPMSoft.services.enums.AuthTypeCaption[BPMSoft.services.enums.AuthType.OAuth20] =
		resources.localizableStrings.AuthTypeNameOauth20;

	/**
	 * OAuth20 Credentials location captions.
	 * @type {Enum}
	 */
	const serviceEnums = BPMSoft.services.enums;
	serviceEnums.CredentialsLocationCaption = {};
	serviceEnums.CredentialsLocationCaption[BPMSoft.services.enums
			.CredentialsLocation.BASIC_HEADER] =
		resources.localizableStrings.OAuth20CredentialsLocationBasicHeader;
	serviceEnums.CredentialsLocationCaption[BPMSoft.services.enums
			.CredentialsLocation.REQUEST_BODY] =
		resources.localizableStrings.OAuth20CredentialsLocationMessageBody;
	serviceEnums.CredentialsLocationCaption[BPMSoft.services.enums
			.CredentialsLocation.QUERY_STRING] =
		resources.localizableStrings.OAuth20CredentialsLocationQueryString;

	/**
	 * OAuth20 Access types captions.
	 * @type {Enum}
	 */
	serviceEnums.AccessTypeCaption = {};
	serviceEnums.AccessTypeCaption[BPMSoft.services.enums
		.AccessType.OFFLINE] = 'offline';
	serviceEnums.AccessTypeCaption[BPMSoft.services.enums
		.AccessType.ONLINE] = 'online';
	serviceEnums.AccessTypeCaption[BPMSoft.services.enums
		.AccessType.NOT_USE] =
		resources.localizableStrings.OAuth20NotUseAccessType;
});
