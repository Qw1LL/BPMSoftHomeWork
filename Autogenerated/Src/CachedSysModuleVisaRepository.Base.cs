namespace BPMSoft.Configuration
{
	using Core;
	using Core.Entities;

	#region Class: SysModuleVisaData

	/// <summary>
	/// Section approval settings data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityData" />
	public class SysModuleVisaData : EntityData
	{
		/// <summary>
		/// Gets or sets entity schema name. 
		/// </summary>
		public string VisaSchemaName { get; set; }
	}

	#endregion

	#region Class: CachedSysModuleVisaRepository

	/// <summary>
	/// The repository for approval settings.
	/// </summary>
	public class CachedSysModuleVisaRepository : CachedEntityRepository<SysModuleVisaData>
	{
		#region Constants: Public

		public static readonly string SysModuleVisaCacheGroupName = "SysModuleVisa";

		#endregion

		#region Fields: Private

		private EntitySchemaQueryColumn _visaSchemaColumnName;

		#endregion

		#region Constructors: Public

		public CachedSysModuleVisaRepository(UserConnection userConnection)
			: base(userConnection, "SysModuleVisa", SysModuleVisaCacheGroupName) {
		}

		#endregion

		#region Methods: Protected

		protected override EntitySchemaQuery GetEntityCollectionEsq() {
			var esq = base.GetEntityCollectionEsq();
			_visaSchemaColumnName = esq.AddColumn("[SysSchema:UId:VisaSchemaUId].Name");
			return esq;
		}

		protected override SysModuleVisaData CreateObjectFromEntity(Entity stage) {
			var item = base.CreateObjectFromEntity(stage);
			item.VisaSchemaName = stage.GetTypedColumnValue<string>(_visaSchemaColumnName.Name);
			return item;
		}

		#endregion
	}

	#endregion
}
