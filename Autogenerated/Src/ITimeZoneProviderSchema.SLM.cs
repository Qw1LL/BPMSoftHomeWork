namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ITimeZoneProviderSchema

	/// <exclude/>
	public class ITimeZoneProviderSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ITimeZoneProviderSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ITimeZoneProviderSchema(ITimeZoneProviderSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("dfa2b430-c6c6-4cf0-9146-f9cae961564f");
			Name = "ITimeZoneProvider";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,101,80,177,78,195,48,16,157,27,41,255,112,234,4,75,188,67,232,64,133,80,7,164,74,237,196,230,134,75,56,9,159,163,179,93,100,80,255,29,187,117,2,162,155,239,221,123,239,222,51,107,131,110,212,29,194,227,246,101,103,123,223,172,45,247,52,4,209,158,44,215,213,119,93,45,130,35,30,96,23,157,71,115,63,207,107,43,216,60,177,39,79,232,18,156,22,74,41,104,93,48,70,75,92,149,121,43,246,72,111,232,192,147,65,248,178,140,112,136,48,208,17,25,156,13,210,97,51,41,213,63,105,235,227,136,163,22,109,128,83,206,135,229,254,124,46,46,87,251,217,171,88,180,106,230,102,245,24,14,31,212,1,177,71,233,115,187,77,86,188,38,65,137,35,109,241,202,236,197,231,59,10,66,65,224,14,46,143,180,201,237,175,90,157,129,103,244,127,42,229,10,215,29,46,136,160,15,194,238,55,115,10,59,97,153,52,37,219,112,111,179,237,52,223,220,230,191,62,213,213,233,7,240,20,168,25,165,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("dfa2b430-c6c6-4cf0-9146-f9cae961564f"));
		}

		#endregion

	}

	#endregion

}

