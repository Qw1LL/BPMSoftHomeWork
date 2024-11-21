namespace BPMSoft.Configuration.DynamicContent.Models
{
	using System;
	using BPMSoft.Configuration.DynamicContent.DataContract;

	#region Class: DCAttributeModel

	/// <summary>
	/// Class to represent data model for <see cref="DCAttribute"/> entity.
	/// </summary>
	public class DCAttributeModel
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
		/// Attribute's caption.
		/// </summary>
		public string Caption { get; set; }

		/// <summary>
		/// Unique identifier of attribute type.
		/// </summary>
		public Guid TypeId { get; set; }

		/// <summary>
		/// Unique index within the template.
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// Specific value of current attribute.
		/// </summary>
		public string Value { get; set; }

		#endregion

		#region Methods: Public

		/// <summary>
		/// Overrides explicit converting to <see cref="DCAttributeContract"/> type.
		/// Converts null to null.
		/// </summary>
		/// <param name="model">Template model object which converted.</param>
		public static explicit operator DCAttributeContract(DCAttributeModel model) =>
			model != null
				? new DCAttributeContract {
					Id = model.Id,
					Caption = model.Caption,
					TypeId = model.TypeId,
					Index = model.Index,
					Value = model.Value
				}
				: null;

		#endregion

	}

	#endregion

}

