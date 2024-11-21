namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFailoverHandlerSchema

	/// <exclude/>
	public class IFailoverHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFailoverHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFailoverHandlerSchema(IFailoverHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("99cf0342-6c2a-4b19-8aa0-db2b06c2b200");
			Name = "IFailoverHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e0feb11c-442a-4bb5-a527-aa32bcda81de");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,81,205,78,131,64,16,62,67,194,59,76,218,139,94,224,94,107,15,54,26,107,210,132,68,125,128,5,6,88,195,238,144,253,33,26,227,187,59,93,90,4,155,236,30,230,219,249,126,102,86,11,133,182,23,37,194,67,126,124,165,218,165,123,210,181,108,188,17,78,146,78,226,239,36,142,188,149,186,153,53,24,188,75,98,198,215,6,27,110,130,131,118,104,106,22,217,192,225,73,200,142,6,52,207,66,87,29,154,208,151,101,25,108,173,87,74,152,175,221,185,206,13,13,178,66,11,10,93,75,149,5,71,160,72,75,71,6,152,10,109,224,67,205,114,54,189,104,100,51,145,222,23,157,44,65,94,188,175,172,129,211,188,80,241,248,137,165,103,85,166,240,44,73,28,77,177,143,163,243,6,242,32,53,62,254,207,26,128,189,65,225,56,235,7,21,243,156,83,184,145,213,11,35,20,104,222,232,253,202,91,52,188,73,141,229,105,141,171,221,91,139,112,194,160,156,192,116,155,5,198,228,178,24,47,26,72,86,103,99,158,226,230,125,33,24,180,254,202,219,241,63,162,53,234,106,28,46,212,63,124,249,44,81,6,127,1,29,75,202,17,245,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("99cf0342-6c2a-4b19-8aa0-db2b06c2b200"));
		}

		#endregion

	}

	#endregion

}

