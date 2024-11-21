namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using BPMSoft.Configuration;
	using BPMSoft.Core;

	#region Class: FastReportTemplateManager

	public class FastReportTemplateManager
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public FastReportTemplateManager(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		public string GetTemplate(Guid templateId) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("FastReportTemplate");
			var entity = entitySchema.CreateEntity(_userConnection);
			if (!entity.FetchFromDB(templateId)) {
				throw new ItemNotFoundException(_userConnection, templateId.ToString(), "FastReportTemplate");
			}
			var template = entity.GetTypedColumnValue<string>("Data");
			if (string.IsNullOrEmpty(template)) {
				throw new Exception();
			}
			return template;
		}

		#endregion

	}

	#endregion

}

