namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnsAggregatorFactorySchema

	/// <exclude/>
	public class ColumnsAggregatorFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnsAggregatorFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnsAggregatorFactorySchema(ColumnsAggregatorFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("32c31bbf-f71f-44eb-9406-7b7d802e4208");
			Name = "ColumnsAggregatorFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,82,209,74,195,48,20,125,238,96,255,112,233,83,11,210,190,171,19,182,105,101,15,142,129,248,36,34,89,123,83,3,105,82,110,18,100,136,255,238,237,102,221,230,44,194,160,105,72,114,238,57,39,231,198,136,6,93,43,74,132,217,234,225,209,74,159,205,173,145,170,14,36,188,178,38,43,148,198,69,211,90,242,227,209,199,120,20,5,167,76,125,128,37,188,250,115,55,43,68,233,45,41,116,124,206,136,60,207,225,90,153,55,36,229,43,91,66,73,40,39,241,98,110,117,104,140,155,214,53,97,45,184,96,87,182,137,243,155,190,200,133,166,17,180,233,215,108,70,99,131,198,59,80,198,35,201,206,187,180,212,49,10,143,80,238,24,65,252,80,246,68,249,1,211,243,45,74,17,180,159,41,83,177,245,196,111,90,180,50,25,244,147,94,192,146,147,130,9,24,158,24,57,8,76,95,152,190,13,107,173,248,146,90,56,7,67,80,184,132,65,61,230,232,210,62,47,182,94,254,20,54,173,68,203,153,193,61,250,147,179,228,201,33,113,243,13,150,93,231,33,28,45,83,216,250,137,134,57,95,191,147,95,145,45,209,57,75,221,195,136,34,37,33,57,166,202,88,125,225,10,238,86,32,188,51,98,173,177,74,98,86,95,33,57,229,60,247,118,255,234,226,180,87,142,78,4,186,110,224,59,236,203,134,188,253,50,144,238,156,125,2,106,135,255,177,47,173,57,91,96,251,39,228,123,154,129,120,58,8,15,254,190,0,14,134,30,76,137,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("32c31bbf-f71f-44eb-9406-7b7d802e4208"));
		}

		#endregion

	}

	#endregion

}

