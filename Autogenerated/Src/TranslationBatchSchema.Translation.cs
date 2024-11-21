namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TranslationBatchSchema

	/// <exclude/>
	public class TranslationBatchSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TranslationBatchSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TranslationBatchSchema(TranslationBatchSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("10369cb8-3549-4f33-8ff6-7c40df21ba6d");
			Name = "TranslationBatch";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,143,209,74,195,48,20,134,175,83,232,59,28,240,70,97,180,247,115,238,98,19,100,12,161,176,189,64,140,103,53,152,166,229,36,17,138,248,238,158,36,85,187,205,155,182,252,253,249,191,239,88,217,161,27,164,66,216,52,207,135,254,228,171,109,111,79,186,13,36,189,238,109,117,36,105,157,73,223,101,241,89,22,34,56,109,91,56,140,206,99,199,93,99,80,197,159,174,122,66,139,164,213,125,89,112,235,134,176,229,20,182,70,58,183,132,217,202,70,122,245,150,58,67,120,49,90,129,138,149,171,6,44,225,81,167,101,73,227,202,121,98,234,2,242,123,189,128,221,245,162,96,59,126,254,161,89,202,83,80,190,39,54,104,18,44,55,38,240,241,98,226,54,175,195,59,142,119,16,79,21,98,143,35,60,196,128,175,18,226,107,2,160,125,205,140,115,96,67,253,128,228,53,94,224,234,186,134,149,11,93,199,151,172,127,130,25,60,238,87,191,197,122,222,156,76,39,177,104,147,189,90,244,201,72,12,164,63,164,71,112,83,240,191,98,78,207,67,206,190,1,241,204,122,66,252,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("10369cb8-3549-4f33-8ff6-7c40df21ba6d"));
		}

		#endregion

	}

	#endregion

}

