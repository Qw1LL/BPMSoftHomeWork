namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationActualizersFactorySchema

	/// <exclude/>
	public class ITranslationActualizersFactorySchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationActualizersFactorySchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationActualizersFactorySchema(ITranslationActualizersFactorySchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("eb492bfc-0b97-4d2d-85d4-269f62222c69");
			Name = "ITranslationActualizersFactory";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,203,75,204,77,45,46,72,76,78,85,112,10,240,13,206,79,43,209,115,206,207,75,203,76,47,45,74,44,201,204,207,211,11,41,74,204,43,206,1,179,121,185,170,121,185,120,185,56,149,139,82,211,129,92,5,207,188,146,212,162,52,160,86,43,5,79,36,101,142,201,37,165,137,57,153,85,169,69,197,110,137,201,37,249,69,149,96,93,5,165,73,57,153,201,10,153,48,77,4,245,112,66,108,131,91,231,155,90,146,145,159,82,108,165,16,0,54,9,34,137,221,16,5,247,212,18,172,18,26,154,214,80,67,83,243,82,32,230,130,249,181,16,143,161,8,2,197,0,104,230,171,6,29,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("eb492bfc-0b97-4d2d-85d4-269f62222c69"));
		}

		#endregion

	}

	#endregion

}

