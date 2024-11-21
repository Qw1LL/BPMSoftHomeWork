namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GetAvailableProvidersRequestSchema

	/// <exclude/>
	public class GetAvailableProvidersRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetAvailableProvidersRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetAvailableProvidersRequestSchema(GetAvailableProvidersRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7d23b130-a0c9-4a16-9005-a52b09ec2d91");
			Name = "GetAvailableProvidersRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fc1a2769-1cc9-44d3-a1a6-003d1b8450f5");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,49,79,195,48,16,133,231,86,234,127,56,149,5,150,100,167,128,84,10,66,8,21,69,205,136,24,174,233,53,88,196,118,184,187,84,10,85,255,59,118,210,32,10,3,139,237,123,62,63,127,207,118,104,73,106,44,8,110,179,101,238,183,154,44,188,219,154,178,97,84,227,93,178,184,207,151,126,67,149,76,198,251,201,120,212,136,113,37,228,173,40,217,100,213,56,53,150,146,156,216,96,101,62,187,19,179,201,56,244,157,49,149,161,128,69,133,34,151,240,64,58,223,161,169,112,93,81,198,126,103,54,196,178,162,143,134,68,187,254,52,77,225,74,26,107,145,219,155,99,189,162,154,73,200,169,0,247,173,160,30,74,82,192,193,11,108,88,68,162,122,48,77,6,179,244,135,219,203,29,42,134,92,202,88,232,107,16,234,102,93,153,2,138,72,247,15,220,40,196,14,227,119,162,208,81,19,171,161,16,43,235,108,250,253,223,9,58,33,88,11,120,6,137,179,190,17,204,179,71,120,167,54,82,254,197,236,57,151,100,215,196,231,207,225,99,224,26,166,88,155,39,106,167,23,17,123,224,22,229,24,122,222,109,193,62,190,201,44,222,49,131,195,17,150,220,166,231,237,234,94,61,21,15,95,132,78,136,173,250,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7d23b130-a0c9-4a16-9005-a52b09ec2d91"));
		}

		#endregion

	}

	#endregion

}

