namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportParametersIteratorSchema

	/// <exclude/>
	public class ImportParametersIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportParametersIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportParametersIteratorSchema(ImportParametersIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a556f6f-f364-4e38-8c78-e99a9660b2e1");
			Name = "ImportParametersIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("79cdeed7-eef0-4dd8-9765-07d140cf1035");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,82,219,106,3,33,16,125,54,144,127,24,232,203,6,194,126,64,211,20,154,180,133,60,4,2,129,190,91,119,118,35,184,186,120,41,132,146,127,175,171,110,162,105,233,203,140,51,158,115,230,162,146,246,104,6,202,16,54,135,253,81,181,182,222,42,217,242,206,105,106,185,146,245,59,23,184,235,7,165,237,124,246,61,159,17,103,184,236,224,120,54,22,251,213,124,230,51,15,26,59,143,132,173,160,198,60,66,4,31,168,246,194,22,181,217,121,67,173,210,1,59,184,79,193,25,24,235,197,25,176,145,241,15,129,248,130,222,94,43,236,209,158,84,227,107,28,130,76,188,44,37,191,20,111,32,42,96,117,175,12,195,245,184,28,169,132,188,176,113,200,167,8,124,147,150,219,243,50,53,180,85,194,245,178,140,62,168,112,88,166,94,209,88,46,195,174,158,129,167,214,23,48,174,138,144,86,105,164,236,4,85,94,0,120,17,200,172,171,58,36,57,154,73,224,94,33,214,4,22,93,201,141,119,55,42,249,213,121,226,197,243,186,232,195,191,179,108,50,104,21,161,139,85,210,226,45,164,84,98,175,65,58,33,110,197,8,83,94,72,58,156,24,151,228,255,156,32,219,26,52,217,217,79,20,171,212,25,34,27,137,76,27,174,242,230,151,137,52,249,244,76,153,240,117,142,212,85,116,193,122,19,254,24,202,38,126,179,16,199,108,153,188,252,0,184,194,2,178,44,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a556f6f-f364-4e38-8c78-e99a9660b2e1"));
		}

		#endregion

	}

	#endregion

}

