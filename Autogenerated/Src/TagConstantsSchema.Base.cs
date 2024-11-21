namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TagConstantsSchema

	/// <exclude/>
	public class TagConstantsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TagConstantsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TagConstantsSchema(TagConstantsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ae28a44b-17af-49d1-987b-2e02f87bc1ca");
			Name = "TagConstants";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9e68a40f-2533-42d0-8fe0-88fdb6bf5704");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,79,77,107,131,64,16,61,71,240,63,44,241,210,30,166,49,186,187,42,161,7,247,171,244,16,8,36,253,1,91,221,136,96,84,92,109,9,37,255,189,27,123,234,65,218,129,97,96,222,155,121,239,77,182,110,43,116,188,218,209,92,118,190,231,123,173,190,24,219,235,194,32,118,216,31,187,243,248,196,187,246,92,87,211,160,199,186,107,125,239,203,247,86,253,244,222,212,5,178,163,219,21,168,104,180,181,232,164,43,199,180,163,117,248,157,179,218,108,130,32,64,174,3,4,243,152,235,142,252,62,31,140,46,187,182,185,162,151,169,46,209,97,198,220,179,211,181,55,111,175,37,122,70,173,249,156,177,135,181,160,138,97,33,41,132,105,152,1,222,42,9,121,138,21,80,17,97,194,25,39,42,142,214,143,187,101,245,255,56,224,221,208,119,46,173,89,48,65,68,146,201,56,139,65,165,50,4,156,198,33,228,9,101,160,98,158,48,46,73,148,73,177,108,226,207,252,67,253,177,172,157,138,68,81,65,57,96,158,19,192,12,199,192,132,200,32,39,50,220,230,36,141,34,26,254,104,223,124,239,246,13,39,163,215,254,221,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ae28a44b-17af-49d1-987b-2e02f87bc1ca"));
		}

		#endregion

	}

	#endregion

}

