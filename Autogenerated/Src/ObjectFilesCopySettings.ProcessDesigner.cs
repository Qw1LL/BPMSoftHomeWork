namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Entities;

	#region Class: ObjectFilesCopySettings

	/// <summary>
	/// Represents object files copy settings.
	/// </summary>
	public class ObjectFilesCopySettings
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets ESQ to select which file to copy.
		/// </summary>
		public EntitySchemaQuery EntitySchemaQuery { get; set; }

		/// <summary>
		/// Gets or sets unique identifier of destination entity schema.
		/// </summary>
		public Guid TargetEntitySchemaUId { get; set; }

		/// <summary>
		/// Gets or sets identifier of the connected object.
		/// </summary>
		public Guid ConnectedObjectId { get; set; }

		/// <summary>
		/// Gets or sets unique identifier of the connected object column.
		/// </summary>
		public Guid ConnectedObjectColumnUId { get; set; }

		#endregion

	}

	#endregion

}

