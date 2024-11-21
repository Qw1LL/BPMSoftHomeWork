namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: IPriceListPickerSchema

	/// <exclude/>
	public class IPriceListPickerSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public IPriceListPickerSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public IPriceListPickerSchema(IPriceListPickerSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("664fa71d-95dd-488e-ad10-f92c9b477801");
			Name = "IPriceListPicker";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("4c797525-d05e-4bd8-84e9-5dcb79ad7c60");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,144,65,106,195,48,16,69,215,49,248,14,34,171,118,99,29,160,174,161,237,34,24,90,48,228,4,170,60,10,67,173,145,25,141,22,161,228,238,181,148,68,20,178,147,254,252,55,255,75,100,60,196,213,88,80,239,211,215,49,56,233,62,2,57,60,37,54,130,129,218,230,183,109,118,41,34,157,212,241,28,5,252,75,219,108,138,214,90,245,49,121,111,248,60,220,238,35,9,176,203,171,92,96,53,49,90,248,196,40,42,194,2,54,47,235,238,160,254,71,174,233,123,65,171,176,194,99,37,39,180,63,192,155,39,119,120,136,44,194,1,68,173,217,191,228,164,107,79,99,109,72,36,57,237,49,174,40,69,93,13,27,175,104,123,255,235,254,134,140,243,126,120,187,30,21,206,64,130,14,129,187,94,23,111,197,123,6,73,76,113,168,77,123,125,151,178,231,144,112,206,205,234,248,169,40,53,228,121,251,195,221,165,109,46,127,25,236,240,228,125,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("664fa71d-95dd-488e-ad10-f92c9b477801"));
		}

		#endregion

	}

	#endregion

}

