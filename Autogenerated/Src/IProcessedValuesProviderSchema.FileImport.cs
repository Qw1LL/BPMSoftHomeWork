namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IProcessedValuesProviderSchema

	/// <exclude/>
	public class IProcessedValuesProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IProcessedValuesProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IProcessedValuesProviderSchema(IProcessedValuesProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d35a2012-d756-4c04-a033-754a28ca5950");
			Name = "IProcessedValuesProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,193,106,195,48,12,134,207,13,228,29,68,79,27,140,248,1,154,229,176,142,64,15,131,66,161,119,215,81,134,71,44,27,217,14,140,209,119,111,226,52,89,232,118,179,172,239,151,62,145,52,232,157,84,8,111,199,143,147,109,67,177,183,212,234,207,200,50,104,75,69,173,59,60,24,103,57,228,217,79,158,109,92,188,116,90,129,166,128,220,142,177,195,145,173,66,239,177,57,203,46,162,31,202,94,55,200,3,59,242,27,33,4,148,62,26,35,249,187,154,63,106,77,141,7,55,39,161,31,163,197,130,139,71,190,116,146,165,1,26,100,95,183,13,250,160,41,233,109,171,201,13,148,237,162,33,88,181,138,82,164,208,255,51,38,62,25,63,206,152,92,254,164,25,67,100,242,213,114,238,2,206,157,17,181,151,47,84,33,221,151,134,215,150,79,178,199,167,105,197,62,109,120,255,149,92,11,191,192,26,74,233,187,82,122,63,239,242,108,216,112,205,179,235,13,162,169,225,51,180,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d35a2012-d756-4c04-a033-754a28ca5950"));
		}

		#endregion

	}

	#endregion

}

