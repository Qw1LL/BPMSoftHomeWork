namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: ActivityAnniversaryReminding

	public class ActivityAnniversaryReminding : BaseAnniversaryReminding
	{
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
		public ActivityAnniversaryReminding(UserConnection userConnection): base(userConnection) {
			SchemaName = "Activity";
			SourceId = RemindingConsts.ActivityRemindSourceId;
		}
		
		/// <summary>
		/// Constructor.
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="id">Current record Id.</param>
		/// </summary>
		public ActivityAnniversaryReminding(UserConnection userConnection, Guid id): this(userConnection) {
			RecordId = id;
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
			switch (queryProperty.Value) {
				case "Participant":
					select.Join(JoinType.Inner, SchemaName + "Participant")
						.On(SchemaName, "Id").IsEqual(SchemaName + "Participant", SchemaName + "Id");
					select.Join(JoinType.Inner, "Contact")
						.On("Contact", "Id").IsEqual(SchemaName + "Participant", "ParticipantId");
					break;
				default:
					select = AnniversaryRemindingsHelper.JoinTable(select, SchemaName, queryProperty.Key);
					break;
			}
			select.And("Activity", "DueDate").IsGreaterOrEqual(Column.Parameter(DateTime.UtcNow));
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

