namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: OpportunityManagementUtilsSchema

	/// <exclude/>
	public class OpportunityManagementUtilsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public OpportunityManagementUtilsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public OpportunityManagementUtilsSchema(OpportunityManagementUtilsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4fcdad74-69f0-4516-b611-2a2e42ad8a52");
			Name = "OpportunityManagementUtils";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f3263ef9-3aa8-474b-9e91-a704f3bef247");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,193,74,3,49,16,134,207,89,216,119,200,177,5,201,11,120,234,106,145,130,85,113,233,73,60,164,217,233,26,216,76,98,102,114,88,164,239,238,196,162,180,216,67,2,249,249,231,203,199,160,13,64,201,58,208,221,203,182,143,7,54,119,17,15,126,44,217,178,143,104,158,83,138,153,11,122,158,183,22,237,8,1,144,219,230,171,109,84,33,143,227,217,88,134,219,191,180,159,137,33,152,71,143,159,18,74,156,202,126,242,78,187,201,18,233,171,208,29,251,137,116,5,255,150,137,197,193,233,125,140,147,126,0,222,208,10,231,222,125,64,176,171,33,120,244,196,34,9,67,55,191,130,139,121,160,197,142,32,139,62,130,171,238,186,92,60,111,42,89,37,155,109,32,65,103,209,124,123,215,242,177,88,156,168,79,117,23,203,147,130,82,25,184,100,252,95,48,98,177,184,68,155,251,174,7,87,178,20,215,56,122,4,243,163,187,62,27,189,110,188,172,27,83,71,185,234,105,155,227,55,157,24,147,72,143,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4fcdad74-69f0-4516-b611-2a2e42ad8a52"));
		}

		#endregion

	}

	#endregion

}

