namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IColumnsAggregatorAdapterSchema

	/// <exclude/>
	public class IColumnsAggregatorAdapterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IColumnsAggregatorAdapterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IColumnsAggregatorAdapterSchema(IColumnsAggregatorAdapterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e345191c-d19b-4e05-ac17-16031da58852");
			Name = "IColumnsAggregatorAdapter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,144,193,106,195,48,12,134,207,13,228,29,68,118,45,241,125,180,133,174,48,200,97,37,176,39,240,82,57,24,98,201,200,206,161,132,190,123,149,53,43,131,210,222,36,125,250,127,137,159,108,192,20,109,135,240,209,126,125,179,203,245,129,201,249,126,20,155,61,83,253,233,7,108,66,100,201,101,49,149,69,89,172,222,4,123,37,0,13,101,20,167,210,119,104,14,60,140,129,210,190,239,149,218,204,178,63,217,168,248,87,97,140,129,77,26,67,176,114,222,45,253,93,12,142,5,4,227,48,215,130,14,5,169,195,4,122,97,147,16,161,211,217,182,90,252,91,97,101,137,165,50,187,250,207,217,252,179,142,227,207,224,59,240,119,247,167,159,129,126,125,100,106,81,146,79,25,41,63,44,174,161,121,65,97,130,203,45,15,164,211,45,146,185,213,217,21,121,191,2,20,83,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e345191c-d19b-4e05-ac17-16031da58852"));
		}

		#endregion

	}

	#endregion

}

