namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBulkDeduplicationTaskClientSchema

	/// <exclude/>
	public class IBulkDeduplicationTaskClientSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationTaskClientSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationTaskClientSchema(IBulkDeduplicationTaskClientSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fef75578-f348-4491-a5ba-51e5ae6801c5");
			Name = "IBulkDeduplicationTaskClient";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,229,147,77,79,195,48,12,134,207,155,180,255,96,141,11,72,168,189,179,49,180,47,161,30,64,211,134,196,57,91,221,17,173,77,170,196,153,54,161,253,119,220,180,221,7,3,6,103,46,85,237,248,177,223,216,177,18,25,218,92,44,16,6,147,167,153,78,40,24,106,149,200,165,51,130,164,86,193,8,99,151,167,114,225,173,86,243,189,213,108,56,43,213,18,78,14,198,169,176,36,23,193,72,103,66,126,130,130,23,97,87,157,159,185,87,156,247,115,89,148,38,35,22,100,131,41,139,210,202,34,115,76,94,25,92,114,52,68,138,208,36,44,246,14,162,129,75,87,39,185,138,50,195,84,162,34,207,132,97,8,93,235,178,76,152,109,175,178,39,70,175,101,140,22,4,88,36,208,9,196,199,25,128,56,133,133,76,40,177,196,140,19,65,134,244,166,99,27,64,157,48,60,202,152,187,57,147,32,107,81,23,52,53,184,119,252,61,19,230,29,83,36,35,113,205,210,10,13,96,73,144,179,48,223,2,163,146,182,160,120,76,32,84,204,213,98,220,120,51,168,217,40,41,161,88,51,174,52,1,110,164,37,11,6,201,25,197,46,151,166,251,224,147,27,148,158,92,24,145,249,148,247,237,178,220,51,255,183,123,227,67,233,160,27,250,168,175,33,175,169,100,162,131,188,51,164,210,211,59,233,208,241,125,25,169,99,10,232,172,147,51,31,245,0,143,72,223,156,93,91,110,35,63,178,195,53,110,161,114,237,69,222,116,126,53,7,126,134,78,164,165,188,127,51,7,83,173,221,165,73,212,235,89,140,162,239,27,117,22,242,135,81,236,202,37,71,21,151,123,94,152,187,15,208,156,37,183,153,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fef75578-f348-4491-a5ba-51e5ae6801c5"));
		}

		#endregion

	}

	#endregion

}

