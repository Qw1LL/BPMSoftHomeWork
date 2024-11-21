namespace BPMSoft.Configuration
{

	using DataContract = BPMSoft.Nui.ServiceModel.DataContract;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Data;
	using System.Drawing;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.DcmProcess;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Process;
	using BPMSoft.Core.Process.Configuration;
	using BPMSoft.GlobalSearch.Indexing;
	using BPMSoft.UI.WebControls.Controls;
	using BPMSoft.UI.WebControls.Utilities.Json.Converters;

	#region Class: PartnershipParameter_PRMBaseEventsProcess

	public partial class PartnershipParameter_PRMBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public override bool UpdateStringValueMethod() {
			return true;
		}

		public virtual void CopyValueToCurrentValueColumn() {
			PartnershipHelper partnershipHelper = ClassFactory.Get<PartnershipHelper>(new ConstructorArgument("userConnection", UserConnection));
			Guid parameterValueTypeId = Entity.GetTypedColumnValue<Guid>("ParameterValueTypeId");
			string columnValueName = partnershipHelper.GetColumnValueNameByType(parameterValueTypeId);
			switch (columnValueName) {
				case "BooleanValue":
					var boolValue = Entity.GetTypedColumnValue<Boolean>(columnValueName);
					Entity.SetColumnValue("CurrentValue", boolValue ? Yes.ToString() : No.ToString());
					break;
				case "ListItemValue":
					Guid listItemValueId = Entity.GetTypedColumnValue<Guid>("ListItemValueId");
					Guid guidValue = Entity.GetTypedColumnValue<Guid>("GuidValue");
					Guid categoryId = Entity.GetTypedColumnValue<Guid>("PartnerParamCategoryId");
					Entity.SetColumnValue("CurrentValue", 
						guidValue.Equals(Guid.Empty) ? 
						listItemValueId.ToString() :
						getLookupDisplayValueByCategory(categoryId, guidValue)
					);
					break;
				default:
					Entity.SetColumnValue("CurrentValue", Entity.GetTypedColumnValue<string>(columnValueName));
					break;
			}
		}

		public virtual string getLookupDisplayValueByCategory(Guid PartnerParamCategoryId, Guid value) {
			string lookupName = getLookupNameByParamCategory(PartnerParamCategoryId);
			if (lookupName == string.Empty) {
				return value.ToString();
			}
			return (new Select(UserConnection).Top(1)
				.Column("Name")
				.From(lookupName)
				.Where("Id").IsEqual(Column.Parameter(value)) as Select).ExecuteScalar<string>();
		}

		public virtual string getLookupNameByParamCategory(Guid PartnerParamCategoryId) {
			return string.Empty;
		}

		#endregion

	}

	#endregion

}

