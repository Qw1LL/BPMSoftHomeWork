namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExternalAccessAppListenerSchema

	/// <exclude/>
	public class ExternalAccessAppListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExternalAccessAppListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExternalAccessAppListenerSchema(ExternalAccessAppListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df");
			Name = "ExternalAccessAppListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,86,91,111,212,58,16,126,94,36,254,131,9,60,100,165,54,165,80,96,5,109,143,182,37,91,86,162,80,53,42,60,28,29,33,175,51,187,245,57,137,189,216,206,66,65,253,239,140,227,36,172,115,41,232,72,188,236,198,227,241,204,55,223,92,108,65,115,208,107,202,128,156,92,156,39,114,105,162,83,41,150,124,85,40,106,184,20,81,252,213,128,18,52,155,50,6,90,95,80,246,31,93,193,253,123,223,239,223,27,21,154,139,21,73,110,180,129,252,85,179,254,105,38,207,165,232,147,43,232,151,250,158,7,116,94,159,12,108,204,40,51,82,113,208,221,253,143,176,24,132,99,247,222,24,179,142,166,11,109,20,218,64,215,214,4,42,62,84,176,194,21,57,205,168,214,47,137,207,196,116,189,126,203,49,114,1,170,84,222,219,219,35,135,92,92,131,226,38,149,108,239,24,101,235,98,145,113,70,152,61,63,124,156,188,36,184,138,55,32,76,45,58,161,26,57,30,33,201,248,219,224,152,113,200,82,4,114,161,248,134,26,112,155,107,183,32,218,32,107,140,40,160,169,20,217,13,57,43,120,74,62,129,231,52,97,215,144,211,171,121,74,142,136,128,47,165,78,24,204,158,78,158,77,226,131,231,187,241,244,233,100,247,96,255,73,188,59,157,29,76,119,159,60,222,223,159,61,158,188,216,159,76,227,96,236,40,25,61,4,145,58,56,62,182,115,48,215,114,16,92,9,230,12,140,207,193,153,162,2,83,22,94,105,80,152,122,1,37,249,164,240,150,59,238,176,31,200,60,29,19,91,129,163,209,134,42,162,33,67,93,140,41,76,202,175,177,141,205,125,134,190,177,113,121,102,132,197,144,233,48,168,252,207,211,160,150,207,148,204,195,192,71,25,236,144,0,104,163,242,17,51,12,161,149,160,220,30,141,230,58,254,92,208,44,68,163,69,46,162,11,170,176,165,208,66,216,193,108,73,68,27,14,47,118,22,176,194,64,130,213,152,193,37,48,169,210,208,166,15,43,226,232,184,76,36,168,8,73,115,118,63,208,172,128,67,203,197,177,135,124,135,200,194,16,75,195,170,22,86,110,20,152,66,137,159,226,82,122,235,39,166,69,61,122,243,37,225,54,207,215,216,38,184,101,48,46,23,146,68,164,174,59,92,243,221,88,184,135,243,55,93,189,227,176,2,213,178,131,231,123,172,90,51,115,129,21,45,24,132,126,52,91,218,127,69,9,106,35,200,191,3,31,116,240,15,161,186,21,90,95,240,27,137,133,117,138,68,27,164,63,231,34,197,76,204,164,242,211,31,226,84,176,243,34,99,223,146,242,235,29,102,183,102,229,206,202,197,216,122,248,116,209,240,37,105,149,38,57,194,158,44,178,172,54,93,5,236,212,111,27,238,218,53,133,78,124,59,173,129,93,165,189,116,216,62,107,43,55,95,155,155,112,124,135,83,123,240,1,206,248,4,140,193,232,181,205,77,89,139,45,252,216,13,190,231,42,57,239,164,225,75,206,202,145,30,11,186,200,32,197,206,89,210,76,195,93,110,123,154,190,41,122,71,108,255,44,105,131,234,244,224,16,29,141,245,223,98,165,42,138,20,52,83,124,93,101,219,142,157,183,146,209,140,127,179,113,186,114,105,33,138,46,65,203,66,49,220,149,10,111,210,14,109,91,23,67,176,227,220,63,10,58,86,117,244,221,43,200,219,168,204,73,57,166,171,74,81,117,73,95,25,158,113,131,23,99,95,179,94,118,180,154,86,237,26,136,90,205,210,97,219,50,208,236,186,219,60,28,186,131,26,118,167,5,94,29,46,173,45,174,78,11,165,240,86,180,45,100,223,6,6,113,207,211,138,148,102,141,199,6,50,89,105,38,197,226,95,232,213,108,84,94,123,121,220,202,170,75,249,120,123,122,252,250,6,44,111,125,183,217,247,42,168,159,5,114,3,74,241,180,154,67,239,69,213,48,137,161,202,132,245,139,160,158,147,204,253,215,164,253,114,106,5,189,205,88,218,134,244,28,87,88,123,85,181,84,113,253,15,168,177,72,255,16,80,180,60,0,179,69,191,147,250,66,148,253,0,5,130,27,42,214,10,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateExternalAccessSessionStartedMessageLocalizableString());
			LocalizableStrings.Add(CreateExternalAccessSessionEndedMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateExternalAccessSessionStartedMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("400920bc-ccb5-41e3-ac22-d74e0dc85be5"),
				Name = "ExternalAccessSessionStartedMessage",
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd"),
				CreatedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df"),
				ModifiedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateExternalAccessSessionEndedMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7f54a547-ff83-45e6-9501-b0794feebae8"),
				Name = "ExternalAccessSessionEndedMessage",
				CreatedInPackageId = new Guid("c3c7809d-fee0-4b66-8bb6-9b3983c2cffd"),
				CreatedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df"),
				ModifiedInSchemaUId = new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("22d9fa35-9564-4de9-b89c-b84ecaec99df"));
		}

		#endregion

	}

	#endregion

}

