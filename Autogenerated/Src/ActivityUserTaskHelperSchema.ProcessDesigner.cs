namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ActivityUserTaskHelperSchema

	/// <exclude/>
	public class ActivityUserTaskHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ActivityUserTaskHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ActivityUserTaskHelperSchema(ActivityUserTaskHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("64a98983-9363-4df0-9a04-3cf2dd6cddc8");
			Name = "ActivityUserTaskHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3949d191-f356-45da-a437-95abb1839b71");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,219,106,219,64,16,125,86,32,255,48,113,95,108,48,210,123,18,27,18,147,164,133,38,24,220,246,125,43,141,236,37,123,17,123,49,21,165,255,158,217,93,73,182,106,59,96,22,207,229,156,57,115,52,138,73,180,13,43,17,30,215,175,27,93,187,124,165,85,205,183,222,48,199,181,186,190,250,123,125,149,121,203,213,22,54,173,117,40,239,134,248,0,144,82,171,115,121,131,249,147,114,220,113,180,84,166,134,47,6,183,196,10,43,193,172,189,133,135,210,241,61,119,237,79,139,230,7,179,239,95,81,52,104,168,143,126,69,81,192,189,245,82,50,211,46,187,120,109,244,158,87,104,129,249,63,92,112,170,128,68,183,211,149,133,90,27,112,59,4,214,81,130,39,78,112,68,154,247,100,197,17,91,227,127,11,94,130,117,180,101,9,101,144,115,89,13,89,64,239,32,254,53,141,188,133,117,36,73,197,255,229,198,196,51,23,194,66,169,133,151,10,246,76,120,4,93,71,153,24,108,105,131,180,83,109,41,211,48,195,36,40,250,60,139,73,234,158,44,163,153,109,126,95,196,226,249,222,52,237,141,254,79,150,171,52,57,20,62,7,69,109,67,127,140,70,128,177,93,123,205,43,216,52,88,242,186,237,77,251,174,245,187,111,18,193,175,128,159,38,177,221,166,115,194,154,112,28,7,121,115,120,241,196,19,135,205,32,156,89,150,241,26,166,105,250,55,251,36,27,215,78,103,125,41,51,232,188,137,103,150,101,255,226,155,38,108,202,29,74,54,124,248,46,92,244,22,167,248,238,4,144,164,210,43,144,144,90,117,202,44,33,199,84,116,199,177,112,137,162,27,52,74,45,122,182,252,153,171,234,177,13,251,78,15,171,207,18,87,216,246,12,248,102,1,202,11,49,44,222,47,130,238,216,222,83,224,188,243,242,200,34,122,226,229,162,170,210,241,198,56,101,199,73,202,125,0,154,46,163,75,11,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("64a98983-9363-4df0-9a04-3cf2dd6cddc8"));
		}

		#endregion

	}

	#endregion

}

