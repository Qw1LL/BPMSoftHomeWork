 namespace BPMSoft.Configuration.DaDataSuggestions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography;
	using System.Text;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Store;
	using Newtonsoft.Json;
	using BPMSoft.DaDataSuggestions;

	#region Class: DaDataSuggestionsHelper

	/// <summary>
	/// Хэлпер для получения подсказок DaData.
	/// </summary>
	public class DaDataSuggestionsHelper
	{

		#region Fields: Private

		/// <summary>
		/// Пользовательское подключение.
		/// </summary>
		private readonly UserConnection _userConnection;
		
		/// <summary>
		/// Список культур системы.
		/// </summary>
		private readonly Dictionary<Guid, string> _sysCultures;
		
		/// <summary>
		/// Код операции лицензирования.
		/// </summary>
		private const string OperationLicenseCode = "DaDataSuggestions.Use";
		
		/// <summary>
		/// Префикс ключа кэша.
		/// </summary>
		private const string CacheKeyPrefix = "DaData_";
		
		/// <summary>
		/// Суффикс ключа кэша для даты получения данных.
		/// </summary>
		private const string CacheRetrievedOnKeySuffix = "_RetrievedOn";
		
		/// <summary>
		/// Время жизни значения в кэше.
		/// </summary>
		private readonly TimeSpan CacheValueLifetime = new TimeSpan(4, 0, 0);

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Конструктор. 
		/// </summary>
		/// <param name="userConnection">Пользовательское подключение</param>
		public DaDataSuggestionsHelper(UserConnection userConnection) 
		{
			_userConnection = userConnection;
			
			_userConnection.LicHelper.CheckHasOperationLicense(OperationLicenseCode);
			
			_sysCultures = Core.Configuration.SysCulture.GetSysCultures(_userConnection);
		}

		#endregion
			
		#region Methods: Private
			
		/// <summary>
		/// Вычисляет SHA256-хэш строки.
		/// </summary>
		/// <param name="value">Строка для вычисления хэша</param>
		/// <returns>SHA256-хэш в виде строки</returns>
		private string ComputeSha256Hash(string value)
		{
			using (var sha256 = SHA256.Create())
			{
				return BitConverter.ToString(
					sha256.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
			}
		}
			
		#endregion

		#region Methods: Public
		
		/// <summary>
		/// Возвращает Id элемента справочника.
		/// </summary>
		/// <param name="schemaName">Название таблицы справочника</param>
		/// <param name="parameterColumnName">Имя колонки-параметра</param>
		/// <param name="parameterValue">Значение колонки-параметра</param>
		/// <param name="comparisonType">Тип сравнения параметров в фильтре</param>
		/// <returns>Id элемента справочника</returns>
		public Guid GetLookupId(string schemaName, string parameterColumnName, string parameterValue,
								FilterComparisonType comparisonType = FilterComparisonType.Equal)
		{
			if (string.IsNullOrEmpty(schemaName))
			{
				throw new ArgumentNullException(nameof(schemaName));
			}
			
			if (string.IsNullOrEmpty(parameterColumnName))
			{
				throw new ArgumentNullException(nameof(parameterColumnName));
			}
			
			if (string.IsNullOrEmpty(parameterValue))
			{
				throw new ArgumentNullException(nameof(parameterValue));
			}
			
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, schemaName);
			esq.UseAdminRights = false;
			esq.UseRecordDeactivation = true;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			
			var cultureId = _sysCultures.FirstOrDefault(pair => pair.Value == "ru-RU").Key;
			esq.SetLocalizationCultureId(cultureId); // Устанавливаем культуру "ru-RU", 
													 // так как значения из DaData приходят только на русском .
			
			var createdOn = esq.AddColumn("CreatedOn");
			createdOn.OrderDirection = OrderDirection.Ascending; // Выбираем самую раннюю по дате создания запись.
			
			esq.Filters.Add(
				esq.CreateFilterWithParameters(comparisonType, parameterColumnName, parameterValue));
				
			var entity = esq.GetEntityCollection(_userConnection).FirstOrDefault();
			if (entity != null) 
			{
				return entity.PrimaryColumnValue;
			}
			
			return Guid.Empty;
		}
		
		/// <summary>
		/// Возвращает значение элемента справочника.
		/// </summary>
		/// <param name="schemaName">Название таблицы справочника</param>
		/// <param name="id">Id записи справочника</param>
		/// <param name="resultColumnName">Имя колонки-результата</param>
		/// <returns>Значение элемента справочника</returns>
		public object GetLookupValueById(string schemaName, Guid id, string resultColumnName)
        {
			if (string.IsNullOrEmpty(schemaName))
			{
				throw new ArgumentNullException(nameof(schemaName));
			}
			
			if (id == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(id));
			}
			
			if (string.IsNullOrEmpty(resultColumnName))
			{
				throw new ArgumentNullException(nameof(resultColumnName));
			}
			
			var select = new Select(_userConnection)
				.Column(resultColumnName)
				.From(schemaName)
				.Where("Id").IsEqual(Column.Parameter(id)) as Select;
			
			return select?.ExecuteScalar<object>();
		}

		/// <summary>
		/// Достает ответ сервиса подсказок из кэша.
		/// </summary>
		/// <param name="query">Текст запроса</param>
		/// <returns>Объект ответа либо null при его отсутствии/устаревании</returns>
		public T GetCachedSuggestionsResponse<T>(string query)
			where T : DaDataSuggestionsResponse
		{
			if (string.IsNullOrEmpty(query))
			{
				return null;
			}
				
			var key = CacheKeyPrefix + ComputeSha256Hash(query.ToLower());
			var retrievedOnKey = key + CacheRetrievedOnKeySuffix;
				
			var retrievedOn = _userConnection.ApplicationCache[retrievedOnKey];
				
			if (retrievedOn == null || 
					DateTime.UtcNow.Subtract((DateTime)retrievedOn) > CacheValueLifetime)
			{
				_userConnection.ApplicationCache.Remove(key);
				_userConnection.ApplicationCache.Remove(retrievedOnKey);
					
				return null;
			}
				
			var cachedValue = _userConnection.ApplicationCache[key] as string;
			
			if (string.IsNullOrEmpty(cachedValue))
			{
				_userConnection.ApplicationCache.Remove(retrievedOnKey);
				
				return null;
			}
			
			try
			{
				return JsonConvert.DeserializeObject<T>(cachedValue);
			}
			catch (JsonException e)
			{
				return null;
			}
		}
		
		/// <summary>
		/// Записывает ответ сервиса подсказок в кэш.
		/// </summary>
		/// <param name="response">Объект ответа</param>
		/// <param name="query">Текст запроса</param>
		public void SetCachedSuggestionsResponse<T>(T response, string query)
			where T : DaDataSuggestionsResponse
		{
			if (response == null ||
			   string.IsNullOrEmpty(query))
			{
				return;
			}
			
			var key = CacheKeyPrefix + ComputeSha256Hash(query.ToLower());
			var retrievedOnKey = key + CacheRetrievedOnKeySuffix;
				
			_userConnection.ApplicationCache[key] = response.FullJson;
			_userConnection.ApplicationCache[retrievedOnKey] = DateTime.UtcNow;
		}
		
		#endregion

	}

	#endregion

}


