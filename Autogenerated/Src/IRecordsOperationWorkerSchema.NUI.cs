namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRecordsOperationWorkerSchema

	/// <exclude/>
	public class IRecordsOperationWorkerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordsOperationWorkerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordsOperationWorkerSchema(IRecordsOperationWorkerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("de0a68c6-78e9-4e0a-a753-aa946a7db874");
			Name = "IRecordsOperationWorker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,195,48,12,61,15,137,255,96,109,23,184,180,247,81,42,13,52,141,29,38,38,134,196,57,107,220,46,162,77,130,147,12,77,136,255,78,154,172,221,7,67,226,20,217,126,207,239,217,142,100,13,26,205,10,132,135,229,98,165,74,155,60,42,89,138,202,17,179,66,73,248,186,190,26,56,35,100,5,171,157,177,216,220,157,197,30,94,215,88,180,88,147,204,80,34,137,194,99,60,106,68,88,181,29,230,210,34,149,94,97,12,243,23,44,20,113,243,172,49,182,127,83,244,142,20,224,105,154,66,102,92,211,48,218,229,251,184,167,130,42,193,110,252,211,17,193,42,160,216,44,233,200,233,17,91,187,117,45,10,16,125,131,63,164,219,249,60,188,55,59,221,162,180,102,12,203,192,143,181,115,103,33,241,74,162,170,144,12,124,110,80,2,219,155,1,97,64,147,42,208,24,228,173,177,223,206,6,216,74,68,161,39,38,121,141,148,69,111,203,142,24,106,19,170,76,14,103,149,184,217,193,8,37,143,134,79,221,47,208,110,20,255,143,253,137,214,181,64,115,186,208,118,195,71,75,189,224,61,100,52,35,214,128,244,31,231,126,88,244,215,31,230,135,159,208,157,203,73,241,225,16,4,247,243,136,82,248,117,37,89,26,232,161,219,86,9,30,156,236,250,171,152,155,249,84,186,198,71,235,26,179,153,19,60,135,131,198,237,229,249,191,227,127,59,73,250,220,15,4,253,223,19,219,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("de0a68c6-78e9-4e0a-a753-aa946a7db874"));
		}

		#endregion

	}

	#endregion

}

