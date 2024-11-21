namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileUploadExceptionsSchema

	/// <exclude/>
	public class FileUploadExceptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileUploadExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileUploadExceptionsSchema(FileUploadExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("743fae56-f4dc-4ba5-9266-2ebf40deeb69");
			Name = "FileUploadExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,197,146,77,107,194,64,16,134,207,10,254,135,33,94,20,36,185,91,235,161,210,130,80,65,106,219,251,152,76,116,33,217,13,59,155,90,91,252,239,157,77,98,21,68,123,232,215,105,153,217,153,103,222,217,125,53,230,196,5,198,4,55,243,217,194,164,46,156,24,157,170,85,105,209,41,163,195,59,149,209,83,145,25,76,58,237,247,78,187,85,178,210,43,88,108,217,81,126,245,25,31,122,243,220,104,201,203,77,215,210,74,8,48,201,144,121,8,51,124,245,172,133,122,163,219,215,152,40,161,196,159,133,159,82,213,71,81,4,35,46,243,28,237,118,220,196,143,107,2,218,87,129,91,163,3,197,114,90,179,209,176,89,147,134,84,152,192,2,245,23,212,128,195,61,46,58,226,21,229,50,83,49,196,94,206,69,53,48,132,35,101,45,191,245,97,25,163,217,217,50,118,198,202,78,243,10,89,169,63,145,95,37,38,150,208,17,131,146,46,212,242,200,38,5,183,45,72,42,137,32,182,148,94,7,151,164,4,209,216,239,114,186,76,157,41,208,98,14,90,190,240,58,96,145,132,43,10,198,15,196,166,180,50,171,201,132,163,168,170,171,218,154,71,184,52,179,55,221,19,22,53,96,15,234,123,64,171,53,132,37,50,245,52,109,224,222,196,152,169,55,92,10,202,89,49,66,175,41,29,64,112,48,206,39,153,131,65,141,8,78,26,57,188,36,105,70,204,126,147,103,204,74,10,250,125,168,254,100,87,63,124,151,116,82,255,142,68,117,238,56,117,234,196,169,126,145,225,201,241,180,31,117,161,170,249,95,155,240,156,144,63,54,224,57,25,191,101,190,233,153,121,255,100,188,115,114,190,99,186,221,7,223,235,200,124,87,5,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateMaxFileSizeExceededExceptionMessageLocalizableString());
			LocalizableStrings.Add(CreateInvalidFileSizeExceptionMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateMaxFileSizeExceededExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("4f2e8a1b-07d3-4f66-9213-287d5ef48032"),
				Name = "MaxFileSizeExceededExceptionMessage",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("743fae56-f4dc-4ba5-9266-2ebf40deeb69"),
				ModifiedInSchemaUId = new Guid("743fae56-f4dc-4ba5-9266-2ebf40deeb69")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateInvalidFileSizeExceptionMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5880e243-dfed-417c-ae92-4c19a2d2bc78"),
				Name = "InvalidFileSizeExceptionMessage",
				CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa"),
				CreatedInSchemaUId = new Guid("743fae56-f4dc-4ba5-9266-2ebf40deeb69"),
				ModifiedInSchemaUId = new Guid("743fae56-f4dc-4ba5-9266-2ebf40deeb69")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("743fae56-f4dc-4ba5-9266-2ebf40deeb69"));
		}

		#endregion

	}

	#endregion

}

