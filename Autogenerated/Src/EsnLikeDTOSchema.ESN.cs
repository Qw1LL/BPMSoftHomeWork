namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: EsnLikeDTOSchema

	/// <exclude/>
	public class EsnLikeDTOSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public EsnLikeDTOSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public EsnLikeDTOSchema(EsnLikeDTOSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9ba4548-db18-453f-afd7-0da2ee2c2296");
			Name = "EsnLikeDTO";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b66b5ae8-46e0-4931-ad78-c2c1ba5fd6ea");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,146,193,110,194,48,12,134,207,32,241,14,17,92,182,75,31,96,104,151,1,66,149,86,86,173,219,105,218,33,164,166,178,214,164,85,156,28,24,226,221,231,164,48,173,83,145,224,18,233,183,127,127,142,157,24,169,129,90,169,64,60,229,89,209,236,92,178,104,204,14,43,111,165,195,198,36,171,98,51,25,31,38,227,145,39,52,149,40,246,228,64,207,255,233,228,213,27,135,26,146,2,44,202,26,191,99,45,187,216,55,179,80,177,16,139,90,18,61,136,21,153,103,252,130,229,219,75,204,126,44,165,147,220,209,89,169,220,39,7,90,191,173,81,9,21,220,61,243,40,92,226,151,150,219,166,5,235,16,24,153,199,146,136,235,120,25,232,45,216,187,13,143,38,30,197,20,203,233,125,64,159,217,107,143,165,72,75,113,16,21,184,185,160,112,28,47,151,83,163,120,166,12,136,100,5,233,16,171,232,59,174,5,123,2,59,200,123,143,137,107,49,138,183,199,203,27,36,45,206,185,27,97,65,246,113,228,108,120,239,19,48,218,111,67,230,22,181,180,251,84,95,218,226,9,221,247,13,53,153,129,41,187,111,192,170,139,253,13,29,127,0,84,213,212,190,211,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9ba4548-db18-453f-afd7-0da2ee2c2296"));
		}

		#endregion

	}

	#endregion

}

