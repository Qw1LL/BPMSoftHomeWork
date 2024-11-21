namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFormDataToEntityMapperSchema

	/// <exclude/>
	public class IFormDataToEntityMapperSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFormDataToEntityMapperSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFormDataToEntityMapperSchema(IFormDataToEntityMapperSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("c20ea6f3-be52-42d0-824d-0e9ad343f8f2");
			Name = "IFormDataToEntityMapper";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("30ff16fc-9eaa-40ad-9611-33924da6f041");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,82,75,106,195,48,16,93,59,144,59,12,89,181,80,236,3,52,205,162,105,83,186,8,20,18,232,90,145,198,182,192,150,140,62,9,166,244,238,157,145,157,212,161,132,130,16,178,60,239,51,111,100,68,139,190,19,18,225,249,99,187,179,101,200,215,214,148,186,138,78,4,109,77,254,134,6,233,136,234,19,15,27,235,218,29,186,163,150,56,159,125,205,103,89,244,218,84,19,160,195,252,213,4,29,52,250,71,250,77,171,40,10,88,250,216,182,194,245,171,241,123,239,132,241,37,113,121,224,29,148,8,2,130,5,100,104,159,195,25,86,76,112,93,60,52,90,130,54,1,93,201,110,223,217,204,11,33,247,54,73,246,91,209,117,232,168,148,141,253,209,77,23,155,70,84,16,106,17,136,71,105,73,93,121,56,213,24,106,116,208,18,156,155,33,14,54,133,10,124,148,18,189,47,99,211,244,249,133,115,106,42,59,88,219,192,110,168,131,164,155,85,24,184,245,236,123,62,187,233,99,75,229,162,194,209,138,7,43,101,116,164,168,162,99,11,163,149,27,154,62,164,162,51,199,175,42,252,39,187,118,152,90,30,114,134,210,217,22,26,65,73,220,212,74,55,157,112,162,5,67,239,228,105,193,209,112,232,139,21,239,215,20,203,34,85,94,128,127,192,131,238,98,53,204,11,172,161,153,159,106,45,235,225,5,76,201,56,21,142,1,213,21,237,209,106,5,52,232,187,243,240,211,3,226,195,3,140,172,131,200,61,207,128,178,160,245,3,172,152,61,81,225,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("c20ea6f3-be52-42d0-824d-0e9ad343f8f2"));
		}

		#endregion

	}

	#endregion

}

