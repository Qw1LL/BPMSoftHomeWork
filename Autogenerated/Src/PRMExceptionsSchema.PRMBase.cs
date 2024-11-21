namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: PRMExceptionsSchema

	/// <exclude/>
	public class PRMExceptionsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public PRMExceptionsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public PRMExceptionsSchema(PRMExceptionsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("4ed693a9-5407-4385-87e0-d7a39b259ee3");
			Name = "PRMExceptions";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,77,79,194,64,16,61,151,132,255,48,169,23,72,76,123,71,228,32,98,98,34,66,192,120,31,182,211,118,147,237,110,179,31,65,52,254,119,167,31,40,74,240,178,201,190,125,243,246,189,153,209,88,145,171,81,16,220,173,151,91,147,251,100,110,116,46,139,96,209,75,163,147,245,102,57,28,124,12,7,81,112,82,23,39,164,170,50,250,102,56,224,151,43,75,5,83,97,174,208,185,9,60,4,157,189,28,106,186,15,181,146,2,61,45,222,4,213,141,88,203,78,211,20,166,46,84,21,218,195,172,191,175,132,8,214,193,190,36,13,193,145,5,111,37,57,240,6,48,203,32,103,65,216,75,95,130,103,89,102,73,81,66,137,14,80,89,194,236,208,144,40,75,142,218,233,137,120,29,118,236,1,68,227,236,31,99,48,129,231,160,212,202,46,170,218,31,78,252,70,156,156,207,159,136,70,59,111,131,240,198,114,210,117,171,222,49,254,198,106,129,57,251,243,28,68,114,21,106,238,177,201,187,12,83,71,4,194,82,126,27,95,118,21,167,179,38,212,121,170,14,169,209,98,5,154,231,119,27,59,54,132,5,197,179,13,57,19,44,255,212,35,201,52,109,121,109,89,223,141,203,63,142,30,143,245,219,174,252,40,51,230,14,237,208,209,168,145,137,52,237,225,201,8,84,242,29,119,138,185,150,87,99,212,83,175,33,230,157,249,150,116,49,3,103,100,151,92,54,145,188,162,10,20,143,199,208,172,93,244,217,79,128,116,214,13,161,189,119,232,111,144,177,47,155,101,211,243,206,2,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateFundTypeDuplicateExceptionLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateFundTypeDuplicateExceptionLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("28e5b2ac-8529-4669-a3f6-90792e6f311c"),
				Name = "FundTypeDuplicateException",
				CreatedInPackageId = new Guid("83b9dda3-84f4-4c2e-b329-54cd69be3f63"),
				CreatedInSchemaUId = new Guid("4ed693a9-5407-4385-87e0-d7a39b259ee3"),
				ModifiedInSchemaUId = new Guid("4ed693a9-5407-4385-87e0-d7a39b259ee3")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("4ed693a9-5407-4385-87e0-d7a39b259ee3"));
		}

		#endregion

	}

	#endregion

}

