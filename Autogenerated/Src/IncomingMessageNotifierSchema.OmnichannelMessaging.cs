namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IncomingMessageNotifierSchema

	/// <exclude/>
	public class IncomingMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IncomingMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IncomingMessageNotifierSchema(IncomingMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bc6fbb0e-f49b-4d6a-b97a-206ce6b2a400");
			Name = "IncomingMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,84,77,75,3,49,16,61,111,193,255,48,216,203,246,96,246,238,23,216,74,69,176,42,22,79,226,33,102,103,219,192,110,178,36,217,74,17,255,187,147,205,166,106,117,11,130,136,183,205,206,204,155,247,222,76,162,120,133,182,230,2,97,124,59,155,235,194,177,137,86,133,92,52,134,59,169,21,187,169,148,20,75,174,20,150,108,134,214,242,133,84,139,189,193,203,222,32,105,44,125,194,124,109,29,86,84,85,150,40,124,137,101,23,168,208,72,113,180,201,121,135,54,200,166,92,56,109,36,90,138,83,198,208,224,130,170,96,82,114,107,15,225,82,9,93,81,77,232,133,215,218,201,66,162,105,83,179,44,131,99,219,84,21,55,235,211,238,124,135,181,65,139,202,89,16,30,225,64,117,21,80,104,3,225,64,12,74,73,44,137,149,5,254,164,27,7,10,159,161,10,45,88,68,206,62,64,63,156,99,193,155,210,141,165,202,169,62,117,235,26,117,145,94,246,208,27,141,30,169,168,110,158,74,41,2,143,62,33,64,18,123,53,38,222,214,141,35,83,137,101,78,150,220,26,185,226,14,91,11,146,58,28,192,58,154,143,128,43,210,117,188,13,120,213,137,61,141,18,227,143,206,242,100,136,42,15,77,186,115,156,1,77,207,153,198,207,135,250,206,219,22,62,222,53,235,225,157,142,160,229,157,108,119,131,147,214,231,221,28,211,145,223,147,228,117,55,179,25,186,165,110,205,104,61,14,193,118,106,82,45,105,217,92,174,201,120,131,197,201,254,15,246,152,245,141,98,31,50,191,5,113,162,43,45,115,56,203,243,72,250,203,30,196,192,182,225,125,206,48,2,75,183,115,63,250,240,183,210,238,176,210,43,252,61,117,1,239,31,9,188,246,177,245,134,96,186,65,233,106,163,178,168,136,222,14,228,98,9,253,86,196,7,5,164,250,114,203,34,74,18,147,216,125,157,211,165,141,134,4,35,188,19,223,238,125,247,239,243,85,120,125,3,247,126,77,177,169,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bc6fbb0e-f49b-4d6a-b97a-206ce6b2a400"));
		}

		#endregion

	}

	#endregion

}

