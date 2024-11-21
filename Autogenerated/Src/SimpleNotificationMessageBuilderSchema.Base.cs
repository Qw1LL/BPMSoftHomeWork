namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SimpleNotificationMessageBuilderSchema

	/// <exclude/>
	public class SimpleNotificationMessageBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SimpleNotificationMessageBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SimpleNotificationMessageBuilderSchema(SimpleNotificationMessageBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("314059c6-f688-44bf-b84c-c7c747f99b73");
			Name = "SimpleNotificationMessageBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,81,107,219,48,16,126,118,161,255,225,72,95,18,40,201,246,154,54,131,166,208,214,15,217,2,97,111,129,162,90,23,71,96,73,70,146,55,66,200,127,223,201,146,157,184,101,137,203,246,146,72,119,247,233,190,251,238,206,138,73,180,37,203,16,230,203,197,74,111,220,248,81,171,141,200,43,195,156,208,234,250,106,127,125,149,84,86,168,28,86,59,235,80,222,181,247,6,176,64,107,89,78,22,130,74,169,21,69,80,204,141,193,156,30,128,199,130,89,59,133,149,144,101,129,223,181,19,27,145,213,79,7,24,206,43,81,112,52,53,166,172,222,10,145,65,230,33,23,17,48,133,244,220,123,9,49,167,223,150,200,147,192,130,19,147,165,17,191,152,195,224,44,195,5,12,50,174,85,177,139,89,227,91,240,42,227,97,6,10,127,119,157,195,81,40,52,185,65,197,67,142,110,194,165,209,37,26,39,208,39,173,43,11,254,201,100,2,247,182,146,146,153,221,183,198,240,140,206,130,54,96,253,191,224,168,168,48,170,81,111,192,109,17,252,213,237,198,45,122,114,10,143,170,61,87,130,67,202,193,55,44,73,114,116,190,83,73,98,227,225,240,201,228,226,152,157,113,41,20,84,74,184,30,12,104,74,30,124,252,79,10,255,15,108,20,205,103,195,195,203,89,183,26,156,6,229,91,127,65,18,235,140,31,212,31,45,238,95,217,88,106,245,81,151,56,28,189,56,172,2,242,60,129,191,77,210,2,221,86,243,62,99,84,79,191,5,214,112,59,233,102,143,222,213,232,148,15,71,145,167,65,87,25,245,174,165,23,21,251,192,97,75,203,117,41,127,186,176,249,75,29,23,240,225,220,50,57,113,135,215,104,35,155,229,28,7,71,80,52,230,138,114,207,162,238,119,167,229,132,144,207,151,241,166,121,191,121,171,145,115,138,126,47,100,240,143,159,180,145,204,13,7,251,61,172,7,6,51,109,72,244,245,96,74,183,253,151,195,122,112,75,135,118,214,201,78,230,175,100,62,28,200,147,242,219,227,60,143,250,23,81,175,75,252,82,246,27,92,47,121,192,183,101,180,138,211,98,207,142,211,18,212,109,157,190,242,198,29,84,8,1,157,190,118,58,210,64,207,236,66,176,118,141,100,251,3,251,104,111,104,191,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("314059c6-f688-44bf-b84c-c7c747f99b73"));
		}

		#endregion

	}

	#endregion

}

