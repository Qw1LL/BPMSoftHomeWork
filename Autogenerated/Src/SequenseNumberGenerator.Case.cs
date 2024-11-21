namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: SequenseNumberGenerator

	/// <summary>
	/// ##### ## ###### # ############## #########.
	/// </summary>
	[Obsolete]
	public class SequenseNumberGenerator
	{
		#region Constants: Private

		/// <summary>
		/// ######## ######## ######### ######### ########## ######.
		/// </summary>
		private const string SequenseNumberProcedureName = "tsp_GenerateSequenseNumber";

		#endregion

		#region Constructors: Public

		public SequenseNumberGenerator() {
		}

		public SequenseNumberGenerator(EntitySchema entitySchema, UserConnection userConnection) {
			EntitySchema = entitySchema;
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// ################ ###########.
		/// </summary>
		protected UserConnection UserConnection {
			get;
			set;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// ##### #######.
		/// </summary>
		public EntitySchema EntitySchema {
			get;
			set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ######## ######### ##### #######.
		/// </summary>
		/// <returns>######### ##### ########.</returns>
		public string GenerateNumber() {
			var number = string.Empty;
			var procedure = new StoredProcedure(UserConnection, SequenseNumberProcedureName);
			var dataValueTypeManager = (DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			procedure.WithParameter(EntitySchema.Name);
			procedure.WithOutputParameter("result_value", dataValueTypeManager.GetInstanceByName("Text"));
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(System.Data.IsolationLevel.ReadCommitted);
				try {
					procedure.Execute(dbExecutor);
					if (procedure.Parameters.Count > 0) {
						number = (string)procedure.Parameters[1].Value;
					}
				} catch {
					dbExecutor.RollbackTransaction();
					throw;
				}
				dbExecutor.CommitTransaction();
			}
			return number;
		}

		#endregion
	}

	#endregion
}
