namespace BPMSoft.Configuration 
{

	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: PartnershipCertifiedContactsDataExtractor

	/// <summary>
	/// Extracts partnership certified contacts data.
	/// </summary>
	public class PartnershipCertifiedContactsDataExtractor : EntityDataExtractor 
	{

		#region Fields: Private

		/// <summary>
		/// QueryColumnExpression for exist clause.
		/// </summary>
		private static readonly QueryColumnExpression existsOneConstant = Column.Const(1);

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize PartnershipCertifiedContactsDataExtractor.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance. </param>
		public PartnershipCertifiedContactsDataExtractor(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Get Select for calculation Account CertifiedContacts count.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		/// <returns> Select for calculation Account CertifiedContacts count.</returns>
		private  Select GetCertifiedContactsQuery(UserConnection userConnection) {
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

		/// <summary>
		/// Get Select for calculation PartnershipParameters value.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		/// <returns>Select for calculation PartnershipParameters value.</returns>
		private  Select GetCountsForPartnershipParameters(UserConnection userConnection) {
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

		#endregion

		#region Methods: Protected

		/// <summary>
		///<inheritdoc />
		/// </summary>
		protected override void PrepareQuery() {
			Query = GetCountsForPartnershipParameters(UserConnection);
		}

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		/// <param name="dataReader"></param>
		/// <returns></returns>
		protected override IEnumerable<Dictionary<string, object>> ConvertQueryResult(IDataReader dataReader) {
			var dataSet = new List<Dictionary<string, object>>();
			while (dataReader.Read()) {
				var row = new Dictionary<string, object>();
				row.Add("Id", dataReader.GetColumnValue<object>("Id"));
				row.Add("Count", dataReader.GetColumnValue<object>("Count"));
				dataSet.Add(row);
			}

			return dataSet;
		}

		#endregion
	}

	#endregion
}
