namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactSgmSchema

	/// <exclude/>
	public class ContactSgmSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactSgmSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactSgmSchema(ContactSgmSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f27597f1-ef26-4cc5-8f2a-1e8aeb9e1ffc");
			Name = "ContactSgm";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0bd8020-de17-4815-83cd-c2dac7bbc324");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,147,95,107,194,48,20,197,159,43,248,29,46,245,69,65,218,119,221,31,152,108,99,48,157,224,222,37,107,175,37,144,38,37,73,11,50,252,238,75,211,116,77,181,200,24,219,139,244,158,228,158,156,251,51,225,36,71,85,144,4,225,97,187,222,137,131,142,86,130,31,104,86,74,162,169,224,227,209,231,120,52,30,5,19,137,153,41,97,197,136,82,11,48,123,52,73,244,46,203,237,106,28,199,112,163,202,60,39,242,120,7,78,176,91,231,80,72,81,209,20,21,36,77,15,132,187,82,114,115,106,56,135,240,153,86,200,161,173,214,52,77,25,54,37,28,40,178,84,69,173,123,220,218,27,161,40,63,24,77,32,169,15,232,69,9,76,216,160,203,42,184,210,178,76,180,144,38,242,214,54,217,184,173,65,215,58,157,129,109,13,246,170,9,7,183,176,207,234,112,27,87,228,54,155,171,140,45,229,89,244,152,23,250,184,172,251,78,141,239,4,121,218,28,238,106,151,100,43,69,129,82,83,60,203,209,227,214,10,225,43,81,218,135,80,51,184,132,16,20,146,86,68,163,11,3,109,242,165,55,160,91,114,192,221,136,25,106,247,21,72,212,102,169,223,90,207,98,126,85,183,203,99,226,6,127,81,155,146,177,55,105,1,76,43,194,74,156,193,125,15,11,44,192,234,209,187,164,6,175,103,125,186,54,251,19,149,191,26,254,251,191,26,24,223,94,178,205,85,0,253,246,1,4,254,93,248,119,8,151,239,32,250,25,133,238,146,14,96,104,92,175,115,56,51,24,0,49,244,14,254,130,132,255,116,156,230,75,70,249,2,196,211,123,111,170,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f27597f1-ef26-4cc5-8f2a-1e8aeb9e1ffc"));
		}

		#endregion

	}

	#endregion

}

