namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IThrottlingSchedulesProviderSchema

	/// <exclude/>
	public class IThrottlingSchedulesProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IThrottlingSchedulesProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IThrottlingSchedulesProviderSchema(IThrottlingSchedulesProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9ef08c3-4687-47dc-a929-945b22c2edc9");
			Name = "IThrottlingSchedulesProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("c3e4ee87-43fa-403d-acda-7e0e57f41b53");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,177,110,194,64,12,134,103,144,120,7,11,150,118,73,118,74,25,138,170,138,1,9,65,95,32,36,78,114,82,114,71,109,31,85,84,245,221,235,36,4,10,164,173,186,68,119,182,243,217,255,127,182,81,137,188,143,98,132,167,245,106,235,82,9,22,206,166,38,243,20,137,113,118,52,252,24,13,7,158,141,205,250,11,130,197,243,118,163,4,103,25,249,97,52,212,234,9,97,166,25,88,90,65,74,21,61,133,229,107,78,78,164,80,204,54,206,49,241,5,242,154,220,193,36,72,205,63,97,24,194,140,125,89,70,84,205,143,247,99,1,67,234,109,92,247,138,10,35,21,136,131,12,5,228,68,4,238,144,144,58,130,216,19,161,21,240,140,20,116,232,240,27,123,239,119,133,137,193,116,227,253,49,221,64,29,208,239,73,214,10,37,119,9,79,97,221,112,218,228,245,252,77,224,5,133,127,158,83,114,188,152,21,118,85,19,35,124,243,134,48,1,22,181,24,179,170,22,113,171,162,141,236,35,138,74,176,250,136,143,99,117,229,86,200,70,105,200,50,158,31,15,42,155,37,178,170,250,221,72,126,213,16,233,96,52,99,146,96,22,54,228,115,35,66,241,100,121,126,238,240,79,17,179,176,67,212,76,181,166,199,244,110,145,106,231,122,210,119,189,225,78,216,111,242,239,219,205,28,76,208,38,237,51,54,247,207,118,95,47,130,26,251,2,154,11,173,249,20,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9ef08c3-4687-47dc-a929-945b22c2edc9"));
		}

		#endregion

	}

	#endregion

}

