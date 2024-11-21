namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using Common;
	using Core;
	using Core.DB;
	using Core.Entities;

	#region Class : CertificateUtils

	/// <summary>
	/// A helper class for operations with certificates.
	/// </summary>
	public static class CertificateUtils
	{

		#region Fields : Private

		private static readonly QueryColumnExpression existsOneConstant = Column.Const(1);

		#endregion

		#region Methods : Private

		private static Select GetCertifiedContactsQuery(UserConnection userConnection) {
			var query = new Select(userConnection)
				.Column("Contact", "AccountId")
				.Column(Func.Count(existsOneConstant)).As("Count")
				.From("Contact").Where()
				.Exists(new Select(userConnection).Column(existsOneConstant).From("Certificate")
					.Where("Certificate", "ContactId").IsEqual("Contact", "Id")
					.And("Certificate", "IssueDate").IsLessOrEqual(Column.Parameter(DateTime.UtcNow))
					.And("Certificate", "ExpireDate").IsGreaterOrEqual(Column.Parameter(DateTime.UtcNow)))
				.GroupBy("Contact", "AccountId");
			return query as Select;
		}

		private static Select GetCountsForPartnershipParameters(UserConnection userConnection) {
			var certifiedContactsQuery = GetCertifiedContactsQuery(userConnection);
			var query = new Select(userConnection)
				.Column("pp", "Id")
				.Column(Func.Coalesce(
					Column.SourceColumn("ca", "Count"),
					Column.Const(0))).As("Count")
				.From("Partnership").As("part")
				.Join(JoinType.LeftOuter, "PartnershipParameter").As("pp")
					.On("pp", "PartnershipId").IsEqual("part", "Id")
					.And("pp", "PartnerParamCategoryId")
						.IsEqual(Column.Parameter(PRMBaseConstants.NumberOfCertifiedExpertsCategory))
					.And("pp", "PartnershipParameterTypeId")
						.IsEqual(Column.Parameter(PRMBaseConstants.CurrentPartnershipParamTypeId))
					.And("pp", "ParameterTypeId")
						.IsEqual(Column.Parameter(PRMBaseConstants.ObligationParameterTypeId))
				.Join(JoinType.LeftOuter, certifiedContactsQuery).As("ca")
					.On("part", "AccountId").IsEqual("ca", "AccountId")
				.Where("part", "IsActive").IsEqual(Column.Const(true))
				.And("pp", "IntValue").IsNotEqual(
					Func.Coalesce(
						Column.SourceColumn("ca", "Count"),
						Column.Const(0)));
			return query as Select;
		}

		private static Select GetCountsForPartnershipParameter(UserConnection userConnection, Guid partnershipId) {
			var resultSelect = GetCountsForPartnershipParameters(userConnection)
				.And("part", "Id").IsEqual(Column.Parameter(partnershipId)) as Select;
			return resultSelect;
		}

		private static void Actualization(UserConnection userConnection, Select query) {
			EntitySchema schema = userConnection.EntitySchemaManager.GetInstanceByName("PartnershipParameter");
			Entity entity = schema.CreateEntity(userConnection);
			var columnName = "IntValue";
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dr = query.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var id = dr.GetColumnValue<Guid>("Id");
						var value = dr.GetColumnValue<int>("Count");
						if (entity.FetchFromDB(id)) {
							entity.SetColumnValue(columnName, value);
							entity.Save();
						}
					}
				}
			}
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Actualizes count of certified contacts for all active partnerships.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public static void ActualizeAll(UserConnection userConnection) {
			var select = GetCountsForPartnershipParameters(userConnection);
			Actualization(userConnection, select);
		}

		/// <summary>
		/// Actualizes count of certified contacts by given partnership.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="partnershipId">Partnership identifier.</param>
		public static void Actualize(UserConnection userConnection, Guid partnershipId) {
			var select = GetCountsForPartnershipParameter(userConnection, partnershipId) as Select;
			Actualization(userConnection, select);
		}

		#endregion

	}

	#endregion

}
