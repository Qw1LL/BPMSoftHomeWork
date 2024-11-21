namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SenderValidationInfoSchema

	/// <exclude/>
	public class SenderValidationInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SenderValidationInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SenderValidationInfoSchema(SenderValidationInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f6ab86a0-e08a-4fdf-9955-a869f72bbafb");
			Name = "SenderValidationInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,84,77,107,195,48,12,61,39,144,255,32,232,61,189,175,165,135,149,82,6,235,8,203,216,206,89,162,100,6,199,14,150,211,81,202,254,251,100,39,203,186,245,187,151,24,203,210,211,123,210,35,42,171,145,154,44,71,184,79,86,169,46,109,60,215,170,20,85,107,50,43,180,138,231,139,116,165,11,148,20,133,219,40,12,90,18,170,130,116,67,22,107,206,148,18,115,151,70,241,18,21,26,145,79,162,144,179,70,6,43,142,194,92,102,68,119,144,162,42,208,188,102,82,20,30,244,65,149,218,231,141,199,99,152,82,91,215,153,217,204,250,251,51,54,6,9,149,37,224,179,97,108,132,82,27,32,15,2,235,1,37,254,1,24,239,32,52,237,187,20,57,228,174,241,145,190,1,235,224,239,64,50,49,186,65,99,5,50,211,196,151,119,239,255,201,249,192,18,153,151,103,195,167,253,64,248,52,154,7,130,117,38,36,129,20,100,29,173,125,94,93,132,201,183,56,92,95,206,148,255,102,247,170,30,249,125,74,214,240,10,102,240,230,42,23,190,208,197,97,11,21,218,137,35,54,129,175,107,20,244,19,197,226,118,21,231,32,78,43,233,23,132,197,105,53,35,222,102,183,50,127,239,162,187,193,96,223,121,188,219,181,96,15,116,78,240,248,151,24,175,247,90,47,166,115,159,115,58,11,92,164,201,121,227,29,108,123,137,239,130,224,242,189,73,55,39,93,254,37,123,100,111,135,198,190,67,142,254,207,251,26,30,60,17,80,252,23,57,221,186,235,58,76,230,137,11,110,90,114,20,114,236,27,127,239,81,234,181,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f6ab86a0-e08a-4fdf-9955-a869f72bbafb"));
		}

		#endregion

	}

	#endregion

}

