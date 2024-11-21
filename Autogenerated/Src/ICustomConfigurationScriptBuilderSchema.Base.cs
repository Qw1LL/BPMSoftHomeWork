namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ICustomConfigurationScriptBuilderSchema

	/// <exclude/>
	public class ICustomConfigurationScriptBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ICustomConfigurationScriptBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ICustomConfigurationScriptBuilderSchema(ICustomConfigurationScriptBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9b66793-dace-4458-a258-e4f09a3b7b8b");
			Name = "ICustomConfigurationScriptBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,142,59,10,195,48,16,68,107,9,124,7,129,155,164,201,1,146,206,174,92,4,2,38,7,112,228,149,89,176,87,98,37,85,193,119,143,62,4,226,46,176,205,12,51,179,143,166,13,188,155,52,168,238,113,31,173,9,151,222,146,193,37,242,20,208,146,106,228,187,145,34,122,164,229,39,193,112,107,100,242,91,134,37,167,6,10,192,38,173,92,213,208,71,31,236,118,88,25,53,163,11,93,196,117,6,78,181,116,46,190,86,212,10,191,197,191,122,25,69,248,192,5,38,187,53,112,122,122,224,84,36,208,133,57,30,228,57,161,138,189,126,109,129,230,138,92,244,254,1,211,218,4,213,254,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9b66793-dace-4458-a258-e4f09a3b7b8b"));
		}

		#endregion

	}

	#endregion

}

