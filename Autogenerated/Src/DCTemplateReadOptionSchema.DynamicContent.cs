namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCTemplateReadOptionSchema

	/// <exclude/>
	public class DCTemplateReadOptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCTemplateReadOptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCTemplateReadOptionSchema(DCTemplateReadOptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f88a83ea-c4fe-4ac2-870c-f6abbd2f69d5");
			Name = "DCTemplateReadOption";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ad993b20-8db8-48d6-9762-5a83fb4975c6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,77,75,196,64,12,134,207,45,244,63,4,188,74,235,122,84,87,208,253,192,139,31,236,234,73,60,100,219,180,12,116,62,152,100,192,34,251,223,77,219,21,246,224,101,152,55,239,155,39,51,113,104,137,3,214,4,143,111,207,123,223,74,185,242,174,53,93,138,40,198,187,114,61,56,180,166,214,162,144,147,34,255,41,242,44,177,113,29,236,7,22,178,183,69,174,149,139,72,157,166,97,227,146,189,129,245,234,157,108,232,81,104,71,216,188,134,17,52,197,170,170,130,59,78,214,98,28,238,79,122,182,25,72,91,161,245,17,162,246,48,40,122,34,148,240,193,196,128,12,109,143,29,151,127,148,234,12,243,185,29,173,47,189,133,116,232,77,61,179,254,127,69,166,31,208,51,123,241,142,96,9,87,151,163,216,124,215,125,106,232,65,36,154,67,18,157,183,132,197,185,179,163,160,92,124,18,219,159,54,161,137,235,137,116,156,23,64,174,153,119,48,202,227,47,201,36,167,126,86,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f88a83ea-c4fe-4ac2-870c-f6abbd2f69d5"));
		}

		#endregion

	}

	#endregion

}

