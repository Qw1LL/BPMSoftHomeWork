namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: SysModuleVisaNotificationProvider

	/// <summary>
	/// Visas notification provider for sections.
	/// </summary>
	public class SysModuleVisaNotificationProvider : BaseVisaNotificationProvider, INotification
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="SysModuleVisaNotificationProvider"/> class with parameters.
		/// </summary>
		/// <param name="parameters">Parameters dictionary.</param>
		public SysModuleVisaNotificationProvider(Dictionary<string, object> parameters)
			: base(parameters) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SysModuleVisaNotificationProvider"/> class with parameters.
		/// </summary>
		/// <param name="userConnection">UserConnection.</param>
		public SysModuleVisaNotificationProvider(UserConnection userConnection)
			: base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private Select GetSysModuleSelect() {
			var select =
				new Select(UserConnection)
					.Column("SysModuleEntity", "SysEntitySchemaUId").As("EntitySchemaUId")
					.Column("SysModuleVisa", "VisaSchemaUId").As("VisaSchemaUId")
					.Column("SysModuleVisa", "MasterColumnUId").As("MasterColumnUId")
					.Column("SysModule", "Image32Id")
				.From("SysModule")
					.InnerJoin("SysModuleVisa").On("SysModuleVisa", "Id")
						.IsEqual("SysModule", "SysModuleVisaId")
					.InnerJoin("SysModuleEntity").On("SysModuleEntity", "Id")
						.IsEqual("SysModule", "SysModuleEntityId")
				.Where("SysModuleVisa", "UseCustomNotificationProvider")
					.IsEqual(Column.Parameter(false)) as Select;
			return select;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Return number of section notification.
		/// </summary>
		/// <returns>A number of notification.</returns>
		public override int GetCount() {
			Select entitySelect = GetEntitiesSelect();
			if (entitySelect == null) {
				return 0;
			}
			Select countSelect =
				new Select(UserConnection)
					.Column(Func.Count("Id"))
					.Distinct()
				.From(entitySelect).As("CountSelect") as Select;
			return countSelect.ExecuteScalar<int>();
		}

		/// <summary>
		/// Returns <see cref="Select"/> for section visas./>
		/// </summary>
		/// <returns>A <see cref="Select"/> instance.</returns>
		public override Select GetEntitiesSelect() {
			Select entitiesSelect = null;
			GetSysModuleSelect().ExecuteReader(reader => {
				Guid entitySchemaUId = reader.GetColumnValue<Guid>("EntitySchemaUId");
				Guid visaSchemaUId = reader.GetColumnValue<Guid>("VisaSchemaUId");
				Guid masterColumnUId = reader.GetColumnValue<Guid>("MasterColumnUId");
				Guid sysModuleImage32Id = reader.GetColumnValue<Guid>("Image32Id");
				EntitySchema visaSchema = EntitySchemaManager.GetInstanceByUId(visaSchemaUId);
				EntitySchema entitySchema = EntitySchemaManager.GetInstanceByUId(entitySchemaUId);
				EntitySchemaColumn masterColumn = visaSchema.Columns.GetByUId(masterColumnUId);
				var sysModuleVisaProvider = new BaseVisaNotificationProvider(parameters) {
					Name = entitySchema.Name,
					Caption = entitySchema.Caption,
					Visa = visaSchema.Name,
					VisaMasterColumn = masterColumn.ColumnValueName,
					TitleColumn = entitySchema.PrimaryDisplayColumn.ColumnValueName,
					ImageId = sysModuleImage32Id
				};
				Select sysModuleVisaSelect = sysModuleVisaProvider.GetEntitiesSelect();
				entitiesSelect = entitiesSelect == null
					? sysModuleVisaSelect
					: entitiesSelect.UnionAll(sysModuleVisaSelect) as Select;
			});
			return entitiesSelect;
		}

		/// <summary>
		/// Returns notification. Method is not implemented.
		/// </summary>
		public IEnumerable<INotificationInfo> GetNotifications() {
			throw new NotImplementedException();
		}

		#endregion

	}

	#endregion
}
