namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailTemplateLanguageHandlerSchema

	/// <exclude/>
	public class EmailTemplateLanguageHandlerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailTemplateLanguageHandlerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailTemplateLanguageHandlerSchema(EmailTemplateLanguageHandlerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce5d036c-9766-420e-a3b2-131f211f241e");
			Name = "EmailTemplateLanguageHandler";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("91d5b8ed-2389-4812-9e17-f329888285e6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,84,219,74,3,49,16,125,110,161,255,48,212,23,11,181,251,174,181,224,13,20,90,40,182,63,48,221,157,174,193,108,178,102,18,161,72,255,221,236,110,178,182,85,170,34,248,150,153,204,156,156,57,103,118,21,22,196,37,166,4,215,243,217,66,175,237,232,70,171,181,200,157,65,43,180,234,117,223,122,221,94,183,115,98,40,247,33,220,72,100,62,135,187,2,133,92,82,81,74,180,52,69,149,59,204,233,30,85,38,201,212,245,73,146,192,152,93,81,160,217,76,66,124,165,0,87,108,13,166,22,232,172,66,0,27,32,64,6,12,48,148,146,120,37,51,138,32,201,1,202,216,144,15,159,121,114,75,44,114,69,25,32,3,66,250,132,66,129,94,123,0,46,181,98,177,18,82,216,205,104,156,196,250,216,111,55,37,149,104,176,0,229,103,191,236,47,31,233,197,17,219,254,100,233,111,26,136,58,225,123,219,218,99,221,236,228,94,115,21,31,246,150,110,37,69,250,49,127,90,233,120,84,198,113,228,53,132,240,70,133,211,184,209,218,49,55,186,36,99,5,121,79,230,245,19,205,253,161,252,117,98,225,210,148,152,117,173,237,103,113,35,199,95,146,250,128,5,79,174,211,233,228,100,47,234,3,135,195,54,112,38,149,53,180,247,103,152,145,125,210,217,79,6,104,72,112,235,207,215,99,212,153,93,139,66,121,127,18,184,123,111,90,95,226,74,89,103,20,251,130,224,93,76,236,200,242,42,140,117,40,227,220,129,204,105,20,36,146,26,4,21,26,132,88,21,46,135,160,156,148,131,93,85,254,119,208,114,167,58,126,123,83,141,25,153,63,170,211,46,246,55,242,12,225,161,93,173,250,221,246,23,208,132,149,54,95,174,75,35,215,126,114,251,14,145,247,67,198,189,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce5d036c-9766-420e-a3b2-131f211f241e"));
		}

		#endregion

	}

	#endregion

}

