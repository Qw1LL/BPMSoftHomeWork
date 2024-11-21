namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailHashDTOSchema

	/// <exclude/>
	public class EmailHashDTOSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailHashDTOSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailHashDTOSchema(EmailHashDTOSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d659f6d2-cdbc-4628-8188-da882d020fa0");
			Name = "EmailHashDTO";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5e01e2a5-733f-47cc-a4c2-452cdff090f0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,79,143,130,48,16,197,207,37,225,59,76,226,29,238,171,241,160,110,162,135,141,36,122,242,86,96,96,107,104,75,250,231,192,26,191,251,150,22,141,226,102,35,28,154,204,155,55,239,215,78,16,148,163,110,105,129,176,202,190,14,178,50,201,90,138,138,213,86,81,195,164,136,163,75,28,197,17,177,154,137,26,14,157,54,200,231,94,153,41,172,157,1,214,13,213,250,3,62,57,101,205,150,234,239,205,113,239,251,173,205,27,86,64,209,183,71,93,226,51,97,248,110,65,153,146,45,42,195,208,165,101,97,248,209,150,166,41,44,180,229,156,170,110,249,44,251,116,208,40,74,84,201,104,34,125,29,25,110,166,141,242,111,242,99,112,129,26,205,220,133,184,227,58,153,11,37,53,248,62,122,227,220,71,198,209,195,251,226,21,79,200,8,28,132,1,105,243,51,22,38,185,219,30,80,132,140,222,23,188,19,9,185,44,187,183,226,87,178,236,166,222,254,182,48,48,110,7,63,82,244,155,251,135,212,111,234,228,92,59,81,201,123,241,23,115,230,130,195,207,228,235,160,62,139,215,56,250,5,61,207,148,86,242,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d659f6d2-cdbc-4628-8188-da882d020fa0"));
		}

		#endregion

	}

	#endregion

}

