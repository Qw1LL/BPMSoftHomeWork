Ext.ns("BPMSoft.configuration.enums");

BPMSoft.Configuration.FileTypeGUID = {
	File: "529bc2f8-0ee0-df11-971b-001d60e938c6",
	Link: "539bc2f8-0ee0-df11-971b-001d60e938c6",
	EntityLink: "549bc2f8-0ee0-df11-971b-001d60e938c6"
};

//Backward compatibility.
BPMSoft.Configuration.FileTypeGUID.KnowledgeBaseLink = BPMSoft.Configuration.FileTypeGUID.EntityLink;

BPMSoft.Configuration.ActivityStatus = {
	NotStarted: "384d4b84-58e6-df11-971b-001d60e938c6",
	InProgress: "394d4b84-58e6-df11-971b-001d60e938c6",
	Finished: "4bdbb88f-58e6-df11-971b-001d60e938c6",
	Canceled: "201cfba8-58e6-df11-971b-001d60e938c6"
};

BPMSoft.Configuration.ActivityCategory = {
	ToDo: "f51c4643-58e6-df11-971b-001d60e938c6",
	Call: "e52bd583-7825-e011-8165-00155d043204"
};

BPMSoft.Configuration.ActivityResult = {
	Call: {
		Completed: "ee2c489d-a4c0-470d-a188-bd76490f0957"
	},
	ToDo: {
		Completed: "632afdd2-f616-4ea6-87d2-8ed38eed8aff"
	}
};

BPMSoft.Configuration.ActivityTypes = {
	Task: "fbe0acdc-cfc0-df11-b00f-001d60e938c6",
	Call: "e1831dec-cfc0-df11-b00f-001d60e938c6",
	Email: "e2831dec-cfc0-df11-b00f-001d60e938c6"
};

/**
 * List of contact types.
 */
BPMSoft.configuration.enums.ContactTypes = {
	Employee: "60733efc-f36b-1410-a883-16d83cab0980"
};
BPMSoft.ContactTypes = BPMSoft.configuration.enums.ContactTypes;

/**
 * List of modules.
 */
BPMSoft.configuration.enums.SysModuleId = {
	Dashboard: "0c5063c9-8180-e011-afbc-00155d04320c"
};
BPMSoft.SysModuleId = BPMSoft.configuration.enums.SysModuleId;

/**
 * Connection types of SysAdminUnit.
 */
BPMSoft.configuration.enums.SysAdminUnitConnectionType = {
	AllEmployees: 0,
	PortalUsers: 1
};
BPMSoft.SysAdminUnitConnectionType = BPMSoft.configuration.enums.SysAdminUnitConnectionType;

/**
 * Folder types.
 */
BPMSoft.configuration.enums.FolderTypeId = {
	Static: "9dc5f6e6-2a61-4de8-a059-de30f4e74f24",
	Dynamic: "65ca0946-0084-4874-b117-c13199af3b95",
	Favorite: "80c0c97d-51a7-4e32-a89e-d5f827705be4"
};

BPMSoft.FolderTypeId = BPMSoft.configuration.enums.FolderTypeId;

/**
 * List of call directions.
 */
BPMSoft.configuration.enums.CallDirectionId = {
	Incoming: "1d96a65f-2131-4916-8825-2d142b1000b2",
	Outgoing: "53f71b5f-7e17-4cf5-bf14-6a59212db422",
	NotDetermined: "c072be2c-3d82-4468-9d4a-6db47d1f4cca"
};

BPMSoft.CallDirectionId = BPMSoft.configuration.enums.CallDirectionId;

/**
 * List of visa statuses.
 */
BPMSoft.configuration.enums.VisaStatusId = {
	Positive: "e79facb3-3c32-43e7-a59e-12ba125e6132",
	Negative: "a93ab0b9-ca36-4b95-9b23-e01aa169c338"
};

BPMSoft.VisaStatusId = BPMSoft.configuration.enums.VisaStatusId;
