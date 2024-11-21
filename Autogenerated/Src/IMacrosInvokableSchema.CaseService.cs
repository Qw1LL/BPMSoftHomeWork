namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMacrosInvokableSchema

	/// <exclude/>
	public class IMacrosInvokableSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMacrosInvokableSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMacrosInvokableSchema(IMacrosInvokableSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("18dfac77-86d7-4509-8aee-d9ad2c50cf9c");
			Name = "IMacrosInvokable";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("33bac096-c819-4c57-86af-fe71bbb0cb56");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,81,77,79,195,48,12,61,183,82,255,131,165,93,224,178,220,97,218,1,14,168,135,74,72,8,238,105,230,118,133,54,158,28,103,18,66,251,239,36,105,10,149,6,55,219,122,31,126,182,213,19,186,147,54,8,15,207,205,11,117,178,125,36,219,13,189,103,45,3,217,170,252,170,202,194,187,193,246,43,0,227,125,85,134,249,134,177,15,32,168,173,32,119,65,228,14,234,70,27,166,128,63,211,135,110,71,76,56,165,20,236,156,159,38,205,159,251,220,255,112,128,58,152,18,9,58,98,72,76,220,46,44,181,162,157,124,59,14,38,32,22,102,54,171,127,205,138,184,238,149,95,26,188,58,100,48,100,45,154,152,44,58,92,91,20,17,21,46,144,65,137,180,106,147,122,209,163,132,252,161,112,185,184,164,148,127,219,54,40,71,58,128,28,181,0,163,120,182,14,156,112,60,232,89,143,30,83,232,57,255,63,43,165,73,166,238,25,157,31,37,43,236,212,50,142,184,172,250,132,50,159,229,45,202,223,80,251,30,150,7,205,189,159,208,138,187,157,95,55,175,188,65,123,152,127,24,219,203,55,173,172,64,145,13,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("18dfac77-86d7-4509-8aee-d9ad2c50cf9c"));
		}

		#endregion

	}

	#endregion

}

