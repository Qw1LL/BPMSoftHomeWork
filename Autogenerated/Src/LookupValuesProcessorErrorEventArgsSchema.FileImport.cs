namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LookupValuesProcessorErrorEventArgsSchema

	/// <exclude/>
	public class LookupValuesProcessorErrorEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LookupValuesProcessorErrorEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LookupValuesProcessorErrorEventArgsSchema(LookupValuesProcessorErrorEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8dbe4f07-e89f-42d7-b44a-3c89f43c4a8f");
			Name = "LookupValuesProcessorErrorEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,144,223,74,195,48,20,198,175,91,216,59,28,216,141,194,216,3,172,120,161,165,202,192,73,161,232,125,76,207,106,176,77,74,254,136,99,248,238,38,105,154,117,195,73,111,66,206,201,249,190,239,228,199,73,135,170,39,20,225,161,220,85,98,175,215,185,224,123,214,24,73,52,19,124,253,200,90,220,118,189,144,122,145,30,23,105,98,20,227,13,84,7,165,177,203,22,169,237,44,37,54,118,18,32,111,137,82,27,120,22,226,211,244,111,164,53,168,74,41,40,42,37,100,33,165,61,190,144,235,123,217,40,175,235,205,123,203,40,80,167,154,35,130,13,76,12,18,183,76,204,182,59,43,45,13,213,66,218,13,74,239,236,67,198,148,25,254,55,79,134,213,96,11,166,15,21,253,192,142,188,110,235,21,88,95,247,99,42,90,211,241,23,75,43,182,58,166,28,12,111,186,130,226,155,98,239,144,185,212,36,193,177,188,5,191,105,82,156,27,195,221,101,84,230,199,242,152,99,39,78,161,195,227,110,146,104,159,167,11,12,3,113,9,103,63,222,253,211,207,128,99,137,188,30,152,133,58,0,180,76,122,148,154,225,223,248,138,232,123,186,29,161,65,157,1,227,26,37,39,45,40,87,133,152,32,243,68,47,63,126,77,23,85,1,239,217,103,103,132,5,217,4,224,127,162,41,136,0,103,218,178,157,95,3,101,96,153,26,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8dbe4f07-e89f-42d7-b44a-3c89f43c4a8f"));
		}

		#endregion

	}

	#endregion

}

