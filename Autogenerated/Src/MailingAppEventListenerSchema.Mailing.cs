namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: MailingAppEventListenerSchema

	/// <exclude/>
	public class MailingAppEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MailingAppEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MailingAppEventListenerSchema(MailingAppEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f77b591-a8a7-4600-8f2b-2803c4f5ce85");
			Name = "MailingAppEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d6cb3076-08d5-49e6-ac18-d8f418ab1e90");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,81,111,211,64,12,126,206,164,253,7,43,123,41,47,201,251,88,43,173,211,6,72,84,84,84,19,15,19,66,110,226,148,19,151,187,147,239,18,81,16,255,29,39,151,64,211,12,177,151,68,254,108,127,182,63,251,12,214,228,29,22,4,235,237,102,103,171,144,221,89,83,169,67,195,24,148,53,151,23,63,47,47,146,198,43,115,56,9,96,122,61,67,63,209,94,60,117,109,141,248,196,123,197,116,16,2,184,211,232,253,53,108,80,105,9,191,117,238,190,37,19,222,43,31,200,16,247,161,121,158,195,141,111,234,26,249,184,26,236,143,228,152,188,68,122,168,41,124,181,165,135,96,65,25,21,20,106,245,131,64,122,254,134,7,202,198,252,252,132,192,53,123,173,10,40,186,210,255,170,12,215,112,14,173,209,147,100,203,196,242,253,51,192,131,34,93,202,4,91,86,45,6,138,78,23,13,120,244,196,34,152,161,162,83,11,190,52,19,59,42,145,92,145,41,35,217,148,121,19,7,123,25,245,27,10,83,100,49,182,47,80,160,239,1,138,248,127,5,221,202,146,68,85,176,56,235,7,150,75,48,141,214,99,72,210,34,3,58,39,17,99,192,200,146,9,187,104,216,31,193,83,42,198,95,150,244,51,160,239,196,155,12,218,209,205,202,77,200,179,221,81,116,174,167,83,196,204,95,253,151,41,52,252,156,136,125,192,203,148,236,55,31,157,231,103,213,3,107,101,228,148,134,227,241,226,39,130,130,169,90,166,253,161,62,96,17,44,31,211,124,5,74,122,245,221,121,205,239,43,34,14,25,107,48,242,128,150,233,160,90,186,122,103,124,64,35,207,201,86,167,228,103,187,74,243,85,118,147,247,4,61,223,112,176,182,37,102,85,18,180,86,149,240,193,72,214,46,32,135,255,173,186,91,227,76,250,249,193,140,89,81,243,225,93,188,69,83,106,98,255,24,196,12,138,124,118,111,112,175,233,86,114,90,218,178,109,165,33,30,163,22,211,50,145,234,249,229,68,116,10,10,246,27,185,140,31,252,113,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f77b591-a8a7-4600-8f2b-2803c4f5ce85"));
		}

		#endregion

	}

	#endregion

}

