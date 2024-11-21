namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OAuthClientAppListenerSchema

	/// <exclude/>
	public class OAuthClientAppListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OAuthClientAppListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OAuthClientAppListenerSchema(OAuthClientAppListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3");
			Name = "OAuthClientAppListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,88,205,111,219,54,20,63,187,64,255,7,194,187,40,128,161,116,59,54,177,1,215,73,51,3,77,147,197,201,122,40,122,96,164,103,155,155,68,185,36,229,54,45,252,191,239,241,75,162,100,217,113,58,100,61,236,82,71,228,251,230,239,253,248,88,78,115,144,43,154,0,121,115,125,57,43,230,42,158,20,124,206,22,165,160,138,21,60,190,26,151,106,249,219,171,151,47,190,191,124,209,43,37,227,11,50,123,144,10,242,147,214,55,234,101,25,36,90,73,198,23,192,65,176,164,150,169,141,231,121,193,187,214,5,116,175,198,231,92,49,197,64,62,178,29,159,175,129,171,14,41,147,193,148,43,88,184,148,206,110,175,14,144,58,255,154,192,74,255,133,178,40,253,139,128,5,126,144,73,70,165,124,77,140,248,36,99,232,114,188,90,189,99,88,1,204,216,72,126,52,17,61,152,112,252,70,52,75,150,144,211,247,88,108,50,36,253,166,118,255,232,19,170,173,202,251,140,37,36,209,246,119,152,39,175,201,27,42,193,108,142,87,108,66,177,224,232,179,135,71,131,255,214,33,226,9,40,81,38,170,16,24,233,181,177,107,37,156,143,110,235,209,17,218,191,71,251,17,135,47,228,140,153,163,164,226,225,244,246,97,5,3,130,38,177,94,35,148,210,72,232,245,190,19,133,235,197,60,194,72,102,32,214,32,170,138,29,13,72,255,93,145,208,140,125,163,247,25,204,140,166,140,43,143,24,131,169,241,239,148,167,25,110,157,11,81,136,75,144,146,46,32,254,147,102,37,244,201,102,176,195,11,102,199,53,204,214,186,198,143,121,116,178,5,239,116,161,61,108,48,159,141,171,31,240,212,150,176,89,207,75,80,203,34,213,165,20,108,77,21,184,90,218,15,82,101,53,229,243,226,6,62,151,32,21,185,0,213,88,127,43,138,220,194,34,178,63,4,204,143,47,230,154,10,60,121,173,224,32,98,183,177,143,148,174,126,138,189,85,230,220,196,125,234,15,162,175,69,251,71,39,149,1,1,41,19,152,238,157,200,14,180,112,83,107,132,134,104,125,68,135,219,10,206,181,101,206,38,54,77,15,52,100,11,55,77,67,19,210,80,204,157,4,113,176,153,89,160,18,154,98,114,172,209,243,72,145,239,139,34,67,35,83,39,188,157,206,25,200,68,48,3,190,3,3,10,52,182,205,213,248,65,107,186,255,58,97,101,193,210,243,21,66,81,95,91,219,45,189,73,41,85,145,187,42,213,128,242,187,222,166,3,217,110,129,102,118,91,25,183,197,239,4,67,177,38,108,156,204,57,215,13,169,195,241,133,119,27,225,249,224,110,120,194,78,162,70,39,147,182,42,31,63,145,239,13,152,155,22,238,109,108,53,5,168,82,240,173,130,154,205,77,179,105,215,5,75,201,68,0,254,109,200,240,6,100,81,138,4,166,220,230,20,93,148,40,80,91,74,7,196,172,8,47,135,11,58,214,154,96,72,217,248,12,27,91,180,140,187,19,238,118,220,50,227,51,107,74,197,51,192,227,152,7,48,147,209,46,209,128,236,3,84,152,164,246,105,84,129,105,157,58,237,93,241,208,53,184,8,90,149,54,101,195,190,48,70,49,102,90,102,170,182,29,29,92,68,144,190,51,44,129,218,11,245,143,18,196,67,171,102,113,40,112,73,57,50,190,192,235,161,145,149,111,192,45,91,182,164,36,49,63,150,107,228,231,120,156,186,150,70,70,168,200,100,186,165,252,150,101,10,241,139,56,70,176,187,92,237,26,25,90,72,107,99,22,118,118,253,3,83,203,107,42,176,3,241,67,70,118,17,103,164,21,69,204,23,92,147,73,124,254,185,164,25,38,48,245,38,251,3,130,215,59,184,48,180,73,171,39,117,156,81,203,115,35,209,122,68,115,140,21,44,216,76,241,164,218,162,221,144,100,115,18,181,109,224,125,91,106,120,15,201,175,254,232,124,83,182,69,63,190,250,212,201,150,26,46,163,200,151,63,214,220,228,28,110,8,100,18,200,30,191,163,192,173,101,93,146,219,27,223,33,103,107,66,104,35,199,195,99,134,163,19,170,121,212,108,141,74,125,199,80,189,174,161,227,18,167,210,219,37,229,87,28,90,120,111,206,31,46,175,158,90,138,226,75,205,8,149,179,106,184,137,92,22,205,66,252,252,68,223,23,207,147,95,192,34,7,140,100,133,194,156,32,245,172,227,62,73,129,163,162,96,169,163,250,91,29,67,237,208,21,13,204,80,40,23,71,100,56,34,143,135,89,137,159,28,26,92,48,122,31,31,31,147,83,89,230,57,78,212,35,191,96,6,96,144,174,59,136,102,209,148,128,126,56,196,149,206,113,91,233,20,201,129,230,132,99,107,12,251,18,99,192,99,26,153,215,6,177,95,241,233,177,17,233,214,128,254,232,118,9,24,11,0,73,4,204,135,253,219,215,59,30,84,38,170,241,28,89,196,152,31,139,133,236,147,227,17,97,248,190,160,28,159,140,73,193,21,101,92,215,82,45,193,187,51,9,144,148,42,218,136,196,61,62,154,7,115,197,167,28,161,169,52,70,139,251,191,240,236,92,18,3,199,243,111,96,142,65,85,254,9,248,22,159,44,33,249,123,66,185,101,248,25,50,134,61,90,163,29,204,87,174,182,67,226,38,239,35,43,97,5,118,95,76,110,162,107,222,79,206,172,126,36,197,97,228,62,100,15,225,198,240,86,223,184,104,126,133,111,51,211,165,101,150,117,200,250,65,47,80,177,11,195,125,79,10,247,150,112,76,255,21,146,82,129,123,31,70,145,1,119,87,8,211,212,234,233,103,21,75,224,131,192,249,13,193,163,239,58,59,138,180,131,192,71,86,103,85,234,188,221,54,78,39,1,167,7,19,253,96,59,16,247,42,156,166,135,152,152,1,34,86,117,154,177,91,205,17,100,31,224,32,237,198,91,19,238,53,220,26,103,142,202,237,35,127,28,106,173,137,178,126,53,224,179,82,55,120,144,111,160,81,143,94,22,3,63,0,215,125,115,110,99,196,13,167,219,61,6,55,29,140,214,98,178,187,21,182,191,161,88,67,102,63,157,196,90,44,178,143,197,158,72,95,62,211,103,96,47,7,185,202,195,147,33,247,159,80,203,14,26,49,81,195,143,50,201,230,240,75,243,12,50,28,158,255,119,215,166,73,251,89,113,87,121,144,79,197,157,27,175,254,229,255,251,60,5,109,55,144,99,129,26,104,195,27,229,64,148,181,230,56,187,218,92,220,252,3,187,153,64,86,39,23,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateClientApplicationHandlingErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateConnectionErrorMessageLocalizableString());
			LocalizableStrings.Add(CreateNoDefaultResourceMessageLocalizableString());
			LocalizableStrings.Add(CreateMoreThanOneDefaultResourceMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateClientApplicationHandlingErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2cf8bb31-6290-cc97-742e-64fed171040b"),
				Name = "ClientApplicationHandlingErrorMessage",
				CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee"),
				CreatedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3"),
				ModifiedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateConnectionErrorMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("3fb4a54a-87f4-40b3-82c2-9d506b6413b6"),
				Name = "ConnectionErrorMessage",
				CreatedInPackageId = new Guid("c966bd43-e9f4-4f60-86c2-6f60723d4eee"),
				CreatedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3"),
				ModifiedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNoDefaultResourceMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("645c2e6f-5960-4a83-98b7-9400582df07a"),
				Name = "NoDefaultResourceMessage",
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				CreatedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3"),
				ModifiedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateMoreThanOneDefaultResourceMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("c3610e85-9aca-45f0-b034-d6dfbee46312"),
				Name = "MoreThanOneDefaultResourceMessage",
				CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96"),
				CreatedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3"),
				ModifiedInSchemaUId = new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("15d94d7f-ad83-ec8e-ed13-e1079bfecbe3"));
		}

		#endregion

	}

	#endregion

}

