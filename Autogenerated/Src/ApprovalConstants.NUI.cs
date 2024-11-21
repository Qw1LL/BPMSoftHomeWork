namespace BPMSoft.Configuration
{
    using System;

    #region Class: ApprovalConstants

    /// <summary>
    /// Approval Constants
    /// </summary>
    public static class ApprovalConstants
    {

        #region Properties: Public

        /// <summary>
        /// Waiting Status.
        /// </summary>
        public static Guid Waiting => new Guid("3462594d-77a7-4b0a-874a-6d8b54b293bc");

        /// <summary>
        /// Accepted Status.
        /// </summary>
        public static Guid Accepted => new Guid("e79facb3-3c32-43e7-a59e-12ba125e6132");

        /// <summary>
        /// Rejected Status.
        /// </summary>
        public static Guid Rejected => new Guid("a93ab0b9-ca36-4b95-9b23-e01aa169c338");

	    /// <summary>
	    /// Caceled Status.
	    /// </summary>
	    public static Guid Canceled => new Guid("9120fdef-69be-4168-b5f3-517714b7a4e9");

		#endregion
	}

	#endregion

}
