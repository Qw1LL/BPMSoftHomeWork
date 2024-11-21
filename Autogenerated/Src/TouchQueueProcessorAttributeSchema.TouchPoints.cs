namespace BPMSoft.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: TouchQueueProcessorAttributeSchema

	/// <exclude/>
	public class TouchQueueProcessorAttributeSchema : BPMSoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public TouchQueueProcessorAttributeSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public TouchQueueProcessorAttributeSchema(TouchQueueProcessorAttributeSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("e9dc9ea7-5170-4749-8f69-4d60ffecdb57");
			Name = "TouchQueueProcessorAttribute";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d23d224d-d671-416d-91d0-80132a374d7a");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,0,10,125,80,187,14,194,48,16,155,169,212,127,56,193,2,75,179,243,146,160,51,82,81,97,66,12,33,92,67,164,54,41,185,100,64,136,127,39,161,80,36,6,182,216,231,216,119,214,188,65,106,185,64,88,23,155,210,84,46,203,141,174,148,244,150,59,101,116,154,220,211,100,224,73,105,9,229,141,28,54,179,52,9,204,200,162,12,99,200,107,78,52,133,157,241,226,178,245,232,177,176,70,32,145,177,43,231,172,58,121,135,47,61,99,12,230,228,155,134,219,219,242,141,123,5,56,3,103,172,148,142,175,96,4,215,232,4,97,49,226,18,161,253,88,130,136,105,217,199,142,253,248,205,9,145,215,100,64,88,172,22,195,110,221,172,79,25,2,139,202,67,79,236,163,251,184,135,59,110,37,58,202,94,39,77,142,65,218,250,83,173,68,151,250,247,68,152,190,203,249,166,133,239,177,185,71,215,22,234,115,87,88,132,129,123,2,34,81,237,137,118,1,0,0 };
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("e9dc9ea7-5170-4749-8f69-4d60ffecdb57"));
		}

		#endregion

	}

	#endregion

}

