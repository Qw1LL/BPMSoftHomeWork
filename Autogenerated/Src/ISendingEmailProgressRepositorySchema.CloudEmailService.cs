namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISendingEmailProgressRepositorySchema

	/// <exclude/>
	public class ISendingEmailProgressRepositorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISendingEmailProgressRepositorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISendingEmailProgressRepositorySchema(ISendingEmailProgressRepositorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cdd44c1d-52e0-461e-8016-96b4499746ae");
			Name = "ISendingEmailProgressRepository";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b39fd9cb-6840-4142-8022-7c9d0489d323");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,145,193,106,195,48,12,134,207,13,228,29,12,189,108,48,154,251,54,118,88,25,35,135,66,72,246,2,158,163,166,130,88,10,182,92,8,99,239,62,57,89,97,99,208,129,49,200,210,255,233,151,76,214,67,156,172,3,243,220,28,58,62,202,110,207,116,196,33,5,43,200,84,22,31,101,177,73,17,105,48,221,28,5,252,67,89,232,75,85,85,230,49,38,239,109,152,159,190,227,22,166,0,17,72,162,145,19,152,14,168,87,217,139,183,56,54,129,7,205,69,45,225,136,194,97,54,142,73,130,117,178,187,208,170,31,184,41,189,143,232,12,146,64,56,102,115,245,117,154,74,212,167,222,155,109,128,65,125,155,3,200,137,251,120,111,154,5,181,38,207,140,189,169,201,5,240,106,179,9,48,217,0,125,11,14,39,204,190,111,94,147,22,64,238,81,247,119,185,189,209,145,150,162,55,206,14,246,156,72,110,215,21,252,161,177,83,79,255,224,116,61,121,140,43,28,149,3,158,161,175,9,5,237,216,234,239,48,69,248,13,187,72,183,138,91,7,94,226,207,178,208,243,5,35,87,176,13,211,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cdd44c1d-52e0-461e-8016-96b4499746ae"));
		}

		#endregion

	}

	#endregion

}

