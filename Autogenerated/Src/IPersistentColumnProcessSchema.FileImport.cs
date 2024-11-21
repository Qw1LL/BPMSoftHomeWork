namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPersistentColumnProcessSchema

	/// <exclude/>
	public class IPersistentColumnProcessSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPersistentColumnProcessSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPersistentColumnProcessSchema(IPersistentColumnProcessSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("8195325f-d746-484e-902f-eef26fde2768");
			Name = "IPersistentColumnProcess";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b51eda84-5cfb-4f7f-b7eb-7f869b20e7e8");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,93,143,207,106,195,48,12,135,207,9,228,29,68,122,217,46,241,125,75,115,104,89,161,135,130,97,79,224,57,74,38,136,255,32,219,165,163,244,221,231,36,219,24,57,248,96,73,191,79,250,172,50,24,188,210,8,7,121,121,119,67,108,142,206,14,52,38,86,145,156,109,78,52,225,217,120,199,177,42,239,69,81,149,133,79,31,19,105,32,27,145,135,57,120,150,200,129,66,68,27,143,110,74,198,74,118,26,67,200,179,247,252,138,29,227,152,81,112,193,248,233,250,240,2,114,33,84,229,220,20,66,64,27,146,49,138,191,186,223,194,219,13,117,138,8,87,53,37,12,224,87,30,217,177,129,191,140,216,134,90,175,88,25,176,89,104,95,211,114,178,156,43,152,239,12,117,151,183,32,130,102,28,246,245,42,244,175,43,186,86,44,241,133,118,117,212,195,143,196,211,118,22,182,232,231,215,213,100,135,182,95,77,243,239,81,149,143,111,18,11,235,209,91,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("8195325f-d746-484e-902f-eef26fde2768"));
		}

		#endregion

	}

	#endregion

}

