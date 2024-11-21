namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactEventListenerSchema

	/// <exclude/>
	public class ContactEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactEventListenerSchema(ContactEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7bbed3c8-78ef-49dc-a0ac-f1c79bd9a80b");
			Name = "ContactEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3e2142cb-b5f1-4ce8-8571-f789e137e2ae");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,209,106,219,48,20,125,118,161,255,112,241,30,234,64,177,223,179,56,208,102,93,87,88,214,178,100,125,25,123,80,172,107,71,195,146,130,36,7,204,216,191,239,74,178,179,165,117,217,139,65,87,231,220,115,207,209,181,98,18,237,129,85,8,183,79,235,141,174,93,190,210,170,22,77,103,152,19,90,93,94,252,186,188,72,58,43,84,3,155,222,58,148,239,79,231,73,66,254,40,149,168,246,76,41,108,243,53,90,203,26,194,78,145,12,230,119,202,9,39,208,254,231,58,191,59,162,114,30,69,184,119,6,27,210,129,85,203,172,157,3,137,59,86,185,128,248,44,104,64,133,38,224,138,162,128,133,237,164,100,166,95,14,231,17,0,181,54,112,53,80,175,128,168,194,245,128,65,37,31,185,197,11,242,194,34,178,214,106,168,12,214,101,122,203,44,134,1,251,51,237,20,10,79,248,62,113,149,109,170,61,74,246,133,18,135,18,210,65,62,157,253,32,252,161,219,181,162,130,202,155,154,244,4,115,120,67,145,216,244,70,244,61,69,179,70,183,215,156,194,121,10,93,227,229,203,60,66,225,19,83,188,69,59,38,240,1,91,116,200,99,18,62,136,215,73,196,202,129,25,38,65,145,147,50,181,168,56,249,94,134,161,32,158,242,69,17,32,211,12,76,151,219,61,134,64,135,48,183,243,55,30,62,204,117,83,59,52,161,253,141,105,172,79,24,132,178,142,41,218,218,202,103,37,148,223,29,183,199,81,46,24,0,206,28,59,155,100,72,89,31,209,24,193,17,142,90,112,120,84,131,237,76,239,126,98,53,90,184,134,41,113,192,25,248,63,34,73,118,244,26,249,95,238,72,194,153,95,230,36,137,228,56,30,245,44,33,139,149,89,4,70,208,145,25,160,9,202,17,150,223,163,219,246,7,228,43,221,118,82,61,179,182,195,197,125,39,248,50,75,31,120,58,180,254,231,15,27,54,229,129,251,7,172,5,5,255,21,37,217,139,5,215,127,52,90,174,24,173,93,38,248,245,73,229,155,69,67,76,69,102,105,93,98,215,223,195,10,209,116,113,139,194,57,86,207,139,84,251,3,196,230,211,255,53,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7bbed3c8-78ef-49dc-a0ac-f1c79bd9a80b"));
		}

		#endregion

	}

	#endregion

}

