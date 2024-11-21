namespace BPMSoft.Configuration.DynamicContent
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: DCSelectBuilder

	/// <summary>
	/// Builds <see cref="Select"/> for given parameters.
	/// </summary>
	public class DCSelectBuilder
	{

		#region Methods: Private

		private void Append(ref Select mainSelect, Select attachedSelect) {
			if (!attachedSelect.HasCondition) {
				return;
			}
			var clonedAttachedSelect = attachedSelect.Clone() as Select;
			if (!mainSelect.HasCondition) {
				mainSelect.Where();
			} else {
				mainSelect.And();
			}
			var queryCondition = mainSelect.Condition.Last().OpenBlock();
			queryCondition.AddRange(clonedAttachedSelect.Condition);
			mainSelect.CloseBlock();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Appends all <see cref="Select"/> objects from <paramref name="selects"/>.
		/// </summary>
		/// <param name="selects">List of the appended selects.</param>
		/// <returns>New <see cref="Select"/> instance containing all conditions from input selects.</returns>
		public Select Append(List<Select> selects) {
			Select result = selects.First().Clone() as Select;
			for (int i = 1; i < selects.Count; i++) {
				Append(ref result, selects[i]);
			}
			return result;
		}

		#endregion

	}


	#endregion

}
