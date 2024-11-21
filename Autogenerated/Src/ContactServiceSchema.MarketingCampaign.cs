namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactServiceSchema

	/// <exclude/>
	public class ContactServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactServiceSchema(ContactServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("892cbfbe-997b-4ab9-8be0-cc1b1284bb2a");
			Name = "ContactService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("23e6b872-7cf2-4336-8046-3b06c9b28cbc");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,84,77,107,219,64,16,61,43,144,255,48,56,23,27,140,124,79,99,7,219,212,212,5,39,38,138,201,193,148,178,145,70,206,210,253,80,118,87,42,166,244,191,119,118,37,171,174,80,220,219,238,155,153,167,55,111,103,164,152,68,91,176,20,97,177,221,36,58,119,241,82,171,156,31,74,195,28,215,234,250,234,215,245,85,84,90,174,14,144,28,173,67,25,39,104,42,158,226,70,103,40,62,93,10,198,243,212,241,42,208,92,206,123,193,215,191,9,39,25,4,146,20,41,67,49,69,111,12,30,136,9,150,130,89,123,11,164,210,177,212,53,60,33,99,223,92,124,200,80,236,155,199,230,182,120,64,71,68,5,9,121,229,130,187,227,19,190,151,220,160,68,229,236,240,252,226,213,192,20,254,83,226,179,226,6,200,70,254,35,69,249,42,120,10,169,87,214,17,6,183,176,96,22,91,153,145,183,179,237,101,107,116,129,198,113,164,134,182,129,36,52,18,21,198,251,134,29,174,47,40,40,27,190,167,61,104,237,81,52,153,76,224,206,150,82,50,115,156,157,128,181,178,142,41,210,162,243,94,198,184,173,156,156,151,54,93,245,106,232,5,67,107,209,1,29,76,103,253,42,225,254,30,134,253,145,41,40,252,217,203,59,220,89,52,20,80,72,227,164,213,104,228,103,37,138,236,165,239,76,161,98,162,196,144,249,187,182,230,6,85,86,219,222,220,155,55,216,160,123,211,89,231,1,122,125,124,66,169,43,180,144,11,118,128,7,173,104,188,75,38,32,55,90,158,132,3,83,89,123,246,211,91,42,158,134,13,248,192,228,128,20,204,48,9,138,54,113,58,200,185,112,104,236,96,182,170,15,224,52,88,20,212,251,137,55,190,155,132,130,254,122,154,80,154,215,36,125,67,201,118,235,108,48,171,143,64,66,222,75,4,158,249,132,156,211,171,159,211,236,31,201,181,160,243,124,121,162,61,45,225,90,85,250,7,14,107,155,200,216,193,246,49,121,30,140,97,103,248,51,202,66,248,57,37,52,65,87,251,241,89,50,46,44,37,44,116,118,76,220,81,248,48,241,108,208,90,118,192,22,141,95,12,43,10,204,198,225,53,253,62,161,117,43,109,36,115,255,20,172,2,20,127,181,90,141,233,9,108,161,149,109,192,143,242,194,82,158,230,183,210,60,131,142,186,161,117,198,255,107,26,179,199,208,220,59,230,141,154,145,238,93,154,93,145,81,235,77,104,110,143,42,93,106,131,195,150,178,203,85,207,98,20,245,78,99,61,163,231,32,33,127,0,183,218,108,97,155,5,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateRemindingUpdateMessageLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateRemindingUpdateMessageLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("dcc3279a-ae13-4ada-8127-1557b79bc092"),
				Name = "RemindingUpdateMessage",
				CreatedInPackageId = new Guid("23e6b872-7cf2-4336-8046-3b06c9b28cbc"),
				CreatedInSchemaUId = new Guid("892cbfbe-997b-4ab9-8be0-cc1b1284bb2a"),
				ModifiedInSchemaUId = new Guid("892cbfbe-997b-4ab9-8be0-cc1b1284bb2a")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("892cbfbe-997b-4ab9-8be0-cc1b1284bb2a"));
		}

		#endregion

	}

	#endregion

}

