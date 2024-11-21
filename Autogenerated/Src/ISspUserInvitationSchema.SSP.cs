namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISspUserInvitationSchema

	/// <exclude/>
	public class ISspUserInvitationSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISspUserInvitationSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISspUserInvitationSchema(ISspUserInvitationSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c32a2df7-dfa5-4008-a507-49930a3bf59e");
			Name = "ISspUserInvitation";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7cc31540-fa76-4c79-9b86-a6eabd8e662c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,148,81,107,194,48,16,199,159,21,252,14,7,190,219,247,57,6,110,136,20,54,17,139,79,99,15,49,189,118,129,54,41,185,196,33,226,119,95,210,234,156,163,182,181,123,9,109,248,229,254,247,191,75,78,178,28,169,96,28,225,121,245,22,169,196,76,94,148,76,68,106,53,51,66,201,73,20,173,70,195,195,104,56,176,36,100,10,209,158,12,230,211,209,208,237,140,53,166,14,129,80,26,212,137,11,241,0,97,68,197,134,80,135,114,39,76,25,160,36,11,187,205,4,7,113,6,107,185,129,87,25,4,65,0,143,100,243,156,233,253,211,121,99,158,51,145,129,74,160,80,218,176,12,172,59,58,249,161,131,223,56,25,237,243,172,78,28,32,69,51,5,242,203,177,204,164,62,254,234,18,22,156,125,195,184,9,227,27,2,11,43,226,11,244,31,9,144,174,246,205,54,150,142,232,37,225,250,52,139,115,33,55,82,180,88,185,38,59,139,249,238,129,86,25,82,67,240,247,143,146,91,123,172,151,141,234,123,198,185,178,178,197,199,31,244,62,35,238,118,162,36,236,208,145,215,138,236,221,152,83,130,11,173,108,209,108,232,154,236,37,182,108,181,227,221,223,229,101,141,100,51,227,223,162,42,240,52,35,234,21,182,74,101,16,89,206,145,186,55,127,174,181,210,240,245,41,50,116,227,194,13,7,151,100,203,75,47,79,116,141,31,185,105,99,201,167,79,123,98,254,222,91,119,239,65,35,87,250,86,55,74,35,33,249,82,205,184,17,187,186,98,85,235,24,101,92,13,69,255,123,252,6,108,180,12,31,92,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c32a2df7-dfa5-4008-a507-49930a3bf59e"));
		}

		#endregion

	}

	#endregion

}

