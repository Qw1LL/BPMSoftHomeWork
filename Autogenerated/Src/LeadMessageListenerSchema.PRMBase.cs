namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LeadMessageListenerSchema

	/// <exclude/>
	public class LeadMessageListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LeadMessageListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LeadMessageListenerSchema(LeadMessageListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f408d242-9302-400c-8b6c-6d9552b53572");
			Name = "LeadMessageListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("2b000645-6072-461d-8963-11edfee86881");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,146,77,110,194,48,16,133,215,70,226,14,22,108,232,38,7,160,234,134,168,63,72,64,17,129,3,24,103,146,88,36,54,245,196,85,81,197,221,59,118,66,21,66,22,145,50,227,247,205,60,191,196,161,210,57,79,46,88,67,245,60,30,185,80,46,182,235,196,100,117,20,27,11,255,205,70,19,237,11,11,34,165,70,180,23,120,194,1,166,170,140,238,83,177,41,75,144,181,50,26,163,119,208,96,149,236,75,86,74,127,81,111,60,210,162,2,60,11,9,157,153,58,83,185,179,194,15,24,143,126,189,138,77,45,228,84,242,184,20,136,115,190,34,87,107,64,20,57,172,20,13,164,29,65,118,118,199,82,73,46,189,106,72,196,231,124,33,16,30,80,70,91,24,243,207,109,209,155,130,50,165,77,91,171,190,69,13,97,58,155,130,78,155,243,182,190,185,162,155,214,214,201,218,88,34,130,135,70,208,250,25,112,50,59,32,88,226,116,19,20,119,119,229,19,25,61,146,209,89,191,29,124,178,15,26,98,236,37,145,5,84,98,67,9,242,23,62,233,44,105,207,39,148,112,95,189,131,12,44,104,9,244,145,92,165,187,240,50,109,129,155,199,134,56,44,83,82,120,65,184,38,70,254,53,105,79,26,96,3,144,198,5,200,211,235,79,64,37,124,102,59,144,198,122,146,130,241,255,21,99,215,199,16,219,222,125,174,215,63,42,172,164,213,167,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f408d242-9302-400c-8b6c-6d9552b53572"));
		}

		#endregion

	}

	#endregion

}

