namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FormulaCalculationServiceSchema

	/// <exclude/>
	public class FormulaCalculationServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FormulaCalculationServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FormulaCalculationServiceSchema(FormulaCalculationServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb");
			Name = "FormulaCalculationService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,86,109,111,219,54,16,254,172,2,253,15,132,247,69,6,2,253,128,44,9,144,164,78,234,109,142,3,171,67,129,101,197,64,75,103,91,43,37,106,36,229,212,107,243,223,119,71,82,146,109,249,37,193,154,97,95,108,233,120,239,247,60,71,21,60,7,93,242,4,216,213,253,40,150,51,19,93,203,98,150,205,43,197,77,38,139,232,70,170,188,18,252,237,155,175,111,223,4,149,206,138,57,139,87,218,64,254,227,214,59,218,9,1,9,25,233,232,22,10,80,89,210,209,185,3,211,145,77,170,194,100,57,68,49,90,112,145,253,109,227,118,180,240,116,153,37,48,146,41,136,131,135,209,71,152,30,86,184,196,36,151,91,81,234,226,209,24,11,201,243,93,103,215,82,65,221,143,195,167,209,59,110,248,189,146,203,44,5,165,55,222,92,119,245,62,123,158,24,169,50,208,71,252,15,190,36,80,218,86,31,42,161,46,123,34,43,131,26,173,234,29,60,26,180,37,237,159,180,45,21,143,126,80,48,71,143,236,90,112,173,79,153,15,117,205,69,130,127,20,171,246,134,120,65,99,176,70,15,84,27,214,100,20,102,254,9,5,101,53,21,89,194,18,114,114,220,7,59,101,27,112,235,132,8,16,118,248,219,36,119,147,129,72,49,187,123,69,35,116,57,4,165,123,97,114,250,39,2,144,253,161,64,87,130,128,102,45,161,72,157,241,166,39,140,171,141,170,168,223,232,206,102,237,189,185,10,142,230,30,246,217,87,246,244,66,155,102,112,12,234,167,62,57,8,78,217,148,227,121,43,109,157,239,171,0,33,85,130,50,136,150,205,2,236,76,70,144,79,65,133,119,72,111,118,206,122,174,37,189,254,167,181,108,125,187,38,246,136,17,191,131,96,14,248,196,20,152,74,21,77,35,41,17,60,211,116,102,159,130,108,198,194,37,23,21,176,76,51,12,7,31,144,193,253,250,52,240,134,24,152,224,133,157,94,98,158,13,193,97,108,3,59,7,39,172,128,71,171,214,28,171,24,12,225,85,55,254,2,10,65,205,229,230,61,47,82,65,24,62,103,93,97,52,212,178,149,122,227,167,126,52,129,82,224,138,11,123,191,247,122,39,12,199,78,186,131,188,52,171,62,145,130,148,24,8,132,99,183,0,155,100,173,100,255,236,239,238,209,56,233,150,240,185,188,242,124,130,25,199,200,107,204,5,154,217,67,172,203,174,204,9,214,233,247,112,169,75,92,178,200,255,18,125,79,51,145,153,213,4,254,170,50,5,57,20,70,135,235,47,180,14,177,196,35,38,164,21,121,65,218,127,62,199,145,219,87,8,233,166,186,109,42,143,192,44,228,94,46,187,33,177,91,74,108,109,65,12,148,146,106,4,90,243,57,132,94,231,51,172,106,232,121,224,254,170,237,162,45,220,117,132,183,145,249,69,38,246,110,153,10,136,173,85,216,219,155,56,66,132,92,218,161,63,109,102,117,124,161,97,172,134,227,13,235,189,217,24,233,138,72,117,124,208,84,205,142,109,176,89,9,145,227,248,86,233,88,7,182,79,195,98,38,113,190,53,168,125,219,80,210,232,71,241,66,42,227,15,54,64,254,29,171,223,81,101,77,66,38,252,92,72,248,115,59,199,37,87,173,114,227,253,252,149,218,113,16,100,219,25,118,187,84,207,170,147,240,122,15,247,45,241,150,5,235,27,220,34,133,92,173,115,59,120,192,171,125,88,44,229,103,8,157,25,109,246,251,113,252,1,17,75,4,5,109,220,230,67,57,170,250,10,156,200,94,244,164,230,82,59,162,103,203,186,146,233,42,54,43,1,27,106,141,52,250,168,120,89,250,149,240,236,27,144,213,71,13,125,103,206,164,129,4,238,28,220,64,113,178,128,156,211,245,117,194,110,171,44,197,59,41,145,42,29,166,46,183,119,153,165,54,87,171,51,103,118,226,175,179,11,150,44,120,49,7,100,153,168,242,66,215,16,48,106,85,79,158,192,213,236,119,187,149,221,103,215,138,22,197,217,112,171,4,169,46,66,63,244,160,249,54,134,144,144,232,66,116,191,238,194,205,253,115,178,163,164,166,154,237,116,219,80,77,159,124,131,234,171,234,37,155,161,1,187,191,228,207,125,225,30,196,206,227,19,75,184,73,22,44,236,186,219,185,160,30,23,80,176,150,100,209,16,11,85,173,38,125,17,100,212,141,171,213,111,160,228,160,67,198,125,228,222,185,60,214,86,70,189,177,45,61,41,4,173,80,23,164,87,55,199,44,148,124,180,189,65,196,222,208,77,218,184,60,59,218,173,139,54,90,45,114,104,11,130,247,198,148,177,225,166,210,215,116,29,14,11,3,170,224,130,28,96,237,148,80,255,181,154,57,198,8,51,33,31,91,225,183,111,236,144,193,165,154,87,116,115,143,43,51,158,77,8,93,175,52,131,24,63,214,72,27,82,72,255,191,19,120,201,173,251,111,179,63,220,190,254,158,90,174,120,234,215,247,118,9,135,82,253,46,35,28,22,248,129,155,165,131,47,37,46,6,106,206,127,61,199,110,237,47,251,188,70,245,127,0,173,117,209,254,195,16,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateFormulaErrorDivisionByZeroLocalizableString());
			LocalizableStrings.Add(CreateFormulaErrorInvalidExpressionLocalizableString());
			LocalizableStrings.Add(CreateFormulaErrorSizeExceededLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateFormulaErrorDivisionByZeroLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2803ac41-a52f-49a0-9401-5d8ea0a163c6"),
				Name = "FormulaErrorDivisionByZero",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"),
				ModifiedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFormulaErrorInvalidExpressionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("dc7e4609-6ddd-4c7b-8ad4-b56900b4b4d5"),
				Name = "FormulaErrorInvalidExpression",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"),
				ModifiedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFormulaErrorSizeExceededLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("9e2fbf3c-ae0a-4801-aa90-f7fb21b38026"),
				Name = "FormulaErrorSizeExceeded",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"),
				ModifiedInSchemaUId = new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dbc5a0bb-9cca-4395-8de4-81203bdde4cb"));
		}

		#endregion

	}

	#endregion

}

