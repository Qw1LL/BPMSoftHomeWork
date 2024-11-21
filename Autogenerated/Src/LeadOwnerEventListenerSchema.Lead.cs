namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LeadOwnerEventListenerSchema

	/// <exclude/>
	public class LeadOwnerEventListenerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LeadOwnerEventListenerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LeadOwnerEventListenerSchema(LeadOwnerEventListenerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("265f0b5e-a6be-455d-942d-40f04c0b5236");
			Name = "LeadOwnerEventListener";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b424f2c1-869b-44e8-aaf1-c9a818421e06");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,81,193,78,2,49,16,61,67,194,63,76,214,139,94,218,59,130,7,8,55,20,146,61,26,15,99,153,93,155,108,91,210,233,66,54,198,127,119,186,136,68,179,202,165,201,155,121,111,230,205,171,71,71,188,71,67,176,216,62,150,161,74,106,25,124,101,235,54,98,178,193,79,198,239,147,241,168,101,235,107,40,59,78,228,238,191,241,69,16,105,184,170,86,62,217,100,137,175,180,213,234,64,62,101,150,240,110,34,213,178,25,150,13,50,79,97,77,184,219,28,61,197,158,179,182,226,65,64,207,212,90,195,140,91,231,48,118,15,95,248,76,128,80,65,200,50,144,81,121,6,136,218,166,78,157,117,250,151,112,198,68,216,112,0,19,169,154,23,255,249,84,11,100,234,107,221,15,83,5,232,60,237,121,160,117,91,154,55,114,248,36,105,195,28,138,108,168,184,123,17,242,190,125,109,172,1,147,143,253,227,86,152,194,101,225,80,20,35,249,35,121,63,78,241,145,223,157,18,204,80,106,159,241,205,230,161,226,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("265f0b5e-a6be-455d-942d-40f04c0b5236"));
		}

		#endregion

	}

	#endregion

}

