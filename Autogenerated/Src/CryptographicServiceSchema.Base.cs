namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CryptographicServiceSchema

	/// <exclude/>
	public class CryptographicServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CryptographicServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CryptographicServiceSchema(CryptographicServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378");
			Name = "CryptographicService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("55f82158-5486-4bb7-b202-c8f84f805cfa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,84,223,111,218,48,16,126,78,165,254,15,86,246,146,74,200,188,175,63,164,150,177,169,219,104,81,211,141,7,212,7,147,28,52,106,98,123,103,135,46,157,246,191,239,156,56,36,132,138,33,8,248,252,221,247,125,190,59,35,69,1,70,139,4,216,205,124,22,171,181,229,19,37,215,217,166,68,97,51,37,79,79,254,156,158,4,165,201,228,134,197,149,177,80,156,15,214,251,248,131,221,24,112,155,37,48,83,41,228,71,55,249,2,86,199,1,215,137,205,182,3,149,206,116,81,188,31,71,56,140,146,84,151,65,187,75,175,67,71,177,40,18,251,228,98,215,70,223,129,37,152,38,205,85,150,103,182,122,128,95,101,134,80,128,180,38,234,47,156,65,118,201,254,147,226,80,220,7,210,51,39,162,203,85,158,37,44,201,133,49,108,130,149,182,106,131,66,63,103,137,119,196,62,178,27,97,160,93,185,102,4,203,123,13,77,181,251,126,131,37,157,234,86,110,213,11,68,51,176,207,42,37,67,225,252,62,126,12,71,236,70,165,85,108,171,220,153,36,216,12,140,17,27,216,69,249,130,68,53,164,35,199,19,56,135,96,236,103,133,133,176,123,9,77,136,127,53,74,142,216,3,205,141,146,6,142,227,220,49,29,235,120,60,102,23,166,44,10,129,213,85,27,248,208,127,237,86,254,7,125,117,0,246,105,26,243,29,207,120,72,116,161,5,138,130,73,26,230,203,80,83,49,95,21,166,225,85,199,215,147,226,23,227,26,221,37,35,216,18,165,241,240,209,190,173,126,106,127,77,52,109,158,35,242,157,52,22,221,160,125,113,83,32,183,128,22,210,185,183,243,83,228,37,68,30,208,122,60,107,90,26,100,107,230,183,248,173,185,43,243,252,30,167,133,182,85,180,3,182,200,160,81,245,74,188,70,185,9,15,130,191,245,115,43,144,37,245,36,249,161,249,6,21,53,103,239,150,206,132,164,46,33,191,214,58,6,107,137,199,44,195,153,217,252,48,128,173,93,42,248,100,64,19,62,157,31,55,59,212,237,76,59,87,8,70,149,152,64,108,21,146,60,153,114,122,100,76,2,221,108,37,249,66,225,75,253,95,68,151,100,15,122,222,145,0,162,66,63,102,196,32,225,149,125,87,137,200,179,55,177,202,9,239,92,69,3,165,102,172,131,32,124,239,134,209,237,8,15,24,12,31,158,125,250,59,1,93,215,174,209,230,117,59,195,51,111,205,62,163,122,173,221,184,122,60,192,26,16,100,2,187,172,168,239,219,39,53,253,242,3,81,236,87,191,105,218,176,158,252,81,249,19,122,138,230,111,45,58,232,249,28,213,54,75,1,125,133,134,189,108,183,163,67,213,131,57,123,151,151,79,101,29,239,198,179,119,36,247,160,15,189,255,1,200,76,174,75,93,6,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCryptoServiceKeyExceptionMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCryptoServiceKeyExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7264c8f8-6a12-42f2-b6d0-3a6bc04b2a99"),
				Name = "CryptoServiceKeyExceptionMessage",
				CreatedInPackageId = new Guid("55f82158-5486-4bb7-b202-c8f84f805cfa"),
				CreatedInSchemaUId = new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378"),
				ModifiedInSchemaUId = new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ba8f2b10-80c4-416c-92db-1fe39960f378"));
		}

		#endregion

	}

	#endregion

}

