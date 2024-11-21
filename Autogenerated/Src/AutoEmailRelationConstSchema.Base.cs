namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AutoEmailRelationConstSchema

	/// <exclude/>
	public class AutoEmailRelationConstSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AutoEmailRelationConstSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AutoEmailRelationConstSchema(AutoEmailRelationConstSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2456833a-24e8-4599-9cc4-9e4102ad1dfd");
			Name = "AutoEmailRelationConst";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,139,219,48,16,134,207,27,200,127,16,187,151,246,48,203,140,190,44,179,244,224,56,78,233,161,108,105,218,31,160,72,114,106,176,101,19,219,20,83,246,191,87,77,123,74,191,12,58,72,175,102,230,225,157,153,104,187,48,14,214,5,182,251,240,254,216,215,211,99,217,199,186,57,207,23,59,53,125,124,44,230,169,175,58,219,180,31,67,123,85,182,155,111,219,205,221,60,54,241,204,142,203,56,133,238,41,189,211,121,184,132,115,250,103,101,107,199,145,253,150,151,202,142,211,118,147,2,135,249,212,54,142,141,83,210,29,115,255,12,191,251,1,187,201,184,4,235,251,216,46,236,237,220,120,86,117,67,219,47,33,188,243,236,13,139,225,235,85,125,117,175,49,19,162,58,148,112,16,122,7,36,9,161,48,70,0,233,189,17,101,177,195,220,224,253,235,167,255,85,127,158,47,101,223,13,54,46,159,150,225,150,161,50,73,252,80,236,65,137,74,195,254,64,4,121,70,59,64,164,189,198,42,23,166,212,43,24,201,234,100,221,116,116,95,66,103,63,223,48,72,159,130,208,138,192,212,129,131,36,149,131,241,30,193,26,20,94,106,35,188,23,43,24,133,115,253,28,255,194,224,202,103,142,236,9,200,7,4,169,144,224,36,145,3,242,128,65,217,140,123,29,214,251,72,253,234,230,216,184,235,24,255,12,68,148,54,39,78,192,169,54,32,45,5,48,57,165,155,114,88,103,74,7,43,105,189,169,21,64,67,78,10,169,9,80,83,14,82,122,15,6,179,100,51,227,105,132,6,141,114,191,38,245,114,93,209,135,16,253,207,117,222,110,94,190,3,195,178,13,233,35,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2456833a-24e8-4599-9cc4-9e4102ad1dfd"));
		}

		#endregion

	}

	#endregion

}

