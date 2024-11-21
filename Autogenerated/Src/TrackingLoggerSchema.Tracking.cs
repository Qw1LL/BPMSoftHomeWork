namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TrackingLoggerSchema

	/// <exclude/>
	public class TrackingLoggerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TrackingLoggerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TrackingLoggerSchema(TrackingLoggerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e1b4bc65-b177-4549-904d-d9ef71e207d9");
			Name = "TrackingLogger";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("874306e1-e314-437e-96bf-3f336a8aaf12");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,79,227,48,16,61,167,18,255,97,20,46,169,132,156,251,210,246,0,116,165,74,116,85,169,112,70,94,103,26,172,77,236,200,31,64,65,252,119,198,206,7,77,182,90,237,41,158,143,247,230,205,155,40,94,163,109,184,64,184,217,109,247,250,224,216,173,86,7,89,122,195,157,212,138,61,24,46,254,72,85,94,204,62,46,102,137,183,244,132,253,209,58,172,175,135,248,27,105,240,124,150,221,221,80,129,74,151,6,75,162,133,219,138,91,251,3,122,246,123,93,150,104,98,71,227,127,87,82,128,8,13,127,213,147,32,98,32,249,41,177,42,136,101,103,228,11,119,24,225,73,211,6,96,144,23,90,85,71,120,180,104,104,39,133,34,44,4,79,126,20,183,178,146,75,84,69,203,218,197,189,78,173,172,51,94,56,109,194,160,168,173,237,200,243,28,22,214,215,53,55,199,85,159,216,40,233,36,175,228,59,82,13,17,132,193,195,50,29,111,145,230,43,144,196,202,149,64,54,48,229,83,170,69,195,13,175,65,209,125,150,233,88,115,186,218,116,120,208,135,211,65,227,85,105,16,91,228,145,38,178,118,206,142,213,100,19,123,198,147,230,16,13,79,38,166,193,114,210,23,174,158,124,254,219,202,45,186,103,93,76,92,236,52,189,104,89,0,9,202,200,236,240,239,212,186,240,21,254,162,221,175,160,79,161,181,188,196,94,17,57,128,198,5,35,195,103,9,10,95,201,253,16,100,19,177,115,182,81,78,103,167,87,72,231,81,112,210,162,217,30,93,150,110,135,145,233,21,157,189,242,181,98,187,224,29,58,114,233,91,208,252,28,182,213,118,22,216,201,30,163,214,111,40,188,195,172,205,118,198,253,135,23,235,55,129,77,188,0,246,175,222,144,128,56,109,29,26,216,131,222,71,166,172,19,113,254,78,109,118,156,252,252,2,247,184,23,192,30,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e1b4bc65-b177-4549-904d-d9ef71e207d9"));
		}

		#endregion

	}

	#endregion

}

