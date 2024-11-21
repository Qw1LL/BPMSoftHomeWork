namespace BPMSoft.Configuration
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Configuration;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	/// <summary>
	/// Entiches PRMTransaction entity.
	/// </summary>
	public class TransactionEnricher
	{

		#region Fields: Private

		private UserConnection _userConnection;
		private readonly string _fundLookupSchemaName = "Fund";
		private readonly string _partnershipColumnName = "PartnershipId";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize new instance of <see cref="TransactionEnricher"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public TransactionEnricher(UserConnection userConnection) {
			_userConnection = userConnection;
		}
		#endregion

		#region Methods: Private

		private Guid GetPartnershipFromFund(Guid prmFundId) {
			Guid partnershipId = Guid.Empty;
			Select selectQuery = new Select(_userConnection)
									.Column(_partnershipColumnName)
									.From(_fundLookupSchemaName)
									.Where("Id").IsEqual(Column.Parameter(prmFundId)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						partnershipId = reader.GetColumnValue<Guid>(_partnershipColumnName);
					}
				}
			}
			return partnershipId;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Enrich PRMTransaction with Partnership.
		/// </summary>
		/// <param name="prmTransactionEntity">PRM transaction entity, which is coonected with fund.</param>
		public virtual void EnrichTransactionWithPartnership(Entity prmTransactionEntity) {
			Guid prmFundId = prmTransactionEntity.GetTypedColumnValue<Guid>($"{_fundLookupSchemaName}Id");
			if (prmFundId != Guid.Empty) {
				Guid partnershipId = GetPartnershipFromFund(prmFundId);
				if (partnershipId != Guid.Empty) {
					prmTransactionEntity.SetColumnValue(_partnershipColumnName, partnershipId);
				}
			}
		}

		#endregion

	}
}
