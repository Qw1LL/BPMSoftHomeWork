namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MatchesFoundUtilitiesSchema

	/// <exclude/>
	public class MatchesFoundUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MatchesFoundUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MatchesFoundUtilitiesSchema(MatchesFoundUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e78d9172-c1ff-4b6b-b8de-32a4d56c58f1");
			Name = "MatchesFoundUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,83,193,78,196,32,16,61,211,164,255,64,178,119,63,192,61,185,53,107,76,172,54,65,79,198,3,133,105,119,18,10,13,208,195,106,252,119,41,212,221,172,198,72,111,195,99,222,188,55,195,160,249,0,110,228,2,232,174,169,153,233,252,85,101,116,135,253,100,185,71,163,203,226,163,44,202,130,76,14,117,79,217,209,121,24,182,17,217,88,232,67,2,173,20,119,238,154,214,220,139,3,184,189,153,180,140,247,175,12,44,114,133,239,188,85,240,22,128,113,106,21,10,42,230,252,31,233,36,137,156,106,54,214,140,96,61,66,40,220,68,90,186,95,74,220,77,40,233,189,12,36,66,72,15,126,27,3,183,4,159,23,185,183,220,195,51,14,64,43,11,33,148,79,58,139,22,37,22,202,238,152,169,229,188,157,167,116,162,61,134,217,174,51,89,27,137,29,174,115,249,205,89,107,243,204,203,246,137,218,207,111,35,192,185,7,12,171,160,193,186,191,137,132,252,22,101,70,132,165,184,17,34,60,188,207,239,49,209,106,144,200,215,53,201,206,196,236,46,91,99,20,101,224,247,198,134,191,224,185,200,51,186,40,166,125,13,83,234,80,193,139,85,235,221,254,215,225,6,180,76,31,37,158,19,122,9,6,236,11,113,238,29,155,217,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e78d9172-c1ff-4b6b-b8de-32a4d56c58f1"));
		}

		#endregion

	}

	#endregion

}

