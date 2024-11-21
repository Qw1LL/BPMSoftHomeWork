namespace BPMSoft.Configuration.DynamicContent.Models
{
	using System.Collections.Generic;
	using System.Linq;

	#region Class : DCTemplateModelExtensions

	/// <summary>
	/// Contains extension methods for template manipulation.
	/// </summary>
	public static class DCTemplateModelExtensions
	{

		#region Methods: Public

		/// <summary>
		/// Returns sorted list of replicas from current <paramref name="template"/>.
		/// </summary>
		/// <param name="template">Dynamic content template.</param>
		/// <returns>Sorted by priority replicas collection. Participants will be segment in this order.</returns>
		public static List<DCReplicaModel> GetSortedReplicasByPriority(this DCTemplateModel template) =>
			template.Replicas
				.Select(x => new {
					Replica = x,
					BlockIndexesLength = x.BlockIndexes.Length,
					BlocksPrioritySum = template.Blocks.Where(b => x.BlockIndexes.Contains(b.Index)).Sum(b => b.Priority)
				})
				.OrderByDescending(g => g.Replica.BlockIndexes.Length)
				.ThenBy(o => o.BlocksPrioritySum)
				.ThenBy(o => o.Replica.Mask)
				.Select(x => x.Replica)
				.ToList();

		#endregion

	}

	#endregion

}
