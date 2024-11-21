namespace BPMSoft.Configuration {

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Entities.Events;

	#region Class: ProductDuplicateMergeEventListener

	[EntityEventListener(SchemaName = "Product")]
	public class ProductDuplicateMergeEventListener : BaseEntityEventListener {

		#region Constants: Private

		private const int DefaultPrecision = 2;

		#endregion

		#region Methods: Private

		private void DeleteEntities(IEnumerable<Entity> redundantPrices, UserConnection userConnection) {
			foreach (Entity entityToDelete in redundantPrices) {
				var entity = entityToDelete.Schema.CreateEntity(userConnection);
				entity.FetchPrimaryColumnFromDB(entityToDelete.PrimaryColumnValue);
				entity.Delete();
			}
		}

		private Entity FindBasePrice(EntityCollection basePrices, Entity productEntity) {
			int precision = GetPricePrecision(productEntity);
			var price = GetPrice(productEntity, precision);
			return basePrices.FirstOrDefault(p => GetPrice(p, precision) == price);
		}

		private Entity FindBaseUnit(EntityCollection baseUnits, Entity productEntity) {
			var productUnitId = productEntity.GetTypedColumnValue<Guid>("UnitId");
			return baseUnits.FirstOrDefault(u => u.GetTypedColumnValue<Guid>("UnitId").Equals(productUnitId));
		}

		private EntityCollection GetBasePrices(UserConnection userConnection, Entity entity) {
			Core.Configuration.SysSettings.TryGetValue(userConnection, "BasePriceList", 
				out var basePriceListId);
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "ProductPrice");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Price");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"Product", entity.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, 
				"PriceList", basePriceListId));
			var basePrices = esq.GetEntityCollection(userConnection);
			return basePrices;
		}

		private EntityCollection GetBaseUnits(UserConnection userConnection, Entity productEntity) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "ProductUnit");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Unit");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Product",
				productEntity.PrimaryColumnValue));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsBase", true));
			var baseUnits = esq.GetEntityCollection(userConnection);
			return baseUnits;
		}

		private double GetPrice(Entity productEntity, int precision) {
			return Math.Round(productEntity.GetTypedColumnValue<double>("Price"), precision);
		}

		private int GetPricePrecision(Entity productEntity) {
			var valueColumnType = productEntity.Schema.Columns.FindByName("Price").DataValueType as FloatDataValueType;
			return valueColumnType?.Precision ?? DefaultPrecision;
		}

		private void HandleEntitiesMerge(UserConnection userConnection, Entity productEntity, 
				Func<UserConnection, Entity, EntityCollection> getBaseEntitiesFunc,
				Func<EntityCollection, Entity, Entity> findBaseEntityFn) {
			EntityCollection baseEntities = getBaseEntitiesFunc(userConnection, productEntity);
			bool isMoreThanOneBaseRecord = baseEntities.Count > 1;
			if (isMoreThanOneBaseRecord) {
				var baseEntity = findBaseEntityFn(baseEntities, productEntity);
				if (baseEntity == null) {
					return;
				}
				var redundantEntities = baseEntities.Where(p => !p.PrimaryColumnValue.Equals(baseEntity.PrimaryColumnValue));
				DeleteEntities(redundantEntities, userConnection);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdating"/>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			base.OnUpdating(sender, e);
			var productEntity  = (Entity)sender;
			UserConnection userConnection = productEntity.UserConnection;
			HandleEntitiesMerge(userConnection, productEntity, GetBasePrices, FindBasePrice);
			HandleEntitiesMerge(userConnection, productEntity, GetBaseUnits, FindBaseUnit);
		}

		#endregion

	}

	#endregion

}
