namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LeadLanguageIteratorSchema

	/// <exclude/>
	public class LeadLanguageIteratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LeadLanguageIteratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LeadLanguageIteratorSchema(LeadLanguageIteratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1252c774-91a4-464b-aa1f-d627521faa81");
			Name = "LeadLanguageIterator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("df5a8bee-e0f6-4225-b7c8-127f6fd1b1ca");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,77,107,194,64,16,61,71,240,63,12,233,69,161,36,119,171,66,181,23,193,82,105,241,84,122,24,215,73,88,216,236,134,253,160,216,226,127,239,228,67,141,169,224,33,11,51,243,222,155,55,51,209,88,144,43,81,16,44,54,175,31,38,243,201,210,232,76,230,193,162,151,70,15,7,191,195,65,20,156,212,121,7,96,233,105,56,224,252,131,165,156,65,176,84,232,220,4,222,202,210,88,31,180,244,135,53,234,60,96,78,43,79,44,100,108,13,79,211,20,166,46,20,5,218,195,188,141,79,0,200,248,83,210,249,170,211,238,0,138,112,15,170,85,113,201,137,157,118,232,101,216,41,41,64,84,205,97,205,248,126,83,152,192,2,29,253,247,18,241,80,252,94,252,27,237,188,13,130,139,60,198,166,214,109,16,125,203,141,103,158,80,162,146,63,228,64,211,55,72,102,163,230,21,154,140,193,68,32,44,101,179,248,150,165,56,157,39,112,22,238,78,211,100,74,180,88,128,230,163,204,226,224,200,178,51,77,162,186,68,60,223,114,12,226,156,72,166,105,141,174,201,237,46,110,181,28,109,175,116,224,90,118,92,177,163,104,2,59,222,212,168,87,131,234,248,81,116,82,124,15,138,39,158,213,51,175,186,201,207,175,22,25,85,37,22,240,40,252,74,119,221,84,176,158,147,241,99,189,137,30,233,89,8,19,180,191,203,189,80,95,40,195,160,252,125,244,145,255,90,126,219,219,147,222,55,231,175,227,38,123,157,60,254,1,87,163,138,122,29,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1252c774-91a4-464b-aa1f-d627521faa81"));
		}

		#endregion

	}

	#endregion

}

