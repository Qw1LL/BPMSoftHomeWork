using System;
using System.Collections.Generic;

namespace BPMSoft.Configuration.OrderPackage
{
	public static class Constants
	{
		public static class Order
		{
			
			/// <summary>
			// Order in progress status.
			/// </summary>
			public static readonly Guid OrderInProgressStatusId = new Guid("C8742634-EA8B-46D9-BA71-1989B951772D");
			
			/// <summary>
			// Order draf status.
			/// </summary>
			public static readonly Guid OrderDraftStatusId = new Guid("1f3ad326-effd-4ac3-a3e2-957e7def3684");
			
			/// <summary>
			// Order confirmation status.
			/// </summary>
			public static readonly Guid OrderConfirmationStatusId = new Guid("29fa66e3-ef69-4feb-a5af-ec1de125a614");
			
			/// <summary>
			// Partially paid.
			/// </summary>
			public static readonly Guid PartiallyPaid = new Guid("7D4959D3-0B8F-403C-A345-3FBCE926013E");

            /// <summary>
            /// Canceled
            /// </summary>
            public static readonly Guid Canceled = new Guid("8AB0F830-908B-40D7-80A3-7F49EF70CE70");

            /// <summary>
            /// Completed
            /// </summary>
            public static readonly Guid Completed = new Guid("40DE86EE-274D-4098-9B92-9EBDCF83D4FC");

            /// <summary>
            /// Status positions
            /// </summary>
		    public static readonly Dictionary<Guid, int> StatusPosition = new Dictionary<Guid, int> {
                { OrderDraftStatusId, 1 },
                { OrderConfirmationStatusId, 2 },
                { OrderInProgressStatusId, 3 },
                { PartiallyPaid, 4 },
                { Completed, 5 },
                { Canceled, 6 }
		    };

            /// <summary>
            // ######### ###### #####.
            /// </summary>
            public static class OrderPaymentStatus
			{
				/// <summary>
				/// ####### #########.
				/// </summary>
				public static Guid Paid {
					get {
						return new Guid("4721338e-a5f1-4529-96be-d3f311518812");
					}
				}
				/// <summary>
				/// ####### ########.
				/// </summary>
				public static Guid PartiallyPaid {
					get {
						return new Guid("a2f17c7b-956b-47c8-9ea5-b545b74a26f6");
					}
				}
			}
		}
	}
}

