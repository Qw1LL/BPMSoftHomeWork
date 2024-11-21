namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ValidationResponseSchema

	/// <exclude/>
	public class ValidationResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValidationResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValidationResponseSchema(ValidationResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("95fa2455-4082-4b76-99b1-0a45dbb30c9d");
			Name = "ValidationResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,77,107,195,48,12,134,207,13,228,63,8,122,111,238,237,216,97,189,118,16,26,216,221,81,20,215,204,177,130,101,15,218,178,255,62,219,105,199,216,23,24,35,201,214,251,62,146,83,19,201,172,144,224,169,125,238,120,12,155,61,187,209,232,232,85,48,236,234,234,90,87,117,181,106,154,6,30,36,78,147,242,231,199,91,126,164,217,147,144,11,2,225,68,144,226,104,3,240,8,120,34,124,53,78,195,155,178,102,40,58,224,163,165,205,93,168,249,162,52,199,222,26,4,180,74,4,94,62,27,142,137,138,157,80,250,177,16,172,214,158,116,86,106,61,207,228,131,33,217,66,91,154,151,247,239,136,55,198,12,149,141,127,58,223,173,123,102,11,93,68,164,68,112,5,77,97,7,146,175,247,127,132,15,140,137,245,162,122,75,144,54,40,74,19,32,15,101,198,191,173,36,248,188,151,3,94,186,18,237,83,199,111,150,107,114,195,50,110,201,83,53,157,15,199,59,242,174,171,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("95fa2455-4082-4b76-99b1-0a45dbb30c9d"));
		}

		#endregion

	}

	#endregion

}

