namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OAuthResourceListenerSchema

	/// <exclude/>
	public class OAuthResourceListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OAuthResourceListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OAuthResourceListenerSchema(OAuthResourceListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2");
			Name = "OAuthResourceListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,86,75,111,219,70,16,62,43,64,254,195,128,189,80,128,65,21,61,218,146,0,89,86,83,1,113,109,68,114,123,8,114,88,147,35,105,91,114,151,216,93,42,86,3,253,247,206,62,72,145,138,92,91,45,2,4,232,69,20,151,243,252,230,155,217,17,172,64,93,178,20,225,250,254,118,33,87,38,153,74,177,226,235,74,49,195,165,72,238,38,149,217,252,244,227,219,55,95,222,190,233,85,154,139,53,44,118,218,96,113,117,244,78,122,121,142,169,85,210,201,59,20,168,120,122,144,57,24,47,10,41,78,157,43,76,102,194,112,195,81,191,240,57,153,109,81,152,19,82,46,214,185,48,184,14,193,223,44,239,94,33,53,123,74,177,180,255,72,150,164,127,80,184,166,23,152,230,76,235,75,112,226,31,80,203,74,165,248,158,83,170,148,154,19,252,232,2,218,185,104,234,15,241,34,221,96,193,126,37,84,97,4,81,71,57,234,127,34,173,178,122,204,121,10,169,181,126,218,56,92,194,53,211,232,190,77,74,62,101,132,43,121,236,81,5,232,247,16,31,1,109,84,149,26,169,40,204,123,103,214,75,4,23,39,141,199,125,50,255,72,230,99,129,159,225,134,187,130,49,181,27,46,119,37,94,0,89,36,172,198,36,101,235,221,235,125,1,67,231,114,21,83,32,11,84,91,84,13,90,253,11,136,222,203,148,229,252,47,246,152,227,194,105,234,164,118,248,129,162,36,151,246,112,166,148,84,183,168,53,91,99,242,27,203,43,140,96,127,241,140,125,74,75,88,26,109,45,180,47,248,170,101,165,56,233,194,122,216,83,38,251,0,28,138,204,99,215,5,242,22,205,70,102,22,67,197,183,204,96,0,209,191,0,5,86,167,52,23,43,9,239,208,180,142,126,86,178,240,52,136,253,3,208,61,106,252,182,76,129,10,178,129,20,94,128,90,196,88,200,51,106,155,170,16,46,228,97,141,126,100,69,163,254,213,87,38,110,184,46,115,182,59,195,82,75,163,109,144,29,82,32,67,150,10,199,121,250,248,123,193,85,59,7,95,185,94,55,150,19,17,6,185,123,37,75,84,182,113,131,167,22,233,124,152,13,237,106,167,68,139,200,166,20,81,217,39,101,73,100,118,157,58,73,83,170,112,40,44,149,214,61,246,62,41,133,166,82,162,157,151,59,127,125,233,165,33,38,97,86,23,63,188,130,36,74,42,158,33,108,37,207,96,185,81,242,115,195,202,216,135,13,232,200,167,215,125,24,141,193,88,17,151,103,167,255,14,74,141,244,213,107,99,107,181,246,96,48,128,161,174,138,130,208,27,215,7,191,48,145,229,4,175,231,3,44,216,150,2,71,59,150,146,70,103,112,172,52,44,153,98,5,8,42,212,40,210,20,3,170,104,236,102,25,248,183,100,56,112,34,167,53,48,26,47,55,72,177,32,66,170,112,53,138,150,151,207,76,107,23,213,100,69,179,192,153,159,168,53,213,112,48,6,78,243,139,9,34,96,42,133,97,92,88,40,205,6,107,119,46,1,200,152,97,157,72,194,112,235,214,229,78,204,133,182,36,19,235,88,62,254,65,165,11,73,92,128,119,127,141,43,10,170,241,15,88,55,232,116,131,233,159,83,38,110,153,160,209,177,160,22,242,149,117,218,161,97,236,184,76,218,46,106,219,216,234,168,0,254,8,194,32,232,123,33,47,112,220,92,221,246,123,118,164,132,89,226,109,204,158,48,173,12,134,27,33,142,29,219,230,153,151,177,179,147,167,248,187,98,37,53,91,50,201,178,218,92,220,242,69,99,52,204,140,7,74,229,48,61,155,76,246,103,177,204,113,255,251,162,217,81,157,255,3,207,92,40,88,119,109,112,238,87,157,59,130,216,13,36,194,149,38,128,157,19,77,123,71,227,105,165,148,181,88,17,196,148,163,214,86,157,107,107,129,238,147,140,206,29,110,79,212,15,130,229,192,220,80,107,33,216,248,252,39,186,123,244,191,29,215,131,253,35,162,159,65,143,27,204,209,252,255,8,50,23,91,90,82,178,134,33,45,94,52,136,48,225,175,134,230,206,180,236,16,210,0,41,21,220,16,71,206,101,67,109,250,76,62,188,56,182,218,171,199,130,246,76,98,205,97,237,232,142,144,102,239,11,114,222,64,184,32,11,191,152,133,251,255,171,69,46,62,242,65,183,254,201,221,213,174,3,245,89,157,114,123,241,171,23,156,195,21,252,108,57,226,16,82,135,215,207,160,251,80,82,237,191,105,183,53,30,190,251,139,229,193,70,74,187,253,191,191,91,142,214,29,127,218,61,220,255,13,1,101,173,93,149,14,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateConnectionErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateResourceRegisteringErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateResourceModifyingErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateResourceDeletingErrorMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateConnectionErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e03aaebb-193b-8726-710a-929627d6b105"),
				Name = "ConnectionErrorMessage",
				CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateResourceRegisteringErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("21597b70-844d-8f8f-62df-ff422643519c"),
				Name = "ResourceRegisteringErrorMessage",
				CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateResourceModifyingErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("592cb685-553c-4598-8deb-f17e38c2101e"),
				Name = "ResourceModifyingErrorMessage",
				CreatedInPackageId = new Guid("1cbe3766-af85-4075-b77c-3de2d413d0be"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateResourceDeletingErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("12e7cc28-c036-6369-e37b-184500b360e6"),
				Name = "ResourceDeletingErrorMessage",
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				CreatedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"),
				ModifiedInSchemaUId = new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5df6ce04-ddc6-56cc-e05b-a60552c68db2"));
		}

		#endregion

	}

	#endregion

}

