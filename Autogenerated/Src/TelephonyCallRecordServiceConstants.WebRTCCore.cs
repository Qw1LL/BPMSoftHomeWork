using System;

namespace BPMSoft.Configuration.TelephonyCallRecordService
{
	 /// <summary>
    /// Тип авторизации.
    /// </summary>
    public static class AuthType
    {
		/// <summary>
    	/// Базовая.
    	/// </summary>
        public const string Basic = "9E40A097-3DF7-49FC-A04E-BD9368760D1C";
		
		/// <summary>
    	/// Токен.
    	/// </summary>
        public const string Token = "84C17DB6-BEF3-4A8F-8EED-B2D2ED7B5D50";
    }

	/// <summary>
    /// Библиотеки интеграции.
    /// </summary>
    public static class IntegrationLibraryIdentificator
    {
		/// <summary>
    	/// Интеграция с Uis.
    	/// </summary>
        public static readonly Guid UIS = new Guid("624ACD68-C073-4C30-B13A-3E32E85F5F30");
    }

    /// <summary>
    /// Направление звонка.
    /// </summary>
    public static class CallDirection
	{
        /// <summary>
        /// Входящий.
        /// </summary>
        public const string Incoming = "1D96A65F-2131-4916-8825-2D142B1000B2";

        /// <summary>
        /// Исходящий.
        /// </summary>
        public const string Outgoing = "53F71B5F-7E17-4CF5-BF14-6A59212DB422";

        /// <summary>
        /// Неизвестно.
        /// </summary>
        public const string NotDetermined = "C072BE2C-3D82-4468-9D4A-6DB47D1F4CCA";
    }
}
