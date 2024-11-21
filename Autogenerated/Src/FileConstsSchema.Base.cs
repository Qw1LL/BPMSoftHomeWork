namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FileConstsSchema

	/// <exclude/>
	public class FileConstsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public FileConstsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public FileConstsSchema(FileConstsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("92a37fd3-69e6-42f0-916f-9be6698711d1");
			Name = "FileConsts";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,146,93,75,195,48,20,134,175,55,216,127,56,108,55,122,17,215,175,117,171,195,11,215,181,67,80,24,204,143,235,180,57,157,193,46,45,77,166,20,241,191,155,180,58,157,76,100,120,147,144,115,222,247,61,15,156,8,186,65,89,210,20,97,182,188,89,21,153,58,123,192,228,178,44,123,221,215,94,183,179,149,92,172,97,85,75,133,155,105,175,171,43,131,10,215,188,16,16,230,84,202,115,136,121,142,97,33,164,146,77,183,220,38,57,79,65,42,170,244,149,26,205,158,164,163,67,245,185,75,137,57,230,76,199,44,27,95,219,27,14,141,3,84,93,34,144,198,45,129,10,6,57,23,79,18,140,98,127,74,133,148,21,34,175,97,177,229,172,209,223,106,235,221,21,131,11,16,248,210,148,79,250,35,39,152,133,78,60,33,86,20,89,100,30,219,54,9,198,246,140,88,150,61,247,173,40,112,39,161,223,63,157,126,34,92,235,97,191,32,252,69,96,172,7,9,220,163,8,34,161,184,170,255,193,241,21,112,144,198,11,146,212,201,52,13,162,69,88,214,210,36,134,134,249,22,106,154,244,59,141,177,151,116,141,240,140,149,212,155,147,80,100,160,30,17,50,179,171,163,217,140,252,254,35,105,81,113,182,212,209,63,9,113,226,165,137,231,82,226,121,174,77,60,63,112,73,194,24,37,212,246,28,123,146,184,233,40,24,239,8,7,40,88,251,167,154,247,91,251,87,247,138,186,246,14,76,121,106,58,237,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("92a37fd3-69e6-42f0-916f-9be6698711d1"));
		}

		#endregion

	}

	#endregion

}

