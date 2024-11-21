using System.Collections.Generic;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Factories;

namespace BPMSoft.Configuration.FileImport {

	#region Class: PrimaryImportEntity

	///<inheritdoc cref="IPrimaryEntityFinder"/>
	public class PrimaryEntityFinder : IPrimaryEntityFinder
	{
		#region Fields: Private

		private IPrimaryImportEntitiesGetter _primaryImportEntitiesGetter;
		private IPrimaryImportEntitiesSetter _primaryImportEntitiesSetter;
		private ConstructorArgument[] _constructorArguments;
		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public PrimaryEntityFinder(UserConnection userConnection, IColumnsAggregatorAdapter columnsProcessor) {
			userConnection.CheckArgumentNull(nameof(UserConnection));
			columnsProcessor.CheckArgumentNull(nameof(IColumnsAggregatorAdapter));

			_userConnection = userConnection;

			_constructorArguments = new ConstructorArgument[] { 
				new ConstructorArgument("columnsProcessor", columnsProcessor),
				new ConstructorArgument("userConnection", _userConnection)
			};
		}

		#endregion

		#region Properties: Private

		private IPrimaryImportEntitiesGetter PrimaryImportEntitiesGetter => _primaryImportEntitiesGetter ??
			(_primaryImportEntitiesGetter =
					ClassFactory.Get<IPrimaryImportEntitiesGetter>(_constructorArguments));

		private IPrimaryImportEntitiesSetter PrimaryImportEntitiesSetter => _primaryImportEntitiesSetter ??
				(_primaryImportEntitiesSetter =
						ClassFactory.Get<IPrimaryImportEntitiesSetter>(_constructorArguments));

		#endregion

		#region Methods: Public

		///<inheritdoc cref="IPrimaryEntityFinder"/>
		public void LoadPrimaryEntity(ImportParameters parameters, IEnumerable<ImportColumn> keysImportColumns) {
			var primaryEntities = PrimaryImportEntitiesGetter.Get(parameters, keysImportColumns);
			if(_userConnection.GetIsFeatureEnabled("HighestSpeedFileImport") && 
				_userConnection.GetIsFeatureEnabled("UsePersistentFileImport")) {
				var persistentPrimaryImportEntitiesSetter = ClassFactory
				.Get<PersistentPrimaryImportEntitiesSetter>(new ConstructorArgument("userConnection", _userConnection));
				persistentPrimaryImportEntitiesSetter.Set(parameters, primaryEntities);
			} else {
				PrimaryImportEntitiesSetter.Set(parameters, primaryEntities, keysImportColumns);
			}

		}

		#endregion
	}

	#endregion
}
