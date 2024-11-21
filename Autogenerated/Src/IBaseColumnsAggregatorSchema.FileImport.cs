namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IBaseColumnsAggregatorSchema

	/// <exclude/>
	public class IBaseColumnsAggregatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IBaseColumnsAggregatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IBaseColumnsAggregatorSchema(IBaseColumnsAggregatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("bf20cba9-3c75-48fd-bbc1-dd610d81de84");
			Name = "IBaseColumnsAggregator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,80,205,106,195,48,12,62,47,144,119,16,61,109,48,226,251,150,5,214,178,65,14,131,178,193,238,106,170,4,67,108,7,201,46,148,209,119,95,98,39,109,216,110,150,244,253,218,162,33,25,176,33,216,238,63,190,92,235,139,157,179,173,238,2,163,215,206,22,239,186,167,218,12,142,125,158,253,228,217,157,82,10,74,9,198,32,159,171,121,254,164,129,73,200,122,129,3,10,65,27,108,51,145,177,215,254,12,173,99,104,92,31,140,21,192,174,99,234,208,59,94,164,212,74,107,8,135,94,55,160,173,39,110,167,72,245,118,148,219,37,238,235,149,10,79,80,239,217,53,36,66,199,111,236,3,201,56,158,244,145,248,17,234,91,224,68,156,145,111,204,238,207,153,9,253,162,62,186,79,237,254,213,139,139,132,20,208,145,55,151,41,174,240,117,133,180,25,144,209,128,29,191,246,101,147,208,49,230,166,74,110,112,154,166,162,84,17,119,163,49,249,192,86,170,148,111,241,41,213,178,159,128,235,106,115,176,52,220,175,47,209,110,22,136,239,135,231,145,124,201,179,203,47,111,246,243,68,240,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("bf20cba9-3c75-48fd-bbc1-dd610d81de84"));
		}

		#endregion

	}

	#endregion

}

