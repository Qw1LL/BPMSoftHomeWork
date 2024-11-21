namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IImapFolderSchema

	/// <exclude/>
	public class IImapFolderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IImapFolderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IImapFolderSchema(IImapFolderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6310e556-8a63-4c49-b0b8-076bc13c50bb");
			Name = "IImapFolder";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("76eace8e-4a48-486b-bf04-de18fe06b0a2");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,142,193,10,194,48,16,68,207,45,244,31,22,188,251,1,245,38,82,8,216,82,236,23,196,118,27,23,210,36,36,81,15,165,255,110,72,80,90,212,227,206,155,153,29,197,39,116,134,247,8,199,182,238,244,232,247,53,39,89,228,115,145,23,121,182,179,40,72,43,96,202,163,29,131,171,4,198,38,110,42,45,7,180,209,98,238,87,73,61,208,219,177,53,100,169,231,83,84,17,202,193,149,208,198,84,98,206,91,82,2,154,176,4,102,16,232,15,176,172,244,238,166,173,255,7,79,40,105,162,240,250,23,188,240,231,87,46,236,132,6,157,15,252,140,15,148,43,24,119,162,26,210,212,120,39,117,43,46,47,227,250,165,80,51,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6310e556-8a63-4c49-b0b8-076bc13c50bb"));
		}

		#endregion

	}

	#endregion

}

