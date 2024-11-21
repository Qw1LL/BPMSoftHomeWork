define("SupportEmailHelper", ["SupportEmailHelperResources"], function(resources) {
	/**
	 * Gets mailto parameters to form letter.
	 * @private
	 * @return {Object}
	 */
	function getMailtoParams(mailSettingCode) {
		return {
			mailSetting: mailSettingCode,
			subjectLocString: resources.localizableStrings.SupportSubject,
			messageTpl: resources.localizableStrings.SupportEmailBodyTemplate
		};
	}

	/**
	 * Gets email parameters from system settings and history state.
	 * @private
	 * @param {String} mailSettingCode System setting with support e-mail address.
	 * @param {Function} callback Callback function
	 * @param {Object} scope Callback function context
	 */
	function getEmailParameters(mailSettingCode, callback, scope) {
		const params = getMailtoParams(mailSettingCode);
		const mailSetting = params.mailSetting;
		const sysSettingsNameArray = [
			"ProductName",
			"ProductEdition",
			"ConfigurationVersion",
			"PrimaryCulture",
			"CustomerId",
			mailSetting
		];
		let parameters = {};
		BPMSoft.SysSettings.querySysSettings(sysSettingsNameArray,
			function(values) {
				if (values) {
					parameters = {
						ProductEdition: values.ProductEdition || "",
						ProductName: values.ProductName || "",
						CustomerID: values.CustomerId || "",
						Version: values.ConfigurationVersion || "",
						Localization: values.PrimaryCulture && values.PrimaryCulture.displayValue || "",
						To: values[mailSetting] || ""
					};
				}
				callback.call(scope, parameters);
			}, this);
	}

	/**
	 * Gets page url parameters.
	 * @private
	 * @return {Object}
	 */
	function getUrlParameters(config, callback) {
		const parameters = config.defaultParameters || {};
		const historyStateInfo = config.sandbox.publish("GetHistoryState");
		const hasState = historyStateInfo && historyStateInfo.hash;
		let schemaName = "";
		if (hasState) {
			const hash = historyStateInfo.hash;
			const state = historyStateInfo.state;
			const moduleName = hash.moduleName || "";
			schemaName = state && state.schemaName || hash.entityName || "";
			parameters.Page = moduleName + "_" + schemaName;
		}
		parameters.Host = window.location.hostname;
		if (parameters.PageCaption) {
			callback(parameters);
			return;
		}
		const query = createEntitySchemaQuery();
		query.addColumn("Caption");
		query.filters.addItem(getSchemaFilters(schemaName));
		query.getEntityCollection(function(response) {
			if (response.success && !response.collection.isEmpty()) {
				const item = response.collection.getByIndex(0);
				parameters.PageCaption = item.values.Caption;
			}
			callback(parameters);
		});
	}

	/**
	 * Creates EntitySchemaQuery instance.
	 * @private
	 * @return {BPMSoft.EntitySchemaQuery}
	 */
	function createEntitySchemaQuery() {
		return Ext.create("BPMSoft.EntitySchemaQuery", {
			"rootSchemaName": "VwSysSchemaInfo"
		});
	}

	/**
	 * Returns query filter for schema name.
	 * @param {String} schemaName Schema name.
	 * @return {BPMSoft.FilterGroup}
	 */
	function getSchemaFilters(schemaName) {
		const filters = Ext.create("BPMSoft.FilterGroup");
		filters.addItem(BPMSoft.createColumnFilterWithParameter(
			BPMSoft.ComparisonType.EQUAL,
			"Name",
			schemaName
		));
		return filters;
	}

	/**
	 * Prepares parameters to form mailto request
	 * @private
	 * @param {Object} config Options config.
	 * @param {Function} callback Callback function
	 * @param {Object} scope Callback function context.
	 * @return {Object}
	 */
	function prepareEmailConfig(config, callback, scope) {
		getEmailParameters(config.mailSettingCode, function(parameters) {
			getUrlParameters(config, function(urlParameters) {
				const mailConfig = {};
				const params = getMailtoParams();
				const subjectLocString = params.subjectLocString;
				const messageTpl = params.messageTpl;
				const product = encodeURIComponent(Ext.String.format("{0} {1}",
					Ext.util.Format.htmlDecode(parameters.ProductName) || "",
					parameters.ProductEdition || ""));
				mailConfig.subject = Ext.String.format("subject={0} {1}",
					encodeURIComponent(subjectLocString),
					product);
				mailConfig.body = Ext.String.format(messageTpl,
					encodeURIComponent(urlParameters.Host),
					encodeURIComponent(parameters.CustomerID),
					product,
					encodeURIComponent(parameters.Version),
					encodeURIComponent(parameters.Localization),
					encodeURIComponent(urlParameters.PageCaption || urlParameters.Page));
				mailConfig.mailTo = Ext.String.format("mailto:{0}",
					parameters.To || ""
				);
				callback.call(scope, mailConfig);
			});
		}, this);
	}

	/**
	 * Creates email for customer support.
	 * @param {Object} config Options config.
	 * @param {Object} config.sandbox Module's sandbox.
	 * @param {String} config.mailSettingCode System setting with support e-mail address.
	 * @param {Object} [config.defaultParameters] Default parameters of the current url. I.e. PageCaption.
	 */
	function callMailTo(config) {
		prepareEmailConfig(config, function(emailConfig) {
			const mailTo = Ext.String.format("{0}?{1}&{2}",
				emailConfig.mailTo,
				emailConfig.subject,
				emailConfig.body);
			window.open(mailTo, "_self");
		}, this);
	}
	return {
		callMailTo: callMailTo
	};
});
