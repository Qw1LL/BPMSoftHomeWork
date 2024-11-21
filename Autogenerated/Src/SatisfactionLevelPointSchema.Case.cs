namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SatisfactionLevelPointSchema

	/// <exclude/>
	public class SatisfactionLevelPointSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SatisfactionLevelPointSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SatisfactionLevelPointSchema(SatisfactionLevelPointSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5f9c9fd0-00ee-4522-83fe-fc6de0e0459a");
			Name = "SatisfactionLevelPoint";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3c90037-274c-4793-841e-197eb228d3cd");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,193,106,195,48,12,134,207,14,228,29,4,189,55,247,181,244,176,92,55,40,228,9,52,87,14,134,88,14,150,82,24,165,239,62,187,46,91,90,232,97,62,24,36,255,255,255,73,152,49,144,204,104,9,222,143,159,67,116,186,237,35,59,63,46,9,213,71,110,155,75,219,64,62,155,68,99,174,161,159,80,4,222,96,200,207,226,208,22,209,7,157,105,58,70,207,218,54,85,221,117,29,236,101,9,1,211,247,225,175,85,205,54,178,162,103,74,224,98,2,89,5,193,92,66,4,144,79,89,21,2,229,98,187,74,236,30,35,231,229,107,242,22,236,45,117,120,49,144,201,11,24,243,52,80,109,220,20,16,29,144,168,15,168,148,169,40,148,137,119,195,138,103,204,157,86,44,213,120,129,145,116,7,82,174,107,217,252,5,166,175,155,128,198,127,129,68,147,231,241,215,253,68,51,149,184,33,62,213,159,105,155,235,15,195,178,61,21,204,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5f9c9fd0-00ee-4522-83fe-fc6de0e0459a"));
		}

		#endregion

	}

	#endregion

}

