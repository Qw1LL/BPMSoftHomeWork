namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IStartDeduplicationRequestFactorySchema

	/// <exclude/>
	public class IStartDeduplicationRequestFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IStartDeduplicationRequestFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IStartDeduplicationRequestFactorySchema(IStartDeduplicationRequestFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("317ae3ca-74ff-401a-9e48-5d31d65af269");
			Name = "IStartDeduplicationRequestFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c53ad23-c903-414d-89cd-b08703861304");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,77,79,2,65,12,134,207,144,240,31,26,188,104,98,118,239,138,36,130,154,236,65,67,224,224,121,216,233,174,19,118,103,214,78,199,72,140,255,221,249,0,132,0,198,219,190,109,223,238,211,78,181,104,209,118,162,68,152,204,158,23,166,226,108,106,116,165,106,71,130,149,209,217,3,74,215,53,170,140,106,208,255,26,244,123,206,42,93,195,65,226,177,17,150,85,153,189,226,242,190,83,161,5,147,40,217,102,115,124,119,104,217,222,14,250,222,121,65,88,251,106,40,52,35,85,254,167,55,80,76,92,179,58,232,53,119,13,62,121,179,161,117,52,229,121,14,35,235,218,86,208,122,188,209,51,50,31,74,162,133,22,249,205,72,168,12,193,210,169,70,6,50,203,130,216,203,102,5,114,191,49,80,130,201,182,77,243,189,174,157,91,250,58,80,91,50,40,22,161,205,33,89,242,239,224,122,97,27,71,124,49,48,37,20,236,249,254,195,114,12,147,34,157,32,209,130,246,15,116,55,180,88,6,219,139,23,195,241,34,137,152,202,70,121,172,59,109,83,90,226,103,50,21,225,243,140,133,144,29,105,59,142,35,255,69,59,202,183,165,193,123,118,67,155,241,207,230,47,45,83,124,169,223,169,174,253,170,98,108,135,124,229,111,166,247,157,238,6,181,76,167,19,164,143,253,0,247,225,51,50,182,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("317ae3ca-74ff-401a-9e48-5d31d65af269"));
		}

		#endregion

	}

	#endregion

}

