namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImapExceptionSchema

	/// <exclude/>
	public class ImapExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImapExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImapExceptionSchema(ImapExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("136f52d1-b451-48cb-a9cb-2a36268a593c");
			Name = "ImapException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("80eb4b00-d20b-4335-a2cc-1f02c0e63f83");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,143,65,10,194,48,16,69,215,41,244,14,3,221,84,40,30,160,238,20,23,46,10,133,158,32,141,99,9,180,73,200,164,160,72,239,110,210,170,53,226,194,77,96,254,60,94,254,40,62,32,25,46,16,246,117,213,232,139,219,86,92,246,105,114,79,19,54,146,84,29,52,55,114,56,236,210,196,39,153,197,78,106,5,135,158,19,149,112,26,184,57,94,5,26,231,195,25,48,99,219,75,1,34,236,227,53,148,240,129,50,239,247,239,42,212,138,156,29,133,211,214,123,235,217,178,16,79,99,228,202,61,27,170,249,234,196,59,220,4,142,149,208,114,194,252,149,65,184,128,77,127,75,138,181,30,72,165,208,190,199,95,250,226,155,137,190,203,80,157,151,195,230,121,73,227,112,122,0,196,203,75,16,121,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("136f52d1-b451-48cb-a9cb-2a36268a593c"));
		}

		#endregion

	}

	#endregion

}

