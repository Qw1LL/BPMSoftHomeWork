﻿define("ProcessUserTaskConstants", ["ext-base", "BPMSoft", "ProcessUserTaskConstantsResources"],
	function(Ext, BPMSoft, resources) {
	/**
	 * @class BPMSoft.configuration.ProcessUserTaskConstants
	 * Class ProcessUserTaskConstants contains constants for user tasks of business processes.
	 */
	Ext.define("BPMSoft.configuration.ProcessUserTaskConstants", {
		alternateClassName: "BPMSoft.ProcessUserTaskConstants",
		singleton: true,

		AutoGeneratedPageElementFieldType: {
			NOTES: {
				id: "CommentaryField",
				name: "Notes",
				type: BPMSoft.DataValueType.TEXT
			},
			ITEMFOLDER: {
				id: "2",
				name: "ItemFolder",
				type: BPMSoft.DataValueType.TEXT
			},
			TEXT: {
				id: "1",
				name: "Text",
				type: BPMSoft.DataValueType.TEXT
			},
			SELECTION: {
				id: "SelectionField",
				name: "Selection",
				type: BPMSoft.DataValueType.LOOKUP
			},
			BOOLEAN: {
				id: "12",
				name: "Boolean",
				type: BPMSoft.DataValueType.BOOLEAN
			},
			DATETIME: {
				id: "DateTimeField",
				name: "DateTime",
				type: BPMSoft.DataValueType.DATE_TIME
			},
			INTEGER: {
				id: "4",
				name: "Integer",
				type: BPMSoft.DataValueType.INTEGER
			},
			DECIMAL: {
				id: "5",
				name: "Decimal",
				type: BPMSoft.DataValueType.FLOAT
			}
		},

		AutoGeneratedPageElementControlDataValueType: {
			SELECTFROMLOOKUP: "10",
			DROPDOWNLIST: "11"
		},

		AutoGeneratedPageElementDateTimeFormat: {
			DATEANDTIME: "7",
			DATE: "8",
			TIME: "9"
		},

		ChangeAdminRightsUserTaskGrantee: {
			ALL_ROLES_AND_USERS: {
				value: "AllRolesAndUsers",
				displayValue: resources.localizableStrings.ChangeAdminRightsUserTaskGranteeAllRolesAndUsers
			},
			ROLE: {
				value: "Role",
				displayValue: resources.localizableStrings.ChangeAdminRightsUserTaskGranteeRole
			},
			EMPLOYEE: {
				value: "Employee",
				displayValue: resources.localizableStrings.ChangeAdminRightsUserTaskGranteeEmployee
			},
			DATA_SOURCE_FILTER: {
				value: "DataSourceFilter",
				displayValue: resources.localizableStrings.ChangeAdminRightsUserTaskGranteeDataSourceFilter
			}
		},

		ChangeAdminRightsUserTaskOperation: {
			ADD: "AddRights",
			DELETE: "DeleteRights"
		},

		SERVER_GENERIC_LIST_TYPE: BPMSoft.process.constants.SERVER_GENERIC_LIST_TYPE,

		SERVER_GENERIC_DICTIONARY: BPMSoft.process.constants.SERVER_GENERIC_DICTIONARY,

		/**
		 * Result type of the read data user task.
		 * @type {Object.<String, String>}
		 */
		READ_DATA_RESULT_TYPE: {
			ENTITY: "0",
			FUNCTION: "1",
			ENTITY_COLLECTION: "2"
		},

		/**
		 * Add data mode.
		 * @type {Object.<String, String>}
		 */
		RECORD_ADD_MODE: {
			/** One record. */
			ONE_RECORD: "0",
			/** The result of query. */
			RECORD_SET: "1"
		},

		/**
		 * Enum, how to send email body.
		 * @type {Object.<String, String>}
		 */
		BODY_TEMPLATE_TYPE: {
			EmailTemplate: "0",
			ProcessTemplate: "1"
		},

		/**
		 * Enum, how to send email type.
		 * @type {Object.<String, String>}
		 */
		SEND_EMAIL_TYPE: {
			Auto: "0",
			Manual: "1"
		},

		/**
		 * Enum email importance.
		 * @type {Object.<String, String>}
		 */
		EMAIL_IMPORTANCE: {
			None: "0",
			Normal: "1",
			Hight: "2",
			Low: "3"
		},

		/**
		 * Enum email recipient type.
		 * @type {Object.<String, String>}
		 */
		EMAIL_RECIPIENT_TYPE: {
			To: "Recipient",
			Cc: "CopyRecipient",
			Bcc: "BlindCopyRecipient"
		},

		/**
		 * Enum approver type.
		 * @type {Object.<String, String>}
		 */
		APPROVER_TYPE: {
			Employee: "0",
			EmployeeManager: "1",
			Role: "2"
		},

		/**
		 * ObjectFileProcessingUserTask result action types.
		 * @type {Object.<String, String>}
		 */
		ObjectFileProcessingUserTaskResultActionType: {
			SaveToFiles: "0",
			UseInProcess: "1"
		},

		/**
		 * ObjectFileProcessingUserTask result action types.
		 * @type {Object.<String, String>}
		 */
		ObjectFileProcessingUserTaskSourceActionType: {
			ReadFiles: "0",
			GenerateReports: "1",
			UseProcessParameter: "2"
		}

	});

	return BPMSoft.ProcessUserTaskConstants;
});
