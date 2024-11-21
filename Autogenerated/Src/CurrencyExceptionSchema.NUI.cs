namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CurrencyExceptionSchema

	/// <exclude/>
	public class CurrencyExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CurrencyExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CurrencyExceptionSchema(CurrencyExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf");
			Name = "CurrencyException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,205,86,77,111,218,64,16,61,19,41,255,97,228,244,0,18,50,119,74,56,20,37,41,82,146,162,16,245,208,219,98,15,176,173,189,235,238,174,33,36,202,127,239,216,107,27,131,109,8,109,34,21,9,193,174,103,103,222,124,188,183,22,44,68,29,49,15,225,203,228,110,42,231,198,29,73,49,231,139,88,49,195,165,112,71,177,82,40,188,205,213,147,135,81,178,115,126,246,114,126,214,138,53,23,11,152,110,180,193,240,115,177,30,201,48,148,130,214,180,115,161,112,65,230,48,10,152,214,125,40,252,40,37,213,29,106,205,22,248,21,131,8,85,106,221,235,245,96,160,227,48,100,106,51,204,214,19,37,87,220,71,13,177,225,1,55,27,8,209,44,165,175,97,46,21,172,165,250,149,132,92,115,179,4,76,156,210,227,212,43,200,57,152,37,130,151,69,116,115,247,189,146,127,46,12,42,193,2,208,134,242,244,192,75,80,30,4,217,74,210,46,178,186,179,80,250,4,146,175,152,193,52,137,74,22,233,198,3,154,88,9,13,129,244,88,192,159,217,44,64,138,170,18,240,70,238,66,79,160,86,177,218,157,136,41,22,130,160,118,93,58,218,72,69,230,206,240,1,181,140,21,53,47,219,113,7,189,212,174,254,88,9,193,52,5,112,79,219,206,240,182,10,44,177,175,250,82,54,147,225,160,151,255,75,30,69,241,44,160,10,102,133,204,28,220,160,41,23,241,17,195,40,160,50,181,199,57,226,169,5,156,3,239,230,7,107,49,118,32,45,126,107,197,148,45,216,158,91,184,4,129,107,184,221,63,219,46,188,59,149,57,118,186,169,203,214,39,167,114,76,187,47,181,48,94,221,239,44,136,209,233,36,19,223,106,217,34,212,2,114,31,101,134,192,218,190,218,249,184,64,225,219,1,74,86,244,181,251,229,237,102,230,220,75,115,45,99,225,151,152,216,64,156,71,154,126,204,173,136,11,204,0,215,244,171,228,90,192,122,137,162,224,6,16,191,132,225,115,142,10,124,73,84,19,210,16,189,40,10,208,84,26,235,103,201,4,53,138,244,0,183,54,26,77,45,175,178,97,216,165,83,5,57,244,225,62,14,130,111,234,42,140,76,89,90,18,146,149,105,70,90,68,115,17,123,212,198,132,107,169,243,172,116,245,100,27,11,110,120,210,57,194,201,210,161,224,228,129,9,175,144,133,129,70,210,6,133,243,75,167,17,159,211,27,218,20,62,152,144,121,27,198,190,51,28,85,91,178,115,56,171,108,35,230,3,212,186,137,185,95,180,124,236,119,210,233,237,195,140,105,108,239,17,117,203,152,146,125,70,191,215,188,242,123,243,122,68,20,35,187,200,5,162,194,182,125,173,56,33,145,227,178,112,80,209,233,227,54,9,85,85,57,42,21,207,142,236,201,129,213,49,247,90,170,144,153,118,29,172,157,218,54,201,195,137,226,48,73,230,4,233,78,187,165,88,196,171,223,49,11,244,15,84,242,234,201,188,159,90,68,121,20,8,40,76,34,17,152,6,130,103,138,244,118,61,56,0,118,43,16,39,171,194,251,106,194,113,140,255,163,72,84,14,23,29,179,87,125,145,85,195,13,95,62,186,74,239,186,225,1,13,58,94,163,183,115,57,187,141,179,183,128,29,216,93,144,179,159,232,25,72,17,117,224,68,249,234,238,123,179,110,182,162,246,207,146,86,255,206,243,33,185,91,193,203,44,63,94,243,38,71,59,252,247,34,152,102,84,105,206,27,164,177,225,205,137,44,255,0,9,98,159,225,205,12,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCurrencyNotFoundExceptionMessageLocalizableString());
			LocalizableStrings.Add(CreateCurrencyParameterLessOrEqualsZeroExceptionMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCurrencyNotFoundExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a74da309-e90a-4cbe-9b82-2327571ebd4e"),
				Name = "CurrencyNotFoundExceptionMessage",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf"),
				ModifiedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateCurrencyParameterLessOrEqualsZeroExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("47fc8d47-9788-470a-afd5-51c6e1736e59"),
				Name = "CurrencyParameterLessOrEqualsZeroExceptionMessage",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf"),
				ModifiedInSchemaUId = new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("28996e92-7c7b-4a20-a9f3-7bfa09f7eaaf"));
		}

		#endregion

	}

	#endregion

}

