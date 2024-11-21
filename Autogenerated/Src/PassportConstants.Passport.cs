using System;

namespace BPMSoft.Configuration
{
	public static class PassportConstants
	{
		/// <summary>
		/// ### ######## #### ####### ######## # ##### - ######## ## #####.
		/// </summary>
		public static readonly Guid SupplyPaymentDelayFromFact = new Guid("EEADA309-2CE7-413C-8B66-E984242A4D22");

		/// <summary>
		/// ### ######## #### ####### ######## # ##### -  ######## ## #####.
		/// </summary>
		public static readonly Guid SupplyPaymentDelayFromPlan = new Guid("6FC58059-9C4A-4481-8775-BBADF4A4AD51");

		/// <summary>
		/// ######### #### ####### ######## # ##### - ########.
		/// </summary>
		public static readonly Guid SupplyPaymentStateFinished = new Guid("E9EB323C-B1ED-4B4B-8DD9-414AD95075D3");

		/// <summary>
		/// ######### #### ####### ######## # ##### - ## ########.
		/// </summary>
		public static readonly Guid SupplyPaymentStateNotFinished = new Guid("B801EDD0-33F8-45ED-AEE8-2E26307B0456");

		/// <summary>
		/// ### #### ####### ######## # ##### - ######.
		/// </summary>
		public static readonly Guid SupplyPaymentTypePayment = new Guid("D868F4B7-4946-4BB1-94BB-6FB93A513CE4");

		/// <summary>
		/// ######### ###### ##### - #######.
		/// </summary>
		public static readonly Guid InvoicePaymentStatusCanceled = new Guid("3fb932ea-f36b-1410-2691-00155d043205");

		/// <summary>
		/// ######### ###### ##### - ####### ########.
		/// </summary>
		public static readonly Guid InvoicePaymentStatusPartiallyPaid = new Guid("03794bf5-52e6-df11-971b-001d60e938c6");

		/// <summary>
		/// ######### ###### ##### - #######.
		/// </summary>
		public static readonly Guid InvoicePaymentStatusPaid = new Guid("698d39fd-52e6-df11-971b-001d60e938c6");
	}
}

