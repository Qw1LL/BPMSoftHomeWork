namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IEntityFileCopierSchema

	/// <exclude/>
	public class IEntityFileCopierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IEntityFileCopierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IEntityFileCopierSchema(IEntityFileCopierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c02c3b56-5b96-4366-af70-1c204d27c6c2");
			Name = "IEntityFileCopier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c85d2d65-6230-4aeb-9934-bfac9785d42f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,193,74,3,49,16,134,207,45,244,29,134,246,162,32,221,123,173,5,45,42,61,84,74,235,11,196,236,100,55,176,155,137,147,68,89,164,239,110,54,187,21,91,139,226,101,217,249,231,207,151,63,147,24,81,163,179,66,34,220,109,214,59,82,126,186,36,163,116,17,88,120,77,102,52,252,24,13,7,193,105,83,192,174,113,30,235,235,209,48,42,19,198,34,182,97,101,60,178,138,203,103,176,186,55,94,251,230,65,87,184,36,171,145,147,49,203,50,152,187,80,215,130,155,69,95,111,209,50,58,52,222,129,36,227,89,72,15,138,56,22,182,105,55,194,4,2,21,73,14,222,181,47,193,89,148,90,105,9,100,219,84,110,122,32,103,223,208,54,188,84,209,162,15,145,206,37,26,196,227,196,239,87,254,53,250,146,114,55,131,77,90,220,53,79,51,39,33,18,26,16,85,213,199,82,76,53,144,193,67,88,79,32,12,249,18,185,205,246,51,92,167,88,193,162,6,19,103,126,51,118,20,88,226,90,196,161,242,78,150,88,139,167,168,143,23,221,127,50,1,41,232,108,80,39,95,191,219,116,158,37,210,223,224,45,74,226,124,149,71,236,17,135,147,14,193,232,215,128,58,111,177,42,14,232,119,176,23,92,160,63,5,63,39,245,63,224,55,210,121,154,231,109,85,93,56,207,237,157,159,159,198,21,60,134,232,61,119,162,190,117,46,211,101,247,70,7,19,52,121,119,207,169,222,119,47,247,72,220,127,2,100,202,20,14,0,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c02c3b56-5b96-4366-af70-1c204d27c6c2"));
		}

		#endregion

	}

	#endregion

}

