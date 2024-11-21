namespace BPMSoft.Configuration.DynamicContent
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.DynamicContent.Models;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: DCResolverTemplateValidator

	/// <summary>
	/// Validates <see cref="DCTemplateModel"/> for segmentation process.
	/// </summary>
	public class DCResolverTemplateValidator
	{

		#region Methods: Private

		private List<Select> GetFilters(DCTemplateModel template, UserConnection userConnection) =>
			template?.Attributes?.Where(x => x.IsFilter())
				.Select(x => x.ToFilter(userConnection)).ToList();

		private void ValidateSqlFilters(DCTemplateModel template, UserConnection userConnection) {
			var selects = GetFilters(template, userConnection);
			if (!selects.Any()) {
				return;
			}
			if (selects.Select(x => x.SourceExpression.Alias).Distinct().Count() > 1) {
				var message = new LocalizableString(userConnection.Workspace.ResourceStorage,
					"DCResolverTemplateValidator", "LocalizableStrings.HasDifferentAliasesExceptionText.Value").Value;
				throw new InvalidQueryStructureException(message);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Validates <paramref name="template"/> for dynamic content processing.
		/// </summary>
		/// <param name="template">Template for validate.</param>
		/// <param name="userConnection">An instance of the <see cref="Core.UserConnection"/>.</param>
		/// <exception cref="InvalidQueryStructureException">Throws when at least two selects 
		/// have different source alias.</exception>
		public void Validate(DCTemplateModel template, UserConnection userConnection) {
			ValidateSqlFilters(template, userConnection);
		}

		#endregion

	}


	#endregion

}
