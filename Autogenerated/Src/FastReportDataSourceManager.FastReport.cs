namespace BPMSoft.Configuration.Reporting.FastReport
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: FastReportDataSourceManager

	public class FastReportDataSourceManager
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public FastReportDataSourceManager(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private TReportDataSourceConfigurationData CreateReportDataSource<TReportDataSourceConfigurationData>(Guid id, string name, string type, string serializedData)
				where TReportDataSourceConfigurationData : class, IReportDataSourceConfigurationData {
			var result = ClassFactory.Get<IReportDataSourceConfigurationData>(
				type,
				new ConstructorArgument("id", id),
				new ConstructorArgument("name", name),
				new ConstructorArgument("serializedData", serializedData));
			if (!(result is TReportDataSourceConfigurationData)) {
				throw new Exception();
			}
			return result as TReportDataSourceConfigurationData;
		}

		#endregion

		#region Methods: Public

		public IEnumerable<ReportDataSourceMetadata> GetDataSourceMetadataListByTemplateId(Guid templateId) {
			var columnMap = new Dictionary<string, string>();
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "FastReportDataSource");
			columnMap.Add("Id", esq.AddColumn("Id").Name);
			columnMap.Add("Name", esq.AddColumn("Name").Name);
			columnMap.Add("Type", esq.AddColumn("Type.Name").Name);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Template", templateId));
			var entityCollection = esq.GetEntityCollection(_userConnection);
			return entityCollection.Select(x => new ReportDataSourceMetadata {
				Id = x.GetTypedColumnValue<Guid>(columnMap["Id"]),
				Name = x.GetTypedColumnValue<string>(columnMap["Name"]),
				Type = x.GetTypedColumnValue<string>(columnMap["Type"])
			});
		}

		public TReportDataSourceConfigurationData GetDataSource<TReportDataSourceConfigurationData>(Guid dataSourceId)
				where TReportDataSourceConfigurationData : class, IReportDataSourceConfigurationData {
			var columnMap = new Dictionary<string, string>();
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "FastReportDataSource");
			columnMap.Add("Id", esq.AddColumn("Id").Name);
			columnMap.Add("Name", esq.AddColumn("Name").Name);
			columnMap.Add("Type", esq.AddColumn("Type.Name").Name);
			columnMap.Add("Data", esq.AddColumn("Data").Name);
			var entity = esq.GetEntity(_userConnection, dataSourceId);
			if (entity == null) {
				throw new ItemNotFoundException(_userConnection, dataSourceId.ToString(), "FastReportDataSource");
			}
			return CreateReportDataSource<TReportDataSourceConfigurationData>(
				entity.GetTypedColumnValue<Guid>(columnMap["Id"]),
				entity.GetTypedColumnValue<string>(columnMap["Name"]),
				entity.GetTypedColumnValue<string>(columnMap["Type"]),
				entity.GetTypedColumnValue<string>(columnMap["Data"]));
		}

		#endregion

	}

	#endregion

}

