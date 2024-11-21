namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactDataEntryComplianceDataSourceDataProviderSchema

	/// <exclude/>
	public class ContactDataEntryComplianceDataSourceDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactDataEntryComplianceDataSourceDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactDataEntryComplianceDataSourceDataProviderSchema(ContactDataEntryComplianceDataSourceDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e");
			Name = "ContactDataEntryComplianceDataSourceDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,88,219,110,219,56,16,125,118,129,254,3,215,221,7,105,225,104,115,105,131,108,155,11,226,75,10,3,77,154,198,238,246,161,40,10,70,162,109,109,37,210,33,169,52,222,54,255,190,67,142,100,83,178,236,184,217,2,187,47,113,56,188,204,204,153,51,195,161,56,77,153,154,210,144,145,246,229,249,64,140,116,208,17,124,20,143,51,73,117,44,248,211,39,223,158,62,105,100,42,230,99,50,152,41,205,210,87,149,49,172,79,18,22,154,197,42,120,205,56,147,113,184,180,230,77,204,111,150,132,195,137,100,52,2,65,48,164,234,139,90,204,47,44,73,83,193,235,228,142,133,193,21,155,10,169,205,49,103,84,105,28,213,237,145,172,94,26,244,184,142,117,204,212,138,233,51,26,106,33,107,231,47,178,56,24,48,121,27,135,236,92,68,44,9,122,119,154,113,101,160,88,44,182,199,207,6,225,132,165,148,28,213,171,14,220,69,245,91,1,230,44,229,27,29,128,75,225,24,56,232,153,100,99,176,135,116,18,170,212,75,210,201,148,22,105,151,106,122,41,197,109,28,49,105,87,125,236,178,17,205,18,221,142,185,9,136,167,103,83,38,70,94,127,129,168,217,50,16,153,12,153,187,217,111,145,11,32,16,88,213,132,160,104,64,202,204,130,45,114,6,193,155,38,49,229,184,97,121,107,211,255,4,138,167,217,117,18,135,36,52,214,145,31,61,130,188,36,15,90,8,58,128,193,240,119,142,196,89,204,146,8,160,184,148,241,45,213,12,39,167,56,32,134,145,130,39,51,242,58,139,35,242,153,57,168,190,239,71,224,39,103,95,237,156,215,220,217,111,247,246,246,95,236,108,29,156,245,118,183,158,239,188,248,99,235,160,219,221,222,58,61,216,222,235,62,223,63,216,235,118,247,154,254,171,218,211,149,150,38,190,159,37,83,214,226,115,202,233,152,201,71,99,185,78,203,199,79,228,115,34,66,154,196,127,211,235,132,13,172,208,104,82,232,14,204,155,28,111,52,154,136,227,48,214,9,107,182,80,244,46,163,22,130,183,163,43,22,10,25,169,55,244,154,37,197,44,18,173,36,58,139,161,26,68,125,126,201,192,70,240,98,204,106,167,75,194,11,161,203,114,35,190,71,254,54,158,49,30,97,228,202,97,60,103,122,34,86,198,177,239,230,195,187,140,201,25,104,208,76,246,161,240,144,14,32,164,89,47,157,234,25,122,240,39,77,50,134,11,188,165,141,228,198,252,109,213,37,99,104,127,252,28,63,201,116,38,11,97,96,226,99,207,29,66,46,145,88,145,33,187,211,37,161,221,212,56,193,243,3,52,10,141,248,16,235,201,37,149,16,35,24,40,15,133,134,4,84,198,74,112,179,57,0,208,122,55,25,77,90,133,66,19,210,86,30,243,192,58,231,163,134,151,37,13,125,5,59,47,178,36,201,253,117,118,35,89,239,203,72,198,92,147,215,44,15,16,250,125,37,190,118,68,198,181,247,94,25,179,56,199,242,79,178,210,16,131,219,40,149,63,55,159,214,32,218,90,31,191,145,253,183,128,125,69,192,242,92,93,154,245,92,27,208,227,6,226,115,26,229,254,121,56,190,18,66,227,50,184,215,52,208,44,165,38,21,205,10,131,150,231,251,193,32,75,141,208,134,248,136,156,142,199,64,78,123,43,217,16,89,144,92,13,232,131,50,154,188,181,36,204,41,151,243,203,95,117,70,14,196,43,151,126,184,10,12,206,109,27,48,115,59,163,235,229,0,249,112,93,177,48,211,108,0,197,129,202,67,136,244,177,183,142,3,88,2,54,9,61,150,207,74,245,252,161,168,222,82,89,218,15,240,150,117,148,110,188,188,126,26,183,251,92,105,83,41,219,51,80,89,10,54,140,203,80,173,162,117,213,153,50,107,221,145,81,216,109,151,168,225,193,157,232,198,165,2,229,181,16,9,233,80,62,248,18,79,243,13,27,22,22,76,167,60,93,223,43,240,23,105,119,84,147,71,243,105,40,19,156,145,239,223,31,183,249,52,186,53,80,70,243,3,188,85,197,173,13,110,49,202,75,114,191,170,23,175,55,184,223,46,39,66,139,157,253,230,250,5,187,187,15,44,216,219,109,214,65,12,44,203,82,38,205,101,119,216,191,130,203,240,45,92,134,221,216,6,19,194,116,136,37,178,69,196,245,95,16,225,227,99,195,3,123,195,50,205,153,82,198,7,15,181,110,82,223,106,153,142,83,255,23,186,155,195,229,34,119,225,236,74,50,175,35,188,77,220,186,66,83,202,3,100,142,66,191,131,15,19,38,89,206,21,114,116,76,126,41,19,190,40,107,249,106,172,80,37,219,139,102,247,56,135,7,125,24,213,36,43,58,243,47,211,24,55,86,220,156,59,106,174,145,213,244,153,91,216,248,152,247,67,134,164,205,79,96,216,178,138,160,67,167,54,154,67,129,125,24,84,139,197,246,69,207,84,180,67,230,152,98,190,225,65,25,246,207,169,158,192,205,148,241,200,243,34,1,221,51,243,107,97,249,157,120,165,144,31,145,109,114,66,118,160,101,118,196,62,249,141,236,108,111,183,200,182,107,134,171,188,22,115,103,173,211,186,217,229,174,206,173,218,205,249,94,211,222,217,223,130,5,111,37,52,178,237,89,151,41,192,192,62,66,238,76,252,239,234,97,41,118,13,39,140,183,103,243,165,110,0,252,159,85,27,46,178,244,154,201,121,7,252,159,212,135,5,21,231,237,122,99,67,94,26,84,0,119,27,158,71,230,125,30,42,251,115,255,179,96,125,83,125,147,168,245,77,133,91,42,151,222,51,230,45,179,226,149,3,185,182,176,36,15,28,242,165,229,12,60,52,205,247,12,170,75,166,85,144,130,111,14,248,110,27,192,151,1,224,101,171,246,37,215,34,191,54,151,157,12,190,221,221,7,246,142,108,66,3,105,255,41,215,213,60,198,117,62,174,194,126,53,139,224,131,132,132,151,36,74,206,164,72,157,103,197,99,90,184,156,184,15,135,152,76,231,138,220,192,165,8,143,181,109,227,43,14,22,111,208,205,45,20,6,185,215,61,117,179,112,28,31,183,142,251,85,127,29,211,240,53,68,78,78,136,158,72,241,21,31,18,119,33,179,181,187,220,34,63,252,60,181,95,56,242,144,225,215,14,243,185,235,112,241,209,98,1,162,205,11,91,95,30,136,205,227,3,128,25,13,216,175,99,70,85,93,245,59,72,203,61,220,237,49,20,124,67,202,31,94,117,254,21,53,201,148,164,82,191,85,20,167,106,27,246,176,33,121,133,106,21,7,215,20,235,226,240,186,58,254,227,10,150,51,186,56,191,166,160,85,42,152,83,64,11,214,26,46,4,200,79,3,30,92,218,230,103,29,197,80,90,22,130,236,31,196,84,35,103,201,21,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateReportTitleLocalizableString());
			LocalizableStrings.Add(CreateQuantityOfRecordsLabelLocalizableString());
			LocalizableStrings.Add(CreateColumnLabelLocalizableString());
			LocalizableStrings.Add(CreateFilledInPercentageLabelLocalizableString());
			LocalizableStrings.Add(CreateFilledInLabelLocalizableString());
			LocalizableStrings.Add(CreateNotFilledInLabelLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateReportTitleLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("63943904-f284-4c2b-8c09-40ebd2f68beb"),
				Name = "ReportTitle",
				CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893"),
				CreatedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"),
				ModifiedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateQuantityOfRecordsLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("00170f6c-9158-4943-830a-0fbe7a4beef7"),
				Name = "QuantityOfRecordsLabel",
				CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893"),
				CreatedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"),
				ModifiedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateColumnLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("cdc9f530-a9ec-4566-b8c8-0445bfb15ba8"),
				Name = "ColumnLabel",
				CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893"),
				CreatedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"),
				ModifiedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFilledInPercentageLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("d1a5b31d-a21d-4eda-af7c-08971fd8efd1"),
				Name = "FilledInPercentageLabel",
				CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893"),
				CreatedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"),
				ModifiedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFilledInLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("4cbb0ef3-8cd3-487e-b927-c14c08c0f2eb"),
				Name = "FilledInLabel",
				CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893"),
				CreatedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"),
				ModifiedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNotFilledInLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("d5ad4a57-06bf-4feb-9cda-0401d4240773"),
				Name = "NotFilledInLabel",
				CreatedInPackageId = new Guid("efa487c3-72d9-47e0-913f-57efbff16893"),
				CreatedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"),
				ModifiedInSchemaUId = new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7168866e-bf9a-4c7d-a71f-006687219c1e"));
		}

		#endregion

	}

	#endregion

}

