namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ISpecificationTermParametersSchema

	/// <exclude/>
	public class ISpecificationTermParametersSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public ISpecificationTermParametersSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public ISpecificationTermParametersSchema(ISpecificationTermParametersSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("7a9ce83e-fd98-4d67-b241-16d384aff5e3");
			Name = "ISpecificationTermParameters";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("b11d550e-0087-4f53-ae17-fb00d41102cf");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,109,142,65,10,194,48,20,68,215,45,244,14,89,234,166,57,128,165,11,93,136,11,161,88,47,16,195,143,4,76,26,254,79,4,41,189,187,73,181,210,82,55,33,153,204,204,27,43,12,144,19,18,216,190,57,183,157,242,229,161,179,74,223,3,10,175,59,91,182,128,79,45,225,10,104,138,188,47,242,140,115,206,42,10,198,8,124,213,223,247,5,28,2,129,245,196,4,35,7,82,43,45,199,60,243,49,200,156,192,136,137,87,42,167,6,62,171,112,225,246,208,146,105,27,29,42,77,57,181,243,142,196,110,126,13,209,223,103,241,88,13,25,133,35,248,127,200,53,243,163,32,248,128,150,234,132,152,71,42,62,253,36,235,114,64,98,44,149,205,118,23,109,67,145,15,111,68,173,116,230,78,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("7a9ce83e-fd98-4d67-b241-16d384aff5e3"));
		}

		#endregion

	}

	#endregion

}

