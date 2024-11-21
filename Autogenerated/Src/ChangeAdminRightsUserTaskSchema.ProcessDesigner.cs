namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: ChangeAdminRightsUserTask

	[DesignModeProperty(Name = "EntitySchemaUId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0ebbb23cf6db45ebad13a1445b7ef081", CaptionResourceItem = "Parameters.EntitySchemaUId.Caption", DescriptionResourceItem = "Parameters.EntitySchemaUId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DataSourceFilters", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0ebbb23cf6db45ebad13a1445b7ef081", CaptionResourceItem = "Parameters.DataSourceFilters.Caption", DescriptionResourceItem = "Parameters.DataSourceFilters.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "DeleteRights", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0ebbb23cf6db45ebad13a1445b7ef081", CaptionResourceItem = "Parameters.DeleteRights.Caption", DescriptionResourceItem = "Parameters.DeleteRights.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "AddRights", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0ebbb23cf6db45ebad13a1445b7ef081", CaptionResourceItem = "Parameters.AddRights.Caption", DescriptionResourceItem = "Parameters.AddRights.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "ConsiderTimeInFilter", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "0ebbb23cf6db45ebad13a1445b7ef081", CaptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", DescriptionResourceItem = "Parameters.ConsiderTimeInFilter.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public partial class ChangeAdminRightsUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public ChangeAdminRightsUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("0ebbb23c-f6db-45eb-ad13-a1445b7ef081");
			_considerTimeInFilter = () => { return true; };
		}

		#endregion

		#region Properties: Public

		public virtual Guid EntitySchemaUId {
			get;
			set;
		}

		public virtual string DataSourceFilters {
			get;
			set;
		}

		public virtual string DeleteRights {
			get;
			set;
		}

		public virtual string AddRights {
			get;
			set;
		}

		private Func<bool> _considerTimeInFilter;
		public virtual bool ConsiderTimeInFilter {
			get {
				return (_considerTimeInFilter ?? (_considerTimeInFilter = () => false)).Invoke();
			}
			set {
				_considerTimeInFilter = () => { return value; };
			}
		}

		#endregion

		#region Methods: Public

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("EntitySchemaUId")) {
				writer.WriteValue("EntitySchemaUId", EntitySchemaUId, Guid.Empty);
			}
			if (!HasMapping("DataSourceFilters")) {
				writer.WriteValue("DataSourceFilters", DataSourceFilters, null);
			}
			if (!HasMapping("DeleteRights")) {
				writer.WriteValue("DeleteRights", DeleteRights, null);
			}
			if (!HasMapping("AddRights")) {
				writer.WriteValue("AddRights", AddRights, null);
			}
			if (!HasMapping("ConsiderTimeInFilter")) {
				writer.WriteValue("ConsiderTimeInFilter", ConsiderTimeInFilter, false);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "EntitySchemaUId":
					EntitySchemaUId = reader.GetGuidValue();
				break;
				case "DataSourceFilters":
					DataSourceFilters = reader.GetStringValue();
				break;
				case "DeleteRights":
					DeleteRights = reader.GetStringValue();
				break;
				case "AddRights":
					AddRights = reader.GetStringValue();
				break;
				case "ConsiderTimeInFilter":
					ConsiderTimeInFilter = reader.GetBoolValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

