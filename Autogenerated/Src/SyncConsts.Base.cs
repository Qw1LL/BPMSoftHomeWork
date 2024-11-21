using System;

namespace BPMSoft.Configuration
{
	public class SyncConsts 
	{
		//######## ############# # LDAP
		public static readonly Guid LdapSyncOperationId = new Guid("C43A35BC-33FA-4D60-91CE-CBD2592D2748");	
		
		//
		public static readonly Guid LdapUserServiceImportOperationId = new Guid("D7BDD8B6-5F3A-46FC-A24C-4F2F79340CE7");
		
		//########### ######
		public static readonly Guid LdapImportDirection = new Guid("A3F528A7-8A23-4435-8E3F-B2B84DF4EA3E");	
		
		//######### - #######
		public static readonly Guid LdapSuccessResult = new Guid("FE955C66-E90E-4ADC-BDFA-3603FF77AE4C");
		
		//######### - #######
		public static readonly Guid LdapErrorResult = new Guid("D62F29E2-A456-48D1-9E36-B01DA3C2ACDD");
		
		//####### - LDAP
		public static readonly Guid LdapSystem = new Guid("806806D5-CCE8-45C7-8D21-D6544DF896CF");
		
	}
}
