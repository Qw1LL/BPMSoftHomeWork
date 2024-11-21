define("FileImportConstants", ["FileImportConstantsResources"], function(resources) {
	/**
	 * @class BPMSoft.configuration.FileImportConstants
	 * FileImportConstants class contains configuration constants for FileImport.
	 */
	Ext.define("BPMSoft.configuration.FileImportConstants", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.FileImportConstants",
		singleton: true,

		Exceptions: {
			FileFormatException: {
				message: resources.localizableStrings.FileFormatExceptionMessage
			},
			ArgumentOutOfRangeException: {
				message: resources.localizableStrings.ArgumentOutOfRangeExceptionMessage
			},
			UriFormatException: {
				message: resources.localizableStrings.UriFormatExceptionMessage,
				link: {
					academyId: 1587,
					caption: resources.localizableStrings.UriFormatExceptionLinkCaption
				}
			},
			OpenXmlPackageException: {
				message: resources.localizableStrings.UriFormatExceptionMessage,
				link: {
					academyId: 1587,
					caption: resources.localizableStrings.UriFormatExceptionLinkCaption
				}
			},
			OutOfMemoryException: {
				message: resources.localizableStrings.OutOfMemoryExceptionMessage
			},
			EmptyHeaderException: {
				message: resources.localizableStrings.EmptyHeaderExceptionMessage
			}
		}
	});
});
