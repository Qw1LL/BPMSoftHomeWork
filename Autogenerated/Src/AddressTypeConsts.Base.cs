using System;

namespace BPMSoft.Configuration
{
	public static class AddressTypeConsts
	{
		// Address type - Work
		public static readonly Guid WorkId = new Guid("780bf68c-4b6e-df11-b988-001d60e938c6");

		// Address type - home
		public static readonly Guid HomeId = new Guid("4f8b2d67-71d0-45fb-897e-cd4a308a97c0");

		// Address type - Legal
		public static readonly Guid LegalId = new Guid("770bf68c-4b6e-df11-b988-001d60e938c6");

		// Address type - Shipping
		public static readonly Guid ShippingId = new Guid("760bf68c-4b6e-df11-b988-001d60e938c6");

		// Address type - Business
		public static readonly Guid BusinessId = new Guid("fb7a3f6a-f36b-1410-6f81-1c6f65e50343");
		
		// Address type - Other
		public static readonly Guid OtherId = new Guid("ce157f11-f425-4811-ba0e-e3816e8eced5");
	}
}

