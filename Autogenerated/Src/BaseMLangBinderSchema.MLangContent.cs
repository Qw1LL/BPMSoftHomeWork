namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseMLangBinderSchema

	/// <exclude/>
	public class BaseMLangBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseMLangBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseMLangBinderSchema(BaseMLangBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4367ba23-e656-4615-8c59-3352d06c36d8");
			Name = "BaseMLangBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("16e592d3-2033-426b-b620-6aa2b1f8eec0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,75,107,194,64,16,62,43,248,31,6,123,177,32,201,93,69,168,214,130,84,169,96,161,231,77,50,166,11,251,8,187,19,169,20,255,123,103,55,177,141,150,210,75,194,126,175,153,253,18,35,52,250,74,228,8,139,221,118,111,15,148,44,173,57,200,178,118,130,164,53,131,254,231,160,223,171,189,52,101,71,224,48,121,18,57,89,39,209,79,127,241,111,152,177,70,107,107,152,99,246,206,97,201,81,176,84,194,251,9,44,132,199,237,70,152,114,33,77,129,46,74,210,52,133,153,175,181,22,238,52,111,207,65,7,186,86,36,21,139,107,81,34,228,33,1,178,232,75,46,182,180,227,171,234,76,201,188,213,221,12,130,9,60,84,213,234,136,134,54,210,19,26,116,65,193,46,190,34,63,191,247,220,34,189,219,130,55,221,197,180,134,108,147,237,17,157,147,5,194,209,202,2,94,12,39,238,73,56,26,93,162,185,61,194,15,130,188,121,223,67,232,175,215,203,120,82,210,145,95,232,105,100,99,51,77,163,167,36,108,59,91,199,28,67,207,146,198,16,47,241,3,204,71,255,218,246,12,225,24,86,90,72,245,90,169,46,58,31,13,27,24,117,165,4,225,240,239,176,48,54,244,190,38,228,191,193,186,49,60,226,65,240,23,185,37,56,179,101,218,180,115,219,40,154,162,41,53,158,27,244,26,60,127,1,101,63,217,23,129,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4367ba23-e656-4615-8c59-3352d06c36d8"));
		}

		#endregion

	}

	#endregion

}

