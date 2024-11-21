namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LandingSubscribtionResponseSchema

	/// <exclude/>
	public class LandingSubscribtionResponseSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LandingSubscribtionResponseSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LandingSubscribtionResponseSchema(LandingSubscribtionResponseSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("da97b47f-924c-f15e-42df-bea8ad415e53");
			Name = "LandingSubscribtionResponse";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,201,106,195,64,12,61,199,224,127,16,228,110,223,219,210,67,83,26,2,105,107,234,254,192,44,202,48,48,158,49,179,28,74,200,191,119,22,59,164,11,141,123,17,72,122,239,233,33,73,147,1,221,72,24,194,67,247,220,155,131,111,54,70,31,164,8,150,120,105,116,211,27,38,137,218,35,225,91,212,117,117,172,171,186,90,173,45,138,216,132,141,34,206,221,192,158,104,46,181,232,3,117,204,74,154,120,111,81,212,104,135,25,222,182,45,220,185,48,12,196,126,220,79,249,227,251,43,216,9,4,132,154,224,193,93,240,155,153,214,94,240,198,64,149,100,192,210,212,191,135,174,138,207,179,209,206,154,17,173,151,24,221,118,89,165,244,191,59,203,133,142,8,4,201,147,133,159,30,102,19,206,219,56,61,99,119,28,142,32,208,223,130,75,225,116,77,90,199,149,47,22,127,137,224,197,242,79,198,14,203,229,19,250,95,242,59,7,42,62,66,68,107,44,239,113,190,25,94,89,23,53,70,69,254,244,71,243,209,240,215,205,173,81,243,114,183,156,151,234,215,226,233,19,70,17,201,209,183,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("da97b47f-924c-f15e-42df-bea8ad415e53"));
		}

		#endregion

	}

	#endregion

}

