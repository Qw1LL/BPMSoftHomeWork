namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: InvalidQueryStructureExceptionSchema

	/// <exclude/>
	public class InvalidQueryStructureExceptionSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public InvalidQueryStructureExceptionSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public InvalidQueryStructureExceptionSchema(InvalidQueryStructureExceptionSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("efb635f4-13c4-4e2e-a2d4-fb0118960ea2");
			Name = "InvalidQueryStructureException";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("69e28147-db31-49df-9976-b6fb9eb762c1");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,149,82,203,110,194,48,16,60,131,196,63,172,194,5,46,201,157,2,135,144,30,122,168,68,149,47,112,204,38,177,148,56,145,31,165,81,197,191,119,157,7,6,170,34,245,16,43,59,59,179,59,107,175,100,53,234,150,113,132,248,248,158,54,185,9,15,141,204,69,97,21,51,162,145,97,210,73,86,11,78,160,65,105,22,243,239,197,124,102,181,144,5,164,157,54,88,191,92,99,175,87,24,38,49,37,40,181,84,88,80,25,56,84,76,235,13,36,135,20,43,228,38,182,162,58,161,122,253,226,216,186,54,61,55,138,34,216,106,91,215,76,117,251,49,190,50,192,148,170,57,75,200,58,226,32,2,87,152,239,130,135,122,65,180,135,115,137,242,150,50,16,92,166,100,26,132,252,100,149,56,129,54,202,114,99,201,233,212,56,186,233,220,218,172,18,28,184,51,13,111,131,228,195,162,234,210,73,230,125,109,188,71,82,210,245,208,233,199,110,228,208,169,81,52,253,177,47,59,48,30,135,237,129,4,115,102,43,3,220,203,156,191,223,6,39,135,207,189,173,214,224,158,107,118,121,210,242,56,142,234,59,66,78,159,70,3,168,20,253,209,122,104,86,32,221,28,224,84,248,15,83,61,210,50,197,106,160,165,193,93,48,106,131,189,191,174,17,10,183,81,79,252,199,48,228,207,173,217,88,96,237,132,179,13,100,76,227,106,194,238,198,93,162,60,13,207,208,199,3,122,15,94,126,0,43,238,17,57,254,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("efb635f4-13c4-4e2e-a2d4-fb0118960ea2"));
		}

		#endregion

	}

	#endregion

}

