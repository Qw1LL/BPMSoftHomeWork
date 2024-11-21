namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: QueueEntityEventAsyncOperationArgsSchema

	/// <exclude/>
	public class QueueEntityEventAsyncOperationArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public QueueEntityEventAsyncOperationArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public QueueEntityEventAsyncOperationArgsSchema(QueueEntityEventAsyncOperationArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1ee00480-4744-4349-9314-bc0a08994574");
			Name = "QueueEntityEventAsyncOperationArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("64ebcdcc-1a9c-4eb3-9403-16c8221d18f7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,111,107,194,48,16,198,95,87,240,59,28,238,141,131,209,190,87,39,56,17,17,54,230,240,19,196,120,237,2,109,42,185,100,32,195,239,190,75,82,255,212,49,149,189,104,107,146,231,238,126,247,92,212,162,66,218,10,137,240,178,124,91,213,185,77,167,181,206,85,225,140,176,170,214,221,206,119,183,147,56,82,186,128,213,142,44,86,195,139,53,235,203,18,165,23,83,58,71,141,70,201,147,230,148,212,96,58,211,86,89,133,116,227,56,157,208,78,203,247,45,70,4,47,231,128,7,131,5,175,96,90,10,162,1,124,56,116,24,34,118,179,47,212,182,29,51,49,5,133,168,44,203,96,68,174,170,132,217,141,155,117,200,0,6,183,6,137,35,137,5,136,32,13,230,207,189,171,25,123,217,24,148,254,228,14,109,109,32,231,199,17,242,206,121,130,192,181,96,95,40,36,121,85,236,17,123,194,161,233,1,39,59,227,217,186,117,169,36,200,128,116,187,39,24,192,141,158,19,158,23,191,79,118,177,129,214,56,201,196,236,218,50,148,139,138,166,244,237,162,253,120,10,24,62,79,16,101,158,6,15,191,30,25,108,45,8,251,7,205,217,137,191,64,201,190,161,66,189,137,96,109,202,165,169,185,162,31,126,155,241,114,124,205,70,219,237,56,22,178,66,243,45,150,199,219,232,253,254,109,248,161,237,197,76,187,138,155,92,151,56,138,253,141,163,21,20,129,147,2,237,16,136,95,71,252,123,128,98,170,22,145,184,131,134,71,228,255,14,147,32,253,19,224,95,229,189,177,97,148,160,54,126,58,185,66,115,29,102,238,212,6,142,55,96,177,185,194,115,49,207,184,219,222,220,255,0,255,112,213,68,98,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1ee00480-4744-4349-9314-bc0a08994574"));
		}

		#endregion

	}

	#endregion

}

