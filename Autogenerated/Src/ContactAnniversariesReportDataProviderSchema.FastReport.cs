namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactAnniversariesReportDataProviderSchema

	/// <exclude/>
	public class ContactAnniversariesReportDataProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactAnniversariesReportDataProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactAnniversariesReportDataProviderSchema(ContactAnniversariesReportDataProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6");
			Name = "ContactAnniversariesReportDataProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,88,221,111,218,58,20,127,159,180,255,193,98,247,33,72,16,173,95,220,110,235,152,10,132,14,169,221,122,11,187,47,213,84,153,96,138,239,66,76,109,167,133,59,241,191,95,127,4,226,36,206,71,165,78,247,97,121,128,196,62,62,231,231,243,105,159,16,46,17,91,65,31,129,222,245,213,152,204,185,219,39,225,28,223,71,20,114,76,194,215,175,126,190,126,5,196,19,49,28,222,131,241,134,113,180,252,144,31,18,171,130,0,249,114,9,115,47,80,136,40,246,109,100,151,56,124,176,141,79,22,20,193,153,24,112,39,144,253,96,41,146,4,216,114,73,194,130,41,3,179,123,131,86,132,114,201,108,8,25,215,95,5,203,40,42,156,112,189,144,99,142,17,43,166,24,66,159,19,170,73,52,209,27,138,238,5,4,208,15,32,99,239,129,192,197,5,205,121,24,226,71,68,25,148,180,26,207,0,114,120,77,201,35,158,33,186,91,124,59,64,115,24,5,188,135,67,169,10,135,111,86,136,204,157,81,178,11,185,106,76,34,234,35,115,125,179,5,190,8,51,130,143,160,81,79,96,163,249,93,75,92,69,211,0,251,192,151,104,107,130,5,239,65,37,32,205,92,120,142,126,49,21,51,196,40,152,9,205,92,83,252,8,57,50,73,86,122,8,72,79,32,97,176,1,23,17,158,129,59,95,195,82,214,216,140,253,5,90,194,111,163,153,216,108,136,158,20,137,211,56,232,244,188,163,206,201,65,251,116,232,29,182,143,15,78,222,181,79,7,131,183,237,243,211,183,71,131,227,206,233,209,96,112,212,104,126,168,43,42,209,192,166,76,234,240,252,168,227,189,59,63,105,247,15,135,253,246,241,159,189,195,118,239,164,223,107,31,246,78,78,189,97,231,96,112,236,117,202,165,50,78,165,79,221,81,196,148,14,175,96,8,239,17,125,166,49,247,206,87,34,227,246,59,184,11,136,15,3,252,47,156,6,104,172,6,165,28,166,183,36,230,227,64,223,61,59,233,19,204,3,212,104,217,39,37,135,75,56,69,65,17,193,215,39,145,10,236,20,95,8,71,79,98,47,139,141,247,136,66,206,74,5,125,38,75,116,189,32,97,185,180,43,50,197,65,25,93,86,166,208,99,57,199,158,140,122,196,216,51,120,78,68,212,106,202,132,112,155,178,209,27,20,206,116,56,216,34,228,10,241,5,169,8,145,145,23,70,75,68,165,41,207,70,55,194,212,95,133,169,7,88,229,95,225,181,103,218,232,45,64,166,255,136,164,220,237,130,11,196,227,29,73,215,113,190,49,68,197,119,168,51,182,72,109,230,103,102,131,42,52,80,58,14,90,18,65,50,242,87,132,232,102,136,3,142,232,72,100,115,48,87,175,205,172,75,61,66,154,98,36,92,47,45,89,167,220,120,54,14,6,81,77,248,40,100,28,134,62,234,109,132,108,39,131,197,140,48,249,228,128,129,7,245,171,67,55,55,155,98,151,229,37,17,227,153,168,109,209,50,20,12,20,35,247,124,22,143,56,141,209,44,21,224,242,201,209,200,24,169,166,82,14,86,77,182,143,131,106,82,35,24,26,182,125,17,25,154,197,91,83,145,91,32,69,155,154,73,114,39,182,181,213,8,201,161,0,248,201,235,78,152,48,108,150,204,73,251,131,13,182,200,149,162,68,198,214,188,196,140,215,10,0,39,203,106,46,234,55,244,23,192,73,156,18,96,19,102,206,123,119,0,2,66,126,68,171,189,226,244,90,87,251,143,171,135,229,17,136,247,54,210,242,142,161,102,87,14,100,129,200,71,239,73,169,83,238,170,120,31,54,76,242,185,213,94,246,61,193,163,2,94,10,253,27,6,17,218,121,161,59,33,58,245,59,205,86,17,39,237,49,37,172,98,151,170,195,43,113,215,18,126,134,79,215,225,105,250,117,9,215,148,251,215,225,43,98,57,205,78,38,242,153,193,243,76,102,194,174,179,203,7,218,154,133,236,84,252,88,172,146,227,170,77,220,117,76,191,114,7,152,173,2,184,49,232,148,180,188,176,109,214,159,182,233,79,138,120,68,195,216,195,12,210,237,11,151,21,227,204,164,42,76,26,69,121,189,249,237,75,204,76,40,191,56,19,203,67,138,53,131,199,199,213,226,149,177,109,172,139,229,229,162,120,165,97,78,233,176,86,14,44,154,170,10,234,173,87,194,189,152,153,218,251,34,185,114,52,142,166,102,185,77,232,246,200,92,75,1,205,179,117,199,241,80,141,194,19,3,211,132,69,53,95,207,58,250,79,92,43,87,226,104,205,72,40,119,234,122,107,81,83,152,5,148,166,118,111,240,253,130,39,216,52,150,60,230,234,194,185,103,249,27,214,206,180,223,86,149,208,148,159,23,22,209,132,191,180,99,109,230,73,28,252,202,242,172,98,184,162,16,72,154,9,94,162,174,147,228,131,138,34,19,107,50,87,186,204,74,104,209,185,155,173,43,133,2,36,200,231,23,177,196,0,255,95,33,43,190,157,120,107,78,133,42,244,200,144,146,229,53,164,2,147,12,204,151,184,24,85,71,20,88,237,5,90,239,72,75,125,243,81,96,107,95,145,4,113,173,235,81,172,199,4,130,27,235,195,99,15,137,74,116,155,193,80,76,182,100,27,24,181,143,130,79,159,242,70,229,11,74,158,116,14,94,251,104,165,210,84,22,208,175,56,148,92,102,91,29,21,150,181,154,33,215,47,145,189,146,130,46,138,56,96,38,144,156,53,248,216,5,107,75,80,169,9,71,35,109,170,100,146,67,154,209,180,104,102,234,222,208,88,116,26,133,198,91,214,110,81,65,252,254,209,200,43,194,253,185,222,186,42,16,27,205,166,126,41,112,145,184,45,100,211,195,182,200,104,117,91,27,170,239,152,178,182,238,68,202,238,239,89,210,227,74,116,170,204,250,236,222,197,11,4,99,92,124,246,7,138,178,236,145,13,146,130,222,101,203,148,89,85,166,109,202,176,213,153,125,49,80,169,58,211,239,169,13,44,181,91,91,89,216,139,49,78,136,25,137,217,171,64,145,240,226,54,107,203,238,206,53,192,229,253,125,7,206,146,18,50,57,32,83,126,236,65,33,29,212,213,25,82,26,201,209,182,50,173,88,17,15,251,233,244,148,24,254,15,129,231,212,0,139,25,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateContactTitleLocalizableString());
			LocalizableStrings.Add(CreateContactNameLabelLocalizableString());
			LocalizableStrings.Add(CreateContactOwnerLabelLocalizableString());
			LocalizableStrings.Add(CreateContactBusinessPhoneLabelLocalizableString());
			LocalizableStrings.Add(CreateContactMobilePhoneLabelLocalizableString());
			LocalizableStrings.Add(CreateContactHomePhoneLabelLocalizableString());
			LocalizableStrings.Add(CreateNoteworthyEventsTitleLocalizableString());
			LocalizableStrings.Add(CreateNoteworthyEventsDateLabelLocalizableString());
			LocalizableStrings.Add(CreateNoteworthyEventsTypeLabelLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateContactTitleLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a3ea6fe3-858f-4289-953e-eff32e7d5359"),
				Name = "ContactTitle",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateContactNameLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f3763488-b1f1-4f2c-9200-e950a8061f92"),
				Name = "ContactNameLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateContactOwnerLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("446e0ff8-9068-4443-95ea-8430144c9fda"),
				Name = "ContactOwnerLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateContactBusinessPhoneLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1c2e18e8-dd88-4275-ae0e-4bb35daaf024"),
				Name = "ContactBusinessPhoneLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateContactMobilePhoneLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1480f944-970e-43bc-b7b7-f95d7bdc3b1d"),
				Name = "ContactMobilePhoneLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateContactHomePhoneLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("9de7d939-e5e0-4e9b-a1cf-2bcbfe1eb742"),
				Name = "ContactHomePhoneLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNoteworthyEventsTitleLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ffcde0e7-1ba1-43dc-96b9-60a1edd7edb9"),
				Name = "NoteworthyEventsTitle",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNoteworthyEventsDateLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5eb620ec-396b-44ca-ad94-05029cc294f4"),
				Name = "NoteworthyEventsDateLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNoteworthyEventsTypeLabelLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("989f9d5d-ca67-49d0-aaad-e69040b20d8d"),
				Name = "NoteworthyEventsTypeLabel",
				CreatedInPackageId = new Guid("906acf31-b33e-421e-b4ec-d7d51ef64e74"),
				CreatedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"),
				ModifiedInSchemaUId = new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dca41caf-58be-4af8-bb7d-ece6f8535de6"));
		}

		#endregion

	}

	#endregion

}

