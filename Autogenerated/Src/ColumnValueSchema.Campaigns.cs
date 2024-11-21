namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ColumnValueSchema

	/// <exclude/>
	public class ColumnValueSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ColumnValueSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ColumnValueSchema(ColumnValueSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("3acab525-0700-4166-92ec-120c1b6f08ac");
			Name = "ColumnValue";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6c038aa0-46cd-4697-bc93-5c682e364aef");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,173,84,205,78,227,48,16,62,23,137,119,24,193,189,185,211,210,3,65,11,72,84,170,68,217,187,147,76,18,47,137,157,181,199,187,91,1,239,190,99,39,41,180,165,81,81,123,113,228,241,124,127,147,56,74,212,104,27,145,34,220,44,230,79,58,167,113,172,85,46,11,103,4,73,173,198,177,168,27,33,11,101,207,207,94,207,207,70,206,74,85,192,211,202,18,214,147,245,254,3,106,144,171,92,191,52,88,48,28,226,74,88,123,5,177,174,92,173,126,138,202,97,56,142,162,8,166,214,213,181,48,171,89,183,103,93,18,82,89,144,42,215,166,14,242,32,18,237,8,254,120,32,112,21,80,145,164,21,164,129,111,220,51,69,159,168,26,151,84,50,133,212,11,111,234,142,56,0,175,107,111,11,163,27,52,36,145,13,46,2,170,61,223,54,23,10,207,74,254,102,15,50,243,14,114,137,6,116,190,235,102,215,78,239,231,206,201,172,179,243,252,144,193,43,20,72,19,176,126,121,31,144,13,214,189,148,197,10,83,194,236,32,49,157,252,226,230,14,124,168,212,143,74,20,64,154,199,159,201,84,16,2,149,162,31,125,41,44,212,34,53,218,14,11,39,90,87,112,47,236,60,244,126,79,127,106,17,33,53,152,95,95,220,10,18,1,188,92,53,120,17,205,190,57,235,13,248,214,238,80,55,113,137,233,139,133,191,37,82,201,47,187,149,237,166,145,49,35,144,103,147,22,8,255,209,30,59,161,98,144,156,81,118,182,52,140,100,186,253,36,211,168,239,221,158,232,131,93,114,67,251,245,192,245,108,43,18,227,253,241,70,113,114,138,104,204,136,75,89,227,209,241,214,68,67,17,251,166,61,49,199,31,29,39,9,87,240,133,60,58,88,32,25,10,229,175,253,254,64,143,90,191,184,198,163,70,111,111,59,167,115,87,145,28,104,241,6,60,255,233,95,124,194,230,143,158,77,32,25,154,205,13,63,80,168,129,207,186,235,248,42,224,37,170,172,253,143,135,125,123,149,55,139,239,255,1,185,154,19,238,220,6,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("3acab525-0700-4166-92ec-120c1b6f08ac"));
		}

		#endregion

	}

	#endregion

}

