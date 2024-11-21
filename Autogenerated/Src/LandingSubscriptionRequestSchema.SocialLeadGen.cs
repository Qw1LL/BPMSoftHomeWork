namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: LandingSubscriptionRequestSchema

	/// <exclude/>
	public class LandingSubscriptionRequestSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public LandingSubscriptionRequestSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public LandingSubscriptionRequestSchema(LandingSubscriptionRequestSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c0ca51e0-3be3-3d77-16f1-134361882e48");
			Name = "LandingSubscriptionRequest";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("f1114c1f-cbc3-4ea1-be84-e9eaafb87c31");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,203,106,195,48,16,69,215,49,248,31,6,186,183,247,77,233,162,41,132,64,74,76,221,31,24,75,99,119,192,146,28,61,40,33,228,223,43,75,118,9,45,116,51,48,87,151,51,71,26,21,185,9,5,193,75,243,214,154,222,87,59,163,123,30,130,69,207,70,87,173,17,140,227,145,80,238,73,151,197,181,44,54,193,177,30,160,189,56,79,106,91,22,49,121,176,52,196,50,236,70,116,238,17,142,168,101,172,180,161,115,194,242,52,115,222,233,28,200,249,212,174,235,26,158,92,80,10,237,229,121,217,95,63,78,96,115,7,190,216,127,2,235,222,88,149,28,0,59,19,60,140,153,90,173,132,250,14,49,133,110,100,1,98,190,255,239,249,77,252,64,156,63,198,141,53,19,89,207,20,181,155,4,201,239,191,29,83,176,128,129,229,44,241,215,98,213,216,7,150,107,249,32,225,10,3,249,45,184,121,220,150,243,164,101,54,72,123,78,239,195,219,55,96,157,222,114,152,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c0ca51e0-3be3-3d77-16f1-134361882e48"));
		}

		#endregion

	}

	#endregion

}

