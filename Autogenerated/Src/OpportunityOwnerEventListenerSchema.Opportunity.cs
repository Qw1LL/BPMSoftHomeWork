namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityOwnerEventListenerSchema

	/// <exclude/>
	public class OpportunityOwnerEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityOwnerEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityOwnerEventListenerSchema(OpportunityOwnerEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("45b2d596-38cb-494e-80ad-afc0697d9ae4");
			Name = "OpportunityOwnerEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1a637eec-ed5e-4e5a-93be-edcf08166986");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,61,79,195,48,16,157,83,169,255,225,20,22,88,236,189,180,12,173,186,245,3,41,35,98,48,233,37,88,138,237,200,103,131,44,196,127,231,156,82,90,32,130,193,195,187,123,239,238,221,179,85,6,169,87,53,194,242,126,91,185,38,136,149,179,141,110,163,87,65,59,59,157,188,77,39,69,36,109,91,168,18,5,52,183,95,248,44,240,56,94,21,107,27,116,208,72,255,180,197,250,5,109,200,44,230,93,121,108,121,51,172,58,69,52,131,13,170,195,254,213,162,31,56,27,205,30,24,12,76,41,37,204,41,26,163,124,186,251,196,39,2,184,6,92,150,1,143,218,247,189,243,33,90,29,18,240,16,29,146,56,201,229,15,253,156,16,85,71,14,106,143,205,162,252,203,174,88,42,194,161,150,190,121,43,65,230,105,15,35,173,235,170,126,70,163,118,28,58,44,160,188,240,85,222,60,178,166,143,79,157,174,161,206,167,95,186,254,29,0,204,224,188,126,44,159,34,127,92,193,239,253,152,42,218,195,49,216,12,185,246,1,188,247,77,154,249,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("45b2d596-38cb-494e-80ad-afc0697d9ae4"));
		}

		#endregion

	}

	#endregion

}

