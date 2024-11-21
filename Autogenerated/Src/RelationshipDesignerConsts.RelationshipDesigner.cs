using System;

namespace BPMSoft.Configuration.RelationshipDesigner
{
	public static class RelationshipDesignerConstants
	{
		//Relation type connection type - Formal
		public static readonly Guid RelationTypeConnectionType_Formal = new Guid("56D730BF-27F5-42D9-83DF-183DF2EC06A1");
		//Relation type connection type - NotFormal
		public static readonly Guid RelationTypeConnectionType_NotFormal = new Guid("6D1D2243-D4DE-4D64-AAB4-23EED4021A60");
		//Relation type position - Horizontal
		public static readonly Guid RelationPosition_Horizontal = new Guid("AC09EF67-6E34-4FEE-9F36-B5BF771E3537");
		//Relation type position - Direct
		public static readonly Guid RelationPosition_Direct = new Guid("0048F78F-4A26-4FA0-806B-DCE39965E551");
		//Relation type position - Reverse
		public static readonly Guid RelationPosition_Reverse = new Guid("1EEE8ED0-2615-4E32-946C-304E199FA8C7");
	}
}
