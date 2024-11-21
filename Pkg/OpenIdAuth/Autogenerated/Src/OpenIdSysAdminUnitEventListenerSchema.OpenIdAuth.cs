namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpenIdSysAdminUnitEventListenerSchema

	/// <exclude/>
	public class OpenIdSysAdminUnitEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpenIdSysAdminUnitEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpenIdSysAdminUnitEventListenerSchema(OpenIdSysAdminUnitEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6031c2b2-7861-40a6-9700-b2042b435ba9");
			Name = "OpenIdSysAdminUnitEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("cafc62fc-f7d7-4a5d-acf5-62f836ef940a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,148,81,143,218,48,12,199,159,65,226,59,120,221,11,72,168,188,115,7,18,32,182,33,29,227,52,224,94,166,61,132,214,208,108,52,169,146,180,140,77,247,221,207,73,90,70,57,16,147,16,82,28,255,237,159,99,187,32,88,138,58,99,17,194,248,121,190,148,91,19,78,164,216,242,93,174,152,225,82,132,139,12,197,44,30,229,38,105,53,255,182,154,141,92,115,177,131,229,81,27,76,31,78,231,127,218,52,149,226,154,93,97,56,21,134,27,142,250,206,117,56,45,80,152,91,94,159,88,100,164,42,163,208,239,163,194,29,113,194,100,207,180,238,131,199,37,188,81,156,114,177,22,220,184,104,79,156,120,5,170,86,147,36,223,93,166,99,237,162,189,140,18,76,217,87,122,13,24,64,112,30,32,232,252,248,63,209,203,225,189,44,203,55,123,30,65,100,233,238,193,65,31,198,76,163,79,180,56,144,229,130,189,97,27,96,139,62,85,61,71,147,200,152,234,126,86,210,96,100,48,174,60,178,202,0,5,87,38,103,123,40,36,143,97,146,96,244,107,194,196,58,139,153,193,181,166,34,124,62,208,71,109,143,254,212,1,151,170,81,48,5,57,89,105,38,4,69,179,41,7,117,207,112,93,187,126,56,201,10,182,231,148,67,42,82,184,230,248,206,29,195,207,104,30,103,254,41,156,54,97,98,135,47,149,247,176,221,241,49,248,22,218,31,78,65,66,98,246,158,142,185,206,212,189,128,175,232,29,7,42,37,213,28,181,102,59,219,37,129,7,120,146,17,197,253,195,54,123,92,26,69,35,118,17,47,252,134,90,230,42,162,91,169,72,214,245,209,26,193,157,6,6,93,8,222,197,214,22,221,204,101,204,183,71,203,56,162,20,5,150,64,33,213,157,99,208,9,87,178,36,41,171,111,152,68,201,131,163,157,254,142,48,179,88,237,243,82,74,191,87,251,255,122,26,11,20,177,159,140,219,131,226,6,210,237,65,163,215,235,193,163,206,211,148,169,227,240,11,19,241,30,53,160,31,135,153,32,86,99,215,15,109,137,225,99,175,114,60,41,51,166,88,10,246,3,50,8,52,101,166,7,24,186,247,0,127,34,141,115,185,174,192,96,184,74,144,242,35,66,164,112,59,8,86,253,27,223,3,71,52,198,45,89,93,252,145,218,233,0,122,67,224,66,27,38,232,219,21,73,97,24,23,22,215,36,88,229,115,228,64,243,195,106,40,229,78,202,130,222,147,199,232,23,99,225,87,194,182,64,110,126,210,28,148,69,116,225,106,122,192,106,200,54,180,178,225,153,186,146,85,29,186,178,113,229,202,117,188,171,247,163,30,94,118,144,206,222,90,55,146,13,222,0,202,139,56,230,183,5,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCantModifyUserActiveMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCantModifyUserActiveMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("9bf23670-1e6a-e323-1820-4acf68e5b432"),
				Name = "CantModifyUserActiveMessage",
				CreatedInPackageId = new Guid("cafc62fc-f7d7-4a5d-acf5-62f836ef940a"),
				CreatedInSchemaUId = new Guid("6031c2b2-7861-40a6-9700-b2042b435ba9"),
				ModifiedInSchemaUId = new Guid("6031c2b2-7861-40a6-9700-b2042b435ba9")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6031c2b2-7861-40a6-9700-b2042b435ba9"));
		}

		#endregion

	}

	#endregion

}

