namespace BPMSoft.Configuration
{
	using System;
	using System.Threading.Tasks;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;
	using BPMSoft.Core.Entities;
	using global::Common.Logging;

	#region Class: WarmupUtility

	/// <summary>
	/// ######## ######### ###### ### ######### ##########.
	/// </summary>
	public static class WarmupUtility
	{

		#region Methods: Private

		private static void WarmupManager<TM, TS>(ISchemaManager schemaManager)
				where TM : ISchemaManager
				where TS : Schema, ISchemaManagerSchema<TS> {
			var typeSchemaManager = (TM)schemaManager;
			var schemaManagerItems = typeSchemaManager.GetItems();
			foreach (SchemaManagerItem<TS> item in schemaManagerItems) {
				Schema instance = item.Instance;
			}
		}

		private static void WarmupEntities(UserConnection userConnection) {
			WarmupManager<EntitySchemaManager, EntitySchema>(userConnection
				.GetSchemaManager(typeof(EntitySchemaManager).Name));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ####### #########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		public static void WarmupManager<TM, TS>(UserConnection userConnection)
			where TM : ISchemaManager
			where TS : Schema, ISchemaManagerSchema<TS> {
			WarmupManager<TM, TS>(userConnection.GetSchemaManager(typeof(TM).Name));
		}

		/// <summary>
		/// ######### ####### ##########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		public static void WarmupApplication(UserConnection userConnection) {
			WarmupEntities(userConnection);
		}

		/// <summary>
		/// ######### ####### ########## ##########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		public static void WarmupApplicationAsync(UserConnection userConnection) {
			Task.Run(() => WarmupApplication(userConnection));
		}

		/// <summary>
		/// ######### ####### ######## ##########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		public static void WarmupEntitiesAsync(UserConnection userConnection) {
			Task.Run(() => WarmupEntities(userConnection));
		}

		#endregion

	}

	#endregion

	#region Class: WarmupAppEventListener

	public class WarmupAppEventListener : IAppEventListener
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("AppEventLoader");

		#endregion

		#region Methods: Public

		public virtual void OnAppStart(AppEventContext context) {
			var appConection = context.Application["AppConnection"] as AppConnection;
			if (appConection == null) {
				return;
			}
			UserConnection userConnection = appConection.SystemUserConnection;
			object warmupOn;
			if (BPMSoft.Core.Configuration.SysSettings.TryGetValue(userConnection, "UseWarmupApp", out warmupOn)
					&& (bool)warmupOn) {
				_log.Info("Warmup application start at : " + DateTime.Now.ToLongTimeString());
				WarmupUtility.WarmupApplicationAsync(userConnection);
				_log.Info("Warmup application finished at : " + DateTime.Now.ToLongTimeString());
			} else if (BPMSoft.Core.Configuration.SysSettings.TryGetValue(userConnection, "UseWarmupEntities", out warmupOn)
					&& (bool)warmupOn) {
				_log.Info("Warmup entities start at : " + DateTime.Now.ToLongTimeString());
				WarmupUtility.WarmupEntitiesAsync(userConnection);
				_log.Info("Warmup entities finished at : " + DateTime.Now.ToLongTimeString());
			}
		}

		public virtual void OnAppEnd(AppEventContext context) {
		}

		public virtual void OnSessionStart(AppEventContext context) {
		}

		public virtual void OnSessionEnd(AppEventContext context) {
		}

		#endregion

	}

	#endregion

}
