namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EmailTemplateUserTaskContactLanguageRuleSchema

	/// <exclude/>
	public class EmailTemplateUserTaskContactLanguageRuleSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EmailTemplateUserTaskContactLanguageRuleSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EmailTemplateUserTaskContactLanguageRuleSchema(EmailTemplateUserTaskContactLanguageRuleSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("93d56a0b-3d90-4502-a157-7f5bc05c865d");
			Name = "EmailTemplateUserTaskContactLanguageRule";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6b752d82-945c-4729-b067-d3f384b1bc2d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,84,75,111,155,64,16,62,19,41,255,97,74,47,182,100,193,221,47,41,69,86,100,169,110,221,216,237,125,3,3,94,21,118,233,62,82,161,42,255,189,179,44,56,134,180,145,115,177,52,195,55,243,61,24,44,88,133,186,102,41,194,167,253,238,32,115,19,37,82,228,188,176,138,25,46,197,237,205,159,219,155,192,106,46,10,56,52,218,96,181,56,215,137,84,56,172,162,141,48,220,112,212,212,166,7,31,21,22,180,3,146,146,105,61,39,132,48,44,53,159,153,40,44,43,240,193,150,216,194,226,56,134,165,182,85,197,84,179,238,234,118,100,6,230,196,12,212,74,62,241,12,53,148,221,36,228,74,86,144,250,117,29,72,163,1,46,0,43,198,75,32,153,117,201,12,130,213,168,192,48,253,19,208,41,107,162,158,46,190,224,171,237,99,201,83,72,29,37,108,220,130,99,55,255,157,198,143,52,253,15,229,48,135,237,208,73,64,73,209,239,217,245,94,201,26,149,75,99,14,251,150,194,63,31,219,109,27,142,201,57,18,152,186,216,157,206,215,66,123,165,14,156,156,177,227,210,189,176,32,40,208,44,92,40,238,5,5,207,157,50,20,153,23,55,84,74,195,218,40,155,26,169,174,209,154,40,164,108,52,197,173,13,19,116,57,50,39,16,34,164,10,243,85,120,109,130,97,188,254,143,205,182,83,51,197,42,16,116,158,171,208,14,28,134,235,113,90,203,184,69,95,102,116,173,138,201,40,189,33,213,180,75,115,4,90,141,96,215,132,188,67,115,146,217,53,249,126,125,52,140,178,125,57,119,58,126,186,222,156,147,233,247,95,254,91,25,115,113,66,197,77,38,83,136,47,195,187,183,60,131,123,60,7,181,205,38,109,203,127,68,15,152,74,149,109,179,62,156,39,166,0,245,47,74,69,224,111,104,255,2,154,67,122,34,65,223,44,170,102,148,112,116,9,216,49,65,235,213,12,194,238,213,132,211,197,121,103,239,63,145,165,173,196,23,186,4,162,32,162,232,46,203,124,111,18,246,10,163,109,22,78,35,135,241,243,158,164,79,170,171,252,52,249,242,245,72,216,108,108,207,111,226,57,76,134,107,62,144,81,91,150,189,253,64,161,177,74,12,185,28,203,177,169,177,19,250,131,149,22,151,46,195,245,228,181,173,142,137,14,232,101,155,195,70,155,170,54,205,27,199,229,187,195,230,243,95,242,250,129,14,210,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("93d56a0b-3d90-4502-a157-7f5bc05c865d"));
		}

		#endregion

	}

	#endregion

}

