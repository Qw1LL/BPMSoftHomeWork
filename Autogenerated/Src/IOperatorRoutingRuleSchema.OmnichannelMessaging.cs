namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IOperatorRoutingRuleSchema

	/// <exclude/>
	public class IOperatorRoutingRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOperatorRoutingRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOperatorRoutingRuleSchema(IOperatorRoutingRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e93c971a-debf-4f24-ad8f-d4b461191ae0");
			Name = "IOperatorRoutingRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("fe318069-3d3c-4328-afd6-b81d71766949");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,82,219,106,220,48,20,124,78,32,255,112,216,190,180,80,236,247,172,107,72,83,88,4,93,178,77,218,15,144,173,35,175,64,150,92,93,18,66,232,191,247,72,90,59,155,27,228,165,208,23,99,31,207,25,205,140,198,240,17,253,196,123,132,175,187,237,141,149,161,186,180,70,170,33,58,30,148,53,213,213,104,84,191,231,198,160,174,182,232,61,31,148,25,206,78,31,206,78,79,162,167,87,184,185,247,1,199,245,179,111,98,209,26,251,68,225,171,13,26,116,170,39,12,161,62,56,28,104,10,204,4,116,146,14,62,7,118,53,33,29,103,221,181,141,129,56,174,163,198,140,157,98,167,85,15,106,134,190,129,60,33,53,244,92,168,119,206,18,44,40,244,231,176,203,20,229,127,93,215,208,248,56,142,220,221,183,243,128,121,32,127,1,132,242,193,169,46,6,20,16,44,112,173,129,223,114,173,120,167,17,236,225,88,15,82,243,161,90,118,37,16,36,34,52,125,43,185,246,216,212,125,91,232,28,46,132,73,146,182,3,25,185,83,196,218,33,240,105,210,10,197,194,211,212,199,170,58,107,53,201,186,36,154,111,143,162,126,218,11,173,103,251,30,30,96,192,176,134,63,7,231,104,68,49,255,52,137,45,134,189,21,239,137,97,131,225,216,165,117,197,70,185,83,63,97,175,36,25,40,54,242,223,232,28,154,0,175,92,200,27,182,242,100,226,142,143,96,168,116,95,86,99,174,19,174,218,210,43,164,120,194,30,36,101,68,87,144,220,51,1,220,228,215,84,191,31,17,35,50,81,53,117,38,121,228,116,24,162,51,190,101,130,4,145,76,36,3,86,166,34,114,49,42,243,203,168,35,107,180,62,227,19,193,119,10,184,217,68,37,218,148,192,108,134,9,255,113,41,251,172,238,32,247,211,250,255,74,49,29,192,196,170,77,129,129,90,34,120,25,211,241,210,239,146,101,222,74,217,66,30,188,190,14,255,52,230,212,111,202,166,184,248,12,9,83,196,48,49,39,253,172,220,165,242,79,135,52,251,11,74,156,5,254,201,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e93c971a-debf-4f24-ad8f-d4b461191ae0"));
		}

		#endregion

	}

	#endregion

}

