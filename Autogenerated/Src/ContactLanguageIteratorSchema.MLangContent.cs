namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ContactLanguageIteratorSchema

	/// <exclude/>
	public class ContactLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ContactLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ContactLanguageIteratorSchema(ContactLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("0cad4a31-9d11-4174-aee6-2df7a00ccdc7");
			Name = "ContactLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,107,194,64,16,61,39,224,127,24,226,69,161,36,119,171,30,180,23,161,5,105,233,169,244,48,217,78,194,194,102,35,251,65,177,197,255,222,217,77,212,168,8,61,100,97,222,188,121,243,102,38,26,27,178,59,20,4,171,237,203,91,91,185,124,221,234,74,214,222,160,147,173,30,165,191,163,52,241,86,234,122,64,48,244,56,74,25,31,27,170,153,4,107,133,214,206,128,43,29,10,247,140,186,246,88,211,198,17,139,180,38,82,139,162,128,185,245,77,131,102,191,236,227,35,1,42,254,148,180,46,116,41,247,32,58,29,80,189,144,205,143,2,197,64,97,231,75,37,5,136,208,251,94,107,152,193,10,45,221,58,74,194,88,103,255,173,182,206,120,193,41,30,99,27,133,163,235,27,219,157,111,45,157,68,37,127,200,130,166,111,144,92,141,154,87,216,86,76,38,2,97,168,90,100,119,60,101,197,50,135,147,246,112,162,14,217,161,193,6,52,223,101,145,121,75,134,101,52,137,112,140,108,249,206,113,88,79,15,228,243,34,178,99,113,191,143,59,93,39,161,244,44,5,151,202,211,32,144,204,160,228,101,77,174,82,16,87,149,28,5,95,189,226,177,23,113,240,205,16,252,248,236,153,73,72,157,250,235,43,67,129,122,101,102,250,112,174,123,162,10,189,250,7,251,192,191,32,191,221,153,198,164,191,186,91,198,184,67,47,193,195,31,51,245,42,31,234,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("0cad4a31-9d11-4174-aee6-2df7a00ccdc7"));
		}

		#endregion

	}

	#endregion

}

