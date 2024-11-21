namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AnniversaryRemindingTextFormerSchema

	/// <exclude/>
	public class AnniversaryRemindingTextFormerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AnniversaryRemindingTextFormerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AnniversaryRemindingTextFormerSchema(AnniversaryRemindingTextFormerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c");
			Name = "AnniversaryRemindingTextFormer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,189,87,109,111,219,54,16,254,172,2,253,15,132,186,1,50,230,202,73,251,45,77,2,164,78,90,20,168,219,160,246,6,12,195,62,208,210,217,230,34,145,30,73,185,243,218,252,247,29,69,74,166,94,162,120,107,177,111,226,241,238,185,231,94,120,164,56,205,65,109,105,2,228,245,237,108,46,86,58,158,10,190,98,235,66,82,205,4,127,250,228,203,211,39,65,161,24,95,147,249,94,105,200,95,181,214,168,159,101,144,24,101,21,191,5,14,146,37,29,157,247,140,255,217,17,46,224,47,125,16,78,133,132,248,134,107,166,25,168,131,248,192,74,66,159,52,207,5,71,57,238,60,147,176,70,18,100,154,81,165,206,200,21,231,108,7,82,81,185,255,4,57,227,41,218,25,143,111,132,204,65,150,22,147,201,132,156,171,34,207,81,231,210,173,111,165,216,177,20,20,201,65,111,68,170,136,22,100,133,38,36,244,0,67,34,43,72,84,64,80,146,82,77,99,82,97,78,60,208,109,177,204,88,66,18,195,234,17,82,228,140,188,235,229,26,152,34,212,1,190,97,144,165,24,225,173,100,59,170,161,12,37,216,74,161,177,10,144,34,53,154,10,158,237,201,207,10,36,22,147,219,226,180,150,54,103,193,51,224,169,133,117,235,42,137,88,77,45,139,68,11,105,60,149,49,56,71,54,158,225,72,162,150,239,162,177,28,145,50,158,160,165,116,209,82,51,229,14,238,135,121,206,108,149,58,201,40,23,4,67,48,221,242,22,244,85,146,136,130,107,143,245,130,233,12,162,138,138,4,93,72,110,52,223,139,132,102,236,111,186,204,96,94,154,71,97,169,234,16,22,144,111,51,196,14,71,62,189,174,67,12,67,211,228,91,28,58,132,255,238,240,181,72,247,145,83,192,254,132,113,165,205,241,204,87,60,188,125,83,58,170,77,11,93,148,41,59,32,93,211,253,21,79,103,232,97,19,25,77,75,37,216,81,73,150,232,164,197,212,154,247,132,101,8,245,71,85,66,73,80,69,166,209,218,114,138,45,159,168,199,195,184,201,119,108,35,122,229,39,214,130,13,167,172,219,20,71,165,172,10,187,213,17,131,97,247,119,79,192,184,38,123,160,82,117,82,254,43,74,253,92,59,30,9,38,66,210,234,188,184,178,59,129,138,74,168,227,50,218,34,100,51,106,19,57,246,189,12,101,53,8,250,243,218,205,129,219,67,115,81,200,4,62,180,178,153,181,13,144,242,15,97,7,70,197,95,124,132,251,248,23,154,21,16,54,18,84,135,204,225,51,233,18,105,142,156,248,147,131,155,227,156,163,107,24,151,72,1,134,176,216,111,241,172,198,198,205,184,75,239,216,86,51,229,237,41,171,215,96,126,22,146,66,74,224,250,218,246,82,139,233,212,110,26,41,222,178,122,122,208,93,176,220,80,53,159,150,86,37,36,212,63,193,37,40,2,162,64,199,11,81,91,122,61,198,86,36,106,217,152,27,118,75,37,44,68,228,209,27,145,75,114,82,81,175,210,112,98,65,202,190,8,12,244,124,75,185,73,1,200,29,205,208,185,7,16,207,139,101,217,97,109,127,173,115,225,234,88,147,173,208,226,5,75,238,212,40,54,233,124,152,59,142,173,143,43,163,66,46,154,222,235,141,58,6,227,236,249,115,63,2,23,149,217,120,100,138,244,207,73,167,128,100,139,186,202,255,174,50,214,180,209,106,237,8,23,162,26,50,179,217,36,77,143,185,35,234,97,97,114,92,177,11,124,39,165,144,252,100,12,62,74,188,215,105,118,195,11,159,205,131,248,158,186,65,231,69,190,132,58,199,166,66,86,66,206,47,186,237,227,70,212,77,190,213,123,191,14,158,217,143,228,244,228,196,212,242,244,148,124,253,74,58,210,23,189,210,151,109,79,253,83,90,111,28,251,106,54,91,247,234,51,211,201,166,65,161,198,75,168,2,114,122,102,23,195,232,74,183,208,173,241,139,163,140,121,218,107,252,242,40,99,217,49,78,97,69,113,96,29,101,221,159,149,163,31,101,222,187,177,124,24,51,190,193,255,3,157,138,132,76,46,189,215,228,161,133,202,27,248,221,53,43,155,20,219,252,220,110,141,137,88,254,129,163,240,178,124,140,223,82,137,131,25,71,129,170,106,209,148,198,211,13,36,119,87,114,93,228,120,228,63,20,89,22,133,77,141,161,119,135,215,130,102,91,37,27,200,169,185,9,80,197,29,235,81,19,237,183,112,94,43,133,191,31,76,205,108,29,48,50,71,216,87,71,174,76,239,31,241,116,83,43,85,166,85,139,30,136,54,59,52,116,119,125,120,168,184,11,248,225,55,144,125,13,28,8,85,189,19,44,241,247,226,206,239,194,208,189,205,122,209,31,120,148,30,131,126,63,124,197,30,217,78,246,209,253,255,246,211,55,52,204,64,43,170,239,91,101,247,55,242,189,202,250,48,220,35,117,244,103,136,147,249,162,251,127,0,94,105,176,8,160,16,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateTitleContactTemplateLocalizableString());
			LocalizableStrings.Add(CreateBodyContactTemplateLocalizableString());
			LocalizableStrings.Add(CreateTitleAccountTemplateLocalizableString());
			LocalizableStrings.Add(CreateBodyAccountTemplateLocalizableString());
			LocalizableStrings.Add(CreatestOrdinalLocalizableString());
			LocalizableStrings.Add(CreatendOrdinalLocalizableString());
			LocalizableStrings.Add(CreaterdOrdinalLocalizableString());
			LocalizableStrings.Add(CreatethOrdinalLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateTitleContactTemplateLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("2d0e61be-0a4a-45c0-ab9f-a90f92028ed7"),
				Name = "TitleContactTemplate",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateBodyContactTemplateLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f88c60c5-8ecc-4ec8-89f7-67590239dfb3"),
				Name = "BodyContactTemplate",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateTitleAccountTemplateLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("babf9ff7-7f81-4b5b-a544-3aeffb636c3b"),
				Name = "TitleAccountTemplate",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateBodyAccountTemplateLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("56be17f0-594f-4a21-84c0-7230a14a16ea"),
				Name = "BodyAccountTemplate",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreatestOrdinalLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("cb7b7382-9e88-48c3-91bf-c459bf541dcf"),
				Name = "stOrdinal",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreatendOrdinalLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("8df46a2e-db2a-408f-8b01-9c39f2d46c85"),
				Name = "ndOrdinal",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreaterdOrdinalLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("8a1a6be5-802f-42f1-9056-13a65c21a853"),
				Name = "rdOrdinal",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreatethOrdinalLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("4fb54baf-e0b3-44c0-bbf6-30d79e2a859c"),
				Name = "thOrdinal",
				CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2"),
				CreatedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"),
				ModifiedInSchemaUId = new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d0c0cb2d-82d8-4e7b-b5be-e3f71e54de5c"));
		}

		#endregion

	}

	#endregion

}

