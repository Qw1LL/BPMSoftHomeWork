namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: SysCultureUtilities

	public class SysCultureUtilities
	{
		#region Fields: Protected

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		protected readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialuze new culture utility class instance.
		/// </summary>
		/// <param name="userConnection"> User connection.</param>
		/// <returns></returns>
		public SysCultureUtilities(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Get default culture from cultures.
		/// </summary>
		/// <returns>Default culture uniqueidentifier.</returns>
		private Guid GetDefaultCultureFromSysCulture() {
			Guid recordId = Guid.Empty;
			var sysCultureEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "SysCulture");
			var idColumn = sysCultureEsq.AddColumn(sysCultureEsq.RootSchema.GetPrimaryColumnName()); 
			sysCultureEsq.Filters
				.Add(sysCultureEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Default", true));
			var sysCultureEntities = sysCultureEsq.GetEntityCollection(_userConnection);
			if (sysCultureEntities.Count > 0) {
				var firstEntity = sysCultureEntities[0];
				recordId = firstEntity.GetTypedColumnValue<Guid>(idColumn.Name);
			}
			return recordId;
		}

		/// <summary>
		/// Get default culture from system settings.
		/// </summary>
		/// <returns>Default culture uniqueidentifier.</returns>
		private Guid GetDefaultCultureFromSysSettings() {
			return (Guid)BPMSoft.Core.Configuration.SysSettings.GetValue(_userConnection, "PrimaryCulture");
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get default culture.
		/// </summary>
		/// <returns>Default culture uniqueidentifier.</returns>
		public Guid GetDefaultCulture() {
			Guid recordId = GetDefaultCultureFromSysCulture();
			if (recordId == Guid.Empty) {
				recordId = GetDefaultCultureFromSysSettings();
			}
			return recordId;
		}

		#endregion

	}

	#endregion

}
