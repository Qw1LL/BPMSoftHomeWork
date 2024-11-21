namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingHandlerSchema

	/// <exclude/>
	public class IMailingHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingHandlerSchema(IMailingHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e6d073d5-261f-4fd0-a166-ab3452299b92");
			Name = "IMailingHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("0a66fb70-43c4-43cd-a81c-f036ca2264c0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,177,78,195,48,16,134,231,70,202,59,156,218,5,150,120,47,165,3,93,200,16,41,2,241,0,38,57,39,150,98,59,58,59,145,16,226,221,113,237,38,184,148,133,37,210,253,119,255,239,207,231,104,174,208,142,188,65,120,170,171,87,35,92,113,50,90,200,110,34,238,164,209,121,246,153,103,155,201,74,221,37,3,132,15,121,230,245,29,97,231,135,160,212,14,73,248,144,61,148,21,151,131,159,126,230,186,29,144,194,24,99,12,14,118,82,138,211,199,241,82,215,100,102,217,162,5,185,120,65,24,2,215,35,168,152,0,125,140,40,150,4,150,68,140,211,251,32,155,196,124,115,238,198,131,251,239,202,88,161,235,77,107,247,80,7,107,108,254,38,11,194,137,144,187,64,102,29,215,62,219,136,192,149,240,220,2,69,101,228,196,21,104,191,211,199,237,100,145,252,46,53,54,231,69,110,143,101,18,119,238,65,179,54,139,3,11,206,16,52,27,217,94,24,22,203,221,219,85,86,176,255,148,247,241,49,254,190,204,11,42,51,255,251,50,129,33,90,87,134,229,152,29,234,54,238,52,212,95,241,79,184,18,189,246,13,205,235,120,58,88,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e6d073d5-261f-4fd0-a166-ab3452299b92"));
		}

		#endregion

	}

	#endregion

}

