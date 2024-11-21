namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPrimaryEntityFinderSchema

	/// <exclude/>
	public class IPrimaryEntityFinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPrimaryEntityFinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPrimaryEntityFinderSchema(IPrimaryEntityFinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8ef9a048-2ae1-43c0-b555-ed097820e198");
			Name = "IPrimaryEntityFinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,145,221,106,131,64,16,133,175,21,124,135,33,189,105,161,232,125,107,189,104,73,138,180,5,33,79,176,209,81,134,186,187,178,63,165,82,242,238,29,179,77,98,176,185,243,140,231,156,111,119,71,9,137,118,16,53,194,115,245,177,213,173,75,95,180,106,169,243,70,56,210,42,221,80,143,165,28,180,113,73,252,147,196,145,183,164,58,216,142,214,161,100,107,223,99,61,249,108,250,138,10,13,213,143,73,204,174,27,131,29,79,161,84,14,77,203,237,15,80,86,134,164,48,227,90,57,114,227,134,84,131,102,242,178,59,203,50,200,173,151,211,239,226,79,79,6,192,111,178,14,136,81,22,4,107,139,14,90,109,32,28,40,52,165,199,130,108,214,48,248,93,79,53,208,17,127,133,30,77,55,90,224,207,252,33,132,0,79,164,104,129,10,147,65,24,33,65,241,99,62,173,14,223,200,100,187,42,194,73,225,60,74,243,236,32,254,143,126,226,104,67,132,159,214,75,197,13,111,56,66,29,196,69,246,75,83,3,239,90,52,23,55,187,13,233,234,196,155,161,239,161,92,43,47,209,136,93,143,249,28,83,192,2,124,199,139,140,246,97,153,168,154,176,207,73,238,127,1,67,135,55,227,50,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8ef9a048-2ae1-43c0-b555-ed097820e198"));
		}

		#endregion

	}

	#endregion

}

