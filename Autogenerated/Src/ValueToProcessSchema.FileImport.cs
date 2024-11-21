namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ValueToProcessSchema

	/// <exclude/>
	public class ValueToProcessSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ValueToProcessSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ValueToProcessSchema(ValueToProcessSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dfa4da1a-566c-479e-a9dd-b9d6bfc7fa46");
			Name = "ValueToProcess";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,205,10,194,48,16,132,207,45,244,29,22,188,40,136,15,160,120,81,16,60,8,69,197,123,140,107,9,164,217,146,31,21,196,119,119,155,6,91,69,200,37,59,251,77,102,98,68,141,174,17,18,97,85,238,14,116,245,179,53,153,171,170,130,21,94,145,153,109,148,198,109,221,144,245,69,254,44,242,172,9,103,173,36,72,45,156,131,147,208,1,143,84,90,146,232,28,171,237,70,54,178,88,49,10,108,228,188,13,210,147,157,67,25,185,86,78,14,223,236,56,40,227,193,210,125,107,46,248,152,2,131,202,84,32,73,135,218,124,207,110,45,56,129,248,84,182,79,4,44,63,240,34,10,235,158,100,109,224,211,201,241,117,22,162,89,28,189,138,60,134,71,115,233,242,167,123,42,195,57,27,180,94,161,235,187,12,218,164,108,157,237,19,42,244,11,96,199,95,125,152,234,207,86,252,132,79,165,126,225,79,48,158,242,121,3,70,157,199,58,190,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dfa4da1a-566c-479e-a9dd-b9d6bfc7fa46"));
		}

		#endregion

	}

	#endregion

}

