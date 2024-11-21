namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: BaseStorableEntitySchema

	/// <exclude/>
	public class BaseStorableEntitySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public BaseStorableEntitySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public BaseStorableEntitySchema(BaseStorableEntitySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("29c15305-d044-47a9-b58f-c7d81b88fdca");
			Name = "BaseStorableEntity";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,93,107,131,48,20,134,175,35,248,31,14,244,166,189,209,251,110,118,208,82,198,46,54,4,47,199,24,169,57,117,7,52,145,124,180,184,209,255,190,36,234,144,109,23,34,121,242,158,55,79,34,121,135,166,231,53,194,190,124,174,212,217,102,7,37,207,212,56,205,45,41,153,38,95,105,194,156,33,217,64,53,24,139,221,93,154,120,178,210,216,248,109,56,180,220,152,45,236,185,193,202,42,205,79,45,30,165,37,59,196,84,158,231,112,111,92,215,113,61,236,166,117,136,130,153,178,128,49,12,87,178,31,192,157,85,13,74,244,39,163,0,18,217,220,144,47,42,94,43,212,196,91,250,12,227,111,30,244,238,212,82,13,117,16,249,215,131,133,27,176,240,205,210,165,86,61,106,75,232,205,203,56,62,39,126,11,71,48,22,77,66,127,141,88,175,233,226,149,225,209,145,128,119,18,254,133,60,28,181,34,123,18,16,29,88,131,22,138,93,200,64,81,196,189,236,216,245,190,251,1,214,17,142,236,5,175,225,191,222,108,96,251,83,200,204,98,24,46,188,117,24,249,45,190,52,91,161,20,227,245,226,122,164,75,120,131,111,225,38,135,76,235,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("29c15305-d044-47a9-b58f-c7d81b88fdca"));
		}

		#endregion

	}

	#endregion

}

