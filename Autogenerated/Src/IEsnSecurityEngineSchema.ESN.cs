namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEsnSecurityEngineSchema

	/// <exclude/>
	public class IEsnSecurityEngineSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEsnSecurityEngineSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEsnSecurityEngineSchema(IEsnSecurityEngineSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9c30106-e300-4bc7-ad30-d1a26877b5c8");
			Name = "IEsnSecurityEngine";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,221,85,193,74,195,64,16,61,183,208,127,24,234,69,65,154,187,214,130,198,32,61,84,138,193,15,216,110,166,201,210,238,110,216,217,180,20,241,223,157,77,82,177,182,138,80,133,226,37,236,60,102,230,189,121,179,100,141,208,72,165,144,8,119,211,73,106,231,126,16,91,51,87,121,229,132,87,214,12,146,244,177,215,125,233,117,59,21,41,147,67,186,33,143,250,186,215,101,228,204,97,206,41,0,99,227,209,205,185,199,21,140,19,50,41,202,202,41,191,73,76,174,12,214,169,81,20,193,144,42,173,133,219,140,218,120,234,236,74,101,72,160,209,23,54,35,152,91,7,178,64,185,8,68,37,58,173,136,66,127,111,1,3,67,233,20,33,144,149,74,44,193,160,95,91,183,224,98,34,145,35,13,182,44,209,7,154,178,154,45,149,4,181,213,119,80,94,39,76,183,167,176,6,226,160,6,214,5,11,68,7,252,129,138,248,80,8,2,33,37,51,7,109,14,37,170,21,6,141,220,117,71,208,190,162,6,41,133,19,26,12,91,127,211,39,30,89,139,231,113,214,31,165,245,113,219,1,24,27,12,163,58,247,112,105,195,24,42,147,29,110,80,187,133,51,107,151,16,11,243,132,34,107,50,39,77,226,249,67,165,50,120,87,112,9,117,188,109,123,193,107,238,116,142,51,167,180,228,195,58,91,101,39,104,74,236,80,120,252,177,33,191,99,135,180,90,115,215,147,181,35,110,244,253,181,29,152,169,19,189,29,123,133,109,222,109,197,255,42,23,234,219,27,3,162,70,190,178,51,225,9,167,188,244,239,157,108,195,79,28,199,251,155,225,18,255,185,193,247,97,68,60,210,226,215,230,61,67,147,53,79,90,175,203,200,27,155,168,163,41,26,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9c30106-e300-4bc7-ad30-d1a26877b5c8"));
		}

		#endregion

	}

	#endregion

}

