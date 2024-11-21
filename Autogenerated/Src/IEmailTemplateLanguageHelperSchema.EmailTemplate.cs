namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEmailTemplateLanguageHelperSchema

	/// <exclude/>
	public class IEmailTemplateLanguageHelperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEmailTemplateLanguageHelperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEmailTemplateLanguageHelperSchema(IEmailTemplateLanguageHelperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a06ed1bb-262f-444b-a442-af9c8800a88f");
			Name = "IEmailTemplateLanguageHelper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,146,75,106,195,48,16,134,215,49,248,14,34,171,22,138,117,128,166,94,180,132,212,144,66,105,122,129,169,52,118,5,122,161,199,34,148,220,189,150,252,106,112,183,133,174,132,102,230,159,255,155,145,52,40,244,22,24,146,199,215,151,147,105,67,245,100,116,43,186,232,32,8,163,203,226,171,44,54,209,11,221,145,211,217,7,84,247,101,209,71,40,165,100,231,163,82,224,206,245,120,111,116,64,215,166,86,173,113,196,58,195,208,103,33,104,130,10,132,36,189,220,74,8,216,71,56,241,8,142,125,166,60,51,74,69,45,88,118,36,18,116,23,161,195,106,178,161,63,124,108,252,144,130,17,49,91,53,251,212,249,125,108,124,28,181,207,40,45,186,190,62,209,175,96,115,224,128,129,112,108,33,202,48,91,102,112,143,154,39,170,107,228,68,179,198,25,34,22,28,40,162,251,77,62,108,167,250,134,111,235,253,245,208,130,239,104,46,93,148,14,67,116,218,215,111,249,92,56,4,175,118,116,74,166,234,67,20,60,33,79,3,54,252,38,135,22,187,219,225,97,254,241,176,246,23,229,209,0,71,183,82,251,96,28,254,229,182,238,72,51,255,153,140,48,231,134,107,218,230,230,82,22,151,111,182,14,176,195,32,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a06ed1bb-262f-444b-a442-af9c8800a88f"));
		}

		#endregion

	}

	#endregion

}

