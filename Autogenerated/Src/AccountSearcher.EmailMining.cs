namespace BPMSoft.Configuration.EmailMining
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IAccountSearcher

	/// <summary>
	/// Provides utility methods for searching accounts.
	/// </summary>
	public interface IAccountSearcher {
		/// <summary>
		/// Searches for the accounts by their names.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>Identifiers of the found accounts or <c>null</c> if nothing was found.</returns>
		IEnumerable<Guid> SearchByName(string name);

		/// <summary>
		/// Searches for the accounts by their web site domains.
		/// </summary>
		/// <param name="domains">The domains of the account to find.</param>
		/// <returns>Identifiers of the found accounts or <c>null</c> if nothing was found.</returns>
		/// <exception cref="ArgumentNullOrEmptyException">Passed <see cref="domains"/> is <c>null</c>.</exception>
		IEnumerable<Guid> SearchByDomain(IEnumerable<string> domains);
	}

	#endregion

	#region Class: AccountSearcher

	/// <summary>
	/// Implementation of <see cref="IAccountSearcher"/>.
	/// </summary>
	[DefaultBinding(typeof(IAccountSearcher))]
	public class AccountSearcher : IAccountSearcher
	{

		#region Constants: Private

		private const int MaxSearchDomainsCount = 3;
		private const int MaxSearchResultCount = 5;
		private const int MinDomainLength = 3;

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly string[] _webAddressVariants = {
			"http://{0}", "https://{0}", "http://www.{0}", "https://www.{0}", "www.{0}", "{0}"
		};

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="AccountSearcher"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public AccountSearcher(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private static EntitySchemaQueryFilter AddUpperFunctionFilter(EntitySchemaQuery esq, string columnName,
				string filterValue) {
			EntitySchemaQueryFunction upperNameFunction = esq.CreateUpperFunction(columnName);
			var filter = new EntitySchemaQueryFilter(FilterComparisonType.Equal) {
				LeftExpression = new EntitySchemaQueryExpression(upperNameFunction)
			};
			filter.RightExpressions.Add(new EntitySchemaQueryExpression(EntitySchemaQueryExpressionType.Parameter) {
				ParameterValue = filterValue.ToUpperInvariant()
			});
			esq.Filters.Add(filter);
			return filter;
		}

		private void AddDomainFilters(string domain, EntitySchemaQuery esq) {
			if (domain.IsNullOrEmpty() || domain.Length < MinDomainLength) {
				return;
			}
			_webAddressVariants.ForEach(webAddress => {
				IEntitySchemaQueryFilterItem filter = esq.CreateFilterWithParameters(FilterComparisonType.StartWith,
					"Number", string.Format(webAddress, domain));
				esq.Filters.Add(filter);
			});
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Searches for the accounts by their names.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns>Identifiers of the found accounts or <c>null</c> if nothing was found.</returns>
		public virtual IEnumerable<Guid> SearchByName(string name) {
			if (name.IsNullOrEmpty()) {
				return null;
			}
			EntitySchema accountSchema = _userConnection.EntitySchemaManager.GetInstanceByName("Account");
			string primaryDisplayColumnName = accountSchema.PrimaryDisplayColumn.Name;
			var esq = new EntitySchemaQuery(accountSchema);
			esq.PrimaryQueryColumn.IsVisible = true;
			EntitySchemaQueryFilter filter = AddUpperFunctionFilter(esq, primaryDisplayColumnName, name);
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			if (entities.IsNotEmpty()) {
				return entities.Select(entity => entity.PrimaryColumnValue);
			}
			filter.LeftExpression.Function = esq.CreateUpperFunction("AlternativeName");
			esq.ResetSelectQuery();
			entities = esq.GetEntityCollection(_userConnection);
			if (entities.IsNotEmpty()) {
				return entities.Select(entity => entity.PrimaryColumnValue);
			}
			return null;
		}

		/// <summary>
		/// Searches for the accounts by their web site domains.
		/// </summary>
		/// <param name="domains">The domains of the account to find.</param>
		/// <returns>Identifiers of the found accounts or <c>null</c> if nothing was found.</returns>
		/// <exception cref="ArgumentNullOrEmptyException">Passed <see cref="domains"/> is <c>null</c>.</exception>
		public virtual IEnumerable<Guid> SearchByDomain(IEnumerable<string> domains) {
			domains.CheckArgumentNull("domains");
			List<string> domainList = domains.Take(MaxSearchDomainsCount).ToList();
			if (domainList.IsEmpty()) {
				return null;
			}
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "AccountCommunication") {
				RowCount = MaxSearchResultCount,
				IsDistinct = true
			};
			esq.PrimaryQueryColumn.IsVisible = false;
			EntitySchemaQueryColumn accountIdColumn = esq.AddColumn("=Account.Id");
			domainList.ForEach(email => AddDomainFilters(email, esq));
			if (esq.Filters.IsEmpty()) {
				return null;
			}
			esq.Filters.LogicalOperation = LogicalOperationStrict.Or;
			EntityCollection entities = esq.GetEntityCollection(_userConnection);
			if (entities.IsEmpty()) {
				return null;
			}
			return entities.Select(entity => entity.GetTypedColumnValue<Guid>(accountIdColumn.Name)).Distinct();
		}

		#endregion

	}

	#endregion

}

