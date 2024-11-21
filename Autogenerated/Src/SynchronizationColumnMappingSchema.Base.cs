namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: SynchronizationColumnMappingSchema

	/// <exclude/>
	public class SynchronizationColumnMappingSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public SynchronizationColumnMappingSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public SynchronizationColumnMappingSchema(SynchronizationColumnMappingSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ceda90a8-7b55-4117-960b-9e514c386e94");
			Name = "SynchronizationColumnMapping";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,141,146,65,110,195,32,16,69,215,177,228,59,140,148,125,188,111,171,46,234,54,59,87,145,124,2,138,177,131,4,3,98,32,146,91,245,238,197,96,71,113,90,165,217,121,134,249,243,31,31,35,211,130,44,227,2,94,14,77,107,122,191,171,13,246,114,8,142,121,105,112,247,134,94,250,177,29,145,31,157,65,249,153,186,101,241,85,22,101,177,217,58,49,196,18,106,197,136,30,224,106,170,54,42,104,108,152,181,18,135,52,95,85,21,60,81,208,154,185,241,121,174,163,157,103,18,9,104,173,6,158,228,160,179,30,36,246,198,233,12,181,172,170,46,118,217,240,161,36,7,62,161,252,67,178,201,244,103,252,70,248,163,233,226,5,246,82,168,142,242,225,53,107,106,180,38,184,24,213,140,134,49,187,137,229,55,204,66,67,222,77,236,89,150,41,222,163,232,241,134,197,171,32,47,113,21,193,221,62,23,218,251,204,242,20,156,152,10,130,162,157,182,44,190,187,113,183,221,254,76,183,62,139,227,214,229,115,246,222,10,236,114,214,169,254,206,63,207,170,25,123,63,57,124,128,122,139,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ceda90a8-7b55-4117-960b-9e514c386e94"));
		}

		#endregion

	}

	#endregion

}

