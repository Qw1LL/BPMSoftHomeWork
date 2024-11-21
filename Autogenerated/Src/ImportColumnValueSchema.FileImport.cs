namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportColumnValueSchema

	/// <exclude/>
	public class ImportColumnValueSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportColumnValueSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportColumnValueSchema(ImportColumnValueSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f8ae54ba-7ca1-412e-af1f-79f7b6e20f3d");
			Name = "ImportColumnValue";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,77,107,219,64,16,61,43,144,255,48,40,23,155,6,233,94,71,130,214,38,144,67,138,137,161,151,210,195,90,30,169,11,218,93,49,187,155,212,53,254,239,221,15,201,145,99,199,36,23,193,206,236,188,121,239,205,104,37,19,168,59,86,33,124,95,62,174,84,109,178,185,146,53,111,44,49,195,149,204,238,121,139,15,162,83,100,174,175,118,215,87,137,213,92,54,176,218,106,131,98,246,230,156,45,56,107,164,210,134,87,250,36,247,100,165,225,2,179,21,18,103,45,255,23,224,221,45,119,239,134,176,113,7,152,183,76,235,175,16,219,205,85,107,133,252,201,90,139,225,82,158,231,112,167,173,16,140,182,101,127,254,38,129,75,109,152,116,244,85,13,230,15,215,80,121,16,32,236,8,53,74,163,129,7,56,168,2,30,60,123,192,108,192,203,71,128,191,22,184,182,77,131,180,224,186,107,217,118,146,134,230,197,46,133,47,32,157,77,170,158,132,200,212,157,211,125,58,253,237,139,14,114,214,45,250,64,103,215,45,175,122,22,103,148,36,206,68,247,61,104,190,231,216,110,156,232,101,168,139,185,183,82,67,32,162,56,189,27,252,235,249,159,10,112,10,152,97,143,40,214,72,147,31,142,48,20,144,70,217,15,190,42,50,30,24,106,67,126,58,243,215,252,236,66,247,39,245,242,233,214,164,94,222,239,235,0,199,77,111,80,110,162,35,199,246,44,73,117,72,134,227,71,44,10,22,127,130,96,216,133,179,236,2,18,236,160,65,51,3,237,63,251,203,60,221,79,227,74,109,101,20,125,104,152,132,204,160,62,222,222,109,135,238,38,34,84,132,117,145,158,44,79,154,151,239,136,11,145,142,17,19,97,81,139,94,89,25,13,185,203,67,234,252,205,241,126,148,71,59,118,177,140,134,217,150,175,155,49,46,232,237,60,209,48,233,13,14,4,111,7,187,71,36,14,177,161,131,31,84,58,5,255,246,36,201,104,91,93,124,84,230,159,155,36,137,99,43,34,122,12,13,123,230,162,3,98,72,156,153,103,31,59,30,241,254,63,19,80,130,14,33,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f8ae54ba-7ca1-412e-af1f-79f7b6e20f3d"));
		}

		#endregion

	}

	#endregion

}

