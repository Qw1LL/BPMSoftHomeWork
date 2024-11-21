define("GoogleIntegrationEnums", ["GoogleIntegrationEnumsResources"],
	function() {
		Ext.ns("BPMSoft.GoogleIntegrationEnums");

		/**
		 * @enum
		 * Google integration mode.
		 */
		BPMSoft.GoogleIntegrationEnums.IntegrationMode = {
			/**
			 * Can't import and export google entities.
			 */
			NOTHING: 0,
			/**
			 * Can import google entities.
			 */
			IMPORT: 1,
			/**
			 * Can export google entities.
			 */
			EXPORT: 2,
			/**
			 * Can import and export google entities.
			 */
			ALL: 3
		};

		/**
		 * @enum
		 * Google integration response code.
		 */
		BPMSoft.GoogleIntegrationEnums.IntegrationResponseCode = {
			/**
			 * No integration service result.
			 */
			NONE: "None",
			/**
			 * Google account settings not set.
			 */
			SETTINGS_NOT_SET: "SettingsNotSet",
			/**
			 * Authentication failed.
			 */
			AUTHENTICATION_ERROR: "AuthenticationFailed",
			/**
			 * Failed integration condition check.
			 */
			CONDITION_ERROR: "IntegrationConditionError",
			/**
			 * Internal service error.
			 */
			INTERNAL_ERROR: "InternalError",
			/**
			 * Service successfully executed.
			 */
			SUCCESS: "Success"
		};
	}
);
