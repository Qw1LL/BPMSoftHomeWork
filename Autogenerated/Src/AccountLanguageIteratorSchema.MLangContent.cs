namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AccountLanguageIteratorSchema

	/// <exclude/>
	public class AccountLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AccountLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AccountLanguageIteratorSchema(AccountLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e46324f1-8f69-4be3-9d3a-1af95158ae46");
			Name = "AccountLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d5fe5418-b108-401a-ba83-ff1213a966db");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,82,77,107,194,64,16,61,71,240,63,12,241,162,80,146,187,85,161,218,139,208,130,180,244,84,122,24,183,147,176,176,217,149,253,160,216,226,127,239,236,38,106,170,8,61,100,97,222,188,121,243,102,38,26,27,114,59,20,4,203,205,243,171,169,124,177,50,186,146,117,176,232,165,209,195,193,207,112,144,5,39,117,221,35,88,186,31,14,24,31,89,170,153,4,43,133,206,77,225,65,8,19,180,127,66,93,7,172,105,237,137,69,140,77,212,178,44,97,230,66,211,160,221,47,186,248,72,128,138,63,37,157,143,93,182,123,192,86,7,84,39,228,138,163,64,217,83,216,133,173,146,2,68,236,125,171,53,76,97,137,142,174,29,101,113,172,179,127,163,157,183,65,112,138,199,216,36,225,228,250,202,118,235,91,75,47,81,201,111,114,160,233,11,36,87,163,230,21,154,138,201,68,32,44,85,243,252,134,167,188,92,20,112,210,238,79,212,34,59,180,216,128,230,187,204,243,224,200,178,57,77,34,30,35,95,188,113,12,226,4,20,179,50,177,83,113,183,143,27,93,199,177,244,44,5,127,149,39,81,32,155,194,150,151,53,190,72,65,90,85,118,20,124,9,138,199,158,167,193,215,125,240,253,163,99,102,49,181,177,178,33,86,241,40,252,90,95,152,138,244,11,67,147,187,115,237,35,85,24,212,63,216,7,254,13,249,109,79,53,34,253,217,222,51,197,45,250,23,60,252,2,24,182,143,61,238,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e46324f1-8f69-4be3-9d3a-1af95158ae46"));
		}

		#endregion

	}

	#endregion

}

