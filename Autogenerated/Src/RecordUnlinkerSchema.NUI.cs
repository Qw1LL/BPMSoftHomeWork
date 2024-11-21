namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RecordUnlinkerSchema

	/// <exclude/>
	public class RecordUnlinkerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordUnlinkerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordUnlinkerSchema(RecordUnlinkerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("66bb5f4d-9a35-4ffa-80c6-0587b0525470");
			Name = "RecordUnlinker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,219,78,2,49,16,125,94,18,254,97,130,47,144,144,253,0,80,31,184,104,76,68,9,132,15,40,237,176,84,75,187,78,187,27,136,241,223,157,110,81,46,209,100,31,182,115,46,51,103,198,138,29,250,82,72,132,209,124,182,116,155,144,143,157,221,232,162,34,17,180,179,240,217,110,101,149,215,182,128,229,193,7,220,13,175,222,76,55,6,101,228,250,252,17,45,146,150,39,206,201,147,240,239,106,62,181,65,7,141,254,31,120,50,138,0,127,55,132,69,28,104,108,132,247,3,88,160,116,164,86,214,104,251,142,212,110,49,163,172,214,70,75,144,145,112,133,195,0,70,194,99,42,78,247,40,171,224,40,102,99,217,201,153,35,4,170,36,67,220,96,222,184,37,198,209,249,210,179,187,242,72,172,177,41,61,84,23,207,62,60,77,116,243,39,232,112,203,190,156,172,15,110,253,198,240,61,148,130,120,239,1,201,247,162,127,150,13,96,205,243,117,175,61,206,120,205,37,178,44,205,176,208,197,54,188,150,120,60,210,29,44,229,22,119,226,12,124,198,26,141,207,199,194,78,149,14,195,164,213,12,76,247,18,203,168,154,161,247,162,64,22,119,154,27,28,146,71,254,75,200,95,92,163,120,112,148,175,74,37,2,118,26,159,175,227,218,208,170,180,185,203,53,206,48,108,157,58,219,96,22,207,151,149,228,2,199,66,5,174,70,34,173,16,106,167,21,76,208,112,192,223,44,221,159,160,105,166,124,41,106,236,214,194,232,216,127,129,31,149,38,84,3,216,8,227,177,247,223,56,77,199,84,191,40,183,91,95,223,17,10,208,97,240,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("66bb5f4d-9a35-4ffa-80c6-0587b0525470"));
		}

		#endregion

	}

	#endregion

}

