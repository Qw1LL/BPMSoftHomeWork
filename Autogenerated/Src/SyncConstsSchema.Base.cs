namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SyncConstsSchema

	/// <exclude/>
	public class SyncConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SyncConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SyncConstsSchema(SyncConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("46b057b7-14b5-4c05-b912-248362985d2b");
			Name = "SyncConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("912fb492-38c7-4dbe-88b2-46a261777d72");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,147,207,106,220,48,16,198,207,107,240,59,136,244,210,30,166,241,234,159,101,66,15,178,70,42,129,132,134,44,121,0,215,171,4,195,174,109,44,187,37,148,188,123,229,236,134,197,176,133,237,160,131,196,140,230,247,49,159,52,133,166,125,33,155,215,48,250,253,77,154,164,73,91,237,125,232,171,218,147,242,225,126,211,61,143,95,77,215,62,55,47,211,80,141,77,215,166,201,159,52,89,245,211,207,93,83,147,122,87,133,16,47,183,117,172,9,99,32,49,53,167,87,215,215,159,142,65,62,54,199,19,185,67,253,48,151,28,91,132,49,182,173,201,224,171,109,215,238,94,201,247,169,217,146,187,109,213,207,93,127,244,254,64,189,221,146,111,164,245,191,223,211,159,175,12,103,154,137,210,0,99,78,3,71,153,65,177,54,22,76,137,84,20,20,105,206,213,213,151,155,213,204,57,200,185,132,248,20,252,176,241,195,175,166,246,183,251,190,27,198,127,225,49,47,17,85,41,65,56,22,241,210,25,208,148,27,224,142,186,188,96,60,51,54,143,248,19,125,49,129,247,184,68,207,65,4,54,131,175,103,17,11,9,154,57,65,149,206,65,105,202,128,115,38,64,89,230,160,164,165,226,232,184,213,204,46,39,112,82,0,31,158,92,100,195,84,215,62,132,71,31,166,221,184,144,224,108,33,132,145,18,108,145,89,224,26,13,148,24,237,96,50,99,206,229,185,182,220,156,159,194,255,41,176,195,208,13,103,248,40,169,163,133,165,160,185,144,192,21,174,161,176,76,66,153,173,81,51,67,181,65,60,199,143,244,203,223,224,252,45,22,84,149,201,184,80,128,49,86,1,23,38,90,128,116,13,40,5,143,131,87,133,52,238,68,125,75,147,183,191,81,64,154,48,98,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("46b057b7-14b5-4c05-b912-248362985d2b"));
		}

		#endregion

	}

	#endregion

}

