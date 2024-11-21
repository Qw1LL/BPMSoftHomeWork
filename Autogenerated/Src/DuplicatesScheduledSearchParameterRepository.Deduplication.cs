namespace BPMSoft.Configuration.Deduplication
{
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: DuplicatesScheduledSearchParameterRepository

	/// <summary>
	/// Default implementation of the <see cref="IDuplicatesScheduledSearchParameterRepository"/> interface.
	/// </summary>
	[DefaultBinding(typeof(IDuplicatesScheduledSearchParameterRepository))]
	public class DuplicatesScheduledSearchParameterRepository : IDuplicatesScheduledSearchParameterRepository
	{
		#region Constants: Private

		private const string DuplicatesSearchParameterSchemaName = "DuplicatesSearchParameter";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public DuplicatesScheduledSearchParameterRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private EntitySchema GetEntitySchema() {
			return _userConnection.EntitySchemaManager.GetInstanceByName(DuplicatesSearchParameterSchemaName);
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IDuplicatesScheduledSearchParameterRepository.GetIsSearchParametersExist"/>
		public bool GetIsSearchParametersExist(string schemaName) {
			var selectQuery = new Select(_userConnection)
				.Column(Func.Count("SchemaToSearchName"))
				.From(DuplicatesSearchParameterSchemaName)
				.Where(DuplicatesSearchParameterSchemaName, "SchemaToSearchName").IsEqual(Column.Parameter(schemaName));
			return ((Select)selectQuery).ExecuteScalar<bool>();
		}

		/// <inheritdoc cref="IDuplicatesScheduledSearchParameterRepository.CreateDefaultSearchParameterBySchemaName"/>
		public void CreateDefaultSearchParameterBySchemaName(string schemaName) {
			var entity = GetEntitySchema().CreateEntity(_userConnection);
			var schemaNameId = _userConnection.EntitySchemaManager.GetItemByName(schemaName).Id;
			entity.SetDefColumnValues();
			entity.SetColumnValue("SchemaToSearch", schemaNameId);
			entity.SetColumnValue("SchemaToSearchName", schemaName);
			entity.Save();
		}

		/// <inheritdoc cref="IDuplicatesScheduledSearchParameterRepository.DeleteSearchParameterBySchemaName"/>
		public void DeleteSearchParameterBySchemaName(string schemaName) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, DuplicatesSearchParameterSchemaName);
			var filter = esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SchemaToSearchName", schemaName);
			esq.Filters.Add(filter);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Days");
			esq.AddColumn("SearchTime");
			esq.AddColumn("SchemaToSearchName");
			esq.GetEntityCollection(_userConnection)
				.ToList()
				.ForEach(entity => entity.Delete());
		}

		#endregion
	}

	#endregion
}

