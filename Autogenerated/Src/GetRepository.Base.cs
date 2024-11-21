namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: GetRepository

	/// <summary>
	/// Provides methods to obtain datas.
	/// </summary>
	/// <typeparam name="TData">Data</typeparam>
	public class GetRepository<TData> : IGetRepository<TData>
		where TData : EntityData, new()
	{

		#region Constructors: Public

		public GetRepository(UserConnection userConnection, string schemaName) {
			UserConnection = userConnection;
			SchemaName = schemaName;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get;
		}

		protected string SchemaName {
			get;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<TData> GetDatas() {
			var select = GetSelect();
			return GetFromReader(select);
		}

		private TData GetData(Guid id) {
			var select = GetSelect();
			AddFilterById(select, id);
			return GetFromReader(select).FirstOrDefault();
		}

		private IEnumerable<TData> GetFromReader(Select select) {
			var result = new List<TData>();
			select.ExecuteReader(reader => {
				result.Add(GetData(reader));
			});
			return result;
		}

		#endregion

		#region Methods: Protected

		protected virtual Select GetSelect() {
			var select = new Select(UserConnection);
			select
				.Column(SchemaName, "Id").As("Id")
				.From(SchemaName);
			return select;
		}

		protected virtual void AddFilterById(Select select, Guid id) {
			if (id.IsNotEmpty()) {
				select.Where(SchemaName, "Id").In(Column.Parameter(id));
			}
		}

		protected virtual TData GetData(IDataReader reader) {
			var result = new TData {
				Id = reader.GetColumnValue<Guid>("Id"),
			};
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets entity data by identifier.
		/// </summary>
		/// <param name="id">The item identifier.</param>
		/// <returns>The entity data.</returns>
		public TData Get(Guid id) {
			return GetData(id);
		}

		/// <summary>
		/// Gets all entity data.
		/// </summary>
		/// <returns>Collection of entity data.</returns>
		public IEnumerable<TData> GetAll() {
			return GetDatas();
		}

		#endregion

	}

	#endregion

}

