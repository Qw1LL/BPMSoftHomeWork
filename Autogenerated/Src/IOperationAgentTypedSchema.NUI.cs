namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IOperationAgentTypedSchema

	/// <exclude/>
	public class IOperationAgentTypedSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IOperationAgentTypedSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IOperationAgentTypedSchema(IOperationAgentTypedSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5b084da8-1bf5-4242-9e04-24f04039b8b1");
			Name = "IOperationAgentTyped";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,193,110,194,48,12,134,207,67,226,29,44,118,97,210,68,239,208,33,49,132,80,15,108,8,208,238,161,117,75,164,52,233,18,7,13,161,189,251,146,148,34,96,116,218,169,178,251,127,246,111,199,146,149,104,42,150,34,188,46,23,107,149,211,96,170,100,206,11,171,25,113,37,161,219,57,118,59,15,214,112,89,192,250,96,8,203,209,77,236,0,33,48,245,106,51,152,163,68,205,83,167,113,170,71,141,133,175,145,72,66,157,187,30,67,72,222,43,172,43,79,10,148,20,100,81,20,65,108,108,89,50,125,24,159,226,205,161,194,12,120,3,130,202,129,118,238,211,208,192,60,62,104,232,232,2,175,236,86,240,244,130,189,233,25,111,62,152,176,248,12,155,21,26,43,104,12,110,66,199,157,237,46,181,111,67,28,205,16,150,117,177,90,112,107,52,36,86,72,86,75,3,164,45,2,207,161,84,26,129,237,25,23,108,43,208,59,252,109,241,97,171,148,128,133,83,78,246,76,112,47,132,35,20,72,35,248,246,191,131,27,148,89,109,232,218,221,2,105,167,178,179,181,127,56,147,248,69,144,158,31,169,217,165,198,84,233,204,180,56,12,25,93,87,24,79,91,225,56,106,52,30,74,102,210,150,110,215,110,158,248,188,221,57,210,155,115,144,184,83,49,253,167,250,50,238,27,94,35,153,118,163,64,42,132,159,22,109,219,94,67,166,98,154,149,32,221,97,191,244,78,108,239,207,17,2,16,248,189,226,25,204,100,104,209,191,154,38,220,204,248,4,37,153,241,131,220,125,40,247,128,254,244,175,146,33,247,3,148,218,253,82,106,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5b084da8-1bf5-4242-9e04-24f04039b8b1"));
		}

		#endregion

	}

	#endregion

}

