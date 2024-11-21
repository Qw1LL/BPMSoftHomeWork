namespace BPMSoft.Configuration.ESN {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Common;
	using Core;
	using Core.Entities;
	using Core.Factories;

	#region Interface: IEsnLikeRepository

	public interface IEsnLikeRepository {
	
		/// <summary>
		/// Create user's like for message.
		/// </summary>
		/// <param name="userId">User id that will used for create like.</param>
		/// <param name="messageId">Message id that will used for create like.</param>
		/// <returns>Value of created like.</returns>
		Guid AddLike(Guid userId, Guid messageId);

		/// <summary>
		/// Delete user's like for message.
		/// </summary>
		/// <param name="userId">User id that will used for delete like.</param>
		/// <param name="messageId">Message id that will used for delete like.</param>
		/// <returns>Value of created like.</returns>
		bool DeleteLike(Guid userId, Guid messageId);

		/// <summary>
		/// Returns messages likes for user.
		/// </summary>
		/// <param name="userId">User's id that will be used to filter likes.</param>
		/// <param name="messageIds">List of messages' id that will be used to filter likes.</param>
		/// <returns><see cref="BPMSoft.Core.Entities.Entity"/>instance collection.</returns>
		IEnumerable<Entity> GetUserLikesByMessages(Guid userId,
			IEnumerable<Guid> messageIds);

		/// <summary>
		/// Returns user's likes for message.
		/// </summary>
		/// <param name="messageId">Message id that will be used to filter likes.</param>
		/// <returns><see cref="BPMSoft.Core.Entities.Entity"/>instance collection.</returns>
		IEnumerable<Entity> GetWhoLikedMessage(Guid messageId);
	}

	#endregion

	#region Class: EsnLikeRepository

	/// <summary>
	/// Provides api for operation in database for <see cref="BPMSoft.Configuration.SocialLike" />
	/// </summary>
	/// <inheritdoc />
	[DefaultBinding(typeof(IEsnLikeRepository))]
	public class EsnLikeRepository : IEsnLikeRepository {

		#region Constants: Private

		private const string EsnLikeEntitySchemaName = "SocialLike";
		private readonly UserConnection _userConnection;

		#endregion

		public EsnLikeRepository(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#region Methods: Private

		private Entity Find(Guid userId, Guid messageId) {
			var esnLikeSchema = GetEsnLikeSchema();
			var esnLike = esnLikeSchema.CreateEntity(_userConnection);
			var conditions = new Dictionary<string, object> {
				{ "User", userId },
				{ "SocialMessage", messageId }
			};
			return esnLike.FetchFromDB(conditions, false) ? esnLike : null;
		}

		private EntitySchema GetEsnLikeSchema() => _userConnection.EntitySchemaManager.GetInstanceByName(EsnLikeEntitySchemaName);

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Add column to like query.
		/// </summary>
		/// <param name="likeQuery">Instance <see cref="BPMSoft.Core.Entities.EntitySchemaQuery"/></param>
		protected virtual void AddLikeQueryColumns(EntitySchemaQuery likeQuery) {
			likeQuery.PrimaryQueryColumn.IsAlwaysSelect = true;
			likeQuery.AddColumn("User");
			likeQuery.AddColumn("SocialMessage");
			likeQuery.AddColumn("CreatedBy");
		}

		/// <summary>
		/// Add filter by user id and messages for like query.
		/// </summary>
		/// <param name="likeQuery">Instance <see cref="BPMSoft.Core.Entities.EntitySchemaQuery"/></param>
		/// <param name="messageId">Message id that will added to filter.</param>
		protected virtual void AddLikeQueryFilters(EntitySchemaQuery likeQuery, Guid messageId) {
			likeQuery.Filters.Add(
				likeQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"SocialMessage",
					messageId
				)
			);
		}

		/// <summary>
		/// Add filter by user id and messages for like query.
		/// </summary>
		/// <param name="likeQuery">Instance <see cref="BPMSoft.Core.Entities.EntitySchemaQuery"/></param>
		/// <param name="userId">User id that will added to filter.</param>
		/// <param name="messageIds">Message ids that will added to filter.</param>
		protected virtual void AddLikeQueryFilters(EntitySchemaQuery likeQuery, Guid userId, IEnumerable<Guid> messageIds) {
			likeQuery.Filters.Add(
				likeQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"User",
					userId
				)
			);
			likeQuery.Filters.Add(
				likeQuery.CreateFilterWithParameters(
					FilterComparisonType.Equal,
					"SocialMessage",
					messageIds.Cast<object>().ToArray()
				)
			);
		}

		/// <summary>
		/// Sets column values for new like.
		/// </summary>
		/// <param name="likeEntity">Instance of <see cref="BPMSoft.Core.Entities.Entity"/></param>
		/// <param name="columnValues">Map column names and values</param>
		protected virtual void SetNewLikeColumnValues(Entity likeEntity, Dictionary<string, object> columnValues) {
			foreach (var columnValue in columnValues) {
				likeEntity.SetColumnValue(columnValue.Key, columnValue.Value);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public Guid AddLike(Guid userId, Guid messageId) {
			userId.CheckArgumentEmpty(nameof(userId));
			messageId.CheckArgumentEmpty(nameof(messageId));
			var likeEntity = Find(userId, messageId);
			if (likeEntity != null) {
				throw new ItemAlreadyExistException();
			}

			var esnLikeSchema = GetEsnLikeSchema();
			likeEntity = esnLikeSchema.CreateEntity(_userConnection);
			likeEntity.SetDefColumnValues();
			var columnValues = new Dictionary<string, object>() {
				{"SocialMessageId", messageId },
				{ "UserId", userId }
			};

			SetNewLikeColumnValues(likeEntity, columnValues);
			likeEntity.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
			likeEntity.Save(setColumnDefValue: false);
			return likeEntity.PrimaryColumnValue;
		}

		/// <inheritdoc />
		public bool DeleteLike(Guid userId, Guid messageId) {
			userId.CheckArgumentEmpty(nameof(userId));
			messageId.CheckArgumentEmpty(nameof(messageId));
			var likeEntity = Find(userId, messageId);
			if (likeEntity == null) {
				throw new ItemNotFoundException();
			}
			return likeEntity.Delete();
		}

		/// <inheritdoc />
		public IEnumerable<Entity> GetUserLikesByMessages(Guid userId,
			IEnumerable<Guid> messageIds) {
			userId.CheckArgumentEmpty(nameof(userId));
			messageIds.CheckArgumentNull(nameof(messageIds));
			var esnLikeSchema = GetEsnLikeSchema();
			var likeQuery = new EntitySchemaQuery(esnLikeSchema);
			AddLikeQueryColumns(likeQuery);
			AddLikeQueryFilters(likeQuery, userId, messageIds);
			likeQuery.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
			return likeQuery
					.GetEntityCollection(_userConnection);
		}

		/// <inheritdoc />
		public IEnumerable<Entity> GetWhoLikedMessage(Guid messageId) {
			messageId.CheckArgumentEmpty(nameof(messageId));
			var esnLikeSchema = GetEsnLikeSchema();
			var likeQuery = new EntitySchemaQuery(esnLikeSchema);
			AddLikeQueryColumns(likeQuery);
			AddLikeQueryFilters(likeQuery, messageId);
			likeQuery.UseAdminRights = GlobalAppSettings.FeatureUseAdminRightsInEmbeddedLogic;
			return likeQuery
					.GetEntityCollection(_userConnection);
		}

		#endregion
	}

	#endregion
}

