namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TriggerEmailQueueJobDispatcherSchema

	/// <exclude/>
	public class TriggerEmailQueueJobDispatcherSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TriggerEmailQueueJobDispatcherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TriggerEmailQueueJobDispatcherSchema(TriggerEmailQueueJobDispatcherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a0d4e234-cd3d-0785-1103-1944273b2e8b");
			Name = "TriggerEmailQueueJobDispatcher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("8ded9bc0-26e3-4d8b-ab12-46857e761bcf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,83,77,107,219,64,16,61,43,144,255,48,144,75,2,70,162,87,213,53,196,169,9,46,85,113,81,66,15,165,7,73,59,150,151,172,118,213,217,93,27,81,242,223,59,210,218,170,157,196,45,212,7,99,207,188,249,120,111,222,234,162,65,219,22,21,194,124,149,229,102,237,226,59,163,215,178,246,84,56,105,244,229,197,175,203,139,200,91,169,107,200,59,235,176,225,188,82,88,245,73,27,223,163,70,146,213,251,17,243,167,9,97,156,87,27,20,94,33,189,206,127,195,146,49,77,99,52,231,56,123,69,88,115,71,184,83,133,181,41,60,144,172,107,164,69,83,72,245,213,163,199,79,166,252,40,121,79,199,45,105,168,72,146,4,166,214,55,77,65,221,108,255,63,71,218,162,133,210,171,39,192,190,22,126,246,197,176,147,110,3,204,211,22,53,167,215,134,192,133,1,40,2,206,198,135,142,201,81,203,214,151,74,86,80,245,59,253,99,37,72,97,94,88,156,243,228,51,136,9,44,111,219,118,177,69,237,62,75,22,146,133,227,17,172,46,127,143,244,87,100,90,36,39,145,53,224,223,142,117,70,17,32,195,118,82,115,39,233,132,169,146,126,193,168,61,96,192,108,145,72,10,132,229,66,251,6,169,40,21,78,79,215,201,130,0,15,93,139,51,184,85,202,236,80,28,197,44,124,24,122,70,26,119,112,182,242,251,15,232,29,193,159,179,144,56,71,45,142,229,26,240,207,225,208,209,21,39,3,219,83,234,25,186,141,17,255,207,123,107,164,128,131,227,88,249,107,203,55,102,199,237,12,61,13,6,255,194,78,159,192,62,234,45,82,31,184,217,179,225,211,140,110,29,125,155,73,237,29,170,142,187,77,255,126,254,217,117,208,132,131,247,100,124,27,102,189,24,125,152,57,1,190,177,52,98,169,195,0,230,252,110,18,234,165,13,143,236,145,161,41,155,212,247,27,31,246,74,71,122,180,135,55,210,174,37,225,82,51,43,63,60,201,20,142,153,100,175,242,113,206,230,118,43,195,190,238,110,250,103,25,61,191,121,150,16,61,13,114,236,55,24,178,180,47,46,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a0d4e234-cd3d-0785-1103-1944273b2e8b"));
		}

		#endregion

	}

	#endregion

}

