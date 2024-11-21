namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CacheUtilitiesSchema

	/// <exclude/>
	public class CacheUtilitiesSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CacheUtilitiesSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CacheUtilitiesSchema(CacheUtilitiesSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e686424e-171b-4e43-9ed2-8c621f1495a0");
			Name = "CacheUtilities";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,165,84,75,79,227,48,16,62,167,18,255,193,202,9,164,85,196,121,17,7,72,217,114,41,90,81,88,14,8,161,73,58,180,22,110,28,217,99,216,21,234,127,223,113,146,74,113,19,250,80,114,136,146,153,249,94,19,183,5,172,208,150,144,163,184,254,61,157,233,55,74,82,93,188,201,133,51,64,82,23,39,163,175,147,81,228,172,44,22,173,1,131,23,157,234,19,102,201,45,81,153,92,101,150,12,228,30,109,121,140,7,75,151,41,153,11,75,76,153,139,92,129,181,34,133,124,137,143,36,149,36,137,150,135,88,135,239,81,105,228,7,16,110,134,153,202,139,164,206,24,44,40,117,138,156,193,59,246,44,188,175,40,90,32,53,79,209,7,24,225,44,26,246,95,96,37,47,46,197,233,99,80,57,243,14,249,149,240,47,231,168,73,147,25,90,203,189,231,56,156,141,95,124,72,190,12,178,104,177,197,189,65,123,76,210,248,74,188,177,26,180,246,247,117,19,41,136,223,36,122,210,230,189,218,123,181,136,137,209,174,236,70,106,148,107,72,242,75,155,21,208,105,220,3,125,253,58,95,199,63,122,214,116,22,218,249,198,204,24,9,164,178,21,223,161,46,218,152,129,242,87,245,97,57,74,190,141,25,40,127,143,165,54,116,156,124,27,51,52,125,1,234,31,191,219,154,179,182,113,41,226,190,122,124,177,159,38,93,194,134,229,208,93,118,161,3,51,77,140,156,255,145,248,121,148,141,0,52,208,192,205,92,82,112,170,121,161,219,181,29,203,188,89,241,212,3,174,74,197,255,69,173,95,168,103,233,180,118,240,76,245,220,41,28,3,65,72,210,87,255,233,19,31,242,125,3,166,158,242,30,162,137,210,25,168,218,65,200,213,223,217,65,213,124,150,45,75,221,234,94,55,51,4,147,47,251,220,108,119,118,80,141,193,46,51,13,102,254,0,89,72,213,223,169,168,248,8,173,255,3,150,209,64,149,4,7,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e686424e-171b-4e43-9ed2-8c621f1495a0"));
		}

		#endregion

	}

	#endregion

}

