namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ApprovalConstantsSchema

	/// <exclude/>
	public class ApprovalConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ApprovalConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ApprovalConstantsSchema(ApprovalConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("96d50106-6c2d-4bb1-9f14-582f073e5e34");
			Name = "ApprovalConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("be1f674b-cdb4-46e4-8c46-23cae20b9205");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,147,65,111,130,48,24,134,207,51,241,63,52,122,217,14,85,75,11,181,115,51,113,30,118,90,98,230,97,231,175,229,195,176,40,16,90,182,152,197,255,190,14,135,67,231,193,68,46,192,155,231,123,191,7,2,25,108,208,22,96,144,60,45,94,150,121,226,6,243,60,75,210,85,85,130,75,243,172,219,249,234,118,136,63,42,155,102,43,178,220,90,135,155,73,183,179,15,251,37,174,60,68,230,107,176,246,158,204,138,162,204,63,96,237,27,172,131,204,217,134,27,14,135,228,193,86,155,13,148,219,233,95,212,240,164,53,112,192,135,199,124,81,233,117,106,136,199,156,63,153,159,133,231,246,253,160,222,120,127,209,86,92,148,121,129,165,75,209,123,46,234,174,54,117,70,176,137,223,32,117,245,163,251,205,149,29,156,204,156,88,254,55,125,174,210,248,208,241,56,37,25,126,214,217,109,143,139,40,8,149,136,169,148,32,169,208,35,160,99,41,128,70,241,88,135,66,7,138,107,211,187,155,92,168,57,51,6,11,135,241,85,158,135,146,35,81,148,42,1,163,57,229,134,7,84,112,148,20,66,133,148,5,26,88,16,98,196,120,112,185,232,43,190,163,185,86,244,181,41,57,18,5,197,65,143,180,162,6,120,228,223,168,10,169,210,1,167,56,98,0,44,82,134,243,241,175,232,205,25,203,67,54,247,191,195,186,109,248,71,183,244,234,240,140,219,28,178,253,248,145,155,98,193,40,137,49,161,145,210,72,5,139,198,84,135,9,167,33,147,146,9,45,65,160,106,220,110,250,152,197,251,239,214,223,237,234,172,29,117,59,187,111,89,48,138,214,183,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("96d50106-6c2d-4bb1-9f14-582f073e5e34"));
		}

		#endregion

	}

	#endregion

}

