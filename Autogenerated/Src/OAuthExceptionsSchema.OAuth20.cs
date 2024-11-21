namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OAuthExceptionsSchema

	/// <exclude/>
	public class OAuthExceptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OAuthExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OAuthExceptionsSchema(OAuthExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("fc203001-613e-494f-8857-3cb5ad94462e");
			Name = "OAuthExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("49af2168-effb-4b7f-bce2-28e45d430d96");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,213,83,205,107,194,48,20,63,43,248,63,4,188,40,72,59,118,116,99,224,100,7,15,99,162,199,177,67,140,175,109,160,77,74,146,162,110,248,191,239,53,245,107,141,31,195,181,108,187,180,125,233,203,239,35,47,63,65,19,208,41,101,64,30,199,207,83,25,24,111,40,69,192,195,76,81,195,165,240,94,6,153,137,110,111,90,205,143,86,179,145,105,46,66,50,93,105,3,201,93,169,246,38,153,48,60,1,111,10,138,211,152,191,219,253,216,133,125,109,5,33,22,100,24,83,173,251,196,98,78,64,203,76,49,120,90,50,72,243,86,219,233,251,62,185,215,89,146,80,181,122,216,212,187,14,98,34,37,23,130,44,34,30,3,81,27,0,252,8,57,42,80,168,197,219,66,248,7,24,175,59,69,179,24,222,112,33,205,102,49,103,132,229,106,78,136,33,253,61,45,238,64,243,248,220,251,144,66,27,149,49,35,21,218,25,91,184,162,195,146,115,17,33,163,153,75,230,231,252,91,190,227,76,157,46,201,143,182,177,190,26,0,165,228,99,192,57,106,26,66,23,165,207,168,134,206,174,174,20,190,119,48,14,46,4,168,93,89,38,238,57,255,15,133,180,65,204,139,211,60,123,180,74,26,96,6,230,231,212,111,123,78,25,248,114,33,71,34,144,40,44,144,61,50,53,10,104,130,222,144,211,192,210,16,86,188,187,57,106,163,177,113,83,244,110,127,157,244,176,89,43,217,58,119,241,71,98,24,115,16,230,234,0,48,187,157,208,52,197,233,89,115,85,70,193,145,87,123,36,28,198,142,157,196,85,215,215,197,186,144,146,218,152,126,16,152,178,166,218,51,227,122,169,50,59,23,236,124,59,64,133,198,65,154,254,177,228,184,186,106,139,140,75,117,69,86,142,128,84,29,146,139,20,255,33,29,67,215,196,47,199,98,253,9,49,230,118,144,182,9,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("fc203001-613e-494f-8857-3cb5ad94462e"));
		}

		#endregion

	}

	#endregion

}

