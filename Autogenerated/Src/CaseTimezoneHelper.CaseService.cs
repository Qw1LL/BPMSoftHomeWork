namespace BPMSoft.Configuration
{
    using System;
    using System.Data;
    using BPMSoft.Common;
    using BPMSoft.Core;
    using BPMSoft.Core.DB;

    /// <summary>
    /// Case time zone service.
    /// </summary>
    public static class CaseTimezoneHelper
    {

		#region Methods: Private

		/// <summary>
		/// Check is empty time zone.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="contactId">Contact identifier.</param>
		/// <returns>Is time zone empty.</returns>
		[Obsolete("7.15.3 | Method is deprecated, use BPMSoft.Core.TimeZoneUtilities.GetUserTimeZone() instead.")]
		private static bool IsEmptyTimeZone(UserConnection userConnection, string contactId) {
            bool isTimeZoneEmpty = true;
            Select select = new Select(userConnection)
                .Column("TimeZoneId")
                .From("VwSysAdminUnit")
                .Where("ContactId")
                .IsEqual(Column.Parameter(Guid.Parse(contactId))) as Select;
            using (var dbExecutor = userConnection.EnsureDBConnection()) {
                using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
                    if (reader.Read()) {
                        isTimeZoneEmpty = reader.GetColumnValue<string>("TimeZoneId") == null ? true : false;
                    }
                }
            }
            return isTimeZoneEmpty;
        }

        #endregion

        #region Methods: Public

        /// <summary>
        /// Get contact time zone.
        /// </summary>
        /// <param name="userConnection">User connection.</param>
        /// <param name="contactId">Contact identifier.</param>
        /// <returns>Contact time zone.</returns>
        public static string GetContactTimezone(UserConnection userConnection, string contactId) {
			return userConnection.CurrentUser.GetCurrentDateTime().ToString("yyyy'-'MM'-'dd HH':'mm':'ss");
        }

        #endregion

    }
}

