namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRecordResultHandlerSchema

	/// <exclude/>
	public class IRecordResultHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordResultHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordResultHandlerSchema(IRecordResultHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("52df6bf9-2697-4d65-9203-47d8c0b2315b");
			Name = "IRecordResultHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,144,191,10,194,48,16,135,231,22,250,14,7,46,186,180,187,138,131,46,118,16,138,250,2,49,185,216,64,155,148,252,17,69,124,119,211,196,150,162,14,33,220,221,239,203,125,68,146,22,77,71,40,194,182,58,156,20,183,249,78,73,46,174,78,19,43,148,204,210,103,150,102,105,50,211,120,245,37,148,210,162,230,62,190,132,242,136,84,105,118,68,227,26,187,39,146,53,168,67,182,40,10,88,27,215,182,68,63,54,159,122,228,64,113,176,53,130,14,176,191,122,26,234,136,231,3,93,76,240,206,93,26,65,65,140,47,252,91,12,81,115,244,60,160,173,21,51,75,168,2,29,135,223,98,161,113,246,50,109,72,131,48,128,119,164,206,34,3,194,253,186,193,210,15,58,173,40,26,131,172,119,252,149,76,110,74,48,136,98,213,16,157,47,86,31,43,148,44,138,245,149,63,175,248,169,147,118,150,134,222,27,239,161,126,192,143,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("52df6bf9-2697-4d65-9203-47d8c0b2315b"));
		}

		#endregion

	}

	#endregion

}

