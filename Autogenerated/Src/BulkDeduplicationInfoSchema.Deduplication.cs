namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BulkDeduplicationInfoSchema

	/// <exclude/>
	public class BulkDeduplicationInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BulkDeduplicationInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BulkDeduplicationInfoSchema(BulkDeduplicationInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e14ddd74-99f1-4f32-b2b4-b4a8b303f9e2");
			Name = "BulkDeduplicationInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3066e968-6ad0-45b5-bf2b-b9af469e0d31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,177,110,131,48,16,134,231,34,241,14,167,100,105,23,216,155,182,67,18,85,202,144,10,133,110,85,7,99,14,100,5,108,228,179,165,166,81,222,189,6,147,52,77,24,130,186,88,58,223,127,255,125,190,3,201,106,164,134,113,132,121,178,78,85,97,162,133,146,133,40,173,102,70,40,25,45,49,183,77,37,120,23,133,193,62,12,194,224,206,146,144,37,164,59,50,88,71,27,43,141,168,49,74,81,11,86,137,239,78,57,235,116,83,141,165,11,96,81,49,162,71,152,219,106,251,199,111,37,11,213,9,227,56,134,39,178,117,205,244,238,165,143,91,53,228,231,114,16,157,222,171,227,51,249,199,146,25,230,184,141,102,220,124,186,139,198,102,174,8,120,219,119,184,45,248,151,92,117,238,46,222,181,69,16,197,69,119,169,12,144,97,218,96,14,25,22,74,99,116,114,56,167,241,56,107,172,51,212,247,111,110,190,240,12,19,65,175,66,147,113,195,154,60,180,132,71,196,76,169,10,86,167,36,236,161,68,51,3,106,143,195,104,68,65,160,173,148,110,59,163,208,54,190,102,144,172,207,221,12,150,104,197,145,200,205,168,65,205,81,26,80,151,148,134,209,118,4,95,115,116,76,188,225,95,76,225,58,36,23,138,155,97,151,61,21,18,112,229,190,99,200,118,64,202,58,19,208,200,149,206,71,96,214,236,235,215,206,129,108,58,131,107,216,245,160,238,159,139,111,71,10,100,121,59,134,81,171,79,125,205,224,234,251,220,0,154,63,167,40,115,255,135,187,32,12,14,63,219,205,173,181,76,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e14ddd74-99f1-4f32-b2b4-b4a8b303f9e2"));
		}

		#endregion

	}

	#endregion

}

