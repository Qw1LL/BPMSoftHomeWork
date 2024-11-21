namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EsnCenterFactorySchema

	/// <exclude/>
	public class EsnCenterFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsnCenterFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsnCenterFactorySchema(EsnCenterFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("04389b5a-20dc-4773-ad27-ab521c1b58a1");
			Name = "EsnCenterFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,148,77,79,195,48,12,134,207,67,226,63,68,227,210,74,168,187,243,49,9,202,64,147,24,66,76,156,16,135,172,245,186,136,226,76,249,0,38,196,127,199,105,182,118,233,54,216,122,203,27,251,137,237,188,13,242,119,208,115,158,1,187,126,28,141,229,212,36,169,196,169,40,172,226,70,72,76,6,227,135,227,163,239,227,163,142,213,2,11,150,74,5,231,193,42,185,229,153,145,74,128,38,157,118,78,20,20,148,200,88,90,114,173,207,216,64,99,10,104,64,249,184,69,21,212,235,245,216,133,192,25,40,97,114,153,177,94,159,196,151,27,152,114,91,154,107,129,57,209,35,179,152,131,156,70,195,54,33,142,95,41,122,110,39,165,200,88,230,78,217,56,132,157,177,141,52,202,113,125,212,5,142,192,204,100,78,21,62,86,164,170,174,237,133,173,206,106,144,44,85,192,13,212,235,232,89,131,162,193,33,100,110,106,204,6,203,152,85,7,119,62,184,106,237,92,169,194,190,19,129,93,50,132,79,154,39,106,163,172,43,119,181,19,117,195,140,238,105,27,126,94,179,75,241,6,79,48,151,90,84,51,184,244,87,176,108,63,185,3,115,225,58,184,15,162,250,209,246,138,214,176,160,113,4,90,243,130,210,120,78,205,239,0,7,65,7,114,243,138,245,47,217,135,237,199,30,67,102,233,22,23,3,44,4,194,46,116,24,181,7,185,148,5,237,27,248,90,93,154,27,105,163,249,155,174,62,82,7,200,39,37,228,20,25,114,221,241,67,125,75,30,178,10,150,65,81,183,182,19,101,22,160,150,122,55,62,109,152,206,103,195,45,188,212,42,69,169,110,59,25,230,173,132,7,250,199,255,78,113,17,77,206,143,239,150,62,5,84,32,110,78,174,174,180,31,237,244,45,180,173,70,214,13,29,186,222,88,231,47,78,224,44,194,180,165,248,96,144,55,82,11,229,197,189,97,161,117,60,43,212,246,67,53,142,114,19,170,23,177,55,221,143,127,152,78,0,115,255,112,209,202,107,235,18,41,191,233,144,14,114,202,5,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("04389b5a-20dc-4773-ad27-ab521c1b58a1"));
		}

		#endregion

	}

	#endregion

}

