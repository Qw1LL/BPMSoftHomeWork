namespace BPMSoft.Configuration 
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;

	#region Class: EntityDataActualizer

	/// <summary>
	/// Controls entity data actualzation.
	/// </summary>
	public class EntityDataActualizer 
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection _userConnection;
		/// <summary>
		/// Data extractor, which extract data in specific format. 
		/// </summary>
		private EntityDataExtractor _dataExtractor { get; set; }
		/// <summary>
		/// Entity data context, which apply data to database.
		/// </summary>
		private EntityActualizatorDataContext _entityDataContext { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialize EntityDataActualizer.
		/// </summary>
		/// <param name="userConnection">UserConnection instance.</param>
		/// <param name="dataExtractor">EntityDataExtractor instance for dataset extraction.</param>
		/// <param name="entityDataContext">EntityActualizatorDataContext instance for dataset apply.</param>
		public EntityDataActualizer(
			UserConnection userConnection, 
			EntityDataExtractor dataExtractor,
			EntityActualizatorDataContext entityDataContext) {

				_userConnection = userConnection;
				_dataExtractor = dataExtractor;
				_entityDataContext = entityDataContext;		
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Actualize entity data with dataset which extracted from EntityDataExtractor 
		/// by EntityDataContext based on mapping rules.
		/// </summary>
		/// <param name="keyColumnName">Name of entity KeyColumn.</param>
		/// <param name="entitySchemaName">Name of entity schema.</param>
		/// <param name="columnsMapping">Columns mapping for dataset apply.</param>
		public void Actualize(string keyColumnName, string entitySchemaName, Dictionary<string, string> columnsMapping) {
			var dataSet = _dataExtractor.ExtractData();
			_entityDataContext.ApplyData(entitySchemaName, keyColumnName, columnsMapping, dataSet);
		}

		#endregion
	}

	#endregion
}
