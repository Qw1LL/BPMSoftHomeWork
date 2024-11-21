namespace BPMSoft.Configuration
{
	using BPMSoft.Core;

	#region  Class: ContactActualizeAge

	public class ContactActualizerAge : BaseActualizerAge
	{

		#region Constructor: Public

		public ContactActualizerAge(UserConnection userConnection) : base(userConnection) { }

		public ContactActualizerAge(UserConnection userConnection, int ChunkSize, int MaxDegreeOfParallelism, int ChunkProcessingDelay) : base(userConnection) {
			if (ChunkSize > 0) {
				this.ChunkSize = ChunkSize;
			}
			if (MaxDegreeOfParallelism > 0) {
				this.MaxDegreeOfParallelism = MaxDegreeOfParallelism;
			}
			if (ChunkProcessingDelay > 0) {
				this.ChunkProcessingDelay = ChunkProcessingDelay;
			}
		}

		#endregion

		#region Properties: Protected

		protected override string EntityName => "Contact";
		protected override string UpdateEntityColumnName => "Age";
		protected override string EntityDateColumnName => "BirthDate";

		#endregion

	}

	#endregion

}
