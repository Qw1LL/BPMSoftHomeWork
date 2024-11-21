namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseServiceRequestSchema

	/// <exclude/>
	public class BaseServiceRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseServiceRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseServiceRequestSchema(BaseServiceRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("56f508aa-2354-4a52-b001-b51958e64e5c");
			Name = "BaseServiceRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,145,205,78,195,48,16,132,207,137,148,119,88,149,11,92,146,59,1,164,54,32,132,80,80,212,112,67,28,156,116,19,44,98,59,216,235,74,161,226,221,113,236,150,223,158,172,29,207,216,223,104,37,19,104,70,214,34,172,170,178,86,29,165,133,146,29,239,173,102,196,149,76,139,155,186,84,27,28,76,18,239,146,56,137,35,107,184,236,161,158,12,161,72,215,86,18,23,152,214,168,57,27,248,187,207,228,222,119,162,177,119,3,20,3,51,230,28,86,204,160,115,109,121,139,107,124,179,104,200,187,178,44,131,11,99,133,96,122,186,218,207,62,1,170,131,198,101,64,7,55,144,2,199,146,30,50,217,143,208,211,53,35,230,176,73,179,150,158,157,48,218,102,224,45,180,254,161,99,63,71,161,75,116,128,172,180,26,81,19,71,71,90,249,112,184,255,139,231,133,91,36,135,167,193,204,39,189,32,44,171,59,120,197,105,102,251,15,23,148,45,27,44,126,141,143,71,67,223,30,95,168,68,209,160,62,125,112,11,130,75,88,56,239,226,108,46,119,104,103,72,207,155,88,142,252,30,39,216,65,143,148,207,76,57,124,236,203,161,220,132,126,126,14,234,111,209,105,159,30,105,149,11,1,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("56f508aa-2354-4a52-b001-b51958e64e5c"));
		}

		#endregion

	}

	#endregion

}

