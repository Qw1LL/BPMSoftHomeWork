namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CustomDataSourceBuilderSchema

	/// <exclude/>
	public class CustomDataSourceBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CustomDataSourceBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CustomDataSourceBuilderSchema(CustomDataSourceBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5fcfcb8d-bcb1-4131-9c48-d001a22ad833");
			Name = "CustomDataSourceBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b2e55c4-93df-4e50-a678-d373851bda85");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,84,219,106,2,49,16,125,86,240,31,130,125,217,5,217,15,80,43,212,75,161,15,22,81,250,84,250,16,227,168,129,53,145,92,108,75,233,191,119,178,145,238,213,85,139,125,89,200,100,206,153,57,103,38,43,232,14,244,158,50,32,195,217,116,33,215,38,26,73,177,230,27,171,168,225,82,68,115,216,75,101,184,216,68,143,84,27,127,154,136,13,23,16,141,172,54,114,215,106,126,181,154,13,171,49,229,10,138,94,5,70,65,117,20,97,204,72,197,65,151,239,83,238,49,53,116,33,173,98,16,61,44,181,81,136,193,226,14,130,160,59,5,27,60,145,81,76,181,238,18,223,121,138,24,90,30,175,64,37,169,175,99,88,83,27,155,33,23,43,228,13,204,231,30,228,58,120,42,101,135,29,242,140,230,145,123,210,246,124,237,240,13,241,123,187,140,57,35,204,85,58,85,136,116,73,41,214,247,82,210,120,206,196,190,103,170,205,113,225,65,39,91,19,98,96,102,128,77,225,136,240,155,218,128,198,24,101,157,171,232,198,44,233,216,103,28,187,63,209,119,240,162,65,33,88,32,173,227,177,185,99,232,8,26,93,178,164,26,130,145,2,106,242,253,205,148,60,112,199,82,128,97,203,73,178,43,119,73,142,151,53,249,72,102,44,85,144,191,100,91,216,209,244,178,192,19,18,183,173,141,239,163,31,32,86,222,146,188,63,83,48,91,185,114,214,40,126,64,226,163,55,254,64,180,65,57,140,100,54,162,82,230,141,6,58,32,117,86,214,15,196,139,109,40,48,86,9,34,224,157,212,214,251,237,252,210,222,138,238,246,50,222,86,185,85,40,144,217,209,170,21,184,86,91,74,122,98,139,58,73,90,250,19,74,165,101,65,115,208,50,62,32,56,60,171,167,176,137,255,247,132,235,182,191,206,136,82,242,89,69,44,247,124,110,188,195,85,15,244,239,83,62,243,212,179,82,11,15,221,71,243,65,140,253,0,55,124,235,206,12,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5fcfcb8d-bcb1-4131-9c48-d001a22ad833"));
		}

		#endregion

	}

	#endregion

}

