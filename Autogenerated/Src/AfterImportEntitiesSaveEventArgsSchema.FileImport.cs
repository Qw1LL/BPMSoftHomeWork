namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: AfterImportEntitiesSaveEventArgsSchema

	/// <exclude/>
	public class AfterImportEntitiesSaveEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public AfterImportEntitiesSaveEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public AfterImportEntitiesSaveEventArgsSchema(AfterImportEntitiesSaveEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("232e8c67-42ba-4203-936e-0c03b535963d");
			Name = "AfterImportEntitiesSaveEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1101e5cd-b945-4f88-8001-faccb4fdb24c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,133,142,65,10,131,48,16,69,215,21,188,195,64,247,30,64,87,86,90,112,81,144,122,130,212,142,33,160,19,201,76,44,69,122,247,70,83,74,187,234,102,32,111,242,254,31,82,35,242,164,58,132,67,115,110,109,47,89,101,169,55,218,59,37,198,82,118,50,3,214,227,100,157,164,201,146,38,59,207,134,52,180,15,22,28,139,52,9,100,239,80,135,159,80,13,138,57,135,178,23,116,209,56,146,24,49,200,173,154,241,56,35,73,233,52,111,206,228,175,131,233,160,91,149,191,6,228,80,83,111,207,200,172,244,119,208,46,28,20,230,231,130,198,217,9,221,234,231,208,108,13,113,255,110,243,134,4,98,15,222,46,246,206,149,245,129,44,160,81,10,224,117,60,223,129,72,183,152,185,189,35,253,133,129,189,0,87,139,201,87,59,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("232e8c67-42ba-4203-936e-0c03b535963d"));
		}

		#endregion

	}

	#endregion

}

