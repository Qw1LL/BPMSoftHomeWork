namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ImportEntitySavedEventArgsSchema

	/// <exclude/>
	public class ImportEntitySavedEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ImportEntitySavedEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ImportEntitySavedEventArgsSchema(ImportEntitySavedEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("d9862337-3e49-447c-a6fe-f4c905fd9341");
			Name = "ImportEntitySavedEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1101e5cd-b945-4f88-8001-faccb4fdb24c");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,143,193,106,195,48,12,134,207,41,244,29,12,189,231,1,218,211,22,186,145,67,33,212,236,1,188,68,113,205,98,217,88,118,183,80,246,238,83,226,210,109,221,200,69,32,233,243,167,223,168,44,144,87,45,136,199,230,32,93,31,203,202,97,111,116,10,42,26,135,229,147,25,160,182,222,133,184,94,93,214,171,34,145,65,45,228,72,17,236,238,214,127,191,13,80,238,49,154,104,128,120,205,192,38,128,102,145,168,6,69,180,21,217,53,35,163,84,103,232,246,103,192,248,16,52,205,180,79,175,131,105,69,59,193,11,172,96,17,246,238,0,68,74,195,15,69,193,25,185,222,174,54,193,121,8,83,154,173,104,102,119,222,251,124,231,57,153,238,122,70,178,139,95,212,157,184,8,13,113,39,104,42,159,127,241,163,115,81,182,39,176,234,101,17,206,185,57,129,177,42,140,215,238,14,47,138,123,123,117,74,248,182,232,77,6,35,135,120,175,177,131,143,255,184,13,96,151,191,63,247,121,250,123,200,179,47,250,120,200,195,249,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("d9862337-3e49-447c-a6fe-f4c905fd9341"));
		}

		#endregion

	}

	#endregion

}

