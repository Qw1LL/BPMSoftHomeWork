namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TemplateContentSchema

	/// <exclude/>
	public class TemplateContentSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TemplateContentSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TemplateContentSchema(TemplateContentSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5dae23e0-f39b-4db5-9d47-a9196b501f89");
			Name = "TemplateContent";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5f5fe385-d25b-4c17-9585-cfaff007abaf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,193,10,131,48,16,68,207,21,252,135,5,239,122,175,165,135,74,233,73,16,244,7,82,93,109,64,19,73,214,67,145,254,123,19,163,197,214,30,218,92,66,102,103,50,47,17,172,67,221,179,18,225,148,165,185,172,41,76,164,168,121,51,40,70,92,138,48,57,231,169,172,176,213,190,55,250,158,239,237,2,133,141,25,64,210,50,173,247,80,96,215,183,140,208,164,8,5,77,150,40,138,224,160,135,174,99,234,126,156,207,118,21,55,4,154,253,80,186,64,184,248,163,85,160,31,174,45,47,161,180,21,219,134,157,3,121,145,100,74,246,168,136,163,193,201,166,164,155,127,98,76,194,5,73,131,84,160,237,78,6,104,197,177,5,89,72,52,41,46,154,197,11,35,52,72,177,189,35,134,199,63,101,194,252,246,79,77,214,248,173,38,64,81,185,103,79,103,167,190,139,70,123,2,28,211,25,88,213,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5dae23e0-f39b-4db5-9d47-a9196b501f89"));
		}

		#endregion

	}

	#endregion

}

