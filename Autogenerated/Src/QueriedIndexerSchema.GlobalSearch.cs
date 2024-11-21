namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: QueriedIndexerSchema

	/// <exclude/>
	public class QueriedIndexerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public QueriedIndexerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public QueriedIndexerSchema(QueriedIndexerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("5329f48a-37fa-49fb-9285-1a0aa78ae731");
			Name = "QueriedIndexer";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("3c3a921b-299a-4f38-a040-5c0154a25bee");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,203,110,194,48,16,60,7,169,255,176,82,47,65,66,254,0,170,94,160,15,245,128,74,161,124,128,137,23,176,100,236,212,94,163,34,196,191,215,177,19,72,218,208,75,172,236,204,206,206,120,173,249,30,93,201,11,132,201,124,182,52,27,98,83,163,55,114,235,45,39,105,52,123,85,102,205,213,18,185,45,118,119,131,211,221,32,243,78,234,109,139,109,145,61,107,146,36,209,61,244,192,183,196,166,70,249,189,94,145,84,61,109,109,34,123,211,2,191,3,26,104,129,120,111,113,27,180,96,170,184,115,99,248,240,104,37,138,200,65,27,25,165,95,43,89,64,81,17,126,225,48,134,9,119,120,97,103,33,80,248,94,69,141,118,100,125,65,198,6,237,121,20,74,140,90,180,43,151,55,214,22,248,229,209,209,19,39,62,241,82,137,48,73,222,132,70,149,94,214,180,198,187,59,46,81,183,155,218,197,97,164,143,97,29,140,231,255,168,246,55,195,9,206,117,198,80,72,49,187,153,103,72,59,35,170,184,214,16,22,132,162,78,220,252,130,57,160,181,82,32,28,140,20,80,9,119,205,231,233,0,140,199,8,26,244,189,196,180,248,207,99,137,23,123,157,106,240,23,227,29,248,53,124,21,10,30,47,42,127,163,178,120,214,171,104,193,121,50,192,86,14,109,216,164,14,238,195,152,116,221,89,239,248,209,197,243,141,167,25,30,159,35,174,11,100,11,84,177,45,129,238,69,162,18,115,78,132,86,15,171,7,220,191,81,214,115,91,237,156,169,181,127,67,169,218,45,158,127,0,34,215,35,192,176,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("5329f48a-37fa-49fb-9285-1a0aa78ae731"));
		}

		#endregion

	}

	#endregion

}

