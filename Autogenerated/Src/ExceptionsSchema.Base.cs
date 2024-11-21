namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ExceptionsSchema

	/// <exclude/>
	public class ExceptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ExceptionsSchema(ExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0c2eb97d-52a5-4c3d-8c66-7c7e74fc11ec");
			Name = "Exceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,81,219,74,195,64,16,125,78,161,255,48,36,47,41,132,84,5,17,235,147,150,22,4,171,165,65,125,16,31,54,219,105,136,110,118,195,94,240,134,255,238,236,166,87,236,18,54,204,217,51,115,206,204,72,214,160,105,25,71,184,153,207,10,181,178,249,88,201,85,93,57,205,108,173,100,191,247,211,239,69,206,212,178,130,226,203,88,108,174,182,241,46,161,105,148,60,134,107,36,148,240,151,2,117,205,68,253,205,74,129,175,4,180,174,20,53,7,46,152,49,112,75,85,239,149,157,42,39,151,147,79,142,173,23,134,17,92,183,45,145,130,141,45,76,185,222,80,148,104,172,60,139,204,26,171,29,183,74,155,17,204,67,217,32,25,13,135,73,146,100,64,151,63,155,255,65,4,9,60,43,253,222,181,63,94,156,94,156,157,159,92,250,220,181,189,163,198,210,71,131,154,100,37,242,224,211,29,132,25,144,29,63,132,218,231,210,108,179,13,160,202,55,162,120,104,224,37,162,17,148,204,96,218,189,230,83,165,27,102,83,137,31,112,167,248,102,84,69,120,76,15,37,242,173,231,124,129,70,57,205,137,167,52,171,48,11,133,163,120,235,213,196,25,196,255,234,153,124,191,177,25,26,67,185,19,129,13,74,251,176,26,43,33,214,66,79,76,56,140,7,235,178,187,142,246,90,25,64,88,199,111,71,9,155,65,185,236,150,67,17,225,244,253,1,170,86,70,29,100,2,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateItemNotFoundMessageElementOfCollectionLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateItemNotFoundMessageElementOfCollectionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ea6e1d20-4f48-49c8-b0b9-9625dfbcff06"),
				Name = "ItemNotFoundMessageElementOfCollection",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("0c2eb97d-52a5-4c3d-8c66-7c7e74fc11ec"),
				ModifiedInSchemaUId = new Guid("0c2eb97d-52a5-4c3d-8c66-7c7e74fc11ec")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0c2eb97d-52a5-4c3d-8c66-7c7e74fc11ec"));
		}

		#endregion

	}

	#endregion

}

