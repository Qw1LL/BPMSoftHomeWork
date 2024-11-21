namespace BPMSoft.Configuration
{
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;
	using BPMSoft.Core.Process.Configuration;

	#region Class: ContractEntityEventListener

	/// <summary>
	/// Class provides contract entities events handling.
	/// </summary>
	/// <seealso cref="BPMSoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Contract")]
	public class ContractEntityEventListener : BaseEntityEventListener {

		#region Methods: Private

		private object GenerateSequenseNumber(Entity entity) {
			var gererator = new GenerateSequenseNumberUserTask(entity.UserConnection);
			return gererator.GenerateSequenseNumber(entity.Schema, entity.UserConnection);
		}

		private bool IsNumberEmpty(Entity entity) {
			var result = entity.GetTypedColumnValue<string>("Number");
			return string.IsNullOrEmpty(result);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// <see cref="BaseEntityEventListener.OnInserting"/>
		/// </summary>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			base.OnInserting(sender, e);
			var entity = (Entity)sender;
			if (IsNumberEmpty(entity)) {
				var sequenseNumber = GenerateSequenseNumber(entity);
				entity.SetColumnValue("Number", sequenseNumber);
			}
		}

		#endregion

	}

	#endregion

}

