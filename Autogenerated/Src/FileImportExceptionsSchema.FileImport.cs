namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileImportExceptionsSchema

	/// <exclude/>
	public class FileImportExceptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileImportExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileImportExceptionsSchema(FileImportExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d8637c44-884d-415b-8ad0-91caafbca065");
			Name = "FileImportExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,82,77,107,194,64,16,61,43,248,31,134,244,162,80,146,187,85,15,85,75,133,218,74,45,189,143,113,18,23,178,187,97,119,131,181,197,255,222,201,135,223,57,20,138,120,73,216,183,111,222,188,153,125,10,37,217,20,67,130,199,217,116,174,35,231,15,181,138,68,156,25,116,66,43,255,73,36,52,145,169,54,174,213,252,105,53,27,153,21,42,134,249,198,58,146,15,251,243,161,86,74,173,24,231,155,59,67,49,43,192,48,65,107,187,48,150,169,219,60,19,46,201,140,191,66,74,115,245,130,23,4,1,244,108,38,37,154,205,160,58,127,172,8,104,199,2,183,66,7,194,242,223,232,181,130,245,138,20,68,236,11,150,154,44,40,237,32,212,202,161,80,128,176,42,58,248,59,221,224,72,56,205,22,137,8,33,204,253,212,218,129,46,188,102,73,242,102,138,203,35,151,13,158,156,191,135,145,180,178,206,100,161,211,134,39,155,21,186,37,227,124,152,2,24,26,66,199,78,5,87,161,226,85,235,8,220,38,37,102,18,65,104,40,234,123,117,126,188,96,144,15,114,57,73,137,164,104,80,130,226,7,236,123,150,173,96,76,222,224,157,172,206,12,247,168,16,191,23,20,188,162,172,218,64,93,175,246,100,87,57,47,11,119,2,157,188,176,209,133,5,90,106,43,90,195,139,14,49,17,223,184,72,152,106,248,245,219,21,243,30,188,67,90,246,194,214,99,252,162,198,250,117,38,166,100,109,238,249,19,147,140,188,78,7,242,196,53,182,213,242,73,45,203,253,23,231,18,61,3,235,50,55,66,135,215,75,220,146,213,255,152,182,19,35,55,207,218,137,155,171,38,109,116,220,233,54,57,59,177,240,223,148,109,127,1,139,154,152,97,52,5,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateEmptyHeaderExceptionMessageLocalizableString());
			LocalizableStrings.Add(CreateEmptyDataExceptionMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateEmptyHeaderExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e8ba9ed7-7f74-43c3-9ac9-e0f6b8e886fc"),
				Name = "EmptyHeaderExceptionMessage",
				CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e"),
				CreatedInSchemaUId = new Guid("d8637c44-884d-415b-8ad0-91caafbca065"),
				ModifiedInSchemaUId = new Guid("d8637c44-884d-415b-8ad0-91caafbca065")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateEmptyDataExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1d2b6f72-8681-4848-a93e-39afafa9f2f2"),
				Name = "EmptyDataExceptionMessage",
				CreatedInPackageId = new Guid("52abf94a-4a51-4e9b-afae-86480a04ff1e"),
				CreatedInSchemaUId = new Guid("d8637c44-884d-415b-8ad0-91caafbca065"),
				ModifiedInSchemaUId = new Guid("d8637c44-884d-415b-8ad0-91caafbca065")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d8637c44-884d-415b-8ad0-91caafbca065"));
		}

		#endregion

	}

	#endregion

}

