namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityMLangBinderSchema

	/// <exclude/>
	public class OpportunityMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityMLangBinderSchema(OpportunityMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c44c1193-13fd-4b69-b47e-53e7dc114349");
			Name = "OpportunityMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0e987dc8-e3a7-4136-b3d3-af8a5676bbce");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,201,106,195,48,16,61,59,144,127,24,210,75,10,197,190,167,33,16,135,22,2,49,9,228,208,179,108,79,92,129,37,25,105,100,106,74,254,189,35,47,197,93,46,22,210,91,102,222,179,22,10,93,35,10,132,244,146,93,205,141,226,131,209,55,89,121,43,72,26,189,92,124,46,23,145,119,82,87,51,130,197,248,85,20,100,172,68,247,252,7,127,195,156,57,74,25,205,24,163,15,22,43,182,130,67,45,156,219,192,185,105,140,37,175,37,117,217,73,232,42,149,186,68,219,51,147,36,129,173,243,74,9,219,237,198,251,140,14,202,215,36,107,214,120,81,33,20,193,15,242,94,30,79,234,100,38,111,124,94,203,98,228,253,63,22,54,176,111,154,151,22,53,157,164,35,212,104,83,225,144,197,156,155,191,223,203,103,72,239,166,228,245,47,189,233,0,142,3,76,139,214,202,18,161,53,178,132,179,102,199,43,9,75,235,201,154,43,37,252,32,40,134,243,17,66,169,81,148,243,164,120,70,159,224,80,105,20,245,117,13,53,119,113,216,118,123,12,123,135,232,71,66,254,61,198,62,205,83,253,6,119,235,213,12,93,13,174,247,49,21,234,114,8,214,223,135,215,159,143,247,47,67,102,93,128,26,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c44c1193-13fd-4b69-b47e-53e7dc114349"));
		}

		#endregion

	}

	#endregion

}

