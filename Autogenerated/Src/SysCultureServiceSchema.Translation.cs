namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SysCultureServiceSchema

	/// <exclude/>
	public class SysCultureServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SysCultureServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SysCultureServiceSchema(SysCultureServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a4865d94-8357-4f78-a417-9cd6dcdf4fff");
			Name = "SysCultureService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0b3cc894-bd0d-4e1b-bb7d-87203708d013");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,193,78,227,48,16,61,7,137,127,24,149,75,145,186,201,157,5,36,218,21,104,87,234,82,81,42,14,213,30,220,100,82,44,18,59,120,236,84,209,138,127,223,177,157,150,66,89,56,206,243,155,55,51,111,198,74,212,72,141,200,17,198,179,233,92,151,54,157,104,85,202,181,51,194,74,173,142,143,254,30,31,37,142,164,90,195,188,35,139,245,247,119,113,58,71,211,202,28,167,186,192,234,211,199,244,42,183,178,13,178,159,243,30,112,245,74,216,182,197,32,183,86,215,33,153,95,79,12,174,89,9,38,149,32,58,243,58,19,87,89,103,176,151,10,164,44,203,224,156,92,93,11,211,93,246,241,204,232,86,22,72,176,193,213,55,138,100,40,181,129,141,54,79,176,145,246,17,74,20,94,137,210,173,68,182,167,177,236,11,176,79,214,136,220,254,241,216,21,53,191,209,114,127,13,207,183,146,149,180,221,29,62,59,105,176,70,101,105,184,31,248,33,225,2,190,72,241,172,180,7,138,83,95,164,113,171,74,230,144,251,129,15,231,133,51,24,11,122,157,62,241,139,219,185,52,69,251,168,11,246,105,22,68,130,57,7,238,4,224,14,89,84,17,20,88,10,46,0,121,172,2,78,201,103,135,108,156,178,178,148,104,188,55,135,230,68,196,68,141,203,31,95,105,156,103,91,170,207,93,222,54,24,207,110,223,219,100,201,171,255,169,90,253,132,195,56,6,155,55,152,221,206,239,7,35,88,24,121,143,117,83,9,235,45,29,220,160,237,107,246,230,48,101,172,139,110,110,187,202,19,88,105,138,68,98,141,59,52,125,48,162,105,176,24,249,82,137,55,28,201,94,107,83,11,251,38,225,58,64,233,47,210,106,196,38,81,163,21,245,224,255,120,97,107,219,181,221,56,89,192,65,127,195,83,8,123,74,90,97,128,118,59,93,88,127,15,146,143,244,2,20,110,246,182,189,123,25,46,248,118,217,39,133,252,171,184,150,255,49,73,18,237,252,72,41,253,160,118,200,121,137,199,112,130,170,136,199,18,226,136,190,5,95,254,1,235,133,232,121,45,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a4865d94-8357-4f78-a417-9cd6dcdf4fff"));
		}

		#endregion

	}

	#endregion

}

