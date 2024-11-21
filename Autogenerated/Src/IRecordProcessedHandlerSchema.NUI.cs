namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IRecordProcessedHandlerSchema

	/// <exclude/>
	public class IRecordProcessedHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IRecordProcessedHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IRecordProcessedHandlerSchema(IRecordProcessedHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("19ec078f-2d2a-4581-b154-931f817b018f");
			Name = "IRecordProcessedHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("db43ba5c-9334-4bce-a1f8-d5a6f72577ed");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,65,106,195,48,16,69,215,9,228,14,131,187,105,161,216,251,52,53,164,37,208,44,2,166,61,129,34,141,109,21,91,50,35,57,164,148,222,189,146,44,155,212,77,64,24,102,252,231,235,205,151,98,45,154,142,113,132,151,226,240,161,75,155,190,106,85,202,170,39,102,165,86,240,189,90,46,220,185,35,172,124,185,87,22,169,116,242,53,236,223,145,107,18,5,105,142,198,160,120,99,74,52,72,171,165,147,103,89,6,27,211,183,45,163,175,60,214,211,40,232,18,108,141,64,97,30,186,209,0,234,193,33,29,13,178,11,135,174,63,54,146,131,156,76,110,92,239,129,157,124,2,62,160,173,181,48,107,40,130,193,240,115,142,23,26,163,65,169,233,58,30,158,80,89,15,247,159,110,17,58,29,35,214,130,114,137,62,39,6,149,64,74,242,221,25,121,31,146,228,218,177,159,109,186,201,130,238,250,24,163,202,36,249,86,8,233,103,88,227,22,118,60,237,240,22,49,183,217,226,145,235,210,246,164,165,136,251,204,196,247,250,248,137,220,194,128,247,56,247,218,121,171,173,99,0,15,242,240,20,179,116,226,33,206,80,255,132,239,223,166,235,253,2,97,235,134,41,74,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("19ec078f-2d2a-4581-b154-931f817b018f"));
		}

		#endregion

	}

	#endregion

}

