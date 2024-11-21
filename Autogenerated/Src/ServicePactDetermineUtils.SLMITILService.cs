using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Entities;

namespace BPMSoft.Configuration.ServicePactService
{

	#region Class: ServicePactDetermineUtils

	/// <summary>
	/// ######### #### ### ########## ########## ######### #########.
	/// </summary>
	public class ServicePactDetermineUtils
	{
		#region Constructors: Public
		
		public ServicePactDetermineUtils() {
		}
		
		public ServicePactDetermineUtils(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private Contact _contact;
		
		private SuitableServicePactsRequest _request;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { 
			get; 
			private set; 
		}

		#endregion
		
		#region Methods: Private

		private string GetServicePactName(Guid servicePactId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServicePact");
			esq.AddColumn("Name");
			Entity entity = esq.GetEntity(UserConnection, servicePactId);
			return entity != null ? entity.GetTypedColumnValue<string>("Name") : string.Empty;
		}

		#endregion

		#region Methods: Protected

		protected virtual Contact GetContactInfo(Guid contactId) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "Contact");
			esq.AddColumn("Department");
			esq.AddColumn("Account");
			return (Contact)esq.GetEntity(UserConnection, contactId);
		}

		protected virtual IEnumerable<Entity> GetServiceObjects() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "ServiceObject");
			esq.AddAllSchemaColumns();
			IEntitySchemaQueryFilterItem isActiveFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"ServicePact.Status.IsActive", true);
			IEntitySchemaQueryFilterItem notExpiredFilter = esq.CreateFilterWithParameters(
				FilterComparisonType.GreaterOrEqual,
				"ServicePact.EndDate",
				UserConnection.CurrentUser.GetCurrentDateTime());

			var relationFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			if (_request.ContactId != Guid.Empty) {
				relationFilterGroup.Add(new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Contact", _request.ContactId),
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", 
						ServiceObjectConstants.ContactTypeId)
				});
			}

			if (_request.AccountId != Guid.Empty) {
				relationFilterGroup.Add(new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Account", _request.AccountId),
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", 
						ServiceObjectConstants.AccountTypeId)
				});
			}

			if (_contact != null && _contact.AccountId != Guid.Empty) {
				relationFilterGroup.Add(new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Account", _contact.AccountId),
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", 
						ServiceObjectConstants.AccountTypeId)
				});
			}

			if (_contact != null && _contact.AccountId != Guid.Empty && _contact.DepartmentId != Guid.Empty) {
				relationFilterGroup.Add(new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.And) {
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Department", _contact.DepartmentId),
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Account", _contact.AccountId),
					esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Type", 
						ServiceObjectConstants.DepartmentTypeId)
				});
			}

			esq.Filters.Add(isActiveFilter);
			esq.Filters.Add(notExpiredFilter);
			esq.Filters.Add(relationFilterGroup);
			return esq.GetEntityCollection(UserConnection);
		}

		protected virtual IEnumerable<SuitableServicePact> ConvertToSuitableServicePacts(
			IEnumerable<Entity> serviceObjects) {
			var resultList = new List<SuitableServicePact>();
			List<ServiceObject> serviceObjectsList = serviceObjects.Select(s => (ServiceObject)s).ToList();

			resultList.AddRange(
				serviceObjectsList.Where(o => o.TypeId == ServiceObjectConstants.ContactTypeId)
					.Select(s => s.ToSuitableServicePact(1)));
			resultList.AddRange(
				serviceObjectsList.Where(o => o.TypeId == ServiceObjectConstants.DepartmentTypeId)
					.Select(s => s.ToSuitableServicePact(2)));

			if (_contact != null && _contact.AccountId != Guid.Empty) {
				resultList.AddRange(
					serviceObjectsList.Where(o => o.AccountId == _contact.AccountId && o.TypeId == 
						ServiceObjectConstants.AccountTypeId).Select(s => s.ToSuitableServicePact(3)));
			}
			if (_request.AccountId != Guid.Empty) {
				resultList.AddRange(
					serviceObjectsList.Where(o => o.AccountId == _request.AccountId && o.TypeId == 
						ServiceObjectConstants.AccountTypeId).Select(s => s.ToSuitableServicePact(4)));
			}
			var defaultServicePactId = Guid.Empty;
			var defaultServicePact = Core.Configuration.SysSettings.GetValue(UserConnection, 
				"DefaultServicePact");
			if (defaultServicePact != null) {
				defaultServicePactId = (Guid)defaultServicePact;
			}
			if (defaultServicePactId != Guid.Empty) {
				resultList.Add(new SuitableServicePact(defaultServicePactId, GetServicePactName(defaultServicePactId), 
					5));
			}

			return resultList.Distinct();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ########## ###### ########## ######### #########. ######## ############ ## #########
		/// ######## ############ ######### ######## # ###########.
		/// </summary>
		/// <param name="request">###### ## ########### #########</param>
		/// <returns>###### ########## ######### #########</returns>
		public virtual IEnumerable<SuitableServicePact> GetSuitableServicePacts(SuitableServicePactsRequest request) {
			_request = request;
			_contact = GetContactInfo(_request.ContactId);
			return ConvertToSuitableServicePacts(GetServiceObjects());
		}

		#endregion
	}

	#endregion

	#region Class: SuitableServicePactExtenssions

	/// <summary>
	/// ############ ########## ### #######, ####### ######### # ########### ########## ######### #########.
	/// </summary>
	public static class SuitableServicePactExtenssions
	{
		#region Methods: Public

		/// <summary>
		/// ########## ###### ########### ########## ######## ## ###### ########, ######### ## ##.
		/// </summary>
		/// <param name="serviceObject">######## ######### #######</param>
		/// <param name="suitableLevel">########## ######## ######## ###### ######### #######</param>
		/// <returns>###### ########### ########## ########</returns>
		public static SuitableServicePact ToSuitableServicePact(this ServiceObject serviceObject, int suitableLevel) {
			return new SuitableServicePact(serviceObject.ServicePactId, serviceObject.ServicePactName, suitableLevel);
		}

		#endregion
	}

	#endregion
}
