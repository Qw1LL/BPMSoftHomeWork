namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DayTypeConstantsSchema

	/// <exclude/>
	public class DayTypeConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DayTypeConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DayTypeConstantsSchema(DayTypeConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e4a46baa-a9bf-4def-a556-bd42551ffe45");
			Name = "DayTypeConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e9cdff4a-a92d-4d26-906f-df90167f5485");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,143,95,107,131,48,20,197,159,43,248,29,66,247,178,61,100,218,180,137,201,254,129,154,116,236,97,80,232,96,207,153,166,69,90,163,152,200,144,177,239,190,104,235,40,221,203,26,114,239,205,61,28,248,157,104,89,42,83,203,76,129,100,245,186,174,54,246,54,173,244,166,216,182,141,180,69,165,125,239,203,247,38,173,41,244,22,172,59,99,85,121,239,123,78,9,130,0,60,152,182,44,101,211,61,29,247,171,241,28,94,125,31,157,193,137,181,110,63,246,69,6,140,117,128,12,100,123,105,12,224,178,123,235,106,229,208,78,214,214,56,91,207,253,131,25,57,125,221,141,192,97,254,186,79,81,103,172,231,182,200,193,123,213,236,28,238,37,7,143,64,171,207,65,188,158,138,48,37,132,196,28,198,152,9,184,32,8,67,202,4,129,88,132,201,50,194,60,230,40,158,222,28,254,254,191,84,151,198,82,106,39,116,126,22,43,140,104,202,146,153,128,108,62,67,112,49,23,75,152,80,22,66,129,17,163,60,33,136,162,104,136,53,249,246,61,119,127,0,156,209,71,245,206,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e4a46baa-a9bf-4def-a556-bd42551ffe45"));
		}

		#endregion

	}

	#endregion

}

