namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: GetThrottlingSchedulesResponseSchema

	/// <exclude/>
	public class GetThrottlingSchedulesResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public GetThrottlingSchedulesResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public GetThrottlingSchedulesResponseSchema(GetThrottlingSchedulesResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dfe8f2e9-f969-4657-87c8-6095ab77b87d");
			Name = "GetThrottlingSchedulesResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,49,111,194,48,16,133,103,144,248,15,39,88,218,37,217,11,101,40,173,88,74,133,72,183,170,131,49,71,176,228,216,145,239,60,80,212,255,222,115,66,210,22,42,117,73,114,207,207,207,239,115,156,170,144,106,165,17,30,214,171,194,239,57,91,120,183,55,101,12,138,141,119,217,226,169,216,136,193,59,66,26,13,79,163,225,32,146,113,37,20,71,98,172,196,108,45,234,228,164,108,137,14,131,209,211,75,207,38,58,54,21,102,133,172,42,107,62,154,96,113,137,111,18,176,148,1,22,86,17,221,193,18,249,245,16,60,179,149,237,133,62,224,46,90,164,238,252,102,71,158,231,48,163,88,85,42,28,231,231,121,131,117,64,66,199,4,124,64,144,239,104,25,252,190,153,184,15,4,58,39,102,93,78,254,35,232,237,81,177,18,118,14,74,243,187,8,117,220,90,163,65,167,106,255,54,27,200,205,200,179,7,90,7,95,99,96,131,66,181,110,130,70,205,250,101,253,70,144,112,2,31,128,210,91,247,55,218,18,92,181,167,84,255,186,127,11,176,194,106,139,225,230,69,254,42,220,195,248,123,123,223,249,217,16,143,111,19,96,71,152,148,217,53,221,28,254,32,78,94,56,65,137,60,77,117,167,240,217,114,77,208,237,90,244,102,110,213,223,162,104,95,149,207,175,44,109,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dfe8f2e9-f969-4657-87c8-6095ab77b87d"));
		}

		#endregion

	}

	#endregion

}

