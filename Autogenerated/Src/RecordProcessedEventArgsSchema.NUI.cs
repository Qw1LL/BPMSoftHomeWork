namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RecordProcessedEventArgsSchema

	/// <exclude/>
	public class RecordProcessedEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordProcessedEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordProcessedEventArgsSchema(RecordProcessedEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("55febf69-27f8-44d0-b988-9700d6626862");
			Name = "RecordProcessedEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,77,106,195,48,16,133,215,49,248,14,3,217,199,251,164,20,218,16,66,23,5,211,208,3,168,210,200,29,176,36,87,35,133,134,208,187,87,146,147,58,253,203,70,140,158,70,239,125,51,86,24,228,65,72,132,251,246,113,231,116,88,172,157,213,212,69,47,2,57,11,199,186,154,69,38,219,193,238,192,1,205,170,174,146,50,247,216,229,215,117,47,152,151,240,132,210,121,213,122,39,145,25,213,102,143,54,220,249,142,75,111,211,52,112,195,209,24,225,15,183,167,123,106,221,147,66,6,161,20,229,28,209,3,89,237,188,25,83,83,5,225,21,127,26,3,102,231,197,217,180,185,112,29,226,75,79,18,100,6,250,151,7,150,48,213,121,178,175,65,82,239,128,62,16,166,105,218,98,85,216,127,193,207,178,176,121,151,56,20,78,167,193,151,44,24,198,176,180,168,140,87,218,190,241,157,1,167,191,83,117,132,14,195,10,56,31,31,87,114,159,45,189,69,132,180,56,27,72,19,122,158,0,174,167,110,35,169,211,86,30,212,95,121,115,180,106,92,69,186,141,218,165,84,87,73,251,4,38,31,43,250,43,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("55febf69-27f8-44d0-b988-9700d6626862"));
		}

		#endregion

	}

	#endregion

}

