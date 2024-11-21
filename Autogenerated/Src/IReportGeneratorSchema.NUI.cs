namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IReportGeneratorSchema

	/// <exclude/>
	public class IReportGeneratorSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IReportGeneratorSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IReportGeneratorSchema(IReportGeneratorSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("1f7efd48-adaa-42e5-b285-f3efa252f7e7");
			Name = "IReportGenerator";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,82,193,106,195,48,12,61,167,208,127,16,233,101,131,17,223,187,44,135,109,48,122,40,132,150,125,128,231,40,153,161,177,131,108,23,202,216,191,207,177,155,172,73,115,177,209,179,158,244,244,44,197,91,52,29,23,8,175,229,254,168,107,155,189,105,85,203,198,17,183,82,171,245,234,103,189,74,156,145,170,89,78,200,14,216,105,178,71,164,179,20,248,188,144,76,61,234,241,13,97,227,9,176,83,22,169,246,29,183,176,139,228,15,84,232,171,105,10,121,140,49,200,141,107,91,78,151,226,26,151,164,207,178,66,3,20,8,208,68,70,223,168,118,74,244,66,248,73,218,75,54,240,217,77,129,206,125,157,164,0,57,244,93,104,155,248,41,253,57,106,220,163,253,214,149,217,66,25,184,241,113,46,44,0,215,34,163,180,94,193,189,132,136,116,156,120,11,202,59,254,146,58,131,228,141,84,24,196,167,197,167,143,65,140,64,150,179,144,189,76,22,183,63,144,22,163,59,19,28,106,77,51,191,52,221,215,37,180,142,148,41,14,241,134,206,83,56,97,53,204,147,179,33,163,167,68,231,222,185,229,227,228,15,189,244,255,81,96,58,217,19,204,204,158,108,207,84,241,99,92,148,100,131,170,138,31,17,226,223,184,62,19,208,99,127,107,34,127,108,186,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("1f7efd48-adaa-42e5-b285-f3efa252f7e7"));
		}

		#endregion

	}

	#endregion

}

