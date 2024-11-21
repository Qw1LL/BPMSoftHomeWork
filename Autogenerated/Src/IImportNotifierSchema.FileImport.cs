namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImportNotifierSchema

	/// <exclude/>
	public class IImportNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImportNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImportNotifierSchema(IImportNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d3fe64f7-9465-476a-b7e1-7f9edad4dc1e");
			Name = "IImportNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,144,221,74,196,64,12,133,175,91,232,59,132,189,90,65,58,15,96,93,80,169,176,23,138,176,79,144,78,211,26,233,252,48,147,22,138,236,187,59,219,186,139,138,94,120,153,228,228,203,57,177,104,40,122,212,4,247,47,79,7,215,73,249,224,108,199,253,24,80,216,217,242,145,7,218,27,239,130,20,249,123,145,23,121,230,199,102,96,13,108,133,66,119,90,220,175,243,103,39,220,49,133,36,73,194,44,83,74,65,21,71,99,48,204,187,115,227,83,20,65,15,76,86,64,94,81,128,151,125,72,53,203,12,28,161,33,182,61,68,156,168,45,47,40,245,147,85,121,12,104,192,166,4,183,155,72,182,165,176,217,85,106,233,254,46,162,41,221,184,11,125,252,174,155,28,183,171,179,121,235,154,55,210,2,43,238,26,214,104,245,226,236,128,83,178,85,159,25,112,161,93,221,44,143,249,127,226,20,85,59,227,7,146,63,131,126,241,86,219,118,123,58,149,29,139,252,248,1,211,131,49,178,184,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d3fe64f7-9465-476a-b7e1-7f9edad4dc1e"));
		}

		#endregion

	}

	#endregion

}

