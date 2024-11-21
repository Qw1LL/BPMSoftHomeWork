namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: DateTimeExcelCellWriterSchema

	/// <exclude/>
	public class DateTimeExcelCellWriterSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public DateTimeExcelCellWriterSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public DateTimeExcelCellWriterSchema(DateTimeExcelCellWriterSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("2cb26043-42ca-4c84-9e87-fb66c4e44a45");
			Name = "DateTimeExcelCellWriter";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("6ba26f98-9709-4408-98d0-761f0c4bf2aa");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,117,142,75,171,194,48,16,133,215,22,250,31,6,220,55,123,95,139,91,117,39,20,20,92,199,116,212,64,146,41,211,212,7,226,127,55,73,111,69,174,220,69,22,231,228,156,57,159,147,22,219,70,42,132,159,106,179,165,163,47,74,114,71,125,234,88,122,77,174,88,221,26,98,191,163,213,77,161,201,179,71,158,141,198,140,167,240,5,165,145,109,59,129,165,244,184,211,22,83,162,68,99,246,172,61,114,158,133,168,16,2,102,109,103,173,228,251,226,87,15,121,192,88,128,240,12,92,83,165,24,26,226,163,210,116,7,163,21,168,56,246,223,22,244,20,95,4,163,136,251,230,173,152,26,100,175,49,64,87,233,106,98,140,147,51,237,206,24,74,53,41,16,113,117,152,165,11,50,235,26,225,125,123,77,108,165,255,210,243,197,95,171,24,96,167,253,204,24,93,221,147,4,245,76,222,167,245,124,1,67,30,46,43,138,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("2cb26043-42ca-4c84-9e87-fb66c4e44a45"));
		}

		#endregion

	}

	#endregion

}

