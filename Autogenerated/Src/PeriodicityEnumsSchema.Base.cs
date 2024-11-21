namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PeriodicityEnumsSchema

	/// <exclude/>
	public class PeriodicityEnumsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PeriodicityEnumsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PeriodicityEnumsSchema(PeriodicityEnumsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01");
			Name = "PeriodicityEnums";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,237,87,93,111,219,54,20,125,118,129,254,7,193,126,113,0,211,21,69,74,164,150,109,0,37,145,217,128,5,13,234,110,121,28,84,153,113,133,218,82,64,73,27,188,194,255,125,36,165,216,137,172,116,217,60,204,125,152,225,47,209,247,158,123,238,7,174,142,139,116,35,171,251,52,147,78,116,115,189,40,239,234,121,92,22,119,249,170,81,105,157,151,197,235,87,159,95,191,26,53,85,94,172,156,197,182,170,229,230,178,119,173,237,215,107,153,25,227,106,126,37,11,169,242,236,96,115,0,85,114,232,116,179,41,11,115,174,159,19,37,87,26,196,137,215,105,85,125,227,252,80,54,170,122,171,174,243,162,169,101,101,15,91,187,251,230,195,58,207,156,204,156,60,99,101,56,239,241,68,46,215,75,13,120,163,242,223,210,90,154,159,204,235,190,189,116,126,174,164,210,41,23,109,10,206,175,205,147,235,203,7,243,137,44,150,45,224,254,164,195,191,81,229,189,84,117,46,77,12,203,109,31,162,101,250,83,153,165,235,252,143,244,195,90,46,106,101,242,183,172,29,203,114,180,146,117,247,109,164,100,221,168,194,41,228,239,199,62,211,43,89,191,147,149,118,204,244,73,169,210,149,156,94,204,156,241,141,174,119,185,204,179,188,222,242,162,217,84,227,89,139,53,26,31,65,84,115,27,119,254,75,186,110,228,248,98,254,190,236,160,47,108,150,163,157,121,223,253,37,249,174,214,103,160,223,69,126,97,2,207,119,76,183,183,170,85,147,105,30,207,245,108,96,174,166,189,73,121,58,40,23,93,21,122,243,227,124,215,179,187,108,195,188,128,229,181,172,63,150,95,24,220,31,123,245,116,134,74,108,28,90,98,111,222,76,38,147,153,163,223,204,227,225,243,201,149,51,113,110,75,245,169,93,7,241,59,72,16,242,67,235,220,181,182,151,220,188,23,238,242,111,103,54,84,250,36,183,224,169,218,126,123,213,228,203,217,241,48,125,111,82,125,218,161,233,67,253,31,13,225,11,128,246,110,250,241,217,248,24,195,233,88,132,81,224,81,151,2,193,3,23,96,15,10,16,250,20,3,198,4,143,33,247,96,140,147,177,30,95,203,97,55,27,64,128,158,224,16,83,10,112,16,65,128,19,17,131,8,34,8,32,37,212,39,2,81,159,113,131,208,209,223,237,190,80,187,93,183,31,31,159,29,239,203,36,221,86,111,239,110,165,252,244,220,174,60,182,248,218,247,228,162,41,150,233,246,12,155,166,13,124,242,166,44,207,68,191,13,124,42,253,247,141,172,206,195,191,139,124,106,2,183,114,89,156,43,133,125,236,147,187,240,81,239,152,51,181,161,11,125,106,10,66,229,231,73,160,13,124,42,253,69,170,105,158,105,15,117,161,255,11,201,211,187,61,252,47,119,190,42,185,115,232,206,191,43,117,180,22,73,32,199,46,240,18,234,3,204,48,2,76,196,62,8,49,97,40,198,132,224,4,26,161,210,222,17,7,181,142,192,60,164,137,64,32,198,76,107,29,14,57,160,130,112,128,9,194,136,19,202,41,179,106,169,189,43,13,66,144,136,17,34,98,15,112,55,16,218,209,15,64,72,163,24,80,24,18,10,177,79,147,200,202,165,238,198,48,44,185,56,130,62,103,58,110,192,117,38,46,241,1,69,44,6,97,20,250,73,226,249,2,19,207,96,236,55,243,112,50,20,199,8,49,4,60,204,181,122,99,90,179,69,177,79,65,34,112,236,19,20,36,140,4,150,73,183,27,135,65,152,231,187,212,143,65,162,229,30,192,190,43,0,101,130,2,26,122,9,76,24,67,174,139,13,136,176,251,105,16,2,5,90,123,211,128,131,0,198,76,167,132,49,8,9,210,21,137,252,196,213,36,92,26,187,182,47,221,134,248,39,10,178,155,64,169,215,80,239,15,143,217,76,237,184,216,243,106,47,84,141,106,236,208,30,123,31,166,243,224,169,39,198,246,220,118,205,150,221,86,205,102,109,121,183,80,187,63,1,251,39,231,172,130,16,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateHoursLocalizableString());
			LocalizableStrings.Add(CreateMinutesLocalizableString());
			LocalizableStrings.Add(CreateSundayLocalizableString());
			LocalizableStrings.Add(CreateSaturdayLocalizableString());
			LocalizableStrings.Add(CreateFridayLocalizableString());
			LocalizableStrings.Add(CreateThursdayLocalizableString());
			LocalizableStrings.Add(CreateWednesdayLocalizableString());
			LocalizableStrings.Add(CreateTuesdayLocalizableString());
			LocalizableStrings.Add(CreateMondayLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateHoursLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("12f23832-fa87-4303-aacd-c714edf36063"),
				Name = "Hours",
				CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateMinutesLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("65f8dfe4-7ce0-435b-abc2-6bc7c5d56ace"),
				Name = "Minutes",
				CreatedInPackageId = new Guid("e5f52fab-ebea-4990-be49-0763f7c9fbd6"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSundayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("a8d5eda9-2165-4a96-9e78-d74c46256197"),
				Name = "Sunday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSaturdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("1020d386-033c-46b6-a17f-8e39fb443bc2"),
				Name = "Saturday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFridayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("bfeef8db-c2a7-438b-a423-cb94b9790dd6"),
				Name = "Friday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateThursdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("0b2c9a60-8c38-49fa-a995-ace5363fa8d1"),
				Name = "Thursday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWednesdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fade33fe-e073-4386-af12-715568054744"),
				Name = "Wednesday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateTuesdayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("165ca4ef-8cfc-4d1c-874e-ed4de8b3461e"),
				Name = "Tuesday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateMondayLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5664557f-389b-421d-a281-b77b0f6df8fb"),
				Name = "Monday",
				CreatedInPackageId = new Guid("f9ecdc95-9cb8-443d-ba94-66f513ca3a49"),
				CreatedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"),
				ModifiedInSchemaUId = new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5e9cfccc-3c95-437a-81fa-d9e23582df01"));
		}

		#endregion

	}

	#endregion

}

