namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CustomDataSelectSchema

	/// <exclude/>
	public class CustomDataSelectSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CustomDataSelectSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CustomDataSelectSchema(CustomDataSelectSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d8e6aa3a-8514-4021-adab-1ac712c5737b");
			Name = "CustomDataSelect";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b2e55c4-93df-4e50-a678-d373851bda85");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,81,203,78,195,48,16,60,167,82,255,97,37,46,32,85,249,128,22,144,32,5,212,3,16,53,95,224,58,219,96,148,216,209,218,65,138,42,254,157,117,28,242,40,61,112,137,228,217,217,153,157,137,22,21,218,90,72,132,199,244,53,51,71,23,39,70,31,85,209,144,112,202,232,120,143,181,33,167,116,17,63,11,235,194,235,73,23,74,99,156,52,214,153,106,185,56,45,23,81,99,153,2,89,107,29,86,172,80,150,40,253,186,141,95,80,35,41,185,25,56,191,54,163,240,86,56,145,153,134,36,198,15,7,235,72,244,171,30,231,61,222,188,34,44,24,130,164,20,214,174,33,24,119,107,232,141,58,78,221,28,74,37,65,122,202,31,6,172,97,55,229,71,124,51,127,71,97,246,115,212,72,103,136,245,211,78,42,48,122,217,115,193,107,166,251,52,53,153,47,149,35,189,113,141,43,232,65,43,63,176,18,1,218,237,81,228,239,186,108,183,170,139,37,168,189,13,180,21,152,195,39,75,221,67,45,136,185,14,201,222,128,47,51,138,210,137,44,220,205,92,124,147,81,148,13,22,60,30,253,194,48,29,244,128,119,135,71,55,252,238,131,163,206,67,246,121,17,108,92,35,255,22,188,92,67,31,112,118,222,9,10,116,27,232,133,231,196,201,153,23,105,255,105,103,146,102,174,113,150,33,160,115,144,177,31,76,245,19,208,225,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d8e6aa3a-8514-4021-adab-1ac712c5737b"));
		}

		#endregion

	}

	#endregion

}

