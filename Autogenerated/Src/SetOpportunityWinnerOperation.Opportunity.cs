namespace BPMSoft.Configuration
{

	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: SetOpportunityWinnerOperation

	/// <summary>
	/// Performs opportunity winner setting operation.
	/// </summary>
	public class SetOpportunityWinnerOperation
	{

		#region Constants: Private

		private const string AccountEntityName = "Account";
		private const string StageColumnName = "StageId";
		private const string OwnerColumnName = "OwnerId";

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly Guid _closedWonStageId = new Guid("60D5310C-5BE6-DF11-971B-001D60E938C6");
		private readonly Guid _closedLostStageId = new Guid("A9AAFDFE-2242-4F42-8CD5-2AE3B9556D79");

		#endregion

		#region Constructors: Public

		public SetOpportunityWinnerOperation(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Protected

		protected Guid GetOpportunityOwnerContactId(Guid ownerId) {
			EntitySchemaQuery ownerEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Contact");
			ownerEsq.AddColumn(AccountEntityName);
			Entity ownerEntity = ownerEsq.GetEntity(_userConnection, ownerId);
			if (ownerEntity == null) {
				return Guid.Empty;
			}
			return ownerEntity.GetTypedColumnValue<Guid>($"{AccountEntityName}Id");
		}

		protected Guid GetCompetitorAsWinner(Entity entity) {
			Select select = new Select(_userConnection).Top(1)
							.Column("CompetitorId")
						.From("OpportunityCompetitor")
						.Where("OpportunityId").IsEqual(Column.Parameter(entity.PrimaryColumnValue))
							.And("IsWinner").IsEqual(Column.Parameter(true))
							.And("CompetitorId").Not().IsNull() as Select;
			return select.ExecuteScalar<Guid>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sets opportunity owners company or competitor as opportunity winner
		/// if opportity was closed with won or lost.
		/// </summary>
		/// <param name="entity">Opportunity entity.</param>
		public virtual void DoOperation(Entity entity) {
			Guid stageId; 
			if (!entity.IsColumnValueLoaded(StageColumnName)) {
				return;
			}
			stageId = entity.GetTypedColumnValue<Guid>(StageColumnName);
			Guid oldStageId = entity.GetTypedOldColumnValue<Guid>(StageColumnName);
			if (stageId == oldStageId) {
				return;
			}
			Guid oppWinnerId = Guid.Empty;
			if (stageId == _closedWonStageId) {
				Guid ownerId = entity.IsColumnValueLoaded(OwnerColumnName) ? entity.GetTypedColumnValue<Guid>(OwnerColumnName) : Guid.Empty;
				oppWinnerId = GetOpportunityOwnerContactId(ownerId);
			} else if (stageId == _closedLostStageId) {
				oppWinnerId = GetCompetitorAsWinner(entity);
			}
			if (!oppWinnerId.Equals(Guid.Empty)) {
				entity.SetColumnValue("WinnerId", oppWinnerId);
			}
		}

		#endregion

	} 
	
	#endregion

} 
