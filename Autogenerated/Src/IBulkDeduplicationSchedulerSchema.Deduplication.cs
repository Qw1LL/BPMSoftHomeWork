namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBulkDeduplicationSchedulerSchema

	/// <exclude/>
	public class IBulkDeduplicationSchedulerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBulkDeduplicationSchedulerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBulkDeduplicationSchedulerSchema(IBulkDeduplicationSchedulerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ddfb5587-be3e-400d-bba5-ff6929417fb9");
			Name = "IBulkDeduplicationScheduler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,147,77,79,195,48,12,134,207,155,180,255,96,109,23,184,180,247,49,118,24,187,12,105,104,98,220,81,218,186,109,160,77,170,36,5,77,136,255,142,147,44,107,247,5,92,162,218,177,95,63,126,149,10,86,163,110,88,138,176,216,172,183,50,55,209,131,20,57,47,90,197,12,151,34,90,98,214,54,21,79,93,52,26,126,141,134,131,137,194,130,2,88,9,131,42,167,214,41,188,174,22,109,245,126,84,187,69,166,210,114,155,150,148,172,80,141,134,212,25,199,49,204,116,91,215,76,237,230,251,248,25,27,133,26,133,209,192,64,135,114,200,165,130,154,9,86,112,81,64,144,69,13,218,201,194,155,76,116,20,20,227,158,100,211,38,84,10,60,176,193,5,178,142,105,64,251,208,121,88,105,141,166,148,153,158,194,198,201,248,203,83,106,151,8,34,150,250,34,30,124,114,83,218,149,26,76,121,206,49,131,134,41,50,155,184,44,248,57,185,207,184,34,16,84,120,63,238,116,195,180,204,187,186,9,74,227,249,75,137,157,48,200,28,12,37,130,141,23,200,172,175,150,78,27,166,12,121,27,205,98,215,238,8,62,36,207,14,155,249,81,143,50,185,89,254,201,209,27,116,173,228,246,238,23,55,151,88,81,77,255,5,92,49,53,217,29,89,186,191,177,77,53,115,174,253,215,91,223,242,68,223,222,195,115,165,131,85,153,133,179,255,194,153,85,30,187,51,74,27,101,159,107,167,29,150,158,160,200,252,19,115,241,183,59,251,73,202,252,0,126,57,202,139,138,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ddfb5587-be3e-400d-bba5-ff6929417fb9"));
		}

		#endregion

	}

	#endregion

}

