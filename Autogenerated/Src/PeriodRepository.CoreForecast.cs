namespace BPMSoft.Configuration.ForecastV2
{
	using Core;
	using Core.Entities;
	using Core.Factories;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Store;

	#region Class: Period

	/// <summary>
	/// Represents DTO for Period entity.
	/// </summary>
	public class Period : EntityData
	{

		#region Properties: Public

		/// <summary>
		/// Name of period.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Identifier of period type.
		/// </summary>
		public Guid PeriodTypeId { get; set; }

		/// <summary>
		/// Period start date.
		/// </summary>
		public DateTime StartDate { get; set; }

		/// <summary>
		/// Period due date.
		/// </summary>
		public DateTime DueDate { get; set; }

		/// <summary>
		/// Code of period.
		/// </summary>
		public string Code => FormCode(Name);

		/// <summary>
		/// Forms period code from period name value.
		/// </summary>
		/// <param name="value">Period name value.</param>
		/// <returns>Period code.</returns>
		public static string FormCode(string value) {
			return value?.Replace(" ", "_");
		}

		#endregion

	}

	#endregion

	#region Interface: IPeriodRepository

	/// <summary>
	/// Interface for Period entities repository.
	/// </summary>
	public interface IPeriodRepository
	{
		/// <summary>
		/// Get all periods with specified type.
		/// </summary>
		/// <param name="periodTypeId">Period type identifier.</param>
		IEnumerable<Period> GetPeriods(Guid periodTypeId);

		/// <summary>
		/// Get all periods with specified type.
		/// </summary>
		/// <param name="periodTypeId">Period type identifier.</param>
		/// <param name="year">Year, which containing needed periods.</param>
		IEnumerable<Period> GetPeriods(Guid periodTypeId, int year);

		/// <summary>
		/// Get all periods with specified identifiers.
		/// </summary>
		/// <param name="periodIds">Periods identifiers.</param>
		IEnumerable<Period> GetPeriods(IEnumerable<Guid> periodIds);
	}

	#endregion

	#region Class: PeriodRepository

	/// <summary>
	/// Repository for Period entities.
	/// </summary>
	[DefaultBinding(typeof(IPeriodRepository))]
	public class PeriodRepository : CachedEntityRepository<Period>, IPeriodRepository
	{

		#region Constants: Private

		private const string NameColumn = "Name";
		private const string PeriodTypeColumn = "PeriodType";
		private const string StartDateColumn = "StartDate";
		private const string DueDateColumn = "DueDate";

		#endregion

		#region Constructors: Public

		public PeriodRepository(UserConnection userConnection)
			: base(userConnection, "Period",
				string.Format(ResetCachePeriodEvent.PeriodCacheTemplate, userConnection.CurrentUser.Culture.Name)) {
		}

		#endregion

		#region Methods: Private

		private IEnumerable<Period> GetOrderedCollectionByStartDate(IEnumerable<Period> collection) {
			return collection.OrderBy(e => e.StartDate).ToList();
		}

		#endregion

		#region Methods: Protected

		///<inheritdoc />
		protected override EntitySchemaQuery GetEntityCollectionEsq() {
			var esq = base.GetEntityCollectionEsq();
			esq.AddColumn(NameColumn);
			esq.AddColumn(PeriodTypeColumn);
			esq.AddColumn(StartDateColumn);
			esq.AddColumn(DueDateColumn);
			return esq;
		}

		///<inheritdoc />
		protected override Period CreateObjectFromEntity(Entity entity) {
			var period = base.CreateObjectFromEntity(entity);
			period.PeriodTypeId = entity.GetTypedColumnValue<Guid>($"{PeriodTypeColumn}Id");
			period.Name = entity.GetTypedColumnValue<string>(NameColumn);
			period.StartDate = entity.GetTypedColumnValue<DateTime>(StartDateColumn);
			period.DueDate = entity.GetTypedColumnValue<DateTime>(DueDateColumn);
			return period;
		}

		///<inheritdoc />
		protected override void FillEntityFromObject(Entity entity, Period item) {
			base.FillEntityFromObject(entity, item);
			entity.SetColumnValue(PeriodTypeColumn, item.PeriodTypeId);
			entity.SetColumnValue(StartDateColumn, item.StartDate);
			entity.SetColumnValue(DueDateColumn, item.DueDate);
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public IEnumerable<Period> GetPeriods(Guid periodTypeId) {
			var collection = GetAll().Where(e => e.PeriodTypeId == periodTypeId);
			return GetOrderedCollectionByStartDate(collection);
		}

		///<inheritdoc />
		public IEnumerable<Period> GetPeriods(Guid periodTypeId, int year) {
			var collection = GetAll().Where(e => e.PeriodTypeId == periodTypeId
				&& e.StartDate.Year == year);
			return GetOrderedCollectionByStartDate(collection);
		}

		///<inheritdoc />
		public IEnumerable<Period> GetPeriods(IEnumerable<Guid> periodIds) {
			HashSet<Guid> periodIdsSet = new HashSet<Guid>(periodIds);
			var collection = GetAll().Where(e => periodIdsSet.Contains(e.Id));
			return GetOrderedCollectionByStartDate(collection);
		}

		#endregion

	}

	#endregion

	#region Class: ResetCachePeriodEvent

	/// <summary>
	/// Handles for reset cache period.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Period")]
	public class ResetCachePeriodEvent : BaseEntityEventListener
	{

		#region Constants: Public

		public const string PeriodCacheTemplate = "PeriodCacheGroup_{0}";

		#endregion

		#region Methods: Private

		private void ResetCache(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			Dictionary<Guid, string> cultures = CommonUtilities.GetCulturesNames(userConnection);
			cultures.Values.ForEach(cultureName => {
				var groupName = string.Format(PeriodCacheTemplate, cultureName);
				userConnection.ApplicationCache.ExpireGroup(groupName);
			});
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			ResetCache(sender);
		}

		/// <inheritdoc />
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ResetCache(sender);
		}

		#endregion

	}

	#endregion

}

