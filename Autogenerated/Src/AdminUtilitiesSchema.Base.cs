namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AdminUtilitiesSchema

	/// <exclude/>
	public class AdminUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AdminUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AdminUtilitiesSchema(AdminUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("170e19f8-c937-4f98-aec0-9d08e2acf0d5");
			Name = "AdminUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,82,203,110,219,48,16,60,211,128,255,129,208,137,58,152,144,208,34,105,16,244,16,89,114,96,160,45,2,219,105,14,69,15,140,180,118,8,80,164,202,135,91,163,200,191,135,15,183,138,157,28,164,149,134,187,51,187,179,116,134,203,29,94,31,140,133,254,122,58,113,241,183,186,251,186,86,91,75,231,170,239,149,124,7,214,240,46,72,235,202,227,211,137,100,61,152,129,181,240,234,84,110,249,206,105,102,185,146,211,201,223,233,4,13,238,81,240,22,27,235,177,22,183,130,25,131,111,186,158,203,123,203,5,183,28,140,79,10,137,103,153,26,88,167,164,56,224,91,199,59,92,195,118,174,132,235,229,138,239,158,236,23,216,131,88,118,248,51,150,240,59,38,144,172,40,46,23,197,199,166,153,149,139,166,156,213,139,178,156,93,93,150,213,172,40,202,250,162,104,174,62,124,154,95,100,249,53,66,40,104,189,213,139,50,183,96,87,74,217,212,159,228,118,217,145,123,3,218,143,37,161,13,51,97,119,242,155,227,216,57,90,131,240,0,54,41,164,182,18,70,206,10,232,70,13,164,204,105,154,134,100,203,46,203,233,66,171,158,100,126,59,255,133,61,24,137,209,195,19,104,56,61,219,28,6,248,206,132,3,159,180,52,205,47,199,4,73,116,193,127,99,73,145,231,244,70,122,79,238,152,6,233,39,18,16,101,150,230,155,19,130,228,152,153,99,119,126,141,94,35,109,152,236,153,198,221,99,243,7,90,103,149,246,83,156,182,78,27,105,156,134,186,26,33,146,255,51,224,132,131,89,182,242,219,131,192,145,44,161,137,21,18,76,70,149,145,0,241,45,38,99,41,13,225,21,63,66,26,172,211,231,11,240,87,49,216,225,129,61,104,235,203,234,42,90,179,81,241,86,140,124,63,130,211,63,243,52,48,66,207,41,30,67,124,167,239,163,74,168,166,77,63,216,67,172,8,103,254,121,126,1,122,196,158,151,71,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("170e19f8-c937-4f98-aec0-9d08e2acf0d5"));
		}

		#endregion

	}

	#endregion

}

