namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFileUploadConfigSchema

	/// <exclude/>
	public class IFileUploadConfigSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFileUploadConfigSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFileUploadConfigSchema(IFileUploadConfigSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("07726079-cc74-4f50-957e-970e32ab99e4");
			Name = "IFileUploadConfig";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,203,106,195,48,16,60,59,144,127,88,210,187,125,239,35,135,26,2,62,4,2,166,31,32,203,43,35,144,180,70,15,104,18,242,239,149,172,52,49,166,166,58,73,179,51,154,97,214,48,141,110,100,28,225,243,116,108,73,248,178,38,35,228,16,44,243,146,76,121,144,10,191,70,69,172,135,235,118,179,221,20,47,22,135,56,128,198,120,180,34,9,155,39,39,107,39,222,24,58,37,57,200,117,26,188,206,177,198,8,186,91,60,60,78,150,70,180,94,162,203,120,85,85,240,238,130,214,204,158,247,191,64,58,71,246,13,34,126,5,78,94,48,122,66,119,246,232,64,144,133,144,195,63,228,213,92,223,35,151,154,169,164,79,73,218,164,190,194,128,254,13,110,255,88,54,14,28,122,224,193,121,210,192,73,5,109,92,249,183,77,71,164,160,69,95,79,228,58,115,15,54,93,167,34,158,150,69,177,106,218,24,231,153,137,69,146,136,67,68,224,22,197,199,110,81,225,174,218,175,132,88,118,189,172,254,158,33,54,53,173,0,77,159,183,16,95,185,139,57,20,145,31,173,63,58,172,58,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("07726079-cc74-4f50-957e-970e32ab99e4"));
		}

		#endregion

	}

	#endregion

}

