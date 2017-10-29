using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRMaket
{
    /// <summary>
    /// Контейнер для Web User'ов
    /// </summary>
	public static class Users
	{
		static List<WebUser> activeUsers = new List<WebUser>();

		public static WebUser UserByCid(string cid)
		{
			foreach (var item in activeUsers)
			{
				if (item.ConnectionId == cid)
				{
					return item;
				}
			}
			return null;
		}
		public static void ConnectUser(WebUser wu)
		{
			if (wu == null)
				throw new NullReferenceException("wu");
			if (UserByCid(wu.ConnectionId) != null)
				return;
			activeUsers.Add(wu);
		}
		public static bool DisconnectUser(WebUser wu)
		{
			return
				activeUsers.Remove(wu) ||
				(
					((wu = UserByCid(wu.ConnectionId)) != null) &&
					activeUsers.Remove(wu)
				);
		}
	}

    /// <summary>
    /// Инкапсулирует Пользователя и его Connection Id (уникальный ключ сессии или типа того)
    /// </summary>
	public class WebUser
	{
		private Пользователь AggregateObj;
		public string ConnectionId { get; set; }
		public Пользователь _User { get { return AggregateObj; } set { AggregateObj = value; } }
		public WebUser(Пользователь u, string cid)
		{
			ConnectionId = cid;
			AggregateObj = u;
		}
	}
}