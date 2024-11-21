namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ChainOfCircumstancesExtensionsSchema

	/// <exclude/>
	public class ChainOfCircumstancesExtensionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ChainOfCircumstancesExtensionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ChainOfCircumstancesExtensionsSchema(ChainOfCircumstancesExtensionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7c54472f-f2a2-4576-973d-73866d39766e");
			Name = "ChainOfCircumstancesExtensions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,146,193,78,195,48,12,134,207,157,180,119,48,227,192,38,161,245,14,91,37,24,28,129,9,120,129,44,117,215,72,77,82,18,7,49,161,189,59,78,186,150,109,66,226,146,54,191,253,37,191,237,24,161,209,183,66,34,220,175,159,222,108,69,243,149,53,149,218,6,39,72,89,51,30,125,143,71,89,240,202,108,225,109,231,9,245,237,120,196,202,165,195,45,135,97,213,8,239,111,96,85,11,101,94,170,149,114,50,104,79,194,72,244,143,95,132,198,115,146,79,68,158,231,176,240,65,107,225,118,197,97,159,48,176,21,200,99,16,112,32,231,61,152,31,145,109,216,52,74,2,103,19,127,100,116,240,175,129,140,203,224,117,240,253,132,84,219,146,157,175,211,97,93,240,220,98,18,238,64,90,173,25,105,173,39,105,77,169,98,95,120,167,12,197,174,80,45,136,23,4,135,62,52,4,58,120,50,87,4,27,132,254,8,1,37,86,34,6,63,69,19,48,22,188,104,133,19,218,97,5,134,7,176,156,188,191,38,122,146,23,243,1,59,41,186,83,104,215,98,34,207,176,226,157,3,241,220,206,196,124,145,15,153,191,240,49,40,99,191,24,171,17,210,47,19,103,217,14,41,56,227,139,245,113,217,156,214,235,49,241,116,18,107,135,165,146,130,112,113,176,85,192,179,165,135,174,244,65,155,82,173,254,158,215,47,150,44,205,32,62,189,44,235,46,236,219,187,44,224,226,241,35,136,198,79,59,229,186,111,238,244,128,207,102,252,68,179,108,127,24,56,154,178,155,121,218,119,234,169,184,255,1,171,201,115,62,4,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7c54472f-f2a2-4576-973d-73866d39766e"));
		}

		#endregion

	}

	#endregion

}

