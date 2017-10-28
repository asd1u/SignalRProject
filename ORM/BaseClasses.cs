using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
	public class HtmlGetter
	{
		public static string getString(string id)
		{
			if (id == "menu")
				return @"<button id='btnGet1' type='button' onclick='changeContent1()'>Get first</button> <button id='btnGet2' type='button' onclick='changeContent2()'>Get second</button><button id='btnGet3' type='button' onclick='changeContent3()'>Get third</button><span id='cont'></span>";
			if (id == "cont1")
				return @"<p /><button id='btnC1' type='button' onclick='alert(123);'>alert123</button>";
			if (id == "cont2")
				return @"<p />texttexttext<p /><button id='btnC2' type='button' onclick='alertAllCl();'>alertAllActiveUsers</button>";
			if (id == "cont3")
				return @"<p /><button id='btnC3' type='button' onclick='location.reload();'>logout</button>";
			return "";
		}
	}

	public class User
	{
		public string Login { get; set; }
		public string MD5Pass { get; set; }

		public static User LoadUser(string login, string pass)
		{
			if (login == "qpIlIpp")
			{
				return new User() { Login = login, MD5Pass = pass };
			}
			return null;
		}
	}

}
