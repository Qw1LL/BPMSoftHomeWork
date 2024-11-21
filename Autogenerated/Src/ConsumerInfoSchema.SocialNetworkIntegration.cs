namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ConsumerInfoSchema

	/// <exclude/>
	public class ConsumerInfoSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ConsumerInfoSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ConsumerInfoSchema(ConsumerInfoSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("12a01026-e84b-495c-b275-01c91bdee21b");
			Name = "ConsumerInfo";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4e5fe717-963e-416c-b3c1-b2bb720a6449");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,144,193,74,3,49,16,134,207,187,176,239,16,218,139,94,246,1,20,47,214,139,72,203,210,128,151,226,33,141,179,75,112,147,44,51,19,97,91,250,238,157,205,170,160,84,4,47,97,102,254,63,223,228,79,48,30,104,48,22,212,125,179,214,177,229,122,21,67,235,186,132,134,93,12,181,142,214,153,190,42,143,85,89,36,114,161,83,122,36,6,95,111,83,96,231,161,214,128,98,112,135,108,191,173,74,241,45,17,58,105,212,170,55,68,55,74,128,148,60,224,99,104,99,214,119,15,134,141,76,25,141,229,23,25,12,105,223,59,171,236,228,255,97,47,100,177,156,95,204,6,227,0,200,14,4,220,228,107,179,158,153,107,240,123,192,171,141,100,82,119,106,241,6,227,226,122,226,127,46,32,198,41,193,19,140,106,202,83,20,29,176,60,89,10,250,40,78,191,211,8,44,2,95,4,234,44,253,131,249,14,72,146,234,34,244,121,214,254,160,46,33,188,206,95,147,251,121,250,125,120,58,3,33,93,215,131,228,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("12a01026-e84b-495c-b275-01c91bdee21b"));
		}

		#endregion

	}

	#endregion

}

