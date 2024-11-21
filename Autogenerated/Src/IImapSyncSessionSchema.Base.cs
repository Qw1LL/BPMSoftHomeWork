namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImapSyncSessionSchema

	/// <exclude/>
	public class IImapSyncSessionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapSyncSessionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapSyncSessionSchema(IImapSyncSessionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("b5e207e3-b931-420a-8ad6-b7eb4a279b1a");
			Name = "IImapSyncSession";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,193,106,132,48,16,134,207,10,190,195,192,94,218,203,122,223,45,133,118,247,226,65,144,250,4,217,56,106,192,36,146,137,11,118,217,119,239,196,216,210,86,10,205,41,153,204,255,231,203,63,70,104,164,81,72,132,215,170,172,109,235,247,165,80,67,150,222,178,20,120,77,164,76,7,245,76,30,245,49,75,179,52,217,57,236,148,53,80,24,143,174,101,225,1,138,66,139,177,158,141,172,145,136,239,150,190,60,207,225,137,38,173,133,155,159,215,115,229,236,85,53,72,160,209,247,182,33,104,173,131,162,124,169,128,88,221,59,107,212,187,240,193,93,5,119,33,195,126,255,105,150,127,115,27,167,203,160,100,108,11,16,27,6,166,58,43,26,45,137,203,128,44,224,255,36,95,236,204,49,162,243,10,233,0,213,226,180,32,111,152,151,194,27,106,235,17,100,47,76,135,160,56,8,2,105,39,227,3,216,150,44,97,166,85,115,90,36,116,10,205,112,131,14,253,17,238,241,165,29,154,38,194,172,231,149,172,140,193,252,3,171,246,194,121,2,197,223,6,205,35,219,68,72,49,136,63,40,175,86,53,60,87,35,67,110,97,228,15,143,113,190,191,209,34,240,207,226,253,3,143,99,150,181,54,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("b5e207e3-b931-420a-8ad6-b7eb4a279b1a"));
		}

		#endregion

	}

	#endregion

}

