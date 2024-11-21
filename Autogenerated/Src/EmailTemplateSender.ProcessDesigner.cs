namespace BPMSoft.Configuration.ProcessDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Web.Common;
	using BPMSoft.Web.Http.Abstractions;

	#region Enum: SendEmailType

 	/// <summary>
 	/// Enum, how to send email type.
 	/// </summary>
 	public enum SendEmailType {
		Auto = 0,
 		Manual = 1
 	}
 	
 	#endregion

	#region Enum: BodyTemplateType
	
 	/// <summary>
 	/// Enum, how to send email body.
 	/// </summary>
 	public enum BodyTemplateType {
		EmailTemplate = 0,
		ProcessTemplate = 1
 	}

 	#endregion

	/// <summary>
	/// Class to send email by template.
	/// </summary>
	#region Class: EmailTemplateSender

	public class EmailTemplateSender
	{

		#region Constructors: Public

		public EmailTemplateSender(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		public EmailTemplateSender(UserConnection userConnection, IHttpContextAccessor httpContextAccessor)
			: this(userConnection) {
			if (httpContextAccessor == null) {
				throw new ArgumentNullOrEmptyException(nameof(httpContextAccessor));
			}
			_httpContextAccessor = httpContextAccessor;
		}

		#endregion

		#region Properties: Private

		private IHttpContextAccessor _httpContextAccessor;
		private IHttpContextAccessor HttpContextAccessor {
			get {
				if (_httpContextAccessor == null) {
					_httpContextAccessor = HttpContext.HttpContextAccessor;
				}
				return _httpContextAccessor;
			}
		}

		#endregion

		#region Properties: Public

		public virtual string Subject { get; set; }

		public virtual string Body { get; set; }

		public virtual Guid RecordId { get; set; }

		public virtual Guid TemplateId { get; set; }

		public virtual Guid SysEntitySchemaId { get; set; }

		private LocalizableString _noDataLocalizableString;
		public LocalizableString NoDataLocalizableString {
			get {
				return _noDataLocalizableString ?? (_noDataLocalizableString =
					new LocalizableString("EmailTemplateSender", "LocalizableStrings.NoDataLocalizableString.Value"));
			}
		}

		public UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Public

		public virtual bool InternalExecute(ProcessExecutingContext context) {
			var manager = UserConnection.EntitySchemaManager;
			var TemplateESQ = new EntitySchemaQuery(manager, "EmailTemplate");
			TemplateESQ.AddColumn("Subject");
			TemplateESQ.AddColumn("Body");
			TemplateESQ.Filters.Add(
				TemplateESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal, 
					"Id", 
					TemplateId
				)
			);
			var queryResult = TemplateESQ.GetEntityCollection(UserConnection);
			if (queryResult.Count > 0) {
				Subject = queryResult[0].GetTypedColumnValue<string>("Subject");
				Body = queryResult[0].GetTypedColumnValue<string>("Body");
			} else {
				return true;
			}
			string schemaName = string.Empty;
			var sysSchema = UserConnection.EntitySchemaManager.FindInstanceByUId(SysEntitySchemaId);
			if (sysSchema != null) {
				schemaName = sysSchema.Name;
			} else {
				return true;
			}
			var mainESQ = new EntitySchemaQuery(manager, schemaName);
			var schema = manager.GetInstanceByName(schemaName);
			mainESQ.AddColumn("Id");
			var columnNames = new Dictionary<string, string>();
			var macrosList = FindMacro(Subject);
			macrosList.AddRange(FindMacro(Body));
			foreach(var columnNamePass in macrosList) {
				if(!columnNames.ContainsKey(columnNamePass)) {
					var column = schema.FindSchemaColumnByPath(columnNamePass);
					if(column != null) {
						string esqColumnName = mainESQ.AddColumn(columnNamePass).Name;
						columnNames.Add(columnNamePass, esqColumnName);
					}
				}
			}
			var entity = mainESQ.GetEntity(UserConnection, (object)RecordId);
			Subject = GetTextWOMacroses(macrosList, Subject, entity, columnNames);
			Body = GetTextWOMacroses(macrosList, Body, entity, columnNames);
			var estimateMacros = "#Estimate#";
			if(ContainsConstMacros(estimateMacros)) {
				UpdateConstMacros(estimateMacros, GetEstimateString());
			}
			var estimatePicMacros = "#EstimatePic#";
			if(ContainsConstMacros(estimatePicMacros)) {
				UpdateConstMacros(estimatePicMacros, GetEstimateStringPic());
			}
			return true;
		}

		public virtual List<string> FindMacro(string source) {
			var rez = new List<string>();
			foreach (Match match in Regex.Matches(source, @"\[#(.+?)#\]")) {
				rez.Add(match.Groups[1].Value);
			}
			return rez;
		}

		public virtual string GetEstimateString() {
			string url = (string)BPMSoft.Core.Configuration.SysSettings.GetValue(UserConnection, "SiteUrl");
			string link = "<a href='" + url + "CustomServices.axd?action=estimate&id=" + RecordId.ToString() +
				"&rating={0}'>{1}</a>  ";
			string result = string.Empty;
			var entitySchemaQuery = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SatisfactionLevel");
			entitySchemaQuery.AddColumn("Name");
			entitySchemaQuery.AddColumn("Point").OrderDirection = OrderDirection.Descending;

			var checkcollection = entitySchemaQuery.GetEntityCollection(UserConnection);
			foreach (var CP in checkcollection) {
				result += string.Format(link, CP.GetColumnValue("Point").ToString(),
					CP.GetTypedColumnValue<string>("Name"));
			}
			return result;
		}

		public virtual string GetEstimateStringPic() {
			HttpContext httpContext = HttpContextAccessor.GetInstance();
			string url = httpContext != null
				? WebUtilities.GetBaseApplicationUrl(httpContext.Request)
				: (string)SysSettings.GetValue(UserConnection, "SiteUrl");
			string divStyle = "width: 40px; height: 40px; font-size: 28px; text-align: center; " +
				"vertical-align: middle; float:left; background:{0};";
			string hrefStyle = "text-decoration: none; color: white; vertical-align: middle; font-family: " +
				"Verdana, Arial,Tahoma;";
			string link = "<td width='40' height='40' style='margin-top: 8px;'>" +
						"<div style='{1}'>" +
							"<a href='" + url + "/ServiceModel/CaseRatingManagementService.svc/RateCase/" + RecordId +
							"/{0}' style='{2}'>{0}</a>" +
						"</div>" +
					"</td>";
			var result = string.Empty;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SatisfactionLevel");
			esq.AddColumn("Point").OrderDirection = OrderDirection.Descending;
			esq.AddColumn("Colour");
			foreach (var satisfactionLevel in esq.GetEntityCollection(UserConnection)) {
				var point = satisfactionLevel.GetTypedColumnValue<int>("Point");
				var color = satisfactionLevel.GetColumnValue("Colour").ToString();
				var currDivStyle = string.Format(divStyle, color);
				result += string.Format(link, point, currDivStyle, hrefStyle);
			}
			return "<table border='0' cellpadding='0' cellspacing='1'><tr>" + result + "</tr></table>";
		}

		public virtual string GetTextWOMacroses(List<string> Macroses, string Text, Entity entity,
				Dictionary<string, string> columnNames) {
			string dataEmpty = NoDataLocalizableString.Value;
			foreach (var columnNamePass in Macroses) {
				string columnName = string.Empty;
				string value = string.Empty;
				try {
					columnName = columnNames[columnNamePass];
					value = (entity.GetColumnValue(columnName) ?? dataEmpty).ToString();
				} catch {
					value = dataEmpty;
				}
				Text = Text.Replace("[#" + columnNamePass + "#]", value);
			}
			return Text;
		}

		public virtual void UpdateConstMacros(string macros, string value) {
			Subject = Subject.Replace(macros, value);
			Body = Body.Replace(macros, value);
		}

		public virtual bool ContainsConstMacros(string macros) {
			return Subject.Contains(macros) || Body.Contains(macros);
		}

		#endregion

	}

	#endregion
}
