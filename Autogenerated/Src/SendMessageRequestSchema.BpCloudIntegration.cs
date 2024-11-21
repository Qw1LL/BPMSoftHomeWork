namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SendMessageRequestSchema

	/// <exclude/>
	public class SendMessageRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SendMessageRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SendMessageRequestSchema(SendMessageRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("394b7098-d52a-4248-b5d6-5a4098ccf4ac");
			Name = "SendMessageRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,147,65,79,219,80,12,199,207,67,226,59,88,229,50,46,201,157,194,36,40,8,237,208,173,34,220,208,132,76,226,100,150,242,242,186,103,7,137,161,125,119,252,94,82,160,45,42,234,46,73,236,248,239,188,223,223,78,135,142,100,137,37,193,197,98,94,248,90,179,153,239,106,110,250,128,202,190,203,102,87,197,220,87,212,202,225,193,243,225,193,151,94,184,107,160,120,18,37,55,221,136,179,155,190,83,118,148,21,20,24,91,254,155,58,88,149,213,29,5,106,44,128,89,139,34,39,80,80,87,205,73,4,27,186,161,63,61,137,166,170,60,207,225,84,122,231,48,60,125,27,227,164,128,218,7,8,67,37,168,7,49,61,176,115,84,49,42,129,27,90,101,171,22,249,70,143,83,33,194,86,60,148,129,234,179,201,39,164,217,5,10,25,195,35,151,171,211,77,32,143,189,238,46,81,209,84,26,176,212,95,150,88,246,15,45,151,80,166,51,110,67,193,9,108,247,50,153,57,105,215,87,83,22,193,47,41,40,147,57,179,72,29,135,247,155,118,164,196,53,169,128,185,33,241,174,191,9,200,33,183,242,222,131,109,19,134,204,35,182,61,189,134,183,166,29,69,112,121,251,243,157,240,173,46,1,207,201,61,80,248,250,195,54,5,206,96,50,106,38,199,209,128,149,3,87,241,16,35,60,172,238,207,208,144,78,227,73,167,240,111,31,164,42,14,21,109,196,113,157,192,215,105,222,113,209,184,3,209,16,159,108,33,28,234,126,180,105,107,214,68,187,73,99,253,61,234,58,233,248,253,56,236,115,253,127,68,138,134,1,87,100,191,76,205,20,246,35,217,161,222,141,148,132,247,92,173,51,93,247,92,13,35,252,94,125,132,116,100,176,195,174,166,120,200,174,39,45,247,2,131,118,188,200,75,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("394b7098-d52a-4248-b5d6-5a4098ccf4ac"));
		}

		#endregion

	}

	#endregion

}

