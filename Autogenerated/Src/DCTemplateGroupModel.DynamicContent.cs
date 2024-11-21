namespace BPMSoft.Configuration.DynamicContent.Models
{
	using System;
	using BPMSoft.Configuration.DynamicContent.DataContract;

	#region Class: DCTemplateGroupModel

	/// <summary>
	/// Class to represent data model for <see cref="DCTemplateGroup"/> entity.
	/// </summary>
	public class DCTemplateGroupModel
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier.
		/// </summary>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Unique identifier of template entity.
		/// </summary>
		public Guid DCTemplateId { get; set; }

		/// <summary>
		/// Unique index within the template.
		/// </summary>
		public int Index { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCTemplateGroupContract"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="model">Template model object which converted.</param>
		public static explicit operator DCTemplateGroupContract(DCTemplateGroupModel model) =>
			model != null
				? new DCTemplateGroupContract {
					Id = model.Id,
					Index = model.Index
				}
				: null;

		#endregion

	}

	#endregion

}

