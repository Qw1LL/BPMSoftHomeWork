namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ServiceTermProviderFactorySchema

	/// <exclude/>
	public class ServiceTermProviderFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ServiceTermProviderFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ServiceTermProviderFactorySchema(ServiceTermProviderFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("af9b1e78-e018-487e-9a15-deed4c262d47");
			Name = "ServiceTermProviderFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,219,106,131,64,16,125,86,240,31,134,60,37,32,250,1,181,66,155,210,208,135,66,192,244,3,204,102,12,91,116,149,157,221,20,41,249,247,206,174,230,30,210,7,69,103,206,217,115,206,204,90,146,106,11,69,79,6,155,100,222,214,53,10,35,91,69,201,2,21,106,41,158,162,208,122,200,235,242,179,104,43,195,24,141,119,139,201,123,41,76,171,37,18,183,163,80,149,13,82,87,10,60,3,169,74,110,173,46,157,64,82,160,222,73,129,43,212,77,20,254,70,97,144,166,41,100,100,155,166,212,125,62,254,187,46,116,186,221,201,13,106,168,188,64,159,28,192,233,25,186,179,235,90,10,16,117,73,228,105,203,145,53,184,234,25,226,68,110,84,124,97,129,134,128,58,20,178,146,194,219,3,227,149,75,205,41,248,147,156,230,173,232,80,241,40,112,121,159,39,162,85,27,233,7,56,201,87,23,71,0,161,155,45,28,17,73,150,250,230,253,131,44,161,230,129,169,97,29,147,252,139,255,29,119,44,220,146,53,26,171,21,229,197,195,24,89,122,192,57,226,56,180,157,212,198,150,53,124,92,112,253,16,143,76,55,163,7,237,233,155,244,190,120,48,25,25,205,119,35,134,118,253,205,102,243,83,98,138,193,197,56,197,130,203,148,51,240,43,10,6,139,48,119,187,28,215,199,215,209,100,15,244,243,169,103,6,10,127,128,15,100,11,214,241,94,244,214,54,168,204,244,124,49,241,153,163,89,252,15,239,106,15,241,181,229,25,95,246,32,216,243,139,159,253,31,18,16,88,139,78,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("af9b1e78-e018-487e-9a15-deed4c262d47"));
		}

		#endregion

	}

	#endregion

}

