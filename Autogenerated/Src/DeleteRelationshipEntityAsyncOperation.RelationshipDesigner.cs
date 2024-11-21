namespace BPMSoft.Configuration.RelationshipDesigner
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities.AsyncOperations;
	using BPMSoft.Core.Entities.AsyncOperations.Interfaces;
	using BPMSoft.Core.Factories;

	#region Class: DeleteRelationshipEntityAsyncOperation

	public class DeleteRelationshipEntityAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Public

		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var relationshipDiagramManager = ClassFactory.Get<IRelationshipDiagramManager>(
				new ConstructorArgument("userConnection", userConnection));
			relationshipDiagramManager.DeleteEntityByRecordId(arguments.EntityId);
		}

		#endregion

	}

	#endregion
}

