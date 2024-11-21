namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IntegrationListResponseSchema

	/// <exclude/>
	public class IntegrationListResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IntegrationListResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IntegrationListResponseSchema(IntegrationListResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("56543138-4c89-c211-d5b8-8f2545d3e89d");
			Name = "IntegrationListResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5eec482-a90e-42cc-86d3-ef2673139bae");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,143,205,106,195,48,16,132,207,49,248,29,22,122,183,239,113,200,161,46,132,64,74,77,221,23,80,229,181,187,32,75,70,43,39,132,208,119,239,250,39,169,211,159,139,196,142,70,179,223,88,213,34,119,74,35,60,22,207,165,171,67,146,59,91,83,211,123,21,200,217,164,116,154,148,57,160,170,118,104,227,232,18,71,171,158,201,54,80,158,57,96,43,110,99,80,15,86,78,196,129,158,116,22,71,226,122,240,216,136,10,185,81,204,107,216,219,128,205,148,121,32,14,175,178,84,190,224,104,77,211,20,54,220,183,173,242,231,237,60,231,198,245,21,248,217,6,79,111,47,112,162,240,1,100,107,231,219,49,7,92,45,227,45,22,140,228,38,215,184,116,145,215,245,239,134,52,232,129,228,63,16,88,195,93,85,209,67,225,221,145,42,244,223,176,43,233,47,231,173,156,56,58,244,129,80,26,22,227,150,233,253,103,163,81,216,97,96,112,30,120,184,255,2,255,77,126,69,31,72,55,11,242,237,178,6,195,5,26,12,217,16,156,193,231,76,136,182,154,32,199,121,82,239,69,209,190,0,42,64,243,163,254,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("56543138-4c89-c211-d5b8-8f2545d3e89d"));
		}

		#endregion

	}

	#endregion

}

