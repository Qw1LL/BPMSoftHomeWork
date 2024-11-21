namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRecordOperationExecutorSchema

	/// <exclude/>
	public class IRecordOperationExecutorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordOperationExecutorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordOperationExecutorSchema(IRecordOperationExecutorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ca04445c-be77-4cfb-a8da-af3e457c1459");
			Name = "IRecordOperationExecutor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,203,110,194,48,16,60,131,196,63,172,224,210,94,226,59,165,28,90,113,224,128,64,237,23,184,201,58,172,84,219,145,189,70,141,170,254,123,253,72,34,10,234,193,178,118,118,102,60,187,54,82,163,239,100,141,240,114,58,188,91,197,213,171,53,138,218,224,36,147,53,240,189,152,207,130,39,211,94,245,29,86,59,195,196,132,254,105,49,143,132,149,195,54,145,247,134,209,169,104,182,134,253,27,214,214,53,199,14,139,209,238,11,235,192,214,101,190,16,2,54,62,104,45,93,191,29,234,73,11,86,1,159,227,53,74,1,7,45,168,120,92,246,173,70,23,113,101,211,133,143,79,170,129,38,167,255,66,64,156,42,242,167,220,7,228,179,109,252,26,78,217,161,52,111,67,102,160,56,160,191,73,152,130,97,90,73,159,130,221,39,43,72,39,157,212,96,226,198,159,151,196,168,151,219,188,198,254,110,226,106,35,50,55,75,47,150,154,241,221,135,65,144,212,143,101,247,179,21,154,166,204,145,235,159,242,35,127,192,136,253,2,248,70,87,184,232,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ca04445c-be77-4cfb-a8da-af3e457c1459"));
		}

		#endregion

	}

	#endregion

}

