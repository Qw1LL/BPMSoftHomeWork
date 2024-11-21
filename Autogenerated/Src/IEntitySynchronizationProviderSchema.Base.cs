namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEntitySynchronizationProviderSchema

	/// <exclude/>
	public class IEntitySynchronizationProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEntitySynchronizationProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEntitySynchronizationProviderSchema(IEntitySynchronizationProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("42049884-aa36-451a-89f4-25b39d83019b");
			Name = "IEntitySynchronizationProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,81,203,74,196,64,16,60,39,144,127,104,240,162,16,242,1,62,22,220,93,149,61,168,139,249,130,201,164,147,180,100,122,150,158,137,16,197,127,119,146,97,87,144,192,94,188,205,116,87,21,85,93,172,12,186,131,210,8,235,253,115,105,27,95,108,44,55,212,14,162,60,89,46,30,216,147,31,203,145,117,39,150,233,115,158,102,233,87,150,102,105,50,56,226,22,202,209,121,52,129,215,247,168,167,181,43,158,144,81,72,223,156,48,191,226,130,81,147,208,45,173,141,177,28,230,97,115,33,216,6,49,216,177,71,105,130,195,107,216,45,186,217,139,253,160,26,101,102,29,134,170,39,13,116,36,157,229,36,49,74,18,97,240,72,92,199,231,165,243,50,121,195,200,215,29,26,245,18,174,149,195,150,230,152,74,198,219,136,201,193,86,239,33,251,10,180,229,58,100,11,55,184,138,41,142,186,27,65,229,241,156,114,101,109,15,131,195,251,218,16,191,81,219,121,7,119,208,168,222,225,31,189,127,243,153,79,162,201,2,244,85,194,125,182,36,177,211,21,216,233,191,30,67,205,131,57,197,251,142,85,33,215,177,173,233,27,102,63,94,94,157,87,86,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("42049884-aa36-451a-89f4-25b39d83019b"));
		}

		#endregion

	}

	#endregion

}

