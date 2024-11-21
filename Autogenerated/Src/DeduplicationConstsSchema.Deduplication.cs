namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DeduplicationConstsSchema

	/// <exclude/>
	public class DeduplicationConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DeduplicationConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DeduplicationConstsSchema(DeduplicationConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2f63d953-bd1e-490d-81f5-9a26e360c7c0");
			Name = "DeduplicationConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("a2cb4b0a-72d7-4fbf-b57c-bc3bae7898e7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,146,91,75,195,48,24,134,175,55,216,127,8,243,70,47,178,30,214,173,173,39,176,177,12,47,134,194,126,65,218,124,173,129,54,45,73,138,20,241,191,155,100,27,78,135,23,122,21,190,195,251,190,15,225,19,180,5,213,211,18,80,246,178,221,117,149,94,144,78,84,188,30,36,213,188,19,232,125,54,157,12,138,139,26,237,70,165,161,189,153,77,77,231,66,66,109,167,164,161,74,93,163,71,96,67,209,240,210,73,140,94,105,229,214,60,207,67,183,106,104,91,42,199,251,67,109,198,154,114,161,80,105,247,168,208,10,85,178,107,109,121,18,203,120,105,95,42,57,168,197,209,201,59,177,234,93,32,50,14,218,60,165,229,112,24,253,119,12,203,111,182,207,72,92,227,107,31,80,215,195,33,26,163,29,80,89,190,218,216,243,220,31,193,18,40,235,68,51,162,205,192,217,65,248,124,180,122,98,232,14,9,120,115,195,203,121,30,196,203,216,39,4,147,117,158,224,40,136,66,252,144,103,41,78,178,48,15,86,25,241,19,146,204,175,204,7,79,38,127,70,222,130,172,225,31,196,78,247,27,112,148,50,127,157,134,33,94,249,20,112,196,82,134,11,198,10,28,68,107,182,12,105,21,20,113,236,128,77,202,199,254,46,64,176,253,105,216,210,244,62,1,108,157,248,86,95,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2f63d953-bd1e-490d-81f5-9a26e360c7c0"));
		}

		#endregion

	}

	#endregion

}

