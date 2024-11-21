namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LangSupMailBoxBinderSchema

	/// <exclude/>
	public class LangSupMailBoxBinderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LangSupMailBoxBinderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LangSupMailBoxBinderSchema(LangSupMailBoxBinderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eab7a1a7-4947-4699-89fb-5232e0e5fe99");
			Name = "LangSupMailBoxBinder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,144,193,106,195,48,16,68,207,10,228,31,22,247,146,66,177,239,105,106,168,67,11,133,132,26,124,232,89,145,215,174,32,150,204,74,54,9,37,255,222,181,21,211,132,38,23,27,237,140,222,106,198,200,6,93,43,21,66,150,111,11,91,249,120,109,77,165,235,142,164,215,214,204,103,63,243,153,232,156,54,245,133,129,48,126,151,202,91,210,232,158,255,233,95,184,99,79,211,88,195,26,171,15,132,53,163,96,189,151,206,45,97,35,77,93,116,237,86,234,125,102,15,153,54,37,210,232,75,146,4,86,174,107,26,73,199,244,124,14,50,84,150,88,66,4,69,88,189,68,31,127,247,7,90,78,182,215,108,139,146,52,158,56,201,5,168,237,118,123,173,64,13,251,111,174,135,37,188,182,237,91,143,198,111,180,243,104,144,50,233,144,175,114,122,254,138,41,194,22,253,183,45,57,68,62,34,131,120,198,219,30,137,248,25,208,91,93,194,167,97,98,225,37,249,197,132,230,98,61,30,60,168,240,127,132,161,90,33,118,188,41,190,176,79,242,80,172,16,99,105,161,236,227,56,16,241,240,230,213,157,10,158,224,246,60,93,68,215,66,20,248,167,115,62,52,101,136,56,158,195,244,122,120,250,5,122,0,56,96,42,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eab7a1a7-4947-4699-89fb-5232e0e5fe99"));
		}

		#endregion

	}

	#endregion

}

