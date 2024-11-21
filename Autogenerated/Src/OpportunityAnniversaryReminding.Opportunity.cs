namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: OpportunityAnniversaryReminding

	public class OpportunityAnniversaryReminding : BaseAnniversaryReminding
	{

		#region Constants

		private const int DefaultActualPeriod = 6;

		#endregion

		#region Fields: Public

		public static readonly string AccountOption = "Account";
		public static readonly string ContactOption = "Contact";
		public static readonly string ParticipantOption = "Participant";

		#endregion

		#region Constructor: Public

		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// </summary>
		public OpportunityAnniversaryReminding(UserConnection userConnection): base(userConnection) {
			SchemaName = "Opportunity";
			SourceId = RemindingConsts.OpportunityRemindSourceId;
			_actualPeriod = Core.Configuration.SysSettings.GetValue<int>(UserConnection,
				"NoteworthyPeriodForOpportunityParticipants", DefaultActualPeriod);
		}
		
		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="id">Current record Id.</param>
		/// </summary>
		public OpportunityAnniversaryReminding(UserConnection userConnection, Guid id): this(userConnection) {
			RecordId = id;
		}

		#endregion
		
		#region Properties: Protected
		
		private int _actualPeriod;
		protected int ActualPeriod {
			get {
				if (_actualPeriod == 0) {
					_actualPeriod = DefaultActualPeriod;
				}
				return _actualPeriod;
			}
			set {
				_actualPeriod = value;
			}
		}
		
		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns select with all filters for current entity.
		/// <param name="select">Select for getting anniversary reminding.</param>
		/// <param name="queryProperty">Query property for current select.</param>
		/// <param name="queryProperty.Key">Anniversary entity schema name</param>
		/// <param name="queryProperty.Value">The property determines type of the decoration.</param>
		/// <returns>Modified select with all filters for current entity.</returns>
		/// </summary>
		protected override Select DecorateSelect(Select select, KeyValuePair<string, string> queryProperty) {
			select
				.And()
				.OpenBlock()
					.OpenBlock(SchemaName, "StageId").IsNotEqual(Column
						.Parameter(OpportunityConstants.OpportunityClosedRejectedId))
						.And(SchemaName, "StageId").IsNotEqual(Column
							.Parameter(OpportunityConstants.OpportunityClosedReroutedId))
						.And(SchemaName, "StageId").IsNotEqual(Column
							.Parameter(OpportunityConstants.OpportunityClosedWonId))
						.And(SchemaName, "StageId").IsNotEqual(Column
							.Parameter(OpportunityConstants.OpportunityClosedLostId))
					.CloseBlock()
					.Or()
					.OpenBlock(
						Func.DateDiff(
							DateDiffQueryFunctionInterval.Month,
							Column.SourceColumn(SchemaName, "DueDate"),
							Func.CurrentDateTime()
						)
					).IsLessOrEqual(Column.Parameter(ActualPeriod))
					.CloseBlock()
				.CloseBlock();
			switch (queryProperty.Value) {
				case "Participant":
					select.Join(JoinType.Inner, SchemaName + "Contact")
						.On(SchemaName, "Id").IsEqual(SchemaName + "Contact", SchemaName + "Id");
					select.Join(JoinType.Inner, "Contact")
						.On("Contact", "Id").IsEqual(SchemaName + "Contact", "ContactId");
					break;
				default:
					select = AnniversaryRemindingsHelper.JoinTable(select, SchemaName, queryProperty.Key);
					break;
			}
			return select;
		}

		protected override void InitQueryProperties() {
			base.InitQueryProperties();
			AddQueryProperty("Account", string.Empty);
			AddQueryProperty("Contact", "Contact");
			AddQueryProperty("Contact", "Participant");
		}

		protected override Dictionary<string, KeyValuePair<string, string>> GetQueryOptionsDictionary() {
			var optionsDict = base.GetQueryOptionsDictionary();
			optionsDict.Add(AccountOption, new KeyValuePair<string, string>("Account", string.Empty));
			optionsDict.Add(ContactOption, new KeyValuePair<string, string>("Contact", "Contact"));
			optionsDict.Add(ParticipantOption, new KeyValuePair<string, string>("Contact", "Participant"));
			return optionsDict;
		}

		#endregion

	}

	#endregion
}

