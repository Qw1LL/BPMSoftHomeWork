namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkEmailNotifierSchema

	/// <exclude/>
	public class BulkEmailNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkEmailNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkEmailNotifierSchema(BulkEmailNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e57633a3-e0d1-4ae8-8223-b6634131fc48");
			Name = "BulkEmailNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8ded9bc0-26e3-4d8b-ab12-46857e761bcf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,203,110,219,48,16,60,59,64,255,129,80,47,18,96,200,247,38,246,33,207,26,104,2,55,74,209,51,45,173,108,54,18,169,242,145,198,13,242,239,93,146,162,44,89,78,144,30,108,136,203,221,229,204,236,144,156,214,160,26,154,3,57,95,221,102,162,212,233,133,224,37,219,24,73,53,19,252,211,201,203,167,147,137,81,140,111,72,182,83,26,234,211,110,189,47,144,112,60,154,94,158,227,6,110,125,150,176,193,110,228,162,162,74,125,33,231,166,122,188,170,41,171,238,132,102,37,3,233,146,102,179,25,57,83,166,174,169,220,45,218,181,205,36,96,83,9,226,84,116,3,164,145,34,199,79,123,22,111,203,211,80,61,235,149,55,102,93,177,156,228,246,200,241,137,4,81,80,5,223,13,24,184,245,157,247,96,38,72,26,255,247,176,5,87,90,154,92,11,137,232,87,174,177,207,56,196,236,2,189,116,82,226,239,76,1,144,92,66,57,143,70,56,162,217,194,67,180,28,198,36,124,164,161,146,214,132,227,168,230,145,81,32,241,0,14,185,157,79,180,56,155,185,93,151,220,82,30,29,18,255,24,20,145,97,143,4,181,88,163,22,241,97,216,142,126,242,218,74,1,188,240,106,12,165,89,73,209,128,212,12,172,48,82,104,172,133,226,29,109,238,144,4,17,37,209,91,148,196,72,9,92,15,198,120,68,130,38,180,37,226,9,164,100,5,16,148,215,206,63,240,115,77,95,200,6,52,153,47,200,13,232,135,93,3,113,146,218,248,41,121,253,32,28,9,53,227,133,237,139,160,152,222,17,149,111,209,122,255,141,234,62,244,201,92,253,16,156,29,162,40,227,110,68,73,135,239,45,133,111,65,111,69,225,228,101,79,84,131,223,109,252,34,156,137,156,247,83,199,35,226,27,195,10,178,14,161,101,209,78,115,242,68,37,81,80,33,114,50,39,28,254,144,204,45,14,28,146,184,220,9,94,226,202,212,60,142,108,203,40,4,175,165,168,227,17,143,176,251,115,11,18,226,104,89,68,73,186,84,87,191,13,173,98,223,38,93,89,163,130,70,63,246,129,37,132,170,22,133,125,69,38,19,15,47,205,26,200,89,185,187,19,223,68,254,248,149,113,173,226,196,39,72,208,70,242,150,70,122,245,12,185,209,144,229,180,162,242,204,235,177,104,83,63,46,237,192,185,71,102,235,244,68,149,51,179,254,133,91,203,34,182,207,199,3,85,143,253,39,36,60,82,65,237,22,105,28,222,46,100,218,41,214,175,75,210,46,188,44,250,200,223,118,25,98,241,246,207,221,67,125,9,42,151,172,177,159,239,34,155,134,122,123,109,93,229,61,40,83,233,129,63,2,71,180,200,128,114,96,119,218,165,118,131,116,46,159,143,125,216,245,234,21,249,251,238,113,175,168,70,67,112,44,29,58,48,197,78,56,120,90,177,191,116,93,65,230,64,143,92,23,30,128,100,234,221,23,89,234,125,89,30,224,89,71,7,182,113,173,210,107,33,107,170,227,35,88,166,67,86,211,145,84,239,88,203,71,135,65,140,253,3,46,28,180,191,102,7,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateBaseNotificationTextLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateBaseNotificationTextLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1e854a2a-8c1e-4794-9486-6d3d7913b64e"),
				Name = "BaseNotificationText",
				CreatedInPackageId = new Guid("8ded9bc0-26e3-4d8b-ab12-46857e761bcf"),
				CreatedInSchemaUId = new Guid("e57633a3-e0d1-4ae8-8223-b6634131fc48"),
				ModifiedInSchemaUId = new Guid("e57633a3-e0d1-4ae8-8223-b6634131fc48")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e57633a3-e0d1-4ae8-8223-b6634131fc48"));
		}

		#endregion

	}

	#endregion

}

