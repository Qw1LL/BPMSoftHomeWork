namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPersistentColumnProcessorSchema

	/// <exclude/>
	public class IPersistentColumnProcessorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPersistentColumnProcessorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPersistentColumnProcessorSchema(IPersistentColumnProcessorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("9d8cf2ba-6149-493d-80f4-bea4d4b996f5");
			Name = "IPersistentColumnProcessor";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,140,65,10,195,32,16,69,215,21,188,131,7,40,57,64,187,75,160,224,162,16,200,9,172,140,97,64,103,100,70,23,33,244,238,181,219,66,225,175,222,127,60,10,5,180,134,8,110,94,159,27,167,54,45,76,9,247,46,161,33,211,244,192,12,190,84,150,102,205,105,205,165,43,210,238,182,67,27,148,187,53,131,212,254,202,24,29,82,3,73,223,144,95,65,20,135,64,109,225,220,11,173,194,17,84,89,110,127,191,171,243,115,80,248,241,71,253,116,111,107,198,62,36,90,44,37,168,0,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("9d8cf2ba-6149-493d-80f4-bea4d4b996f5"));
		}

		#endregion

	}

	#endregion

}

