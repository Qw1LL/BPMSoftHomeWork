namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IFragmentSynchronizableSchema

	/// <exclude/>
	public class IFragmentSynchronizableSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IFragmentSynchronizableSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IFragmentSynchronizableSchema(IFragmentSynchronizableSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1d438be3-42dd-4256-9b99-40dbca5fc709");
			Name = "IFragmentSynchronizable";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d0bba11f-3986-4819-81ab-1d3ddbfc1f48");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,145,193,78,195,48,16,68,207,173,148,127,88,149,11,92,154,123,41,57,80,4,202,33,82,69,191,96,235,174,29,75,201,58,90,59,135,130,248,119,156,56,133,64,5,151,72,179,158,140,223,172,25,91,242,29,42,130,199,125,117,112,58,172,119,142,181,53,189,96,176,142,179,229,123,182,204,150,139,27,33,19,37,148,28,72,116,180,111,160,124,22,52,45,113,56,156,89,213,226,216,190,225,177,161,209,158,231,57,108,125,223,182,40,231,98,210,79,228,149,216,35,121,240,29,41,171,173,130,198,153,248,213,78,64,97,219,161,53,12,29,74,176,202,118,200,33,26,191,147,7,152,245,37,57,159,69,119,253,177,137,33,246,2,246,55,215,34,85,249,234,82,81,168,221,201,111,96,63,70,164,195,223,228,227,224,149,66,47,124,197,3,45,50,26,18,8,53,6,176,179,98,99,165,94,36,82,0,53,52,208,12,240,215,244,105,34,41,191,40,217,7,228,216,193,233,8,65,4,74,72,63,172,202,221,180,157,121,179,42,221,189,42,214,219,252,242,255,16,248,159,25,94,104,46,111,239,238,167,141,16,159,210,82,70,253,145,158,252,199,48,206,62,1,88,36,101,145,43,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1d438be3-42dd-4256-9b99-40dbca5fc709"));
		}

		#endregion

	}

	#endregion

}

