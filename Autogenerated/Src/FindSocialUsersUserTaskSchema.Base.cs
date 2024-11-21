namespace BPMSoft.Core.Process.Configuration
{

	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Social;
	using BPMSoft.UI.WebControls.Controls;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;

	#region Class: FindSocialUsersUserTask

	[DesignModeProperty(Name = "ContactId", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1ecbfc385dd14aa3a343ab604e18117c", CaptionResourceItem = "Parameters.ContactId.Caption", DescriptionResourceItem = "Parameters.ContactId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SearchCriteria", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1ecbfc385dd14aa3a343ab604e18117c", CaptionResourceItem = "Parameters.SearchCriteria.Caption", DescriptionResourceItem = "Parameters.SearchCriteria.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SocialNetworks", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1ecbfc385dd14aa3a343ab604e18117c", CaptionResourceItem = "Parameters.SocialNetworks.Caption", DescriptionResourceItem = "Parameters.SocialNetworks.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "Users", Group = "", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "1ecbfc385dd14aa3a343ab604e18117c", CaptionResourceItem = "Parameters.Users.Caption", DescriptionResourceItem = "Parameters.Users.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class FindSocialUsersUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public FindSocialUsersUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("1ecbfc38-5dd1-4aa3-a343-ab604e18117c");
		}

		#endregion

		#region Properties: Public

		public virtual Guid ContactId {
			get;
			set;
		}

		public virtual string SearchCriteria {
			get;
			set;
		}

		public virtual string SocialNetworks {
			get;
			set;
		}

		public virtual Object Users {
			get;
			set;
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			if (!ContactId.IsEmpty() && string.IsNullOrEmpty(SearchCriteria)) {
				var entitySchemaManager = UserConnection.EntitySchemaManager;
				EntitySchemaQuery query = new EntitySchemaQuery(entitySchemaManager, "Contact");
				query.AddColumn("Name");
				var contact = (BPMSoft.Configuration.Contact)query.GetEntity(UserConnection, ContactId);
				if (contact != null) {
					SearchCriteria = contact.Name.Trim();
				}
			}
			SocialNetwork socialNetwork = 0;
			var netwoks = SocialNetworks.Split('|');
			if (netwoks == null || netwoks.Length == 0){
				socialNetwork = SocialNetwork.All;
			}
			foreach(var netwok in netwoks) {
				socialNetwork = socialNetwork | (SocialNetwork)Enum.Parse(typeof(SocialNetwork), netwok, true);
			}
			SocialCommutator commutator = new SocialCommutator(UserConnection, socialNetwork);
			Users = commutator.FindUsers(SearchCriteria);
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public virtual void UpdateFiltersRightExprMetaDataByParameterValue(Process process, DataSourceFilterCollection filters) {
			foreach (var filter in filters) {
				if (filter is DataSourceFilterCollection) {
					UpdateFiltersRightExprMetaDataByParameterValue(process, (DataSourceFilterCollection)filter);
					continue;
				}	
				var dataSourcefilter = (DataSourceFilter)filter;
				if (dataSourcefilter.RightExpression == null) {
					continue;
				}
				if (dataSourcefilter.RightExpression.Type == DataSourceFilterExpressionType.Custom) {
					dataSourcefilter.RightExpression.Type = DataSourceFilterExpressionType.Parameter;
					if (dataSourcefilter.RightExpression.Parameters.Count == 2) {
						var parameters = dataSourcefilter.RightExpression.Parameters;
						var metaPath = parameters[1].Value;
						parameters[1].Value = process.GetParameterValueByMetaPath((string)metaPath);
						parameters.RemoveAt(0);
					}
					if (dataSourcefilter.SubFilters != null && dataSourcefilter.SubFilters.Count > 0) {
						UpdateFiltersRightExprMetaDataByParameterValue(process, dataSourcefilter.SubFilters);
					}
				}
			}
		}

		public override void WritePropertiesData(DataWriter writer) {
			writer.WriteStartObject(Name);
			base.WritePropertiesData(writer);
			if (Status == Core.Process.ProcessStatus.Inactive) {
				writer.WriteFinishObject();
				return;
			}
			if (!HasMapping("ContactId")) {
				writer.WriteValue("ContactId", ContactId, Guid.Empty);
			}
			if (!HasMapping("SearchCriteria")) {
				writer.WriteValue("SearchCriteria", SearchCriteria, null);
			}
			if (!HasMapping("SocialNetworks")) {
				writer.WriteValue("SocialNetworks", SocialNetworks, null);
			}
			if (Users != null) {
				if (Users.GetType().IsSerializable || Users.GetType().GetInterface("ISerializable") != null) {
					writer.WriteSerializableObjectValue("Users", Users, null);
				}
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "ContactId":
					ContactId = reader.GetGuidValue();
				break;
				case "SearchCriteria":
					SearchCriteria = reader.GetStringValue();
				break;
				case "SocialNetworks":
					SocialNetworks = reader.GetStringValue();
				break;
				case "Users":
					Users = reader.GetSerializableObjectValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

