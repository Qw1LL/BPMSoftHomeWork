namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SectionExceptionResourcesSchema

	/// <exclude/>
	public class SectionExceptionResourcesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SectionExceptionResourcesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SectionExceptionResourcesSchema(SectionExceptionResourcesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1");
			Name = "SectionExceptionResources";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,205,10,194,48,16,132,207,45,244,29,22,122,111,239,34,30,44,30,5,177,190,192,118,187,173,193,52,9,217,22,255,240,221,77,172,5,79,222,102,118,7,230,27,131,3,139,67,98,216,30,246,181,237,198,162,178,166,83,253,228,113,84,214,100,233,51,75,147,220,115,31,12,84,26,69,86,80,51,197,223,238,70,236,162,56,178,216,201,19,75,150,134,112,89,150,176,150,105,24,208,223,55,95,127,58,43,129,57,4,100,91,6,161,51,15,24,180,25,81,25,1,109,9,181,122,96,163,25,2,144,96,207,2,157,245,128,90,195,213,250,139,211,145,17,77,11,50,183,3,47,245,82,44,173,229,79,173,155,26,173,8,40,34,255,35,78,226,192,215,135,60,103,211,206,75,179,52,92,222,37,226,120,70,27,1,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateSectionNotFoundByIdTplLocalizableString());
			LocalizableStrings.Add(CreateWorkplaceNotFoundByIdTplLocalizableString());
			LocalizableStrings.Add(CreateEntityNotAllowedForSSPTplLocalizableString());
			LocalizableStrings.Add(CreateWorkplaceCreateFailedLocalizableString());
			LocalizableStrings.Add(CreateWorkplaceSectionTypeNotMatchLocalizableString());
			LocalizableStrings.Add(CreateSectionNotSspTypeTplLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateSectionNotFoundByIdTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f01bcb74-e302-4b6e-9150-8ecf83c08c88"),
				Name = "SectionNotFoundByIdTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWorkplaceNotFoundByIdTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5aa54c95-c48e-49ee-90c4-e020e313e093"),
				Name = "WorkplaceNotFoundByIdTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateEntityNotAllowedForSSPTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("f341ba5c-75ac-4bd7-99b0-4a9e2a1729ea"),
				Name = "EntityNotAllowedForSSPTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWorkplaceCreateFailedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ddbc7ab7-59d9-433c-88df-543bba74a3f1"),
				Name = "WorkplaceCreateFailed",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateWorkplaceSectionTypeNotMatchLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("09d7c38b-e8ab-4c98-85f0-1122edff1cb5"),
				Name = "WorkplaceSectionTypeNotMatch",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateSectionNotSspTypeTplLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("7b27fa27-0b26-45c9-b8bc-bcb375d08e95"),
				Name = "SectionNotSspTypeTpl",
				CreatedInPackageId = new Guid("9735f166-4b01-4c20-b58c-0bd002ae38b1"),
				CreatedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"),
				ModifiedInSchemaUId = new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ff29964e-7106-4780-912f-9d1f5161f3f1"));
		}

		#endregion

	}

	#endregion

}

