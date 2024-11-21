namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityLanguageIteratorSchema

	/// <exclude/>
	public class OpportunityLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityLanguageIteratorSchema(OpportunityLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("561424eb-006b-4c14-a174-a6cb826ea99f");
			Name = "OpportunityLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0e987dc8-e3a7-4136-b3d3-af8a5676bbce");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,95,107,194,48,20,197,159,43,248,29,46,221,139,130,180,239,78,11,211,189,8,27,147,13,159,198,30,98,118,91,2,105,82,242,135,225,134,223,125,183,109,212,232,196,61,52,144,155,147,95,206,185,189,138,213,104,27,198,17,22,235,231,55,93,186,108,169,85,41,42,111,152,19,90,13,7,63,195,65,226,173,80,85,36,48,120,63,28,80,253,206,96,69,34,88,74,102,237,20,94,154,70,27,231,149,112,187,39,166,42,207,42,92,57,36,144,54,157,60,207,115,152,89,95,215,204,236,138,176,63,8,160,164,79,10,235,218,151,182,59,208,39,22,200,0,179,217,1,146,71,148,198,111,165,224,192,91,15,183,44,192,20,22,204,226,95,103,9,69,164,245,148,70,43,235,140,231,116,72,161,214,29,190,87,92,6,232,19,208,99,130,73,241,141,22,20,126,129,160,219,76,81,67,117,73,98,68,224,6,203,121,122,195,89,154,23,25,28,249,113,182,190,210,48,195,106,80,244,167,230,169,183,104,200,160,66,222,254,158,180,216,208,30,248,177,144,205,242,78,221,93,14,157,185,241,242,104,115,134,131,115,250,184,133,36,83,216,82,219,70,23,71,208,206,69,146,28,128,175,94,82,252,121,215,128,85,92,124,255,8,202,164,61,122,196,146,121,233,136,227,24,119,177,238,194,201,4,226,134,165,227,201,137,17,46,175,212,3,231,218,43,119,37,222,21,96,76,8,46,254,87,239,105,204,105,13,227,129,234,179,159,144,110,223,87,207,139,251,95,127,38,242,6,78,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("561424eb-006b-4c14-a174-a6cb826ea99f"));
		}

		#endregion

	}

	#endregion

}

