namespace BPMSoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Web;
	using BPMSoft.Core;
	using Newtonsoft.Json;
	using System.Runtime.Serialization;
	using BPMSoft.Core.DB;
	using System.Data;
	using Common;
	using Core.Entities;


	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class PartnerManagerService
	{
		#region Class: PartnerManagerResponse

		[Serializable]
		[DataContract]
		public class PartnerManagerResponse
		{
			#region Properties: Public

			[DataMember(Name = "PhotoId")]
			public Guid PhotoId {
				get;
				set;
			}

			[DataMember(Name = "Email")]
			public string Email {
				get;
				set;
			}

			[DataMember(Name = "Name")]
			public string Name {
				get;
				set;
			}

			#endregion

			#region Constructor: Public


			/// <summary>
			/// Initializes a new instance of the <see cref="PartnerManagerResponse"/> class.
			/// </summary>
			public PartnerManagerResponse() {
				PhotoId = default(Guid);
			}

			#endregion
		}

		#endregion

		#region Properties: Private

		private UserConnection _userConnection;

		/// <summary>
		/// User connection.
		/// </summary>
		private UserConnection UserConnection {
			get {
				return _userConnection ??
					(_userConnection = (UserConnection)HttpContext.Current.Session["UserConnection"]);
			}
		}

		#endregion

		#region Methods: Private

		private PartnerManagerResponse GetImageId(Guid partnershipId) {
			PartnerManagerResponse partnerManager = new PartnerManagerResponse();
			if (partnershipId == default(Guid)) {
				return partnerManager;
			}
			Select query = new Select(UserConnection)
				.Column("C", "PhotoId")
				.Column("C", "Email")
				.Column("C", "Name")
				.From("Account").As("A")
				.Join(JoinType.Inner, "Contact").As("C")
					.On("C", "Id").IsEqual("A", "OwnerId")
				.Join(JoinType.Inner, "Partnership").As("P")
					.On("P", "AccountId").IsEqual("A", "Id")
				.Where("P", "Id").IsEqual(Column.Parameter(partnershipId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = query.ExecuteReader(dbExecutor)) {
					reader.Read();
					partnerManager.PhotoId = reader.GetColumnValue<Guid>("PhotoId");
					partnerManager.Email = reader.GetColumnValue<string>("Email");
					partnerManager.Name = reader.GetColumnValue<string>("Name");
				}
			}
			return partnerManager;
		}

		private Guid GetPartnershipId() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Partnership");
			string idColumnName = esq.AddColumn("Id").Name;
			EntityCollection entityCollection = esq.GetEntityCollection(UserConnection);
			Guid partnershipId = default(Guid);
			if (entityCollection.IsNotEmpty()) {
				var entity = entityCollection[0];
				partnershipId = entity.GetTypedColumnValue<Guid>(idColumnName);
			}
			return partnershipId;
		}
		#endregion

		#region Methods: Public

		/// <summary>
		/// Get managers data.
		/// </summary>
		/// <returns>An object that contains the photoId time and email.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
			ResponseFormat = WebMessageFormat.Json)]
		public PartnerManagerResponse GetManagerData() {
			Guid partnershipId = GetPartnershipId();
			PartnerManagerResponse response = GetImageId(partnershipId);
			return response;
		}

		#endregion
	}
}
