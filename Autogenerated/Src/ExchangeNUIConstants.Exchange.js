define("ExchangeNUIConstants", ["BPMSoft", "ExchangeNUIConstantsResources", "ConfigurationConstants"],
	function(BPMSoft, resources, ConfigurationConstants) {
		var mailSyncPeriod = {
			Week: "2d480351-94b7-4cad-b02f-885730c7eb3e",
			All: "9f8663db-e39a-4559-a773-c343d1f3a9a3",
			OneDay: "560452ae-76cd-475e-bdd0-aac8e2ac7731",
			ThreeDays: "341eccde-6c76-4b3f-a647-84940adbe9d1"
		};

		var mailServer = {
			Type: {
				Imap: "844f0837-eaa0-4f40-b965-71f5db9eae6e",
				Exchange: "3490bd45-4f4d-4613-aa06-454546f3342a"
			},
			Gmail: "1b424a93-dee9-e011-8376-00155d04c01d"
		};
		var nameOfFolders = {
			ImportAppointmentsCalendars: {
				Name: "ImportAppointmentsCalendars"
			},
			ImportTasksFolders: {
				Name: "ImportTasksFolders"
			},
			ExportActivitiesGroups: {
				Name: "ExportActivitiesGroups"
			}
		};
		var exchangeFolder = {
			NoteClass: {
				Name: "IPF.Note"
			},
			AppointmentClass: {
				Name: "IPF.Appointment"
			},
			ContactClass: {
				Name: "IPF.Contact"
			},
			TaskClass: {
				Name: "IPF.Task"
			},
			BPMContact: {
				Name: "BPM.ContactFolder",
				SchemaName: "ContactFolder",
				SchemaFilters: [
					BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "FolderType",
						ConfigurationConstants.Folder.Type.Search)
				]
			},
			BPMActivity: {
				Name: "BPM.ActivityFolder",
				SchemaName: "ActivityFolder",
				SchemaFilters: [
					BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "FolderType",
						ConfigurationConstants.Folder.Type.Search)
				]
			}
		};

		return {
			MailServer: mailServer,
			ExchangeFolder: exchangeFolder,
			MailSyncPeriod: mailSyncPeriod,
			NameOfFolders: nameOfFolders
		};
	});
