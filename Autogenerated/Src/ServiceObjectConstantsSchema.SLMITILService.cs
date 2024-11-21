namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ServiceObjectConstantsSchema

	/// <exclude/>
	public class ServiceObjectConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceObjectConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceObjectConstantsSchema(ServiceObjectConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("87b3bcc1-054b-4d22-b62d-b3d765973e0c");
			Name = "ServiceObjectConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,91,75,195,48,20,128,159,45,244,63,132,237,69,31,98,239,151,205,11,232,4,241,65,28,204,63,144,156,156,140,202,154,150,38,85,134,248,223,77,59,187,141,49,193,203,33,33,57,247,15,206,105,117,161,150,100,177,214,6,203,11,215,113,29,197,74,212,53,3,36,183,243,199,69,37,205,249,172,82,178,88,182,13,51,69,165,92,231,221,117,78,198,13,46,173,66,102,43,166,245,148,44,176,121,45,0,159,248,11,130,177,225,218,48,101,180,141,179,199,243,60,114,169,219,178,100,205,250,250,75,31,15,178,253,237,76,86,134,44,111,47,173,110,249,170,0,98,43,27,251,64,215,247,251,182,29,226,142,113,112,76,201,188,47,210,57,187,123,72,54,160,145,99,76,211,65,219,102,238,211,29,224,221,183,133,232,250,26,6,230,121,93,227,131,32,87,68,225,91,239,56,29,241,144,49,145,8,73,153,76,128,198,97,194,41,131,16,104,40,131,72,228,121,224,179,44,24,157,245,211,248,43,229,111,64,111,0,170,86,29,3,141,18,95,164,82,100,20,242,216,130,70,224,83,142,144,210,216,15,130,20,56,159,136,144,255,31,244,231,164,119,88,179,198,148,120,20,150,167,28,131,40,204,169,204,164,160,113,14,9,157,248,89,68,227,44,102,81,146,103,233,196,143,122,216,205,244,199,168,196,102,67,172,246,177,217,213,125,155,53,125,2,107,136,32,73,28,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("87b3bcc1-054b-4d22-b62d-b3d765973e0c"));
		}

		#endregion

	}

	#endregion

}

