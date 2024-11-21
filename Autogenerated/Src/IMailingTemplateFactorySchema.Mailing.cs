namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingTemplateFactorySchema

	/// <exclude/>
	public class IMailingTemplateFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingTemplateFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingTemplateFactorySchema(IMailingTemplateFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("097b8032-3d21-4484-aa49-cf8ba99707c8");
			Name = "IMailingTemplateFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("5d774dd3-3f0d-4e5d-9409-9a3b17d3417e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,145,65,75,196,48,16,133,207,91,232,127,24,214,139,94,54,247,117,237,193,5,161,135,66,81,255,64,76,39,221,64,51,41,147,84,88,196,255,110,218,100,69,43,130,158,202,188,153,190,247,61,66,210,162,31,165,66,184,111,155,39,167,195,238,232,72,155,126,98,25,140,163,178,120,43,139,178,216,92,49,246,113,132,154,2,178,142,231,123,168,27,105,6,67,253,51,218,113,144,1,31,164,10,142,207,203,185,16,2,14,126,178,86,242,185,202,115,203,238,213,116,232,193,98,56,185,206,131,118,12,138,49,230,80,15,134,124,144,164,76,220,59,13,225,132,241,127,196,121,175,239,182,235,168,173,168,118,151,20,241,37,102,156,94,6,163,162,87,134,252,157,113,147,106,125,246,106,18,211,30,218,197,34,45,197,170,197,34,28,103,226,72,153,129,241,239,184,63,121,147,194,24,38,38,95,61,166,239,127,157,15,226,98,48,59,174,47,50,111,157,61,175,111,110,115,113,164,46,117,95,230,247,244,202,223,196,168,125,0,229,21,237,152,30,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("097b8032-3d21-4484-aa49-cf8ba99707c8"));
		}

		#endregion

	}

	#endregion

}

