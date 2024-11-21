namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CallMessagePublisherSchema

	/// <exclude/>
	public class CallMessagePublisherSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CallMessagePublisherSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CallMessagePublisherSchema(CallMessagePublisherSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7614e58c-2fc5-4196-ab0f-e9195ef944f6");
			Name = "CallMessagePublisher";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e1e897dc-76f3-4978-8d04-4d8824362a32");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,80,237,106,2,49,16,252,157,131,123,135,197,254,177,32,62,192,245,3,234,169,253,101,17,142,62,192,26,215,51,144,203,73,54,41,28,197,119,239,230,34,180,86,33,36,153,201,236,76,118,35,27,215,66,51,112,160,110,94,247,214,146,14,166,119,60,127,39,71,222,232,167,178,136,163,100,177,221,52,253,33,136,198,147,144,101,225,176,35,62,161,166,63,79,238,96,218,232,49,57,148,197,119,89,40,89,15,158,90,193,80,91,100,174,160,70,107,55,196,140,45,109,227,206,26,62,146,79,118,234,148,144,6,157,100,119,85,80,193,2,153,110,139,149,36,201,254,155,212,59,14,62,234,208,251,10,70,157,206,130,75,196,61,243,233,39,147,151,66,151,251,135,120,5,103,176,52,227,5,253,240,44,222,50,144,25,228,243,21,200,5,19,134,181,33,187,231,37,6,124,76,81,170,130,157,124,118,250,223,231,70,12,105,76,74,173,70,190,209,71,234,240,67,38,11,47,48,121,147,154,47,97,39,50,111,165,206,151,38,201,237,115,159,35,206,236,53,121,254,1,174,14,11,76,213,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7614e58c-2fc5-4196-ab0f-e9195ef944f6"));
		}

		#endregion

	}

	#endregion

}

