namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DCResolverTemplateValidatorSchema

	/// <exclude/>
	public class DCResolverTemplateValidatorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DCResolverTemplateValidatorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DCResolverTemplateValidatorSchema(DCResolverTemplateValidatorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("787acbf1-2f3a-46bd-87e9-f398e666cb27");
			Name = "DCResolverTemplateValidator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4f82e5e2-fdef-4aa4-baf8-be69c75a6ead");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,85,201,110,219,48,16,61,43,64,254,97,170,94,44,32,160,209,107,19,59,112,236,52,13,144,0,105,149,54,103,70,30,217,68,37,82,33,41,47,45,252,239,29,82,75,44,197,241,37,23,11,228,12,223,188,89,222,88,242,28,77,193,19,132,171,135,251,88,165,150,77,149,76,197,162,212,220,10,37,217,108,43,121,46,18,186,180,40,237,233,201,191,211,147,160,52,66,46,32,222,26,139,57,185,103,25,38,206,215,176,27,148,168,69,114,222,247,185,19,242,229,245,242,53,80,158,43,121,232,254,125,2,236,94,205,49,51,135,30,105,60,124,203,102,87,100,32,211,103,141,11,66,132,105,198,141,249,10,179,233,79,52,42,91,161,126,196,188,200,184,197,223,60,19,115,110,149,246,238,195,225,16,46,76,153,231,92,111,199,245,185,246,64,67,22,68,72,52,166,163,112,54,109,0,60,185,112,56,134,84,105,48,184,200,137,177,207,2,10,173,18,52,134,53,184,195,61,224,162,124,206,68,2,137,163,117,156,85,64,213,167,223,54,147,123,180,75,53,167,92,30,180,88,145,107,101,45,170,3,220,9,99,47,98,116,221,25,195,13,218,111,34,179,168,205,160,199,23,108,125,58,131,95,6,53,21,90,86,253,132,178,115,140,96,228,216,6,65,227,127,201,38,214,106,241,92,82,61,46,217,211,18,53,14,54,228,4,27,118,107,170,96,131,40,242,79,2,86,241,104,236,143,170,182,247,66,68,100,113,180,7,209,121,55,151,149,18,243,182,250,241,75,246,225,92,220,28,7,193,138,187,62,57,102,6,70,251,53,122,197,233,61,116,51,22,4,34,133,193,167,250,33,155,200,45,229,89,35,6,26,109,169,253,84,7,193,174,117,110,124,187,101,136,85,169,19,188,222,20,154,102,195,13,251,36,19,220,68,108,70,37,16,146,252,34,154,224,82,210,23,198,240,165,13,225,88,147,106,13,95,32,177,150,184,134,59,149,80,109,254,242,231,12,99,106,137,92,244,10,203,158,148,254,227,101,206,220,120,185,168,49,77,20,1,156,85,144,65,120,100,240,194,51,8,223,68,48,236,59,55,51,145,166,212,118,105,61,113,52,215,155,4,11,23,240,17,55,150,17,64,137,97,84,125,171,138,4,118,169,213,218,115,190,149,43,23,224,71,137,122,75,144,101,66,117,195,22,96,80,39,24,237,85,114,87,79,63,202,121,37,128,247,212,224,5,85,25,251,42,238,203,184,224,154,231,36,99,160,45,131,163,176,233,123,35,226,121,181,125,32,169,214,79,163,99,202,223,73,249,173,150,171,27,15,218,71,28,55,117,245,192,62,119,58,176,139,161,247,62,252,184,219,197,112,60,145,32,164,177,92,210,190,86,41,216,37,238,47,34,191,237,186,115,79,121,188,141,128,77,145,235,119,199,59,65,196,93,207,12,172,151,40,129,91,200,144,27,11,118,173,90,233,52,200,75,190,66,152,55,51,1,213,160,1,97,115,67,44,218,176,158,73,189,245,58,194,254,168,156,15,44,136,227,66,62,60,81,254,214,253,97,116,174,119,255,1,242,204,113,165,43,7,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateHasDifferentAliasesExceptionTextLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateHasDifferentAliasesExceptionTextLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("0516f4b9-03c3-4a08-80ae-8affa9b34e2b"),
				Name = "HasDifferentAliasesExceptionText",
				CreatedInPackageId = new Guid("4f82e5e2-fdef-4aa4-baf8-be69c75a6ead"),
				CreatedInSchemaUId = new Guid("787acbf1-2f3a-46bd-87e9-f398e666cb27"),
				ModifiedInSchemaUId = new Guid("787acbf1-2f3a-46bd-87e9-f398e666cb27")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("787acbf1-2f3a-46bd-87e9-f398e666cb27"));
		}

		#endregion

	}

	#endregion

}

