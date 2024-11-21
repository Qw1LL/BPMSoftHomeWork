namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SecurityTokenCleanerSchema

	/// <exclude/>
	public class SecurityTokenCleanerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SecurityTokenCleanerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SecurityTokenCleanerSchema(SecurityTokenCleanerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0104f03c-a574-4da3-bbd9-fc323cbac58a");
			Name = "SecurityTokenCleaner";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,193,110,194,48,12,61,23,105,255,96,177,11,72,168,189,111,172,135,1,154,152,132,132,198,248,128,180,53,44,44,77,170,56,101,160,137,127,159,211,176,178,110,104,151,200,121,126,121,126,182,163,69,137,84,137,28,225,113,185,88,153,141,139,39,70,111,228,182,182,194,73,163,111,122,159,55,189,168,38,169,183,176,58,146,195,146,243,74,97,238,147,20,63,161,70,43,243,251,150,115,17,177,200,40,227,183,22,183,204,133,137,18,68,112,7,43,204,107,43,221,241,213,188,163,158,40,20,172,208,16,147,36,129,49,213,101,41,236,49,61,223,95,176,178,72,168,29,129,128,60,144,97,103,50,216,24,11,120,168,164,197,2,232,172,8,206,75,82,252,173,149,252,16,171,234,76,201,156,37,188,137,107,22,216,217,252,217,100,179,3,231,156,97,71,17,55,206,103,235,127,129,238,205,20,190,131,101,163,21,178,191,77,55,192,20,21,58,164,255,12,254,117,24,144,74,88,81,130,230,165,60,244,107,66,203,203,208,97,216,253,116,205,119,200,91,32,30,39,13,251,250,227,202,199,236,194,82,63,93,182,113,231,205,121,38,123,105,93,45,20,236,141,44,32,244,143,3,95,235,82,27,186,86,70,48,159,202,38,98,239,99,114,150,55,63,2,147,237,56,157,194,165,242,16,252,231,137,34,141,31,221,153,175,157,84,210,73,164,65,87,120,24,135,209,205,194,224,26,46,13,134,254,123,69,167,243,58,80,23,97,35,205,61,160,93,240,244,5,180,105,133,32,212,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0104f03c-a574-4da3-bbd9-fc323cbac58a"));
		}

		#endregion

	}

	#endregion

}

