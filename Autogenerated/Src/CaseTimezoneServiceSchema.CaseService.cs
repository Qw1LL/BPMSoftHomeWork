namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: CaseTimezoneServiceSchema

	/// <exclude/>
	public class CaseTimezoneServiceSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public CaseTimezoneServiceSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public CaseTimezoneServiceSchema(CaseTimezoneServiceSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("992549c5-f56f-432d-80e7-1157f156a8c6");
			Name = "CaseTimezoneService";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d90d0856-ba58-4278-952e-572fe1ed6e53");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,83,193,78,194,64,16,61,67,226,63,108,56,97,66,218,187,2,137,144,168,152,32,132,106,60,16,15,75,59,224,198,238,110,221,153,146,84,195,191,59,219,22,138,65,241,64,147,125,243,118,246,189,55,131,145,26,48,147,49,136,209,124,26,217,53,5,99,107,214,106,147,59,73,202,154,139,246,215,69,187,149,163,50,27,17,21,72,160,131,8,220,86,197,48,181,9,164,215,231,138,193,77,76,106,91,182,57,207,123,129,85,67,104,100,56,56,69,153,202,21,173,203,150,92,13,195,80,244,49,215,90,186,98,88,159,199,18,65,144,210,32,62,173,1,129,213,83,193,158,29,30,209,151,181,14,246,76,78,198,244,234,177,27,204,30,129,248,149,140,181,175,84,170,168,88,192,71,174,28,104,48,132,221,227,131,55,32,6,226,159,43,158,21,212,64,114,233,31,201,242,85,170,98,17,167,18,177,20,252,196,122,189,220,90,144,184,18,35,70,235,19,95,240,99,56,113,91,2,119,64,34,102,253,44,191,113,125,96,31,187,173,144,76,58,169,133,225,185,15,58,245,189,73,210,25,246,195,178,208,240,28,80,238,12,14,79,122,247,195,125,201,115,151,179,12,170,93,57,14,177,181,228,73,77,204,214,190,67,119,10,244,102,19,78,169,51,159,69,79,157,158,240,73,0,210,173,117,90,18,227,76,157,2,162,220,64,5,5,15,104,77,79,140,108,82,68,84,164,62,224,134,114,64,131,23,39,179,12,146,158,127,110,193,75,108,13,214,13,254,234,89,70,191,207,30,201,249,205,226,248,188,112,214,189,31,65,183,174,28,194,185,20,101,250,173,202,246,143,113,221,67,202,246,131,95,154,60,243,222,49,102,128,255,4,222,77,211,205,111,117,107,199,31,254,237,190,1,49,229,35,148,128,3,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("992549c5-f56f-432d-80e7-1157f156a8c6"));
		}

		#endregion

	}

	#endregion

}

