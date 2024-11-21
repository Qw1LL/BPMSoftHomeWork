namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITranslationBatchSchema

	/// <exclude/>
	public class ITranslationBatchSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITranslationBatchSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITranslationBatchSchema(ITranslationBatchSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6a16d126-b908-4b9c-8616-b21a5c69f407");
			Name = "ITranslationBatch";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("ab054f7f-9309-4520-a5a0-bfba22ceff76");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,77,10,194,48,16,133,215,41,244,14,3,110,165,221,107,113,161,130,20,17,10,122,129,24,167,53,216,166,101,146,46,138,120,119,167,137,150,138,155,252,188,249,230,189,73,140,108,208,118,82,33,108,139,211,185,45,93,178,107,77,169,171,158,164,211,173,73,46,36,141,173,253,57,142,158,113,36,122,171,77,5,231,193,58,108,152,173,107,84,99,209,38,7,52,72,90,173,227,136,169,5,97,197,42,228,198,33,149,108,191,130,124,102,181,149,78,221,61,216,245,215,90,43,208,95,238,31,3,110,221,107,31,34,105,200,172,35,30,96,9,97,223,176,5,79,197,235,20,89,80,219,33,57,141,118,5,133,119,15,245,52,77,33,179,125,211,176,203,216,230,133,89,24,60,112,72,38,48,157,147,33,11,142,56,192,248,5,66,84,232,248,157,66,188,62,209,104,110,33,221,223,131,250,43,178,246,6,23,133,177,139,107,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6a16d126-b908-4b9c-8616-b21a5c69f407"));
		}

		#endregion

	}

	#endregion

}

