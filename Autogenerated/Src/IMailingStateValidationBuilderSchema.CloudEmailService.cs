namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IMailingStateValidationBuilderSchema

	/// <exclude/>
	public class IMailingStateValidationBuilderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IMailingStateValidationBuilderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IMailingStateValidationBuilderSchema(IMailingStateValidationBuilderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("a8d7af86-6b55-4390-b894-80b48b52f7ba");
			Name = "IMailingStateValidationBuilder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("bbfdb6d8-67aa-4e5b-af46-39321e13789f");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,145,77,107,195,48,12,134,207,13,228,63,136,246,178,93,226,251,150,229,208,50,74,15,133,176,192,238,110,162,164,6,127,20,89,238,40,99,255,125,118,188,66,183,49,24,24,97,189,178,94,61,182,173,52,232,79,178,71,88,183,251,206,141,92,109,156,29,213,20,72,178,114,182,44,222,203,98,17,188,178,19,116,23,207,104,98,93,107,236,83,209,87,91,180,72,170,127,44,139,120,74,8,1,181,15,198,72,186,52,95,121,75,238,172,6,244,96,144,143,110,0,118,48,33,3,5,29,181,209,17,120,150,140,112,150,90,13,146,29,85,87,31,113,99,116,10,7,173,122,80,150,145,198,132,186,219,75,165,35,82,151,154,95,115,111,228,89,7,165,7,164,216,17,161,99,92,172,8,167,168,195,126,30,238,31,160,157,157,114,81,252,192,157,133,45,178,7,62,226,13,161,201,179,190,147,70,215,132,250,155,53,43,132,28,200,250,166,246,136,208,19,142,79,203,221,179,13,6,73,30,52,214,127,240,191,196,153,205,82,52,240,166,248,152,9,170,90,92,189,146,249,127,77,210,61,210,198,223,221,231,191,89,172,208,14,249,53,230,252,163,44,226,250,4,7,109,17,102,253,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("a8d7af86-6b55-4390-b894-80b48b52f7ba"));
		}

		#endregion

	}

	#endregion

}

