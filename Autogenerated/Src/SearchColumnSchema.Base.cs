namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SearchColumnSchema

	/// <exclude/>
	public class SearchColumnSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SearchColumnSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SearchColumnSchema(SearchColumnSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1e9e33bb-e2f8-4c17-b5b6-db4500bda4ab");
			Name = "SearchColumn";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,79,75,10,194,48,16,93,183,208,59,12,116,239,1,116,103,214,74,177,94,32,198,105,26,104,39,97,146,44,164,244,238,182,137,8,74,23,186,25,120,95,222,144,28,209,59,169,16,142,205,169,181,93,216,9,75,157,209,145,101,48,150,170,114,170,202,170,44,106,70,189,64,16,131,244,126,15,45,74,86,189,176,67,28,41,233,46,222,6,163,64,173,242,151,90,228,134,119,69,195,214,33,7,131,75,79,147,98,89,127,85,248,192,134,52,92,176,67,70,82,216,170,30,71,121,94,102,194,4,26,195,1,252,122,230,173,208,63,222,60,239,55,239,245,225,54,93,53,210,61,127,149,112,102,63,201,249,9,111,155,230,240,97,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1e9e33bb-e2f8-4c17-b5b6-db4500bda4ab"));
		}

		#endregion

	}

	#endregion

}

