namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AddCampaignAudienceElementHandlerSchema

	/// <exclude/>
	public class AddCampaignAudienceElementHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AddCampaignAudienceElementHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AddCampaignAudienceElementHandlerSchema(AddCampaignAudienceElementHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4");
			Name = "AddCampaignAudienceElementHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,86,91,107,27,57,20,126,118,161,255,225,212,251,50,6,51,102,223,150,38,49,36,173,221,4,156,38,172,211,205,195,178,15,202,204,177,45,58,35,121,37,141,27,119,233,127,223,163,219,92,124,75,91,10,33,96,233,92,62,125,223,185,140,96,37,234,53,203,16,174,238,111,231,114,97,210,119,82,44,248,178,82,204,112,41,94,191,250,239,245,171,94,165,185,88,194,124,171,13,150,116,95,20,152,217,75,157,126,64,129,138,103,103,187,54,51,46,254,221,59,124,192,103,211,28,54,233,20,166,151,198,40,254,84,25,212,71,12,222,177,114,205,248,82,188,112,157,78,54,40,204,53,19,121,129,170,177,181,54,209,100,158,173,176,100,112,1,93,199,238,53,185,146,243,104,52,130,115,93,149,37,83,219,113,248,77,236,24,198,133,134,18,205,74,230,26,22,82,65,73,39,246,212,230,186,204,115,184,172,114,142,130,56,197,2,75,2,164,129,11,200,98,170,24,121,212,10,189,174,158,10,158,129,70,86,96,14,89,193,180,182,145,34,170,24,112,226,227,133,7,194,91,184,98,26,79,27,13,225,230,78,68,147,191,88,193,115,102,144,50,146,174,244,191,247,155,194,37,73,105,223,165,141,170,50,35,149,126,11,247,14,142,183,8,208,94,68,147,12,192,214,74,175,135,157,227,143,84,96,196,246,7,52,15,219,53,38,131,212,30,88,105,122,223,2,2,20,185,7,209,69,116,235,9,38,48,138,111,28,102,135,198,255,128,141,228,57,60,42,110,112,202,11,131,42,188,140,28,111,196,66,38,39,120,137,162,68,184,27,70,2,162,214,108,25,112,206,178,175,115,42,71,177,164,152,21,38,251,207,25,66,223,39,125,228,102,245,81,18,117,57,183,153,31,153,178,37,208,31,156,213,129,55,29,88,183,117,26,226,154,44,211,169,84,37,51,73,72,63,140,208,168,26,215,214,39,4,234,214,102,74,74,236,188,246,96,150,33,236,168,30,174,103,184,193,34,13,88,7,109,37,58,220,198,82,153,202,34,71,165,147,155,137,168,74,84,236,169,192,243,19,236,142,235,154,143,252,242,5,36,111,226,97,122,41,182,201,32,94,245,20,154,74,185,166,118,32,2,105,11,159,146,104,154,73,150,7,0,238,161,117,236,64,204,10,179,207,225,126,242,204,105,202,8,93,11,166,135,49,80,75,143,112,226,133,243,34,82,154,41,23,49,77,251,38,233,250,123,205,126,162,86,92,148,211,181,226,42,121,71,213,189,119,180,177,13,35,142,95,37,179,139,218,149,185,213,242,247,76,25,158,241,53,19,230,168,208,52,9,145,101,43,160,114,84,241,210,14,190,93,59,39,4,77,58,149,173,222,51,99,71,241,68,100,50,183,253,240,233,97,250,7,45,21,115,181,165,85,16,9,72,61,182,192,148,247,118,157,16,70,75,52,35,191,186,24,133,225,102,235,251,197,113,249,73,163,34,238,133,95,92,131,180,9,112,118,8,211,53,211,77,113,56,242,175,177,88,163,74,93,197,205,247,237,146,38,224,176,21,103,8,59,137,67,54,215,19,7,210,213,20,245,142,143,182,56,190,66,40,223,54,223,126,108,160,74,67,120,48,247,247,187,107,206,29,252,233,58,83,131,89,33,20,212,89,32,23,100,132,8,153,194,197,69,255,100,105,244,71,227,122,219,1,219,221,133,118,255,237,47,64,127,178,102,138,149,32,136,197,139,190,103,180,63,142,121,130,232,84,81,218,48,10,152,158,143,156,121,227,237,167,137,30,207,2,222,76,10,66,75,149,126,2,204,249,40,122,249,214,8,204,128,220,160,82,60,71,248,238,185,215,46,191,16,61,57,240,225,225,95,17,133,246,201,195,97,58,45,228,151,232,155,222,45,236,194,124,161,9,147,78,103,191,172,124,107,175,31,148,61,142,3,125,228,59,134,130,213,100,54,91,39,5,223,18,228,22,103,247,23,154,85,32,164,213,192,15,188,99,186,255,125,167,200,33,249,125,240,79,235,99,195,141,166,187,250,115,165,254,180,104,77,22,187,30,14,82,222,161,123,240,67,52,254,196,174,194,96,108,103,115,88,33,205,72,210,233,227,10,21,38,207,112,49,134,55,207,105,211,231,62,204,238,142,61,16,172,181,187,58,183,126,92,31,73,117,34,83,24,243,7,98,157,170,36,58,165,191,255,1,179,49,17,94,44,12,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateFolderWithNoConditionWarningLocalizableString());
			LocalizableStrings.Add(CreateFolderNotFoundErrorLocalizableString());
			LocalizableStrings.Add(CreateFilterWithNoConditionWarningLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateFolderWithNoConditionWarningLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7244310a-84bf-404b-baa6-2bae953fbbc1"),
				Name = "FolderWithNoConditionWarning",
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				CreatedInSchemaUId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4"),
				ModifiedInSchemaUId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFolderNotFoundErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f6c3f61f-5296-4d52-bc90-ce76168b921f"),
				Name = "FolderNotFoundError",
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				CreatedInSchemaUId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4"),
				ModifiedInSchemaUId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFilterWithNoConditionWarningLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("b77bcf38-2f18-445a-8f83-e2935ae6e184"),
				Name = "FilterWithNoConditionWarning",
				CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48"),
				CreatedInSchemaUId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4"),
				ModifiedInSchemaUId = new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b67a7d9d-3115-49bd-b36e-75efab9107b4"));
		}

		#endregion

	}

	#endregion

}

