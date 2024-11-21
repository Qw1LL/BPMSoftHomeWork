namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFullPipelineDataRetrieverSchema

	/// <exclude/>
	public class IFullPipelineDataRetrieverSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFullPipelineDataRetrieverSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFullPipelineDataRetrieverSchema(IFullPipelineDataRetrieverSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bab0b7d8-fd3f-4488-b7c0-eec4053f33c3");
			Name = "IFullPipelineDataRetriever";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("eccc4091-3404-497f-94e5-8c10d0f3a0d7");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,146,77,110,194,48,16,133,215,32,113,135,81,216,180,155,120,79,67,22,109,105,149,5,82,4,189,128,73,38,193,146,99,71,99,155,42,170,184,123,77,76,32,80,149,141,37,207,207,167,247,158,173,120,131,166,229,5,194,107,190,222,234,202,198,111,90,85,162,118,196,173,208,106,54,253,153,77,39,206,8,85,195,182,51,22,27,223,151,18,139,83,211,196,159,168,144,68,241,50,155,250,169,57,97,237,171,144,41,139,84,121,228,2,178,15,39,101,46,90,148,66,225,59,183,124,131,150,4,30,144,250,13,198,24,36,198,53,13,167,46,61,223,115,210,7,81,162,1,49,96,64,87,64,97,143,75,168,60,17,218,51,18,74,207,140,7,18,27,161,90,183,147,162,24,65,30,73,153,120,147,254,188,56,88,163,221,235,210,44,32,239,41,161,121,47,182,47,12,144,139,144,191,74,66,165,229,196,27,80,62,237,101,52,168,95,41,43,108,23,242,54,81,250,181,199,171,49,236,123,80,140,31,195,196,9,235,57,87,172,207,197,145,50,233,245,81,78,105,37,6,17,10,194,106,25,141,93,111,244,119,196,210,132,13,75,39,74,182,82,174,65,226,59,137,201,221,108,10,227,152,158,254,155,28,187,72,47,6,110,188,61,135,15,50,153,163,42,67,196,253,253,24,190,205,77,241,248,11,172,202,143,248,145,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bab0b7d8-fd3f-4488-b7c0-eec4053f33c3"));
		}

		#endregion

	}

	#endregion

}

