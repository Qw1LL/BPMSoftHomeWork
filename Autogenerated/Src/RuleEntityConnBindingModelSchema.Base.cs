namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RuleEntityConnBindingModelSchema

	/// <exclude/>
	public class RuleEntityConnBindingModelSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RuleEntityConnBindingModelSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RuleEntityConnBindingModelSchema(RuleEntityConnBindingModelSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("97585371-05d4-46c8-a8c6-2e53c1842cc8");
			Name = "RuleEntityConnBindingModel";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,84,203,78,195,48,16,60,167,82,255,97,5,215,202,249,0,10,82,41,15,245,128,132,8,124,128,107,111,90,11,199,174,252,0,42,196,191,179,137,147,42,133,150,55,82,14,177,189,59,51,59,235,181,225,21,250,21,23,8,167,215,87,133,45,3,155,90,83,170,69,116,60,40,107,216,36,6,123,94,113,165,111,80,55,59,195,193,243,112,144,69,175,204,2,138,181,15,88,29,209,154,190,67,135,11,58,135,169,230,222,195,77,212,120,110,130,10,107,194,51,167,202,72,74,184,178,18,117,138,206,243,28,198,62,86,21,119,235,147,169,213,177,50,30,230,41,204,143,32,122,148,16,44,148,74,107,224,82,170,154,154,107,208,202,7,176,37,184,86,141,103,227,188,67,233,80,29,210,242,222,119,235,11,235,0,159,120,181,210,56,2,69,169,164,44,225,142,61,34,8,135,229,241,193,68,4,245,64,98,217,68,8,27,77,56,200,79,64,52,170,128,27,185,29,217,4,176,107,167,106,86,170,46,112,209,196,43,223,192,162,28,181,204,97,137,102,63,83,47,179,101,122,84,97,9,219,184,240,192,117,68,214,2,206,12,97,18,77,91,206,46,216,26,238,110,38,9,139,104,231,91,33,251,91,194,110,185,91,96,72,135,133,88,146,129,132,65,80,93,37,159,232,255,11,194,116,7,62,160,221,244,229,110,118,246,77,182,194,70,39,240,125,121,117,111,247,82,237,232,240,95,48,247,235,100,59,174,236,42,206,181,18,32,62,159,162,122,14,183,231,168,219,72,238,246,37,246,21,180,29,99,155,244,254,4,117,252,151,81,201,22,231,141,111,208,240,102,116,80,15,126,150,249,246,231,101,56,248,161,160,100,201,111,100,109,76,253,64,92,150,237,149,151,186,244,123,191,138,93,247,236,63,36,125,215,177,247,194,190,228,88,106,233,33,26,153,222,246,225,224,229,21,248,150,179,246,48,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("97585371-05d4-46c8-a8c6-2e53c1842cc8"));
		}

		#endregion

	}

	#endregion

}

