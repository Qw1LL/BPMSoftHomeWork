namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MessagePublisherManagerSchema

	/// <exclude/>
	public class MessagePublisherManagerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MessagePublisherManagerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MessagePublisherManagerSchema(MessagePublisherManagerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f427a0bd-0b35-4b26-946c-3c6a5598a4f9");
			Name = "MessagePublisherManager";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("7c74fc90-4a57-4e68-9eda-fe0982d1250d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,83,203,106,195,48,16,60,43,208,127,216,146,139,3,198,31,144,54,45,109,66,67,14,46,129,180,231,162,216,107,71,69,145,140,36,7,66,233,191,119,101,57,15,59,164,80,122,145,172,245,120,102,118,86,86,124,139,182,226,25,194,243,50,93,233,194,37,83,173,10,81,214,134,59,161,213,205,224,235,102,192,106,43,84,9,171,189,117,184,189,235,157,9,47,37,102,30,108,147,57,42,52,34,59,97,78,164,6,169,74,245,161,193,146,176,48,149,220,218,49,164,104,45,47,113,89,175,165,176,27,52,41,87,116,52,13,180,242,197,12,50,143,188,14,100,228,144,214,35,241,139,64,73,196,75,35,118,220,181,162,172,10,39,48,200,115,173,228,30,222,45,26,234,84,5,231,240,81,119,206,237,87,67,84,121,96,237,74,16,208,58,83,103,78,27,18,106,92,182,50,193,241,21,175,81,79,180,171,57,2,31,53,99,61,43,48,233,225,124,184,236,251,119,131,41,186,141,206,79,41,116,67,208,235,79,162,130,57,186,5,245,193,85,134,17,181,227,199,213,68,253,74,87,34,134,153,104,212,184,217,223,135,151,49,132,253,1,10,74,56,183,51,238,248,193,243,219,190,66,112,126,153,128,127,166,139,224,252,30,29,9,71,141,109,102,208,213,70,5,232,237,4,84,45,37,60,194,19,73,145,51,109,146,41,13,200,225,209,150,199,197,253,225,196,29,3,227,134,228,111,161,92,78,108,167,69,30,234,118,243,223,48,118,220,0,253,84,157,27,64,185,68,139,254,181,24,157,79,224,76,237,140,50,164,38,10,136,46,24,219,248,14,170,172,15,72,14,237,180,36,148,206,181,136,66,181,91,164,218,15,201,138,164,115,28,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f427a0bd-0b35-4b26-946c-3c6a5598a4f9"));
		}

		#endregion

	}

	#endregion

}

