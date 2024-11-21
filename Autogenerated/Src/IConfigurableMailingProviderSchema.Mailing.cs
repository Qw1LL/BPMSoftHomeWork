namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IConfigurableMailingProviderSchema

	/// <exclude/>
	public class IConfigurableMailingProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IConfigurableMailingProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IConfigurableMailingProviderSchema(IConfigurableMailingProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("cc13a695-7766-435a-88b7-db1edaea23f9");
			Name = "IConfigurableMailingProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5d774dd3-3f0d-4e5d-9409-9a3b17d3417e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,144,191,10,194,48,16,135,231,22,250,14,7,46,186,180,187,138,131,78,14,133,130,79,16,211,107,61,104,146,114,73,5,17,223,221,216,164,254,29,220,114,151,251,125,249,46,90,40,180,189,144,8,219,170,60,152,198,229,59,163,27,106,7,22,142,140,206,75,65,29,233,54,75,175,89,154,165,201,140,177,245,109,216,107,135,220,248,216,18,246,207,192,177,195,56,94,177,57,83,141,60,102,138,162,128,181,29,148,18,124,217,196,58,14,88,80,232,78,166,182,224,12,200,200,65,80,129,2,125,196,228,19,165,120,195,244,195,177,35,9,52,153,252,17,73,194,2,207,13,202,240,240,18,170,145,19,46,191,85,199,198,132,245,182,94,168,71,118,228,143,166,1,57,48,163,118,94,193,58,161,37,62,52,127,61,147,179,161,250,5,153,47,86,81,4,117,29,92,198,250,22,254,247,163,121,187,3,253,9,251,118,158,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("cc13a695-7766-435a-88b7-db1edaea23f9"));
		}

		#endregion

	}

	#endregion

}

