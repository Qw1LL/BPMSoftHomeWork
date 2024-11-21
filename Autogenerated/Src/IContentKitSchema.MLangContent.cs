namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IContentKitSchema

	/// <exclude/>
	public class IContentKitSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IContentKitSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IContentKitSchema(IContentKitSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("37dac048-4167-4f6c-9dc9-b9ea768da408");
			Name = "IContentKit";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("16e592d3-2033-426b-b620-6aa2b1f8eec0");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,83,65,78,195,48,16,60,167,82,255,96,181,23,144,80,114,47,165,7,16,170,34,168,168,218,23,152,100,19,86,36,118,180,222,28,34,212,191,227,196,118,160,165,173,56,36,202,174,103,102,199,19,91,201,26,76,35,51,16,143,219,205,94,23,28,63,105,85,96,217,146,100,212,106,58,249,154,78,162,214,160,42,197,190,51,12,245,253,88,255,16,8,226,103,197,200,8,198,46,91,192,156,160,180,108,145,42,6,42,172,250,66,164,86,151,65,241,11,242,0,73,146,68,44,77,91,215,146,186,149,175,119,208,16,24,11,50,226,19,89,20,154,68,221,86,140,149,84,101,43,75,16,153,211,136,3,63,249,37,208,180,239,21,102,2,195,200,227,137,145,221,135,125,143,206,182,164,27,160,222,241,66,108,7,166,91,63,181,53,52,94,195,124,180,218,146,53,245,6,254,58,136,210,0,76,61,110,100,142,141,62,206,40,42,129,251,28,163,200,248,143,195,149,233,126,27,194,88,62,92,154,236,65,251,30,19,24,174,184,62,113,14,42,119,145,28,231,179,1,254,208,249,127,194,217,1,183,164,76,248,55,194,62,200,221,5,159,67,167,145,36,107,161,236,201,123,152,57,116,154,207,86,111,132,37,42,89,121,129,81,15,243,190,81,32,80,188,76,6,234,121,37,130,76,83,222,43,13,103,177,19,174,113,149,79,206,251,106,115,238,148,133,157,44,147,0,235,121,94,124,13,236,83,190,89,183,152,123,108,154,223,137,161,12,102,110,221,125,56,141,217,133,127,220,60,124,3,157,148,37,215,139,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("37dac048-4167-4f6c-9dc9-b9ea768da408"));
		}

		#endregion

	}

	#endregion

}

