namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CompleteFileImportStageSchema

	/// <exclude/>
	public class CompleteFileImportStageSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CompleteFileImportStageSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CompleteFileImportStageSchema(CompleteFileImportStageSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("f9010370-d507-4e89-b413-ae509e726a22");
			Name = "CompleteFileImportStage";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,86,77,79,227,48,16,61,7,137,255,224,45,151,84,170,210,59,208,34,40,101,85,105,129,106,17,167,213,106,101,146,73,177,72,236,200,31,221,173,16,255,125,39,113,210,166,105,156,6,46,109,98,191,121,158,121,243,225,112,154,130,202,104,8,228,102,121,255,36,98,29,204,4,143,217,202,72,170,153,224,193,29,75,96,145,102,66,106,114,122,242,126,122,226,25,197,248,170,6,150,112,209,186,26,220,209,80,11,201,64,225,62,34,206,36,172,144,144,144,89,66,149,58,39,51,145,102,9,104,216,29,240,164,233,10,10,236,120,60,38,151,140,191,130,100,58,18,33,9,37,196,147,193,13,85,77,244,96,60,173,224,202,164,41,149,155,234,125,254,15,66,163,129,132,229,49,36,70,75,194,10,211,202,100,92,179,249,117,11,49,53,137,190,97,60,194,80,124,189,201,64,196,254,162,229,208,225,136,60,160,106,100,66,56,254,33,200,17,202,112,248,27,137,51,243,146,48,12,33,143,218,21,52,57,39,45,231,160,113,46,248,86,185,59,6,73,132,202,45,37,91,83,109,149,242,50,251,66,22,214,112,73,37,250,164,65,170,159,144,9,197,48,3,27,242,135,57,247,46,90,56,230,92,51,141,121,155,189,26,254,166,110,169,166,75,41,214,44,2,89,49,185,17,109,124,63,132,120,51,153,155,205,181,191,199,133,85,169,180,52,121,73,93,203,149,73,129,107,242,172,64,226,58,135,48,47,213,125,4,153,76,9,135,191,109,118,254,192,236,25,14,70,13,166,161,173,88,239,12,120,100,181,47,223,203,68,160,131,25,200,92,128,109,50,72,255,108,116,108,161,207,29,185,34,87,87,249,25,158,231,119,129,38,182,193,108,247,109,130,239,160,47,59,188,153,250,93,34,14,43,37,250,87,200,81,192,46,198,14,80,51,210,46,62,103,188,110,163,175,69,237,172,227,35,219,187,136,157,144,102,188,110,46,103,180,46,147,158,177,186,106,189,6,207,171,189,24,102,165,58,118,176,57,70,90,227,84,178,223,114,35,27,238,98,38,18,147,114,117,189,90,225,113,52,119,41,162,25,86,40,142,237,98,3,131,8,65,41,33,135,214,224,156,188,224,156,244,27,100,135,104,242,78,62,62,209,195,181,168,62,121,245,84,42,136,53,72,137,114,147,6,74,205,185,73,73,241,184,136,242,74,104,219,15,28,26,30,73,205,61,232,87,225,188,16,214,130,69,219,228,88,82,191,57,7,72,182,125,68,201,10,137,31,132,102,241,230,145,87,150,126,13,82,12,100,239,22,118,140,143,168,97,241,157,64,147,188,230,14,192,31,45,62,29,156,208,195,43,22,19,255,219,110,57,120,0,136,158,80,22,203,85,161,60,9,218,72,110,221,196,163,241,119,77,101,121,233,23,80,214,217,66,21,100,234,91,58,239,203,23,200,232,24,65,115,128,35,69,45,234,82,233,125,199,3,27,236,156,71,126,213,180,109,242,118,165,167,135,210,53,145,171,249,153,127,232,152,36,177,62,185,175,146,224,57,139,104,91,193,116,152,88,103,243,178,175,153,5,101,11,96,43,163,235,139,104,143,198,61,212,75,178,190,68,174,121,217,151,230,163,119,115,10,141,85,1,209,23,231,75,101,222,61,98,174,200,130,163,175,152,232,114,8,246,201,117,99,58,28,36,206,182,211,46,249,45,33,151,107,251,42,224,218,127,108,69,167,149,87,12,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateCompleteRemindingSubjectLocalizableString());
			LocalizableStrings.Add(CreateNotImportedRowsCountMessageTemplateLocalizableString());
			LocalizableStrings.Add(CreateCompleteRemindingDescriptionTemplateLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateCompleteRemindingSubjectLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("6f65dc87-b8f6-49d8-8bf6-3ac2dbbdbbb6"),
				Name = "CompleteRemindingSubject",
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab"),
				CreatedInSchemaUId = new Guid("f9010370-d507-4e89-b413-ae509e726a22"),
				ModifiedInSchemaUId = new Guid("f9010370-d507-4e89-b413-ae509e726a22")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNotImportedRowsCountMessageTemplateLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("844066a9-4ae1-4da8-a4c2-43d603e52b7d"),
				Name = "NotImportedRowsCountMessageTemplate",
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab"),
				CreatedInSchemaUId = new Guid("f9010370-d507-4e89-b413-ae509e726a22"),
				ModifiedInSchemaUId = new Guid("f9010370-d507-4e89-b413-ae509e726a22")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateCompleteRemindingDescriptionTemplateLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a5398abd-87e5-4737-9e25-5cb7b840b6bb"),
				Name = "CompleteRemindingDescriptionTemplate",
				CreatedInPackageId = new Guid("28117f91-27b8-43f6-8b95-0e32534298ab"),
				CreatedInSchemaUId = new Guid("f9010370-d507-4e89-b413-ae509e726a22"),
				ModifiedInSchemaUId = new Guid("f9010370-d507-4e89-b413-ae509e726a22")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("f9010370-d507-4e89-b413-ae509e726a22"));
		}

		#endregion

	}

	#endregion

}

