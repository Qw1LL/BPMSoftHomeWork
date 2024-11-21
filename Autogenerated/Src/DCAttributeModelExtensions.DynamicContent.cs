namespace BPMSoft.Configuration.DynamicContent.Models
{
	using BPMSoft.Common;
	using BPMSoft.Common.Json;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Nui.ServiceModel.Extensions;

	#region Class: DCAttributeModelExtensions

	/// <summary>
	/// Extensions for <see cref="DCAttributeModel"/> object.
	/// </summary>
	public static class DCAttributeModelExtensions
	{

		#region Methods: Public

		/// <summary>
		/// Determines whether the attribute is a filter.
		/// </summary>
		/// <param name="model">Extensible model object.</param>
		/// <returns>Returns true when <paramref name="model"/> has type 
		/// <see cref="DCConstants.DCAttributeFilterTypeId"/>. And false in otherwise.</returns>
		public static bool IsFilter(this DCAttributeModel model) {
			model.CheckArgumentNull(nameof(model));
			return model.TypeId == DCConstants.DCAttributeFilterTypeId;
		}

		/// <summary>
		/// Converts attribute model with type <see cref="DCConstants.DCAttributeFilterTypeId"/> to <see cref="Select"/>.
		/// </summary>
		/// <param name="model">Extensible model object.</param>
		/// <param name="userConnection">User connection.</param>
		/// <returns>Converted <see cref="Select"/> object when attribute is filter and value is correct 
		/// search data string. And null in othervise.</returns>
		public static Select ToFilter(this DCAttributeModel model, UserConnection userConnection) {
			model.CheckArgumentNull(nameof(model));
			userConnection.CheckArgumentNull(nameof(userConnection));
			if (!model.IsFilter()) {
				return null;
			}
			var dataSourceFilters = Json.Deserialize<Nui.ServiceModel.DataContract.Filters>(model.Value);
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, dataSourceFilters.RootSchemaName);
			esq.AddColumn(esq.RootSchema.GetPrimaryColumnName());
			IEntitySchemaQueryFilterItem filters = dataSourceFilters.BuildEsqFilter(esq.RootSchema.UId, userConnection);
			CommonUtilities.DisableEmptyEntitySchemaQueryFilters(new[] { filters });
			if (filters != null) {
				esq.Filters.Add(filters);
			}
			esq.UseAdminRights = false;
			return esq.GetSelectQuery(userConnection);
		}

		#endregion

	}

	#endregion

}
