namespace BPMSoft.Configuration.RelationshipDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using BPMSoft.Configuration.RightsService;
	using System.Data;

	#region Interface: IRelationshipDiagramBuilder

	public interface IRelationshipDiagramBuilder
	{
		DiagramInfo GetDiagram(Guid recordId, string schemaName);

		DiagramConfig GetDiagramConfig();

		// TODO DONT USE!!!!!!!!!!!!!!!!
		List<EntityInfo> GetEntitiesFromDiagram(Guid recordId, DiagramConfiguration diagramConfiguration);

		List<ConnectionInfo> GetDiagramConnections(IEnumerable<Guid> recordIds);

		List<Guid> GetOnlyConnectedEntities(Guid sourceRecordId, List<Guid> entities, List<ConnectionInfo> connections);
	}

	#endregion

	#region Class: RelationshipDiagramBuilder

	[DefaultBinding(typeof(IRelationshipDiagramBuilder), Name = "RelationshipDiagramBuilder")]
	public class RelationshipDiagramBuilder : IRelationshipDiagramBuilder
	{

		#region Fields: Private

		private readonly string defaultAccountImage = "data:image/svg+xml;base64,DQo8c3ZnIHdpZHRoPSc0MCcgaGVpZ2h0PSc0MCcgdmlld0JveD0nMCAwIDQwIDQwJyBmaWxsPSdub25lJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPjxyZWN0IHdpZHRoPSc0MCcgaGVpZ2h0PSc0MCcgcng9JzQnIGZpbGw9JyNGNkY2RjYnLz48cGF0aCBkPSdNMjAuOTYzOSAxMC4zMDg1QzIwLjQwNjQgOS44NDA4NyAxOS41OTM2IDkuODQwODcgMTkuMDM2IDEwLjMwODVMMTAuNzg2IDE3LjIyODNDMTAuNDQ2MyAxNy41MTMzIDEwLjI1IDE3LjkzNCAxMC4yNSAxOC4zNzc1VjI4LjI1QzEwLjI1IDI5LjA3ODQgMTAuOTIxNiAyOS43NSAxMS43NSAyOS43NUgxNC43NUMxNS41Nzg0IDI5Ljc1IDE2LjI1IDI5LjA3ODQgMTYuMjUgMjguMjVWMjQuMjQwNEMxNi4yNSAyMy40MTIgMTYuOTIxNiAyMi43NDA0IDE3Ljc1IDIyLjc0MDRIMjBIMjIuMjVDMjMuMDc4NCAyMi43NDA0IDIzLjc1IDIzLjQxMiAyMy43NSAyNC4yNDA0VjI4LjI1QzIzLjc1IDI5LjA3ODQgMjQuNDIxNiAyOS43NSAyNS4yNSAyOS43NUgyOC4yNUMyOS4wNzg0IDI5Ljc1IDI5Ljc1IDI5LjA3ODQgMjkuNzUgMjguMjVWMTguMzc3NUMyOS43NSAxNy45MzQgMjkuNTUzNyAxNy41MTMzIDI5LjIxNCAxNy4yMjgzTDIwLjk2MzkgMTAuMzA4NVonIHN0cm9rZT0nIzY3NzQ4RScgc3Ryb2tlLXdpZHRoPScyJyBzdHJva2UtbGluZWNhcD0nc3F1YXJlJyBzdHJva2UtbGluZWpvaW49J3JvdW5kJy8+PC9zdmc+DQo=";
		private readonly string defaultAccountNoAccessImage = "data:image/svg+xml;base64,DQo8c3ZnIHdpZHRoPSc0MCcgaGVpZ2h0PSc0MCcgdmlld0JveD0nMCAwIDQwIDQwJyBmaWxsPSdub25lJyB4bWxucz0naHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmcnPjxyZWN0IHdpZHRoPSc0MCcgaGVpZ2h0PSc0MCcgcng9JzQnIGZpbGw9JyNGNkY2RjYnLz48cGF0aCBkPSdNMjAuOTYzOSAxMC4zMDg1QzIwLjQwNjQgOS44NDA4NyAxOS41OTM2IDkuODQwODcgMTkuMDM2IDEwLjMwODVMMTAuNzg2IDE3LjIyODNDMTAuNDQ2MyAxNy41MTMzIDEwLjI1IDE3LjkzNCAxMC4yNSAxOC4zNzc1VjI4LjI1QzEwLjI1IDI5LjA3ODQgMTAuOTIxNiAyOS43NSAxMS43NSAyOS43NUgxNC43NUMxNS41Nzg0IDI5Ljc1IDE2LjI1IDI5LjA3ODQgMTYuMjUgMjguMjVWMjQuMjQwNEMxNi4yNSAyMy40MTIgMTYuOTIxNiAyMi43NDA0IDE3Ljc1IDIyLjc0MDRIMjBIMjIuMjVDMjMuMDc4NCAyMi43NDA0IDIzLjc1IDIzLjQxMiAyMy43NSAyNC4yNDA0VjI4LjI1QzIzLjc1IDI5LjA3ODQgMjQuNDIxNiAyOS43NSAyNS4yNSAyOS43NUgyOC4yNUMyOS4wNzg0IDI5Ljc1IDI5Ljc1IDI5LjA3ODQgMjkuNzUgMjguMjVWMTguMzc3NUMyOS43NSAxNy45MzQgMjkuNTUzNyAxNy41MTMzIDI5LjIxNCAxNy4yMjgzTDIwLjk2MzkgMTAuMzA4NVonIHN0cm9rZT0nIzY3NzQ4RScgc3Ryb2tlLXdpZHRoPScyJyBzdHJva2UtbGluZWNhcD0nc3F1YXJlJyBzdHJva2UtbGluZWpvaW49J3JvdW5kJy8+PC9zdmc+DQo=";
		private readonly string defaultContactImage = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0nNDAnIGhlaWdodD0nNDAnIHZpZXdCb3g9JzAgMCA0MCA0MCcgZmlsbD0nbm9uZScgeG1sbnM9J2h0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnJz48cmVjdCB3aWR0aD0nNDAnIGhlaWdodD0nNDAnIHJ4PSc0JyBmaWxsPScjRjZGNkY2Jy8+PHBhdGggZD0nTTE0LjM0MDIgMjguMjYyNkwxNC4wNjM1IDI5LjIyMzZIMTQuMDYzNUwxNC4zNDAyIDI4LjI2MjZaTTI1LjY2MDMgMjguMjYyNkwyNS4zODM2IDI3LjMwMTZMMjUuNjYwMyAyOC4yNjI2Wk0xMi4wMDAyIDI0LjgxNjFIMTMuMDAwMkgxMi4wMDAyWk0xNC4wNjM1IDI5LjIyMzZDMTUuNDk4IDI5LjYzNjYgMTcuNDkzNiAyOS45OTk5IDIwLjAwMDIgMjkuOTk5OVYyNy45OTk5QzE3LjY4NzYgMjcuOTk5OSAxNS44NzgxIDI3LjY2NDggMTQuNjE2OSAyNy4zMDE2TDE0LjA2MzUgMjkuMjIzNlpNMjAuMDAwMiAyOS45OTk5QzIyLjUwNjggMjkuOTk5OSAyNC41MDI0IDI5LjYzNjYgMjUuOTM3IDI5LjIyMzVMMjUuMzgzNiAyNy4zMDE2QzI0LjEyMjMgMjcuNjY0OCAyMi4zMTI4IDI3Ljk5OTkgMjAuMDAwMiAyNy45OTk5VjI5Ljk5OTlaTTI5LjAwMDIgMjQuODE2MUMyOS4wMDAyIDIzLjkwMjEgMjguNTk0MyAyMy4xNjE2IDI4LjA4MTQgMjIuNjAxNkMyNy41Nzc2IDIyLjA1MTQgMjYuOTM2MyAyMS42MzQzIDI2LjM0NTEgMjEuMzIzNUMyNS43NDY3IDIxLjAwODkgMjUuMTQ5NSAyMC43Nzc0IDI0LjY5NjYgMjAuNjE4MUMyNC40NjkzIDIwLjUzODEgMjQuMjczNCAyMC40NzQ2IDI0LjEzNDMgMjAuNDI5NEMyNC4wNjIgMjAuNDA1OCAyNC4wMTI0IDIwLjM4OTYgMjMuOTc3MSAyMC4zNzc0QzIzLjkxNzcgMjAuMzU2OCAyMy45NTg3IDIwLjM2NzggMjQuMDE5OSAyMC4zOTk4TDIzLjA5MTcgMjIuMTcxNUMyMy4xODY4IDIyLjIyMTMgMjMuMjkyMiAyMi4yNTY3IDIzLjMyMzcgMjIuMjY3NkMyMy4zNzk0IDIyLjI4NjkgMjMuNDQ3MyAyMi4zMDkgMjMuNTE1IDIyLjMzMTFDMjMuNjU2MiAyMi4zNzcgMjMuODMwOCAyMi40MzM3IDI0LjAzMjkgMjIuNTA0N0MyNC40Mzg3IDIyLjY0NzYgMjQuOTM1NyAyMi44NDIxIDI1LjQxNDQgMjMuMDkzOEMyNS45MDA0IDIzLjM0OTMgMjYuMzE5NCAyMy42Mzg5IDI2LjYwNjUgMjMuOTUyM0MyNi44ODQ1IDI0LjI1NTkgMjcuMDAwMiAyNC41MzYgMjcuMDAwMiAyNC44MTYxSDI5LjAwMDJaTTE1Ljk4MTMgMjAuMzk5NUMxNi4wNDMxIDIwLjM2NzIgMTYuMDg0OSAyMC4zNTYgMTYuMDI1MSAyMC4zNzY2QzE1Ljk4OTggMjAuMzg4NyAxNS45NDAzIDIwLjQwNDkgMTUuODY4IDIwLjQyODNDMTUuNzI5IDIwLjQ3MzQgMTUuNTMzMiAyMC41MzY3IDE1LjMwNTggMjAuNjE2NEMxNC44NTI5IDIwLjc3NTMgMTQuMjU1NSAyMS4wMDY0IDEzLjY1NjggMjEuMzIwOUMxMy4wNjUyIDIxLjYzMTUgMTIuNDIzNiAyMi4wNDg3IDExLjkxOTQgMjIuNTk5NEMxMS40MDYgMjMuMTYwMSAxMS4wMDAyIDIzLjkwMTIgMTEuMDAwMiAyNC44MTYxSDEzLjAwMDJDMTMuMDAwMiAyNC41MzQ0IDEzLjExNjUgMjQuMjUzNiAxMy4zOTQ1IDIzLjk0OTlDMTMuNjgxNiAyMy42MzYzIDE0LjEwMDcgMjMuMzQ2OCAxNC41ODY3IDIzLjA5MTVDMTUuMDY1NSAyMi44NDAxIDE1LjU2MjQgMjIuNjQ2IDE1Ljk2OCAyMi41MDM2QzE2LjE2OTkgMjIuNDMyOCAxNi4zNDQ0IDIyLjM3NjQgMTYuNDg1MiAyMi4zMzA3QzE2LjU1MjggMjIuMzA4OCAxNi42MjA1IDIyLjI4NjggMTYuNjc1OSAyMi4yNjc3QzE2LjcwNjggMjIuMjU3MSAxNi44MTI3IDIyLjIyMTcgMTYuOTA4MSAyMi4xNzE4TDE1Ljk4MTMgMjAuMzk5NVpNMjUuOTM3IDI5LjIyMzVDMjguMDQwOCAyOC42MTc4IDI5LjAwMDIgMjYuNjk5IDI5LjAwMDIgMjQuODE2MUgyNy4wMDAyQzI3LjAwMDIgMjYuMDczMiAyNi40IDI3LjAwOSAyNS4zODM2IDI3LjMwMTZMMjUuOTM3IDI5LjIyMzVaTTExLjAwMDIgMjQuODE2MUMxMS4wMDAyIDI2LjY5OSAxMS45NTk4IDI4LjYxNzggMTQuMDYzNSAyOS4yMjM2TDE0LjYxNjkgMjcuMzAxNkMxMy42MDA1IDI3LjAwOSAxMy4wMDAyIDI2LjA3MzEgMTMuMDAwMiAyNC44MTYxSDExLjAwMDJaTTIwLjAwMDIgMjMuNjQ3QzIyLjA2ODIgMjMuNjQ3IDIzLjcwMTkgMjIuODkxOCAyNC43OTY5IDIxLjU0NjRDMjUuODY3NCAyMC4yMzEgMjYuMzMzNiAxOC40NjI3IDI2LjMzMzYgMTYuNTcxNEgyNC4zMzM2QzI0LjMzMzYgMTguMTYyNyAyMy45Mzg5IDE5LjQzMjIgMjMuMjQ1NyAyMC4yODRDMjIuNTc2OSAyMS4xMDU3IDIxLjU0NCAyMS42NDcgMjAuMDAwMiAyMS42NDdWMjMuNjQ3Wk0yNi4zMzM2IDE2LjU3MTRDMjYuMzMzNiAxMy4wODU3IDIzLjY4NzYgOS45OTk5NCAyMC4wMDAyIDkuOTk5OTRWMTEuOTk5OUMyMi40NTQzIDExLjk5OTkgMjQuMzMzNiAxNC4wNTcgMjQuMzMzNiAxNi41NzE0SDI2LjMzMzZaTTIwLjAwMDIgOS45OTk5NEMxNi4zMTI5IDkuOTk5OTQgMTMuNjY2OSAxMy4wODU3IDEzLjY2NjkgMTYuNTcxNEgxNS42NjY5QzE1LjY2NjkgMTQuMDU3IDE3LjU0NjIgMTEuOTk5OSAyMC4wMDAyIDExLjk5OTlWOS45OTk5NFpNMTMuNjY2OSAxNi41NzE0QzEzLjY2NjkgMTguNDYyNyAxNC4xMzMxIDIwLjIzMSAxNS4yMDM2IDIxLjU0NjRDMTYuMjk4NSAyMi44OTE4IDE3LjkzMjMgMjMuNjQ3IDIwLjAwMDIgMjMuNjQ3VjIxLjY0N0MxOC40NTY1IDIxLjY0NyAxNy40MjM2IDIxLjEwNTcgMTYuNzU0OCAyMC4yODRDMTYuMDYxNiAxOS40MzIyIDE1LjY2NjkgMTguMTYyNyAxNS42NjY5IDE2LjU3MTRIMTMuNjY2OVonIGZpbGw9JyM2Nzc0OEUnLz48L3N2Zz4NCg==";
		private readonly string defaultContactNoAccessImage = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0nNDAnIGhlaWdodD0nNDAnIHZpZXdCb3g9JzAgMCA0MCA0MCcgZmlsbD0nbm9uZScgeG1sbnM9J2h0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnJz48cmVjdCB3aWR0aD0nNDAnIGhlaWdodD0nNDAnIHJ4PSc0JyBmaWxsPScjRjZGNkY2Jy8+PHBhdGggZD0nTTE0LjM0MDIgMjguMjYyNkwxNC4wNjM1IDI5LjIyMzZIMTQuMDYzNUwxNC4zNDAyIDI4LjI2MjZaTTI1LjY2MDMgMjguMjYyNkwyNS4zODM2IDI3LjMwMTZMMjUuNjYwMyAyOC4yNjI2Wk0xMi4wMDAyIDI0LjgxNjFIMTMuMDAwMkgxMi4wMDAyWk0xNC4wNjM1IDI5LjIyMzZDMTUuNDk4IDI5LjYzNjYgMTcuNDkzNiAyOS45OTk5IDIwLjAwMDIgMjkuOTk5OVYyNy45OTk5QzE3LjY4NzYgMjcuOTk5OSAxNS44NzgxIDI3LjY2NDggMTQuNjE2OSAyNy4zMDE2TDE0LjA2MzUgMjkuMjIzNlpNMjAuMDAwMiAyOS45OTk5QzIyLjUwNjggMjkuOTk5OSAyNC41MDI0IDI5LjYzNjYgMjUuOTM3IDI5LjIyMzVMMjUuMzgzNiAyNy4zMDE2QzI0LjEyMjMgMjcuNjY0OCAyMi4zMTI4IDI3Ljk5OTkgMjAuMDAwMiAyNy45OTk5VjI5Ljk5OTlaTTI5LjAwMDIgMjQuODE2MUMyOS4wMDAyIDIzLjkwMjEgMjguNTk0MyAyMy4xNjE2IDI4LjA4MTQgMjIuNjAxNkMyNy41Nzc2IDIyLjA1MTQgMjYuOTM2MyAyMS42MzQzIDI2LjM0NTEgMjEuMzIzNUMyNS43NDY3IDIxLjAwODkgMjUuMTQ5NSAyMC43Nzc0IDI0LjY5NjYgMjAuNjE4MUMyNC40NjkzIDIwLjUzODEgMjQuMjczNCAyMC40NzQ2IDI0LjEzNDMgMjAuNDI5NEMyNC4wNjIgMjAuNDA1OCAyNC4wMTI0IDIwLjM4OTYgMjMuOTc3MSAyMC4zNzc0QzIzLjkxNzcgMjAuMzU2OCAyMy45NTg3IDIwLjM2NzggMjQuMDE5OSAyMC4zOTk4TDIzLjA5MTcgMjIuMTcxNUMyMy4xODY4IDIyLjIyMTMgMjMuMjkyMiAyMi4yNTY3IDIzLjMyMzcgMjIuMjY3NkMyMy4zNzk0IDIyLjI4NjkgMjMuNDQ3MyAyMi4zMDkgMjMuNTE1IDIyLjMzMTFDMjMuNjU2MiAyMi4zNzcgMjMuODMwOCAyMi40MzM3IDI0LjAzMjkgMjIuNTA0N0MyNC40Mzg3IDIyLjY0NzYgMjQuOTM1NyAyMi44NDIxIDI1LjQxNDQgMjMuMDkzOEMyNS45MDA0IDIzLjM0OTMgMjYuMzE5NCAyMy42Mzg5IDI2LjYwNjUgMjMuOTUyM0MyNi44ODQ1IDI0LjI1NTkgMjcuMDAwMiAyNC41MzYgMjcuMDAwMiAyNC44MTYxSDI5LjAwMDJaTTE1Ljk4MTMgMjAuMzk5NUMxNi4wNDMxIDIwLjM2NzIgMTYuMDg0OSAyMC4zNTYgMTYuMDI1MSAyMC4zNzY2QzE1Ljk4OTggMjAuMzg4NyAxNS45NDAzIDIwLjQwNDkgMTUuODY4IDIwLjQyODNDMTUuNzI5IDIwLjQ3MzQgMTUuNTMzMiAyMC41MzY3IDE1LjMwNTggMjAuNjE2NEMxNC44NTI5IDIwLjc3NTMgMTQuMjU1NSAyMS4wMDY0IDEzLjY1NjggMjEuMzIwOUMxMy4wNjUyIDIxLjYzMTUgMTIuNDIzNiAyMi4wNDg3IDExLjkxOTQgMjIuNTk5NEMxMS40MDYgMjMuMTYwMSAxMS4wMDAyIDIzLjkwMTIgMTEuMDAwMiAyNC44MTYxSDEzLjAwMDJDMTMuMDAwMiAyNC41MzQ0IDEzLjExNjUgMjQuMjUzNiAxMy4zOTQ1IDIzLjk0OTlDMTMuNjgxNiAyMy42MzYzIDE0LjEwMDcgMjMuMzQ2OCAxNC41ODY3IDIzLjA5MTVDMTUuMDY1NSAyMi44NDAxIDE1LjU2MjQgMjIuNjQ2IDE1Ljk2OCAyMi41MDM2QzE2LjE2OTkgMjIuNDMyOCAxNi4zNDQ0IDIyLjM3NjQgMTYuNDg1MiAyMi4zMzA3QzE2LjU1MjggMjIuMzA4OCAxNi42MjA1IDIyLjI4NjggMTYuNjc1OSAyMi4yNjc3QzE2LjcwNjggMjIuMjU3MSAxNi44MTI3IDIyLjIyMTcgMTYuOTA4MSAyMi4xNzE4TDE1Ljk4MTMgMjAuMzk5NVpNMjUuOTM3IDI5LjIyMzVDMjguMDQwOCAyOC42MTc4IDI5LjAwMDIgMjYuNjk5IDI5LjAwMDIgMjQuODE2MUgyNy4wMDAyQzI3LjAwMDIgMjYuMDczMiAyNi40IDI3LjAwOSAyNS4zODM2IDI3LjMwMTZMMjUuOTM3IDI5LjIyMzVaTTExLjAwMDIgMjQuODE2MUMxMS4wMDAyIDI2LjY5OSAxMS45NTk4IDI4LjYxNzggMTQuMDYzNSAyOS4yMjM2TDE0LjYxNjkgMjcuMzAxNkMxMy42MDA1IDI3LjAwOSAxMy4wMDAyIDI2LjA3MzEgMTMuMDAwMiAyNC44MTYxSDExLjAwMDJaTTIwLjAwMDIgMjMuNjQ3QzIyLjA2ODIgMjMuNjQ3IDIzLjcwMTkgMjIuODkxOCAyNC43OTY5IDIxLjU0NjRDMjUuODY3NCAyMC4yMzEgMjYuMzMzNiAxOC40NjI3IDI2LjMzMzYgMTYuNTcxNEgyNC4zMzM2QzI0LjMzMzYgMTguMTYyNyAyMy45Mzg5IDE5LjQzMjIgMjMuMjQ1NyAyMC4yODRDMjIuNTc2OSAyMS4xMDU3IDIxLjU0NCAyMS42NDcgMjAuMDAwMiAyMS42NDdWMjMuNjQ3Wk0yNi4zMzM2IDE2LjU3MTRDMjYuMzMzNiAxMy4wODU3IDIzLjY4NzYgOS45OTk5NCAyMC4wMDAyIDkuOTk5OTRWMTEuOTk5OUMyMi40NTQzIDExLjk5OTkgMjQuMzMzNiAxNC4wNTcgMjQuMzMzNiAxNi41NzE0SDI2LjMzMzZaTTIwLjAwMDIgOS45OTk5NEMxNi4zMTI5IDkuOTk5OTQgMTMuNjY2OSAxMy4wODU3IDEzLjY2NjkgMTYuNTcxNEgxNS42NjY5QzE1LjY2NjkgMTQuMDU3IDE3LjU0NjIgMTEuOTk5OSAyMC4wMDAyIDExLjk5OTlWOS45OTk5NFpNMTMuNjY2OSAxNi41NzE0QzEzLjY2NjkgMTguNDYyNyAxNC4xMzMxIDIwLjIzMSAxNS4yMDM2IDIxLjU0NjRDMTYuMjk4NSAyMi44OTE4IDE3LjkzMjMgMjMuNjQ3IDIwLjAwMDIgMjMuNjQ3VjIxLjY0N0MxOC40NTY1IDIxLjY0NyAxNy40MjM2IDIxLjEwNTcgMTYuNzU0OCAyMC4yODRDMTYuMDYxNiAxOS40MzIyIDE1LjY2NjkgMTguMTYyNyAxNS42NjY5IDE2LjU3MTRIMTMuNjY2OVonIGZpbGw9JyM2Nzc0OEUnLz48L3N2Zz4NCg==";
		private readonly string toggleCollapse = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdib3g9IjAgMCAxMCA0IiBoZWlnaHQ9IjQiIHdpZHRoPSIxMCI+DQoJPGc+DQoJCTxwYXRoIGZpbGw9Im5vbmUiIHN0cm9rZT0iIzYwNzc5RiIgZD0iTTAuNSAzLjUgTDUgMC41IEw5LjUgMy41IiAvPg0KCTwvZz4NCjwvc3ZnPg==";
		private readonly string toggleExpand = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdib3g9IjAgMCAxMCA0IiBoZWlnaHQ9IjQiIHdpZHRoPSIxMCI+Cgk8Zz4KCQk8cGF0aCBmaWxsPSJub25lIiBzdHJva2U9IiM2MDc3OUYiIGQ9Ik0wLjUgMC41IEw1IDMuNSBMOS41IDAuNSIgLz4KCTwvZz4KPC9zdmc+";

		private readonly string RelationshipTypeEnum_RelationshipItem = "relationship-item";
		private readonly string RelationshipTypeEnum_RelationshipContainer = "relationship-container";
		private readonly string RelationshipTypeEnum_Connection = "connection";
		private readonly string RelationshipTypeEnum_IndirectConnection = "indirect-connection";
		private readonly string RelationshipTypeEnum_ParentConnection = "parent-connection";

		private readonly Guid RelationConnectionType_Formal = RelationshipDesignerConstants.RelationTypeConnectionType_Formal;
		private readonly string ConnectionLabel_Type = "label";

		private readonly int _queryMaxParametersCount = 2000;

		private RightsHelper _rightsHelper;
		private IRelationshipDiagramConfigProvider _diagramConfigProvider;
		private IRelationshipDiagramManager _diagramManager;

		#endregion

		#region Constructors: Public

		public RelationshipDiagramBuilder(UserConnection userConnection) {
			this.UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// User connection.
		/// </summary>
		private UserConnection UserConnection {
			get; set;
		}

		public RightsHelper RightsHelper =>
			_rightsHelper ?? (_rightsHelper = ClassFactory.Get<RightsHelper>(
				new ConstructorArgument("userConnection", UserConnection)));

		public IRelationshipDiagramConfigProvider DiagramConfigProvider =>
			_diagramConfigProvider ?? (_diagramConfigProvider = ClassFactory.Get<IRelationshipDiagramConfigProvider>());

		public IRelationshipDiagramManager DiagramManager =>
			_diagramManager ?? (_diagramManager = ClassFactory.Get<IRelationshipDiagramManager>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		#region DiagramConfig
		private List<DiagramElement> GetDiagramElementsConfigMockData() {
			var accountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Account");
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var noAccessCaption = UserConnection.GetLocalizableString(GetType().Name, "NoAccessElementCaption");
			return new List<DiagramElement> {
					new DiagramElement() {
						Caption = accountSchema.Name,
						CaptionNoAccess = noAccessCaption,
						Width = 300,
						Height = 56,
						ImageWidth = 56,
						ImageHeight = 56,
						Fill = "#F8F9FE",
						FillInParent = "#FFFFFF",
						Stroke = "#E4E4E4",
						RelationshipType = RelationshipTypeEnum_RelationshipContainer,
						LargeImage = defaultAccountImage,
						LargeImageNoAccess = defaultAccountNoAccessImage,
						EntitySchemaData = new EntitySchemaData {
							Name = accountSchema.Name,
							Caption = accountSchema.Caption,
							UId = accountSchema.UId
						}
					},
					new DiagramElement() {
						Caption = contactSchema.Name,
						CaptionNoAccess = noAccessCaption,
						Width = 300,
						Height = 56,
						ImageWidth = 56,
						ImageHeight = 56,
						Fill = "#F8F9FE",
						FillInParent = "#FFFFFF",
						Stroke = "#E4E4E4",
						RelationshipType = RelationshipTypeEnum_RelationshipItem,
						LargeImage = defaultContactImage,
						LargeImageNoAccess = defaultContactNoAccessImage,
						EntitySchemaData = new EntitySchemaData {
							Name = contactSchema.Name,
							Caption = contactSchema.Caption,
							UId = contactSchema.UId
						}
					},
					new DiagramElement() {
						RelationshipType = RelationshipTypeEnum_IndirectConnection
					}
			};
		}
		private string GetImageUrl(string elementName) {
			return string.Format("../img/resource-manager/hash/BPMSoft.Nui/{0}", elementName);
		}

		private ElementToolsConfig GetElementToolsConfig() {
			return new ElementToolsConfig {
				AddItems = new List<ToolItem>(),
				Tools = new ToolObject {
					Add = new ToolItem {
						ImageUrl = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiA8IS0tIENyZWF0ZWQgd2l0aCBNZXRob2QgRHJhdyAtIGh0dHA6Ly9naXRodWIuY29tL2R1b3BpeGVsL01ldGhvZC1EcmF3LyAtLT4KIDxnPgogIDx0aXRsZT5iYWNrZ3JvdW5kPC90aXRsZT4KICA8cmVjdCBmaWxsPSJub25lIiBpZD0iY2FudmFzX2JhY2tncm91bmQiIGhlaWdodD0iMjYiIHdpZHRoPSIyNiIgeT0iLTEiIHg9Ii0xIi8+CiAgPGcgZGlzcGxheT0ibm9uZSIgb3ZlcmZsb3c9InZpc2libGUiIHk9IjAiIHg9IjAiIGhlaWdodD0iMTAwJSIgd2lkdGg9IjEwMCUiIGlkPSJjYW52YXNHcmlkIj4KICAgPHJlY3QgZmlsbD0idXJsKCNncmlkcGF0dGVybikiIHN0cm9rZS13aWR0aD0iMCIgeT0iMCIgeD0iMCIgaGVpZ2h0PSIxMDAlIiB3aWR0aD0iMTAwJSIvPgogIDwvZz4KIDwvZz4KIDxnPgogIDx0aXRsZT5MYXllciAxPC90aXRsZT4KICA8dGV4dCB4bWw6c3BhY2U9InByZXNlcnZlIiB0ZXh0LWFuY2hvcj0ic3RhcnQiIGZvbnQtZmFtaWx5PSJIZWx2ZXRpY2EsIEFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjI0IiBpZD0ic3ZnXzEiIHk9IjIwLjMxNDE4IiB4PSI0Ljk4NTc5IiBzdHJva2Utd2lkdGg9IjAiIHN0cm9rZT0iIzAwMCIgZmlsbD0iIzU0NjU3ZCI+KzwvdGV4dD4KIDwvZz4KPC9zdmc+"
					},
					Connect = new ToolItem {
						ImageUrl = GetImageUrl("ProcessSchemaDesigner.ElementTools.ArrowToolsImage.svg")

					},
					Setup = new ToolItem {
						ImageUrl = GetImageUrl("ProcessSchemaDesigner.ElementTools.SetupToolsImage.svg")
					},
					Delete = new ToolItem {
						ImageUrl = GetImageUrl("ProcessSchemaDesigner.ElementTools.DeleteToolsImage.svg")
					}
				},
				InnerTools = new InnerToolObject {
					Toggle = new InnerToolItem {
						ExpandImageUrl = toggleExpand,
						CollapseImageUrl = toggleCollapse
					}
				}
			};
		}

		#endregion

		private string GetEntityImage(Entity entity, string columnName, string defaultValue) {
			var imageId = entity.GetTypedColumnValue<Guid>(columnName);
			if (imageId.IsEmpty()) {
				return defaultValue;
			}
			try {
				var imageEntity = UserConnection.EntitySchemaManager.GetInstanceByName("SysImage")
					.CreateEntity(UserConnection);
				imageEntity.FetchFromDB("Id", imageId);
				var mimeType = imageEntity.GetTypedColumnValue<string>("MimeType");
				var fileContent = Convert.ToBase64String(imageEntity.GetBytesValue("Data"));
				var result = $"data:{mimeType};base64,{fileContent}";
				return result;
			} catch (Exception e) {
				return defaultValue;
			}
		}

		private bool IsFirstLevel(Guid schemaUId, DiagramConfiguration configuration) {
			return configuration.FirstLevelConfig.SchemaUId == schemaUId;
		}

		private Guid GetDiagramIdByEntityRecordId(Guid entityRecordId) {
			var entitySelect = new Select(UserConnection)
				.Column("RelationEntInDiagram", "RelationshipDiagramId")
				.From("RelationEntInDiagram")
				.InnerJoin("RelationshipEntity")
					.On("RelationEntInDiagram", "RelationshipEntityId")
					.IsEqual("RelationshipEntity", "Id")
				.Where("RecordId").IsEqual(Column.Parameter(entityRecordId)) as Select;
			return entitySelect.ExecuteScalar<Guid>();
		}

		private List<ConnectionLabel> GetConnectionLabels(List<ConnectionInfo> connections) {
			List<ConnectionLabel> connectionLabels = new List<ConnectionLabel>();
			var notEmptyConnections = connections.Where(e => !string.IsNullOrEmpty(e.Comment)).ToList();
			foreach (ConnectionInfo connectionInfo in notEmptyConnections) {
				connectionLabels.Add(new ConnectionLabel {
					Caption = connectionInfo.Comment,
					Type = ConnectionLabel_Type,
					Parent = connectionInfo.Id
				});
			}
			return connectionLabels;
		}

		private Dictionary<Guid, RelationshipGroup> GetRelationshipGroupWithEntities(Guid diagramId) {
			Dictionary<Guid, RelationshipGroup> relationshipGroupDictionary = new Dictionary<Guid, RelationshipGroup>();
			var groupSelect = new Select(UserConnection)
				.Column("RelationshipGroup", "Id").As("Id")
				.Column("RelationshipGroup", "Name").As("Name")
				.Column("RelationshipGroup", "Color").As("Color")
				.Column("RelationshipGroup", "Comment").As("Comment")
				.Column("RelationEntityInGroup", "RelationshipEntityId").As("RelationshipEntityId")
				.From("RelationshipGroup").As("RelationshipGroup")
				.InnerJoin("RelationEntityInGroup").As("RelationEntityInGroup")
					.On("RelationEntityInGroup", "RelationshipGroupId").IsEqual("RelationshipGroup", "Id")
				.InnerJoin("RelationEntInDiagram").As("RelationEntInDiagram")
					.On("RelationEntInDiagram", "RelationshipEntityId").IsEqual("RelationEntityInGroup", "RelationshipEntityId")
				.Where("RelationEntInDiagram", "RelationshipDiagramId").IsEqual(Column.Parameter(diagramId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = groupSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var entityId = reader.GetColumnValue<Guid>("RelationshipEntityId");
						var groupId = reader.GetColumnValue<Guid>("Id");
						var name = reader.GetColumnValue<string>("Name");
						var color = reader.GetColumnValue<string>("Color");
						var comment = reader.GetColumnValue<string>("Comment");
						var relationshipGroup = new RelationshipGroup();
						if (relationshipGroupDictionary.TryGetValue(groupId, out relationshipGroup)) {
							relationshipGroup.Entities.AddIfNotExists(entityId);
						} else {
							relationshipGroupDictionary.Add(groupId, new RelationshipGroup {
								Caption = name,
								Id = groupId,
								Color = color,
								Comment = comment,
								Entities = new List<Guid> { entityId }
							});
						}
					}
				}
			}

			return relationshipGroupDictionary;
		}

		private Dictionary<Guid, List<RelationshipInGroup>> GetRelationshipEntetiesInGroups(Guid diagramId) {
			Dictionary<Guid, List<RelationshipInGroup>> relationshipEntetiesInGroups = new Dictionary<Guid, List<RelationshipInGroup>>();
			var groupSelect = new Select(UserConnection)
				.Column("RelationEntityInGroup", "RelationshipEntityId").As("EntityId")
				.Column("RelationEntityInGroup", "RelationshipGroupId").As("GroupId")
				.Column("RelationEntityInGroup", "Comment").As("Comment")
				.From("RelationEntityInGroup").As("RelationEntityInGroup")
				.InnerJoin("RelationEntInDiagram").As("RelationEntInDiagram")
					.On("RelationEntInDiagram", "RelationshipEntityId").IsEqual("RelationEntityInGroup", "RelationshipEntityId")
				.Where("RelationEntInDiagram", "RelationshipDiagramId").IsEqual(Column.Parameter(diagramId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = groupSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var entityId = reader.GetColumnValue<Guid>("EntityId");
						var groupId = reader.GetColumnValue<Guid>("GroupId");
						var comment = reader.GetColumnValue<string>("Comment");
						var relationshipInGroup = new RelationshipInGroup {
							GroupId = groupId,
							Comment = comment
						};
						if (relationshipEntetiesInGroups.ContainsKey(entityId)) {
							relationshipEntetiesInGroups[entityId].Add(relationshipInGroup);
						} else {
							var entetiesInGroups = new List<RelationshipInGroup>();
							entetiesInGroups.Add(relationshipInGroup);
							relationshipEntetiesInGroups[entityId] = entetiesInGroups;
						}
					}
				}
			}
			return relationshipEntetiesInGroups;
		}


		private List<EntityInfo> AddGroupsToEntities(List<EntityInfo> entities, Dictionary<Guid, List<RelationshipInGroup>> relationshipEntetiesInGroups) {
			var resultEntities = new List<EntityInfo>();
			foreach (var entity in entities) {
				if (relationshipEntetiesInGroups.Any() && entity.CanRead && relationshipEntetiesInGroups.ContainsKey(entity.Id)) {
					entity.Groups = relationshipEntetiesInGroups[entity.Id];
				}
				resultEntities.Add(entity);
			}
			return resultEntities;
		}

		private List<ConnectionInfo> ApplyEntitiesRightsToConnections(List<EntityInfo> diagramEntities, List<ConnectionInfo> diagramConnections) {
			foreach (ConnectionInfo diagramConnection in diagramConnections) {
				var sourceOrTargetCanNotRead = diagramEntities
					.Any(entity => (entity.Id == diagramConnection.Source || entity.Id == diagramConnection.Target) && !entity.CanRead);
				if (sourceOrTargetCanNotRead) {
					diagramConnection.Comment = string.Empty;
				}
			}
			return diagramConnections;
		}

		private string GetConnectionType(Guid connectionType, bool includeIntoContainer) {
			if (connectionType.Equals(RelationConnectionType_Formal)) {
				return includeIntoContainer ? RelationshipTypeEnum_ParentConnection : RelationshipTypeEnum_Connection;
			} else {
				return RelationshipTypeEnum_IndirectConnection;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns part of diagram connections.
		/// </summary>
		/// <param name="recordIds">Part of entities ids.</param>
		/// <param name="isOrCondition">Is apply OR condition for entities.</param>
		/// <returns>Diagram connections.</returns>
		protected List<ConnectionInfo> GetPartDiagramConnections(IEnumerable<Guid> recordIds, bool isOrCondition = false) {
			var result = new List<ConnectionInfo>();
			if (recordIds.IsEmpty()) {
				return result;
			}
			var entityConnectionsSelect = GetDiagramConnectionsSelect(recordIds, isOrCondition);
			entityConnectionsSelect.ExecuteReader((reader) => {
				result.Add(CreateDigramConnection(reader));
			});
			return result;
		}

		/// <summary>
		/// Returns diagram connections select.
		/// </summary>
		/// <param name="recordIds">Entities ids.</param>
		/// <param name="isOrCondition">Is apply OR condition for entities.</param>
		/// <returns>Select.</returns>
		protected Select GetDiagramConnectionsSelect(IEnumerable<Guid> recordIds, bool isOrCondition = false) {
			Guid currentUserCultureId = UserConnection.CurrentUser.SysCultureId;
			var select = new Select(UserConnection)
				.Column("RC", "Id")
				.Column("RC", "RelationshipEntityAId")
				.Column("RC", "RelationshipEntityBId")
				.Column("RC", "Comment")
				.Column("RC", "Name")
				.Column("RT", "Id").As("RelationTypeId")
				.Column(Func.IsNull(Column.SourceColumn("SRTL", "Name"), Column.SourceColumn("RT", "Name"))).As("RelationTypeName")
				.Column("RT", "IncludeIntoContainer").As("IncludeIntoContainer")
				.Column(Func.IsNull(Column.SourceColumn("SRRTL", "Name"), Column.SourceColumn("RRT", "Name"))).As("ReverseRelationTypeName")
				.Column("RCT", "Id").As("RelationConnectionTypeId")
				.Column(Func.IsNull(Column.SourceColumn("SRCTL", "Name"), Column.SourceColumn("RCT", "Name"))).As("RelationConnectionTypeName")
				.Column("EntityA", "SchemaUId").As("EntityASchemaUId")
				.Column("EntityB", "SchemaUId").As("EntityBSchemaUId")
				.Column("RTP", "Value").As("Position")
				.From("RelationshipConnection").As("RC")
				.InnerJoin("RelationshipEntity").As("EntityA").On("EntityA", "Id").IsEqual("RC", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("EntityB").On("EntityB", "Id").IsEqual("RC", "RelationshipEntityBId")
				.LeftOuterJoin("RelationType").As("RT").On("RC", "RelationTypeId").IsEqual("RT", "Id")
				.LeftOuterJoin("SysRelationTypeLcz").As("SRTL").On("RT", "Id").IsEqual("SRTL", "RecordId")
					.And("SRTL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.LeftOuterJoin("RelationConnectionType").As("RCT").On("RT", "RelationConnectionTypeId").IsEqual("RCT", "Id")
				.LeftOuterJoin("SysRelationConnectionTypeLcz").As("SRCTL").On("RCT", "Id").IsEqual("SRCTL", "RecordId")
					.And("SRCTL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.LeftOuterJoin("RelationTypePosition").As("RTP").On("RT", "PositionId").IsEqual("RTP", "Id")
				.LeftOuterJoin("RelationType").As("RRT").On("RT", "ReverseRelationTypeId").IsEqual("RRT", "Id")
				.LeftOuterJoin("SysRelationTypeLcz").As("SRRTL").On("RRT", "Id").IsEqual("SRRTL", "RecordId")
					.And("SRRTL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.Where("RelationshipEntityAId")
					.In(Column.Parameters(recordIds)) as Select;
			if (isOrCondition) {
				select.Or("RelationshipEntityBId")
					.In(Column.Parameters(recordIds));
			} else {
				select.And("RelationshipEntityBId")
					.In(Column.Parameters(recordIds));
			}
			return select;
		}

		/// <summary>
		/// Creates diagram connection.
		/// </summary>
		/// <param name="reader">Reader.</param>
		/// <returns>Diagram connection.</returns>
		protected ConnectionInfo CreateDigramConnection(IDataReader reader) {
			var relationConnectionTypeId = reader.GetColumnValue<Guid>("RelationConnectionTypeId");
			var includeIntoContainer = GetDiagramConnectionIncludePropertyValue(reader);
			var typeOfConnection = GetConnectionType(relationConnectionTypeId, includeIntoContainer);
			return new ConnectionInfo {
				Id = reader.GetColumnValue<Guid>("Id"),
				Source = reader.GetColumnValue<Guid>("RelationshipEntityAId"),
				Target = reader.GetColumnValue<Guid>("RelationshipEntityBId"),
				ElementType = typeOfConnection,
				Name = reader.GetColumnValue<string>("Name"),
				Comment = reader.GetColumnValue<string>("Comment"),
				RelationshipType = CreateDiagramConnectionRelationType(reader)
			};
		}

		/// <summary>
		/// Returns diagram connection include property value.
		/// </summary>
		/// <param name="reader">Reader.</param>
		/// <returns>Connection include property value.</returns>
		protected bool GetDiagramConnectionIncludePropertyValue(IDataReader reader) {
			var relationConnectionTypeId = reader.GetColumnValue<Guid>("RelationConnectionTypeId");
			var entityASchemaUId = reader.GetColumnValue<string>("EntityASchemaUId");
			var entityBSchemaUId = reader.GetColumnValue<string>("EntityBSchemaUId");
			var includeIntoContainer = reader.GetColumnValue<bool>("IncludeIntoContainer");
			return includeIntoContainer &&
				relationConnectionTypeId.Equals(RelationConnectionType_Formal) &&
				!entityASchemaUId.Equals(entityBSchemaUId);
		}

		/// <summary>
		/// Creates diagram connection relation type.
		/// </summary>
		/// <param name="reader">Reader.</param>
		/// <returns>Connection relation type.</returns>
		protected RelationshipType CreateDiagramConnectionRelationType(IDataReader reader) {
			var includeIntoContainer = GetDiagramConnectionIncludePropertyValue(reader);
			return new RelationshipType {
				Id = reader.GetColumnValue<Guid>("RelationTypeId"),
				Name = $"{reader.GetColumnValue<string>("RelationTypeName")} - {reader.GetColumnValue<string>("ReverseRelationTypeName")}",
				IncludeIntoContainer = includeIntoContainer,
				Position = reader.GetColumnValue<int>("Position"),
				ConnectionType = new LookupItem {
					Id = reader.GetColumnValue<Guid>("RelationConnectionTypeId"),
					Name = reader.GetColumnValue<string>("RelationConnectionTypeName")
				},
			};
		}

		/// <summary>
		/// Returns true if is need distinct diagram connections list.
		/// </summary>
		/// <param name="entitiesRecordsParts">Entities records parts.</param>
		/// <returns>Is need distinct</returns>
		protected bool IsNeedDiagramConnectionsDistinct(IEnumerable<IEnumerable<Guid>> entitiesRecordsParts) {
			return entitiesRecordsParts.Count() > 1;
		}

		/// <summary>
		/// Returns diagram connections chunk size.
		/// </summary>
		/// <returns>Chunk size.</returns>
		protected int GetDiagramConenctionsListChunkSize() {
			return _queryMaxParametersCount / 2;
		}

		#endregion

		#region Methods: Public

		public DiagramInfo GetDiagramData(Guid recordId, string schemaName, DiagramConfiguration configuration, Guid diagramId) {
			if (diagramId.IsEmpty()) {
				diagramId = GetDiagramIdByEntityRecordId(recordId);
			}
			var diagramEntities = GetEntitiesFromDiagram(recordId, configuration);
			diagramEntities = diagramEntities.Where(entity => !entity.IsDeleted).ToList();
			var entityIds = diagramEntities.Select(x => x.Id).ToList();
			var diagramConnections = GetDiagramConnections(entityIds);
			var rootRecordId = diagramEntities.First(x => x.RecordId == recordId).Id;
			var filteredEntityIds = GetOnlyConnectedEntities(rootRecordId, entityIds, diagramConnections);
			diagramEntities = diagramEntities.Where(x => filteredEntityIds.Contains(x.Id)).ToList();
			diagramConnections = diagramConnections.Where(x =>
				filteredEntityIds.Contains(x.Source) && filteredEntityIds.Contains(x.Target)).ToList();
			diagramConnections = ApplyEntitiesRightsToConnections(diagramEntities, diagramConnections);
			var connectionLabels = GetConnectionLabels(diagramConnections);
			var groups = GetRelationshipGroupWithEntities(diagramId);
			var relationshipEntitiesInGroups = GetRelationshipEntetiesInGroups(diagramId);
			var diagramGroups = new List<RelationshipGroup>();
			if (groups.Any()) {
				diagramGroups = groups.Values.ToList();
				diagramEntities = AddGroupsToEntities(diagramEntities, relationshipEntitiesInGroups);
			}

			return new DiagramInfo {
				Id = diagramId,
				Caption = "Coolbrook",
				Entities = diagramEntities,
				Connections = diagramConnections,
				Labels = connectionLabels,
				Groups = diagramGroups,
				RootElementId = recordId
			};
		}

		public List<EntityInfo> GetEntitiesFromDiagram(Guid recordId, DiagramConfiguration diagramConfiguration) {
			var result = new List<EntityInfo>();
			var entitiesSelect = new Select(UserConnection)
				.Column("Id")
				.Column("RecordId")
				.Column("SchemaUId")
				.From("RelationshipEntity")
				.Where("Id").In(new Select(UserConnection)
					.Column("RelationshipEntityId")
					.From("RelationEntInDiagram")
					.Where("RelationshipDiagramId").In(new Select(UserConnection)
						.Column("RelationshipDiagramId")
						.From("RelationEntInDiagram")
						.Where("RelationshipEntityId").In(new Select(UserConnection)
							.Column("Id")
							.From("RelationshipEntity")
							.Where("RecordId").IsEqual(Column.Parameter(recordId)) as Select) as Select) as Select) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = entitiesSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var Id = reader.GetColumnValue<Guid>("Id");
						var entityRecordId = reader.GetColumnValue<Guid>("RecordId");
						var schemaUId = reader.GetColumnValue<Guid>("SchemaUId");
						var isFirstLevel = IsFirstLevel(schemaUId, diagramConfiguration);
						var entityConfiguration = isFirstLevel ? diagramConfiguration.FirstLevelConfig : diagramConfiguration.SecondLevelConfig;
						var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
						var typeOfEntity = isFirstLevel ? RelationshipTypeEnum_RelationshipContainer : RelationshipTypeEnum_RelationshipItem;
						var defaultImage = isFirstLevel ? defaultAccountImage : defaultContactImage;
						var canRead = RightsHelper.GetCanReadSchemaRecordRight(entitySchema.Name, entityRecordId);
						var entityInfo = new EntityInfo {
							Id = Id,
							RecordId = entityRecordId,
							ElementType = typeOfEntity,
							SubCaption = entitySchema.Caption,
							CanRead = canRead,
							IsDeleted = false
						};
						if (!canRead) {
							result.Add(entityInfo);
							continue;
						}
						// TODO Need use diagramconfig for entity
						var entity = entitySchema.CreateEntity(UserConnection);
						// TODO: Add some cleanup for entities that have no records (RelationshipEntity exists when underlying Account/Contact was deleted)
						if (!entity.FetchFromDB("Id", entityRecordId)) {
							entityInfo.IsDeleted = true;
							result.Add(entityInfo);
							continue;
						}
						entityInfo.Caption = entity.GetTypedColumnValue<string>(entityConfiguration.DisplayValueColumn);
						string subCaptionEntityColumnName = isFirstLevel ? "TypeName" : "JobName";
						entityInfo.SubCaption = entity.GetTypedColumnValue<string>(subCaptionEntityColumnName);
						string info = isFirstLevel ? entity.GetTypedColumnValue<string>("AUM") : "";
						info = info.IsNotEmpty() ? string.Format("AUM: {0}", info) : null;
						entityInfo.Info = isFirstLevel ? info : null;
						entityInfo.Image = GetEntityImage(entity, entityConfiguration.ImageColumn, defaultImage);
						result.Add(entityInfo);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns diagram connections by entities.
		/// </summary>
		/// <param name="recordIds">Entities ids.</param>
		/// <returns>Diagram connections.</returns>
		public List<ConnectionInfo> GetDiagramConnections(IEnumerable<Guid> recordIds) {
			var result = new List<ConnectionInfo>();
			if (recordIds.IsEmpty()) {
				return result;
			}
			var chunkSize = GetDiagramConenctionsListChunkSize();
			var parts = recordIds.SplitOnChunks(chunkSize);
			var isNeedDistinct = IsNeedDiagramConnectionsDistinct(parts);
			parts.ForEach(part => {
				result.AddRange(GetPartDiagramConnections(part, isNeedDistinct));
			});
			if (isNeedDistinct) {
				result = result.Distinct().ToList();
			}
			return result;
		}

		public List<Guid> GetOnlyConnectedEntities(Guid sourceRecordId, List<Guid> entities, List<ConnectionInfo> connections) {
			bool isNeedToContinue = true;
			var result = new List<Guid> {
				sourceRecordId
			};
			while (isNeedToContinue) {
				isNeedToContinue = false;
				foreach (var connection in connections) {
					if (result.Contains(connection.Source) && !result.Contains(connection.Target)) {
						result.Add(connection.Target);
						isNeedToContinue = true;
					} else if (result.Contains(connection.Target) && !result.Contains(connection.Source)) {
						result.Add(connection.Source);
						isNeedToContinue = true;
					}
				}
			}
			return result;
		}

		public bool IsRelationshipEntityExistsForCurrentRecord(Guid recordId) {
			var entitySelect = new Select(UserConnection)
				.Column(Func.Count(Column.Asterisk())).As("Count")
				.From("RelationshipEntity")
				.Where("RecordId").IsEqual(Column.Parameter(recordId)) as Select;
			return entitySelect.ExecuteScalar<int>() > 0;
		}

		public DiagramInfo GetDiagram(Guid recordId, string schemaName) {
			if (recordId.IsEmpty()) {
				return new DiagramInfo();
			}
			var configuration = DiagramConfigProvider.GetConfiguration();
			var diagramId = Guid.Empty;
			if (!IsRelationshipEntityExistsForCurrentRecord(recordId)) {
				var createdResult = DiagramManager.CreateRelationshipEntityAndDiagramForRecord(recordId, schemaName);
				diagramId = createdResult.CreatedDiagramId;
				// TODO Optimize. Return empty diagram.
			}
			return GetDiagramData(recordId, schemaName, configuration, diagramId);
		}

		public DiagramConfig GetDiagramConfig() {
			return new DiagramConfig {
				CustomDiagramElements = GetDiagramElementsConfigMockData(),
				CustomElementToolsConfig = GetElementToolsConfig(),
			};
		}

		#endregion

	}

	#endregion

	#region RelationshipDiagramStructure

	#region RelationshipTypeEnum

	[DataContract(Name = "RelationshipTypeEnum")]
	public enum RelationshipTypeEnum
	{
		[EnumMember(Value = "relationship-item")]
		RelationshipItem,

		[EnumMember(Value = "relationship-container")]
		RelationshipContainer,

		[EnumMember(Value = "connection")]
		Connection,

		[EnumMember(Value = "indirect-connection")]
		IndirectConnection
	};

	#endregion

	#region Class: LookupItem

	[DataContract]
	public class LookupItem
	{
		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "name")]
		public string Name {
			get; set;
		}
	}

	#endregion

	#region Class: RelationshipType

	[DataContract]
	public class RelationshipType : LookupItem, IEquatable<RelationshipType>
	{
		#region Properties: Public

		[DataMember(Name = "position")]
		public int Position {
			get; set;
		}

		[DataMember(Name = "includeIntoContainer")]
		public bool IncludeIntoContainer {
			get; set;
		}

		[DataMember(Name = "connectionType")]
		public LookupItem ConnectionType {
			get; set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Equals relationship type with this.
		/// </summary>
		/// <param name="relationshipType">Relationship type.</param>
		/// <returns>Equals value.</returns>
		public bool Equals(RelationshipType relationshipType) {
			if (ReferenceEquals(relationshipType, null)) {
				return false;
			}

			if (ReferenceEquals(this, relationshipType)) {
				return true;
			}

			return Id.Equals(relationshipType.Id);
		}

		/// <summary>
		/// Returns hash code.
		/// </summary>
		/// <returns>Hash code.</returns>
		public override int GetHashCode() {
			return Id.GetHashCode();
		}

		#endregion

	}

	#endregion

	#region Class: DiagramInfo

	[DataContract]
	public class DiagramInfo
	{

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "rootElementId")]
		public Guid RootElementId {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "elements")]
		public List<EntityInfo> Entities {
			get; set;
		}

		[DataMember(Name = "connections")]
		public List<ConnectionInfo> Connections {
			get; set;
		}

		[DataMember(Name = "labels")]
		public List<ConnectionLabel> Labels {
			get; set;
		}

		[DataMember(Name = "groups")]
		public List<RelationshipGroup> Groups {
			get; set;
		}

		public DiagramInfo() {
			Id = Guid.Empty;
			RootElementId = Guid.Empty;
			Caption = string.Empty;
			Entities = new List<EntityInfo>();
			Connections = new List<ConnectionInfo>();
			Labels = new List<ConnectionLabel>();
			Groups = new List<RelationshipGroup>();
		}

	}

	#endregion

	#region Class: EntityInfo

	[DataContract]
	public class EntityInfo
	{
		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "recordId")]
		public Guid RecordId {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "subCaption")]
		public string SubCaption {
			get; set;
		}

		[DataMember(Name = "info")]
		public string Info {
			get; set;
		}

		[DataMember(Name = "largeImage")]
		public string Image {
			get; set;
		}

		[DataMember(Name = "type")]
		public string ElementType {
			get; set;
		}

		[DataMember(Name = "groups")]
		public List<RelationshipInGroup> Groups {
			get; set;
		}

		[DataMember(Name = "canRead")]
		public bool CanRead {
			get; set;
		}

		[DataMember(Name = "isDeleted")]
		public bool IsDeleted {
			get; set;
		}

	}

	#endregion

	#region Class: ConnectionInfo

	[DataContract]
	public class ConnectionInfo : IEquatable<ConnectionInfo>
	{
		#region Properties: Public

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "source")]
		public Guid Source {
			get; set;
		}

		[DataMember(Name = "target")]
		public Guid Target {
			get; set;
		}

		[DataMember(Name = "type")]
		public string ElementType {
			get; set;
		}

		[DataMember(Name = "relationshipType")]
		public RelationshipType RelationshipType {
			get; set;
		}

		[DataMember(Name = "comment")]
		public string Comment {
			get; set;
		}

		[DataMember(Name = "name")]
		public string Name {
			get; set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Equals connection with this.
		/// </summary>
		/// <param name="connection">Conenction.</param>
		/// <returns>Equals value.</returns>
		public bool Equals(ConnectionInfo connection) {
			if (ReferenceEquals(connection, null)) {
				return false;
			}

			if (ReferenceEquals(this, connection)) {
				return true;
			}

			return Source.Equals(connection.Source) && Target.Equals(connection.Target)
				&& ElementType.Equals(connection.ElementType) && RelationshipType.Equals(connection.RelationshipType);
		}

		/// <summary>
		/// Returns hash code.
		/// </summary>
		/// <returns>Hash code.</returns>
		public override int GetHashCode() {
			int sourceHash = Source.GetHashCode();
			int targetHash = Target.GetHashCode();
			int elementTypeHash = ElementType.GetHashCode();
			int relationshipType = RelationshipType.GetHashCode();
			return sourceHash ^ targetHash ^ elementTypeHash ^ relationshipType;
		}

		#endregion

	}

	#endregion

	#region Class: ConnectionLabel

	[DataContract]
	public class ConnectionLabel
	{
		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "type")]
		public string Type {
			get; set;
		}

		[DataMember(Name = "parent")]
		public Guid Parent {
			get; set;
		}


	}

	#endregion

	#region Class: RelationshipGroup

	[DataContract]
	public class RelationshipGroup
	{

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "color")]
		public string Color {
			get; set;
		}

		[DataMember(Name = "comment")]
		public string Comment {
			get; set;
		}

		public List<Guid> Entities {
			get; set;
		}
	}

	#endregion

	#region Class: RelationshipInGroup

	[DataContract]
	public class RelationshipInGroup
	{
		[DataMember(Name = "id")]
		public Guid GroupId {
			get; set;
		}

		[DataMember(Name = "comment")]
		public String Comment {
			get; set;
		}

	}

	#endregion

	#region DiagramElement

	#region Class: DiagramElement

	[DataContract]
	public class DiagramElement
	{
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "captionNoAccess", EmitDefaultValue = false)]
		public string CaptionNoAccess {
			get; set;
		}

		[DataMember(Name = "width", EmitDefaultValue = false)]
		public int Width {
			get; set;
		}

		[DataMember(Name = "height", EmitDefaultValue = false)]
		public int Height {
			get; set;
		}

		[DataMember(Name = "imageWidth", EmitDefaultValue = false)]
		public int ImageWidth {
			get; set;
		}

		[DataMember(Name = "imageHeight", EmitDefaultValue = false)]
		public int ImageHeight {
			get; set;
		}


		[DataMember(Name = "fill", EmitDefaultValue = false)]
		public string Fill {
			get; set;
		}


		[DataMember(Name = "fillInParent", EmitDefaultValue = false)]
		public string FillInParent {
			get; set;
		}

		[DataMember(Name = "stroke", EmitDefaultValue = false)]
		public string Stroke {
			get; set;
		}


		[DataMember(Name = "type")]
		public string RelationshipType {
			get; set;
		}

		[DataMember(Name = "largeImage", EmitDefaultValue = false)]
		public string LargeImage {
			get; set;
		}

		[DataMember(Name = "largeImageNoAccess", EmitDefaultValue = false)]
		public string LargeImageNoAccess {
			get; set;
		}

		[DataMember(Name = "entitySchemaData", EmitDefaultValue = false)]
		public EntitySchemaData EntitySchemaData {
			get; set;
		}

	}

	#endregion

	#region Class: EntitySchemaData

	[DataContract]
	public class EntitySchemaData
	{
		[DataMember(Name = "name")]
		public string Name {
			get; set;

		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;

		}

		[DataMember(Name = "uId")]
		public Guid UId {
			get; set;

		}
	}

	#endregion

	#region Class: ElementToolsConfig

	[DataContract]
	public class ElementToolsConfig
	{

		[DataMember(Name = "addItems")]
		public List<ToolItem> AddItems {
			get; set;
		}

		[DataMember(Name = "tools")]
		public ToolObject Tools {
			get; set;
		}

		[DataMember(Name = "innerTools")]
		public InnerToolObject InnerTools {
			get; set;
		}

	}

	#endregion

	#region Class: ToolObject

	[DataContract]
	public class ToolObject
	{

		[DataMember(Name = "add")]
		public ToolItem Add {
			get; set;
		}

		[DataMember(Name = "connect")]
		public ToolItem Connect {
			get; set;
		}


		[DataMember(Name = "setup")]
		public ToolItem Setup {
			get; set;
		}

		[DataMember(Name = "delete")]
		public ToolItem Delete {
			get; set;
		}

	}

	#endregion

	#region Class: InnerToolObject

	[DataContract]
	public class InnerToolObject
	{

		[DataMember(Name = "toggle")]
		public InnerToolItem Toggle {
			get; set;
		}

	}

	#endregion

	#region Class: ToolItem

	[DataContract]
	public class ToolItem
	{

		[DataMember(Name = "imageUrl", EmitDefaultValue = false)]
		public string ImageUrl {
			get; set;
		}

		[DataMember(Name = "title")]
		public string Title {
			get; set;
		}

		[DataMember(Name = "type", EmitDefaultValue = false)]
		public string Type {
			get; set;
		}

	}

	#endregion

	#region Class: InnerToolItem

	[DataContract]
	public class InnerToolItem
	{

		[DataMember(Name = "collapseImageUrl")]
		public string CollapseImageUrl {
			get; set;
		}

		[DataMember(Name = "expandImageUrl")]
		public string ExpandImageUrl {
			get; set;
		}

	}

	#endregion

	#region Class: DiagramConfig

	[DataContract]
	public class DiagramConfig
	{

		[DataMember(Name = "customDiagramElements")]
		public List<DiagramElement> CustomDiagramElements {
			get; set;
		}

		[DataMember(Name = "customElementToolsConfig")]
		public ElementToolsConfig CustomElementToolsConfig {
			get; set;
		}

	}

	#endregion

	#endregion

}

#endregion

