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
	using System.Text;

	#region Class: CreateSocialAccountUserTask

	[DesignModeGroup(Name = "Incoming", Position = 1, UseSolutionStorage = true, ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.UserId.Group", DescriptionResourceItem = "Parameters.UserId.Group")]
	[DesignModeGroup(Name = "Event names", Position = 2, UseSolutionStorage = true, ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.SuccessEventName.Group", DescriptionResourceItem = "Parameters.SuccessEventName.Group")]
	[DesignModeProperty(Name = "UserId", Group = "Incoming", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.UserId.Caption", DescriptionResourceItem = "Parameters.UserId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SocialNetwork", Group = "Incoming", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.SocialNetwork.Caption", DescriptionResourceItem = "Parameters.SocialNetwork.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "OpenerPageId", Group = "Incoming", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.OpenerPageId.Caption", DescriptionResourceItem = "Parameters.OpenerPageId.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "SuccessEventName", Group = "Event names", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.SuccessEventName.Caption", DescriptionResourceItem = "Parameters.SuccessEventName.Caption", UseSolutionStorage = true)]
	[DesignModeProperty(Name = "FailedEventName", Group = "Event names", ValuesProvider = "ProcessSchemaParameterValueProvider", Editor="xtype=processschemaparametervalueedit;dataProvider=processschemaparametervalueprovider", ResourceManager = "4c647b901d28415a83933699e8ed5e25", CaptionResourceItem = "Parameters.FailedEventName.Caption", DescriptionResourceItem = "Parameters.FailedEventName.Caption", UseSolutionStorage = true)]
	/// <exclude/>
	public class CreateSocialAccountUserTask : ProcessUserTask
	{

		#region Constructors: Public

		public CreateSocialAccountUserTask(UserConnection userConnection)
			: base(userConnection) {
			SchemaUId = new Guid("4c647b90-1d28-415a-8393-3699e8ed5e25");
		}

		#endregion

		#region Properties: Public

		public virtual Guid UserId {
			get;
			set;
		}

		public virtual string SocialNetwork {
			get;
			set;
		}

		public virtual string OpenerPageId {
			get;
			set;
		}

		private string _successEventName = @"SocialAccountCreatedSuccessfullyEvent";
		public virtual string SuccessEventName {
			get {
				return _successEventName;
			}
			set {
				_successEventName = value;
			}
		}

		private string _failedEventName = @"SocialAccountCreationFailedEvent";
		public virtual string FailedEventName {
			get {
				return _failedEventName;
			}
			set {
				_failedEventName = value;
			}
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			
			var pageSchemaManager = UserConnection.GetSchemaManager("PageSchemaManager") as PageSchemaManager;
			var pageSchema = pageSchemaManager.GetInstanceByName("SocialAccountAuthPage");	
			var sb = new StringBuilder();
			sb.AppendFormat("BPMSoft.openWindow('ViewPage.aspx','{0}',", pageSchema.UId.ToString());
			
			// params:
			sb.Append("[");
			bool isFirst = true;
			var parameters = new Dictionary<string, string>{
				{ "userId", UserId.ToString() },
				{ "SocialNetwork", SocialNetwork },
				{ "OpenerPageId", OpenerPageId },
				{ "SuccessEventName", SuccessEventName },
				{ "FailedEventName", FailedEventName }
			};
			foreach (var parameter in parameters) {
				if (isFirst) {
					isFirst = false;
				} else {
					sb.Append(",\n\t");
				}
				sb.Append("{");
				sb.AppendFormat("\tname: '{0}',", parameter.Key);
				sb.AppendFormat("\tvalue: '{0}'", parameter.Value);
				sb.Append("}");
			}
			
			sb.Append("\t],");	
			
			var width = pageSchema.Width.ToString(CultureInfo.InvariantCulture);
			var height = pageSchema.Height.ToString(CultureInfo.InvariantCulture);
			sb.AppendFormat("{0}, {1}, ", width, height);		
			// isCenterWindow: 	
			sb.Append("true);");
			var page = (System.Web.HttpContext.Current.CurrentHandler as BPMSoft.UI.WebControls.Page).Page;
			ScriptManager scriptManager = page.FindControl("ScriptManager") as BPMSoft.UI.WebControls.Controls.ScriptManager;
			string script = sb.ToString();
			scriptManager.AddScript(script);
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
			if (!HasMapping("UserId")) {
				writer.WriteValue("UserId", UserId, Guid.Empty);
			}
			if (!HasMapping("SocialNetwork")) {
				writer.WriteValue("SocialNetwork", SocialNetwork, null);
			}
			if (!HasMapping("OpenerPageId")) {
				writer.WriteValue("OpenerPageId", OpenerPageId, null);
			}
			if (!HasMapping("SuccessEventName")) {
				writer.WriteValue("SuccessEventName", SuccessEventName, null);
			}
			if (!HasMapping("FailedEventName")) {
				writer.WriteValue("FailedEventName", FailedEventName, null);
			}
			writer.WriteFinishObject();
		}

		#endregion

		#region Methods: Protected

		protected override void ApplyPropertiesDataValues(DataReader reader) {
			base.ApplyPropertiesDataValues(reader);
			switch (reader.CurrentName) {
				case "UserId":
					UserId = reader.GetGuidValue();
				break;
				case "SocialNetwork":
					SocialNetwork = reader.GetStringValue();
				break;
				case "OpenerPageId":
					OpenerPageId = reader.GetStringValue();
				break;
				case "SuccessEventName":
					SuccessEventName = reader.GetStringValue();
				break;
				case "FailedEventName":
					FailedEventName = reader.GetStringValue();
				break;
			}
		}

		#endregion

	}

	#endregion

}

