namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkEmailContextSchema

	/// <exclude/>
	public class BulkEmailContextSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkEmailContextSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkEmailContextSchema(BulkEmailContextSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("20559898-5818-4bc5-ac24-30a5cda72c44");
			Name = "BulkEmailContext";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,79,107,194,64,16,197,207,10,126,135,65,239,201,189,182,130,6,41,57,8,161,161,167,210,195,186,153,164,67,147,221,176,127,74,69,250,221,59,73,140,85,137,214,203,146,153,188,183,191,183,179,171,68,133,182,22,18,97,149,108,82,157,187,32,210,42,167,194,27,225,72,171,201,120,63,25,143,188,37,85,64,186,179,14,171,249,177,30,52,4,209,58,29,146,24,228,46,247,103,6,11,150,65,84,10,107,31,96,229,203,207,117,37,168,228,77,28,126,187,86,19,134,33,60,90,95,85,194,236,22,135,58,86,185,54,85,139,0,177,213,222,193,150,173,128,141,183,183,132,39,158,218,111,75,146,32,27,204,0,101,196,199,226,245,24,39,49,186,70,227,8,57,83,210,90,187,255,151,81,14,89,172,19,138,71,166,115,112,31,200,2,68,144,6,243,167,233,233,129,131,87,139,134,137,10,101,19,123,26,46,192,237,106,12,142,251,158,230,237,3,159,123,46,203,61,20,232,230,96,155,229,231,102,66,103,116,230,37,90,88,38,49,240,232,120,224,218,103,208,78,1,82,52,95,36,255,73,18,243,77,46,107,234,197,205,231,189,248,72,151,229,33,49,143,136,31,152,21,5,2,101,22,72,157,223,219,117,252,179,167,236,237,29,54,157,57,102,239,253,116,175,92,3,254,35,129,65,73,53,161,114,246,38,148,216,248,210,75,187,125,6,168,51,84,89,247,110,218,186,235,158,55,185,247,11,73,233,135,226,90,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("20559898-5818-4bc5-ac24-30a5cda72c44"));
		}

		#endregion

	}

	#endregion

}

