namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: InfoMessageEventArgsSchema

	/// <exclude/>
	public class InfoMessageEventArgsSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public InfoMessageEventArgsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public InfoMessageEventArgsSchema(InfoMessageEventArgsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("581d1ca8-4c25-474e-9e2b-79fe22e7b14e");
			Name = "InfoMessageEventArgs";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("1a247561-b87d-48fb-9e13-b6a8baa960d3");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,157,145,65,10,194,48,16,69,215,22,122,135,129,238,61,128,174,84,170,116,81,40,244,4,177,157,134,64,155,132,153,84,148,226,221,77,90,149,170,93,185,9,201,240,230,255,249,19,45,58,100,43,42,132,125,145,151,166,113,235,131,209,141,146,61,9,167,140,94,31,85,139,89,103,13,185,56,26,226,104,213,179,210,18,202,27,59,236,182,113,228,43,9,161,244,36,192,161,21,204,27,72,137,12,229,200,44,36,166,23,212,110,71,146,71,210,246,231,86,85,80,5,110,25,131,13,100,186,49,191,221,171,224,253,182,42,200,88,36,167,208,219,21,163,232,168,255,50,56,245,170,134,105,232,210,43,249,142,172,134,1,36,186,45,112,56,238,31,120,122,173,208,134,176,179,219,240,75,39,168,235,201,223,191,166,218,188,180,176,137,229,40,223,139,88,162,252,30,254,13,207,142,194,15,61,21,255,8,226,163,61,0,8,230,186,120,21,2,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("581d1ca8-4c25-474e-9e2b-79fe22e7b14e"));
		}

		#endregion

	}

	#endregion

}

