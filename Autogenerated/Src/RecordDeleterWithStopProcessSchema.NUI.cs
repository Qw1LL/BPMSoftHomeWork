namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: RecordDeleterWithStopProcessSchema

	/// <exclude/>
	public class RecordDeleterWithStopProcessSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public RecordDeleterWithStopProcessSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public RecordDeleterWithStopProcessSchema(RecordDeleterWithStopProcessSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0257476-0351-4841-902a-f92f292b905b");
			Name = "RecordDeleterWithStopProcess";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("edbaf284-b37c-4101-84cb-76a44645334f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,203,106,35,49,16,60,43,144,127,16,236,197,129,48,31,144,13,123,240,131,37,16,19,179,38,236,49,200,154,142,173,101,44,205,182,122,76,134,224,127,79,75,26,197,153,241,35,55,61,74,213,93,213,37,171,182,224,107,165,65,142,23,243,165,123,165,98,226,236,171,89,55,168,200,56,43,223,175,175,68,227,141,93,203,101,235,9,182,63,7,123,134,87,21,232,128,245,197,111,176,128,70,95,196,60,173,254,241,114,238,74,168,14,184,67,109,132,211,167,197,204,146,33,3,254,204,245,116,124,230,98,129,78,131,63,249,108,187,117,246,168,215,71,99,255,159,161,234,57,195,24,70,253,64,88,7,155,38,149,242,254,78,254,1,237,176,156,66,5,4,248,215,208,102,73,174,238,58,136,248,186,89,85,70,75,29,224,23,209,114,64,22,6,193,239,15,5,217,75,194,70,147,67,174,187,136,180,9,209,149,184,68,62,122,246,128,204,96,211,80,100,211,219,222,6,22,33,30,166,38,110,21,182,247,92,138,221,184,149,46,14,239,151,172,21,114,110,152,216,223,112,163,43,229,97,52,224,232,65,66,136,196,190,19,0,182,76,26,250,130,230,64,27,87,6,45,104,118,138,32,220,69,57,105,43,119,206,148,50,201,9,106,38,202,106,168,102,111,160,155,80,47,11,59,36,237,190,59,122,52,60,86,142,37,55,221,63,200,125,137,14,56,179,107,99,225,153,76,21,115,86,164,10,11,133,96,41,211,191,28,169,28,114,134,232,8,17,28,41,82,179,79,53,164,192,140,210,221,62,11,251,222,136,110,168,217,7,71,92,21,74,233,118,128,104,202,158,37,95,170,116,170,8,219,110,117,169,27,177,151,90,145,222,200,81,252,95,45,7,163,28,183,217,145,55,13,117,12,8,228,85,102,23,223,78,226,243,73,254,129,67,143,162,17,39,66,17,229,166,243,222,241,245,213,254,3,7,210,49,184,173,4,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0257476-0351-4841-902a-f92f292b905b"));
		}

		#endregion

	}

	#endregion

}

