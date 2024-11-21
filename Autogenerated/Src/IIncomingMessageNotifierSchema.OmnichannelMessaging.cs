namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IIncomingMessageNotifierSchema

	/// <exclude/>
	public class IIncomingMessageNotifierSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IIncomingMessageNotifierSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IIncomingMessageNotifierSchema(IIncomingMessageNotifierSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ce1c4ef7-b936-4dd7-987d-b5980c9beea9");
			Name = "IIncomingMessageNotifier";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("92ff52b6-dfba-4556-90d8-6f4c37f69c5d");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,181,147,193,78,195,48,12,134,207,157,212,119,176,182,203,184,180,247,49,42,1,167,74,20,166,241,4,89,235,118,145,26,167,138,211,161,9,237,221,233,210,166,27,84,32,14,112,140,253,251,247,231,196,33,161,144,27,145,35,60,108,178,87,93,218,232,81,83,41,171,214,8,43,53,69,47,138,100,190,23,68,88,71,25,50,139,74,82,21,206,222,195,89,56,11,22,6,171,78,4,41,89,52,101,103,178,130,52,165,92,171,78,211,139,241,89,91,89,74,52,78,31,199,49,172,185,85,74,152,99,50,156,183,216,24,100,36,203,32,189,13,148,218,0,185,74,170,160,150,108,145,208,48,136,157,110,45,16,190,129,234,221,35,111,26,95,185,54,237,174,150,249,149,219,247,76,65,55,71,48,142,145,161,221,235,130,87,176,113,14,14,121,194,236,2,247,69,193,142,195,179,157,65,166,36,125,164,17,70,40,160,238,162,239,230,94,63,79,6,150,139,195,58,118,66,87,119,208,178,56,55,121,26,146,203,175,35,248,196,88,126,115,251,3,238,22,149,62,32,255,43,109,223,227,143,128,135,23,186,16,243,111,145,135,197,152,39,190,255,184,42,19,98,215,228,232,193,120,57,174,183,31,118,168,244,164,11,164,162,223,20,119,62,245,95,224,83,240,244,1,200,96,168,198,79,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ce1c4ef7-b936-4dd7-987d-b5980c9beea9"));
		}

		#endregion

	}

	#endregion

}

