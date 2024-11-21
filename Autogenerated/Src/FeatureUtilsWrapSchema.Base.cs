namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FeatureUtilsWrapSchema

	/// <exclude/>
	public class FeatureUtilsWrapSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FeatureUtilsWrapSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FeatureUtilsWrapSchema(FeatureUtilsWrapSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("857989eb-d198-4858-9f7a-b2ad3d351897");
			Name = "FeatureUtilsWrap";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,145,63,107,195,48,16,197,103,7,242,29,68,178,216,80,236,61,253,3,77,90,151,12,129,64,9,29,74,7,89,58,59,2,85,50,39,105,8,37,223,189,39,59,45,46,78,41,52,139,64,119,239,126,122,239,100,248,59,184,150,11,96,203,237,230,217,214,62,95,89,83,171,38,32,247,202,154,233,228,99,58,73,130,83,166,25,8,16,174,207,86,243,146,11,111,81,129,163,62,41,230,8,13,65,216,74,115,231,22,172,4,238,3,194,206,43,237,94,144,183,157,230,245,1,106,30,180,95,42,35,137,151,250,67,11,182,78,215,3,177,242,68,204,178,55,82,183,161,210,74,48,17,129,35,30,91,176,209,24,205,80,2,58,191,205,108,192,239,173,36,59,219,142,213,55,139,162,96,55,202,236,1,149,151,150,30,64,168,111,103,35,90,254,4,126,237,78,213,71,195,43,13,50,221,57,64,90,154,1,17,55,118,197,156,71,10,146,205,138,187,72,62,57,174,172,213,236,239,105,22,196,23,128,9,43,33,99,113,255,73,130,64,51,177,123,214,65,167,140,95,146,28,47,142,83,90,188,55,135,232,234,178,96,191,114,254,21,113,64,27,133,157,131,145,253,223,118,247,190,250,179,120,252,4,34,159,83,122,231,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("857989eb-d198-4858-9f7a-b2ad3d351897"));
		}

		#endregion

	}

	#endregion

}

